namespace Science_Library
{
    partial class SeminarRoom
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
            this.gboxSeminar2 = new System.Windows.Forms.GroupBox();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.gboxSeminar1 = new System.Windows.Forms.GroupBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.txtSeminarStatus = new System.Windows.Forms.TextBox();
            this.gboxSeminar2.SuspendLayout();
            this.gboxSeminar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxSeminar2
            // 
            this.gboxSeminar2.Controls.Add(this.checkedListBox2);
            this.gboxSeminar2.Location = new System.Drawing.Point(421, 58);
            this.gboxSeminar2.Name = "gboxSeminar2";
            this.gboxSeminar2.Size = new System.Drawing.Size(332, 136);
            this.gboxSeminar2.TabIndex = 4;
            this.gboxSeminar2.TabStop = false;
            this.gboxSeminar2.Text = "세미나실2";
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Items.AddRange(new object[] {
            "6:00 ~ 8:50",
            "9:00 ~ 11:50",
            "12:00 ~ 14:50",
            "15:00 ~ 17:50",
            "18:00 ~ 20:50"});
            this.checkedListBox2.Location = new System.Drawing.Point(6, 24);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(318, 104);
            this.checkedListBox2.TabIndex = 2;
            // 
            // gboxSeminar1
            // 
            this.gboxSeminar1.Controls.Add(this.checkedListBox1);
            this.gboxSeminar1.Location = new System.Drawing.Point(37, 58);
            this.gboxSeminar1.Name = "gboxSeminar1";
            this.gboxSeminar1.Size = new System.Drawing.Size(325, 136);
            this.gboxSeminar1.TabIndex = 5;
            this.gboxSeminar1.TabStop = false;
            this.gboxSeminar1.Text = "세미나실1";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "6:00 ~ 8:50",
            "9:00 ~ 11:50",
            "12:00 ~ 14:50",
            "15:00 ~ 17:50",
            "18:00 ~ 20:50"});
            this.checkedListBox1.Location = new System.Drawing.Point(6, 24);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(313, 104);
            this.checkedListBox1.TabIndex = 1;
            // 
            // txtSeminarStatus
            // 
            this.txtSeminarStatus.Location = new System.Drawing.Point(43, 242);
            this.txtSeminarStatus.Multiline = true;
            this.txtSeminarStatus.Name = "txtSeminarStatus";
            this.txtSeminarStatus.Size = new System.Drawing.Size(300, 151);
            this.txtSeminarStatus.TabIndex = 6;
            // 
            // SeminarRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtSeminarStatus);
            this.Controls.Add(this.gboxSeminar2);
            this.Controls.Add(this.gboxSeminar1);
            this.Name = "SeminarRoom";
            this.Text = "SeminarRoom";
            this.gboxSeminar2.ResumeLayout(false);
            this.gboxSeminar1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxSeminar2;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.GroupBox gboxSeminar1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.TextBox txtSeminarStatus;
    }
}