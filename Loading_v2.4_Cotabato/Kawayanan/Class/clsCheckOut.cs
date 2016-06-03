using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlreySolutions.Class
{
    public class clsCheckOut
    {
        private int _Id;
        private double _amountexpected;
        private DateTime _Timestamp;
        private int _userid;
        private string _username;
        private double _amountactual;

        public double ActualAmount
        {
            get { return _amountactual; }
            set { _amountactual = value; }
        }
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

        public DateTime Timestamp
        {
            get { return _Timestamp; }
            set { _Timestamp = value; }
        }

        public double ExpectedAmount
        {
            get { return _amountexpected; }
            set { _amountexpected = value; }
        }

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private List<clsCheckOutItem> _LstItems;

        public List<clsCheckOutItem> LstItems
        {
            get { return _LstItems; }
            set { _LstItems = value; }
        }

        public bool Save()
        {
            dbConnect con = new dbConnect();
            bool ret = con.SaveCheckOut(this);
            if (ret && this.LstItems.Count > 0)
            {
                this.Id = clsCheckOut.GetCheckOutID(this.Timestamp,this.UserName);
                con.DeleteCheckOutItem(this.Id);
                foreach (clsCheckOutItem chkOutItem in this.LstItems)
                {
                    chkOutItem.CheckOutId = this.Id;
                    if (chkOutItem.ActualAmount - chkOutItem.ExpectedAmount != 0)
                        chkOutItem.Remarks = string.Format("{0} [{1:0.00}]", chkOutItem.ActualAmount - chkOutItem.ExpectedAmount > 0 ? "Over" : (chkOutItem.ActualAmount - chkOutItem.ExpectedAmount == 0 ? "Match" : "Short"), chkOutItem.ActualAmount - chkOutItem.ExpectedAmount);
                    else chkOutItem.Remarks = "Match";
                    chkOutItem.Save();
                }
            }
            con.Close();
            return ret;
        }

        public static bool Delete(int initCashid)
        {
            dbConnect con = new dbConnect();
            bool ret = con.DeleteInitialCash(initCashid);
            con.Close();
            return ret;

        }
        public static double GetActualCOH(DateTime dt, string username)
        {
            dbConnect con = new dbConnect();
            double ret = con.GetActualCOH(dt, username);
            con.Close();
            return ret;

        }
        public static int GetCheckOutID(DateTime dt, string username)
        {
            dbConnect con = new dbConnect();
            int ret = con.GetCheckOutID(dt, username);
            con.Close();
            return ret;
        }

        public static List<clsCheckOut> GetCheckOut(DateTime datestart, DateTime dateend, int userid)
        {
            dbConnect con = new dbConnect();
            List<clsCheckOut>  lstCheckout = con.GetCheckOut(datestart, dateend, userid);
            con.Close();
            return lstCheckout;
        }
    }
}
