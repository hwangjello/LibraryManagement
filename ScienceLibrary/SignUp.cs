using Science_Library.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Science_Library
{
    public partial class SignUp : Form
    {
        SQLite sql = new SQLite();
        

        public SignUp()
        {
            InitializeComponent();
            txtPW.TextChanged += txtPassword_TextChanged;
            txtPW_confirm.TextChanged += txtConfirmPassword_TextChanged;

        }
        private void CheckPasswordMatch()
        {
            if (txtPW.Text == txtPW_confirm.Text)
            {
                btnSignOK.Enabled = true;
            }
            else if (string.IsNullOrEmpty(txtPW.Text) == true || string.IsNullOrEmpty(txtPW_confirm.Text) == true)
            {
                btnSignOK.Enabled = false;
            }
            else
            {
                btnSignOK.Enabled = false;
            }
        }
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            CheckPasswordMatch();
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            CheckPasswordMatch();
        }
        private void PW_visible_CheckedChanged(object sender, EventArgs e)
        {
            if (PW_visible.Checked)
            {
                txtPW.PasswordChar = default(char);
            }
            else
            {
                txtPW.PasswordChar = '*';
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //int isPWSame = 0;
            //if(txtPW.Text == txtPW_confirm.Text)
            //{
            //    isPWSame = 1;
            //}
            //else
            //{
            //    isPWSame = 0;
            //} 

            //if(isPWSame == 1)
            //{
            //    btnSignOK.Enabled = true;
            //}
        }

        private void btnSignOK_Click(object sender, EventArgs e)
        {
            
            int result = 0;
            string in_name = txtName.Text;
            int in_id = int.Parse(txtID.Text);
            string in_pw = txtPW.Text;
            sql.connect_db();
            result=sql.signup_confirm(in_id);
            if (result == 1)
            {
                sql.user_insert(in_id, in_name, in_pw);
                this.Close();
            }
            else
            {
                lblConfirm.Text = "이미 존재하는 아이디 입니다.";
            }
        }

    }
}
