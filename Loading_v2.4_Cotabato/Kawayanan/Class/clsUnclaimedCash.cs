using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;

namespace AlreySolutions.Class
{
    public class clsUnclaimedCash
    {
        private int _loadaccountId;
        private int _userid;
        private string _smartmoney;
        private string _refnum;
        private double _amount;
        private DateTime _Timestamp;

        public int UserId
        {
            get { return _userid; }
            set { _userid = value; }
        }
        public string SmartMoney
        {
            get { return _smartmoney; }
            set { _smartmoney = value; }
        }
        public string RefNum
        {
            get { return _refnum; }
            set { _refnum = value; }
        }
        public DateTime Timestamp
        {
            get { return _Timestamp; }
            set { _Timestamp = value; }
        }

        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public int LoadAccountId
        {
            get { return _loadaccountId; }
            set { _loadaccountId = value; }
        }

        public bool Save()
        {
            dbConnect con = new dbConnect();
            bool ret = con.SaveUnclaimedCash(this);
            con.Close();
            return ret;
        }

        public static bool ClaimCash(string refnum)
        {
            dbConnect con = new dbConnect();
            bool ret = con.ClaimCash(refnum);
            con.Close();
            return ret;

        }

        public static List<clsUnclaimedCash> GetUnclaimedCash(int loadid)
        {
            dbConnect con = new dbConnect();
            List<clsUnclaimedCash> ret = null;
            try
            {
                ret = con.GetUnclaimedCash(loadid);
            }
            catch { }
            con.Close();
            return ret;
        }
        public static clsUnclaimedCash GetUnclaimedCash(string refnum,int accountid)
        {
            dbConnect con = new dbConnect();
            clsUnclaimedCash ret = null;
            try
            {
                ret = con.GetUnclaimedCash(refnum, accountid);
            }
            catch { }
            con.Close();
            return ret;
        }

        public static double TotalUnclaimedCash(int accountid)
        {
            dbConnect con = new dbConnect();
            double ret = 0;
            try
            {
                ret = con.TotalUnclaimedCash(accountid);
            }
            catch { }
            con.Close();
            return ret;
        }
    }
}
