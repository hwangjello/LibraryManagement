using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Reflection; //Assembly
using System.IO;

namespace Science_Library.DB
{
    public class SQLite
    {
        private SQLiteConnection con;
        private Dictionary<int, int> seat;
        

        public void connect_db()
        {
            string strConn = @"Data Source=C:\Users\secun\Desktop\응소실\Team play 0516\DB\info.db";
            con = new SQLiteConnection(strConn);
            con.Open();
        }

        public void disconnect_db()
        {
            con.Close();
        }

        public void user_insert(int in_id, string in_name, string in_pw)
        {
            SQLiteCommand cmd = new SQLiteCommand("INSERT INTO users VALUES ('" + in_id.ToString() + "' , '" + in_name + "','"+ in_pw + "')", con);
            cmd.ExecuteNonQuery();
        }
        public void insert_seat()
        {
            for (int i = 1; i < 65; i++)
            {
                SQLiteCommand cmd = new SQLiteCommand("INSERT INTO seat VALUES ('" + i.ToString() + "' , '20186030" + i.ToString()+"')", con);
                cmd.ExecuteNonQuery();
            }

        }

        public void return_seat(int seat_number)
        {
            SQLiteCommand cmd = con.CreateCommand();
            cmd.Connection = con;

            cmd.CommandText = "UPDATE seat SET ID = 0 WHERE seat_number = "+seat_number.ToString()+"; COMMIT;";
        }
        public void show_seat()
        {
            SQLiteCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM seat";

            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int seat_number = Convert.ToInt32(reader[0]);
                int ID = Convert.ToInt32(reader[1]);
                Console.WriteLine("Seat Number : {0}, ID : {1}", seat_number, ID);
            }
        }
        public Dictionary<int, int> get_seat()
        {
            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM seat", con);

            SQLiteDataReader reader = cmd.ExecuteReader();
            Dictionary<int, int> seat = new Dictionary<int, int>();
            while (reader.Read())
            {
                int seat_number = Convert.ToInt32(reader[0]);
                int ID = Convert.ToInt32(reader[1]);
                seat.Add(seat_number, ID);
            }
            return seat;
        }
        public void update_seat(string update_seat)
        {
            using (SQLiteCommand command = new SQLiteCommand(update_seat, con))
            {
                command.ExecuteNonQuery();
            }
            
            
        }
        public int seat_numinfo(int seat_num)         // 좌석번호를 넣으면 ID 출력
        {
            int ID = -1;
            SQLiteCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT ID FROM seat WHERE seat_number="+seat_num.ToString ();
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ID = Convert.ToInt32(reader[1]);
                
            }
            return ID;
        }
        public int seat_IDinfo(int ID)   // ID를 넣으면 좌석번호 출력
        {
            int seat_num = -1;
            SQLiteCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT seat_number FROM seat WHERE ID=" + ID.ToString();
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                seat_num = Convert.ToInt32(reader[0]);
                
            }
            return seat_num;
        }
        public int seat_restime(int seat_num)         // 좌석번호를 넣으면 연장 잔여횟수 출력
        {
            int res_time = -1;
            SQLiteCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT res_time FROM seat WHERE seat_number=" + seat_num.ToString();
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                res_time = Convert.ToInt32(reader[2]);

            }
            return res_time;
        }
        public DateTime seat_reswhen(int seat_num)         // 좌석번호를 넣으면 예약한 시각 출력
        {
            int num = -1;
            DateTime res_when = new DateTime();
            SQLiteCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT res_when FROM seat WHERE seat_number =" + seat_num.ToString();
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                num = Convert.ToInt32(reader[3]);

            }
            res_when = DateTime.FromBinary(num);
            return res_when;
        }
        public int dtToint(DateTime date)   //db에 예약시각 저장 시 DateTime을 int로 바꿔서 저장해야 해서 바뀌주는 함수
        {
            int intValue = (int)date.Ticks;
            return intValue;
        }
        public DateTime intTodt (int res_when)  //db에서 에약시간 불러올 때 int를 DateTime으로 바꿔주는 함수
        {
            DateTime dtValue = DateTime.FromBinary (res_when);
            return dtValue;
        }
    }
}
