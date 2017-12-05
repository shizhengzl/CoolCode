namespace WindowTools
{
    partial class WindowTools
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabtools = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.emailHost = new System.Windows.Forms.Label();
            this.emailSendMail = new System.Windows.Forms.Label();
            this.emailPassword = new System.Windows.Forms.Label();
            this.emailPort = new System.Windows.Forms.Label();
            this.emailSendTo = new System.Windows.Forms.Label();
            this.emailMessage = new System.Windows.Forms.Label();
            this.txtemailhost = new System.Windows.Forms.TextBox();
            this.txtemailsendmail = new System.Windows.Forms.TextBox();
            this.txtemailpassword = new System.Windows.Forms.TextBox();
            this.txtemailport = new System.Windows.Forms.TextBox();
            this.txtemailsendto = new System.Windows.Forms.TextBox();
            this.txtemailsendmessage = new System.Windows.Forms.TextBox();
            this.btnemailSend = new System.Windows.Forms.Button();
            this.txtemailsendresult = new System.Windows.Forms.TextBox();
            this.txtemailsubject = new System.Windows.Forms.TextBox();
            this.txtemailSendToCC = new System.Windows.Forms.TextBox();
            this.emailsubject = new System.Windows.Forms.Label();
            this.emailsendtocc = new System.Windows.Forms.Label();
            this.tabtools.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabtools
            // 
            this.tabtools.Controls.Add(this.tabPage1);
            this.tabtools.Controls.Add(this.tabPage2);
            this.tabtools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabtools.Location = new System.Drawing.Point(0, 0);
            this.tabtools.Name = "tabtools";
            this.tabtools.SelectedIndex = 0;
            this.tabtools.Size = new System.Drawing.Size(921, 487);
            this.tabtools.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtemailsubject);
            this.tabPage1.Controls.Add(this.txtemailSendToCC);
            this.tabPage1.Controls.Add(this.emailsubject);
            this.tabPage1.Controls.Add(this.emailsendtocc);
            this.tabPage1.Controls.Add(this.txtemailsendresult);
            this.tabPage1.Controls.Add(this.btnemailSend);
            this.tabPage1.Controls.Add(this.txtemailsendmessage);
            this.tabPage1.Controls.Add(this.txtemailsendto);
            this.tabPage1.Controls.Add(this.txtemailport);
            this.tabPage1.Controls.Add(this.txtemailpassword);
            this.tabPage1.Controls.Add(this.txtemailsendmail);
            this.tabPage1.Controls.Add(this.txtemailhost);
            this.tabPage1.Controls.Add(this.emailMessage);
            this.tabPage1.Controls.Add(this.emailSendTo);
            this.tabPage1.Controls.Add(this.emailPort);
            this.tabPage1.Controls.Add(this.emailPassword);
            this.tabPage1.Controls.Add(this.emailSendMail);
            this.tabPage1.Controls.Add(this.emailHost);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(913, 461);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabemail";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(913, 461);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabdatabase";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // emailHost
            // 
            this.emailHost.AutoSize = true;
            this.emailHost.Location = new System.Drawing.Point(65, 43);
            this.emailHost.Name = "emailHost";
            this.emailHost.Size = new System.Drawing.Size(29, 12);
            this.emailHost.TabIndex = 0;
            this.emailHost.Text = "Host";
            // 
            // emailSendMail
            // 
            this.emailSendMail.AutoSize = true;
            this.emailSendMail.Location = new System.Drawing.Point(43, 71);
            this.emailSendMail.Name = "emailSendMail";
            this.emailSendMail.Size = new System.Drawing.Size(53, 12);
            this.emailSendMail.TabIndex = 1;
            this.emailSendMail.Text = "SendMail";
            // 
            // emailPassword
            // 
            this.emailPassword.AutoSize = true;
            this.emailPassword.Location = new System.Drawing.Point(41, 98);
            this.emailPassword.Name = "emailPassword";
            this.emailPassword.Size = new System.Drawing.Size(53, 12);
            this.emailPassword.TabIndex = 2;
            this.emailPassword.Text = "Password";
            // 
            // emailPort
            // 
            this.emailPort.AutoSize = true;
            this.emailPort.Location = new System.Drawing.Point(65, 127);
            this.emailPort.Name = "emailPort";
            this.emailPort.Size = new System.Drawing.Size(29, 12);
            this.emailPort.TabIndex = 3;
            this.emailPort.Text = "Port";
            // 
            // emailSendTo
            // 
            this.emailSendTo.AutoSize = true;
            this.emailSendTo.Location = new System.Drawing.Point(56, 155);
            this.emailSendTo.Name = "emailSendTo";
            this.emailSendTo.Size = new System.Drawing.Size(41, 12);
            this.emailSendTo.TabIndex = 4;
            this.emailSendTo.Text = "SendTo";
            // 
            // emailMessage
            // 
            this.emailMessage.AutoSize = true;
            this.emailMessage.Location = new System.Drawing.Point(26, 185);
            this.emailMessage.Name = "emailMessage";
            this.emailMessage.Size = new System.Drawing.Size(71, 12);
            this.emailMessage.TabIndex = 5;
            this.emailMessage.Text = "SendMessage";
            // 
            // txtemailhost
            // 
            this.txtemailhost.Location = new System.Drawing.Point(125, 40);
            this.txtemailhost.Name = "txtemailhost";
            this.txtemailhost.Size = new System.Drawing.Size(146, 21);
            this.txtemailhost.TabIndex = 6;
            this.txtemailhost.Text = "smtp.exmail.qq.com";
            // 
            // txtemailsendmail
            // 
            this.txtemailsendmail.Location = new System.Drawing.Point(125, 69);
            this.txtemailsendmail.Name = "txtemailsendmail";
            this.txtemailsendmail.Size = new System.Drawing.Size(146, 21);
            this.txtemailsendmail.TabIndex = 7;
            this.txtemailsendmail.Text = "zshi@dfocuspace.com";
            // 
            // txtemailpassword
            // 
            this.txtemailpassword.Location = new System.Drawing.Point(125, 95);
            this.txtemailpassword.Name = "txtemailpassword";
            this.txtemailpassword.Size = new System.Drawing.Size(146, 21);
            this.txtemailpassword.TabIndex = 8;
            this.txtemailpassword.Text = "Shizi120";
            // 
            // txtemailport
            // 
            this.txtemailport.Location = new System.Drawing.Point(125, 127);
            this.txtemailport.Name = "txtemailport";
            this.txtemailport.Size = new System.Drawing.Size(146, 21);
            this.txtemailport.TabIndex = 9;
            this.txtemailport.Text = "587";
            // 
            // txtemailsendto
            // 
            this.txtemailsendto.Location = new System.Drawing.Point(125, 155);
            this.txtemailsendto.Name = "txtemailsendto";
            this.txtemailsendto.Size = new System.Drawing.Size(146, 21);
            this.txtemailsendto.TabIndex = 10;
            this.txtemailsendto.Text = "shizheng89@qq.com";
            // 
            // txtemailsendmessage
            // 
            this.txtemailsendmessage.Location = new System.Drawing.Point(125, 182);
            this.txtemailsendmessage.Name = "txtemailsendmessage";
            this.txtemailsendmessage.Size = new System.Drawing.Size(146, 21);
            this.txtemailsendmessage.TabIndex = 11;
            this.txtemailsendmessage.Text = "Test";
            // 
            // btnemailSend
            // 
            this.btnemailSend.Location = new System.Drawing.Point(196, 280);
            this.btnemailSend.Name = "btnemailSend";
            this.btnemailSend.Size = new System.Drawing.Size(75, 23);
            this.btnemailSend.TabIndex = 12;
            this.btnemailSend.Text = "Send Test";
            this.btnemailSend.UseVisualStyleBackColor = true;
            this.btnemailSend.Click += new System.EventHandler(this.btnemailSend_Click);
            // 
            // txtemailsendresult
            // 
            this.txtemailsendresult.Location = new System.Drawing.Point(293, 40);
            this.txtemailsendresult.Multiline = true;
            this.txtemailsendresult.Name = "txtemailsendresult";
            this.txtemailsendresult.Size = new System.Drawing.Size(233, 157);
            this.txtemailsendresult.TabIndex = 13;
            // 
            // txtemailsubject
            // 
            this.txtemailsubject.Location = new System.Drawing.Point(125, 238);
            this.txtemailsubject.Name = "txtemailsubject";
            this.txtemailsubject.Size = new System.Drawing.Size(146, 21);
            this.txtemailsubject.TabIndex = 17;
            this.txtemailsubject.Text = "Test";
            // 
            // txtemailSendToCC
            // 
            this.txtemailSendToCC.Location = new System.Drawing.Point(125, 211);
            this.txtemailSendToCC.Name = "txtemailSendToCC";
            this.txtemailSendToCC.Size = new System.Drawing.Size(146, 21);
            this.txtemailSendToCC.TabIndex = 16;
            // 
            // emailsubject
            // 
            this.emailsubject.AutoSize = true;
            this.emailsubject.Location = new System.Drawing.Point(47, 241);
            this.emailsubject.Name = "emailsubject";
            this.emailsubject.Size = new System.Drawing.Size(47, 12);
            this.emailsubject.TabIndex = 15;
            this.emailsubject.Text = "Subject";
            // 
            // emailsendtocc
            // 
            this.emailsendtocc.AutoSize = true;
            this.emailsendtocc.Location = new System.Drawing.Point(43, 214);
            this.emailsendtocc.Name = "emailsendtocc";
            this.emailsendtocc.Size = new System.Drawing.Size(53, 12);
            this.emailsendtocc.TabIndex = 14;
            this.emailsendtocc.Text = "SendToCC";
            // 
            // WindowTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 487);
            this.Controls.Add(this.tabtools);
            this.Name = "WindowTools";
            this.Text = "WindowTools";
            this.tabtools.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabtools;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label emailSendTo;
        private System.Windows.Forms.Label emailPort;
        private System.Windows.Forms.Label emailPassword;
        private System.Windows.Forms.Label emailSendMail;
        private System.Windows.Forms.Label emailHost;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtemailsendmessage;
        private System.Windows.Forms.TextBox txtemailsendto;
        private System.Windows.Forms.TextBox txtemailport;
        private System.Windows.Forms.TextBox txtemailpassword;
        private System.Windows.Forms.TextBox txtemailsendmail;
        private System.Windows.Forms.TextBox txtemailhost;
        private System.Windows.Forms.Label emailMessage;
        private System.Windows.Forms.Button btnemailSend;
        private System.Windows.Forms.TextBox txtemailsendresult;
        private System.Windows.Forms.TextBox txtemailsubject;
        private System.Windows.Forms.TextBox txtemailSendToCC;
        private System.Windows.Forms.Label emailsubject;
        private System.Windows.Forms.Label emailsendtocc;
    }
}

