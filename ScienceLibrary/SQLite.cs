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
        

        public void insert_seat()
        {
            //SQLiteCommand cmd = new SQLiteCommand("INSERT INTO seat VALUES ('" + i.ToString() + "' , '20196030" + i.ToString()+"')", con);
            //cmd.ExecuteNonQuery();
            

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

    }
}
