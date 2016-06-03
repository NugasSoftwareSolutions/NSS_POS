using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlreySolutions.Class.Load
{
    public class clsLoadAccount
    {
        private int load_id;
        public int LoadId
        {
            get { return load_id; }
            set { load_id = value; }
        }
        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private double currentbal;
        public double CurrentBalance
        {
            get { return currentbal; }
            set { currentbal = value; }
        }
        private double availablebal;

        public double AvailableBalance
        {
            get { return availablebal; }
            set { availablebal = value; }
        }
        private LoadAccountType loadtype;

        public LoadAccountType LoadType
        {
            get { return loadtype; }
            set { loadtype = value; }
        }
        private string accountnum;

        public string AccountNum
        {
            get { return accountnum; }
            set { accountnum = value; }
        }
        private string mobilenum;

        public string MobileNum
        {
            get { return mobilenum; }
            set { mobilenum = value; }
        }
        private byte[] imgFile;

        public byte[] ImgFile
        {
            get { return imgFile; }
            set { imgFile = value; }
        }
        private List<clsServiceFee> lstServiceFees = new List<clsServiceFee>();

        public List<clsServiceFee> LstServiceFees
        {
            get { return lstServiceFees; }
            set { lstServiceFees = value; }
        }
        
        public bool Save()
        {
            dbConnect con = new dbConnect();
            bool ret = false;
            try
            {
                ret = con.SaveLoadAccount(this);
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
                ret = con.DeleteLoadAccount(this);
            }
            catch { }
            con.Close();
            return ret;
        }
        public static clsLoadAccount GetLoadAccount(int loadid)
        {
            dbConnect con = new dbConnect();
            clsLoadAccount ret = null;
            try
            {
                ret = con.GetLoadAccount(loadid);
            }
            catch { }
            con.Close();
            return ret;
        }

        public static List<clsLoadAccount> GetLoadAccounts()
        {
            dbConnect con = new dbConnect();
            List<clsLoadAccount> ret = null;
            try
            {
                ret = con.GetLoadAccounts();
            }
            catch { }
            con.Close();
            return ret;
        }
        public static LoadAccountType GetLoadType(string type)
        {
            switch (type)
            {
                case "Globe E-Cash":
                    return LoadAccountType.GCash;
                case "Smart E-Cash":
                    return LoadAccountType.SCash;
                case "Load Wallet":
                    return LoadAccountType.LoadWallet;
                case "E-Load":
                    return LoadAccountType.ELoad;
                default: return LoadAccountType.New;
            }
        }
    }
    public enum LoadAccountType
    {
        GCash =0,
        SCash = 1,
        LoadWallet =2,
        ELoad=3,
        New = 4
    }
}
