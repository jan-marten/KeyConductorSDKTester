using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyConductorSDK;
using System.IO;
using System.Diagnostics;
using System.Globalization;

namespace KeyConductorSDKTester
{
    public partial class Form1 : Form
    {
        KeyConductorClient _client;

        int RXCount;
        int TXCount;
        StreamWriter _swDataLoggerTXT;
        StreamWriter _swDataLoggerBIN;

        public Form1()
        {
            InitializeComponent();

            _client = new KeyConductorClient();

            // bind all events from client
            _client.OnMessage += _client_OnMessage;
            _client.OnCommand += _client_OnCommand;

            // events

            _client.OnPutFile += _client_OnPutFile;
            _client.OnGetFile += _client_OnGetFile;
            _client.OnGetInfo += _client_OnGetInfo;

            _client.OnRemoteAuthentication += _client_OnRemoteAuthentication;

            _client.OnRawDataReceived += _client_OnRawDataReceived;
            _client.OnRawDataSend += _client_OnRawDataSend;

            _client.OnGetLiveView += _client_OnGetLiveView;
            _client.OnGetLiveView3 += _client_OnGetLiveView3;
            _client.OnSetDateTime += _client_OnSetDateTime;

            // OnEvents
            _client.OnEventLogin += _client_OnEventLogin;
            _client.OnEventLogout += _client_OnEventLogout;
            _client.OnEventDoorOpen += _client_OnEventDoorOpen;
            _client.OnEventDoorClosed += _client_OnEventDoorClosed;
            _client.OnEventKeyPicked += _client_OnEventKeyPicked;
            _client.OnEventKeyReturned += _client_OnEventKeyReturned;
            _client.OnEventWarning += _client_OnEventWarning;
            _client.OnEventTimeout += _client_OnEventTimeout;
            _client.OnEventAlarm += _client_OnEventAlarm;
            _client.OnEventAlarmCleared += _client_OnEventAlarmCleared;

            _client.OnRemoteReturn += _client_OnRemoteReturn;
            _client.OnRemoteReboot += _client_OnRemoteReboot;

            _client.OnEventMainsVoltageLost += _client_OnEventMainsVoltageLost;
            _client.OnEventMainsVoltageConnected += _client_OnEventMainsVoltageConnected;

            _client.OnRegisterMileage += _client_OnRegisterMileage;

            // Locker event (3.4.3)
            _client.OnLockerDoorOpened += _client_OnLockerDoorOpened;
            _client.OnLockerDoorClosed += _client_OnLockerDoorClosed;
            _client.OnLockerAssetRemoved += _client_OnLockerRemoved;
            _client.OnLockerAssetReturned += _client_OnLockerReturned;

        }

        private void _client_OnLockerReturned(object sender, OnEventLockerEventArgs e)
        {
            AddLog("Locker returned:" + e.ToString());

        }

        private void _client_OnLockerRemoved(object sender, OnEventLockerEventArgs e)
        {
            AddLog("Locker removed:" + e.ToString());

        }

        private void _client_OnLockerDoorClosed(object sender, OnEventLockerEventArgs e)
        {
            AddLog("Locker door closed:" + e.ToString());

        }

        private void _client_OnLockerDoorOpened(object sender, OnEventLockerEventArgs e)
        {
            AddLog("Locker door opened:" + e.ToString());

        }

        private void _client_OnRegisterMileage(object sender, OnRegisterMileageEventArgs e)
        {
            AddLog("Mileage registration: " + e.ToString());
            _client.RegisterMileageResponse((uint)nudMileageMin.Value, (uint)nudMileageMax.Value);

        }

        private void _client_OnEventMainsVoltageConnected(object sender, OnEventWarningEventArgs e)
        {
            AddLog("Main voltage connected:" + e.ToString());

        }

        private void _client_OnEventMainsVoltageLost(object sender, OnEventWarningEventArgs e)
        {
            AddLog("Main voltage lost:" + e.ToString());
        }

        private void _client_OnEventAlarm(object sender, OnEventWarningEventArgs e)
        {
            AddLog("External alarm:" + e.ToString());
        }

        private void _client_OnEventAlarmCleared(object sender, OnEventWarningEventArgs e)
        {
            AddLog("External alarm cleared:" + e.ToString());

        }

        private void _client_OnRemoteReboot(object sender, KeyConductorBaseReplyEventArgs e)
        {
            AddLog("OnRemoteReboot:" + e.ToString());
        }

