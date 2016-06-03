using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlreySolutions.Class.Load
{
   public class clsServiceFee
    {
        private int _ServiceFeeID;
        public int ServiceFeeID
        {
            get { return _ServiceFeeID; }
            set { _ServiceFeeID = value; }
        }

        private double _AmountFrom;

        public double AmountFrom
        {
            get { return _AmountFrom; }
            set { _AmountFrom = value; }
        }

        private double _AmountTo;

        public double AmountTo
        {
            get { return _AmountTo; }
            set { _AmountTo = value; }
        }

        private double _EcashFee;

        public double EcashFee
        {
            get { return _EcashFee; }
            set { _EcashFee = value; }
        }

        private double _P2PFee;

        public double P2PFee
        {
            get { return _P2PFee; }
            set { _P2PFee = value; }
        }

        private int _load_id;

        public int Load_id
        {
            get { return _load_id; }
            set { _load_id = value; }
        }

        private double _Rebate_Percentage;
        public double Rebate
        {
            get { return _Rebate_Percentage; }
            set { _Rebate_Percentage = value; }
        }
        private string _Remarks;

        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }

        public static List<clsServiceFee> GetServiceFees(int id = 0)
        {
            dbConnect con = new dbConnect();
            List<clsServiceFee> lstRet = con.GetServiceFees(id);
            con.Close();
            return lstRet;
        }

        public bool Save()
        {
            dbConnect con = new dbConnect();
            bool ret = con.SaveServiceFee(this);
            con.Close();
            return ret;
        }
        public bool Delete()
        {
            dbConnect con = new dbConnect();
            bool ret = con.DeleteServiceFee(this.ServiceFeeID);
            con.Close();
            return ret;
        }
    }
}
