using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Science_Library.DB;
using System.Data.SQLite;
namespace Science_Library
{
    public partial class Login : Form
    {
        SQLite sql = new SQLite();
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            int result = 0;
            int writtenID=int.Parse(txtId.Text);
            string writtenPW=txtPw.Text;
            sql.connect_db();
            result=sql.login_confirm(writtenID, writtenPW);

            if (result == 1)
            {
                main.Show();
            }
            else
            {
                lblIsConfirmed.Text = "입력정보가 올바르지 않습니다.";
            }
        }
        //string in_name = txtName.Text;
        //int in_id = int.Parse(txtID.Text);
        //string in_pw = txtPW.Text;
        //sql.connect_db();
        //sql.user_insert(in_id, in_name, in_pw);
        private void btnSignin_Click(object sender, EventArgs e)
        {
            SignUp signup = new SignUp();
            signup.Show();
        }
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminLogin adminLogin = new AdminLogin();
            adminLogin.Show();
        }
    }
    
}