        private void _client_OnRemoteReturn(object sender, KeyConductorBaseReplyEventArgs e)
        {
            AddLog("OnRemoteReturn:" + e.ToString());
        }

        private void _client_OnSetDateTime(object sender, KeyConductorBaseReplyEventArgs e)
        {
            //throw new NotImplementedException();\
            AddLog(System.Reflection.MethodBase.GetCurrentMethod().Name + " -> " + e.ResultCode.ToString());

#if DEBUG
            // Test to fill the LOG
            // This was usefull for testing Overflow errors in the Digi module caused by slow network (VPN?)
            // Firmware 3.4.9 fixed the Overflow errors
            if (chkGetInfoContinue.Checked)
            {
                System.Threading.Thread.Sleep(50);
                _client.SetDateTime(DateTime.Now);

            }
#endif
        }

        private void _client_OnEventTimeout(object sender, OnEventWarningEventArgs e)
        {
            AddLog(System.Reflection.MethodBase.GetCurrentMethod().Name + " -> " + e.UserCode);
        }

        private void _client_OnEventWarning(object sender, OnEventWarningEventArgs e)
        {
            AddLog(System.Reflection.MethodBase.GetCurrentMethod().Name + " -> " + e.UserCode);
        }

        private void _client_OnEventKeyReturned(object sender, OnEventKeyEventArgs e)
        {
            AddLog(System.Reflection.MethodBase.GetCurrentMethod().Name + " -> " + e.ToString());
        }

        private void _client_OnEventKeyPicked(object sender, OnEventKeyEventArgs e)
        {
            AddLog(System.Reflection.MethodBase.GetCurrentMethod().Name + " -> " + e.ToString());
        }

        private void _client_OnEventDoorClosed(object sender, OnEventDoorEventArgs e)
        {
            AddLog(System.Reflection.MethodBase.GetCurrentMethod().Name + " -> " + e.UserCode + ", Door: 0x" + e.DoorNumber.ToString("X"));
        }

        private void _client_OnEventDoorOpen(object sender, OnEventDoorEventArgs e)
        {
            AddLog(System.Reflection.MethodBase.GetCurrentMethod().Name + " -> " + e.UserCode + ", Door: 0x" + e.DoorNumber.ToString("X"));
        }

        private void _client_OnEventLogout(object sender, OnEventUserEventArgs e)
        {
            AddLog(System.Reflection.MethodBase.GetCurrentMethod().Name + " -> " + e.ToString());
        }

        private void _client_OnEventLogin(object sender, OnEventUserEventArgs e)
        {
            AddLog(System.Reflection.MethodBase.GetCurrentMethod().Name + " -> " + e.ToString());

        }

        void _client_OnGetLiveView(object sender, KeyConductorSDK.V2.LiveViewEventArgs e)
        {

            // GetLiveView performance (firmware 2.16RC7):
            //  24 slots = 1,2 sec
            // 108 slots = 2 sec
            // 180 slots ~= 3 sec
            // Parsing of slots in LVEventArgs is 1 ms

            if (e.ResultCode == Protocol.ReturnValues.OK)
            {
                AddLog("Result GetLiveView at " + DateTime.Now.ToString("HH:mm:ss:fff"));

                string filename = "GetFileResult." + e.Filename.ToString();

                if (filename.EndsWith("KCL")) filename += ".kcl";
                if (filename.EndsWith("V3")) filename += ".v3";

                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
                File.WriteAllBytes(filename, e.GetContents());
                AddLog("File saved as " + filename);

                AddLog(e.ToString());
                AddLog(e.SlotsToString());
                AddLog("Result GetLiveView done printing at " + DateTime.Now.ToString("HH:mm:ss:fff"));

            }


        }

        void _client_OnGetLiveView3(object sender, KeyConductorSDK.V3.LiveViewEventArgs e)
        {

            // GetLiveView performance (firmware 3.1.0):
            if (e.ResultCode == Protocol.ReturnValues.OK)
            {
                AddLog("Result GetLiveView at " + DateTime.Now.ToString("HH:mm:ss:fff"));

                string filename = "GetFileResult." + e.Filename.ToString();

                if (filename.EndsWith("KCL")) filename += ".kcl";
                if (filename.EndsWith("V3")) filename += ".v3";

                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
                File.WriteAllBytes(filename, e.GetContents());
                AddLog("File saved as " + filename);

                AddLog(e.ToString());
                AddLog(e.SlotsToString());
                AddLog("Result GetLiveView done printing at " + DateTime.Now.ToString("HH:mm:ss:fff"));

            }

        }


