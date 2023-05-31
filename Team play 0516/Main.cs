using Science_Library.DB;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;


namespace Science_Library
{
    public partial class Main : Form
    {
        SQLite sql = new SQLite();
        private int my_id = 2018603036;  //서버 연결하면 로그인 시 자동 입력받게 할 것
        private int my_seat = 0;  //내 좌석의 번호
        private bool my = false; //내가 좌석을 쓰고 있는지 아닌지 
        Button clickedBtn; 
        //private Dictionary<int, int> seat; 소켓으로 불러오면 사용하자
        private Dictionary<int, int> seat = new Dictionary<int, int>(); // 좌석번호, ID

        
        public Main()
        {
            InitializeComponent();
            sql.connect_db();
            for (int i=1; i<65; i++)
            {
                string buttonname = "btnSeat" + i;
                Button btn = Controls.Find(buttonname, true).FirstOrDefault() as Button;
                if(btn != null)
                {
                    set_seat(i, btn);
                }
            }
            //seat = sql.get_seat();
            for (int i=1; i<65; i++)   //임의로 0으로 초기화함
            {
                seat.Add(i, 0);
            }

        }
        public void click_seat(object sender, EventArgs e)
        {
            Button clickedBtn = sender as Button;

            if (clickedBtn != null)
            {
                if (my == false)
                {
                    btnRequest.Enabled = true;

                    int tmp_seatNum = int.Parse(clickedBtn.Text);
                    my_seat = tmp_seatNum;
                }
                else
                {
                    //MessageBox.Show("메시지 내용입니다.", "메시지 제목", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnRequest.Enabled = false;
                    MessageBox.Show("이미 예약한 좌석이 있습니다", "좌석 중복 예약", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        public void set_seat(int s_num, Button seat_number)
        {
            if (seat.ContainsKey(s_num))
            {
                if (seat[s_num] != 0)
                {
                    seat_number.Enabled = false;
                }
                else
                {
                    seat_number.Enabled = true;
                }
            }
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            DateTime nowTime = DateTime.Now;
            int res_when = sql.dtToint(nowTime);
            if (my == false)
            {
                string cmd_context = "UPDATE seat SET ID=" + my_id.ToString() + ", res_when=" +
                    res_when.ToString() +", res_time = 2"+ " WHERE seat_number=" + my_seat.ToString(); //좌석 예약 시 db에 학번, 예약시각, 연장 잔여횟수 입력 들어감.
                sql.update_seat(cmd_context);
                my = true; set_info(); btnRequest.Enabled = false;
                seat[my_seat] = my_id;
             
            }
            else
            {
                btnRequest.Enabled = false;
                MessageBox.Show("이미 예약한 좌석이 있습니다", "좌석 중복 예약", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnProlong_Click(object sender, EventArgs e)
        {
            int seatNumber = seat[my_id];
            DateTime nowTime = DateTime.Now;
            DateTime res_when = sql.seat_reswhen(seatNumber);
            TimeSpan twohours = TimeSpan.FromHours(2);
            DateTime canPro = res_when.Add(twohours); // 연장 가능한 시각(2시간 뒤)
            int res_time = sql.seat_restime(seatNumber);
            if ((nowTime > canPro) && (seat[seatNumber]==my_id)&&(res_time !=0))
            {
                string cmd_context = "UPDATE seat SET res_time="+(res_time-1).ToString()+ 
                    ", res_when ="+nowTime.Add(TimeSpan.FromHours(3))+
                    "WHERE ID="+my_id.ToString()+", seat_number="+my_seat.ToString();
                sql.update_seat(cmd_context);
            }
            else
            {
                MessageBox.Show("연장이 불가합니다.");
            }

        }

        private void btnReturn_Click(object sender, EventArgs e)  
        {
            if (my == true)
            {
                string cmd_context = "UPDATE seat SET ID=0 WHERE seat_number=" + my_seat.ToString();
                sql.update_seat(cmd_context);

                my = false; my_seat = 0; set_info(); btnRequest.Enabled = false;
            }
            else
            {
                btnRequest.Enabled = false;
                MessageBox.Show("예약한 좌석이 없습니다", "좌석 반납 불가", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void set_info()
        {
            if (my == false)
            {
                txtMySeat.Text = "좌석을 예약하세요";
                btnRequest.Enabled = true; btnProlong.Enabled = false; btnReturn.Enabled = false;
            }
            else
            {
                DateTime rest = DateTime.Now;
                DateTime futureTime = rest.AddHours(3);
                DateTime proTime = rest.AddHours(2);
                txtMySeat.Text = "좌석 번호 : " + my_seat.ToString() + "\r\n사용시간 : "+ futureTime.ToString("yyyy-MM-dd HH:mm:ss")+" 까지"+
                "\r\n연장가능시간 : " + proTime.ToString("yyyy-MM-dd HH:mm:ss");
                btnRequest.Enabled = false; btnProlong.Enabled = true; btnReturn.Enabled = true;
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e) //잘 못 누름
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }
        
    }
}
