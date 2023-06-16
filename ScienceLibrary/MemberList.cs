using Science_Library.DB;
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
    public partial class MemberList : Form
    {
        MemberData dataset;
        public MemberList()
        {

            SQLite sql = new SQLite();
            sql.connect_db();

            InitializeComponent();
            Dictionary<int, string> memberInfo = new Dictionary<int, string>();
            memberInfo = sql.dicReturn();
            dataset = new MemberData();
            foreach (var mem in memberInfo)
            {
                dataset.Tables["Member"].Rows.Add(new object[] { mem.Key, mem.Value });
            }
            dgvMember.DataSource = dataset.Tables["Member"];

        }
        //private List<object> SplitString(string data)
        //{
        //    List<string> splitValues = data.Split(',').Select(x => x.Trim()).ToList();
        //    List<object> values = new List<object>();

        //    foreach (string value in splitValues)
        //    {
        //        int intValue;
        //        if (int.TryParse(value, out intValue))
        //            values.Add(intValue);
        //        else
        //            values.Add(value);
        //    }

        //    return values;
        //}


        //private async void LoadMemberDataAsync()
        //{
        //    SQLite sql = new SQLite();
        //    sql.connect_db();

        //    Dictionary<int, string> memberInfo = new Dictionary<int, string>();
        //    memberInfo = sql.dicReturn();
            
        //    while (true)
        //    {
        //        string receivedData = await Program.a.ReceiveStringFromServer();
        //        List<object> values = SplitString(receivedData);

        //        int value1 = (int)values[0];
        //        string value2 = (string)values[1];
        //        memberInfo.Add(value1, value2);
        //        if (Program.a.ProcessReceivedData(receivedData) == false) { break; }
        //    }
            
        //        dataset = new MemberData();
        //        foreach (var mem in memberInfo)
        //        {
        //            dataset.Tables["Member"].Rows.Add(new object[] { mem.Key, mem.Value });
        //        }

        //        dgvMember.DataSource = dataset.Tables["Member"];
            
        //}
        private void btnDelete_Click(object sender, EventArgs e)
        {
            SQLite sql = new SQLite();
            sql.connect_db();

            DataGridViewRow selectedRow = dgvMember.SelectedRows[0];
            string selectedID = selectedRow.Cells[0].Value.ToString();
            
            int rowIndex = dgvMember.SelectedRows[0].Index;

            DataRowView selRow = (DataRowView)dgvMember.Rows[rowIndex].DataBoundItem;

            selRow.Row.Delete();
            sql.user_delete(selectedID);
            MessageBox.Show("회원삭제 성공");
        }
    }
}