        void _client_OnRemoteAuthentication(object sender, RemoteAuthenticationEventArgs e)
        {
            AddLog(e.ToString());
            GenerateConfigUsersAndTransmit(e.UserCode, e.PinCode, e.UserData);
        }

        private void GenerateConfigUsersAndTransmit(string userCode, string pinCode, string userData)
        {
            if (userCode == "0000") userCode = "1234"; // used for pincode only and swipecard logon


            if (_client.FirmwareVersion.Major == 2)
            {

                if (optRemoteAuth_Deny.Checked)
                {

                    AddLog(string.Format("Denying UserCode={0} PinCode={1} Swipecard={2}", userCode, pinCode, userData));
                    _client.AuthenticateRemoteUser(false, 0, 0, "Invalid user", false, new List<byte>() { 0 }, "", 0x00);
                }
                else
                {
                    AddLog(string.Format("Authenticating UserCode={0} PinCode={1} Swipecard={2} Supervisor={3}", userCode, pinCode, userData, optRemoteAuth_SuperVisor.Checked));
                    _client.AuthenticateRemoteUser(true, short.Parse(userCode), short.Parse(pinCode), "Remote user", optRemoteAuth_SuperVisor.Checked, new List<byte>() { 1, 2, 3, 4 }, userData, 0xFF);
                }
            }
            else if (_client.FirmwareVersion.Major == 3)
            {
                if (optRemoteAuth_Deny.Checked)
                {
                    AddLog(string.Format("Denying UserCode={0} PinCode={1} Swipecard={2}", userCode, pinCode, userData));
                    KeyConductorSDK.V3.User nullUser = null;
                    _client.AuthenticateRemoteUser(nullUser);
                }
                else if (optRemoteAuth_AssignSwipecard.Checked)
                {
                    _client.AssignSwipecard();
                }
                else
                {
                    AddLog(string.Format("Authenticating UserCode={0} PinCode={1} Swipecard={2} Supervisor={3}", userCode, pinCode, userData, optRemoteAuth_SuperVisor.Checked));
                    var usr3 = new KeyConductorSDK.V3.User();
                    usr3.Description = "Remote user";
                    usr3.UserID = ushort.Parse(userCode);
                    usr3.Pincode = ushort.Parse(pinCode);
                    usr3.Swipecard = userData;

                    usr3.UserFlags = KeyConductorSDK.V3.UserFlag.None;
                    if (optRemoteAuth_SuperVisor.Checked) usr3.UserFlags = KeyConductorSDK.V3.UserFlag.Supervisor;

                    var lstRemoteAuthGroups = txtRemoteAuthGroups.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (lstRemoteAuthGroups.Count() > 0)
                    {
                        foreach(var g in lstRemoteAuthGroups)
                        {
                            if (usr3.Groups.Count <= 50)
                            {
                                usr3.Groups.Add(ushort.Parse(g));
                            }
                            else
                            {
                                AddLog("User group count overflow. Max groups for user structure is 50.");
                                break;
                            }
                        }
                    }

                    _client.AuthenticateRemoteUser(usr3);
                }
            }
        }

        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }


        void _client_OnRawDataSend(object sender, RawDataEventArgs e)
        {
            //throw new NotImplementedException();
            var data = e.GetData();

            AddLog("TX:" + BitConverter.ToString(data));
            TXCount += data.Length;
            UpdateDataCounters();

            if (chkDataLog.Checked)
            {
                OpenDataLogger();
                _swDataLoggerTXT.WriteLine(string.Format("TX({0}/{1}):{2}", data.Length, TXCount, BitConverter.ToString(data)));
                // Do not store data in BIN version
            }
        }

        void _client_OnRawDataReceived(object sender, RawDataEventArgs e)
        {

            var data = e.GetData();
            AddLog("RX:" + data.Length + " bytes:" + BitConverter.ToString(data));

            RXCount += data.Length;
            UpdateDataCounters();

            if (chkDataLog.Checked)
            {
                OpenDataLogger();
                _swDataLoggerTXT.WriteLine(string.Format("RX({0}/{1}):{2}", data.Length, RXCount, BitConverter.ToString(data)));
                _swDataLoggerBIN.BaseStream.Write(data, 0, data.Length);
            }

        }

