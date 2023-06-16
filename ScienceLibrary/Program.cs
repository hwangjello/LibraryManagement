using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Science_Library.DB;
using Client_Code;

namespace Science_Library
{
    internal static class Program
    {
        public static Client a;
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SQLite sql = new SQLite();
           

            a = new Client();
            //string savePath = "C:\\Users\\my\\Desktop\\응\\ScienceLibrary\\DB\\d_info.db"; // DB 파일을 저장할 경로와 파일명
            //a.ReceiveDBFile(savePath);
            a.Run();
            
            
            
            
            

            sql.connect_db();
            
            sql.disconnect_db();
            Application.Run(new Login());
        }
    }
}
