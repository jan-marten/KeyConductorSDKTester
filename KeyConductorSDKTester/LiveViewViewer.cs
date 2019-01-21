using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using KeyConductorSDK;

namespace KeyConductorSDKTester
{
    public partial class LiveViewViewer : Form
    {
        public LiveViewViewer()
        {
            InitializeComponent();
        }

        private void LiveViewViewer_Load(object sender, EventArgs e)
        {
            string prevFilename = Properties.Settings.Default.PreviousLogFile;
            if (prevFilename.Length > 0)
            {
                if (File.Exists(prevFilename))
                {
                    txtFilename.Text = prevFilename;
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory();

            if (txtFilename.Text.Length > 0 && File.Exists(txtFilename.Text))
            {
                FileInfo fi = new FileInfo(txtFilename.Text);
                path = fi.Directory.FullName;
            }

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = path;
            ofd.Filter = "KCL|*.kcl|V3|*.v3|All files|*.*";
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                txtFilename.Text = ofd.FileName;
                LoadLiveViewFile();
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadLiveViewFile();
        }



        private void LoadLiveViewFile()
        {


            if (File.Exists(txtFilename.Text) == false)
            {

            }
            else
            {
                Properties.Settings.Default.PreviousLogFile = txtFilename.Text;
                Properties.Settings.Default.Save();

                var arrBytes = File.ReadAllBytes(txtFilename.Text);

                if (txtFilename.Text.ToUpper().EndsWith(".V3"))
                {
                    var lv = new KeyConductorSDK.V3.LiveViewEventArgs("160101010101", Protocol.ReturnValues.OK, 0, arrBytes);
                    textBox1.Text = lv.ToString() + "\r\n" + lv.SlotsToString();
                }
                else
                {
                    var lv = new KeyConductorSDK.V2.LiveViewEventArgs("160101010101", Protocol.ReturnValues.OK, 0, arrBytes);
                    textBox1.Text = lv.ToString() + "\r\n" + lv.SlotsToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder s = new StringBuilder();

            string path = @"D:\temp\2016-10-10 Kelso files\LOGDATA.LiveView.160921115454.20161010153847";
            if (Directory.Exists(path) == false) return;

            var dirInfo = new DirectoryInfo(path);

            var fiFiles = dirInfo.GetFiles().OrderBy(f => f.LastWriteTime).ToArray();

            foreach (var fiFile in fiFiles)
            {
                var arrBytes = File.ReadAllBytes(fiFile.FullName);
                var lv = new KeyConductorSDK.V2.LiveViewEventArgs("160101010101", Protocol.ReturnValues.OK, 0, arrBytes);

                for (int i = lv.Slots.Count - 1; i >= 0; i--)
                {
                    if (lv.Slots[i].Position == 51)
                    {
                        //s.AppendLine(string.Format("{0} - {1} - {2}"))
                        s.AppendLine(fiFile.Name + " ::: " + lv.Slots[i].ToString());
                        i = -1;
                        break;
                    }
                }

            }

            textBox1.Text = s.ToString();
        }
    }
}
