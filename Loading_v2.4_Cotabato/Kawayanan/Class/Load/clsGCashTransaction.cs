using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlreySolutions.Class.Load
{
    public class clsGCashTransaction
    {
        private int gcashtransid;

        public int GCashtTransId
        {
            get { return gcashtransid; }
            set { gcashtransid = value; }
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
        private GCashTransType _transType;

        public GCashTransType TransactionType
        {
            get { return _transType; }
            set { _transType = value; }
        }

        private DateTime transDate;

        public DateTime TransDate
        {
            get { return transDate; }
            set { transDate = value; }
        }
        
        private DateTime dateClaimed;

        public DateTime DateClaimed
        {
            get { return dateClaimed; }
            set { dateClaimed = value; }
        }

        private DateTime dateCancelled;

        public DateTime DateCancelled
        {
            get { return dateCancelled; }
            set { dateCancelled = value; }
        }

        private string _Country;

        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }

        private string _GCashNumber;

        public string GCashNumber
        {
            get { return _GCashNumber; }
            set { _GCashNumber = value; }
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

        public bool Save()
        {
            dbConnect con = new dbConnect();
            bool ret = false;
            try
            {
                int id = this.GCashtTransId;
                ret = con.SaveGCash(this,ref id);
                this.GCashtTransId = id;
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
                        reload.EcashTransId = this.GCashtTransId;
                        reload.Remarks = this.Remarks;
                        switch (TransactionType)
                        {
                            case GCashTransType.CashIn:
                                reload.Amount = Properties.Settings.Default.CashInSvc ? -(this.TransAmount + this.SvcFeeAmount) : -this.TransAmount;
                                reload.RemainingBalance =  dbConnect.GetRemainingLoadBalance(this.Load_Id) + reload.Amount;
                                reload.TransactionAmount = (this.TransAmount + this.SvcFeeAmount);
                                reload.Save();

                                if (Properties.Settings.Default.CashInRebate && this.Rebate>0)
                                {
                                    reload.Amount = this.Rebate;
                                    reload.Remarks = string.Format("Rebate from Refnum:{0}",reload.RefNum);
                                    reload.RemainingBalance = dbConnect.GetRemainingLoadBalance(this.Load_Id) + reload.Amount;
                                    reload.TransactionAmount = 0;
                                    reload.ReloadType = (int)ReloadType.REBATE;
                                    reload.Save();
                                }
                                break;
                            case GCashTransType.SendToOthers:
                                reload.Amount = Properties.Settings.Default.SendToOthersSvc ? -(this.TransAmount + this.SvcFeeAmount) : -this.TransAmount;
                                reload.RemainingBalance = dbConnect.GetRemainingLoadBalance(this.Load_Id) + reload.Amount;
                                reload.TransactionAmount = (this.TransAmount + this.SvcFeeAmount);
                                reload.Save();

                                if (Properties.Settings.Default.SendToOthersRebate && this.Rebate>0)
                                {
                                    reload.Amount = this.Rebate;
                                    reload.RemainingBalance = dbConnect.GetRemainingLoadBalance(this.Load_Id) + reload.Amount;
                                    reload.Remarks = "Rebate";
                                    reload.TransactionAmount = 0;
                                    reload.ReloadType = (int)ReloadType.REBATE;
                                    reload.Save();
                                }
                                break;
                            case GCashTransType.CashOut:
                                reload.Amount = Properties.Settings.Default.CashOutSvc ? (this.TransAmount - this.SvcFeeAmount) : this.TransAmount;
                                reload.RemainingBalance = dbConnect.GetRemainingLoadBalance(this.Load_Id) + reload.Amount;
                                reload.TransactionAmount = -(this.TransAmount - this.SvcFeeAmount);
                                reload.Save();
                                if (Properties.Settings.Default.CashOutRebate && this.Rebate>0)
                                {
                                    reload.Amount = this.Rebate;
                                    reload.RemainingBalance = dbConnect.GetRemainingLoadBalance(this.Load_Id) + reload.Amount;
                                    reload.Remarks = "Rebate";
                                    reload.TransactionAmount = 0;
                                    reload.ReloadType = (int)ReloadType.REBATE;
                                    reload.Save();
                                }
                                break;

                            case GCashTransType.IntCashPickUp:
                                reload.Amount = Properties.Settings.Default.IntCashPickUpSvc ? (this.TransAmount + this.SvcFeeAmount) : this.transAmount;
                                reload.RemainingBalance = dbConnect.GetRemainingLoadBalance(this.Load_Id) + reload.Amount;
                                reload.TransactionAmount = -(this.TransAmount);
                                reload.Save();
                                if (Properties.Settings.Default.IntCashPickUpRebate && this.Rebate>0)
                                {
                                    reload.Amount = this.Rebate;
                                    reload.RemainingBalance = dbConnect.GetRemainingLoadBalance(this.Load_Id) + reload.Amount;
                                    reload.Remarks = "Rebate";
                                    reload.TransactionAmount = 0;
                                    reload.ReloadType = (int)ReloadType.REBATE;
                                    reload.Save();
                                }
                                break;
                            case GCashTransType.DomCashPickup:
                                reload.Amount = Properties.Settings.Default.DomCashPickupSvc ? (this.TransAmount + this.SvcFeeAmount) : this.TransAmount;
                                reload.RemainingBalance = dbConnect.GetRemainingLoadBalance(this.Load_Id) + reload.Amount;
                                reload.TransactionAmount = -(this.TransAmount);
                                reload.Save();
                                if (Properties.Settings.Default.DomCashPickupRebate && this.Rebate>0)
                                {
                                    reload.Amount = this.Rebate;
                                    reload.RemainingBalance = dbConnect.GetRemainingLoadBalance(this.Load_Id) + reload.Amount;
                                    reload.Remarks = "Rebate";
                                    reload.TransactionAmount = 0;
                                    reload.ReloadType = (int)ReloadType.REBATE;
                                    reload.Save();
                                }
                                break;
                            case GCashTransType.RemitSend:
                                reload.Amount = Properties.Settings.Default.RemitSendSvc ? -(this.TransAmount + this.SvcFeeAmount) : -this.TransAmount;
                                reload.RemainingBalance = dbConnect.GetRemainingLoadBalance(this.Load_Id) + reload.Amount;
                                reload.TransactionAmount = (this.TransAmount + this.SvcFeeAmount);                               
                                reload.Save();
                                if (Properties.Settings.Default.RemitSendRebate && this.Rebate>0)
                                {
                                    reload.Amount = this.Rebate;
                                    reload.RemainingBalance = dbConnect.GetRemainingLoadBalance(this.Load_Id) + reload.Amount;
                                    reload.Remarks = "Rebate";
                                    reload.TransactionAmount = 0;
                                    reload.ReloadType = (int)ReloadType.REBATE;
                                    reload.Save();
                                }
                                break;
                            case GCashTransType.RemitCancel:
                                reload.Amount = Properties.Settings.Default.RemitCancelSvc ? (this.TransAmount + this.SvcFeeAmount) : this.TransAmount;
                                reload.RemainingBalance = dbConnect.GetRemainingLoadBalance(this.Load_Id) + reload.Amount;
                                reload.TransactionAmount = Properties.Settings.Default.ChargeServiceFeeOnCancelRemittance ? -(this.TransAmount - this.SvcFeeAmount) : -this.TransAmount;

                                reload.Save();
                                if (Properties.Settings.Default.RemitCancelRebate && this.Rebate>0)
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

        public static List<clsGCashTransaction> GetGCashTransactions(int loadid)
        {
            dbConnect con = new dbConnect();
            List<clsGCashTransaction> ret = null;
            try
            {
                ret = con.GetGCashTransactions(loadid);
            }
            catch { }
            con.Close();
            return ret;
        }
        public static List<clsGCashTransaction> GetGcashTransactionReport(DateTime dateStart, DateTime dateEnd, int userid, string customer)
        {
            dbConnect con = new dbConnect();
            List<clsGCashTransaction> ret = new List<clsGCashTransaction>();
            try
            {
                ret = con.GetGcashTransactionReport(dateStart, dateEnd, userid, customer);
            }
            catch { }
            con.Close();
            return ret;
        }
        public static string GetTransType(GCashTransType type)
        {
            string  ret = "";
            switch (type)
            {
                case GCashTransType.CashIn:
                    ret = "Cash-in";
                    break;
                case GCashTransType.SendToOthers:
                    ret = "Cash-in to others";
                    break;
                case GCashTransType.CashOut:
                    ret = "Cash-out";
                    break;
                case GCashTransType.IntCashPickUp:
                    ret = "Receive International Cash Pick Up";
                    break;
                case GCashTransType.DomCashPickup:
                    ret = "Receive Domestic Cash Pick Up";
                    break;
                case GCashTransType.RemitSend:
                    ret = "Send GCash Remit";
                    break;
                case GCashTransType.RemitCancel:
                    ret = "Cancel GCash Remit";
                    break;
            }
            return ret;
        }
    }

    public enum GCashTransType
    {
        CashIn = 0,
        CashOut = 1,
        SendToOthers = 2,
        IntCashPickUp =3,
        DomCashPickup=4,
        RemitSend=5,
        RemitCancel=6
    }
}
