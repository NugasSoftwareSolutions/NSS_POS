using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlreySolutions.Class.Load
{
    public class clsLoadWalletTransaction
    {
        private int _LoadwalletTransId;

        public int LoadwalletTransId
        {
            get { return _LoadwalletTransId; }
            set { _LoadwalletTransId = value; }
        }
        private int _LoadId;

        public int Load_Id
        {
            get { return _LoadId; }
            set { _LoadId = value; }
        }

        private string _LoadDescription;

        public string LoadDescription
        {
            get { return _LoadDescription; }
            set { _LoadDescription = value; }
        }

        private double _LoadAmount;

        public double LoadAmount
        {
            get { return _LoadAmount; }
            set { _LoadAmount = value; }
        }

        private string _MobileNum;

        public string MobileNum
        {
            get { return _MobileNum; }
            set { _MobileNum = value; }
        }

        private double _DiscountPercentage;

        public double DiscountPercentage
        {
            get { return _DiscountPercentage; }
            set { _DiscountPercentage = value; }
        }

        private double _TransactionAmount;

        public double AmtDue
        {
            get { return _TransactionAmount; }
            set { _TransactionAmount = value; }
        }
        private int _UserId;

        public int UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        private int _SubDId;

        public int SubDId
        {
            get { return _SubDId; }
            set { _SubDId = value; }
        }

        private string _Username;

        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        private string _Remarks;

        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }

        private DateTime _Timestamp;

        public DateTime Timestamp
        {
            get { return _Timestamp; }
            set { _Timestamp = value; }
        }

        private double _TenderedAmount;

        public double TenderedAmount
        {
            get { return _TenderedAmount; }
            set { _TenderedAmount = value; }
        }


        public bool Save()
        {
            dbConnect con = new dbConnect();
            bool ret = false;
            try
            {
                int id = this.LoadwalletTransId;
                ret = con.SaveLoadWallet(this, ref id);
                this.LoadwalletTransId = id;
                if (ret)
                {
                    clsLoadAccount load = clsLoadAccount.GetLoadAccount(this.Load_Id);
                    if (load != null)
                    {
                        clsReloadHistory reload = new clsReloadHistory();
                        reload.Load_Id = this.Load_Id;
                        reload.Timestamp = DateTime.Now;
                        reload.UserId = this.UserId;
                        reload.EcashTransId = this.LoadwalletTransId;
                        reload.Amount = -this.LoadAmount;
                        reload.TransactionAmount = this.AmtDue;
                        
                        reload.RemainingBalance = dbConnect.GetRemainingLoadBalance(this.Load_Id) + reload.Amount;
                        reload.Save();                       

                        load.CurrentBalance = dbConnect.GetRemainingLoadBalance(this.Load_Id);
                        load.AvailableBalance = load.CurrentBalance;
                        load.Save();
                    }

                }
            }
            catch { }
            con.Close();
            return ret;
        }

        public static List<clsLoadWalletTransaction> GetLoadWalletTransactionsReport(DateTime dateStart, DateTime dateEnd, int userid, int loadid)
        {
            dbConnect con = new dbConnect();
            List<clsLoadWalletTransaction> ret = new List<clsLoadWalletTransaction>();
            try
            {
                ret = con.GetLoadWalletTransactionsReport(dateStart, dateEnd, userid, loadid);
            }
            catch { }
            con.Close();
            return ret;
        }

        public void PrintReceipt()
        {
            string ret = "";
            Receipt or = new Receipt();
            or.InitializePrinter();
            List<string> strmsg = new List<string>();
            ret += or.PrintCompanyHeader();
            strmsg.Add("");
            strmsg.Add("LOAD WALLET");
            ret += or.PrintAppend(strmsg, PrintFontAlignment.Center, PrintFontSize.Bold);
            strmsg.Clear();

            strmsg.Add(string.Format("Cashier: {0}", myPosWide.m_user.UserName.ToUpper()));
            strmsg.Add(string.Format("Date: {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            strmsg.Add(string.Format("ReloadId: {0}", LoadwalletTransId));
            strmsg.Add("");
            strmsg.Add(string.Format("Mobile Number: {0}", MobileNum));
            strmsg.Add(string.Format("Reload Amount: P {0:0.00}", LoadAmount));
            strmsg.Add(string.Format("Discount: P {0:0.00}", LoadAmount - AmtDue));
            strmsg.Add(string.Format("Tendered Amount: P {0:0.00}", TenderedAmount));
            strmsg.Add(string.Format("Change: P {0:0.00}", TenderedAmount - AmtDue));
            strmsg.Add("");
            strmsg.Add("");

            ret += or.PrintAppend(strmsg,PrintFontAlignment.Left, PrintFontSize.Regular);
            or.FormFeed();
            or.OpenDrawer();
            or.ExecPrint(ret);
            strmsg.Clear();
        }
    }
}
