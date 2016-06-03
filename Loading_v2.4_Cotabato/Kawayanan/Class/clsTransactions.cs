using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kawayanan.Class
{
    public class clsTransactionItem
    {
        private int _or_num;
        private int _qty;
        private double _amount;
        private DateTime _date;
        private string _desc;
        private string _barcode;
        private List<clsPurchasedItem> _lstPurchases=null;
        public clsTransactionItem() 
        {
            _amount = 0.0;
            _qty = 0;
            _or_num = 0;
            _desc = "";
            _barcode = "";
            _lstPurchases = new List<clsPurchasedItem>();
        }

        public int ORNumber
        {
            get { return _or_num; }
            set { _or_num = value; }
        }
        public string Description
        {
            get { return _desc; }
            set { _desc = value; }
        }

        public int Quantity
        {
            get { return _qty; }
            set { _qty = value; }
        }

        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        public DateTime TransDate
        {
            get { return _date; }
            set { _date = value; }
        }
        public double Total
        {
            get { return (double)_qty * _amount; }
        }
        public string BarCode
        {
            get { return _barcode; }
            set { _barcode = value; }
        }
        public override string ToString()
        {
            return string.Format("{0} : P{1:0.00} x {2} = {3}",_desc,_amount,_qty,_amount*(double)_qty);
        }

        public void Save()
        {
            dbConnect connect = new dbConnect();
            if (_lstPurchases.Count > 0)
            {
                foreach (clsPurchasedItem item in _lstPurchases)
                {
                    connect.InsertTransHistoryItem(item.ORNumber, item.Description, item.Amount, item.Qty, item.BarCode);

                }
            }
            connect.InsertTransHistoryItem(this._or_num, this._desc, this._amount, this._qty, this._barcode);
            connect.Close();
        }
        public void SaveHistory()
        {
            dbConnect connect = new dbConnect();
            connect.InsertInventoryHistory(this._or_num, this._desc, this._amount, this._qty, this._barcode, this._date);
            connect.Close();
        }
        public void Delete(int inventoryid)
        {
            dbConnect connect = new dbConnect();
            connect.DeleteInventoryItem(inventoryid);
            connect.Close();
        }
    }
}
