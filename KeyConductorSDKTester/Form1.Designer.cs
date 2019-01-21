namespace KeyConductorSDKTester
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPutFile = new System.Windows.Forms.Button();
            this.chkGetInfoContinue = new System.Windows.Forms.CheckBox();
            this.btnUpdateFirmware = new System.Windows.Forms.Button();
            this.btnDbg_GetLog5s = new System.Windows.Forms.Button();
            this.btnDbgGetLogInc = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnDbg_RemoteRelease8 = new System.Windows.Forms.Button();
            this.btnDbg_RemoteRelease = new System.Windows.Forms.Button();
            this.btnDbg_LiveView = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbDbgReleasePos = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDbgSetDateTime2 = new System.Windows.Forms.Button();
            this.btnDbgSetDateTime1 = new System.Windows.Forms.Button();
            this.btnDbgGetLog = new System.Windows.Forms.Button();
            this.btnDbgGetInfo = new System.Windows.Forms.Button();
            this.btnDbgIsConnected = new System.Windows.Forms.Button();
            this.btnDbgConnect = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDebugKCID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDebugPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDebugIP = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRemoteAuthGroups = new System.Windows.Forms.TextBox();
            this.optRemoteAuth_AssignSwipecard = new System.Windows.Forms.RadioButton();
            this.optRemoteAuth_SuperVisor = new System.Windows.Forms.RadioButton();
            this.optRemoteAuth_Grant = new System.Windows.Forms.RadioButton();
            this.optRemoteAuth_Deny = new System.Windows.Forms.RadioButton();
            this.btnLogToBin = new System.Windows.Forms.Button();
            this.chkDataLog = new System.Windows.Forms.CheckBox();
            this.btnDataReset = new System.Windows.Forms.Button();
            this.lblDataTXCount = new System.Windows.Forms.Label();
            this.lblDataTX = new System.Windows.Forms.Label();
            this.lblDataRXCount = new System.Windows.Forms.Label();
            this.lblDataRX = new System.Windows.Forms.Label();
            this.btnLogParser = new System.Windows.Forms.Button();
            this.btnResourceEditor = new System.Windows.Forms.Button();
            this.btnDbgRemoteReturn = new System.Windows.Forms.Button();
            this.btnDbgRemoteReboot = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnEmulator = new System.Windows.Forms.Button();
            this.chkAutoUpdateKCID = new System.Windows.Forms.CheckBox();
            this.btnDigiDeviceDiscovery = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnDbgSetDateTime3 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudMileageMax = new System.Windows.Forms.NumericUpDown();
            this.nudMileageMin = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.nudRemoteUserID = new System.Windows.Forms.NumericUpDown();
            this.btnDbgEmergencyRelease = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnDbgLiveViewParser = new System.Windows.Forms.Button();
            this.btnResourceEditor3 = new System.Windows.Forms.Button();
            this.txtDbgLog2 = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMileageMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMileageMin)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRemoteUserID)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPutFile
            // 
            this.btnPutFile.Location = new System.Drawing.Point(211, 42);
            this.btnPutFile.Name = "btnPutFile";
            this.btnPutFile.Size = new System.Drawing.Size(240, 23);
            this.btnPutFile.TabIndex = 39;
            this.btnPutFile.Text = "Put file...";
            this.btnPutFile.UseVisualStyleBackColor = true;
            this.btnPutFile.Click += new System.EventHandler(this.btnPutFile_Click);
            // 
            // chkGetInfoContinue
            // 
            this.chkGetInfoContinue.AutoSize = true;
            this.chkGetInfoContinue.Location = new System.Drawing.Point(45, 74);
            this.chkGetInfoContinue.Name = "chkGetInfoContinue";
            this.chkGetInfoContinue.Size = new System.Drawing.Size(126, 17);
            this.chkGetInfoContinue.TabIndex = 38;
            this.chkGetInfoContinue.Text = "Continue GetInfo test";
            this.chkGetInfoContinue.UseVisualStyleBackColor = true;
            // 
            // btnUpdateFirmware
            // 
            this.btnUpdateFirmware.Location = new System.Drawing.Point(211, 13);
            this.btnUpdateFirmware.Name = "btnUpdateFirmware";
            this.btnUpdateFirmware.Size = new System.Drawing.Size(240, 23);
            this.btnUpdateFirmware.TabIndex = 37;
            this.btnUpdateFirmware.Text = "Update to latest standalone Firmware!";
            this.btnUpdateFirmware.UseVisualStyleBackColor = true;
            this.btnUpdateFirmware.Click += new System.EventHandler(this.btnUpdateFirmware_Click);
            // 
            // btnDbg_GetLog5s
            // 
            this.btnDbg_GetLog5s.Location = new System.Drawing.Point(487, 13);
            this.btnDbg_GetLog5s.Name = "btnDbg_GetLog5s";
            this.btnDbg_GetLog5s.Size = new System.Drawing.Size(111, 23);
            this.btnDbg_GetLog5s.TabIndex = 36;
            this.btnDbg_GetLog5s.Text = "Get log (5s)";
            this.btnDbg_GetLog5s.UseVisualStyleBackColor = true;
            this.btnDbg_GetLog5s.Click += new System.EventHandler(this.btnDbg_GetLog5s_Click);
            // 
            // btnDbgGetLogInc
            // 
            this.btnDbgGetLogInc.Location = new System.Drawing.Point(487, 72);
            this.btnDbgGetLogInc.Name = "btnDbgGetLogInc";
            this.btnDbgGetLogInc.Size = new System.Drawing.Size(111, 23);
            this.btnDbgGetLogInc.TabIndex = 35;
            this.btnDbgGetLogInc.Text = "Get log (delta)";
            this.btnDbgGetLogInc.UseVisualStyleBackColor = true;
            this.btnDbgGetLogInc.Click += new System.EventHandler(this.btnDbgGetLogInc_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearLog.Location = new System.Drawing.Point(12, 230);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(53, 23);
            this.btnClearLog.TabIndex = 34;
            this.btnClearLog.Text = "CLS";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(27, 103);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(154, 17);
            this.checkBox1.TabIndex = 35;
            this.checkBox1.Text = "Rem.Rel with ReasonCode";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnDbg_RemoteRelease8
            // 
            this.btnDbg_RemoteRelease8.Location = new System.Drawing.Point(27, 74);
            this.btnDbg_RemoteRelease8.Name = "btnDbg_RemoteRelease8";
            this.btnDbg_RemoteRelease8.Size = new System.Drawing.Size(159, 23);
            this.btnDbg_RemoteRelease8.TabIndex = 34;
            this.btnDbg_RemoteRelease8.Text = "Remote release 8";
            this.btnDbg_RemoteRelease8.UseVisualStyleBackColor = true;
            this.btnDbg_RemoteRelease8.Click += new System.EventHandler(this.btnDbg_RemoteRelease8_Click);
            // 
            // btnDbg_RemoteRelease
            // 
            this.btnDbg_RemoteRelease.Location = new System.Drawing.Point(27, 45);
            this.btnDbg_RemoteRelease.Name = "btnDbg_RemoteRelease";
            this.btnDbg_RemoteRelease.Size = new System.Drawing.Size(159, 23);
            this.btnDbg_RemoteRelease.TabIndex = 32;
            this.btnDbg_RemoteRelease.Text = "Standalone - remote release";
            this.btnDbg_RemoteRelease.UseVisualStyleBackColor = true;
            this.btnDbg_RemoteRelease.Click += new System.EventHandler(this.btnDbg_RemoteRelease_Click);
            // 
            // btnDbg_LiveView
            // 
            this.btnDbg_LiveView.Location = new System.Drawing.Point(27, 19);
            this.btnDbg_LiveView.Name = "btnDbg_LiveView";
            this.btnDbg_LiveView.Size = new System.Drawing.Size(159, 23);
            this.btnDbg_LiveView.TabIndex = 33;
            this.btnDbg_LiveView.Text = "Standalone - LiveView";
            this.btnDbg_LiveView.UseVisualStyleBackColor = true;
            this.btnDbg_LiveView.Click += new System.EventHandler(this.btnDbg_LiveView_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Position:";
            // 
            // cmbDbgReleasePos
            // 
            this.cmbDbgReleasePos.FormattingEnabled = true;
            this.cmbDbgReleasePos.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99"});
            this.cmbDbgReleasePos.Location = new System.Drawing.Point(75, 18);
            this.cmbDbgReleasePos.MaxDropDownItems = 15;
            this.cmbDbgReleasePos.Name = "cmbDbgReleasePos";
            this.cmbDbgReleasePos.Size = new System.Drawing.Size(121, 21);
            this.cmbDbgReleasePos.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(695, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Standalone:";
            // 
            // btnDbgSetDateTime2
            // 
            this.btnDbgSetDateTime2.Location = new System.Drawing.Point(765, 44);
            this.btnDbgSetDateTime2.Name = "btnDbgSetDateTime2";
            this.btnDbgSetDateTime2.Size = new System.Drawing.Size(118, 23);
            this.btnDbgSetDateTime2.TabIndex = 31;
            this.btnDbgSetDateTime2.Text = "Set DT (AUS)";
            this.btnDbgSetDateTime2.UseVisualStyleBackColor = true;
            this.btnDbgSetDateTime2.Click += new System.EventHandler(this.btnDbgSetDateTime2_Click);
            // 
            // btnDbgSetDateTime1
            // 
            this.btnDbgSetDateTime1.Location = new System.Drawing.Point(765, 19);
            this.btnDbgSetDateTime1.Name = "btnDbgSetDateTime1";
            this.btnDbgSetDateTime1.Size = new System.Drawing.Size(118, 23);
            this.btnDbgSetDateTime1.TabIndex = 30;
            this.btnDbgSetDateTime1.Text = "Set DT";
            this.btnDbgSetDateTime1.UseVisualStyleBackColor = true;
            this.btnDbgSetDateTime1.Click += new System.EventHandler(this.btnDbgSetDateTime1_Click);
            // 
            // btnDbgGetLog
            // 
            this.btnDbgGetLog.Location = new System.Drawing.Point(487, 43);
            this.btnDbgGetLog.Name = "btnDbgGetLog";
            this.btnDbgGetLog.Size = new System.Drawing.Size(111, 23);
            this.btnDbgGetLog.TabIndex = 29;
            this.btnDbgGetLog.Text = "Get log (90s)";
            this.btnDbgGetLog.UseVisualStyleBackColor = true;
            this.btnDbgGetLog.Click += new System.EventHandler(this.btnDbgGetLog_Click);
            // 
            // btnDbgGetInfo
            // 
            this.btnDbgGetInfo.Location = new System.Drawing.Point(3, 3);
            this.btnDbgGetInfo.Name = "btnDbgGetInfo";
            this.btnDbgGetInfo.Size = new System.Drawing.Size(202, 65);
            this.btnDbgGetInfo.TabIndex = 26;
            this.btnDbgGetInfo.Text = "Get version info";
            this.btnDbgGetInfo.UseVisualStyleBackColor = true;
            this.btnDbgGetInfo.Click += new System.EventHandler(this.btnDbgGetInfo_Click);
            // 
            // btnDbgIsConnected
            // 
            this.btnDbgIsConnected.Location = new System.Drawing.Point(288, 43);
            this.btnDbgIsConnected.Name = "btnDbgIsConnected";
            this.btnDbgIsConnected.Size = new System.Drawing.Size(91, 23);
            this.btnDbgIsConnected.TabIndex = 7;
            this.btnDbgIsConnected.Text = "IsConnected?";
            this.btnDbgIsConnected.UseVisualStyleBackColor = true;
            this.btnDbgIsConnected.Click += new System.EventHandler(this.btnDbgIsConnected_Click);
            // 
            // btnDbgConnect
            // 
            this.btnDbgConnect.Location = new System.Drawing.Point(191, 44);
            this.btnDbgConnect.Name = "btnDbgConnect";
            this.btnDbgConnect.Size = new System.Drawing.Size(91, 23);
            this.btnDbgConnect.TabIndex = 3;
            this.btnDbgConnect.Text = "Connect";
            this.btnDbgConnect.UseVisualStyleBackColor = true;
            this.btnDbgConnect.Click += new System.EventHandler(this.btnDbgConnect_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "KCID";
            // 
            // txtDebugKCID
            // 
            this.txtDebugKCID.Location = new System.Drawing.Point(78, 75);
            this.txtDebugKCID.MaxLength = 16;
            this.txtDebugKCID.Name = "txtDebugKCID";
            this.txtDebugKCID.Size = new System.Drawing.Size(100, 20);
            this.txtDebugKCID.TabIndex = 2;
            this.txtDebugKCID.Text = "00000000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Port";
            // 
            // txtDebugPort
            // 
            this.txtDebugPort.Location = new System.Drawing.Point(78, 46);
            this.txtDebugPort.Name = "txtDebugPort";
            this.txtDebugPort.Size = new System.Drawing.Size(100, 20);
            this.txtDebugPort.TabIndex = 1;
            this.txtDebugPort.Text = "2101";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "IP";
            // 
            // txtDebugIP
            // 
            this.txtDebugIP.Location = new System.Drawing.Point(78, 17);
            this.txtDebugIP.Name = "txtDebugIP";
            this.txtDebugIP.Size = new System.Drawing.Size(100, 20);
            this.txtDebugIP.TabIndex = 0;
            this.txtDebugIP.Text = "localhost";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtRemoteAuthGroups);
            this.groupBox1.Controls.Add(this.optRemoteAuth_AssignSwipecard);
            this.groupBox1.Controls.Add(this.optRemoteAuth_SuperVisor);
            this.groupBox1.Controls.Add(this.optRemoteAuth_Grant);
            this.groupBox1.Controls.Add(this.optRemoteAuth_Deny);
            this.groupBox1.Location = new System.Drawing.Point(20, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 139);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Standalone: Remote Authentication";
            this.groupBox1.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(256, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "(seperate with comma)";
            // 
            // txtRemoteAuthGroups
            // 
            this.txtRemoteAuthGroups.Location = new System.Drawing.Point(126, 47);
            this.txtRemoteAuthGroups.Name = "txtRemoteAuthGroups";
            this.txtRemoteAuthGroups.Size = new System.Drawing.Size(123, 20);
            this.txtRemoteAuthGroups.TabIndex = 4;
            this.txtRemoteAuthGroups.Text = "1,2,3";
            // 
            // optRemoteAuth_AssignSwipecard
            // 
            this.optRemoteAuth_AssignSwipecard.AutoSize = true;
            this.optRemoteAuth_AssignSwipecard.Location = new System.Drawing.Point(9, 94);
            this.optRemoteAuth_AssignSwipecard.Name = "optRemoteAuth_AssignSwipecard";
            this.optRemoteAuth_AssignSwipecard.Size = new System.Drawing.Size(107, 17);
            this.optRemoteAuth_AssignSwipecard.TabIndex = 3;
            this.optRemoteAuth_AssignSwipecard.Text = "Assign swipecard";
            this.optRemoteAuth_AssignSwipecard.UseVisualStyleBackColor = true;
            // 
            // optRemoteAuth_SuperVisor
            // 
            this.optRemoteAuth_SuperVisor.AutoSize = true;
            this.optRemoteAuth_SuperVisor.Location = new System.Drawing.Point(9, 71);
            this.optRemoteAuth_SuperVisor.Name = "optRemoteAuth_SuperVisor";
            this.optRemoteAuth_SuperVisor.Size = new System.Drawing.Size(118, 17);
            this.optRemoteAuth_SuperVisor.TabIndex = 2;
            this.optRemoteAuth_SuperVisor.Text = "Grant as Supervisor";
            this.optRemoteAuth_SuperVisor.UseVisualStyleBackColor = true;
            // 
            // optRemoteAuth_Grant
            // 
            this.optRemoteAuth_Grant.AutoSize = true;
            this.optRemoteAuth_Grant.Checked = true;
            this.optRemoteAuth_Grant.Location = new System.Drawing.Point(9, 48);
            this.optRemoteAuth_Grant.Name = "optRemoteAuth_Grant";
            this.optRemoteAuth_Grant.Size = new System.Drawing.Size(111, 17);
            this.optRemoteAuth_Grant.TabIndex = 1;
            this.optRemoteAuth_Grant.TabStop = true;
            this.optRemoteAuth_Grant.Text = "Grant with groups:";
            this.optRemoteAuth_Grant.UseVisualStyleBackColor = true;
            // 
            // optRemoteAuth_Deny
            // 
            this.optRemoteAuth_Deny.AutoSize = true;
            this.optRemoteAuth_Deny.Location = new System.Drawing.Point(9, 24);
            this.optRemoteAuth_Deny.Name = "optRemoteAuth_Deny";
            this.optRemoteAuth_Deny.Size = new System.Drawing.Size(50, 17);
            this.optRemoteAuth_Deny.TabIndex = 0;
            this.optRemoteAuth_Deny.Text = "Deny";
            this.optRemoteAuth_Deny.UseVisualStyleBackColor = true;
            // 
            // btnLogToBin
            // 
            this.btnLogToBin.Location = new System.Drawing.Point(144, 50);
            this.btnLogToBin.Name = "btnLogToBin";
            this.btnLogToBin.Size = new System.Drawing.Size(75, 23);
            this.btnLogToBin.TabIndex = 6;
            this.btnLogToBin.Text = "LOG2BIN";
            this.btnLogToBin.UseVisualStyleBackColor = true;
            this.btnLogToBin.Click += new System.EventHandler(this.btnLogToBin_Click);
            // 
            // chkDataLog
            // 
            this.chkDataLog.AutoSize = true;
            this.chkDataLog.Location = new System.Drawing.Point(10, 56);
            this.chkDataLog.Name = "chkDataLog";
            this.chkDataLog.Size = new System.Drawing.Size(96, 17);
            this.chkDataLog.TabIndex = 5;
            this.chkDataLog.Text = "Log data to file";
            this.chkDataLog.UseVisualStyleBackColor = true;
            this.chkDataLog.CheckedChanged += new System.EventHandler(this.chkDataLog_CheckedChanged);
            // 
            // btnDataReset
            // 
            this.btnDataReset.Location = new System.Drawing.Point(9, 32);
            this.btnDataReset.Name = "btnDataReset";
            this.btnDataReset.Size = new System.Drawing.Size(75, 23);
            this.btnDataReset.TabIndex = 4;
            this.btnDataReset.Text = "Reset";
            this.btnDataReset.UseVisualStyleBackColor = true;
            this.btnDataReset.Click += new System.EventHandler(this.btnDataReset_Click);
            // 
            // lblDataTXCount
            // 
            this.lblDataTXCount.AutoSize = true;
            this.lblDataTXCount.Location = new System.Drawing.Point(63, 16);
            this.lblDataTXCount.Name = "lblDataTXCount";
            this.lblDataTXCount.Size = new System.Drawing.Size(13, 13);
            this.lblDataTXCount.TabIndex = 3;
            this.lblDataTXCount.Text = "0";
            // 
            // lblDataTX
            // 
            this.lblDataTX.AutoSize = true;
            this.lblDataTX.Location = new System.Drawing.Point(7, 16);
            this.lblDataTX.Name = "lblDataTX";
            this.lblDataTX.Size = new System.Drawing.Size(24, 13);
            this.lblDataTX.TabIndex = 2;
            this.lblDataTX.Text = "TX:";
            // 
            // lblDataRXCount
            // 
            this.lblDataRXCount.AutoSize = true;
            this.lblDataRXCount.Location = new System.Drawing.Point(63, 3);
            this.lblDataRXCount.Name = "lblDataRXCount";
            this.lblDataRXCount.Size = new System.Drawing.Size(13, 13);
            this.lblDataRXCount.TabIndex = 1;
            this.lblDataRXCount.Text = "0";
            // 
            // lblDataRX
            // 
            this.lblDataRX.AutoSize = true;
            this.lblDataRX.Location = new System.Drawing.Point(6, 3);
            this.lblDataRX.Name = "lblDataRX";
            this.lblDataRX.Size = new System.Drawing.Size(25, 13);
            this.lblDataRX.TabIndex = 0;
            this.lblDataRX.Text = "RX:";
            // 
            // btnLogParser
            // 
            this.btnLogParser.Location = new System.Drawing.Point(17, 6);
            this.btnLogParser.Name = "btnLogParser";
            this.btnLogParser.Size = new System.Drawing.Size(141, 50);
            this.btnLogParser.TabIndex = 4;
            this.btnLogParser.Text = "Log parser";
            this.btnLogParser.UseVisualStyleBackColor = true;
            this.btnLogParser.Click += new System.EventHandler(this.btnLogParser_Click);
            // 
            // btnResourceEditor
            // 
            this.btnResourceEditor.Location = new System.Drawing.Point(445, 6);
            this.btnResourceEditor.Name = "btnResourceEditor";
            this.btnResourceEditor.Size = new System.Drawing.Size(141, 50);
            this.btnResourceEditor.TabIndex = 6;
            this.btnResourceEditor.Text = "Resource editor FW2";
            this.btnResourceEditor.UseVisualStyleBackColor = true;
            this.btnResourceEditor.Click += new System.EventHandler(this.btnResourceEditor_Click);
            // 
            // btnDbgRemoteReturn
            // 
            this.btnDbgRemoteReturn.Location = new System.Drawing.Point(192, 45);
            this.btnDbgRemoteReturn.Name = "btnDbgRemoteReturn";
            this.btnDbgRemoteReturn.Size = new System.Drawing.Size(140, 23);
            this.btnDbgRemoteReturn.TabIndex = 36;
            this.btnDbgRemoteReturn.Text = "fw3 - RemoteReturn";
            this.btnDbgRemoteReturn.UseVisualStyleBackColor = true;
            this.btnDbgRemoteReturn.Click += new System.EventHandler(this.btnDbgRemoteReturn_Click);
            // 
            // btnDbgRemoteReboot
            // 
            this.btnDbgRemoteReboot.Location = new System.Drawing.Point(743, 117);
            this.btnDbgRemoteReboot.Name = "btnDbgRemoteReboot";
            this.btnDbgRemoteReboot.Size = new System.Drawing.Size(140, 23);
            this.btnDbgRemoteReboot.TabIndex = 40;
            this.btnDbgRemoteReboot.Text = "FW3 - RemoteReboot";
            this.btnDbgRemoteReboot.UseVisualStyleBackColor = true;
            this.btnDbgRemoteReboot.Click += new System.EventHandler(this.btnDbgRemoteReboot_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(908, 212);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnEmulator);
            this.tabPage1.Controls.Add(this.chkAutoUpdateKCID);
            this.tabPage1.Controls.Add(this.btnDigiDeviceDiscovery);
            this.tabPage1.Controls.Add(this.btnDbgIsConnected);
            this.tabPage1.Controls.Add(this.btnDbgConnect);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtDebugIP);
            this.tabPage1.Controls.Add(this.txtDebugKCID);
            this.tabPage1.Controls.Add(this.txtDebugPort);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(900, 186);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "KeyConductor";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnEmulator
            // 
            this.btnEmulator.Location = new System.Drawing.Point(665, 46);
            this.btnEmulator.Name = "btnEmulator";
            this.btnEmulator.Size = new System.Drawing.Size(91, 23);
            this.btnEmulator.TabIndex = 10;
            this.btnEmulator.Text = "Emulator";
            this.btnEmulator.UseVisualStyleBackColor = true;
            this.btnEmulator.Click += new System.EventHandler(this.btnEmulator_Click);
            // 
            // chkAutoUpdateKCID
            // 
            this.chkAutoUpdateKCID.AutoSize = true;
            this.chkAutoUpdateKCID.Checked = true;
            this.chkAutoUpdateKCID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoUpdateKCID.Location = new System.Drawing.Point(191, 77);
            this.chkAutoUpdateKCID.Name = "chkAutoUpdateKCID";
            this.chkAutoUpdateKCID.Size = new System.Drawing.Size(125, 17);
            this.chkAutoUpdateKCID.TabIndex = 9;
            this.chkAutoUpdateKCID.Text = "Auto update if invalid";
            this.chkAutoUpdateKCID.UseVisualStyleBackColor = true;
            // 
            // btnDigiDeviceDiscovery
            // 
            this.btnDigiDeviceDiscovery.Location = new System.Drawing.Point(191, 17);
            this.btnDigiDeviceDiscovery.Name = "btnDigiDeviceDiscovery";
            this.btnDigiDeviceDiscovery.Size = new System.Drawing.Size(91, 23);
            this.btnDigiDeviceDiscovery.TabIndex = 8;
            this.btnDigiDeviceDiscovery.Text = "Search...";
            this.btnDigiDeviceDiscovery.UseVisualStyleBackColor = true;
            this.btnDigiDeviceDiscovery.Click += new System.EventHandler(this.btnDigiDeviceDiscovery_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnLogToBin);
            this.tabPage2.Controls.Add(this.chkDataLog);
            this.tabPage2.Controls.Add(this.btnDataReset);
            this.tabPage2.Controls.Add(this.lblDataRX);
            this.tabPage2.Controls.Add(this.lblDataTXCount);
            this.tabPage2.Controls.Add(this.lblDataRXCount);
            this.tabPage2.Controls.Add(this.lblDataTX);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(900, 186);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Data logging";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.numericUpDown1);
            this.tabPage3.Controls.Add(this.btnDbgSetDateTime3);
            this.tabPage3.Controls.Add(this.btnDbgRemoteReboot);
            this.tabPage3.Controls.Add(this.btnPutFile);
            this.tabPage3.Controls.Add(this.chkGetInfoContinue);
            this.tabPage3.Controls.Add(this.btnUpdateFirmware);
            this.tabPage3.Controls.Add(this.btnDbg_GetLog5s);
            this.tabPage3.Controls.Add(this.btnDbgGetLogInc);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.btnDbgSetDateTime2);
            this.tabPage3.Controls.Add(this.btnDbgSetDateTime1);
            this.tabPage3.Controls.Add(this.btnDbgGetLog);
            this.tabPage3.Controls.Add(this.btnDbgGetInfo);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(900, 186);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Functions";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(639, 76);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1440,
            0,
            0,
            -2147483648});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 43;
            // 
            // btnDbgSetDateTime3
            // 
            this.btnDbgSetDateTime3.Location = new System.Drawing.Point(765, 73);
            this.btnDbgSetDateTime3.Name = "btnDbgSetDateTime3";
            this.btnDbgSetDateTime3.Size = new System.Drawing.Size(118, 23);
            this.btnDbgSetDateTime3.TabIndex = 42;
            this.btnDbgSetDateTime3.Text = "Set DT with offset";
            this.btnDbgSetDateTime3.UseVisualStyleBackColor = true;
            this.btnDbgSetDateTime3.Click += new System.EventHandler(this.btnDbgSetDateTime3_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.groupBox5);
            this.tabPage4.Controls.Add(this.cmbDbgReleasePos);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(900, 186);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Position";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.nudMileageMax);
            this.groupBox2.Controls.Add(this.nudMileageMin);
            this.groupBox2.Location = new System.Drawing.Point(648, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(195, 75);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mileage registration";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Max:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Min:";
            // 
            // nudMileageMax
            // 
            this.nudMileageMax.Location = new System.Drawing.Point(55, 42);
            this.nudMileageMax.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudMileageMax.Name = "nudMileageMax";
            this.nudMileageMax.Size = new System.Drawing.Size(120, 20);
            this.nudMileageMax.TabIndex = 1;
            this.nudMileageMax.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            // 
            // nudMileageMin
            // 
            this.nudMileageMin.Location = new System.Drawing.Point(55, 18);
            this.nudMileageMin.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudMileageMin.Name = "nudMileageMin";
            this.nudMileageMin.Size = new System.Drawing.Size(120, 20);
            this.nudMileageMin.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.nudRemoteUserID);
            this.groupBox5.Controls.Add(this.btnDbgEmergencyRelease);
            this.groupBox5.Controls.Add(this.btnDbgRemoteReturn);
            this.groupBox5.Controls.Add(this.btnDbg_LiveView);
            this.groupBox5.Controls.Add(this.checkBox1);
            this.groupBox5.Controls.Add(this.btnDbg_RemoteRelease);
            this.groupBox5.Controls.Add(this.btnDbg_RemoteRelease8);
            this.groupBox5.Location = new System.Drawing.Point(218, 18);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(357, 123);
            this.groupBox5.TabIndex = 35;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Standalone";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(226, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "UserID:";
            // 
            // nudRemoteUserID
            // 
            this.nudRemoteUserID.Location = new System.Drawing.Point(279, 20);
            this.nudRemoteUserID.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudRemoteUserID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRemoteUserID.Name = "nudRemoteUserID";
            this.nudRemoteUserID.Size = new System.Drawing.Size(53, 20);
            this.nudRemoteUserID.TabIndex = 38;
            this.nudRemoteUserID.Value = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            // 
            // btnDbgEmergencyRelease
            // 
            this.btnDbgEmergencyRelease.Location = new System.Drawing.Point(192, 74);
            this.btnDbgEmergencyRelease.Name = "btnDbgEmergencyRelease";
            this.btnDbgEmergencyRelease.Size = new System.Drawing.Size(140, 23);
            this.btnDbgEmergencyRelease.TabIndex = 37;
            this.btnDbgEmergencyRelease.Text = "fw3 - EmergencyRelease";
            this.btnDbgEmergencyRelease.UseVisualStyleBackColor = true;
            this.btnDbgEmergencyRelease.Click += new System.EventHandler(this.btnDbgEmergencyRelease_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBox1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(900, 186);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Remote auth";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.button1);
            this.tabPage6.Controls.Add(this.button2);
            this.tabPage6.Controls.Add(this.btnDbgLiveViewParser);
            this.tabPage6.Controls.Add(this.btnResourceEditor3);
            this.tabPage6.Controls.Add(this.btnLogParser);
            this.tabPage6.Controls.Add(this.btnResourceEditor);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(900, 186);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Other";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(711, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 50);
            this.button1.TabIndex = 10;
            this.button1.Text = "Matrix translator";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(17, 118);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 50);
            this.button2.TabIndex = 9;
            this.button2.Text = "KCL/V3 parser";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnDbgLiveViewParser
            // 
            this.btnDbgLiveViewParser.Location = new System.Drawing.Point(17, 62);
            this.btnDbgLiveViewParser.Name = "btnDbgLiveViewParser";
            this.btnDbgLiveViewParser.Size = new System.Drawing.Size(141, 50);
            this.btnDbgLiveViewParser.TabIndex = 8;
            this.btnDbgLiveViewParser.Text = "LiveView parser";
            this.btnDbgLiveViewParser.UseVisualStyleBackColor = true;
            this.btnDbgLiveViewParser.Click += new System.EventHandler(this.btnDbgLiveViewParser_Click);
            // 
            // btnResourceEditor3
            // 
            this.btnResourceEditor3.Location = new System.Drawing.Point(445, 64);
            this.btnResourceEditor3.Name = "btnResourceEditor3";
            this.btnResourceEditor3.Size = new System.Drawing.Size(141, 50);
            this.btnResourceEditor3.TabIndex = 7;
            this.btnResourceEditor3.Text = "Resource editor FW3";
            this.btnResourceEditor3.UseVisualStyleBackColor = true;
            this.btnResourceEditor3.Click += new System.EventHandler(this.btnResourceEditor3_Click);
            // 
            // txtDbgLog2
            // 
            this.txtDbgLog2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDbgLog2.Location = new System.Drawing.Point(12, 230);
            this.txtDbgLog2.Name = "txtDbgLog2";
            this.txtDbgLog2.Size = new System.Drawing.Size(904, 391);
            this.txtDbgLog2.TabIndex = 35;
            this.txtDbgLog2.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 633);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.txtDbgLog2);
            this.Name = "Form1";
            this.Text = "KeyConductorSDK tester";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMileageMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMileageMin)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRemoteUserID)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbDbgReleasePos;
        private System.Windows.Forms.Button btnDbgConnect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDebugKCID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDebugPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDebugIP;
        private System.Windows.Forms.Button btnDbgGetInfo;
        private System.Windows.Forms.Button btnDbgGetLog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton optRemoteAuth_SuperVisor;
        private System.Windows.Forms.RadioButton optRemoteAuth_Grant;
        private System.Windows.Forms.RadioButton optRemoteAuth_Deny;
        private System.Windows.Forms.Button btnDbgSetDateTime2;
        private System.Windows.Forms.Button btnDbgSetDateTime1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDbg_RemoteRelease;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDbg_LiveView;
        private System.Windows.Forms.Button btnDbg_RemoteRelease8;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Button btnDataReset;
        private System.Windows.Forms.Label lblDataTXCount;
        private System.Windows.Forms.Label lblDataTX;
        private System.Windows.Forms.Label lblDataRXCount;
        private System.Windows.Forms.Label lblDataRX;
        private System.Windows.Forms.CheckBox chkDataLog;
        private System.Windows.Forms.Button btnLogParser;
        private System.Windows.Forms.Button btnDbgGetLogInc;
        private System.Windows.Forms.Button btnDbgIsConnected;
        private System.Windows.Forms.Button btnResourceEditor;
        private System.Windows.Forms.Button btnDbg_GetLog5s;
        private System.Windows.Forms.Button btnUpdateFirmware;
        private System.Windows.Forms.Button btnLogToBin;
        private System.Windows.Forms.CheckBox chkGetInfoContinue;
        private System.Windows.Forms.Button btnPutFile;
        private System.Windows.Forms.Button btnDbgRemoteReturn;
        private System.Windows.Forms.Button btnDbgRemoteReboot;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnResourceEditor3;
        private System.Windows.Forms.Button btnDbgSetDateTime3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btnDbgLiveViewParser;
        private System.Windows.Forms.Button btnDbgEmergencyRelease;
        private System.Windows.Forms.Button btnDigiDeviceDiscovery;
        private System.Windows.Forms.CheckBox chkAutoUpdateKCID;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudRemoteUserID;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox txtDbgLog2;
        private System.Windows.Forms.Button btnEmulator;
        private System.Windows.Forms.RadioButton optRemoteAuth_AssignSwipecard;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudMileageMax;
        private System.Windows.Forms.NumericUpDown nudMileageMin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRemoteAuthGroups;
    }
}

