using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlreySolutions.Class.Load
{
    class clsSmartCashTransaction
    {
        private int _SCashTransId;

        public int SCashTransId
        {
            get { return _SCashTransId; }
            set { _SCashTransId = value; }
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
        private int accountid;

        public int AccountId
        {
            get { return accountid; }
            set { accountid = value; }
        }
        private string accountname;

        public string AccountName
        {
            get { return accountname; }
            set { accountname = value; }
        }
        private int load_id;

        public int Load_Id
        {
            get { return load_id; }
            set { load_id = value; }
        }
        private double transAmount;

        public double TransAmount
        {
            get { return transAmount; }
            set { transAmount = value; }
        }
        private double svcFeeAmount;

        public double SvcFeeAmount
        {
            get { return svcFeeAmount; }
            set { svcFeeAmount = value; }
        }
        private string senderName;

        public string SenderName
        {
            get { return senderName; }
            set { senderName = value; }
        }
        private string senderContact;

        public string SenderContact
        {
            get { return senderContact; }
            set { senderContact = value; }
        }
        private string recipientName;

        public string RecipientName
        {
            get { return recipientName; }
            set { recipientName = value; }
        }
        private string recipientContact;

        public string RecipientContact
        {
            get { return recipientContact; }
            set { recipientContact = value; }
        }
        private string refNum;

        public string RefNum
        {
            get { return refNum; }
            set { refNum = value; }
        }
        private string remarks;

        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }

        private string _RecepientAccNum;

        public string RecepientAccNum
        {
            get { return _RecepientAccNum; }
            set { _RecepientAccNum = value; }
        }

        private string _SenderAccnum;

        public string SenderAccnum
        {
            get { return _SenderAccnum; }
            set { _SenderAccnum = value; }
        }
        private double _Rebate;

        public double Rebate
        {
            get { return _Rebate; }
            set { _Rebate = value; }
        }

        private SCashPaymentMode _PaymentMode;

        public SCashPaymentMode PaymentMode
        {
            get { return _PaymentMode; }
            set { _PaymentMode = value; }
        }

        private SCashTranstype _SCashTransType;

        public SCashTranstype TransType
        {
            get { return _SCashTransType; }
            set { _SCashTransType = value; }
        }
        private DateTime transDate;

        public DateTime TransDate
        {
            get { return transDate; }
            set { transDate = value; }
        }
        private double _TenderedAmount;

        public double TenderedAmount
        {
            get { return _TenderedAmount; }
            set { _TenderedAmount = value; }
        }

        private double _TotalAmtTransfered;

        public double TotalAmtTransfered
        {
            get { return _TotalAmtTransfered; }
            set { _TotalAmtTransfered = value; }
        }

        public bool Save()
        {
            dbConnect con = new dbConnect();
            bool ret = false;
            try
            {
                int id = this.SCashTransId;
                ret = con.SaveSCash(this, ref id);
                this.SCashTransId = id;
                if (ret)
                {
                    clsLoadAccount load = clsLoadAccount.GetLoadAccount(this.Load_Id);
                    if (load != null)
                    {
                        clsReloadHistory reload = new clsReloadHistory();
                        reload.Load_Id = this.Load_Id;
                        reload.RefNum = this.refNum;
                        reload.Timestamp = DateTime.Now;
                        reload.UserId = this.userid;
                        reload.EcashTransId = this.SCashTransId;
                        reload.Remarks = this.Remarks;
                        switch (TransType)
                        {
                            case SCashTranstype.SEND:
                                reload.Amount = Properties.Settings.Default.SmartPadalaSendSvc ? -(this.TransAmount + this.SvcFeeAmount) : -this.TransAmount;
                                reload.RemainingBalance = dbConnect.GetRemainingLoadBalance(this.Load_Id) + reload.Amount;
                                reload.TransactionAmount = (this.TransAmount + this.SvcFeeAmount);
                                reload.Save();

                                if (Properties.Settings.Default.SmartPadalaSendRebate && this.Rebate>0)
                                {
                                    reload.Amount = this.Rebate;
                                    reload.Remarks = "Rebate";
                                    reload.RemainingBalance = dbConnect.GetRemainingLoadBalance(this.Load_Id) + reload.Amount;
                                    reload.TransactionAmount = 0;
                                    reload.ReloadType = (int)ReloadType.REBATE;
                                    reload.Save();
                                }
                                break;
                            case SCashTranstype.ENCASH:

                                reload.Amount = this.TransAmount + this.SvcFeeAmount;
                                reload.RemainingBalance = dbConnect.GetRemainingLoadBalance(this.Load_Id) + reload.Amount;
                                reload.TransactionAmount = -(this.TransAmount - this.SvcFeeAmount);
                                reload.Save();
                                
                                if (Properties.Settings.Default.SmartPadalaIncashRebate && this.Rebate > 0)
                                {
                                    reload.Amount = this.Rebate;
                                    reload.RemainingBalance = dbConnect.GetRemainingLoadBalance(this.Load_Id) + reload.Amount;
                                    reload.Remarks = "Rebate";
                                    reload.TransactionAmount = 0;
                                    reload.ReloadType = (int)ReloadType.REBATE;
                                    reload.Save();
                                }
                                break;                            
                        }
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

        public static List<clsSmartCashTransaction> GetGcashTransactionReport(DateTime dateStart, DateTime dateEnd, int userid, string customer)
        {
            dbConnect con = new dbConnect();
            List<clsSmartCashTransaction> ret = new List<clsSmartCashTransaction>();
            try
            {
                ret = con.GetScashTransactionReport(dateStart, dateEnd, userid, customer);
            }
            catch { }
            con.Close();
            return ret;
        }

        public static string GetTransType(SCashTranstype type)
        {
            switch (type)
            {
                case SCashTranstype.ENCASH:
                    return "Receive Money ";
                case SCashTranstype.SEND:
                    return "Send Money";
                default: return "";
            }
        }
        public static string GetPaymentMode(SCashPaymentMode mode)
        {
            switch (mode)
            {
                case SCashPaymentMode.CASH:
                    return "Cash";
                case SCashPaymentMode.SMARTMONEY:
                    return "Smart Money";
                default :
                    return "";
            }
        }
        public static double GetTransAmount(SCashTranstype type,SCashPaymentMode mode, double amount, double svcfee)
        {
            double ret = 0;
            switch (type)
            {
                case SCashTranstype.SEND:
                    ret = (amount + svcfee);
                    break;
                case SCashTranstype.ENCASH:
                    if (mode == SCashPaymentMode.SMARTMONEY) ret = -(amount);
                    else if (mode == SCashPaymentMode.CASH) ret = -(amount - svcfee);
                    else ret = 0;
                    break;
                default:
                    ret = 0;
                    break;
            }
            return ret;
        }
    }

    public enum SCashTranstype
    {
        SEND = 1,
        ENCASH = 2
    }
     public enum SCashPaymentMode
    {
        SMARTMONEY = 1,
        CASH = 2
    }
}
