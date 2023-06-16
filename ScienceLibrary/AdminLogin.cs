using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Science_Library
{
    public partial class AdminLogin : Form
    {
        private string adminId = "admin";
        private string adminPwd = "1111";

        public AdminLogin()
        {
            InitializeComponent();
        }

        private async void btnAdminLogin_Click(object sender, EventArgs e)
        {
            Admin adminForm = new Admin();
            MemberList memList=new MemberList();
            string aid = txtAdminId.Text;
            string apw = txtAdminPw.Text;
            //Program.a.S_login(aid, apw);
            //string receivedData = await Program.a.ReceiveStringFromServer();
            if (aid == adminId && apw==adminPwd)
            {
                memList.Show();
                this.Close();
            }
            else
            {
                lblAdminStatus.Text = "입력정보가 틀렸습니다.";
            }
        }
    }
}
