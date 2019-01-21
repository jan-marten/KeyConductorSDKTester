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
    public partial class KeyConductorEmulator : Form
    {
        private Classes.KeyConductorServer _server;

        public KeyConductorEmulator()
        {
            InitializeComponent();

            _server = new Classes.KeyConductorServer();
            _server.OnLogMessage += _server_OnLogMessage;
        }

        private void _server_OnLogMessage(object sender, Classes.LogMessageEventArgs e)
        {
            AddLog(e.Message);

        }

        private delegate void AddLogDelegate(string msg);
        private void AddLog(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new AddLogDelegate(AddLog), new object[] { msg });
            }
            else
            {
                int maxLengthLog = 10000000;
                if (txtDbgLog2.TextLength > maxLengthLog) txtDbgLog2.Text = txtDbgLog2.Text.Substring(txtDbgLog2.Text.Length - maxLengthLog);
                txtDbgLog2.AppendText("\r\n" + DateTime.Now.ToString("hh:mm:ss.ffff") + " - " + msg);
                txtDbgLog2.Select(txtDbgLog2.TextLength, 0);
                txtDbgLog2.ScrollToCaret();
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            UInt32 tmpKcid = 0;
            DateTime dtKCID = DateTime.Now;
            if (DateTime.TryParseExact("20" + txtDebugKCID.Text, "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out dtKCID))
            {
                // Timezone KeyConductor = +1 hour (fixed)
                // Use ToUniversalTime for TimeZone independant times
                // var secs = (dtKCID - new DateTime(1970, 1, 1).AddSeconds(3600).ToUniversalTime()).TotalSeconds;
                // secs = (dtKCID - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds;
                // 22-04-2014 - fix for DST

                DateTime epochUTC = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                var secs = (dtKCID - epochUTC).TotalSeconds;
                tmpKcid = (UInt32)secs;
            }
            else
            {
                // invalid KCID
                throw new ArgumentOutOfRangeException("KCID", "Invalid KeyConductor ID. Use format yyMMddHHmmss.");
            }

            _server.StartListening(int.Parse(txtDebugPort.Text), tmpKcid);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _server.SendDoorOpenEvent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            _server.SendDoorClosedEvent();
        }


        private string _lastUsercode = "";
        private string _lastPincode = "";
        private string _lastSwipe = "";

        private void btnLogin_UserPin_Click(object sender, EventArgs e)
        {
            _lastUsercode = txtUserCode.Text;
            _lastPincode = txtPinCode.Text;
            _lastSwipe = "";
            _server.SendLogin(_lastUsercode, _lastPincode, _lastSwipe);
        }

        private void btnLogin_Pin_Click(object sender, EventArgs e)
        {
            _lastUsercode = "";
            _lastPincode = txtPinCode.Text;
            _lastSwipe = "";
            _server.SendLogin(_lastUsercode, _lastPincode, _lastSwipe);
        }

        private void btnLogin_Swipe_Click(object sender, EventArgs e)
        {
            _lastUsercode = "";
            _lastPincode = "";
            _lastSwipe = txtSwipeCard.Text;
            _server.SendLogin(_lastUsercode, _lastPincode, _lastSwipe);
        }

        private void btnLogin_SwipePin_Click(object sender, EventArgs e)
        {
            _lastUsercode = "";
            _lastPincode = txtPinCode.Text;
            _lastSwipe = txtSwipeCard.Text;
            _server.SendLogin(_lastUsercode, _lastPincode, _lastSwipe);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            _server.SendLogout(_lastUsercode, _lastPincode, _lastSwipe); 
        }
    }
}
