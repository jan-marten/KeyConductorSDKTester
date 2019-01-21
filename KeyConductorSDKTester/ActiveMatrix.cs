using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using V3 = KeyConductorSDK.V3;

namespace KeyConductorSDKTester
{
    public partial class ActiveMatrix : UserControl
    {
        public ActiveMatrix()
        {
            InitializeComponent();
        }

        public void LoadMatrix(V3.ActiveMatrix matrix)
        {
            Reset(true);
            if (matrix == null) return;

            for (int day = 0; day < 7; day++)
            {
                for (int hour = 0; hour < 24; hour++)
                {
                    var dateTime = new DateTime(2016, 10, 24).AddDays(day).AddHours(hour);
                    var checkBox = (CheckBox)tableLayoutPanel1.GetControlFromPosition(hour + 1, day + 1);
                    var active = matrix.Get(dateTime);
                    if (checkBox != null) checkBox.Checked = active;
                }
            }
        }

        public V3.ActiveMatrix GetMatrix()
        {
            var matrix = new V3.ActiveMatrix();
            matrix.Reset(false);
            for (int day = 0; day < 7; day++)
            {
                for (int hour = 0; hour < 24; hour++)
                {
                    var checkBox = (CheckBox)tableLayoutPanel1.GetControlFromPosition(hour + 1, day + 1);
                    if (checkBox != null && checkBox.Checked)
                    {
                        var dateTime = new DateTime(2016, 10, 24).AddDays(day).AddHours(hour);
                        matrix.SetRange(dateTime, new TimeSpan(1, 0, 0), true);
                        
                    }
                }
            }

            return matrix;
        }

        public void Reset(bool value)
        {
            foreach (var c in Controls)
            {
                if (c is CheckBox)
                {
                    ((CheckBox)c).Checked = value;
                }
            }
        }

        private void label26_Click(object sender, EventArgs e)
        {

            var lblSender = sender as Label;
            if (lblSender == null) return;

            var celPos = tableLayoutPanel1.GetCellPosition(lblSender);

            if(celPos.Column == 0)
            {
                var firstBox = (CheckBox)tableLayoutPanel1.GetControlFromPosition(celPos.Column + 1, celPos.Row);
                var firstBoxChecked = firstBox.Checked;
                for(int hour = 0; hour < 24; hour++)
                {
                    var checkBox = (CheckBox)tableLayoutPanel1.GetControlFromPosition(hour + 1, celPos.Row);
                    checkBox.Checked = !firstBoxChecked;
                }
            }
            else if (celPos.Row == 0)
            {
                var firstBox = (CheckBox)tableLayoutPanel1.GetControlFromPosition(celPos.Column, celPos.Row + 1);
                var firstBoxChecked = firstBox.Checked;
                for (int day = 0; day < 7; day++)
                {
                    var checkBox = (CheckBox)tableLayoutPanel1.GetControlFromPosition(celPos.Column, day + 1);
                    checkBox.Checked = !firstBoxChecked;
                }
            }

        }
    }
}
