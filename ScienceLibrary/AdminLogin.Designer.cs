namespace Science_Library
{
    partial class AdminLogin
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
            this.pnlAdminLogin = new System.Windows.Forms.Panel();
            this.lblAdminId = new System.Windows.Forms.Label();
            this.txtAdminPw = new System.Windows.Forms.TextBox();
            this.txtAdminId = new System.Windows.Forms.TextBox();
            this.lblAdminPw = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdminLogin = new System.Windows.Forms.Button();
            this.lblAdminStatus = new System.Windows.Forms.Label();
            this.pnlAdminLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAdminLogin
            // 
            this.pnlAdminLogin.Controls.Add(this.lblAdminId);
            this.pnlAdminLogin.Controls.Add(this.txtAdminPw);
            this.pnlAdminLogin.Controls.Add(this.txtAdminId);
            this.pnlAdminLogin.Controls.Add(this.lblAdminPw);
            this.pnlAdminLogin.Location = new System.Drawing.Point(38, 82);
            this.pnlAdminLogin.Name = "pnlAdminLogin";
            this.pnlAdminLogin.Size = new System.Drawing.Size(496, 137);
            this.pnlAdminLogin.TabIndex = 7;
            // 
            // lblAdminId
            // 
            this.lblAdminId.AutoSize = true;
            this.lblAdminId.Location = new System.Drawing.Point(22, 32);
            this.lblAdminId.Name = "lblAdminId";
            this.lblAdminId.Size = new System.Drawing.Size(20, 15);
            this.lblAdminId.TabIndex = 2;
            this.lblAdminId.Text = "ID";
            // 
            // txtAdminPw
            // 
            this.txtAdminPw.Location = new System.Drawing.Point(73, 82);
            this.txtAdminPw.Name = "txtAdminPw";
            this.txtAdminPw.PasswordChar = '*';
            this.txtAdminPw.Size = new System.Drawing.Size(396, 25);
            this.txtAdminPw.TabIndex = 1;
            // 
            // txtAdminId
            // 
            this.txtAdminId.Location = new System.Drawing.Point(73, 29);
            this.txtAdminId.Name = "txtAdminId";
            this.txtAdminId.Size = new System.Drawing.Size(396, 25);
            this.txtAdminId.TabIndex = 0;
            // 
            // lblAdminPw
            // 
            this.lblAdminPw.AutoSize = true;
            this.lblAdminPw.Location = new System.Drawing.Point(22, 85);
            this.lblAdminPw.Name = "lblAdminPw";
            this.lblAdminPw.Size = new System.Drawing.Size(31, 15);
            this.lblAdminPw.TabIndex = 3;
            this.lblAdminPw.Text = "PW";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(197, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "관리자 로그인 창 입니다.";
            // 
            // btnAdminLogin
            // 
            this.btnAdminLogin.Location = new System.Drawing.Point(210, 251);
            this.btnAdminLogin.Name = "btnAdminLogin";
            this.btnAdminLogin.Size = new System.Drawing.Size(142, 49);
            this.btnAdminLogin.TabIndex = 9;
            this.btnAdminLogin.Text = "Log In";
            this.btnAdminLogin.UseVisualStyleBackColor = true;
            this.btnAdminLogin.Click += new System.EventHandler(this.btnAdminLogin_Click);
            // 
            // lblAdminStatus
            // 
            this.lblAdminStatus.AutoSize = true;
            this.lblAdminStatus.ForeColor = System.Drawing.Color.Red;
            this.lblAdminStatus.Location = new System.Drawing.Point(207, 222);
            this.lblAdminStatus.Name = "lblAdminStatus";
            this.lblAdminStatus.Size = new System.Drawing.Size(0, 15);
            this.lblAdminStatus.TabIndex = 10;
            // 
            // AdminLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 312);
            this.Controls.Add(this.lblAdminStatus);
            this.Controls.Add(this.btnAdminLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlAdminLogin);
            this.Name = "AdminLogin";
            this.Text = "AdminLogin";
            this.pnlAdminLogin.ResumeLayout(false);
            this.pnlAdminLogin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlAdminLogin;
        private System.Windows.Forms.Label lblAdminId;
        private System.Windows.Forms.TextBox txtAdminPw;
        private System.Windows.Forms.TextBox txtAdminId;
        private System.Windows.Forms.Label lblAdminPw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdminLogin;
        private System.Windows.Forms.Label lblAdminStatus;
    }
}