        private void OpenDataLogger()
        {
            if (_swDataLoggerTXT == null)
            {
                _swDataLoggerTXT = new StreamWriter($"DataLog_{DateTime.Now.ToString("yyMMddTHHmmss")}.txt", true, Encoding.Default);
                _swDataLoggerTXT.AutoFlush = true;
            }
            if (_swDataLoggerBIN == null)
            {
                _swDataLoggerBIN = new StreamWriter($"DataLog_{DateTime.Now.ToString("yyMMddTHHmmss")}.bin", true, Encoding.Default);
                _swDataLoggerBIN.AutoFlush = true;
            }
        }


        private void chkDataLog_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDataLog.Checked == false && _swDataLoggerTXT != null)
            {
                _swDataLoggerTXT.Close();
                _swDataLoggerTXT.Dispose();
                _swDataLoggerTXT = null;
            }
            if (chkDataLog.Checked == false && _swDataLoggerBIN != null)
            {
                _swDataLoggerBIN.Close();
                _swDataLoggerBIN.Dispose();
                _swDataLoggerBIN = null;
            }
        }


        void _client_OnGetInfo(object sender, GetInfoEventArgs e)
        {
            AddLog(System.Reflection.MethodBase.GetCurrentMethod().Name + " -> " + e.ResultCode.ToString() + " -> " + e.infoVersion.ToString());

            if (e.ResultCode != Protocol.ReturnValues.OK &&
                chkAutoUpdateKCID.Checked)
            {
                ReconnectWithValidKCID(e.GetKCIDSerialNumber());
            }

            if (chkGetInfoContinue.Checked)
            {
                System.Threading.Thread.Sleep(250);
                _client.GetInfo();
            }
        }

        private delegate void ReconnectWithValidKCIDDelegate(string kcid);
        private void ReconnectWithValidKCID(string kcid)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new ReconnectWithValidKCIDDelegate(ReconnectWithValidKCID), new object[] { kcid });
                }
                else
                {
                    _client.Disconnect();
                    txtDebugKCID.Text = kcid;
                    txtDebugKCID.BackColor = Color.Yellow;
                    AddLog("Updating to valid KCID");
                    btnDbgConnect_Click(null, null);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        void _client_OnGetFile(object sender, GetFileEventArgs e)
        {
            AddLog(System.Reflection.MethodBase.GetCurrentMethod().Name + " -> " + e.ResultCode.ToString());
            if (e.ResultCode == Protocol.ReturnValues.OK)
            {
                string filename = "GetFileResult." + e.Filename.ToString();

                if (filename.EndsWith("KCL")) filename += ".kcl";
                if (filename.EndsWith("V3")) filename += ".v3";

                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
                File.WriteAllBytes(filename, e.GetContents());
                AddLog("File saved as " + filename);
            }
        }

        void _client_OnPutFile(object sender, KeyConductorBaseReplyEventArgs e)
        {
            AddLog(System.Reflection.MethodBase.GetCurrentMethod().Name + " -> " + e.ResultCode.ToString());
        }


        void _client_OnCommand(object sender, KeyConductorBaseReplyEventArgs e)
        {

            AddLog(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e.KCID + "=>" + e.GetKCIDSerialNumber() + " - " + e.CommandType.ToString() + " -> " + e.ResultCode.ToString());
        }

        void _client_OnMessage(object sender, KeyConductorRawCommandEventArgs e)
        {
            AddLog(System.Reflection.MethodBase.GetCurrentMethod().Name + " -> " + e.Message.ToString());

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtDebugIP.Text = global::KeyConductorSDKTester.Properties.Settings.Default.Hostname;
            txtDebugPort.Text = global::KeyConductorSDKTester.Properties.Settings.Default.Hostport;
            txtDebugKCID.Text = global::KeyConductorSDKTester.Properties.Settings.Default.KCID;

#if DEBUG
            groupBox1.Visible = true; // this is for remote authentication
            //btnEmulator_Click(null, null);
#endif

        }


        #region Debug buttons

        private void btnDbgConnect_Click(object sender, EventArgs e)
        {
            try
            {

                // no-todo - add exception logging functions !!

                btnDbgConnect.Enabled = false;

                global::KeyConductorSDKTester.Properties.Settings.Default.Hostname = txtDebugIP.Text;
                global::KeyConductorSDKTester.Properties.Settings.Default.Hostport = txtDebugPort.Text;
                global::KeyConductorSDKTester.Properties.Settings.Default.KCID = txtDebugKCID.Text;
                global::KeyConductorSDKTester.Properties.Settings.Default.Save();

                if (_client.IsConnected())
                {
                    _client.Disconnect();
                }
                else
                {
                    if (int.TryParse(txtDebugPort.Text, out int portNumber) == false)
                    {
                        portNumber = 2101;
                    }

                    _client.Connect(txtDebugKCID.Text, txtDebugIP.Text, portNumber);
                }

                if (_client.IsConnected())
                {
                    btnDbgConnect.Text = "Disconnect";
                    AddLog("Connected");
                }
                else
                {
                    btnDbgConnect.Text = "Connect";
                    AddLog("Disconnected");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Connect exception: " + ex.Message);

            }
            btnDbgConnect.Enabled = true;

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


        private delegate void UpdateDataCountersDelegate();
        private void UpdateDataCounters()
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new UpdateDataCountersDelegate(UpdateDataCounters));

                }
                else
                {

                    lblDataRXCount.Text = RXCount.ToString();
                    lblDataTXCount.Text = TXCount.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnDataReset_Click(object sender, EventArgs e)
        {
            RXCount = 0;
            TXCount = 0;
            lblDataRXCount.Text = "0";
            lblDataTXCount.Text = "0";
        }

        #endregion


        private void btnDbgGetInfo_Click(object sender, EventArgs e)
        {
            _client.GetInfo();
            AddLog("GetInfo");
        }

        private void btnUpdateFirmware_Click(object sender, EventArgs e)
        {
            if (_client == null)
            {
                AddLog("No client instance?");
            }
            else if (_client.FirmwareVersion.Major < 2 || _client.FirmwareVersion.Major > 3)
            {
                AddLog($"Firmware {_client.FirmwareVersion} is unsupported!");
            }
            else if (_client.FirmwareVersion.Major == 2)
            {
                string filename = @"firmware.bin";
                if (File.Exists(filename) && _client.FirmwareVersion.Major == 2)
                {
                    var data = File.ReadAllBytes(filename);
                    _client.PutFile(filename, Protocol.FileName.FirmwareBIN);
                }
                else
                {
                    AddLog("firmware.bin-file not found!");
                }
            }
            else if (_client.FirmwareVersion.Major == 3)
            {
                string filename = @"firmware.v3";
                if (File.Exists(filename))
                {
                    var data = File.ReadAllBytes(filename);
                    _client.PutFile(filename, Protocol.FileName.FirmwareV3);
                }
                else
                {
                    AddLog("firmware.v3-file not found!");
                }
            }
            else
            {
                AddLog("Firmware update not available.");
            }
        }

        private void btnDbgGetLog_Click(object sender, EventArgs e)
        {
            if (_client.FirmwareVersion.Major == 2) _client.GetFile(Protocol.FileName.LogDataKCL);
            if (_client.FirmwareVersion.Major == 3) _client.GetFile(Protocol.FileName.LogDataV3);
            AddLog("Get log with default timeout... (can take a while)");
        }

        private void btnDbg_GetLog5s_Click(object sender, EventArgs e)
        {
            if (_client.FirmwareVersion.Major == 2) _client.GetFile(Protocol.FileName.LogDataKCL, 5);
            if (_client.FirmwareVersion.Major == 3) _client.GetFile(Protocol.FileName.LogDataV3, 5);
            AddLog("Get log with 5 sec timeout... (can take a while)");
        }

        private void btnDbgGetLogInc_Click(object sender, EventArgs e)
        {
            if (_client.FirmwareVersion.Major == 2) _client.GetFile(Protocol.FileName.LogDataIncrementalKCL);
            if (_client.FirmwareVersion.Major == 3) _client.GetFile(Protocol.FileName.LogDataIncrementalV3);
            AddLog("Get incremental log...");

        }


        private void btnDbgSetDateTime1_Click(object sender, EventArgs e)
        {
            AddLog("Setting correct DT");
            _client.SetDateTime(DateTime.Now);
        }

        private void btnDbgSetDateTime2_Click(object sender, EventArgs e)
        {
            AddLog("Setting DT.AddHours(10)");
            _client.SetDateTime(DateTime.UtcNow.AddHours(10));

        }

        private void btnDbgSetDateTime3_Click(object sender, EventArgs e)
        {
            AddLog("Setting DT.AddMinutes(" + numericUpDown1.Value + ")");
            _client.SetDateTime(DateTime.Now.AddMinutes((double)numericUpDown1.Value));
        }


        private void btnDbg_RemoteRelease_Click(object sender, EventArgs e)
        {
            if (cmbDbgReleasePos.Text == "") cmbDbgReleasePos.SelectedIndex = 1;
            if (_client.FirmwareVersion.Major == 2)
            {
                // Byte 1-180
                _client.RemoteRelease(byte.Parse(cmbDbgReleasePos.Text), (short)nudRemoteUserID.Value, (byte)(checkBox1.Checked ? 0x56 : 0x00));
            }
            else if (_client.FirmwareVersion.Major == 3)
            {
                // UShort 1-2700
                _client.RemoteRelease(ushort.Parse(cmbDbgReleasePos.Text), (short)nudRemoteUserID.Value, (byte)(checkBox1.Checked ? 0x56 : 0x00));

            }
            AddLog("RemoteRelease @" + cmbDbgReleasePos.Text);
        }

        private void btnDbg_RemoteRelease8_Click(object sender, EventArgs e)
        {
            _client.RemoteRelease(new byte[] { 2, 3, 4, 5, 6, 7, 8, 9 }, (short)nudRemoteUserID.Value, (byte)(checkBox1.Checked ? 0x56 : 0x00));
            AddLog("RemoteRelease @" + cmbDbgReleasePos.Text);
        }

        private void btnDbgRemoteReturn_Click(object sender, EventArgs e)
        {
            if (cmbDbgReleasePos.Text == "") cmbDbgReleasePos.SelectedIndex = 1;
            if (_client.FirmwareVersion.Major == 3)
            {
                _client.RemoteReturn(ushort.Parse(cmbDbgReleasePos.Text), (short)nudRemoteUserID.Value, (byte)(checkBox1.Checked ? 0x56 : 0x00));
                AddLog("RemoteReturn @ " + cmbDbgReleasePos.Text);
            }
            else
            {
                AddLog("Firmware 3 is required for RemoteReturn!");
            }
        }

        private void btnDbg_LiveView_Click(object sender, EventArgs e)
        {
            AddLog("Sending GetLiveView at " + DateTime.Now.ToString("HH:mm:ss:fff"));
            if (_client.FirmwareVersion.Major == 2) _client.GetFile(Protocol.FileName.LiveViewKCL);
            if (_client.FirmwareVersion.Major == 3) _client.GetFile(Protocol.FileName.LiveViewV3);

            AddLog("Sent GetLiveView at " + DateTime.Now.ToString("HH:mm:ss:fff"));

        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            txtDbgLog2.Clear();
        }

        private void btnLogParser_Click(object sender, EventArgs e)
        {
            LogFileViewer fViewer = new LogFileViewer();
            fViewer.Show();
        }

        private void btnDbgIsConnected_Click(object sender, EventArgs e)
        {
            AddLog("IsConnected = " + _client.IsConnected());

        }

        private void btnResourceEditor_Click(object sender, EventArgs e)
        {
            ResourceEditor2 resEditor = new ResourceEditor2();
            if (_client != null && _client.IsConnected())
            {
                resEditor.Client = _client;
            }
            resEditor.ShowDialog();
        }

        private void btnResourceEditor3_Click(object sender, EventArgs e)
        {
            ResourceEditor3 resEditor = new ResourceEditor3();
            if (_client != null && _client.IsConnected())
            {
                resEditor.Client = _client;
            }
            resEditor.ShowDialog();
        }

        private void btnLogToBin_Click(object sender, EventArgs e)
        {
            string filenameInput = "";

            OpenFileDialog dlgOpen = new OpenFileDialog();
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                filenameInput = dlgOpen.FileName;
                ConvertLogFileToBinary(filenameInput);
            }
        }

        private void ConvertLogFileToBinary(string filename)
        {
            if (File.Exists(filename) == false) return;

            var lines = File.ReadAllLines(filename);

            int messageCounter = 0;

            string TXRX = "";
            string outputFilename = "";

            foreach (string line in lines)
            {
                // line Format = "RX(512/30824):85-01-CE-53-74..."

                if (line.StartsWith("TX") && TXRX != "TX")
                {
                    // start a new TX file based on filename
                    TXRX = "TX";
                    messageCounter++;
                }
                else if (line.StartsWith("RX") && TXRX != "RX")
                {
                    // start a new RX file based on filename
                    TXRX = "RX";
                    messageCounter++;
                }

                outputFilename = string.Format("{0}.{1}.{2:00}.BIN", filename, TXRX, messageCounter);

                var data = line.Substring(line.IndexOf(":") + 1).Split('-').Select(x => byte.Parse(x, NumberStyles.HexNumber)).ToArray();

                using (var fileStream = new FileStream(outputFilename, FileMode.Append | FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                using (var bw = new BinaryWriter(fileStream))
                {
                    //bw.Write(intData);
                    //bw.Write(stringData);
                    //bw.Write(lotsOfData);
                    bw.Write(data);
                }

            }
        }

        private void btnPutFile_Click(object sender, EventArgs e)
        {
            try
            {

                var dlg = new OpenFileDialog();
                dlg.Filter = "KeyConductor files|*.kcl;*.v3;*.bin|All files|*.*";
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    if (File.Exists(dlg.FileName))
                    {
                        _client.PutFile(dlg.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnDbgRemoteReboot_Click(object sender, EventArgs e)
        {
            if (_client.FirmwareVersion.Major == 3)
            {
                _client.RemoteReboot(1234, 0x34);
                AddLog("Remote Reboot executed");
            }
            else
            {
                AddLog("Remote Reboot requires firmware 3");
            }
        }

        private void btnDbgLiveViewParser_Click(object sender, EventArgs e)
        {
            LiveViewViewer vwr = new LiveViewViewer();
            vwr.Show();
        }

        private void btnDbgEmergencyRelease_Click(object sender, EventArgs e)
        {
            try
            {
                _client.EmergencyRelease((short)nudRemoteUserID.Value, 10);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDigiDeviceDiscovery_Click(object sender, EventArgs e)
        {
            var dlgSearch = new DigiDevice.frmDigiDeviceDiscovery(txtDebugIP.Text);
            if (dlgSearch.ShowDialog() == DialogResult.OK)
            {
                txtDebugIP.Text = dlgSearch.IP;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = "";

                OpenFileDialog dlgOpen = new OpenFileDialog();
                if (dlgOpen.ShowDialog() == DialogResult.OK)
                {
                    filename = dlgOpen.FileName;

                    var fiInfo = new FileInfo(filename);

                    if (fiInfo.Extension.ToLower() == ".v3")
                    {
                        if (fiInfo.Name.ToLower().Contains("users"))
                        {
                            var v3Users = new KeyConductorSDK.V3.UserCollection(filename, LoginMethod.Default, LoginReader.Auto);
                            AddLog(v3Users.ToString(true));
                        }
                        if (fiInfo.Name.ToLower().Contains("groups"))
                        {
                            var v3Groups = new KeyConductorSDK.V3.GroupCollection(filename);
                            AddLog(v3Groups.ToString(true));

                        }
                        if (fiInfo.Name.ToLower().Contains("keys"))
                        {
                            var v3Keys = new KeyConductorSDK.V3.KeyCollection(filename);
                            AddLog(v3Keys.ToString(true));

                        }
                        if (fiInfo.Name.ToLower().Contains("config"))
                        {
                            var v3Config = new KeyConductorSDK.V3.Config(filename);
                            AddLog(v3Config.ToString(true));

                        }
                    }
                    if (fiInfo.Extension.ToLower() == ".kcl")
                    {
                        if (fiInfo.Name.ToLower().Contains("users"))
                        {
                            var v2Users = new KeyConductorSDK.V2.UserCollection(filename, LoginMethod.Default, LoginReader.Auto);
                            AddLog(v2Users.ToString(true));
                        }

                        if (fiInfo.Name.ToLower().Contains("keys"))
                        {
                            var v2Keys = new KeyConductorSDK.V2.KeyCollection(filename);
                            AddLog(v2Keys.ToString(true));

                        }
                        if (fiInfo.Name.ToLower().Contains("config"))
                        {
                            var v2Config = new KeyConductorSDK.V2.Config(filename);
                            AddLog(v2Config.ToString(true));

                        }
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fMatrixTester = new FormMatrixTester();
            fMatrixTester.Show();
        }

        private void btnEmulator_Click(object sender, EventArgs e)
        {
            var fEmulator = new KeyConductorEmulator();
            fEmulator.Show();
        }

    }
}
