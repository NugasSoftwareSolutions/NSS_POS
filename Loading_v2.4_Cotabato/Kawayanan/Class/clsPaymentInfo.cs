using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlreySolutions.Class
{
    public class clsPaymentInfo
    {
        public int PaymentId;
        public int AccountId;
        public string AccountName;
        public int OrNum;
        public double AmountPaid;
        public DateTime Timestamp;
        public int UserId;
        public string UserName;
        public string Remarks;

        public clsPaymentInfo()
        {

        }

        public string Save()
        {
            dbConnect con = new dbConnect();
            string ret = "";
            try
            {
                ret = con.SavePayment(this);
            }
            catch { }
            con.Close();
            return ret;
        }
        public static bool CancelPayment(int payref)
        {
            dbConnect con = new dbConnect();
            bool ret = false;
            try
            {
                ret = con.CancelPayment(payref);
            }
            catch { }
            con.Close();
            return ret;
        }
        public static clsPaymentInfo GetPayment(int payref)
        {
            dbConnect con = new dbConnect();
            clsPaymentInfo ret = null;
            try
            {
                ret = con.GetPayment(payref);
            }
            catch { }
            con.Close();
            return ret;
        }
        public static List<clsPaymentInfo> GetPaymentInfo(int ORNum)
        {
            dbConnect con = new dbConnect();
            List<clsPaymentInfo> ret = null;
            try
            {
                ret = con.GetPaymentInfo(ORNum);
            }
            catch { }
            con.Close();
            return ret;
        }

        public static List<clsPaymentInfo> GetPaymentsInfo(int accountid)
        {
            dbConnect con = new dbConnect();
            List<clsPaymentInfo> ret = null;
            try
            {
                ret = con.GetPaymentsInfo(accountid);
            }
            catch { }
            con.Close();
            return ret;
        }

        public static List<clsPaymentInfo> GetPaymentsInfoFromDate( DateTime startdate, DateTime enddate, string cashier)
        {
            dbConnect con = new dbConnect();
            List<clsPaymentInfo> ret = null;
            try
            {
                ret = con.GetPaymentsInfoFromDate(startdate,enddate,cashier);
            }
            catch { }
            con.Close();
            return ret;
        }

        public static double GetTotalPaymentsInfoFromDate(DateTime startdate, DateTime enddate, string cashier)
        {
            dbConnect con = new dbConnect();
            double ret = 0;
            try
            {
                ret = con.GetTotalPaymentsInfoFromDate(startdate, enddate, cashier);
            }
            catch { }
            con.Close();
            return ret;
        }
    }
}
