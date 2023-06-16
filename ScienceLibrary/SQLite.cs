using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Reflection; //Assembly
using System.IO;
using System.Windows.Forms.Design;
using System.Windows.Forms;

namespace Science_Library.DB
{
    public class SQLite
    {
        private SQLiteConnection con;
        private Dictionary<int, int> seat;
        

        public void connect_db()
        {
            string strConn = @"Data Source=C:\Users\jmhwa\LibraryManagement\ScienceLibrary\DB\info.db";
            con = new SQLiteConnection(strConn);
            con.Open();
        }

        public void disconnect_db()
        {
            con.Close();
        }
        public Dictionary<int,string> dicReturn()
        {
            string query = "SELECT ID,name FROM users";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataReader reader = cmd.ExecuteReader();

            Dictionary<int, string> info = new Dictionary<int, string>();

            while (reader.Read())
            {
                // 행의 값을 가져와서 처리
                int key = Convert.ToInt32(reader["ID"]);
                string value = reader["name"].ToString();

                // 벡터 사전에 추가
                info.Add(key, value);
            }
            return info;
        }
        public void user_insert(int in_id, string in_name, string in_pw)
        {
            SQLiteCommand cmd = new SQLiteCommand("INSERT INTO users VALUES ('" + in_id.ToString() + "' , '" + in_name + "','"+ in_pw + "')", con);
            cmd.ExecuteNonQuery();
        }
        public void user_delete(string in_id)
        {
            SQLiteCommand cmd = new SQLiteCommand("DELETE FROM users WHERE ID=" + in_id + ";",con);
            cmd.ExecuteNonQuery();
        }
        public int login_confirm(int writtenID, string writtenPW)
        {
            string query = "SELECT ID,password FROM users";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataReader reader = cmd.ExecuteReader();

            Dictionary<int, string> info = new Dictionary<int, string>();

            while (reader.Read())
            {
                // 행의 값을 가져와서 처리
                int key = Convert.ToInt32(reader["ID"]);    
                string value = reader["password"].ToString(); 

                // 벡터 사전에 추가
                info.Add(key, value);
            }
            if (info.ContainsKey(writtenID))
            {
                if (info[writtenID] == writtenPW) return 1;
                else return 0;
            }
            else return 0;
        }
        public int signup_confirm(int InID)
        {
            string query = "SELECT ID FROM users";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataReader reader = cmd.ExecuteReader();

            List<int> info = new List<int>();

            while (reader.Read())
            {
                // 행의 값을 가져와서 처리
                int ID = Convert.ToInt32(reader["ID"]);
                

                // 벡터 사전에 추가
                info.Add(ID);
            }
            if (!info.Contains(InID)) return 1;
            else return 0;
        }

        public void insert_seat(int seat_num,int seat_user_id,int returnhour,int returnminute)
        {
            SQLiteCommand cmd = new SQLiteCommand("INSERT INTO seat VALUES ('" + (seat_num+1).ToString() + "' , '" + seat_user_id.ToString() + "' , '" + returnhour.ToString()+"' , '" + returnminute.ToString()+ "')", con);
            cmd.ExecuteNonQuery();


        }
        public void time_prolong(int user_id, int user_hour, int user_min)
        {
            int max_time = 22;
            if (user_hour >= 18)
            {
                SQLiteCommand cmd = new SQLiteCommand("UPDATE seat SET hour =" + max_time.ToString() + " WHERE ID = " + user_id.ToString() + ";", con);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("좌석 예약 시간 연장이 완료되었습니다.");
            }
            else
            {
                SQLiteCommand cmd = new SQLiteCommand("UPDATE seat SET hour =" + (user_hour+4).ToString() + " WHERE ID = " + user_id.ToString() + ";", con);
                cmd.ExecuteNonQuery();
            }
            

        }
        public int get_seat(int user_id)
        {
            string query="SELECT seat_number FROM seat WHERE ID="+user_id.ToString()+";";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataReader reader = cmd.ExecuteReader();
            List<int> my_seat = new List<int>();
            while (reader.Read())
            {
                int count = Convert.ToInt32(reader["seat_number"]);// 행의 값을 가져와서 처리

                my_seat.Add(count);// 벡터 사전에 추가
            }
            return my_seat[0];

        }
        public void return_seat(int seat_number)
        {
            SQLiteCommand cmd = new SQLiteCommand("UPDATE seat SET ID = 0 WHERE seat_number = " + seat_number.ToString() + ";", con);
            cmd.ExecuteNonQuery();

            
        }
        public int seat_confirm(int inID)
        {
            string query = "SELECT count(ID) FROM seat WHERE ID=" + inID.ToString() +";" ;
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataReader reader = cmd.ExecuteReader();

            List<int> count_info = new List<int>();
            while (reader.Read())
            {
                // 행의 값을 가져와서 처리
                int count = Convert.ToInt32(reader["count(ID)"]);


                // 벡터 사전에 추가
                count_info.Add(count);
            }
            if (count_info[0] > 0)
            {
                return 0;
            }
            else return 1;
        }
        public Dictionary<int, int> show_seat(int seat_user_id)
        {
            string query = "SELECT * FROM seat WHERE ID="+seat_user_id+";";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataReader reader = cmd.ExecuteReader();
            Dictionary<int, int> seat_info = new Dictionary<int, int>();


            while (reader.Read())
            {
                int key = Convert.ToInt32(reader["seat_number"]);
                int value = Convert.ToInt32(reader["ID"]);

                seat_info.Add(key, value);
            }

            return seat_info;
            
        }
        public Dictionary<int, int> show_returnTime(int seat_user_id)
        {
            string query = "SELECT * FROM seat WHERE ID=" + seat_user_id + ";";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataReader reader = cmd.ExecuteReader();
            Dictionary<int, int> returnTime_info = new Dictionary<int, int>();


            while (reader.Read())
            {
                int key = Convert.ToInt32(reader["hour"]);
                int value = Convert.ToInt32(reader["minute"]);

                returnTime_info.Add(key, value);
            }

            return returnTime_info;

        }

    }
}
