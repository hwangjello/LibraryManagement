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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void statusBtn_Click(object sender, EventArgs e)
        {
            Admin_Status admin_stat = new Admin_Status();

            admin_stat.Show();
        }

        private void memListBtn_Click(object sender, EventArgs e)
        {
            MemberList memList =new MemberList();
            memList.Show();
        }
    }
}
