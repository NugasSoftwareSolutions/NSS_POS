using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AlreySolutions.Class
{
    public class Receipt
    {
        #region Private Members
        private Dictionary<string, clsPurchasedItem> _lstPurchasedItems;
        private Dictionary<int, List<clsPurchasedItem>> _dicPurchasedItems=new Dictionary<int,List<clsPurchasedItem>>();
        private string _CashierName;
        private Int32 _ORNumber;
        private double _CashTendered;
        private DateTime _TransDate;
        private double _TotalAmountDue;
        private int m_ReceiptSize = 200;
        private double _discount = 0;
        private double _seniorDiscount = 0;
        private double _dbAmountDue = 0;
        private double _WholeSaleDiscount = 0;
        private int _accountid = 0;
        private string _AccountName = "";
        private string PrintString = "";
        public clsChargedTransaction ChargeTrans
        {
            get {
                if (_ORNumber > 0)
                {
                    return clsChargedTransaction.GetChargedTransaction(_ORNumber);
                }
                return null; 
            }
        }


       #endregion

        #region Public Members

        public string AccountName
        {
            get { return _AccountName; }
            set { _AccountName = value; }
        }

        public int Accountid
        {
            get { return _accountid; }
            set { _accountid = value; }
        }
        public double SeniorDiscount
        {
            get { return _seniorDiscount; }
            set { _seniorDiscount = value; }
        }
        public double WholeSaleDiscount
        {
            get { return _WholeSaleDiscount; }
            set { _WholeSaleDiscount = value; }
        }
        
        public double ItemDiscount
        {
            get {

                _discount = 0;
                foreach (KeyValuePair<string, clsPurchasedItem> purchases in this.PurchasedItems)
                {
                    _discount += (purchases.Value.Discount * purchases.Value.Qty);
                }
                return _discount; 
            }
        }
        
        public Dictionary<string, clsPurchasedItem> PurchasedItems
        {
            get { return _lstPurchasedItems; }
            set { _lstPurchasedItems = value; }
        }
        public string CashierName
        {
            get { return _CashierName; }
            set { _CashierName = value; }
        }
        public double CashTendered
        {
            get { return _CashTendered; }
            set { _CashTendered = value; }
        }
        public double ChangeAmount
        {
            get { return _CashTendered - TotalDiscountedAmount >= 0 ? _CashTendered - TotalDiscountedAmount : 0;} // +(ChargeTrans != null ? ChargeTrans.ChargedAmount : 0); }
        }
        public Int32 ORNumber
        {
            get { return _ORNumber; }
            set { 
                _ORNumber = value;
            }
        }
        public DateTime TransDate
        {
            get { return _TransDate; }
            set { _TransDate = value; }
        }

        public double TotalDiscountedAmount
        {
            get { return Math.Round(TotalAmountDue - ItemDiscount - SeniorDiscount,2); }
        }
        public double ChargedAmount
        {
            get
            {
                if (TotalDiscountedAmount > _CashTendered) return TotalDiscountedAmount - _CashTendered;
                else return 0;
            }
        }
        public double PaidAmount
        {
            get
            {
                if (TotalDiscountedAmount < _CashTendered) return TotalDiscountedAmount;
                else return _CashTendered;
            }
        }

        public double TotalAmountDue
        {
            get
            {
                _TotalAmountDue = 0.0;
                if (_lstPurchasedItems != null)
                {
                    foreach (KeyValuePair<string, clsPurchasedItem> fi in _lstPurchasedItems)
                    {
                        _TotalAmountDue += fi.Value.Amount * fi.Value.Qty;
                    }
                }
                return _TotalAmountDue;
            }
        }
        public double TotalCapital
        {
            get
            {
                double totCapital = 0.0;
                if (_lstPurchasedItems != null)
                {
                    foreach (KeyValuePair<string, clsPurchasedItem> fi in _lstPurchasedItems)
                    {
                        totCapital += fi.Value.Capital * fi.Value.Qty;
                    }
                }
                return totCapital;
            }
        }

        public double DbAmountDue
        {
            get { return _dbAmountDue; }
            set { _dbAmountDue = value; }
        }

        public double TotalQty
        {
            get
            {
                double totalqty = 0;
                if (_lstPurchasedItems != null)
                {
                    foreach (KeyValuePair<string, clsPurchasedItem> fi in _lstPurchasedItems)
                    {
                        totalqty += fi.Value.Qty;
                    }
                }
                return totalqty;
            }
        }

        public void AddPurchasedItem(clsPurchasedItem purchaseditem)
        {
            if (purchaseditem != null)
            {
                this._lstPurchasedItems.Add(purchaseditem.BarCode, purchaseditem);
            }
        }
        public void RemovePurchasedItem(clsPurchasedItem purchaseditem)
        {
            if (purchaseditem != null)
            {
                this._lstPurchasedItems.Remove(purchaseditem.BarCode);
            }
        }
        public Dictionary<string, clsPurchasedItem> GetPurchasedItems()
        {
            return _lstPurchasedItems;
        }
        public Receipt(Int32 ORNum=0,bool isTempReceipt=false)
        {
            _lstPurchasedItems = new Dictionary<string, clsPurchasedItem>();
            if (ORNum > 0)
            {
                dbConnect con = new dbConnect();
                Receipt receipt = null;
                if (isTempReceipt == false)
                    receipt = con.RetrieveReceiptInfo(ORNum);
                else
                    receipt = con.RetrieveTempReceiptInfo(ORNum);

                if (receipt.ORNumber > 0)
                {
                    _ORNumber = receipt.ORNumber;
                    _CashTendered = receipt.CashTendered;
                    _CashierName = receipt.CashierName;
                    _lstPurchasedItems = receipt.PurchasedItems;
                    _TotalAmountDue = receipt.TotalAmountDue;
                    _TransDate = receipt.TransDate;
                    _discount = receipt.ItemDiscount;
                    _seniorDiscount = receipt.SeniorDiscount;
                    _accountid = receipt.Accountid;
                    _AccountName = receipt.AccountName;
                    
                    con.Close();
                    return;
                }
                con.Close();

            }
            _TransDate = DateTime.Now;
            _CashierName = "(Customer)";
        }

        #endregion
        private PrintDialog pd = new PrintDialog();
        private int m_PageNum = 0;


        public void SaveTemp(string CustomerName , bool modifyPurchases = false)
        {
            dbConnect dbCon = new dbConnect();
            Int32 receiptid = this.ORNumber;
            if (dbCon.CreateTempReceipt(ref receiptid, CustomerName, this.TotalAmountDue, this.CashTendered, this.SeniorDiscount, this.ItemDiscount, this.Accountid) == false)
            {
                return;
            }
            if (this.ORNumber != receiptid || this.ORNumber == receiptid && modifyPurchases)
            {
                this.ORNumber = receiptid;

                dbCon.RemoveFromTempHistory(this._ORNumber);
                foreach (KeyValuePair<string, clsPurchasedItem> purchaseditem in _lstPurchasedItems)
                {
                    if (purchaseditem.Value.Qty > 0)
                    {
                        purchaseditem.Value.ORNumber = this.ORNumber;
                        dbCon.AddTempTransaction(purchaseditem.Value);
                    }
                }
            }
            dbCon.Close();
        }

        public static List<Receipt> GetTempReceiptInfo()
        {

            List<Receipt> tmpList = null;
            dbConnect con = new dbConnect();
            try
            {
                tmpList = con.GetTempReceiptInfo();
            }
            catch { }
            con.Close();
            return tmpList;
        }
        public void Save(bool modifyPurchases=false)
        {
            dbConnect dbCon = new dbConnect();
            Int32 receiptid = this.ORNumber;
            if (dbCon.CreateReceipt(ref receiptid, this.CashierName,this.TotalAmountDue, this.CashTendered,this.SeniorDiscount,this.ItemDiscount,this.Accountid,this.TransDate) == false)
            {
                return;
            }
            if (this.ORNumber != receiptid || this.ORNumber==receiptid && modifyPurchases)
            {
                this.ORNumber = receiptid;

                dbCon.RemoveFromHistory(this._ORNumber);
                foreach (KeyValuePair<string, clsPurchasedItem> purchaseditem in _lstPurchasedItems)
                {
                    if (purchaseditem.Value.Qty > 0)
                    {
                        purchaseditem.Value.ORNumber = this.ORNumber;
                        if (dbCon.AddTransaction(purchaseditem.Value))
                        {
                            clsProductItem prod = clsProductItem.SearchProduct(purchaseditem.Value.BarCode);
                            prod.QtySold += purchaseditem.Value.Qty;
                            prod.Save();
                        }
                    }
                }
            }
            this.ORNumber = receiptid;

            dbCon.Close();
        }

        public bool Delete()
        {
            dbConnect dbCon = new dbConnect();
            bool ret = false;
            ret = dbCon.DeleteReceipt(this._ORNumber);
            dbCon.Close();
            return ret;
        }
        public bool DeleteTempReceipt()
        {
            dbConnect dbCon = new dbConnect();
            bool ret = false;
            ret = dbCon.DeleteTempReceipt(this._ORNumber);
            dbCon.Close();
            return ret;
        }
        public override string ToString()
        {
            return string.Format("Invoice #:{0}" , this._ORNumber.ToString().PadLeft(5,'0'));
        }
        public void InitializePrinter()
        {
            pd.PrinterSettings = new PrinterSettings();
            PrintString = string.Format("{0}@", char.ConvertFromUtf32(27));
        }
        public void FormFeed()
        {
            if(Properties.Settings.Default.PrintORBarcode)
                PrintString += string.Format("{0}V{1}{2}", char.ConvertFromUtf32(29), char.ConvertFromUtf32(66), char.ConvertFromUtf32(0));
        }
        
        public void OpenDrawer()
        {
            PrintString += string.Format("{0}{1}{2}{3}{4}", char.ConvertFromUtf32(27), char.ConvertFromUtf32(112), char.ConvertFromUtf32(0), char.ConvertFromUtf32(60), char.ConvertFromUtf32(120));
        }
        public void ExecPrint(string printstring="")
        {
            bool print=false;
            if (Properties.Settings.Default.EnablePrint)
            {
                if (Properties.Settings.Default.ConfirmPrint)
                {
                    if (MessageBox.Show("Do you want to print Receipt?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        print = true;
                }
                else
                {
                    print = true;
                }
                if (print)
                {
                    RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, PrintString);
                }
            }
            if (Properties.Settings.Default.ShowReceipt)
            {
                if (printstring != "")
                {
                    frmPrintReceipt or = new frmPrintReceipt(printstring);
                    or.Show();
                }
            }
        }

        public void PrintBarcode(string Barcode,int labelpos=0)
        {
            int len = Barcode.Length;
            PrintString += string.Format("{8}a{1}{0}h{2}{0}H{3}{0}w{8}{0}f{4}{0}k{5}{6}{7}", char.ConvertFromUtf32(29), char.ConvertFromUtf32(1), char.ConvertFromUtf32(50), char.ConvertFromUtf32(labelpos), char.ConvertFromUtf32(0), char.ConvertFromUtf32(72), char.ConvertFromUtf32(len), Barcode, char.ConvertFromUtf32(27), char.ConvertFromUtf32(10));
        }
        public string PrintHeader(List<string> header,PrintFontAlignment align, PrintFontSize size)
        {
            string strHeader = "";
            foreach (string str in header)
            {
                strHeader += str;
                strHeader += char.ConvertFromUtf32(10);
            }
            PrintString += string.Format("{0}a{1}{0}!{2}{3}", char.ConvertFromUtf32(27), char.ConvertFromUtf32((int)align), char.ConvertFromUtf32((int)size), strHeader);
            return strHeader;
        }

        public string PrintTest(List<string> header,int alignment, int fontsize)
        {
            string strHeader = "";
            foreach (string str in header)
            {
                strHeader += str;
                strHeader += char.ConvertFromUtf32(10);
            }
            PrintString += string.Format("{0}a{1}{0}!{2}{3}", char.ConvertFromUtf32(27), char.ConvertFromUtf32(0), char.ConvertFromUtf32(fontsize), strHeader);
            return strHeader;
        }
        public string PrintCompanyHeader()
        {
            List<string> strmsg = new List<string>();
            strmsg.Add(Properties.Settings.Default.Company);
            strmsg.Add(Properties.Settings.Default.Address1);
            strmsg.Add(Properties.Settings.Default.Address2);
            return PrintHeader(strmsg,PrintFontAlignment.Center,PrintFontSize.MediumReg);
        }
        //public void PrintHeaderLeft(List<string> header)
        //{
        //    string strHeader = "";
        //    foreach (string str in header)
        //    {
        //        strHeader += str;
        //        strHeader += char.ConvertFromUtf32(10);
        //    }
        //    PrintString += string.Format("{0}a{1}{0}!{2}{3}", char.ConvertFromUtf32(27), char.ConvertFromUtf32((int)PrintFontAlignment.Left), char.ConvertFromUtf32((int)PrintFontSize.BigReg), strHeader);
        //}
        public string PrintCenter(List<string> header)
        {
            string strHeader = "";
            foreach (string str in header)
            {
                strHeader += str;
                strHeader += char.ConvertFromUtf32(10);
            }
            PrintString += string.Format("{0}a{1}{0}!{2}{3}", char.ConvertFromUtf32(27), char.ConvertFromUtf32(1), char.ConvertFromUtf32((int)PrintFontSize.SmallBold), strHeader);
            return strHeader;
        }
        public string PrintAppend(List<string> strlist,PrintFontAlignment align, PrintFontSize size)
        {
            string strVal = "";
            foreach (string str in strlist)
            {
                strVal += str;
                strVal += char.ConvertFromUtf32(10);
            }

            PrintString += string.Format("{0}a{1}{0}!{2}{3}", char.ConvertFromUtf32(27), char.ConvertFromUtf32((int)align), char.ConvertFromUtf32((int)size), strVal);
            return strVal;
        }
        public void PrintRight(List<string> strlist)
        {
            string strVal = "";
            foreach (string str in strlist)
            {
                strVal += str;
                strVal += char.ConvertFromUtf32(10);
            }
            PrintString += string.Format("{0}a{1}{0}!{2}{3}", char.ConvertFromUtf32(27), char.ConvertFromUtf32(2), char.ConvertFromUtf32(Properties.Settings.Default.NormalFontSize), strVal);
        }

        public string PrintNew( int printFor = 0 )
        {
            string ret = "";
            InitializePrinter();
            ret += PrintHeader(new List<string>() { Properties.Settings.Default.Company, Properties.Settings.Default.Address1, Properties.Settings.Default.Address2 },  PrintFontAlignment.Center, PrintFontSize.MediumReg);
            if (Properties.Settings.Default.PrintTIN)
                ret += PrintHeader(new List<string>() { Properties.Settings.Default.TIN }, PrintFontAlignment.Center, PrintFontSize.MediumReg);
            if (printFor == 4)
            {
                ret += PrintAppend(new List<string>() { string.Format("Customer: {0}", CashierName.ToUpper()), string.Format("Date: {0}", this.TransDate.ToString("yyyy-MM-dd HH:mm:ss")) }, PrintFontAlignment.Left, PrintFontSize.Regular);
            }
            else
            {
                ret += PrintAppend(new List<string>() { string.Format("Cashier: {0}", CashierName.ToUpper()), string.Format("Date: {0}", this.TransDate.ToString("yyyy-MM-dd HH:mm:ss")), string.Format("Invoice Number: {0}", ORNumber) }, PrintFontAlignment.Left, PrintFontSize.Regular);
            }
            List<string> strmsg = new List<string>();
            if (printFor == 1)
                strmsg.Add("Customer's Copy");
            else if (printFor == 2)
                strmsg.Add("Duplicate Copy");
            else if (printFor == 3)
                strmsg.Add("Reprint");
            else if (printFor == 4)
                strmsg.Add("Partial Billing");

            strmsg.Add("_______________________________________");

            foreach (clsPurchasedItem item in _lstPurchasedItems.Values)
            {
                strmsg.Add(String.Format("Item code: {0}", item.BarCode));
                strmsg.Add(String.Format("  {0}", item.Description));
                strmsg.Add(String.Format("  {0} {3}@P {1:0.00}\tP {2:0.00}", item.Qty, item.Amount - item.Discount, item.Total - (item.Discount * item.Qty), item.Unit));
            }
            strmsg.Add("_______________________________________");
            strmsg.Add(string.Format(" Items              :\t  {0}", TotalQty));
            if (TotalAmountDue > TotalDiscountedAmount)
            {
                strmsg.Add(string.Format(" Before Disc        :\tP {0:0.00}", TotalAmountDue));
                strmsg.Add(string.Format(" Items  Disc        :\tP {0:0.00}", ItemDiscount));
            }

            strmsg.Add(string.Format(" Grand Total        :\tP {0:0.00}", TotalDiscountedAmount));
            strmsg.Add(string.Format(" Tendered Amount    :\tP {0:0.00}", CashTendered));
            strmsg.Add(string.Format(" Change Amount      :\tP {0:0.00}", ChangeAmount));
            ret += PrintAppend(strmsg, PrintFontAlignment.Left, PrintFontSize.SmallBold);
            strmsg.Clear();
            if (ChargeTrans != null)
            {
                strmsg.Add(" ");
                strmsg.Add(string.Format(" Account Name       :\t{0}", ChargeTrans.AccountName));
                clsAccountInfo act = clsAccountInfo.GetAccounts(ChargeTrans.AccountName)[0];
                strmsg.Add(string.Format(" Previous Balance   :\tP {0:0.00}", ChargeTrans.PrevBalance));
                strmsg.Add(string.Format(" Amount Charged     :\tP {0:0.00}", ChargeTrans.ChargedAmount));
                strmsg.Add(string.Format(" Outstanding Balance:\tP {0:0.00}", ChargeTrans.CurrBalance));
                strmsg.Add(string.Format(" _________________________________"));
                strmsg.Add(string.Format(" YTD Trans          :\tP {0:0.00}", act.YTDTransaction));
                strmsg.Add(string.Format(" "));
            }

            if (Properties.Settings.Default.PrintVat)
            {
                strmsg.Add("_______________________________________");
                strmsg.Add(string.Format(" VATable   \t\tP {0:0.00}", TotalDiscountedAmount / (1+(Properties.Settings.Default.VatPercentage/100))));
                strmsg.Add(string.Format(" VAT - {1}% \t\tP {0:0.00}", (TotalDiscountedAmount / (1+(Properties.Settings.Default.VatPercentage/100)) * (Properties.Settings.Default.VatPercentage/100)), Properties.Settings.Default.VatPercentage));
                strmsg.Add(string.Format(" Amount Due\t\tP {0:0.00}", TotalDiscountedAmount));
            }

            if (this.SeniorDiscount > 0)
            {
                strmsg.Add("_______________________________________");
                strmsg.Add("\n");
                strmsg.Add("Senior Citizen Discount");
                strmsg.Add("\n");
                strmsg.Add("Name: ________________________");
                strmsg.Add("\n");
                strmsg.Add("Address: _____________________");
                strmsg.Add("\n");
                strmsg.Add("Signature: ___________________");
            }
            ret += PrintAppend(strmsg, PrintFontAlignment.Left, PrintFontSize.SmallBold);
            strmsg.Clear();
            if (Properties.Settings.Default.PrintMessage)
            {
                strmsg.Add("_______________________________________");
                strmsg.Add(Properties.Settings.Default.Message1);
                strmsg.Add(Properties.Settings.Default.Message2);
                if (Properties.Settings.Default.Message3!="")
                    strmsg.Add(Properties.Settings.Default.Message3);
                strmsg.Add("_______________________________________");
            }
            ret += PrintCenter(strmsg);
            if (Properties.Settings.Default.PrintORBarcode)
                PrintBarcode(ORNumber.ToString("999900000000"));
            else
            {
                PrintCenter(new List<string>() { " ", " " });
            }
            FormFeed();
            if (PaidAmount > 0)
            OpenDrawer();
            ExecPrint();
            
            frmPrintReceipt pr = new frmPrintReceipt(ret);
            pr.ShowDialog();
            return ret;
        }


        public class RawPrinterHelper
        {
            // Structure and API declarions:
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
            public class DOCINFOA
            {
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDocName;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pOutputFile;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDataType;
            }
            [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

            [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool ClosePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

            [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndDocPrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

            // SendBytesToPrinter()
            // When the function is given a printer name and an unmanaged array
            // of bytes, the function sends those bytes to the print queue.
            // Returns true on success, false on failure.
            public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
            {
                Int32 dwError = 0, dwWritten = 0;
                IntPtr hPrinter = new IntPtr(0);
                DOCINFOA di = new DOCINFOA();
                bool bSuccess = false; // Assume failure unless you specifically succeed.

                di.pDocName = "POS Receipt";
                di.pDataType = "RAW";

                // Open the printer.
                if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
                {
                    // Start a document.
                    if (StartDocPrinter(hPrinter, 1, di))
                    {
                        // Start a page.
                        if (StartPagePrinter(hPrinter))
                        {
                            // Write your bytes.
                            bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                            EndPagePrinter(hPrinter);
                        }
                        EndDocPrinter(hPrinter);
                    }
                    ClosePrinter(hPrinter);
                }
                // If you did not succeed, GetLastError may give more information
                // about why not.
                if (bSuccess == false)
                {
                    dwError = Marshal.GetLastWin32Error();
                }
                return bSuccess;
            }

            public static bool SendFileToPrinter(string szPrinterName, string szFileName)
            {
                // Open the file.
                FileStream fs = new FileStream(szFileName, FileMode.Open);
                // Create a BinaryReader on the file.
                BinaryReader br = new BinaryReader(fs);
                // Dim an array of bytes big enough to hold the file's contents.
                Byte[] bytes = new Byte[fs.Length];
                bool bSuccess = false;
                // Your unmanaged pointer.
                IntPtr pUnmanagedBytes = new IntPtr(0);
                int nLength;

                nLength = Convert.ToInt32(fs.Length);
                // Read the contents of the file into the array.
                bytes = br.ReadBytes(nLength);
                // Allocate some unmanaged memory for those bytes.
                pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
                // Copy the managed byte array into the unmanaged array.
                Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
                // Send the unmanaged bytes to the printer.
                bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
                // Free the unmanaged memory that you allocated earlier.
                Marshal.FreeCoTaskMem(pUnmanagedBytes);
                return bSuccess;
            }
            public static bool SendStringToPrinter(string szPrinterName, string szString)
            {
                IntPtr pBytes;
                Int32 dwCount;
                // How many characters are in the string?
                dwCount = szString.Length;
                // Assume that the printer is expecting ANSI text, and then convert
                // the string to ANSI text.
                pBytes = Marshal.StringToCoTaskMemAnsi(szString);
                // Send the converted ANSI string to the printer.
                SendBytesToPrinter(szPrinterName, pBytes, dwCount);
                Marshal.FreeCoTaskMem(pBytes);
                return true;
            }
        }
					
    }

    public enum PrintFontAlignment
    {
        Left=0,
        Center=1,
        Right=2
    }
    public enum PrintFontSize
    {
        Small = 1,
        SmallBold = 65,
        Regular=10,
        Bold=99,
        ItalicBold=95,
        UnderlineReg = 200,
        UnderlineBold = 208,
        MediumReg=66,
        BigReg=32,
        BigBold=50,



    }
}
