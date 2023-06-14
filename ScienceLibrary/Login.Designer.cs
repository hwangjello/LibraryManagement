namespace Science_Library
{
    partial class Login
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPw = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.lblPw = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnSignin = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.lblIsConfirmed = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPw
            // 
            this.txtPw.Location = new System.Drawing.Point(73, 82);
            this.txtPw.Name = "txtPw";
            this.txtPw.PasswordChar = '*';
            this.txtPw.Size = new System.Drawing.Size(396, 25);
            this.txtPw.TabIndex = 0;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(73, 29);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(396, 25);
            this.txtId.TabIndex = 1;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(22, 32);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(20, 15);
            this.lblId.TabIndex = 2;
            this.lblId.Text = "ID";
            // 
            // lblPw
            // 
            this.lblPw.AutoSize = true;
            this.lblPw.Location = new System.Drawing.Point(22, 85);
            this.lblPw.Name = "lblPw";
            this.lblPw.Size = new System.Drawing.Size(31, 15);
            this.lblPw.TabIndex = 3;
            this.lblPw.Text = "PW";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(62, 248);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(146, 40);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Log In";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnSignin
            // 
            this.btnSignin.Location = new System.Drawing.Point(239, 248);
            this.btnSignin.Name = "btnSignin";
            this.btnSignin.Size = new System.Drawing.Size(146, 37);
            this.btnSignin.TabIndex = 5;
            this.btnSignin.Text = "Sign Up";
            this.btnSignin.UseVisualStyleBackColor = true;
            this.btnSignin.Click += new System.EventHandler(this.btnSignin_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblId);
            this.panel1.Controls.Add(this.txtPw);
            this.panel1.Controls.Add(this.txtId);
            this.panel1.Controls.Add(this.lblPw);
            this.panel1.Location = new System.Drawing.Point(62, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 137);
            this.panel1.TabIndex = 6;
            // 
            // btnAdmin
            // 
            this.btnAdmin.Location = new System.Drawing.Point(412, 248);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(146, 37);
            this.btnAdmin.TabIndex = 7;
            this.btnAdmin.Text = "Admin";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // lblIsConfirmed
            // 
            this.lblIsConfirmed.AutoSize = true;
            this.lblIsConfirmed.ForeColor = System.Drawing.Color.Red;
            this.lblIsConfirmed.Location = new System.Drawing.Point(218, 219);
            this.lblIsConfirmed.Name = "lblIsConfirmed";
            this.lblIsConfirmed.Size = new System.Drawing.Size(0, 15);
            this.lblIsConfirmed.TabIndex = 8;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 311);
            this.Controls.Add(this.lblIsConfirmed);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSignin);
            this.Controls.Add(this.btnLogin);
            this.Name = "Login";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPw;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblPw;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnSignin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Label lblIsConfirmed;
    }
}

