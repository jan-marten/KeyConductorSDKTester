namespace KeyConductorSDKTester
{
    partial class LogFileViewer
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.grdLog = new System.Windows.Forms.DataGridView();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnReloadLogKCL = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdLog)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Load logfile:";
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(83, 9);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(344, 20);
            this.txtFilename.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(433, 5);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(68, 24);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // grdLog
            // 
            this.grdLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLog.Location = new System.Drawing.Point(15, 35);
            this.grdLog.Name = "grdLog";
            this.grdLog.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdLog.Size = new System.Drawing.Size(899, 484);
            this.grdLog.TabIndex = 3;
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(507, 5);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(106, 24);
            this.btnReload.TabIndex = 4;
            this.btnReload.Text = "Reload log";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnReloadLogKCL
            // 
            this.btnReloadLogKCL.Location = new System.Drawing.Point(619, 5);
            this.btnReloadLogKCL.Name = "btnReloadLogKCL";
            this.btnReloadLogKCL.Size = new System.Drawing.Size(106, 24);
            this.btnReloadLogKCL.TabIndex = 5;
            this.btnReloadLogKCL.Text = "Reload log wKCL";
            this.btnReloadLogKCL.UseVisualStyleBackColor = true;
            this.btnReloadLogKCL.Click += new System.EventHandler(this.btnReloadLogKCL_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(814, 8);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(100, 20);
            this.txtFilter.TabIndex = 6;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(776, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Filter:";
            // 
            // LogFileViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 531);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.btnReloadLogKCL);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.grdLog);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.label1);
            this.Name = "LogFileViewer";
            this.Text = "LogFileViewer";
            this.Load += new System.EventHandler(this.LogFileViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.DataGridView grdLog;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnReloadLogKCL;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label2;
    }
}