namespace Science_Library
{
    partial class Admin
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
            this.statusBtn = new System.Windows.Forms.Button();
            this.memListBtn = new System.Windows.Forms.Button();
            this.IPlbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // statusBtn
            // 
            this.statusBtn.Location = new System.Drawing.Point(70, 71);
            this.statusBtn.Name = "statusBtn";
            this.statusBtn.Size = new System.Drawing.Size(194, 60);
            this.statusBtn.TabIndex = 0;
            this.statusBtn.Text = "자리 현황";
            this.statusBtn.UseVisualStyleBackColor = true;
            this.statusBtn.Click += new System.EventHandler(this.statusBtn_Click);
            // 
            // memListBtn
            // 
            this.memListBtn.Location = new System.Drawing.Point(307, 71);
            this.memListBtn.Name = "memListBtn";
            this.memListBtn.Size = new System.Drawing.Size(194, 60);
            this.memListBtn.TabIndex = 1;
            this.memListBtn.Text = "회원 목록";
            this.memListBtn.UseVisualStyleBackColor = true;
            this.memListBtn.Click += new System.EventHandler(this.memListBtn_Click);
            // 
            // IPlbl
            // 
            this.IPlbl.AutoSize = true;
            this.IPlbl.Location = new System.Drawing.Point(504, 297);
            this.IPlbl.Name = "IPlbl";
            this.IPlbl.Size = new System.Drawing.Size(45, 15);
            this.IPlbl.TabIndex = 2;
            this.IPlbl.Text = "label1";
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 321);
            this.Controls.Add(this.IPlbl);
            this.Controls.Add(this.memListBtn);
            this.Controls.Add(this.statusBtn);
            this.Name = "Admin";
            this.Text = "Admin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button statusBtn;
        private System.Windows.Forms.Button memListBtn;
        private System.Windows.Forms.Label IPlbl;
    }
}