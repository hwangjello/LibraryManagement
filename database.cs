using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    internal class database
    {
        String ID;
        String Name;
        String PW;
        

        public bool login(string id, String pw)
        {
            bool check = false;
            try
            {
                String loginId = "SELECT PW FROM user WHERE ID='" + id + "'";
                if (loginId == pw)
                {
                    check = true;
                    return check;
                }
                else
                {
                    return check;
                }
            }
            catch (Exception ex)
            {
                return check;
            }
        }

        public bool idCheck(string id)
        {
            bool check = false;
            try
            {
                string checkId = "SELECT" + id + "FROM user";
                if (checkId == null)
                {
                    check = true;
                    return check;
                }
                else
                {
                    return check;
                }
            }
            catch
            {
                return check;
            }
        }
        public bool pwCheck(string pw)
        {
            bool check = false;
            try
            {
                string checkPw = "SELECT" + pw + "FROM user";
                if (checkPw == null)
                {
                    check = true;
                    return check;
                }
                else
                {
                    return check;
                }
            }
            catch
            {
                return check;
            }
        }
    }
}
