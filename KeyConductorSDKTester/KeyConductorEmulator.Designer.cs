namespace KeyConductorSDKTester
{
    partial class KeyConductorEmulator
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDebugKCID = new System.Windows.Forms.TextBox();
            this.txtDebugPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnLogin_SwipePin = new System.Windows.Forms.Button();
            this.btnLogin_Swipe = new System.Windows.Forms.Button();
            this.btnLogin_Pin = new System.Windows.Forms.Button();
            this.btnLogin_UserPin = new System.Windows.Forms.Button();
            this.txtPinCode = new System.Windows.Forms.MaskedTextBox();
            this.txtUserCode = new System.Windows.Forms.MaskedTextBox();
            this.txtSwipeCard = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.txtDbgLog2 = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1098, 212);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnConnect);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtDebugKCID);
            this.tabPage1.Controls.Add(this.txtDebugPort);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1090, 186);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "KeyConductor";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(191, 44);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(91, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Serve";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
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
            this.txtDebugKCID.Text = "180101010101";
            // 
            // txtDebugPort
            // 
            this.txtDebugPort.Location = new System.Drawing.Point(78, 46);
            this.txtDebugPort.Name = "txtDebugPort";
            this.txtDebugPort.Size = new System.Drawing.Size(100, 20);
            this.txtDebugPort.TabIndex = 1;
            this.txtDebugPort.Text = "2101";
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
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button7);
            this.tabPage3.Controls.Add(this.button6);
            this.tabPage3.Controls.Add(this.btnLogout);
            this.tabPage3.Controls.Add(this.btnLogin_SwipePin);
            this.tabPage3.Controls.Add(this.btnLogin_Swipe);
            this.tabPage3.Controls.Add(this.btnLogin_Pin);
            this.tabPage3.Controls.Add(this.btnLogin_UserPin);
            this.tabPage3.Controls.Add(this.txtPinCode);
            this.tabPage3.Controls.Add(this.txtUserCode);
            this.tabPage3.Controls.Add(this.txtSwipeCard);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1090, 186);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Login";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(494, 38);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 14;
            this.button7.Text = "Door closed";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(494, 11);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 13;
            this.button6.Text = "Door open";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(264, 125);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(174, 40);
            this.btnLogout.TabIndex = 12;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnLogin_SwipePin
            // 
            this.btnLogin_SwipePin.Location = new System.Drawing.Point(264, 96);
            this.btnLogin_SwipePin.Name = "btnLogin_SwipePin";
            this.btnLogin_SwipePin.Size = new System.Drawing.Size(174, 23);
            this.btnLogin_SwipePin.TabIndex = 11;
            this.btnLogin_SwipePin.Text = "Login: SwipeCard + PinCode";
            this.btnLogin_SwipePin.UseVisualStyleBackColor = true;
            this.btnLogin_SwipePin.Click += new System.EventHandler(this.btnLogin_SwipePin_Click);
            // 
            // btnLogin_Swipe
            // 
            this.btnLogin_Swipe.Location = new System.Drawing.Point(264, 67);
            this.btnLogin_Swipe.Name = "btnLogin_Swipe";
            this.btnLogin_Swipe.Size = new System.Drawing.Size(174, 23);
            this.btnLogin_Swipe.TabIndex = 10;
            this.btnLogin_Swipe.Text = "Login: SwipeCard";
            this.btnLogin_Swipe.UseVisualStyleBackColor = true;
            this.btnLogin_Swipe.Click += new System.EventHandler(this.btnLogin_Swipe_Click);
            // 
            // btnLogin_Pin
            // 
            this.btnLogin_Pin.Location = new System.Drawing.Point(264, 38);
            this.btnLogin_Pin.Name = "btnLogin_Pin";
            this.btnLogin_Pin.Size = new System.Drawing.Size(174, 23);
            this.btnLogin_Pin.TabIndex = 9;
            this.btnLogin_Pin.Text = "Login: PinCode";
            this.btnLogin_Pin.UseVisualStyleBackColor = true;
            this.btnLogin_Pin.Click += new System.EventHandler(this.btnLogin_Pin_Click);
            // 
            // btnLogin_UserPin
            // 
            this.btnLogin_UserPin.Location = new System.Drawing.Point(264, 11);
            this.btnLogin_UserPin.Name = "btnLogin_UserPin";
            this.btnLogin_UserPin.Size = new System.Drawing.Size(174, 23);
            this.btnLogin_UserPin.TabIndex = 8;
            this.btnLogin_UserPin.Text = "Login: UserCode + PinCode";
            this.btnLogin_UserPin.UseVisualStyleBackColor = true;
            this.btnLogin_UserPin.Click += new System.EventHandler(this.btnLogin_UserPin_Click);
            // 
            // txtPinCode
            // 
            this.txtPinCode.Location = new System.Drawing.Point(82, 41);
            this.txtPinCode.Mask = "0000";
            this.txtPinCode.Name = "txtPinCode";
            this.txtPinCode.Size = new System.Drawing.Size(100, 20);
            this.txtPinCode.TabIndex = 7;
            this.txtPinCode.Text = "1234";
            this.txtPinCode.ValidatingType = typeof(int);
            // 
            // txtUserCode
            // 
            this.txtUserCode.Location = new System.Drawing.Point(82, 13);
            this.txtUserCode.Mask = "0000";
            this.txtUserCode.Name = "txtUserCode";
            this.txtUserCode.Size = new System.Drawing.Size(100, 20);
            this.txtUserCode.TabIndex = 6;
            this.txtUserCode.Text = "0001";
            this.txtUserCode.ValidatingType = typeof(int);
            // 
            // txtSwipeCard
            // 
            this.txtSwipeCard.Location = new System.Drawing.Point(82, 70);
            this.txtSwipeCard.MaxLength = 64;
            this.txtSwipeCard.Name = "txtSwipeCard";
            this.txtSwipeCard.Size = new System.Drawing.Size(163, 20);
            this.txtSwipeCard.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Swipecard:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "PIN Code:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User code:";
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1090, 186);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Position";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1090, 186);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "External input";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1090, 186);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Other";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // txtDbgLog2
            // 
            this.txtDbgLog2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDbgLog2.Location = new System.Drawing.Point(12, 230);
            this.txtDbgLog2.Name = "txtDbgLog2";
            this.txtDbgLog2.Size = new System.Drawing.Size(1098, 491);
            this.txtDbgLog2.TabIndex = 36;
            this.txtDbgLog2.Text = "";
            // 
            // KeyConductorEmulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 724);
            this.Controls.Add(this.txtDbgLog2);
            this.Controls.Add(this.tabControl1);
            this.Name = "KeyConductorEmulator";
            this.Text = "KeyConductorEmulator";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDebugKCID;
        private System.Windows.Forms.TextBox txtDebugPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.RichTextBox txtDbgLog2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnLogin_SwipePin;
        private System.Windows.Forms.Button btnLogin_Swipe;
        private System.Windows.Forms.Button btnLogin_Pin;
        private System.Windows.Forms.Button btnLogin_UserPin;
        private System.Windows.Forms.MaskedTextBox txtPinCode;
        private System.Windows.Forms.MaskedTextBox txtUserCode;
        private System.Windows.Forms.TextBox txtSwipeCard;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
    }
}