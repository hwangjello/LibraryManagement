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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();


            SQLite sql = new SQLite();
            sql.connect_db();
            sql.insert_seat();
            sql.show_seat();

        }
        public void click_seat(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
