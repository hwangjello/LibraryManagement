namespace Science_Library
{
    partial class SignUp
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtPW = new System.Windows.Forms.TextBox();
            this.btnSignOK = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblPW = new System.Windows.Forms.Label();
            this.lblPW_confirm = new System.Windows.Forms.Label();
            this.txtPW_confirm = new System.Windows.Forms.TextBox();
            this.PW_visible = new System.Windows.Forms.CheckBox();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(44, 60);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(153, 25);
            this.txtName.TabIndex = 0;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(44, 127);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(153, 25);
            this.txtID.TabIndex = 1;
            // 
            // txtPW
            // 
            this.txtPW.Location = new System.Drawing.Point(44, 203);
            this.txtPW.Name = "txtPW";
            this.txtPW.PasswordChar = '*';
            this.txtPW.Size = new System.Drawing.Size(153, 25);
            this.txtPW.TabIndex = 2;
            // 
            // btnSignOK
            // 
            this.btnSignOK.Enabled = false;
            this.btnSignOK.Location = new System.Drawing.Point(193, 441);
            this.btnSignOK.Name = "btnSignOK";
            this.btnSignOK.Size = new System.Drawing.Size(175, 46);
            this.btnSignOK.TabIndex = 4;
            this.btnSignOK.Text = "가입";
            this.btnSignOK.UseVisualStyleBackColor = true;
            this.btnSignOK.Click += new System.EventHandler(this.btnSignOK_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(41, 32);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(37, 15);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "이름";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(41, 100);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(37, 15);
            this.lblID.TabIndex = 6;
            this.lblID.Text = "학번";
            // 
            // lblPW
            // 
            this.lblPW.AutoSize = true;
            this.lblPW.Location = new System.Drawing.Point(41, 175);
            this.lblPW.Name = "lblPW";
            this.lblPW.Size = new System.Drawing.Size(67, 15);
            this.lblPW.TabIndex = 7;
            this.lblPW.Text = "비밀번호";
            // 
            // lblPW_confirm
            // 
            this.lblPW_confirm.AutoSize = true;
            this.lblPW_confirm.Location = new System.Drawing.Point(41, 254);
            this.lblPW_confirm.Name = "lblPW_confirm";
            this.lblPW_confirm.Size = new System.Drawing.Size(102, 15);
            this.lblPW_confirm.TabIndex = 8;
            this.lblPW_confirm.Text = "비밀번호 확인";
            // 
            // txtPW_confirm
            // 
            this.txtPW_confirm.Location = new System.Drawing.Point(44, 281);
            this.txtPW_confirm.Name = "txtPW_confirm";
            this.txtPW_confirm.PasswordChar = '*';
            this.txtPW_confirm.Size = new System.Drawing.Size(153, 25);
            this.txtPW_confirm.TabIndex = 3;
            // 
            // PW_visible
            // 
            this.PW_visible.AutoSize = true;
            this.PW_visible.Location = new System.Drawing.Point(231, 205);
            this.PW_visible.Name = "PW_visible";
            this.PW_visible.Size = new System.Drawing.Size(124, 19);
            this.PW_visible.TabIndex = 10;
            this.PW_visible.Text = "비밀번호 보기";
            this.PW_visible.UseVisualStyleBackColor = true;
            this.PW_visible.CheckedChanged += new System.EventHandler(this.PW_visible_CheckedChanged);
            // 
            // lblConfirm
            // 
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.ForeColor = System.Drawing.Color.Red;
            this.lblConfirm.Location = new System.Drawing.Point(190, 396);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(0, 15);
            this.lblConfirm.TabIndex = 11;
            // 
            // SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 502);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.PW_visible);
            this.Controls.Add(this.txtPW_confirm);
            this.Controls.Add(this.lblPW_confirm);
            this.Controls.Add(this.lblPW);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnSignOK);
            this.Controls.Add(this.txtPW);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtName);
            this.Name = "SignUp";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtPW;
        private System.Windows.Forms.Button btnSignOK;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblPW;
        private System.Windows.Forms.Label lblPW_confirm;
        private System.Windows.Forms.TextBox txtPW_confirm;
        private System.Windows.Forms.CheckBox PW_visible;
        private System.Windows.Forms.Label lblConfirm;
    }
}