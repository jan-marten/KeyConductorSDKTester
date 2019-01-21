namespace KeyConductorSDKTester.DigiDevice
{
    partial class frmDigiDeviceConfigure
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDigiDeviceConfigure));
            this.lblInstructions = new System.Windows.Forms.Label();
            this.lblDevice = new System.Windows.Forms.Label();
            this.lblDeviceValue = new System.Windows.Forms.Label();
            this.lblMacAddress = new System.Windows.Forms.Label();
            this.lblMacAddressValue = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtGateway = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNetmask = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.lblIPAddress = new System.Windows.Forms.Label();
            this.optNetworkStatic = new System.Windows.Forms.RadioButton();
            this.optNetworkDHCP = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInstructions
            // 
            resources.ApplyResources(this.lblInstructions, "lblInstructions");
            this.lblInstructions.Name = "lblInstructions";
            // 
            // lblDevice
            // 
            resources.ApplyResources(this.lblDevice, "lblDevice");
            this.lblDevice.Name = "lblDevice";
            // 
            // lblDeviceValue
            // 
            resources.ApplyResources(this.lblDeviceValue, "lblDeviceValue");
            this.lblDeviceValue.Name = "lblDeviceValue";
            // 
            // lblMacAddress
            // 
            resources.ApplyResources(this.lblMacAddress, "lblMacAddress");
            this.lblMacAddress.Name = "lblMacAddress";
            // 
            // lblMacAddressValue
            // 
            resources.ApplyResources(this.lblMacAddressValue, "lblMacAddressValue");
            this.lblMacAddressValue.Name = "lblMacAddressValue";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtGateway);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtNetmask);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtIPAddress);
            this.groupBox1.Controls.Add(this.lblIPAddress);
            this.groupBox1.Controls.Add(this.optNetworkStatic);
            this.groupBox1.Controls.Add(this.optNetworkDHCP);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // txtGateway
            // 
            resources.ApplyResources(this.txtGateway, "txtGateway");
            this.txtGateway.Name = "txtGateway";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // txtNetmask
            // 
            resources.ApplyResources(this.txtNetmask, "txtNetmask");
            this.txtNetmask.Name = "txtNetmask";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // txtIPAddress
            // 
            resources.ApplyResources(this.txtIPAddress, "txtIPAddress");
            this.txtIPAddress.Name = "txtIPAddress";
            // 
            // lblIPAddress
            // 
            resources.ApplyResources(this.lblIPAddress, "lblIPAddress");
            this.lblIPAddress.Name = "lblIPAddress";
            // 
            // optNetworkStatic
            // 
            resources.ApplyResources(this.optNetworkStatic, "optNetworkStatic");
            this.optNetworkStatic.Name = "optNetworkStatic";
            this.optNetworkStatic.TabStop = true;
            this.optNetworkStatic.UseVisualStyleBackColor = true;
            this.optNetworkStatic.CheckedChanged += new System.EventHandler(this.optNetwork_CheckedChanged);
            // 
            // optNetworkDHCP
            // 
            resources.ApplyResources(this.optNetworkDHCP, "optNetworkDHCP");
            this.optNetworkDHCP.Name = "optNetworkDHCP";
            this.optNetworkDHCP.TabStop = true;
            this.optNetworkDHCP.UseVisualStyleBackColor = true;
            this.optNetworkDHCP.CheckedChanged += new System.EventHandler(this.optNetwork_CheckedChanged);
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmDigiDeviceConfigure
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblMacAddressValue);
            this.Controls.Add(this.lblMacAddress);
            this.Controls.Add(this.lblDeviceValue);
            this.Controls.Add(this.lblDevice);
            this.Controls.Add(this.lblInstructions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDigiDeviceConfigure";
            this.Load += new System.EventHandler(this.frmDigiDeviceConfigure_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Label lblDevice;
        private System.Windows.Forms.Label lblDeviceValue;
        private System.Windows.Forms.Label lblMacAddress;
        private System.Windows.Forms.Label lblMacAddressValue;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton optNetworkStatic;
        private System.Windows.Forms.RadioButton optNetworkDHCP;
        private System.Windows.Forms.TextBox txtGateway;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNetmask;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Label lblIPAddress;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}