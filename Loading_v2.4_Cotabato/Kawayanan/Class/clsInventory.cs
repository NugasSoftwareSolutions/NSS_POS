using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlreySolutions.Class
{
    class clsInventory
    {
        private int _IventoryId;
        private DateTime _DateAdded;
        private double _Quantity;
        private double _Capital;
        private string _Remarks;
        private string _BarCode;
        private string _Description;
        private DateTime _ExpiryDate;

        public string BarCode
        {
            get { return _BarCode; }
            set { _BarCode = value; }
        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }

        public double Capital
        {
            get { return _Capital; }
            set { _Capital = value; }
        }

        public double Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
        public DateTime ExpiryDate
        {
            get { return _ExpiryDate; }
            set { _ExpiryDate = value; }
        }
        public int IventoryId
        {
            get { return _IventoryId; }
            set { _IventoryId = value; }
        }

        public DateTime DateAdded
        {
            get { return _DateAdded; }
            set { _DateAdded = value; }
        }

        public bool Save()
        {
            dbConnect connect = new dbConnect();
            if (this.BarCode == "") return false;
            bool ret = connect.SaveInventory(this);
            connect.Close();
            return ret;
        }

        public static List<clsInventory> lstInventory(string BarCode)
        {
            dbConnect con = new dbConnect();
            List<clsInventory> ret = con.getInventory(BarCode);
            con.Close();
            return ret;
        }

        public static List<clsInventory> GetPurchases(DateTime startdate, DateTime enddate,string remarks)
        {
            dbConnect con = new dbConnect();
            List<clsInventory> ret = con.GetPurchases(startdate, enddate, remarks);
            con.Close();
            return ret;
        }

        public static double GetTotalInventoryQty( string barcode )
        {
            dbConnect con = new dbConnect();
            double ret = 0;
            try
            {
                ret = con.getInventoryQty(barcode);
            }
            catch { }
            con.Close();
            return ret;
        }
        public static double TotalCapital(List<clsInventory> inventories)
        {
            double _TotalCapital = 0.0;
            if (inventories.Count > 0)
            {
                foreach (clsInventory inventory in inventories)
                {
                    _TotalCapital += (inventory.Quantity * inventory.Capital);
                }
            }

            return _TotalCapital;
        }

        public static double AverageCapital(List<clsInventory> inventories)
        {
            double _TotalCapital = 0.0;
            double _TotalQty = 0.0;
            
            if (inventories.Count > 0)
            {
                foreach (clsInventory inventory in inventories)
                {
                    if (inventory.Quantity > 0)
                    {
                        _TotalCapital += (inventory.Quantity * inventory.Capital);
                        _TotalQty += inventory.Quantity;
                    }
                }
            }
            if (_TotalQty == 0) return 0;
            else return _TotalCapital/_TotalQty;
        }
    }
}
