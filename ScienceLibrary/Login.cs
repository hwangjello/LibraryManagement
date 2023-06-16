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
using Client_Code;


namespace Science_Library
{
    public partial class Login : Form
    {
        SQLite sql = new SQLite();
        
        public Login()
        {
            InitializeComponent();
            
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "" || txtPw.Text=="")
            {
                lblIsConfirmed.Text = "입력정보가 올바르지 않습니다.";
            }
            else
            {
                int writtenID = int.Parse(txtId.Text);
                Main main = new Main(writtenID);
                int result = 0;
                string writtenPW = txtPw.Text;
                
                string s_writtenID = writtenID.ToString();
                Program.a.S_login(s_writtenID,writtenPW);

                sql.connect_db();
                result = sql.login_confirm(writtenID, writtenPW);
                //여기서는 학번비번보내서 sql처리
                if (result == 1)
                {
                    main.Show();
                    //string filePathToDelete = "C:\\Users\\my\\Desktop\\응\\ScienceLibrary\\DB\\d_info.db";
                  // Program.a.DeleteDBFileInFolder(filePathToDelete);
                    //this.Close();
                }
                else
                {
                    lblIsConfirmed.Text = "입력정보가 올바르지 않습니다.";
                }
            }
            
        }
        
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

        private void btnSeminar_Click(object sender, EventArgs e)
        {
            SeminarRoom seminar = new SeminarRoom();
            seminar.Show();
        }
    }
    
}
