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
            this.PW_visible = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPw
            // 
            this.txtPw.Location = new System.Drawing.Point(73, 82);
            this.txtPw.Name = "txtPw";
            this.txtPw.PasswordChar = '*';
            this.txtPw.Size = new System.Drawing.Size(241, 25);
            this.txtPw.TabIndex = 0;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(73, 29);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(241, 25);
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
            this.btnLogin.Location = new System.Drawing.Point(118, 225);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(146, 40);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Log In";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnSignin
            // 
            this.btnSignin.Location = new System.Drawing.Point(342, 225);
            this.btnSignin.Name = "btnSignin";
            this.btnSignin.Size = new System.Drawing.Size(146, 37);
            this.btnSignin.TabIndex = 5;
            this.btnSignin.Text = "Sign Up";
            this.btnSignin.UseVisualStyleBackColor = true;
            this.btnSignin.Click += new System.EventHandler(this.btnSignin_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PW_visible);
            this.panel1.Controls.Add(this.lblId);
            this.panel1.Controls.Add(this.txtPw);
            this.panel1.Controls.Add(this.txtId);
            this.panel1.Controls.Add(this.lblPw);
            this.panel1.Location = new System.Drawing.Point(62, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 137);
            this.panel1.TabIndex = 6;
            // 
            // PW_visible
            // 
            this.PW_visible.AutoSize = true;
            this.PW_visible.Location = new System.Drawing.Point(356, 88);
            this.PW_visible.Name = "PW_visible";
            this.PW_visible.Size = new System.Drawing.Size(124, 19);
            this.PW_visible.TabIndex = 11;
            this.PW_visible.Text = "비밀번호 보기";
            this.PW_visible.UseVisualStyleBackColor = true;
            this.PW_visible.CheckedChanged += new System.EventHandler(this.PW_visible_CheckedChanged);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 311);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSignin);
            this.Controls.Add(this.btnLogin);
            this.Name = "Login";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtPw;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblPw;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnSignin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox PW_visible;
    }
}

