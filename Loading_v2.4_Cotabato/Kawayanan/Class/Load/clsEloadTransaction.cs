using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlreySolutions.Class.Load
{
    public class clsEloadTransaction
    {
        private int eloadtrans_id;

        public int ELoadTrans_Id
        {
            get { return eloadtrans_id; }
            set { eloadtrans_id = value; }
        }
        private int load_id;

        public int Load_Id
        {
            get { return load_id; }
            set { load_id = value; }
        }
        private double transaction_amount;

        public double Transaction_Amount
        {
            get { return transaction_amount; }
            set { transaction_amount = value; }
        }
        private double amountdue;

        public double AmountDue
        {
            get { return amountdue; }
            set { amountdue = value; }
        }
        private double discount;

        public double Discount
        {
            get { return discount; }
            set { discount = value; }
        }
        private DateTime timestamp;

        public DateTime Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }
        private string refnum;

        public string RefNum
        {
            get { return refnum; }
            set { refnum = value; }
        }
        private string remarks;

        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
        private int accountid;

        public int AccountId
        {
            get { return accountid; }
            set { accountid = value; }
        }
        private int userid;

        public int UserId
        {
            get { return userid; }
            set { userid = value; }
        }
        private string accountName;

        public string AccountName
        {
            get { return accountName; }
            set { accountName = value; }
        }
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string mobilenum;

        public string MobileNum
        {
            get { return mobilenum; }
            set { mobilenum = value; }
        }
        private ELoadStatus eloadstatusid;

        public ELoadStatus ELoadStatusId
        {
            get { return eloadstatusid; }
            set { eloadstatusid = value; }
        }
        private double _TenderedAmount;

        public double TenderedAmount
        {
            get { return _TenderedAmount; }
            set { _TenderedAmount = value; }
        }
        private double _Rebate;

        public double Rebate
        {
            get { return _Rebate; }
            set { _Rebate = value; }
        }
        private string _ELoadName;

        public string ELoadName
        {
            get { return _ELoadName; }
            set { _ELoadName = value; }
        }

        public bool Save()
        {
            dbConnect con = new dbConnect();
            bool ret = false;
            try
            {
                int id = this.ELoadTrans_Id;
                ret = con.SaveELoad(this, ref id);
                this.ELoadTrans_Id = id;
                if (ret)
                {
                    clsLoadAccount load = clsLoadAccount.GetLoadAccount(this.Load_Id);
                    if (load != null)
                    {
                        clsReloadHistory reload = new clsReloadHistory();
                        reload.Load_Id = this.Load_Id;
                        reload.RefNum = this.RefNum;
                        reload.Timestamp = DateTime.Now;
                        reload.UserId = this.userid;
                        reload.EcashTransId = this.ELoadTrans_Id;
                        reload.Amount = -this.Transaction_Amount;
                        reload.TransactionAmount = this.amountdue;
                        
                        reload.RemainingBalance = dbConnect.GetRemainingLoadBalance(this.Load_Id) + reload.Amount;
                        reload.Remarks = string.Format("Eload (Load Account:{0} Amount:{1:0.00} Remaining Balance:{2:0.00})",load.AccountNum,reload.Amount,reload.RemainingBalance) ;
                        reload.Save();

                        reload.Amount = this.Rebate;
                        reload.Remarks = "Rebate";
                        reload.TransactionAmount = 0;
                        reload.RemainingBalance = dbConnect.GetRemainingLoadBalance(this.Load_Id) + reload.Amount;
                        reload.Remarks = string.Format("Rebate (Load Account:{0} Amount:{1:0.00} Remaining Balance:{2:0.00})", load.AccountNum, reload.Amount, reload.RemainingBalance);
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

        public static List<clsEloadTransaction> GetEloadTransactions(int loadid)
        {
            dbConnect con = new dbConnect();
            List<clsEloadTransaction> ret = null;
            try
            {
                ret = con.GetEloadTransactions(loadid);
            }
            catch { }
            con.Close();
            return ret;
        }

        public static List<clsEloadTransaction> GetEloadTransactionsReport(DateTime dateStart, DateTime dateEnd, int userid, int loadid)
        {
            dbConnect con = new dbConnect();
            List<clsEloadTransaction> ret = new List<clsEloadTransaction>();
            try
            {
                ret = con.GetELoadTransactionReport(dateStart, dateEnd, userid, loadid);
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
            strmsg.Add("E-LOAD");
            ret += or.PrintAppend(strmsg, PrintFontAlignment.Center, PrintFontSize.UnderlineBold);
            strmsg.Clear();

            strmsg.Add(string.Format("Cashier: {0}", myPosWide.m_user.UserName.ToUpper()));
            strmsg.Add(string.Format("Date: {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            strmsg.Add(string.Format("ReloadId: {0}", ELoadTrans_Id));
            strmsg.Add("");
            strmsg.Add(string.Format("Mobile Number: {0}", MobileNum));
            strmsg.Add(string.Format("Reload Amount: P {0:0.00}", Transaction_Amount));
            strmsg.Add(string.Format("Amount Due: P {0:0.00}", AmountDue));
            strmsg.Add(string.Format("Tendered Amount: P {0:0.00}", TenderedAmount));
            strmsg.Add(string.Format("Change: P {0:0.00}", TenderedAmount - AmountDue));
            strmsg.Add("");
            strmsg.Add("");
            ret += or.PrintAppend(strmsg, PrintFontAlignment.Left , PrintFontSize.Regular);
            or.FormFeed();
            or.OpenDrawer();
            or.ExecPrint(ret);
            strmsg.Clear();
        }
    }

    public enum ELoadStatus
    {
        PaymentReceived =0 ,
        LoadProcessed =1,
        Cancelled = 2
    }
}
