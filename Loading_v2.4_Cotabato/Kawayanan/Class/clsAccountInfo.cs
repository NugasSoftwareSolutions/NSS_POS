using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlreySolutions.Class
{
    public class clsAccountInfo
    {
        private int _AccountId;
        public int AccountId
        {
            get { return _AccountId; }
            set
            {
                _AccountId = value;
            }
        }

        private string _AccountName;
        public string AccountName{ get{return _AccountName;} set{_AccountName =value ;} }
        private DateTime _LastInterestPayment;

        private double _PrincipalBalance = 0;
        private double _TotalInterest = 0;
        private double _TotalPayment = 0;
        private double _TotalYearToDateTrans = 0;
        private List<clsChargedTransaction> _ChargedTrans = null;
        private List<clsPaymentInfo> _PaymentInfo = null;
        private double _CreditLimit;
        
       
        public double CreditLimit
        {
            get { return _CreditLimit; }
            set { _CreditLimit = value; }
        }

        public double TotalPayment
        {
            get {
                _TotalPayment = 0;
                if (_PaymentInfo != null)
                {
                    foreach (clsPaymentInfo p in _PaymentInfo)
                    {
                        _TotalPayment += p.AmountPaid;
                    }
                }
                return _TotalPayment; 
            }
        }

        public double PrincipalBalance
        {
            get {
                //if (_ChargedTrans != null)
                //{
                //    _PrincipalBalance = 0;
                //    foreach (clsChargedTransaction c in _ChargedTrans)
                //    {
                //        _PrincipalBalance += c.TransBalance;
                //    }
                //}
                return _PrincipalBalance;
            }
            set
            {
                _PrincipalBalance = value;
            }
        }
        public double TotalInterest
        {
            get
            {
                //if (_ChargedTrans != null)
                //{
                //    _TotalInterest = 0;
                //    foreach (clsChargedTransaction c in _ChargedTrans)
                //    {
                //        _TotalInterest += c.Interest;
                //    }
                //}
                return Math.Round(_TotalInterest,2);
            }
            set
            {
                _TotalInterest = value;
            }
        }

        public DateTime LastComputedInterest
        {
            get { return _LastInterestPayment; }
            set { _LastInterestPayment = value; }
        }
        public double AccountReceivable
        {
            get
            {
                return Math.Round(PrincipalBalance + TotalInterest,2);
            }
        }
        public List<clsChargedTransaction> ChargedTrans
        {
            get { return _ChargedTrans; }
            set { _ChargedTrans = value; }
        }

        public List<clsPaymentInfo> PaymentInfo
        {
            get { return _PaymentInfo; }
            set { _PaymentInfo = value; }
        }

        public double YTDTransaction
        {
            get { return _TotalYearToDateTrans; }
            set { _TotalYearToDateTrans = value; }
        }
        public clsAccountInfo()
        { 
        
        }
        public clsAccountInfo(int accountid)
        {
            dbConnect con = new dbConnect();
            clsAccountInfo account = con.GetAccountInfo(accountid);
            if (account != null)
            {
                AccountId = account.AccountId;
                AccountName = account.AccountName;
                CreditLimit = account.CreditLimit;
                YTDTransaction = account.YTDTransaction;
                PrincipalBalance = account.PrincipalBalance;
                TotalInterest = account.TotalInterest;
            }
            con.Close();
        }

        public void LoadTransInfo()
        {
            PaymentInfo = clsPaymentInfo.GetPaymentsInfo(_AccountId);
            ChargedTrans = clsChargedTransaction.GetChargedTransactions(_AccountId);
            YTDTransaction = clsChargedTransaction.GetYTDTransactions(_AccountId);
            Recompute();
        }

        private void Recompute()
        {
            double totalPrincipal = 0;
            double totalInterest = 0;
            foreach(clsChargedTransaction c in ChargedTrans)
            {
                totalPrincipal += c.ChargedAmount;
                int totalmonths = dbConnect.getTotalMonths(c.InterestPayment.Date);
                if (c.TransBalance > 0 && totalmonths > 0)
                {
                    c.Interest = Math.Round(c.TransBalance * Properties.Settings.Default.InterestRate * totalmonths, 2);
                }
                else
                {
                    c.Interest = 0;
                }
                totalInterest += c.Interest;
            }
            totalInterest = Math.Round(totalInterest, 2);
            totalPrincipal = Math.Round(totalPrincipal, 2);
            foreach (clsPaymentInfo p in PaymentInfo)
            {
                if(p.Remarks.ToLower().Contains("principal payment"))
                    totalPrincipal -= p.AmountPaid;
            }
            TotalInterest = totalInterest;
            PrincipalBalance = totalPrincipal;
            Save();
        }
        public bool Save()
        {
            dbConnect con = new dbConnect();
            bool ret = false;
            try
            {
                ret = con.SaveAccountInfo(this);
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
                ret = con.DeleteAccountInfo(AccountId);
            }
            catch { }
            con.Close();
            return ret;
        }
        public static List<clsAccountInfo> GetAccounts(string name)
        {
            List<clsAccountInfo> lstac = new List<clsAccountInfo>();
            try
            {
                lstac = dbConnect.GetAccountInfoList(name);
            }
            catch { }
            return lstac;
        }
    }
}
