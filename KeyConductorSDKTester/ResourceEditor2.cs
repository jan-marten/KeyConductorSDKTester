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

namespace KeyConductorSDKTester
{
    public partial class ResourceEditor2 : Form
    {
        KeyConductorSDK.V2.Resources _resources2;

        public KeyConductorSDK.KeyConductorClient Client { get; set; }

        public ResourceEditor2()
        {
            InitializeComponent();

            _resources2 = new KeyConductorSDK.V2.Resources();
            dataGridView1.DataSource = _resources2.ResourceTable;

            // 1 - restore button
            ToolStripItem itmRestore = new ToolStripMenuItem("Restore");
            itmRestore.Click += (s, evtArg) => _resources2.Clear();
            templatesToolStripMenuItem.DropDownItems.Add(itmRestore);

            // 2 - a seperator line
            templatesToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());

            // 3 - enumerate available resources
            var allResources = _resources2.ListAvailableResources();
            foreach (var r in allResources)
            {
                ToolStripItem itmResource = new ToolStripMenuItem(r);
                itmResource.Click += (s, evtArg) => _resources2.LoadResource(itmResource.Text);
                templatesToolStripMenuItem.DropDownItems.Add(itmResource);

            }


            // 4 - done


        }

        private void openResourceKCLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // load resources from a file
            //FileDialog dlgOpen = new FileDialog();
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.FileName = "Resource.KCL";
            dlgOpen.Filter = "KeyConductor configuration|*.kcl|All files|*.*";
            if (dlgOpen.ShowDialog(this) == DialogResult.OK)
            {
                if (File.Exists(dlgOpen.FileName) == false) return;

                byte[] arrBytes = System.IO.File.ReadAllBytes(dlgOpen.FileName);

                _resources2.Load(dlgOpen.FileName);

            }
        }

        private void saveResourceKCLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlgSave = new SaveFileDialog();
            dlgSave.FileName = "Resource.KCL";
            dlgSave.Filter = "KeyConductor configuration|*.kcl|All files|*.*";


            if (dlgSave.ShowDialog(this) == DialogResult.OK)
            {
                // save every row which has no NULL value
                _resources2.Save(dlgSave.FileName);

            }

        }

    

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                ToolStripMenuItem itm = (ToolStripMenuItem)sender;
                string copyData = itm.Text.Substring(itm.Text.Length - 2, 1);
                Clipboard.SetText(copyData);
            }
            catch (Exception)
            {
            }
        }

        private void transmitResourceKCLToKeyConductorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Client != null && Client.IsConnected())
            {
                string tmpFilename = Path.GetTempFileName();


                _resources2.Save(tmpFilename);

                Client.PutFile(tmpFilename, KeyConductorSDK.Protocol.FileName.ResourceKCL);

            }
            else
            {
                MessageBox.Show("Client not connected");
            }
        }

    }
}
