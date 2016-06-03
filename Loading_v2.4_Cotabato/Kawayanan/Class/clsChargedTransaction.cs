using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlreySolutions.Class
{
    public class clsChargedTransaction
    {
        public int ChargeID;
        public int AccountId;
        public string AccountName;
        public int ORNum;
        public double ChargedAmount;
        public double TransAmount;
        public int User_Id;
        public DateTime Timestamp;
        public double PrevBalance;
        public double CurrBalance;
        public double TransBalance;
        public double Interest;
        public DateTime InterestPayment;

        public bool SaveChargeTransaction()
        {
            dbConnect con = new dbConnect();
            bool ret = con.SaveChargedTransaction(this);
            con.Close();
            return ret;
        }
        public static clsChargedTransaction GetChargedTransaction(int ornum)
        {
            dbConnect con = new dbConnect();
            clsChargedTransaction trans = con.GetChargedTransaction(ornum);
            con.Close();
            return trans;
        }

        public static List<clsChargedTransaction> GetChargedTransactions(int accountid)
        {
            dbConnect con = new dbConnect();
            List<clsChargedTransaction> trans = null;
            try
            {
                trans = con.GetChargedTransactions(accountid);
            }
            catch { }
            con.Close();
            return trans;
        }
        public static double GetYTDTransactions( int accountid )
        {
            dbConnect con = new dbConnect();
            double ytdtrans = 0;
            try
            {
                ytdtrans = con.GetYTDTransactions(accountid);
            }
            catch { }
            con.Close();
            return ytdtrans;
        }
        public static double GetPrincipalAmount(int accountid)
        {
            dbConnect con = new dbConnect();
            double principal = 0;
            try
            {
                principal = con.GetPrincipalAmount(accountid);
            }
            catch { }
            con.Close();
            return principal;
        }
        public static double GetTotalInterest(int accountid)
        {
            dbConnect con = new dbConnect();
            double interest = 0;
            try
            {
                interest = con.GetTotalInterest(accountid);
            }
            catch { }
            con.Close();
            return interest;
        }        
        public static List<clsChargedTransaction> GetUnPaidChargedTransactions(int accountid)
        {
            dbConnect con = new dbConnect();
            List<clsChargedTransaction> trans = null;
            try
            {
                trans = con.GetUnPaidChargedTransactions(accountid);
            }
            catch { }
            con.Close();
            return trans;
        }    
    }
}
