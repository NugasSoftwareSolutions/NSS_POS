using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlreySolutions.Class
{
    public class clsChargedLoadTrans
    {
        public int ChargeID;
        public int LoadId;
        public int Id_SubDAccount;
        public int LoadWalletTransId;
        public double ChargedAmount;
        public int User_Id;
        public double PrevBalance;
        public double CurrBalance;
        public double TransAmount;
        public double TransBalance;
        public DateTime Timestamp;

        public bool SaveChargeTransaction()
        {
            dbConnect con = new dbConnect();
            bool ret = con.SaveChargedLoadTransaction(this);
            con.Close();
            return ret;
        }
        public static clsChargedLoadTrans GetChargedTransaction(int loadwallettransid)
        {
            dbConnect con = new dbConnect();
            clsChargedLoadTrans trans = con.GetChargedLoadTransaction(loadwallettransid);
            con.Close();
            return trans;
        }

        public static List<clsChargedLoadTrans> GetChargedTransactions(int id_subdaccount)
        {
            dbConnect con = new dbConnect();
            List<clsChargedLoadTrans> trans = null;
            try
            {
                trans = con.GetChargedLoadTransactions(id_subdaccount);
            }
            catch { }
            con.Close();
            return trans;
        }

        public static List<clsChargedLoadTrans> GetUnPaidChargedTransactions(int id_subdaccount)
        {
            dbConnect con = new dbConnect();
            List<clsChargedLoadTrans> trans = null;
            try
            {
                trans = con.GetUnPaidChargedLoadTransactions(id_subdaccount);
            }
            catch { }
            con.Close();
            return trans;
        }    
    }
}
