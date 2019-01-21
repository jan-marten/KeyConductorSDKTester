using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyConductorSDKTester
{
    public partial class SpecialCharEditor : Form
    {
        public SpecialCharEditor()
        {
            InitializeComponent();
            
            //for(int iCol = 0; iCol < 5; iCol++)
            //{
            //    for(int iRow = 0; iRow < tableLayoutPanel1.getro)
            //}

            foreach(var c in tableLayoutPanel1.Controls)
            {
                if(c is Panel)
                {
                    var cPanel = (Panel)c;

                    cPanel.Click += SpecialCharEditor_Click;
                    cPanel.Tag = false;
                    cPanel.Cursor = Cursors.Hand;
                    cPanel.Dock = DockStyle.Fill;
                }
            }
            RedrawSpecialCharacter();

        }

        private void SpecialCharEditor_Click(object sender, EventArgs e)
        {
            if(sender is Panel)
            {
                var cPanel = (Panel)sender;
                if ((bool)(cPanel).Tag)
                {
                    cPanel.Tag = false;
                }
                else
                {
                    cPanel.Tag = true;
                }
            }
            RedrawSpecialCharacter();
        }

        private void RedrawSpecialCharacter()
        {
            var result = new byte[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            if(textBox1.Text.Length == 1)
            {
                result[8] = Encoding.ASCII.GetBytes(textBox1.Text)[0];
            }

            foreach (var c in tableLayoutPanel1.Controls)
            {
                if (c is Panel)
                {

                    var cPanel = (Panel)c;

                    var iCol = tableLayoutPanel1.GetColumn(cPanel);
                    var iRow = tableLayoutPanel1.GetRow(cPanel);

                    if((bool)cPanel.Tag)
                    {
                        cPanel.BackColor = Color.Lime;

                        result[iRow] |= (byte)(0x10 >> iCol);

                    }
                    else
                    {
                        cPanel.BackColor = Color.Black;
                    }
                }
            }

            textBox2.Text = Encoding.ASCII.GetString(result); // BitConverter.ToString(result);

            Invalidate();
        }

    }
}
