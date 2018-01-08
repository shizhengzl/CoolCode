namespace Core.GeneratorWindows
{
    partial class GeneratorLogin
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
            this.chk_remberer = new System.Windows.Forms.CheckBox();
            this.btnCanel = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtLoginName = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblLoginName = new System.Windows.Forms.Label();
            this.comLoginMethod = new System.Windows.Forms.ComboBox();
            this.labLoginMethod = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.labServerName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chk_remberer
            // 
            this.chk_remberer.AutoSize = true;
            this.chk_remberer.Checked = true;
            this.chk_remberer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_remberer.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chk_remberer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.chk_remberer.Location = new System.Drawing.Point(96, 246);
            this.chk_remberer.Name = "chk_remberer";
            this.chk_remberer.Size = new System.Drawing.Size(103, 25);
            this.chk_remberer.TabIndex = 32;
            this.chk_remberer.Text = "Remberer";
            this.chk_remberer.UseVisualStyleBackColor = true;
            // 
            // btnCanel
            // 
            this.btnCanel.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCanel.Location = new System.Drawing.Point(306, 235);
            this.btnCanel.Name = "btnCanel";
            this.btnCanel.Size = new System.Drawing.Size(75, 43);
            this.btnCanel.TabIndex = 31;
            this.btnCanel.Text = "Canel";
            this.btnCanel.UseVisualStyleBackColor = true;
            this.btnCanel.Click += new System.EventHandler(this.btnCanel_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.Location = new System.Drawing.Point(211, 235);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 43);
            this.btnLogin.TabIndex = 30;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPassword.Location = new System.Drawing.Point(213, 186);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(172, 29);
            this.txtPassword.TabIndex = 29;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // txtLoginName
            // 
            this.txtLoginName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLoginName.Location = new System.Drawing.Point(213, 140);
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.Size = new System.Drawing.Size(172, 29);
            this.txtLoginName.TabIndex = 28;
            this.txtLoginName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLoginName_KeyPress);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblPassword.Location = new System.Drawing.Point(91, 187);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(99, 19);
            this.lblPassword.TabIndex = 27;
            this.lblPassword.Text = "Password:";
            // 
            // lblLoginName
            // 
            this.lblLoginName.AutoSize = true;
            this.lblLoginName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLoginName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblLoginName.Location = new System.Drawing.Point(71, 140);
            this.lblLoginName.Name = "lblLoginName";
            this.lblLoginName.Size = new System.Drawing.Size(119, 19);
            this.lblLoginName.TabIndex = 26;
            this.lblLoginName.Text = "Login Name:";
            // 
            // comLoginMethod
            // 
            this.comLoginMethod.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comLoginMethod.FormattingEnabled = true;
            this.comLoginMethod.Items.AddRange(new object[] {
            "Windows   Login",
            "SQLServer Login"});
            this.comLoginMethod.Location = new System.Drawing.Point(213, 88);
            this.comLoginMethod.Name = "comLoginMethod";
            this.comLoginMethod.Size = new System.Drawing.Size(172, 27);
            this.comLoginMethod.TabIndex = 25;
            this.comLoginMethod.SelectedIndexChanged += new System.EventHandler(this.comLoginMethod_SelectedIndexChanged);
            // 
            // labLoginMethod
            // 
            this.labLoginMethod.AutoSize = true;
            this.labLoginMethod.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labLoginMethod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.labLoginMethod.Location = new System.Drawing.Point(30, 89);
            this.labLoginMethod.Name = "labLoginMethod";
            this.labLoginMethod.Size = new System.Drawing.Size(159, 19);
            this.labLoginMethod.TabIndex = 24;
            this.labLoginMethod.Text = "Authentication:";
            // 
            // txtServerName
            // 
            this.txtServerName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtServerName.Location = new System.Drawing.Point(213, 38);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(172, 29);
            this.txtServerName.TabIndex = 23;
            this.txtServerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtServerName_KeyPress);
            // 
            // labServerName
            // 
            this.labServerName.AutoSize = true;
            this.labServerName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labServerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.labServerName.Location = new System.Drawing.Point(58, 38);
            this.labServerName.Name = "labServerName";
            this.labServerName.Size = new System.Drawing.Size(129, 19);
            this.labServerName.TabIndex = 22;
            this.labServerName.Text = "Server Name:";
            // 
            // GeneratorLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 314);
            this.Controls.Add(this.chk_remberer);
            this.Controls.Add(this.btnCanel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtLoginName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblLoginName);
            this.Controls.Add(this.comLoginMethod);
            this.Controls.Add(this.labLoginMethod);
            this.Controls.Add(this.txtServerName);
            this.Controls.Add(this.labServerName);
            this.Name = "GeneratorLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code Generator Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chk_remberer;
        private System.Windows.Forms.Button btnCanel;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtLoginName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblLoginName;
        private System.Windows.Forms.ComboBox comLoginMethod;
        private System.Windows.Forms.Label labLoginMethod;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label labServerName;
    }
}