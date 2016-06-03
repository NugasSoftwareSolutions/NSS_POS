using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlreySolutions.Class.Load
{
    public class clsReloadHistory
    {
        private int reloadid;

        public int ReloadId
        {
            get { return reloadid; }
            set { reloadid = value; }
        }
        private int userid;

        public int UserId
        {
            get { return userid; }
            set { userid = value; }
        }
        private string username;

        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        private int load_id;

        public int Load_Id
        {
            get { return load_id; }
            set { load_id = value; }
        }
        private string refnum;

        public string RefNum
        {
            get { return refnum; }
            set { refnum = value; }
        }
        private double amount;

        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        private DateTime timestamp;

        public DateTime Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }

        private string _Remarks;

        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }
        private int _EcashTransId;

        public int EcashTransId
        {
            get { return _EcashTransId; }
            set { _EcashTransId = value; }
        }

        private double _RemainingBalance;

        public double RemainingBalance
        {
            get { return _RemainingBalance; }
            set { _RemainingBalance = value; }
        }

        private double _TransactionAmount;

        public double TransactionAmount
        {
            get { return _TransactionAmount; }
            set { _TransactionAmount = value; }
        }
        private int _ReloadType;

        public int ReloadType
        {
            get { return _ReloadType; }
            set { _ReloadType = value; }
        }

        public bool Save()
        {
            dbConnect con = new dbConnect();
            bool ret = false;
            try
            {
                ret = con.SaveReLoadHistory(this);
            }
            catch { }
            con.Close();
            return ret;
        }

        public static List<clsReloadHistory> GetReloadHistory(int loadid =0)
        {
            dbConnect con = new dbConnect();
            List<clsReloadHistory> ret = null;
            try
            {
                ret = con.GetReLoadHistory(loadid);
            }
            catch { }
            con.Close();
            return ret;
        }
        public static List<clsReloadHistory> GetReLoadHistoryReport(DateTime dateStart, DateTime dateEnd, int userid, int loadid)
        {
            dbConnect con = new dbConnect();
            List<clsReloadHistory> ret = new List<clsReloadHistory>();
            try
            {
                ret = con.GetReLoadHistoryReport(dateStart, dateEnd, userid, loadid);
            }
            catch { }
            con.Close();
            return ret;
        }
        public static double GetLoadingStationTotalCashIn(DateTime startdate, DateTime enddate, int cashier)
        {
            dbConnect con = new dbConnect();
            double ret = 0;
            try
            {
                ret = con.GetLoadingStationTotalCashIn(startdate, enddate, cashier);
            }
            catch { }
            return ret;
        }
        public static double GetLoadingStationTotalCashOut(DateTime startdate, DateTime enddate, int cashier)
        {
            dbConnect con = new dbConnect();
            double ret = 0;
            try
            {
                ret = con.GetLoadingStationTotalCashOut(startdate, enddate, cashier);
            }
            catch { }
            return ret;
        }

        public void PrintReceipt(clsLoadAccount acc)
        {
            string ret = "";
            Receipt or = new Receipt();
            or.InitializePrinter();
            List<string> strmsg = new List<string>();
            strmsg.Add(Remarks);
            ret = or.PrintAppend(strmsg, PrintFontAlignment.Center, PrintFontSize.Bold);
            strmsg.Clear();

            strmsg.Add(string.Format("Cashier: {0}", myPosWide.m_user.UserName.ToUpper()));
            strmsg.Add(string.Format("Date: {0}", Timestamp));
            strmsg.Add(string.Format("RefNum: {0}",RefNum));
            strmsg.Add("");

            strmsg.Add(string.Format("Load Account Name: {0}", acc.Description));
            strmsg.Add(string.Format("Previous Balance: P {0:0.00}", acc.AvailableBalance + Amount));
            strmsg.Add(string.Format("Amount: P {0:0.00}", Amount));
            strmsg.Add(string.Format("Available Balance: P {0:0.00}", acc.AvailableBalance));
            strmsg.Add("");
            strmsg.Add("");
            ret = or.PrintAppend(strmsg, PrintFontAlignment.Left, PrintFontSize.Regular);
            or.FormFeed();
            or.OpenDrawer();
            or.ExecPrint(ret);
            strmsg.Clear();
        }
    }

    public enum ReloadType
    {
        REBATE = 1
    }
}
