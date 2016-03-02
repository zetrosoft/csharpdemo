namespace ZoiperWinForms
{
    partial class ZoiperMain
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
            this.btnAddUser = new System.Windows.Forms.Button();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbUsers = new System.Windows.Forms.ListBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnUnregister = new System.Windows.Forms.Button();
            this.btnCreateCall = new System.Windows.Forms.Button();
            this.lblCallee = new System.Windows.Forms.Label();
            this.tbCallee = new System.Windows.Forms.TextBox();
            this.rtbRunLog = new System.Windows.Forms.RichTextBox();
            this.cbTransportType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grpBAccountState = new System.Windows.Forms.GroupBox();
            this.lbActiveCalls = new System.Windows.Forms.ListBox();
            this.tbIsRegistered = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbCertUserName = new System.Windows.Forms.TextBox();
            this.tbCertPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.grpBActication = new System.Windows.Forms.GroupBox();
            this.btnCertActivate = new System.Windows.Forms.Button();
            this.grpBActiveCalls = new System.Windows.Forms.GroupBox();
            this.btnCloseCall = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpBAccountState.SuspendLayout();
            this.grpBActication.SuspendLayout();
            this.grpBActiveCalls.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(182, 223);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(75, 23);
            this.btnAddUser.TabIndex = 0;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(81, 118);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(176, 20);
            this.tbUserName.TabIndex = 1;
            this.tbUserName.Text = "atanas";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(81, 144);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(176, 20);
            this.tbPassword.TabIndex = 2;
            this.tbPassword.Text = "mnbv";
            // 
            // tbServer
            // 
            this.tbServer.Location = new System.Drawing.Point(81, 170);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(176, 20);
            this.tbServer.TabIndex = 3;
            this.tbServer.Text = "sip3.zoiper.com";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "User Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Server:";
            // 
            // lbUsers
            // 
            this.lbUsers.FormattingEnabled = true;
            this.lbUsers.Location = new System.Drawing.Point(6, 19);
            this.lbUsers.Name = "lbUsers";
            this.lbUsers.Size = new System.Drawing.Size(254, 82);
            this.lbUsers.TabIndex = 7;
            this.lbUsers.SelectedIndexChanged += new System.EventHandler(this.lbUsers_SelectedIndexChanged);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(9, 47);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 9;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnUnregister
            // 
            this.btnUnregister.Location = new System.Drawing.Point(90, 47);
            this.btnUnregister.Name = "btnUnregister";
            this.btnUnregister.Size = new System.Drawing.Size(75, 23);
            this.btnUnregister.TabIndex = 10;
            this.btnUnregister.Text = "Unregister";
            this.btnUnregister.UseVisualStyleBackColor = true;
            this.btnUnregister.Click += new System.EventHandler(this.btnUnregister_Click);
            // 
            // btnCreateCall
            // 
            this.btnCreateCall.Location = new System.Drawing.Point(173, 74);
            this.btnCreateCall.Name = "btnCreateCall";
            this.btnCreateCall.Size = new System.Drawing.Size(75, 23);
            this.btnCreateCall.TabIndex = 11;
            this.btnCreateCall.Text = "Create Call";
            this.btnCreateCall.UseVisualStyleBackColor = true;
            this.btnCreateCall.Click += new System.EventHandler(this.btnCreateCall_Click);
            // 
            // lblCallee
            // 
            this.lblCallee.AutoSize = true;
            this.lblCallee.Location = new System.Drawing.Point(6, 79);
            this.lblCallee.Name = "lblCallee";
            this.lblCallee.Size = new System.Drawing.Size(39, 13);
            this.lblCallee.TabIndex = 12;
            this.lblCallee.Text = "Callee:";
            // 
            // tbCallee
            // 
            this.tbCallee.Location = new System.Drawing.Point(88, 76);
            this.tbCallee.Name = "tbCallee";
            this.tbCallee.Size = new System.Drawing.Size(77, 20);
            this.tbCallee.TabIndex = 13;
            // 
            // rtbRunLog
            // 
            this.rtbRunLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbRunLog.Enabled = false;
            this.rtbRunLog.Location = new System.Drawing.Point(12, 252);
            this.rtbRunLog.Name = "rtbRunLog";
            this.rtbRunLog.Size = new System.Drawing.Size(866, 347);
            this.rtbRunLog.TabIndex = 14;
            this.rtbRunLog.Text = "";
            // 
            // cbTransportType
            // 
            this.cbTransportType.FormattingEnabled = true;
            this.cbTransportType.Items.AddRange(new object[] {
            "UDP",
            "TCP"});
            this.cbTransportType.Location = new System.Drawing.Point(81, 196);
            this.cbTransportType.Name = "cbTransportType";
            this.cbTransportType.Size = new System.Drawing.Size(176, 21);
            this.cbTransportType.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Transoprt:";
            // 
            // grpBAccountState
            // 
            this.grpBAccountState.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBAccountState.Controls.Add(this.tbIsRegistered);
            this.grpBAccountState.Controls.Add(this.label5);
            this.grpBAccountState.Controls.Add(this.tbCallee);
            this.grpBAccountState.Controls.Add(this.btnCreateCall);
            this.grpBAccountState.Controls.Add(this.btnUnregister);
            this.grpBAccountState.Controls.Add(this.lblCallee);
            this.grpBAccountState.Controls.Add(this.btnRegister);
            this.grpBAccountState.Enabled = false;
            this.grpBAccountState.Location = new System.Drawing.Point(6, 107);
            this.grpBAccountState.Name = "grpBAccountState";
            this.grpBAccountState.Size = new System.Drawing.Size(254, 121);
            this.grpBAccountState.TabIndex = 17;
            this.grpBAccountState.TabStop = false;
            this.grpBAccountState.Text = "VoIP User";
            // 
            // lbActiveCalls
            // 
            this.lbActiveCalls.FormattingEnabled = true;
            this.lbActiveCalls.Location = new System.Drawing.Point(9, 19);
            this.lbActiveCalls.Name = "lbActiveCalls";
            this.lbActiveCalls.Size = new System.Drawing.Size(212, 95);
            this.lbActiveCalls.TabIndex = 18;
            // 
            // tbIsRegistered
            // 
            this.tbIsRegistered.Location = new System.Drawing.Point(84, 21);
            this.tbIsRegistered.Name = "tbIsRegistered";
            this.tbIsRegistered.ReadOnly = true;
            this.tbIsRegistered.Size = new System.Drawing.Size(81, 20);
            this.tbIsRegistered.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Is Registered:";
            // 
            // tbCertUserName
            // 
            this.tbCertUserName.Location = new System.Drawing.Point(75, 19);
            this.tbCertUserName.Name = "tbCertUserName";
            this.tbCertUserName.Size = new System.Drawing.Size(104, 20);
            this.tbCertUserName.TabIndex = 18;
            this.tbCertUserName.Text = "atanas.andreev";
            // 
            // tbCertPassword
            // 
            this.tbCertPassword.Location = new System.Drawing.Point(75, 45);
            this.tbCertPassword.Name = "tbCertPassword";
            this.tbCertPassword.Size = new System.Drawing.Size(104, 20);
            this.tbCertPassword.TabIndex = 19;
            this.tbCertPassword.Text = "-CSAT4";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "User Name:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Password:";
            // 
            // grpBActication
            // 
            this.grpBActication.Controls.Add(this.btnCertActivate);
            this.grpBActication.Controls.Add(this.label8);
            this.grpBActication.Controls.Add(this.label9);
            this.grpBActication.Controls.Add(this.tbCertUserName);
            this.grpBActication.Controls.Add(this.tbCertPassword);
            this.grpBActication.Location = new System.Drawing.Point(12, 12);
            this.grpBActication.Name = "grpBActication";
            this.grpBActication.Size = new System.Drawing.Size(192, 100);
            this.grpBActication.TabIndex = 22;
            this.grpBActication.TabStop = false;
            this.grpBActication.Text = "SDK Activation";
            // 
            // btnCertActivate
            // 
            this.btnCertActivate.Location = new System.Drawing.Point(104, 71);
            this.btnCertActivate.Name = "btnCertActivate";
            this.btnCertActivate.Size = new System.Drawing.Size(75, 23);
            this.btnCertActivate.TabIndex = 23;
            this.btnCertActivate.Text = "Activate";
            this.btnCertActivate.UseVisualStyleBackColor = true;
            this.btnCertActivate.Click += new System.EventHandler(this.btnCertActivate_Click);
            // 
            // grpBActiveCalls
            // 
            this.grpBActiveCalls.Controls.Add(this.btnCloseCall);
            this.grpBActiveCalls.Controls.Add(this.lbActiveCalls);
            this.grpBActiveCalls.Location = new System.Drawing.Point(535, 12);
            this.grpBActiveCalls.Name = "grpBActiveCalls";
            this.grpBActiveCalls.Size = new System.Drawing.Size(343, 128);
            this.grpBActiveCalls.TabIndex = 23;
            this.grpBActiveCalls.TabStop = false;
            this.grpBActiveCalls.Text = "Active Calls";
            // 
            // btnCloseCall
            // 
            this.btnCloseCall.Location = new System.Drawing.Point(227, 19);
            this.btnCloseCall.Name = "btnCloseCall";
            this.btnCloseCall.Size = new System.Drawing.Size(75, 23);
            this.btnCloseCall.TabIndex = 16;
            this.btnCloseCall.Text = "Close Call";
            this.btnCloseCall.UseVisualStyleBackColor = true;
            this.btnCloseCall.Click += new System.EventHandler(this.btnCloseCall_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbUsers);
            this.groupBox1.Controls.Add(this.grpBAccountState);
            this.groupBox1.Location = new System.Drawing.Point(263, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 234);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "VoIP Users";
            // 
            // ZoiperMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 611);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpBActiveCalls);
            this.Controls.Add(this.grpBActication);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbTransportType);
            this.Controls.Add(this.rtbRunLog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbServer);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.btnAddUser);
            this.Name = "ZoiperMain";
            this.Text = "Zoiper SDK";
            this.grpBAccountState.ResumeLayout(false);
            this.grpBAccountState.PerformLayout();
            this.grpBActication.ResumeLayout(false);
            this.grpBActication.PerformLayout();
            this.grpBActiveCalls.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbUsers;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnUnregister;
        private System.Windows.Forms.Button btnCreateCall;
        private System.Windows.Forms.Label lblCallee;
        private System.Windows.Forms.TextBox tbCallee;
        private System.Windows.Forms.RichTextBox rtbRunLog;
        private System.Windows.Forms.ComboBox cbTransportType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grpBAccountState;
        private System.Windows.Forms.TextBox tbIsRegistered;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lbActiveCalls;
        private System.Windows.Forms.TextBox tbCertUserName;
        private System.Windows.Forms.TextBox tbCertPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox grpBActication;
        private System.Windows.Forms.Button btnCertActivate;
        private System.Windows.Forms.GroupBox grpBActiveCalls;
        private System.Windows.Forms.Button btnCloseCall;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

