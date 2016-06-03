using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlreySolutions.Class
{
    public class clsUsers
    {
        private string _UserName;
        private string _Password;
        private int _LoginType;
        private bool _Enabled;
        private int _LogInAttempt;
        private int _UserId;

        public int UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public int LoginType
        {
            get { return _LoginType; }
            set { _LoginType = value; }
        }

        public bool Enabled
        {
            get { return _Enabled; }
            set { _Enabled = value; }
        }

        public int LogInAttempt
        {
            get { return _LogInAttempt; }
            set { _LogInAttempt = value; }
        }

        public clsUsers()
        {

        }
        public bool UsernameExists(string username)
        {
            dbConnect con = new dbConnect();
            bool ret =con.UserNameExists(username);
            con.Close();
            return ret;
        }
        public bool Login(string username, string password)
        {
            dbConnect con = new dbConnect();
            clsUsers user = con.Login(username, password);
            con.Close();
            if (user.UserName != "")
            {
                _UserId = user.UserId;
                _UserName = user.UserName;
                _Password = user.Password;
                _LoginType = user.LoginType;
                _Enabled = user.Enabled;
                _LogInAttempt = user.LogInAttempt;
                if (_Enabled) return true;
            }
            return false;
        }
        public static List<string> GetUserList()
        {
            dbConnect con = new dbConnect();
            List<string> ret = con.GetUser();
            con.Close();
            return ret;
        }
        public static List<clsUsers> GetUsers()
        {
            dbConnect con = new dbConnect();
            List<clsUsers> ret = con.GetUsers();
            con.Close();
            return ret;
        }

        public static clsUsers GetUser(string username)
        {
            dbConnect con = new dbConnect();
            List<clsUsers> ret = con.GetUsers();
            con.Close();
            foreach (clsUsers user in ret)
            {
                if (user.UserName == username)
                    return user;
            }
            return null;
        }

        public bool Save()
        {
            dbConnect con = new dbConnect();
            bool ret =con.SaveUser(this);
            con.Close();
            return ret;
        }
    }
}
