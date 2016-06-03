using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlreySolutions.Class
{
    public class clsProductItem
    {
        #region Private Members
        private Int32 _ID;

        private string _BarCode;
        private string _Description;
        private double _Amount;
        private double _WSAmount;
        private double _TotalInventoryQty;
        private double _QtySold;
        private string _Imagepath;
        private double _Capital;
        private string _Unit;
        private int _CriticalLevel;
        private string _Category;



        #endregion

        #region Public Members

        public clsProductItem()
        {
            _ID = 0;
            _Amount = 0.0;
            _TotalInventoryQty = 0;
            _Description = "";
            _BarCode = "";
            _Imagepath = "";
            _Capital = 0;
            _Unit = "pc";
            _CriticalLevel=0;
            _Category = "";
        }


        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string BarCode
        {
            get { return _BarCode; }
            set { _BarCode = value; }
        }
        public string Description
        {
            set { _Description = value; }
            get { return _Description; }
        }
        public double Capital
        {
            get { return _Capital; }
            set { _Capital = value; }
        }

        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }
        public double WSAmount
        {
            get { return _WSAmount; }
            set { _WSAmount = value; }
        }

        public int CategoryId;

        public string Category
        {
            get { return _Category; }
            set { _Category = value; }
        }

        public string Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }

        public double TotalInventoryQty
        {
            get { return _TotalInventoryQty; }
            set { _TotalInventoryQty = value; }
        }

        public double QtySold
        {
            get { return _QtySold; }
            set { _QtySold = value; }
        }

        public double StocksRemainingQty
        {
            get { return _TotalInventoryQty - _QtySold; }
        }

        public string Imagepath
        {
            get { return _Imagepath; }
            set { _Imagepath = value; }
        }

        public int CriticalLevel
        {
            get { return _CriticalLevel; }
            set { _CriticalLevel = value; }
        }
        public Int32 UserID;
        public int WSMinimum;
        public int InStorage;


        #endregion

        #region Public Functions
        public bool Save()
        {
            dbConnect connect = new dbConnect();
            if (this.BarCode == "" || this.Description == "") return false;
            bool ret = connect.SaveProductItem(this);
            connect.Close();
            return ret;
        }
      
        #endregion
        #region Static Functions
        public static bool Delete(string barcode)
        {
            dbConnect connect = new dbConnect();
            bool ret = connect.DeleteProductItem(barcode);
            connect.Close();
            return ret;
        }
        public static bool DeleteProductItem(Int32 id)
        {
            dbConnect connect = new dbConnect();
            bool ret = connect.DeleteProductItem(id);
            connect.Close();
            return ret;
        }
        public static List<clsProductItem> SearchProductItems(string searchString)
        {
            dbConnect connect = new dbConnect();
            List<clsProductItem> lstProd = connect.SearchProductItems(searchString);
            connect.Close();
            return lstProd;
        }
        public static clsProductItem SearchProduct(string barcode)
        {
            dbConnect connect = new dbConnect();
            clsProductItem item = connect.GetProductItem(barcode);
            connect.Close();
            return item;
        }
        public static int ChangeBarcode( string oldBarcode, string newBarcode )
        {
            dbConnect connect = new dbConnect();
            int ret = connect.ChangeBarcode(oldBarcode,newBarcode);
            connect.Close();
            return ret;
        }
        #endregion
    }
}
