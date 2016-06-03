using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;

namespace AlreySolutions.Class
{
    public class clsExpenses
    {
        private int expense_id;
        private string _description;
        private double _amount;
        private string _UserName;
        private int _UserId;
        private DateTime _Timestamp;
        

        public DateTime Timestamp
        {
            get { return _Timestamp; }
            set { _Timestamp = value; }
        }

        public int UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int Expense_id
        {
            get { return expense_id; }
            set { expense_id = value; }
        }

        public bool Save()
        {
            dbConnect con = new dbConnect();
            bool ret = con.SaveExpenses(this);
            con.Close();
            Print();
            return ret;
        }

        public static bool Delete(int expenseid)
        {
            dbConnect con = new dbConnect();
            bool ret = con.DeleteExpenses(expenseid);
            con.Close();
            return ret;

        }

        public static List<clsExpenses> GetExpenses(DateTime dateStart,DateTime dateEnd,string cashier="")
        {
            dbConnect con = new dbConnect();
            List<clsExpenses> lstExp = con.GetExpenses(dateStart,dateEnd,cashier);
            con.Close();
            return lstExp;
        }
        public static double GetTotalExpenses(DateTime dateStart, DateTime dateEnd, string cashier = "")
        {
            dbConnect con = new dbConnect();
            double lstExp = con.GetTotalExpenses(dateStart, dateEnd, cashier);
            con.Close();
            return lstExp;
        }

        public void Print()
        {
            string ret = "";
            Receipt or = new Receipt();
            or.InitializePrinter();
            List<string> strmsg = new List<string>();
            ret += or.PrintCompanyHeader();
            strmsg.Add("");
            strmsg.Add("EXPENSE RECEIPT");
            ret += or.PrintAppend(strmsg, PrintFontAlignment.Center, PrintFontSize.UnderlineBold); 
            strmsg.Clear();
            strmsg.Add("Cashier: " + this._UserName.ToUpper());
            strmsg.Add("Date:" + this._Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
            strmsg.Add("");
            strmsg.Add("Description: " + this.Description);
            strmsg.Add("Expense Amount: P " + this.Amount.ToString("0.00"));
            ret += or.PrintAppend(strmsg, PrintFontAlignment.Left, PrintFontSize.Regular);
            or.FormFeed();
            or.OpenDrawer();
            strmsg.Clear();
            or.ExecPrint(ret);
        }

    }

}
