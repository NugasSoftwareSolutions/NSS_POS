using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlreySolutions.Class
{
    public class clsCheckOutItem
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private int _checkOutId;

        public int CheckOutId
        {
            get { return _checkOutId; }
            set { _checkOutId = value; }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private double _ExpectedAmount;

        public double ExpectedAmount
        {
            get { return _ExpectedAmount; }
            set { _ExpectedAmount = value; }
        }

        private double _ActualAmount;

        public double ActualAmount
        {
            get { return _ActualAmount; }
            set { _ActualAmount = value; }
        }
        private string _Remarks;

        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }

        public static List<clsCheckOutItem> GetCheckOutItems(int checkoutId)
        {
            dbConnect con = new dbConnect();
            List<clsCheckOutItem> lstCheckoutItems = con.GetCheckOutItems(checkoutId);
            con.Close();
            return lstCheckoutItems;
        }

        public bool Save()
        {
            dbConnect con = new dbConnect();
            bool ret = con.SaveCheckOutItem(this);
            
            con.Close();
            return ret;
        }
    }
}
