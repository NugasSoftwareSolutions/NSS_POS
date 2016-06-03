using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;

namespace AlreySolutions.Class
{
    public class clsDepositCash
    {
        private int _Id;
        private double _amount;
        private DateTime _Timestamp;
        private int _userid;
        private string _username;
        private double _prevamount;
        private double _addedamount;

        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        public int UserId
        {
            get { return _userid; }
            set { _userid = value; }
        }
        public double PrevAmount
        {
            get { return _prevamount; }
            set { _prevamount = value; }
        }
        public double Addedamount
        {
            get { return _addedamount; }
            set { _addedamount = value; }
        }
        public DateTime Timestamp
        {
            get { return _Timestamp; }
            set { _Timestamp = value; }
        }

        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public bool Save()
        {
            dbConnect con = new dbConnect();
            bool ret = con.SaveDepositCash(this);
            con.Close();
            if (Amount > 0)
                Print();
            return ret;
        }

        public static bool Delete(int initCashid)
        {
            dbConnect con = new dbConnect();
            bool ret = con.DeleteInitialCash(initCashid);
            con.Close();
            return ret;

        }

        public static double GetCashDeposit(DateTime date, int userid)
        {
            dbConnect con = new dbConnect();
            double amount = con.GetDepositCash(date, userid);
            con.Close();
            return amount;
        }

        public static double GetDepositCash(DateTime date, string username)
        {
            dbConnect con = new dbConnect();
            double amount = con.GetDepositCash(date, username);
            con.Close();
            return amount;
        }


        public void Print()
        {
            Receipt or = new Receipt();
            string strval = "";
            or.InitializePrinter();
            List<string> strmsg = new List<string>();
            strval += or.PrintCompanyHeader();
            strmsg.Add("");
            strmsg.Add("DEPOSIT CASH");
            strval += or.PrintAppend(strmsg,PrintFontAlignment.Center, PrintFontSize.Bold);
            strmsg.Clear();
            strmsg.Add("Cashier: " + this._username.ToUpper());
            strmsg.Add("Date: " + this._Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
            strmsg.Add("");
            strmsg.Add("Previous Deposited Amount: P " + this.PrevAmount.ToString("0.00"));
            strmsg.Add("Added Amount: P " + this.Addedamount.ToString("0.00"));
            strmsg.Add("Total Deposited Amount: P " + this.Amount.ToString("0.00"));
            strval += or.PrintAppend(strmsg, PrintFontAlignment.Left, PrintFontSize.Regular);
            or.FormFeed();
            or.OpenDrawer();
            strmsg.Clear();
            or.ExecPrint(strval);

        }
    }
}
