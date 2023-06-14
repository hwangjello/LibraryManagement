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

        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            Admin adminForm = new Admin();
            if (txtAdminId.Text == adminId && txtAdminPw.Text == adminPwd)
            {
                adminForm.Show();
            }
            else
            {
                lblAdminStatus.Text = "입력정보가 틀렸습니다.";
            }
        }
    }
}
