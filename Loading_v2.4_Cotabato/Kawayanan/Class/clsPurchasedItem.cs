using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlreySolutions.Class
{
    public class clsPurchasedItem
    {
        private Int32 _ORNumber;
        private string _BarCode;
        private string _Description;
        private double _Amount;
        private double _Qty;
        private string _Unit;
        private int _UserID;
        private string _UserName;
        private bool _IsWholeSale;
        private double _Discount;
        private double _Capital;
        private int _InStorage;
        private string _Category;
        private string _Account;


        public string Category
        {
            get { return _Category; }
            set { _Category = value; }
        }

        public double Capital
        {
            get { return _Capital; }
            set { _Capital = value; }
        }

        public double Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }

        public bool IsWholeSale
        {
            get { return _IsWholeSale; }
            set { _IsWholeSale = value; }
        }

        public Int32 ORNumber
        {
          get { return _ORNumber; }
          set { _ORNumber = value; }
        }

        public string BarCode
        {
            get { return _BarCode; }
            set { _BarCode = value; }
        }
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        public double Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }


        public string Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }

        public int InStorage
        {
            get { return _InStorage; }
            set { _InStorage = value; }
        }

        public string Description
        {
            set { _Description = value; }
            get { return _Description; }
        }
        public double Total
        {
            get { return _Amount * _Qty; }
        }

        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }


        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        public string Account
        {
            get { return _Account; }
            set { _Account = value; }
        }
        public clsPurchasedItem() 
        {
            _Amount = 0.0;
            _Qty = 0;
            _Unit = "pc";
            _Description = "";
            _BarCode = "";
            _IsWholeSale = false;
            _UserID = 0;
            _Discount = 0;
            _Capital = 0;
            _Category = "";
            _Account = "";
        }
        
        public clsPurchasedItem(clsProductItem item,bool iswholesale=false) 
        {
            _Amount = iswholesale? item.WSAmount:item.Amount ;
            _Qty = 1;
            _Unit = item.Unit;
            _Description = item.Description;
            _BarCode = item.BarCode;
            _IsWholeSale = iswholesale;
            _UserID = item.UserID;
            _Discount = 0;
            _Capital = item.Capital;
            _InStorage = item.InStorage;
            _Category = item.Category;
        }
        public static double GetTotalQtySold(string barcode)
        {
            dbConnect con = new dbConnect();
            double ret = 0;
            try
            {
                ret = con.GetTotalQtySold(barcode);
            }
            catch { }
            con.Close();
            return ret;
        }
        public static List<clsPurchasedItem> GetTransactionsFrmDate( DateTime startDate, DateTime endDate )
        {
            dbConnect con = new dbConnect();
            List<clsPurchasedItem> ret = null;
            try
            {
                ret = con.GetTransactionsFrmDate(startDate,endDate);
            }
            catch { }
            con.Close();
            return ret;
        }
        public string ToString(int format=0)
        {
            switch (format)
            {
                case 0: return String.Format("{0}: {1} - P{2} x {3} {5} = {4}", _BarCode, _Description, _Amount.ToString("0.00"), _Qty, Total,_Unit);
                case 1: return String.Format("{0}: {1}", _BarCode, _Description);
            }
            return _Description;   
        }
    }
}
