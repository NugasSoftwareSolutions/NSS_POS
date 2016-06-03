using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlreySolutions.Class.Load
{
    public class clsSubDAccount
    {
        private int id_subdAccounts;

        public int Id_subdAccounts
        {
            get { return id_subdAccounts; }
            set { id_subdAccounts = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string mobilenum;

        public string MobileNum
        {
            get { return mobilenum; }
            set { mobilenum = value; }
        }
        private int loadid;

        public int LoadId
        {
            get { return loadid; }
            set { loadid = value; }
        }
        private double balance;

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        private double discount;

        public double Discount
        {
            get { return discount; }
            set { discount = value; }
        }
        public bool Save()
        {
            dbConnect con = new dbConnect();
            bool ret = false;
            try
            {
                ret = con.SaveSubDAccount(this);
            }
            catch { }
            con.Close();
            return ret;
        }
        public bool Delete()
        {
            dbConnect con = new dbConnect();
            bool ret = false;
            try
            {
                ret = con.DeleteSubDAccount(this);
            }
            catch { }
            con.Close();
            return ret;
        }

        public static clsSubDAccount GetSubDAccount(string mobilenum)
        {
            dbConnect con = new dbConnect();
            clsSubDAccount ret = null;
            try
            {
                ret = con.GetSubDAccount(mobilenum);
            }
            catch { }
            con.Close();
            return ret;
        }

        public static List<clsSubDAccount> GetSubDAccounts(int loadid, string searchstr)
        {
            dbConnect con = new dbConnect();
            List<clsSubDAccount> ret = null;
            try
            {
                ret = con.GetSubDAccounts(loadid, searchstr);
            }
            catch { }
            con.Close();
            return ret;
        }
    }
}
