using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using V2 = KeyConductorSDK.V2;
using V3 = KeyConductorSDK.V3;

namespace KeyConductorSDKTester
{
    public partial class FormMatrixTester : Form
    {
        public FormMatrixTester()
        {
            InitializeComponent();
        }

        private void btnDowngrade_Click(object sender, EventArgs e)
        {
            var m = activeMatrix1.GetMatrix();
            V2.ActiveDays flags = V2.ActiveDays.None;
            byte startTime = 0;
            byte endTime = 0;
            m.Downgrade(false, out flags, out startTime, out endTime);

            chkMonday.Checked = flags.HasFlag(V2.ActiveDays.Monday);
            chkTuesday.Checked = flags.HasFlag(V2.ActiveDays.Tuesday);
            chkWednesday.Checked = flags.HasFlag(V2.ActiveDays.Wednesday);
            chkThursday.Checked = flags.HasFlag(V2.ActiveDays.Thursday);
            chkFriday.Checked = flags.HasFlag(V2.ActiveDays.Friday);
            chkSaturday.Checked = flags.HasFlag(V2.ActiveDays.Saturday);
            chkSunday.Checked = flags.HasFlag(V2.ActiveDays.Sunday);

            nudFrom.Value = startTime;
            nudTo.Value = endTime;

        }

        private void btnUpgrade_Click(object sender, EventArgs e)
        {
            V2.ActiveDays flags = V2.ActiveDays.None;
            byte startTime = 0;
            byte endTime = 0;

            if(chkMonday.Checked) flags |= V2.ActiveDays.Monday;
            if (chkTuesday.Checked) flags |= V2.ActiveDays.Tuesday;
            if (chkWednesday.Checked) flags |= V2.ActiveDays.Wednesday;
            if (chkThursday.Checked) flags |= V2.ActiveDays.Thursday;
            if (chkFriday.Checked) flags |= V2.ActiveDays.Friday;
            if (chkSaturday.Checked) flags |= V2.ActiveDays.Saturday;
            if (chkSunday.Checked) flags |= V2.ActiveDays.Sunday;

            startTime = (byte)nudFrom.Value;
            endTime = (byte)nudTo.Value;

            var m = new V3.ActiveMatrix();
            m.Set(flags, startTime, endTime);

            activeMatrix2.LoadMatrix(m);
        }
    }
}
