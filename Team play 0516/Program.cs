using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Science_Library.DB;

namespace Science_Library
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SQLite sql = new SQLite();
            sql.connect_db();
            sql.show_seat();
            sql.disconnect_db();
            Application.Run(new Login());
        }
    }
}
