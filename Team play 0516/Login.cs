using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Science_Library.DB;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;




namespace Science_Library
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SQLite sql = new SQLite();
            sql.connect_db();
            if (txtId.Text ==txtPw.Text) {      //현재는 아이디랑 비번 똑같아야 Main화면 들어가게 설정
                Main main = new Main();
                main.Show();
                this.Hide();
            }
            else
            {
                NotCorrect notcorrect = new NotCorrect();
                notcorrect.Show();
            }

            
            
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            SignUp signup = new SignUp();
            signup.Show();
        }


        private void PW_visible_CheckedChanged(object sender, EventArgs e)
        {
            

            if (PW_visible.Checked)
            {
                txtPw.PasswordChar = default(char);
            }
            else
            {
                txtPw.PasswordChar = '*';
            }
        }
    }
    
}
