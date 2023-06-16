using Science_Library.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Science_Library
{
    public partial class Main : Form
    {
        private List<int> seats=new List<int>();
        private Dictionary<int, int> seat_info=new Dictionary<int, int>();
        private Dictionary<int, int> return_info = new Dictionary<int, int>();
        int user_id = 0;
        int isRequested;
        string btnName;
        Button btnClickedNum = null;
        DateTime nowTime = DateTime.Now;
        int hour;
        int minute;
        int now_hour;
        int now_min;

        public Main(int value)
        {

            InitializeComponent();
            user_id = value;
            lblUserID.Text= "학번 : "+value.ToString();
            SQLite sql = new SQLite();
            sql.connect_db();
            //sql.insert_seat();
            //sql.show_seat();
            int isBooked = sql.seat_confirm(user_id);
            if (isBooked == 0)
            {
                panel1.Enabled = false;
                btnRequest.Enabled = false;
                seat_info = sql.show_seat(user_id);
                return_info=sql.show_returnTime(user_id);
                foreach (var mem in seat_info)
                {
                    txtUserInfo.Text = "좌석 번호 : " + mem.Key + ", 학번 : " + mem.Value;
                }
                foreach (var time in return_info)
                {
                    txtUserInfo.Text = txtUserInfo.Text+ ", 반납시간 : " + time.Key + ":" + time.Value ;
                }
            }
            else
            {
                panel1.Enabled= true;
                //panel1()
            }

        }
        public void click_seat(object sender, EventArgs e)
        {
            Button clickedBtn = (Button)sender;
            seats.Add(clickedBtn.TabIndex);
            btnClickedNum = (Button)clickedBtn;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        
        private void btnRequest_Click(object sender, EventArgs e)
        {
            SQLite sql = new SQLite();
            sql.connect_db();
            //int seat_num = seats.IndexOf(seats.Last());
            int seat_num = seats.Last();
            int seat_user_id = user_id;
            string s_num = seat_num.ToString();
            Program.a.S_num(s_num);
            hour = nowTime.Hour;
            minute = nowTime.Minute;
            int returnhour;
            string returnminute;
            if (hour > 14)
            {
                returnhour = 22;
                returnminute = "00";
            }
            else
            {
                returnhour = hour + 8;
                returnminute = minute.ToString();
            }
            
            int intReturnMin =Convert.ToInt32(returnminute);
            now_hour = returnhour;
            now_min = intReturnMin;
            sql.insert_seat(seat_num, seat_user_id,returnhour,intReturnMin);
            //btnClickedNum.Enabled = false;
            panel1.Enabled = false;
            btnRequest.Enabled = false;
            seat_info = sql.show_seat(seat_user_id);
            return_info = sql.show_returnTime(seat_user_id);
            foreach (var mem in seat_info)
            {
                txtUserInfo.Text = "좌석 번호 : " + mem.Key + ", 학번 : " + mem.Value;
            }
            foreach (var time in return_info)
            {
                txtUserInfo.Text = txtUserInfo.Text + ", 반납시간 : " + time.Key + ":" + time.Value;
            }
            MessageBox.Show("좌석 예약이 완료되었습니다.");
        }
        

        private void btnProlong_Click(object sender, EventArgs e)
        {
            SQLite sql = new SQLite();
            sql.connect_db();
            int user_hour;
            int user_min;
            seat_info = sql.show_seat(user_id);
            return_info = sql.show_returnTime(user_id);
            foreach (var mem in seat_info)
            {
                txtUserInfo.Text = "좌석 번호 : " + mem.Key + ", 학번 : " + mem.Value;
            }
            foreach (var time in return_info)
            {
                user_hour = time.Key;
                user_min = time.Value;
                txtUserInfo.Text = txtUserInfo.Text + ", 반납시간 : " + time.Key + ":" + time.Value ;
                
            }
            sql.time_prolong(user_id,now_hour,now_min);



        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            SQLite sql = new SQLite();
            sql.connect_db();
            int my_seat = sql.get_seat(user_id);
            sql.return_seat(my_seat);
            panel1.Enabled = true;
            btnRequest.Enabled = true;
            txtUserInfo.Text = "";
            MessageBox.Show("좌석 반납이 완료되었습니다.");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
