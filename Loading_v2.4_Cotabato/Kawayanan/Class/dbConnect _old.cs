using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Xml.Serialization;

namespace AlreySolutions.Class
{
    class dbConnect_old
    {
        OleDbConnection con = null;

        public dbConnect_old()
        {
            try
            {
                con = new OleDbConnection(Properties.Settings.Default.dbConnectionString1 + @";Jet OLEDB:Database Password=@Lr3yP0$dB;");  // connection string change database name and password here.
                con.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }
        public string GetDatabaseName()
        {
            return con.DataSource;
        }
        public void Close()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }

        /// <summary>
        /// MBD compact method (c) 2004 Alexander Youmashev
        /// !!IMPORTANT!!
        /// !make sure there's no open connections
        ///    to your db before calling this method!
        /// !!IMPORTANT!!
        /// </summary>
        /// <param name="connectionString">connection string to your db</param>
        /// <param name="mdwfilename">FULL name
        ///     of an MDB file you want to compress.</param>
        public static void CompactAccessDB( string connectionString, string mdwfilename )
        {
            try
            {
                object[] oParams;

                //create an inctance of a Jet Replication Object
                object objJRO =
                  Activator.CreateInstance(Type.GetTypeFromProgID("JRO.JetEngine"));

                //filling Parameters array
                //cnahge "Jet OLEDB:Engine Type=5" to an appropriate value
                // or leave it as is if you db is JET4X format (access 2000,2002)
                //(yes, jetengine5 is for JET4X, no misprint here)
                oParams = new object[] {
                    connectionString,
                    "Provider=Microsoft.Jet.OLEDB.4.0;Data" + 
                    " Source=C:\\tempdb.mdb;Jet OLEDB:Engine Type=5"};

                //invoke a CompactDatabase method of a JRO object
                //pass Parameters array
                objJRO.GetType().InvokeMember("CompactDatabase",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    objJRO,
                    oParams);

                //database is compacted now
                //to a new file C:\\tempdb.mdw
                //let's copy it over an old one and delete it

                System.IO.File.Delete(mdwfilename);
                System.IO.File.Move("C:\\tempdb.mdb", mdwfilename);

                //clean up (just in case)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(objJRO);
                objJRO = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool SaveChargedTransaction( clsChargedTransaction charge )
        {
            if (con.State == ConnectionState.Closed) con.Open();
            bool ret = false;
            OleDbCommand cmd = new OleDbCommand("Select chargeid from chargetransaction WHERE chargeid = " + charge.ChargeID.ToString() + " AND Deleted=0", con); // creating query command
            try
            {
                object obj = cmd.ExecuteScalar(); // executes query
                string sql = "";
                if (obj != null && obj != DBNull.Value) // if can read row from database
                {
                    sql = string.Format("Update chargetransaction set accountid={0},ornum={1},charged_amount={2},user_id={3},[timestamp]='{4}',deleted = 0,accountname = '{5}',prev_balance={7},curr_balance={8},trans_balance={9},interest_payment='{10}',trans_amount = {11} where chargeid = {6}", charge.AccountId, charge.ORNum, charge.ChargedAmount, charge.User_Id, charge.Timestamp.ToString("yyy-MM-dd HH:ss:mm"), charge.AccountName, charge.ChargeID, charge.PrevBalance, charge.CurrBalance, charge.TransBalance, charge.InterestPayment.ToString("yyy-MM-dd HH:ss:mm"), charge.TransAmount);
                    cmd = new OleDbCommand(sql, con); // creating query command
                    ret = cmd.ExecuteNonQuery() > 0;
                }
                else
                {
                    sql = string.Format("Insert into chargetransaction ([accountid],[ornum],[charged_amount],[user_id],[timestamp],[deleted],[accountname],[prev_balance],[curr_balance],[trans_balance],[interest_payment],[trans_amount]) VALUES({0},{1},{2},{3},'{4}',{5},'{6}',{7},{8},{9},'{10}',{11})", charge.AccountId, charge.ORNum, charge.ChargedAmount, charge.User_Id, charge.Timestamp.ToString("yyy-MM-dd HH:ss:mm"), 0, charge.AccountName, charge.PrevBalance, charge.CurrBalance, charge.TransBalance, charge.InterestPayment.ToString("yyy-MM-dd HH:ss:mm"), charge.TransAmount);
                    cmd = new OleDbCommand(sql, con); // creating query command
                    ret = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch { }
            return ret;
        }


        public clsChargedTransaction GetChargedTransaction( int OrNum )
        {
            if (con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from view_chargetransactions WHERE ornum = " + OrNum.ToString() + " AND Deleted=0", con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            clsChargedTransaction charge = null;
            try
            {
                if (reader.HasRows && reader.Read())
                    charge = BuildChargedTransaction(reader);
            }
            catch { }
            if (!reader.IsClosed) reader.Close();
            return charge;
        }

        private static clsChargedTransaction BuildChargedTransaction( OleDbDataReader reader )
        {
            clsChargedTransaction charge = null;
            if (reader.HasRows) // if can read row from database
            {
                charge = new clsChargedTransaction();
                charge.AccountId = Convert.ToInt32(reader["AccountId"].ToString());
                charge.AccountName = reader["AccountName"].ToString();
                charge.ChargeID = Convert.ToInt32(reader["ChargeID"].ToString());
                charge.ORNum = Convert.ToInt32(reader["ORNum"].ToString());
                charge.ChargedAmount = double.Parse(reader["Charged_Amount"].ToString());
                charge.TransAmount = double.Parse(reader["trans_Amount"].ToString());
                charge.User_Id = Convert.ToInt32(reader["User_Id"].ToString());
                charge.Timestamp = Convert.ToDateTime(reader["timestamp"].ToString());
                if (reader["prev_balance"] != DBNull.Value)
                    charge.PrevBalance = Convert.ToDouble(reader["prev_balance"]);
                if (reader["curr_balance"] != DBNull.Value)
                    charge.CurrBalance = Convert.ToDouble(reader["curr_balance"]);
                if (reader["trans_balance"] != DBNull.Value)
                    charge.TransBalance = Math.Round(Convert.ToDouble(reader["trans_balance"]), 2);
                if (reader["interest_payment"] != DBNull.Value)
                    charge.InterestPayment = Convert.ToDateTime(reader["interest_payment"]);
                else
                    charge.InterestPayment = charge.Timestamp;
                int totalmonths = getTotalMonths(charge.InterestPayment.Date);
                if (charge.TransBalance > 0 && totalmonths > 0)
                {
                    charge.Interest = Math.Round(charge.TransBalance * Properties.Settings.Default.InterestRate * totalmonths, 2);
                }
                else
                {
                    charge.Interest = 0;
                }
            }
            return charge;
        }
        public static int getTotalMonths( DateTime intpaymentdate )
        {
            return (DateTime.Now.Year - intpaymentdate.Year) * 12 + DateTime.Now.Month - intpaymentdate.Month + (DateTime.Now.Day >= intpaymentdate.Day ? 0 : -1);

        }
        public List<clsChargedTransaction> GetChargedTransactions( int accountid )
        {
            if (con.State == ConnectionState.Closed) con.Open();

            OleDbCommand cmd = null;
            if(accountid==0)
                cmd = new OleDbCommand("Select * from view_chargetransactions WHERE Deleted=0 order by chargeid", con); // creating query command
            else
                cmd = new OleDbCommand("Select * from view_chargetransactions WHERE accountid = " + accountid.ToString() + " AND Deleted=0  order by chargeid", con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            clsChargedTransaction charge = null;
            List<clsChargedTransaction> charges = new List<clsChargedTransaction>();
            if (reader.HasRows) // if can read row from database
            {
                while (reader.Read())
                {
                    try
                    {
                        charge = BuildChargedTransaction(reader);
                        if (charge != null)
                            charges.Add(charge);
                    }
                    catch { }
                }
            }
            if (!reader.IsClosed) reader.Close();
            return charges;
        }

        public double GetYTDTransactions( int accountid )
        {
            if (con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd = new OleDbCommand("Select SUM(trans_amount) from view_chargetransactions WHERE accountid = " + accountid.ToString() + " AND Deleted=0 and [timestamp] like '%" + DateTime.Now.Year + "%'", con); // creating query command
            object obj = cmd.ExecuteScalar(); // executes query
            if (obj != null && obj != DBNull.Value)
                return Convert.ToDouble(obj);
            else
                return 0;
        }
        public double GetPrincipalAmount( int accountid )
        {
            if (con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd = new OleDbCommand("Select SUM(trans_balance) from view_chargetransactions WHERE accountid = " + accountid.ToString() + " AND Deleted=0 and trans_balance>0", con); // creating query command
            object obj = cmd.ExecuteScalar(); // executes query
            if (obj != null && obj != DBNull.Value)
                return Convert.ToDouble(obj);
            else
                return 0;
        }
        public double GetTotalInterest( int actid )
        {
            double total = 0;
            List<clsChargedTransaction> tmplist = GetTransWithInterest(actid);
            foreach (clsChargedTransaction ct in tmplist)
            {
                total += ct.Interest;
            }
            return Math.Round(total, 2);
        }
        public List<clsChargedTransaction> GetTransWithInterest( int accountid )
        {
            if (con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from view_chargetransactions WHERE accountid = " + accountid.ToString() + " AND Deleted=0 AND Trans_Balance>0 and interest_payment <= #" + DateTime.Today.AddMonths(-1).ToShortDateString() + "# order by timestamp asc", con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            clsChargedTransaction charge = null;
            List<clsChargedTransaction> charges = new List<clsChargedTransaction>();
            if (reader.HasRows) // if can read row from database
            {
                while (reader.Read())
                {
                    try
                    {
                        charge = BuildChargedTransaction(reader);
                        if (charge != null)
                            charges.Add(charge);
                    }
                    catch { }
                }
            }
            if (!reader.IsClosed) reader.Close();
            return charges;
        }

        public List<clsChargedTransaction> GetUnPaidChargedTransactions( int accountid )
        {
            if (con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from view_chargetransactions WHERE accountid = " + accountid.ToString() + " AND Deleted=0 AND Trans_Balance>0 order by timestamp asc", con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            clsChargedTransaction charge = null;
            List<clsChargedTransaction> charges = new List<clsChargedTransaction>();
            if (reader.HasRows) // if can read row from database
            {
                while (reader.Read())
                {
                    try
                    {
                        charge = BuildChargedTransaction(reader);
                        if (charge != null)
                            charges.Add(charge);
                    }
                    catch { }
                }
            }
            if (!reader.IsClosed) reader.Close();
            return charges;
        }

        public bool CancelPayment( int payref )
        {
            if (con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd = new OleDbCommand("Update PaymentInfo set Deleted=1 WHERE payment_id = " + payref.ToString() + " AND Deleted=0", con); // creating query command
            int ret = cmd.ExecuteNonQuery(); // executes query
            return ret > 0;
        }

        public List<clsPaymentInfo> GetPaymentInfo( int OrNo )
        {
            if (con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from view_PaymentInfo WHERE OrNum = " + OrNo.ToString() + " AND Deleted=0", con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            List<clsPaymentInfo> payment = new List<clsPaymentInfo>();
            if (reader.HasRows) // if can read row from database
            {
                while (reader.Read())
                {
                    clsPaymentInfo pinfo = BuildPaymentInfo(reader);
                    payment.Add(pinfo);
                }
            }
            if (!reader.IsClosed) reader.Close();
            return payment;
        }

        public clsPaymentInfo GetPayment( int payment_id )
        {
            if (con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd = new OleDbCommand("Select Top 1 * from view_PaymentInfo WHERE payment_id = " + payment_id.ToString() + " AND Deleted=0", con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            clsPaymentInfo payment = null;
            if (reader.HasRows) // if can read row from database
            {
                if (reader.Read())
                {
                    payment = BuildPaymentInfo(reader);
                }
            }
            if (!reader.IsClosed) reader.Close();
            return payment;
        }

        private static clsPaymentInfo BuildPaymentInfo( OleDbDataReader reader )
        {
            clsPaymentInfo pinfo = new clsPaymentInfo();
            try
            {
                pinfo.PaymentId = Convert.ToInt32(reader["Payment_Id"].ToString());
                pinfo.OrNum = Convert.ToInt32(reader["OrNum"].ToString());
                pinfo.AccountId = Convert.ToInt32(reader["AccountId"].ToString());
                pinfo.AccountName = reader["AccountName"].ToString();
                pinfo.UserName = reader["LoginName"].ToString();
                pinfo.Remarks = reader["Remarks"].ToString();
                string ret = reader["AmountPaid"].ToString();
                pinfo.AmountPaid = Convert.ToDouble(ret.Trim());
                pinfo.Timestamp = Convert.ToDateTime(reader["Timestamp"].ToString());
                pinfo.UserId = Convert.ToInt32(reader["User_Id"].ToString());
            }
            catch { }
            return pinfo;
        }
        public List<clsPaymentInfo> GetPaymentsInfo( int accountid )
        {
            if (con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from view_PaymentInfo WHERE accountid = " + accountid.ToString() + " AND Deleted=0", con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            List<clsPaymentInfo> payments = new List<clsPaymentInfo>();

            if (reader.HasRows) // if can read row from database
            {
                while (reader.Read())
                {
                    clsPaymentInfo pinfo = BuildPaymentInfo(reader);
                    payments.Add(pinfo);
                }
            }
            if (!reader.IsClosed) reader.Close();
            return payments;
        }
        public List<clsChargedTransaction> GetChargedTransFromDate( int accountid, DateTime startdate, DateTime enddate )
        {
            if (con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd = new OleDbCommand(string.Format("Select * from view_chargetransactions WHERE accountid ={0} AND Deleted=0 AND [timestamp] between #{0} 06:00:00# and #{1} 06:00:00# ", accountid, startdate.ToString("yyyy-MM-dd"), enddate.ToString("yyyy-MM-dd")), con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            List<clsChargedTransaction> charges = new List<clsChargedTransaction>();

            if (reader.HasRows) // if can read row from database
            {
                while (reader.Read())
                {
                    clsChargedTransaction pinfo = BuildChargedTransaction(reader);
                    charges.Add(pinfo);
                }
            }
            if (!reader.IsClosed) reader.Close();
            return charges;
        }

        public List<clsPaymentInfo> GetPaymentsInfoFromDate( DateTime startdate, DateTime enddate, string cashier )
        {
            if (con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd = null;
            if (cashier != "")
            {
                cmd = new OleDbCommand(string.Format("Select * from view_paymentInfo WHERE Deleted=0 AND [timestamp] between #{0} 06:00:00# and #{1} 06:00:00# AND LoginName = '{2}' ", startdate.ToString("yyyy-MM-dd"), enddate.ToString("yyyy-MM-dd"), cashier), con); // creating query command
            }
            else
            {
                cmd = new OleDbCommand(string.Format("Select * from view_paymentInfo WHERE Deleted=0 AND [timestamp] between #{0} 06:00:00# and #{1} 06:00:00#  ", startdate.ToString("yyyy-MM-dd"), enddate.ToString("yyyy-MM-dd")), con); // creating query command
            }
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            List<clsPaymentInfo> payments = new List<clsPaymentInfo>();

            if (reader.HasRows) // if can read row from database
            {
                while (reader.Read())
                {
                    clsPaymentInfo pinfo = BuildPaymentInfo(reader);
                    payments.Add(pinfo);
                }
            }
            if (!reader.IsClosed) reader.Close();
            return payments;
        }

        public double GetTotalPaymentsInfoFromDate( DateTime startdate, DateTime enddate, string cashier )
        {
            double ret = 0;
            if (con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd = null;
            if (cashier != "")
            {
                cmd = new OleDbCommand(string.Format("Select sum(amountpaid) as AmountPaid from view_paymentInfo WHERE Deleted=0 AND [timestamp] between #{0} 06:00:00# and #{1} 06:00:00# AND LoginName = '{2}' ", startdate.ToString("yyyy-MM-dd"), enddate.ToString("yyyy-MM-dd"), cashier), con); // creating query command
            }
            else
            {
                cmd = new OleDbCommand(string.Format("Select sum(amountpaid) as AmountPaid from view_paymentInfo WHERE Deleted=0 AND [timestamp] between #{0} 06:00:00# and #{1} 06:00:00#  ", startdate.ToString("yyyy-MM-dd"), enddate.ToString("yyyy-MM-dd")), con); // creating query command
            }
            object obj = cmd.ExecuteScalar(); // executes query
            if (obj != null && obj != DBNull.Value)
                ret = Convert.ToDouble(obj);
            return ret;
        }


        public string SavePayment( clsPaymentInfo pay )
        {
            try
            {
                string ret = "";
                OleDbCommand cmd = null;
                OleDbCommand cmdGetIdentity;

                List<clsChargedTransaction> lstCharged = GetUnPaidChargedTransactions(pay.AccountId);
                string sql = "";
                double totalPayment = pay.AmountPaid;
                if (lstCharged.Count > 0)
                {
                    foreach (clsChargedTransaction c in lstCharged)
                    {
                        bool savetrans = false;
                        if (totalPayment <= 0)
                            break;
                        else if (c.Interest > 0 && totalPayment - c.Interest >= 0)
                        {
                            totalPayment -= c.Interest;
                            totalPayment = Math.Round(totalPayment, 2);
                            c.InterestPayment = DateTime.Now;
                            sql = String.Format("Insert Into paymentinfo ([accountid],[AmountPaid],[timestamp],[user_id],[Deleted],[remarks],[ORNum]) VALUES({0},{1},'{2}',{3},0,'{4}',{5})", pay.AccountId, c.Interest, DateTime.Now, pay.UserId, string.Format("Interest Payment: ORNum({0})", c.ORNum), c.ORNum);
                            cmd = new OleDbCommand(sql, con); // creating query command
                            cmd.ExecuteNonQuery();
                            savetrans = true;
                            cmdGetIdentity = new OleDbCommand("SELECT @@IDENTITY", con);
                            object obj = cmdGetIdentity.ExecuteScalar();
                            if (obj != null && obj != DBNull.Value)
                                ret += string.Format("Payment ref#{0}: {1} P{2:0.00}\n", obj.ToString(), string.Format("Interest Payment: ORNum({0})", c.ORNum), c.Interest);
                            cmdGetIdentity = null;

                        }
                        if (savetrans)
                            c.SaveChargeTransaction();
                    }
                    totalPayment = Math.Round(totalPayment, 2);
                    foreach (clsChargedTransaction c in lstCharged)
                    {
                        bool savetrans = false;
                        if (totalPayment <= 0)
                            break;

                        if (c.TransBalance - totalPayment >= 0)
                        {
                            c.TransBalance -= totalPayment;
                            sql = String.Format("Insert Into paymentinfo ([accountid],[AmountPaid],[timestamp],[user_id],[Deleted],[remarks],[ORNum]) VALUES({0},{1},'{2}',{3},0,'{4}',{5})", pay.AccountId, totalPayment, DateTime.Now, pay.UserId, string.Format("Principal Payment: ORNum({0})", c.ORNum), c.ORNum);
                            cmd = new OleDbCommand(sql, con); // creating query command
                            cmd.ExecuteNonQuery();

                            cmdGetIdentity = new OleDbCommand("SELECT @@IDENTITY", con);
                            object obj = cmdGetIdentity.ExecuteScalar();
                            if (obj != null && obj != DBNull.Value)
                                ret += string.Format("Payment ref#{0}: {1} P{2:0.00}\n", obj.ToString(), string.Format("Principal Payment: ORNum({0})", c.ORNum), totalPayment);
                            cmdGetIdentity = null;

                            totalPayment = 0;
                            savetrans = true;
                        }
                        else
                        {
                            sql = String.Format("Insert Into paymentinfo ([accountid],[AmountPaid],[timestamp],[user_id],[Deleted],[remarks],[ORNum]) VALUES({0},{1},'{2}',{3},0,'{4}',{5})", pay.AccountId, c.TransBalance, DateTime.Now, pay.UserId, string.Format("Principal Payment: ORNum({0})", c.ORNum), c.ORNum);
                            cmd = new OleDbCommand(sql, con); // creating query command
                            cmd.ExecuteNonQuery();

                            cmdGetIdentity = new OleDbCommand("SELECT @@IDENTITY", con);
                            object obj = cmdGetIdentity.ExecuteScalar();
                            if (obj != null && obj != DBNull.Value)
                                ret += string.Format("Payment ref#{0}: {1} P{2:0.00}\n", obj.ToString(), string.Format("Principal Payment: ORNum({0})", c.ORNum), c.TransBalance);
                            cmdGetIdentity = null;

                            totalPayment -= c.TransBalance;
                            c.TransBalance = 0;
                            savetrans = true;
                        }
                        if (savetrans)
                            c.SaveChargeTransaction();
                    }
                    totalPayment = Math.Round(totalPayment, 2);

                }
                return ret;
                //sql = String.Format("Insert Into paymentinfo ([accountid],[AmountPaid],[timestamp],[user_id],[Deleted]) VALUES({0},{1},'{2}',{3},0)", pay.AccountId, pay.AmountPaid, DateTime.Now, pay.UserId);
                //cmd = new OleDbCommand(sql, con); // creating query command

                //if (cmd.ExecuteNonQuery() > 0)
                //{
                //    return true;
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);  // shows exception message in console if any errors occured
            }
            return "";
        }


        public clsAccountInfo GetAccountInfo( int AccountId )
        {
            if (con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from AccountInfo WHERE accountid = " + AccountId.ToString() + " AND Deleted=0", con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            clsAccountInfo account = null;
            if (reader.HasRows) // if can read row from database
            {
                reader.Read();
                account = BuildAccount(reader);
            }
            if (!reader.IsClosed) reader.Close();
            return account;
        }

        public bool SaveAccountInfo( clsAccountInfo ac )
        {
            bool ret = false;
            if (con.State == ConnectionState.Closed) con.Open();

            OleDbCommand cmd = null;
            if (ac.AccountId == 0)
                cmd = new OleDbCommand("Select accountid from AccountInfo WHERE AccountName = '" + ac.AccountName.ToString() + "' AND Deleted=0", con); // creating query command
            else
                cmd = new OleDbCommand("Select accountid from AccountInfo WHERE accountid = " + ac.AccountId.ToString() + " AND Deleted=0", con); // creating query command

            object obj = cmd.ExecuteScalar();
            if (obj != null && obj != DBNull.Value) // if can read row from database
            {
                cmd = new OleDbCommand(string.Format("Update AccountInfo set AccountName = '{0}', creditlimit={1},YTD={2},Principal={3},Interest={4},LastComputedInterest='{6}' where accountid={5}", ac.AccountName, ac.CreditLimit, ac.YTDTransaction, ac.PrincipalBalance, ac.TotalInterest, ac.AccountId, ac.LastComputedInterest), con);
                ret = cmd.ExecuteNonQuery() > 0;
            }
            else
            {
                cmd = new OleDbCommand(string.Format("Insert into AccountInfo (AccountName,CreditLImit,Deleted,YTD,Principal,Interest,LastComputedInterest) VALUES('{0}',{1},0,{2},{3},{4},'{5}')", ac.AccountName, ac.CreditLimit, ac.YTDTransaction, ac.PrincipalBalance, ac.TotalInterest, ac.LastComputedInterest), con);
                ret = cmd.ExecuteNonQuery() > 0;
            }
            return ret;
        }

        public bool DeleteAccountInfo( int accountid )
        {
            bool ret = false;
            if (con.State == ConnectionState.Closed) con.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand("Select accountid from AccountInfo WHERE accountid = " + accountid.ToString() + " AND Deleted=0", con); // creating query command
                object obj = cmd.ExecuteScalar();
                if (obj != null && obj != DBNull.Value) // if can read row from database
                {
                    cmd = new OleDbCommand(string.Format("Update AccountInfo set deleted = 1 where accountid={0}", accountid), con);
                    ret = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch { }
            return ret;
        }

        public static List<clsAccountInfo> GetAccountInfoList( string name = "" )
        {
            OleDbConnection dbCon = new OleDbConnection(Properties.Settings.Default.dbConnectionString1 + "Jet OLEDB:Database Password=@Lr3yP0$dB;");  // connection string change database name and password here.
            if (dbCon.State == ConnectionState.Closed) dbCon.Open();
            OleDbCommand cmd = null;
            if (name == "")
                cmd = new OleDbCommand("Select * from AccountInfo where Deleted=0 order by AccountName", dbCon); // creating query command
            else
                cmd = new OleDbCommand("Select * from AccountInfo where AccountName like '%" + name + "%' and Deleted=0 order by AccountName", dbCon); // creating query command

            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            clsAccountInfo account = null;
            List<clsAccountInfo> accounts = new List<clsAccountInfo>();

            if (reader.HasRows) // if can read row from database
            {
                while (reader.Read())
                {
                    account = BuildAccount(reader);
                    accounts.Add(account);
                }
            }
            if (!reader.IsClosed) reader.Close();
            dbCon.Close();
            return accounts;
        }

        private static clsAccountInfo BuildAccount( OleDbDataReader reader )
        {
            clsAccountInfo account = new clsAccountInfo();
            account.AccountId = Convert.ToInt32(reader["AccountId"].ToString());
            account.AccountName = reader["AccountName"].ToString();
            account.CreditLimit = double.Parse(reader["CreditLimit"].ToString());
            bool updateneeded = false;
            if (reader["YTD"] == DBNull.Value || reader["YTD"] == null)
            {
                account.YTDTransaction = clsChargedTransaction.GetYTDTransactions(account.AccountId);
                updateneeded = true;
            }
            else
                account.YTDTransaction = double.Parse(reader["YTD"].ToString());

            if (reader["Principal"] == DBNull.Value || reader["Principal"] == null)
            {
                account.PrincipalBalance = clsChargedTransaction.GetPrincipalAmount(account.AccountId);
                updateneeded = true;
            }
            else
                account.PrincipalBalance = double.Parse(reader["Principal"].ToString());

            if (reader["LastComputedInterest"] == DBNull.Value || reader["LastComputedInterest"] == null)
            {
                account.LastComputedInterest = DateTime.MinValue;
                updateneeded = true;
            }
            else
                account.LastComputedInterest = DateTime.Parse(reader["LastComputedInterest"].ToString());

            if (reader["Interest"] == DBNull.Value || reader["Interest"] == null)
            {
                account.TotalInterest = clsChargedTransaction.GetTotalInterest(account.AccountId);
                updateneeded = true;
            }
            else
            {
                if ((DateTime.Now - account.LastComputedInterest).TotalDays >= 30 || DateTime.Now < account.LastComputedInterest)
                {
                    account.TotalInterest = clsChargedTransaction.GetTotalInterest(account.AccountId);
                    account.LastComputedInterest = DateTime.Today;
                    updateneeded = true;
                }
                else
                    account.TotalInterest = double.Parse(reader["Interest"].ToString());
            }
            if (updateneeded)
                account.Save();
            return account;
        }


        public clsProductItem GetProductItem( string barcode )
        {
            if (con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from view_Items WHERE barcode = '" + barcode.Replace("'", "''") + "' AND Deleted=0", con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            clsProductItem proditem = null;
            if (reader.HasRows) // if can read row from database
            {
                reader.Read();
                proditem = BuildProductITem(reader);

            }
            if (!reader.IsClosed) reader.Close();
            return proditem;
        }

        private static clsProductItem BuildProductITem( OleDbDataReader reader )
        {
            clsProductItem proditem = new clsProductItem();
            proditem.ID = Int32.Parse(reader["ID"].ToString());
            proditem.BarCode = reader["barcode"].ToString();
            proditem.Description = reader["description"].ToString();
            proditem.Amount = Math.Round(double.Parse(reader["amount"].ToString()), 2);
            proditem.WSAmount = Math.Round(double.Parse(reader["wsamount"].ToString()), 2);
            proditem.TotalInventoryQty = double.Parse(reader["QtyAvailable"].ToString());
            proditem.QtySold = double.Parse(reader["QtySold"].ToString());
            proditem.Unit = reader["unit"].ToString();
            proditem.Imagepath = reader["ImagePath"].ToString();
            proditem.WSMinimum = Int32.Parse(reader["WSMinimum"].ToString());
            proditem.Capital = Math.Round(double.Parse(reader["capital"].ToString()), 2);
            proditem.InStorage = Int32.Parse(reader["instorage"].ToString());
            proditem.CriticalLevel = Int32.Parse(reader["CriticalLevel"].ToString());
            proditem.CategoryId = Int32.Parse(reader["categoryid"].ToString());
            proditem.Category = reader["category"].ToString();
            return proditem;
        }

        private static clsProductItem BuildProductITemAsOf( OleDbDataReader reader, DateTime asOf )
        {
            OleDbCommand cmd = null;
            OleDbConnection dbCon = new OleDbConnection();

            clsProductItem proditem = new clsProductItem();
            proditem.ID = Int32.Parse(reader["ID"].ToString());
            proditem.BarCode = reader["barcode"].ToString();
            proditem.Description = reader["description"].ToString();
            proditem.Amount = Math.Round(double.Parse(reader["amount"].ToString()), 2);
            proditem.WSAmount = Math.Round(double.Parse(reader["wsamount"].ToString()), 2);

            cmd = new OleDbCommand(String.Format("Select sum(Qty) from view_Items where Deleted = 0 and Barcode ='{0}'", proditem.BarCode.Trim()), dbCon);
            object obj = cmd.ExecuteScalar();
            if (obj != DBNull.Value && obj != null)
            {
                proditem.QtySold = double.Parse(obj.ToString());
            }
            cmd = new OleDbCommand(String.Format("Select sum(Qty) from inventory where Deleted = 0 and Barcode ='{0}'", proditem.BarCode.Trim()), dbCon);
            obj = cmd.ExecuteScalar();
            if (obj != DBNull.Value && obj != null)
            {
                proditem.TotalInventoryQty = double.Parse(obj.ToString()) - proditem.QtySold;
            }

            proditem.Unit = reader["unit"].ToString();
            proditem.Imagepath = reader["ImagePath"].ToString();
            proditem.WSMinimum = Int32.Parse(reader["WSMinimum"].ToString());
            proditem.Capital = Math.Round(double.Parse(reader["capital"].ToString()), 2);
            proditem.InStorage = Int32.Parse(reader["instorage"].ToString());
            proditem.CriticalLevel = Int32.Parse(reader["CriticalLevel"].ToString());
            proditem.CategoryId = Int32.Parse(reader["categoryid"].ToString());
            proditem.Category = reader["category"].ToString();
            return proditem;
        }

        public List<clsProductItem> GetProductItems( string description )
        {
            OleDbCommand cmd = new OleDbCommand("Select * from view_Items WHERE description like '%" + description.Replace("'", "''") + "%' and Deleted=0", con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            List<clsProductItem> proditems = new List<clsProductItem>();
            if (reader.HasRows)
            {
                while (reader.Read()) // if can read row from database
                {
                    clsProductItem proditem = BuildProductITem(reader);
                    proditems.Add(proditem);
                }
            }
            if (!reader.IsClosed) reader.Close();
            return proditems;
        }

        public List<clsInventory> getInventory( string BarCode )
        {
            string sql = "";
            if (BarCode == "")
                sql = String.Format("Select * from view_Inventory WHERE deleted=0 order by [ID] desc");
            else
                sql = String.Format("Select * from view_Inventory WHERE [Barcode] like '{0}' and [deleted] = 0 order by [ID] desc", BarCode);

            OleDbCommand cmd = new OleDbCommand(sql, con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            List<clsInventory> inventories = new List<clsInventory>();
            if (reader.HasRows)
            {
                while (reader.Read()) // if can read row from database
                {
                    clsInventory inventory = new clsInventory();
                    inventory.Description = reader["Description"].ToString();
                    inventory.BarCode = reader["BarCode"].ToString();
                    inventory.DateAdded = Convert.ToDateTime(reader["DateAdded"].ToString());
                    inventory.Quantity = int.Parse(reader["Qty"].ToString());
                    inventory.Capital = double.Parse(reader["Capital"].ToString());
                    try
                    {
                        inventory.ExpiryDate = DateTime.Parse(reader["ExpiryDate"].ToString());
                    }
                    catch
                    {
                        inventory.ExpiryDate = inventory.DateAdded;
                    }
                    inventory.Remarks = reader["Remarks"].ToString();
                    inventories.Add(inventory);
                }
            }
            if (!reader.IsClosed) reader.Close();
            return inventories;
        }

        public List<clsInventory> GetPurchases( DateTime startdate, DateTime enddate, string remarks )
        {
            string sql = "";
            if (remarks == "")
                sql = String.Format("Select * from view_Inventory WHERE DateAdded between #{0:yyyy/MM/dd 06:00:00}# and #{1:yyyy/MM/dd 06:00:00}# and deleted=0 order by dateadded desc", startdate, enddate.AddDays(1));
            else
                sql = String.Format("Select * from view_Inventory WHERE DateAdded between #{0:yyyy/MM/dd 06:00:00}# and #{1:yyyy/MM/dd 06:00:00}# and remarks like '%{2}%' and deleted=0 order by dateadded desc", startdate, enddate.AddDays(1), remarks);

            OleDbCommand cmd = new OleDbCommand(sql, con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            List<clsInventory> inventories = new List<clsInventory>();
            if (reader.HasRows)
            {
                while (reader.Read()) // if can read row from database
                {
                    clsInventory inventory = new clsInventory();
                    inventory.Description = reader["Description"].ToString();
                    inventory.BarCode = reader["BarCode"].ToString();
                    inventory.DateAdded = Convert.ToDateTime(reader["DateAdded"].ToString());
                    inventory.Quantity = int.Parse(reader["Qty"].ToString());
                    inventory.Capital = double.Parse(reader["Capital"].ToString());
                    try
                    {
                        inventory.ExpiryDate = DateTime.Parse(reader["ExpiryDate"].ToString());
                    }
                    catch
                    {
                        inventory.ExpiryDate = inventory.DateAdded;
                    }
                    inventory.Remarks = reader["Remarks"].ToString();
                    inventories.Add(inventory);
                }
            }
            if (!reader.IsClosed) reader.Close();
            return inventories;
        }


        public double getInventoryQty( string BarCode )
        {
            string sql = "";
            double ret = 0;
            if (BarCode != "")
            {
                sql = String.Format("Select sum(qty) as TotalQty from view_Inventory WHERE Barcode ='{0}' and deleted=0", BarCode);
                try
                {
                    OleDbCommand cmd = new OleDbCommand(sql, con); // creating query command
                    object obj = cmd.ExecuteScalar(); // executes query
                    if (obj != null && obj != DBNull.Value)
                    {

                        try
                        {
                            ret = Convert.ToDouble(obj);
                        }
                        catch { }

                    }
                }
                catch (Exception ex)
                {
                    string str = ex.Message;
                }
            }
            return ret;
        }

        public bool DeleteProductItem( string barcode )
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand(String.Format("Select * from Items where Barcode = '{0}' AND Deleted=0", barcode), con);
                if (cmd.ExecuteReader().HasRows == true)
                {
                    cmd = new OleDbCommand(String.Format("Update Items Set Deleted = 1 where Barcode = '{0}' AND Deleted=0;", barcode), con); // creating query command
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        cmd = new OleDbCommand(String.Format("Update Inventory Set Deleted = 1 where Barcode = '{0}' AND Deleted=0;", barcode), con); // creating query command
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);  // shows exception message in console if any errors occured
            }
            return false;
        }

        public bool DeleteProductItem( Int32 id )
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand(String.Format("Select ID from Items where ID = {0} AND Deleted=0", id), con);
                if (cmd.ExecuteScalar() != null)
                {
                    cmd = new OleDbCommand(String.Format("Delete from Items where ID = {0} AND Deleted=0", id), con); // creating query command
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);  // shows exception message in console if any errors occured
            }
            return false;
        }

        public List<clsProductItem> SearchProductItems( string searchString )
        {
            List<clsProductItem> lstProdItems = new List<clsProductItem>();
            try
            {
                OleDbCommand cmd = null;
                if (searchString == "")
                    cmd = new OleDbCommand(String.Format("Select * from view_Items where Deleted = 0 order by description"), con);
                else
                    cmd = new OleDbCommand(String.Format("Select * from view_Items where (Barcode like '%{0}%' OR Description like '%{0}%') AND Deleted = 0 order by description", searchString.Replace("'", "''")), con);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read()) // if can read row from database
                    {
                        clsProductItem proditem = BuildProductITem(reader);
                        lstProdItems.Add(proditem);
                    }
                    if (!reader.IsClosed) reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);  // shows exception message in console if any errors occured
            }
            return lstProdItems;
        }

        public List<clsProductItem> SearchProductItemsAsOf( string searchString, DateTime asOf )
        {
            List<clsProductItem> lstProdItems = new List<clsProductItem>();
            try
            {
                OleDbCommand cmd = null;
                if (searchString == "")
                    cmd = new OleDbCommand(String.Format("Select * from view_Items where Deleted = 0 order by description"), con);
                else
                    cmd = new OleDbCommand(String.Format("Select * from view_Items where (Barcode like '%{0}%' OR Description like '%{0}%') AND Deleted = 0 order by description", searchString.Replace("'", "''")), con);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read()) // if can read row from database
                    {
                        clsProductItem proditem = BuildProductITem(reader);
                        lstProdItems.Add(proditem);
                    }
                    if (!reader.IsClosed) reader.Close();
                    if (DateTime.Now.Date != asOf.Date)
                    {
                        frmProgress progress = new frmProgress(lstProdItems.Count);
                        progress.Caption = "Re-Calculating Inventory";
                        progress.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        progress.Show();
                        foreach (clsProductItem proditem in lstProdItems)
                        {
                            progress.Val += 1;

                            cmd = new OleDbCommand(String.Format("Select sum(Qty) from view_transaction where Deleted = 0 and Barcode ='{0}' and transdate<#{1:yyyy-MM-dd}#", proditem.BarCode.Trim(), asOf.AddDays(1).ToShortDateString()), con);
                            object obj = cmd.ExecuteScalar();
                            if (obj != DBNull.Value && obj != null)
                            {
                                proditem.QtySold = double.Parse(obj.ToString());
                            }
                            else
                            {
                                proditem.QtySold = 0;
                            }
                            cmd = new OleDbCommand(String.Format("Select sum(Qty) from inventory where Deleted = 0 and Barcode ='{0}' and dateadded<#{1:yyyy-MM-dd}#", proditem.BarCode.Trim(), asOf.AddDays(1).ToShortDateString()), con);
                            obj = cmd.ExecuteScalar();
                            if (obj != DBNull.Value && obj != null)
                            {
                                proditem.TotalInventoryQty = double.Parse(obj.ToString());
                            }
                            else
                            {
                                proditem.TotalInventoryQty = 0;
                            }
                        }
                        progress.Close();

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);  // shows exception message in console if any errors occured
            }
            return lstProdItems;
        }

        public int ExecuteNonQuery( string sql, ref string errormsg )
        {
            try
            {
                OleDbCommand cmd = null;
                cmd = new OleDbCommand(sql, con);
                errormsg = "";
                return cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                errormsg = ex.Message;
            }
            return -1;
        }

        public bool SaveProductItem( clsProductItem proditem )
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand(String.Format("Select * from Items where Barcode = '{0}' AND Deleted = 0", proditem.BarCode), con);
                if (cmd.ExecuteReader().HasRows == false)
                {
                    cmd = new OleDbCommand(String.Format("Insert Into Items(barcode,description,amount,wsamount,qtyavailable,imagepath,wsminimum,capital,qtysold,unit,instorage,criticalLevel,categoryid) VALUES('{0}','{1}',{2:0.00},{3:0.00},{4},'{5}',{6},{7},0,'{8}',{9},{10},{11})", proditem.BarCode, proditem.Description.Replace("'", "''"), proditem.Amount, proditem.WSAmount, proditem.TotalInventoryQty, proditem.Imagepath, proditem.WSMinimum, proditem.Capital, proditem.Unit, proditem.InStorage, proditem.CriticalLevel, proditem.CategoryId), con); // creating query command

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                }
                else
                {
                    string sql = String.Format("Update Items Set Description = '{0}', Amount = {1:0.00}, WSAmount={2:0.00},QtyAvailable={3},ImagePath='{5}',WSMinimum={6},Capital={7},QtySold={8},Unit='{9}',InStorage={10},CriticalLevel={11},categoryid={12} WHERE Barcode ='{4}'", proditem.Description.Replace("'", "''"), proditem.Amount, proditem.WSAmount, proditem.TotalInventoryQty, proditem.BarCode, proditem.Imagepath, proditem.WSMinimum, proditem.Capital, proditem.QtySold, proditem.Unit, proditem.InStorage, proditem.CriticalLevel, proditem.CategoryId);
                    cmd = new OleDbCommand(sql, con); // creating query command

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);  // shows exception message in console if any errors occured
            }
            return false;
        }

        public bool SaveInventory( clsInventory inventory )
        {
            try
            {
                string sql = String.Format("Insert Into Inventory(Barcode,DateAdded,Qty,Capital,Remarks,ExpiryDate,Deleted)VALUES('{0}',NOW(),{1},{2},'{3}','{4}',0)", inventory.BarCode, inventory.Quantity, inventory.Capital, inventory.Remarks, inventory.ExpiryDate);
                OleDbCommand cmd = new OleDbCommand(sql, con); // creating query command

                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);  // shows exception message in console if any errors occured
            }
            return false;
        }

        public bool DeleteReceipt( Int32 ReceiptID )
        {
            try
            {
                OleDbCommand cmd = null;
                cmd = new OleDbCommand(String.Format("Update Receipt Set Deleted=1 Where ORNumber={0}", ReceiptID), con);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    try
                    {
                        cmd = new OleDbCommand(String.Format("Update ChargeTransaction Set Deleted=1 Where ORNum={0}", ReceiptID), con);
                        cmd.ExecuteNonQuery();
                    }
                    catch { }
                    return RemoveFromHistory(ReceiptID);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return false;
        }

        public bool DeleteTempReceipt( Int32 ReceiptID )
        {
            try
            {
                OleDbCommand cmd = null;
                cmd = new OleDbCommand(String.Format("Update TempReceipt Set Deleted=1 Where ORNumber={0}", ReceiptID), con);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return RemoveFromTempHistory(ReceiptID);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return false;
        }

        public static double GetTotalDiscount( Int32 ReceiptID )
        {
            OleDbConnection dbCon = new OleDbConnection(Properties.Settings.Default.dbConnectionString1 + "Jet OLEDB:Database Password=@Lr3yP0$dB;");  // connection string change database name and password here.
            OleDbCommand cmd = null;
            double ret = 0;
            try
            {
                dbCon.Open();
                cmd = new OleDbCommand(string.Format("Select sum(discount) as Total from TransactionHistory WHERE OrNumber={0} and Deleted=0", ReceiptID), dbCon); // creating query command

                object obj = cmd.ExecuteScalar(); // executes query
                if (obj != null && obj != DBNull.Value)
                    ret = Convert.ToDouble(obj);
            }
            catch { }
            dbCon.Close();
            return ret;
        }
        public bool CreateReceipt( ref Int32 ReceiptID, string cashier, double AmountDue, double CashTendered, double srdiscount, double itemdiscount, Int32 accountid )
        {
            try
            {
                OleDbCommand cmd = null;
                OleDbCommand cmdGetIdentity;
                if (ReceiptID == 0)
                {
                    cmd = new OleDbCommand(String.Format("Insert Into Receipt(CustomerName,AmountDue,CashTendered,TransDate,Discount,ItemDiscount,AccountId, Deleted) Values('{0}',{1},{2},'{3}',{4},{5},{6},0)", cashier, AmountDue, CashTendered, DateTime.Now.ToString(), srdiscount, itemdiscount, accountid), con); // creating query command
                    cmd.ExecuteNonQuery();
                    cmdGetIdentity = new OleDbCommand("SELECT @@IDENTITY", con);
                    object obj = cmdGetIdentity.ExecuteScalar();
                    if (obj != null && obj != DBNull.Value)
                        ReceiptID = Convert.ToInt32(obj);
                    cmdGetIdentity = null;
                }
                else
                {
                    cmd = new OleDbCommand(String.Format("Select * from Receipt where ORNumber = {0} AND Deleted = 0", ReceiptID), con);
                    if (cmd.ExecuteReader().HasRows == false)
                    {
                        cmd = new OleDbCommand(String.Format("Insert Into Receipt(CustomerName,AmountDue,CashTendered,TransDate,Discount,ItemDiscount, Deleted) Values('{0}',{1},{2},'{3}',{4},{5},0)", cashier, AmountDue, CashTendered, DateTime.Now.ToString(), srdiscount, itemdiscount), con); // creating query command
                        cmdGetIdentity = new OleDbCommand("SELECT @@IDENTITY", con);
                        object obj = cmdGetIdentity.ExecuteScalar();
                        if (obj != null && obj != DBNull.Value)
                            ReceiptID = Convert.ToInt32(obj);
                        cmdGetIdentity = null;
                    }
                    else
                    {
                        cmd = new OleDbCommand(String.Format("Update Receipt Set CustomerName='{0}',AmountDue={1},CashTendered={2},Discount={3},ItemDiscount={5},AccountId={6} WHERE ORNumber={4}", cashier, AmountDue, CashTendered, srdiscount, ReceiptID, itemdiscount, accountid), con); // creating query command
                        cmd.ExecuteNonQuery();
                    }
                }

                //if (ReceiptID==0)
                //{
                //    cmd = new OleDbCommand("Select Top 1 ORNumber from Receipt Order by ORNumber desc", con);
                //    OleDbDataReader reader = cmd.ExecuteReader();
                //    if (reader.HasRows == true)
                //    {
                //        reader.Read();
                //        ReceiptID = Int32.Parse(reader["ORNumber"].ToString());
                //        return true;
                //    }
                //}   
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);  // shows exception message in console if any errors occured
            }
            if (ReceiptID == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CreateTempReceipt( ref Int32 ReceiptID, string cashier, double AmountDue, double CashTendered, double srdiscount, double itemdiscount, Int32 accountid )
        {
            try
            {
                OleDbCommand cmd = null;
                OleDbCommand cmdGetIdentity;
                if (ReceiptID == 0)
                {
                    cmd = new OleDbCommand(String.Format("Insert Into TempReceipt(CustomerName,AmountDue,CashTendered,TransDate,Discount,ItemDiscount,AccountId, Deleted) Values('{0}',{1},{2},'{3}',{4},{5},{6},0)", cashier, AmountDue, CashTendered, DateTime.Now.ToString(), srdiscount, itemdiscount, accountid), con); // creating query command
                    cmd.ExecuteNonQuery();
                    cmdGetIdentity = new OleDbCommand("SELECT @@IDENTITY", con);
                    object obj = cmdGetIdentity.ExecuteScalar();
                    if (obj != null && obj != DBNull.Value)
                        ReceiptID = Convert.ToInt32(obj);
                    cmdGetIdentity = null;
                }
                else
                {
                    cmd = new OleDbCommand(String.Format("Select * from TempReceipt where ORNumber = {0} AND Deleted = 0", ReceiptID), con);
                    if (cmd.ExecuteReader().HasRows == false)
                    {
                        cmd = new OleDbCommand(String.Format("Insert Into TempReceipt(CustomerName,AmountDue,CashTendered,TransDate,Discount,ItemDiscount, Deleted) Values('{0}',{1},{2},'{3}',{4},{5},0)", cashier, AmountDue, CashTendered, DateTime.Now.ToString(), srdiscount, itemdiscount), con); // creating query command
                        cmdGetIdentity = new OleDbCommand("SELECT @@IDENTITY", con);
                        object obj = cmdGetIdentity.ExecuteScalar();
                        if (obj != null && obj != DBNull.Value)
                            ReceiptID = Convert.ToInt32(obj);
                        cmdGetIdentity = null;
                    }
                    else
                    {
                        cmd = new OleDbCommand(String.Format("Update TempReceipt Set CustomerName='{0}',AmountDue={1},CashTendered={2},Discount={3},ItemDiscount={5},AccountId={6} WHERE ORNumber={4}", cashier, AmountDue, CashTendered, srdiscount, ReceiptID, itemdiscount, accountid), con); // creating query command
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);  // shows exception message in console if any errors occured
            }
            if (ReceiptID == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool RemoveFromHistory( Int32 receiptid )
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand(String.Format("Update TransactionHistory Set Deleted=1 WHERE ORNumber = {0}", receiptid), con); // creating query command

                if (cmd.ExecuteNonQuery() >= 0)
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);  // shows exception message in console if any errors occured
            }
            return false;
        }

        public bool RemoveFromTempHistory( Int32 receiptid )
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand(String.Format("Update TempTransactionHistory Set Deleted=1 WHERE ORNumber = {0}", receiptid), con); // creating query command

                if (cmd.ExecuteNonQuery() >= 0)
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);  // shows exception message in console if any errors occured
            }
            return false;
        }

        public bool AddTransaction( clsPurchasedItem purchaseditem )
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand(String.Format("Insert Into TransactionHistory (ORNumber,Barcode,Description,Amount,Qty,TotalAmount,IsWholeSale,userid,Deleted,Discount,Capital,unit,instorage) Values({0},'{1}','{2}',{3},{4},{5},{6},{7},0,{8},{9},'{10}',{11})", purchaseditem.ORNumber, purchaseditem.BarCode.Replace("'", "''"),
                    purchaseditem.Description.Replace("'", "''"), purchaseditem.Amount, purchaseditem.Qty, purchaseditem.Amount * purchaseditem.Qty, purchaseditem.IsWholeSale ? 1 : 0, purchaseditem.UserID, purchaseditem.Discount, purchaseditem.Capital, purchaseditem.Unit, purchaseditem.InStorage), con); // creating query command

                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);  // shows exception message in console if any errors occured
            }
            return false;
        }

        public bool AddTempTransaction( clsPurchasedItem purchaseditem )
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand(String.Format("Insert Into TempTransactionHistory (ORNumber,Barcode,Description,Amount,Qty,TotalAmount,IsWholeSale,userid,Deleted,Discount,Capital,unit,instorage) Values({0},'{1}','{2}',{3},{4},{5},{6},{7},0,{8},{9},'{10}',{11})", purchaseditem.ORNumber, purchaseditem.BarCode.Replace("'", "''"),
                    purchaseditem.Description.Replace("'", "''"), purchaseditem.Amount, purchaseditem.Qty, purchaseditem.Amount * purchaseditem.Qty, purchaseditem.IsWholeSale ? 1 : 0, purchaseditem.UserID, purchaseditem.Discount, purchaseditem.Capital, purchaseditem.Unit, purchaseditem.InStorage), con); // creating query command

                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);  // shows exception message in console if any errors occured
            }
            return false;
        }

        public Receipt RetrieveReceiptInfo( Int32 ORNum )
        {
            Receipt receipt = new Receipt();
            string sql = String.Format("Select Top 1 * from view_Receipt where ORNumber = {0} AND Deleted=0 Order By ORNumber Desc", ORNum);
            OleDbCommand cmd = new OleDbCommand(sql, con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            if (reader.Read()) // if can read row from database
            {
                receipt.ORNumber = int.Parse(reader["ORNumber"].ToString());
                receipt.CashierName = reader["CustomerName"].ToString();
                receipt.CashTendered = double.Parse(reader["CashTendered"].ToString());
                receipt.TransDate = DateTime.Parse(reader["TransDate"].ToString());
                receipt.PurchasedItems = GetPurchasedItems(receipt.ORNumber);
                receipt.SeniorDiscount = double.Parse(reader["Discount"].ToString());
                receipt.Accountid = int.Parse(reader["Accountid"].ToString());
                receipt.AccountName = reader["AccountName"].ToString();
            }
            if (!reader.IsClosed) reader.Close();

            return receipt;
        }

        public Receipt RetrieveTempReceiptInfo( Int32 ORNum )
        {
            Receipt receipt = new Receipt();
            string sql = String.Format("Select Top 1 * from TempReceipt where ORNumber = {0} AND Deleted=0 Order By ORNumber Desc", ORNum);
            OleDbCommand cmd = new OleDbCommand(sql, con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            if (reader.Read()) // if can read row from database
            {
                receipt.ORNumber = int.Parse(reader["ORNumber"].ToString());
                receipt.CashierName = reader["CustomerName"].ToString();
                receipt.CashTendered = double.Parse(reader["CashTendered"].ToString());
                receipt.TransDate = DateTime.Parse(reader["TransDate"].ToString());
                receipt.PurchasedItems = GetPurchasedItems(receipt.ORNumber);
                receipt.SeniorDiscount = double.Parse(reader["Discount"].ToString());
            }
            if (!reader.IsClosed) reader.Close();

            return receipt;
        }
        public List<Receipt> GetTempReceiptInfo()
        {
            List<Receipt> lstReceipt = new List<Receipt>();
            string sql = String.Format("Select * from TempReceipt WHERE Deleted=0 Order By ORNumber Asc");
            OleDbCommand cmd = new OleDbCommand(sql, con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query

            if (reader.HasRows) // if can read row from database `
            {
                while (reader.Read())
                {
                    Receipt receipt = new Receipt();
                    receipt.ORNumber = int.Parse(reader["ORNumber"].ToString());
                    receipt.CashierName = reader["CustomerName"].ToString();
                    receipt.CashTendered = double.Parse(reader["CashTendered"].ToString());
                    receipt.DbAmountDue = double.Parse(reader["AmountDue"].ToString());
                    receipt.TransDate = DateTime.Parse(reader["TransDate"].ToString());

                    receipt.PurchasedItems = GetTempPurchasedItems(receipt.ORNumber);
                    receipt.SeniorDiscount = double.Parse(reader["Discount"].ToString());
                    try
                    {
                        if (reader["itemdiscount"] != DBNull.Value)
                            receipt.WholeSaleDiscount = double.Parse(reader["ItemDiscount"].ToString());
                    }
                    catch { }
                    lstReceipt.Add(receipt);
                }
            }
            if (!reader.IsClosed) reader.Close();

            return lstReceipt;
        }

        public List<Receipt> GetReceiptInfo( DateTime startdate, DateTime enddate, string cashier, bool includepurchases = true )
        {
            List<Receipt> lstReceipt = new List<Receipt>();
            string sql = String.Format("Select * from view_Receipt WHERE TransDate >= #{0:yyyy/MM/dd 06:00:00}# and TransDate<= #{1:yyyy/MM/dd 06:00:00}# and Deleted=0 and CustomerName like '%{2}%' Order By TransDate Asc", startdate, enddate, cashier);
            OleDbCommand cmd = new OleDbCommand(sql, con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query

            if (reader.HasRows) // if can read row from database `
            {
                while (reader.Read())
                {
                    Receipt receipt = new Receipt();
                    receipt.ORNumber = int.Parse(reader["ORNumber"].ToString());
                    receipt.CashierName = reader["CustomerName"].ToString();
                    receipt.CashTendered = double.Parse(reader["CashTendered"].ToString());
                    receipt.DbAmountDue = double.Parse(reader["AmountDue"].ToString());
                    receipt.TransDate = DateTime.Parse(reader["TransDate"].ToString());

                    receipt.PurchasedItems = (includepurchases ? GetPurchasedItems(receipt.ORNumber) : new Dictionary<string, clsPurchasedItem>());
                    receipt.SeniorDiscount = double.Parse(reader["Discount"].ToString());
                    receipt.AccountName = reader["AccountName"].ToString();
                    try
                    {
                        if (reader["itemdiscount"] != DBNull.Value)
                            receipt.WholeSaleDiscount = double.Parse(reader["ItemDiscount"].ToString());
                    }
                    catch { }
                    lstReceipt.Add(receipt);
                }
            }
            if (!reader.IsClosed) reader.Close();

            return lstReceipt;
        }

        public List<double> GetSalesInfo( DateTime startdate, DateTime enddate, string cashier )
        {
            List<double> ret = new List<double>();
            double totsales = 0, totcharges = 0, totalincome = 0, totaldiscount = 0, totAddlDisc = 0;
            string sql = "";

            if (cashier == "")
                sql = String.Format("Select sum(AmountDue) from Receipt WHERE TransDate between #{0:yyyy/MM/dd 06:00:00}# and #{1:yyyy/MM/dd 06:00:00}# and deleted=0", startdate, enddate);
            else
                sql = String.Format("Select sum(AmountDue) from Receipt WHERE TransDate between #{0:yyyy/MM/dd 06:00:00}# and #{1:yyyy/MM/dd 06:00:00}# and CustomerName = '{2}' and deleted=0", startdate, enddate, cashier);
            OleDbCommand cmd = new OleDbCommand(sql, con); // creating query command
            object obj = cmd.ExecuteScalar(); // executes query
            if (obj != null && obj != DBNull.Value)
            {
                totsales = Convert.ToDouble(obj);
            }

            if (cashier == "")
                sql = String.Format("Select sum(discount*qty) from view_transaction WHERE TransDate between #{0:yyyy/MM/dd 06:00:00}# and #{1:yyyy/MM/dd 06:00:00}# and deleted=0", startdate, enddate);
            else
                sql = String.Format("Select sum(discount*qty) from view_transaction WHERE TransDate between #{0:yyyy/MM/dd 06:00:00}# and #{1:yyyy/MM/dd 06:00:00}# and UserName = '{2}' and deleted=0", startdate, enddate, cashier);
            cmd = new OleDbCommand(sql, con); // creating query command
            obj = cmd.ExecuteScalar(); // executes query
            if (obj != null && obj != DBNull.Value)
            {
                totaldiscount = Convert.ToDouble(obj);
            }


            if (cashier == "")
                sql = String.Format("Select sum(discount) from receipt WHERE TransDate between #{0:yyyy/MM/dd 06:00:00}# and #{1:yyyy/MM/dd 06:00:00}# and deleted=0", startdate, enddate);
            else
                sql = String.Format("Select sum(discount) from receipt WHERE TransDate between #{0:yyyy/MM/dd 06:00:00}# and #{1:yyyy/MM/dd 06:00:00}# and CustomerName = '{2}' and deleted=0", startdate, enddate, cashier);
            cmd = new OleDbCommand(sql, con); // creating query command
            obj = cmd.ExecuteScalar(); // executes query
            if (obj != null && obj != DBNull.Value)
            {
                totAddlDisc = Convert.ToDouble(obj);
            }


            if (cashier == "")
                sql = String.Format("Select sum((amount-discount-capital)*qty) from view_transaction WHERE TransDate between #{0:yyyy/MM/dd 06:00:00}# and #{1:yyyy/MM/dd 06:00:00}# and deleted=0", startdate, enddate);
            else
                sql = String.Format("Select sum((amount-discount-capital)*qty) from view_transaction WHERE TransDate between #{0:yyyy/MM/dd 06:00:00}# and #{1:yyyy/MM/dd 06:00:00}# and UserName = '{2}' and deleted=0", startdate, enddate, cashier);
            cmd = new OleDbCommand(sql, con); // creating query command
            obj = cmd.ExecuteScalar(); // executes query
            if (obj != null && obj != DBNull.Value)
            {
                totalincome = Math.Round(Convert.ToDouble(obj), 2) - totAddlDisc;
            }
            if (cashier == "")
                sql = String.Format("Select sum(charged_amount) from view_chargetransactions WHERE [timestamp] >= #{0:yyyy/MM/dd 06:00:00}# and [timestamp]<= #{1:yyyy/MM/dd 06:00:00}# and Deleted=0", startdate, enddate);
            else
                sql = String.Format("Select sum(charged_amount) from view_chargetransactions WHERE [timestamp] >= #{0:yyyy/MM/dd 06:00:00}# and [timestamp]<= #{1:yyyy/MM/dd 06:00:00}# and Deleted=0 and LoginName = '{2}'", startdate, enddate, cashier);
            cmd = new OleDbCommand(sql, con); // creating query command
            obj = cmd.ExecuteScalar(); // executes query
            if (obj != null && obj != DBNull.Value)
            {
                totcharges = Math.Round(Convert.ToDouble(obj), 2);
            }
            ret.Add(totsales - totcharges);
            ret.Add(totcharges);
            ret.Add(totalincome);
            ret.Add(totaldiscount + totAddlDisc);
            return ret;
        }

        public Int32 GetSoldItems( string barcode )
        {
            if (con.State == ConnectionState.Closed) con.Open();
            string sql = String.Format("Select sum(qty) from TransactionHistory WHERE barcode='{0}' and Deleted=0", barcode);
            OleDbCommand cmd = new OleDbCommand(sql, con); // creating query command
            object obj = cmd.ExecuteScalar(); // executes query
            if (obj == DBNull.Value) return 0;
            Int32 ret = Convert.ToInt32(obj);
            return ret;
        }


        public static Int32 GetNextORNumber()
        {
            string sql = String.Format("Select ORNumber from Receipt order by ORNumber Desc");
            OleDbConnection con = new OleDbConnection(Properties.Settings.Default.dbConnectionString1 + "Jet OLEDB:Database Password=@Lr3yP0$dB;");  // connection string change database name and password here.
            con.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand(sql, con); // creating query command
                OleDbDataReader reader = cmd.ExecuteReader(); // executes query
                if (reader.HasRows == true && reader.Read()) // if can read row from database
                {
                    Int32 ret = Int32.Parse(reader["ORNumber"].ToString()) + 1;
                    if (!reader.IsClosed) reader.Close();
                    con.Close();
                    return ret;
                }
                if (!reader.IsClosed) reader.Close();
            }
            catch { }
            con.Close();
            return 1;
        }

        public static Int32 GetNextSKU()
        {
            string sql = String.Format("Select SKU_ID from SKU order by ID Desc");
            OleDbConnection con = new OleDbConnection(Properties.Settings.Default.dbConnectionString1 + "Jet OLEDB:Database Password=@Lr3yP0$dB;");  // connection string change database name and password here.
            con.Open();

            OleDbCommand cmd = new OleDbCommand(sql, con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            try
            {
                if (reader.HasRows == true && reader.Read()) // if can read row from database
                {
                    Int32 ret = Int32.Parse(reader["SKU_ID"].ToString()) + 1;
                    if (!reader.IsClosed) reader.Close();
                    cmd = new OleDbCommand(string.Format("Update SKU set SKU_ID={0}", ret), con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return ret;
                }
                else
                {
                    cmd = new OleDbCommand(string.Format("Insert Into SKU(SKU_ID) VALUES({0})", 1), con);
                    cmd.ExecuteNonQuery();
                }
            }
            catch { }
            if (!reader.IsClosed) reader.Close();
            con.Close();
            return 1;
        }

        public double GetTotalQtySold( string barcode )
        {
            double totalqty = 0;
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();
                OleDbCommand cmd = new OleDbCommand("Select sum(qty) as TotalQty from transactionhistory WHERE barcode = '" + barcode.Replace("'", "''") + "' AND Deleted=0", con); // creating query command
                OleDbDataReader reader = cmd.ExecuteReader(); // executes query
                if (reader.HasRows) // if can read row from database
                {
                    reader.Read();
                    try
                    {
                        totalqty = Convert.ToDouble(reader["TotalQty"].ToString());
                    }
                    catch { }
                }
                if (!reader.IsClosed) reader.Close();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
            return totalqty;
        }
        private Dictionary<string, clsPurchasedItem> GetPurchasedItems( Int32 ORNum )
        {
            Dictionary<string, clsPurchasedItem> dicPurchasedItems = new Dictionary<string, clsPurchasedItem>();
            string sql = string.Format("Select * from view_transaction3 where ORNumber = {0} and Deleted=0 ", ORNum);
            OleDbCommand cmd = new OleDbCommand(sql, con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            if (reader.HasRows)
            {
                while (reader.Read()) // if can read row from database
                {
                    clsPurchasedItem item = new clsPurchasedItem();
                    item.ORNumber = ORNum;
                    int id = int.Parse(reader["id"].ToString());
                    item.BarCode = reader["Barcode"].ToString();
                    item.Description = reader["Description"].ToString();
                    item.Amount = double.Parse(reader["Amount"].ToString());
                    item.Qty = double.Parse(reader["Qty"].ToString());
                    item.Unit = reader["unit"].ToString();
                    try
                    {
                        item.InStorage = int.Parse(reader["instorage"].ToString());
                    }
                    catch { }
                    item.IsWholeSale = int.Parse(reader["IsWholeSale"].ToString()) == 1 ? true : false;
                    item.UserID = int.Parse(reader["UserID"].ToString());
                    item.UserName = reader["UserName"].ToString();
                    item.Discount = double.Parse(reader["Discount"].ToString());
                    item.Capital = double.Parse(reader["Capital"].ToString());
                    item.Account = reader["AccountName"].ToString();

                    //item.Category = reader["Category"].ToString();

                    if (dicPurchasedItems.ContainsKey(item.BarCode) == false) dicPurchasedItems.Add(item.BarCode, item);
                    //else
                    //{
                    //    dicPurchasedItems[item.BarCode].Qty += item.Qty;
                    //}
                }
            }
            if (!reader.IsClosed) reader.Close();
            return dicPurchasedItems;
        }

        public List<clsPurchasedItem> GetTransactionsFrmDate( DateTime startDate, DateTime endDate )
        {
            List<clsPurchasedItem> dicPurchasedItems = new List<clsPurchasedItem>();
            string sql = string.Format("Select * from view_transaction3 where transdate between #{0}# and #{1}# and Deleted=0 ", startDate, endDate);
            OleDbCommand cmd = new OleDbCommand(sql, con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            if (reader.HasRows)
            {
                while (reader.Read()) // if can read row from database
                {
                    clsPurchasedItem item = new clsPurchasedItem();
                    item.ORNumber = int.Parse(reader["ORNumber"].ToString()); ;
                    int id = int.Parse(reader["id"].ToString());
                    item.BarCode = reader["Barcode"].ToString();
                    item.Description = reader["Description"].ToString();
                    item.Amount = double.Parse(reader["Amount"].ToString());
                    item.Qty = double.Parse(reader["Qty"].ToString());
                    item.Unit = reader["unit"].ToString();
                    try
                    {
                        item.InStorage = int.Parse(reader["instorage"].ToString());
                    }
                    catch { }
                    item.IsWholeSale = int.Parse(reader["IsWholeSale"].ToString()) == 1 ? true : false;
                    item.UserID = int.Parse(reader["UserID"].ToString());
                    item.UserName = reader["UserName"].ToString();
                    item.Discount = double.Parse(reader["Discount"].ToString());
                    item.Capital = double.Parse(reader["Capital"].ToString());
                    item.Account = reader["AccountName"].ToString();
                    dicPurchasedItems.Add(item);
                }
            }
            if (!reader.IsClosed) reader.Close();
            return dicPurchasedItems;
        }

        private Dictionary<string, clsPurchasedItem> GetTempPurchasedItems( Int32 ORNum )
        {
            Dictionary<string, clsPurchasedItem> dicPurchasedItems = new Dictionary<string, clsPurchasedItem>();
            string sql = string.Format("Select * from view_temptransaction where ORNumber = {0} and Deleted=0 ", ORNum);
            OleDbCommand cmd = new OleDbCommand(sql, con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            if (reader.HasRows)
            {
                while (reader.Read()) // if can read row from database
                {
                    clsPurchasedItem item = new clsPurchasedItem();
                    item.ORNumber = ORNum;
                    int id = int.Parse(reader["id"].ToString());
                    item.BarCode = reader["Barcode"].ToString();
                    item.Description = reader["Description"].ToString();
                    item.Amount = double.Parse(reader["Amount"].ToString());
                    item.Qty = double.Parse(reader["Qty"].ToString());
                    item.Unit = reader["unit"].ToString();
                    try
                    {
                        item.InStorage = int.Parse(reader["instorage"].ToString());
                    }
                    catch { }
                    item.IsWholeSale = int.Parse(reader["IsWholeSale"].ToString()) == 1 ? true : false;
                    item.UserID = int.Parse(reader["UserID"].ToString());
                    item.UserName = reader["UserName"].ToString();
                    item.Discount = double.Parse(reader["Discount"].ToString());
                    item.Capital = double.Parse(reader["Capital"].ToString());
                    item.Category = reader["Category"].ToString();

                    if (dicPurchasedItems.ContainsKey(item.BarCode) == false) dicPurchasedItems.Add(item.BarCode, item);
                    //else
                    //{
                    //    dicPurchasedItems[item.BarCode].Qty += item.Qty;
                    //}
                }
            }
            if (!reader.IsClosed) reader.Close();
            return dicPurchasedItems;
        }

        public Dictionary<string, clsPurchasedItem> GetProductSales( DateTime dateStart, DateTime dateEnd, string username = "" )
        {
            Dictionary<string, clsPurchasedItem> dicPurchasedItems = new Dictionary<string, clsPurchasedItem>();
            string sql = String.Format("Select * from view_transaction WHERE TransDate between #{0:yyyy/MM/dd 06:00:00}# and #{1:yyyy/MM/dd 06:00:00}# and deleted = 0 Order by Barcode", dateStart, dateEnd, username);

            OleDbCommand cmd = new OleDbCommand(sql, con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            if (reader.HasRows)
            {
                while (reader.Read()) // if can read row from database
                {
                    clsPurchasedItem item = new clsPurchasedItem();
                    int id = int.Parse(reader["id"].ToString());
                    item.ORNumber = int.Parse(reader["ORNumber"].ToString());
                    item.BarCode = reader["Barcode"].ToString();
                    item.Description = reader["Description"].ToString();
                    item.Amount = double.Parse(reader["Amount"].ToString());
                    item.Qty = double.Parse(reader["Qty"].ToString());
                    item.Unit = reader["unit"].ToString();
                    try
                    {
                        item.InStorage = int.Parse(reader["instorage"].ToString());
                    }
                    catch { }
                    item.IsWholeSale = int.Parse(reader["IsWholeSale"].ToString()) == 1 ? true : false;
                    item.UserID = int.Parse(reader["UserID"].ToString());
                    item.UserName = reader["UserName"].ToString();
                    item.Discount = double.Parse(reader["Discount"].ToString());
                    item.Capital = double.Parse(reader["Capital"].ToString());
                    item.Category = reader["Category"].ToString();

                    if (dicPurchasedItems.ContainsKey(item.BarCode) == false) dicPurchasedItems.Add(item.BarCode, item);
                    else
                    {
                        dicPurchasedItems[item.BarCode].Qty += item.Qty;
                    }
                }
            }
            if (!reader.IsClosed) reader.Close();
            return dicPurchasedItems;
        }

        public bool UserNameExists( string username )
        {
            OleDbCommand cmd = new OleDbCommand(string.Format("Select LoginName from UserAccount where LoginName = '{0}'", username), con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            bool ret = reader.HasRows;
            reader.Close();
            con.Close();
            return ret;

        }
        public static bool HaveAdmin()
        {
            try
            {
                OleDbConnection con = new OleDbConnection(Properties.Settings.Default.dbConnectionString1 + "Jet OLEDB:Database Password=@Lr3yP0$dB;");  // connection string change database name and password here.
                con.Open();

                string sql = string.Format("Select * from UserAccount where LoginType=1 AND Enabled=1");
                OleDbCommand cmd = new OleDbCommand(sql, con); // creating query command
                OleDbDataReader reader = cmd.ExecuteReader(); // executes query
                bool ret = reader.HasRows;
                reader.Close();
                con.Close();
                return ret;
            }
            catch
            {
                throw new Exception("Unable to connect to database. Please contact Admin");
            }

        }

        public clsUsers Login( string username, string password )
        {
            string sql = string.Format("Select * from UserAccount where LoginName = '{0}' and Password = '{1}'", username, License.POSLicense.EncryptPassword(password));
            OleDbCommand cmd = new OleDbCommand(sql, con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            clsUsers user = new clsUsers();
            if (reader.HasRows)
            {
                reader.Read();
                user.UserId = Convert.ToInt32(reader["UserId"].ToString());
                user.UserName = reader["LoginName"].ToString();
                user.Password = reader["Password"].ToString();
                user.LoginType = Convert.ToInt32(reader["LoginType"].ToString());
                user.Enabled = Convert.ToInt16(reader["Enabled"].ToString()) == 1 ? true : false;
                user.LogInAttempt = Convert.ToInt32(reader["LoginAttemp"].ToString());
            }
            reader.Close();
            return user;
        }
        public List<string> GetUser()
        {
            string sql = string.Format("Select * from UserAccount where Enabled=1");
            OleDbCommand cmd = new OleDbCommand(sql, con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            List<string> users = new List<string>();
            if (reader.HasRows)
            {
                while (reader.Read())
                    users.Add(reader["LoginName"].ToString());
            }
            reader.Close();
            return users;
        }
        public List<clsUsers> GetUsers()
        {
            string sql = string.Format("Select * from UserAccount");
            OleDbCommand cmd = new OleDbCommand(sql, con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            List<clsUsers> users = new List<clsUsers>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    clsUsers user = new clsUsers();
                    user.UserId = Convert.ToInt32(reader["UserId"].ToString());
                    user.UserName = reader["LoginName"].ToString();
                    user.LoginType = Convert.ToInt32(reader["LoginType"]);
                    user.Enabled = Convert.ToInt32(reader["Enabled"]) == 1 ? true : false;
                    user.Password = "";
                    users.Add(user);
                }
            }
            reader.Close();
            return users;
        }
        public bool SaveUser( clsUsers user )
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand(String.Format("Select * from UserAccount where LoginName = '{0}'", user.UserName), con);
                if (cmd.ExecuteReader().HasRows == false)
                {
                    string sql = String.Format("Insert Into UserAccount ([LoginType],[LoginName],[Password],[Enabled],[LoginAttemp]) VALUES({0},'{1}','{2}',{3},{4})", user.LoginType, user.UserName, License.POSLicense.EncryptPassword(user.Password), user.Enabled ? 1 : 0, user.LogInAttempt);
                    cmd = new OleDbCommand(sql, con); // creating query command

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                }
                else
                {

                    string sql = "";
                    if (user.Password != "")
                    {
                        sql = String.Format("Update UserAccount Set [LoginType] = {0}, [Password]= '{1}', [Enabled]={2},[LoginAttemp]={3},[LoginName] ='{4}' WHERE [LoginName] ='{4}'", user.LoginType, License.POSLicense.EncryptPassword(user.Password), user.Enabled ? 1 : 0, user.LogInAttempt, user.UserName);
                    }
                    else
                    {
                        sql = String.Format("Update UserAccount Set [LoginType] = {0}, [Enabled]={1},[LoginAttemp]={2} WHERE [LoginName] ='{3}'", user.LoginType, user.Enabled ? 1 : 0, user.LogInAttempt, user.UserName);
                    }

                    cmd = new OleDbCommand(sql, con); // creating query command

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);  // shows exception message in console if any errors occured
            }
            return false;
        }

        public bool SaveExpenses( clsExpenses expenses )
        {
            try
            {
                OleDbCommand cmd = null;
                string sql = "";
                if (expenses.Expense_id > 0)
                {
                    sql = String.Format("Update expenses set [Description]='{0}',[Amount]={1} where expense_id = {2}", expenses.Description, expenses.Amount, expenses.Expense_id);
                    cmd = new OleDbCommand(sql, con); // creating query command

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                }
                else
                {
                    sql = String.Format("Insert Into expenses ([Description],[Amount],[UserId],[UserName],[Timestamp],[Deleted]) VALUES('{0}',{1},{2},'{3}','{4}',0)", expenses.Description, expenses.Amount, expenses.UserId, expenses.UserName, expenses.Timestamp);
                    cmd = new OleDbCommand(sql, con); // creating query command

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);  // shows exception message in console if any errors occured
            }
            return false;
        }




        public bool DeleteExpenses( Int32 ExpenseId )
        {
            try
            {
                OleDbCommand cmd = null;
                cmd = new OleDbCommand(String.Format("Update expenses Set Deleted=1 Where expense_id={0}", ExpenseId), con);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return false;
        }

        public List<clsExpenses> GetExpenses( DateTime dateStart, DateTime dateEnd, string username = "" )
        {
            OleDbCommand cmd = null;
            if (username == "")
                cmd = new OleDbCommand(string.Format("Select * from expenses WHERE [timestamp] between #{0} 06:00:00# and #{1} 06:00:00# and Deleted=0", dateStart.ToString("yyyy-MM-dd"), dateEnd.ToString("yyyy-MM-dd")), con); // creating query command
            else
                cmd = new OleDbCommand(string.Format("Select * from expenses WHERE [timestamp] between #{0} 06:00:00# and #{1} 06:00:00# and Deleted=0 and username='{2}'", dateStart.ToString("yyyy-MM-dd"), dateEnd.ToString("yyyy-MM-dd"), username), con); // creating query command

            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            List<clsExpenses> lstExp = new List<clsExpenses>();
            if (reader.HasRows)
            {
                while (reader.Read()) // if can read row from database
                {
                    try
                    {
                        clsExpenses expenses = new clsExpenses();
                        expenses.Expense_id = int.Parse(reader["expense_id"].ToString());
                        expenses.Description = reader["description"].ToString();
                        expenses.Amount = double.Parse(reader["amount"].ToString());
                        expenses.UserId = int.Parse(reader["userid"].ToString());
                        expenses.UserName = reader["username"].ToString();
                        expenses.Timestamp = DateTime.Parse(reader["timestamp"].ToString());
                        lstExp.Add(expenses);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            if (!reader.IsClosed) reader.Close();
            return lstExp;
        }


        public double GetTotalExpenses( DateTime dateStart, DateTime dateEnd, string username = "" )
        {
            OleDbCommand cmd = null;
            double ret = 0;
            try
            {
                if (username == "")
                    cmd = new OleDbCommand(string.Format("Select sum(amount) as Total from expenses WHERE [timestamp] between #{0} 06:00:00# and #{1} 06:00:00# and Deleted=0", dateStart.ToString("yyyy-MM-dd"), dateEnd.ToString("yyyy-MM-dd")), con); // creating query command
                else
                    cmd = new OleDbCommand(string.Format("Select sum(amount) as Total from expenses WHERE [timestamp] between #{0} 06:00:00# and #{1} 06:00:00# and Deleted=0 and username='{2}'", dateStart.ToString("yyyy-MM-dd"), dateEnd.ToString("yyyy-MM-dd"), username), con); // creating query command

                object obj = cmd.ExecuteScalar(); // executes query
                if (obj != null && obj != DBNull.Value)
                    ret = Convert.ToDouble(obj);
            }
            catch { }

            return ret;
        }

        public bool SaveInitialCash( clsInitCash initCash )
        {
            try
            {
                OleDbCommand cmd = null;

                string sql = String.Format("Select id from initialcash where timestamp between #{0} 06:00:00# and #{1} 06:00:00# and userid={2}", initCash.Timestamp.ToString("yyyy-MM-dd"), initCash.Timestamp.AddDays(1).ToString("yyyy-MM-dd"), initCash.UserId);
                cmd = new OleDbCommand(sql, con); // creating query command
                object obj = cmd.ExecuteScalar();
                if (obj != DBNull.Value && obj != null)
                {
                    int id = Convert.ToInt16(obj);
                    if (id > 0)
                    {
                        sql = String.Format("Update initialcash set amount = {0}, [Timestamp] ='{1:yyyy-MM-dd HH:mm:ss}' where id={2}", initCash.Amount, DateTime.Now, id);
                        cmd = new OleDbCommand(sql, con); // creating query command

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    sql = String.Format("Insert Into initialcash ([Amount],[UserId],[UserName],[Timestamp],[Deleted]) VALUES({0},{1},'{2}','{3}',0)", initCash.Amount, initCash.UserId, initCash.UserName, DateTime.Now);
                    cmd = new OleDbCommand(sql, con); // creating query command

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);  // shows exception message in console if any errors occured
            }
            return false;
        }

        public bool DeleteInitialCash( Int32 initCashId )
        {
            try
            {
                OleDbCommand cmd = null;
                cmd = new OleDbCommand(String.Format("Update initialcash Set Deleted=1 Where id={0}", initCashId), con);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return false;
        }

        public double GetInitialCash( DateTime date, int userid )
        {
            double amount = 0;
            string sql = string.Format("Select * from initialcash WHERE [timestamp] >= #{0} 06:00:00# and [timestamp] <= #{1} 06:00:00# and userid={2} and Deleted=0", date.ToString("yyyy-MM-dd"), date.AddDays(1).ToString("yyyy-MM-dd"), userid);
            OleDbCommand cmd = new OleDbCommand(sql, con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            if (reader.HasRows)
            {
                while (reader.Read()) // if can read row from database
                {
                    try
                    {
                        amount += double.Parse(reader["amount"].ToString());
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            if (!reader.IsClosed) reader.Close();
            return amount;
        }

        public double GetInitialCash( DateTime date, string username )
        {
            double amount = 0;
            string sql = string.Format("Select * from initialcash WHERE [timestamp] >= #{0} 06:00:00# and [timestamp] <= #{1} 06:00:00# and username='{2}' and Deleted=0", date.ToString("yyyy-MM-dd"), date.AddDays(1).ToString("yyyy-MM-dd"), username);
            OleDbCommand cmd = new OleDbCommand(sql, con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            if (reader.HasRows)
            {
                while (reader.Read()) // if can read row from database
                {
                    try
                    {
                        amount += double.Parse(reader["amount"].ToString());
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            if (!reader.IsClosed) reader.Close();
            return amount;
        }


        public bool SaveDepositCash( clsDepositCash initCash )
        {
            try
            {
                OleDbCommand cmd = null;

                string sql = String.Format("Select id from Depositcash where timestamp between #{0} 06:00:00# and #{1} 06:00:00# and userid={2}", initCash.Timestamp.ToString("yyyy-MM-dd"), initCash.Timestamp.AddDays(1).ToString("yyyy-MM-dd"), initCash.UserId);
                cmd = new OleDbCommand(sql, con); // creating query command
                object obj = cmd.ExecuteScalar();
                if (obj != DBNull.Value && obj != null)
                {
                    int id = Convert.ToInt16(obj);
                    if (id > 0)
                    {
                        sql = String.Format("Update Depositcash set amount = {0}, [Timestamp] ='{1:yyyy-MM-dd HH:mm:ss}' where id={2}", initCash.Amount, DateTime.Now, id);
                        cmd = new OleDbCommand(sql, con); // creating query command

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    sql = String.Format("Insert Into Depositcash ([Amount],[UserId],[UserName],[Timestamp],[Deleted]) VALUES({0},{1},'{2}','{3}',0)", initCash.Amount, initCash.UserId, initCash.UserName, DateTime.Now);
                    cmd = new OleDbCommand(sql, con); // creating query command

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);  // shows exception message in console if any errors occured
            }
            return false;
        }

        public bool DeleteDepositCash( Int32 initCashId )
        {
            try
            {
                OleDbCommand cmd = null;
                cmd = new OleDbCommand(String.Format("Update Depositcash Set Deleted=1 Where id={0}", initCashId), con);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return false;
        }
        public List<clsDepositCash> GetAllDepositCash( )
        {
            List<clsDepositCash> lstDeposit = new List<clsDepositCash>();
            string sql = string.Format("Select * from Depositcash");
            OleDbCommand cmd = new OleDbCommand(sql, con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            if (reader.HasRows)
            {
                while (reader.Read()) // if can read row from database
                {
                    try
                    {
                        clsDepositCash depo = new clsDepositCash();
                        depo.Amount = double.Parse(reader["amount"].ToString());
                        depo.Id = Int32.Parse(reader["id"].ToString());
                        depo.Timestamp = Convert.ToDateTime(reader["timestamp"]);
                        depo.UserId = Convert.ToInt32(reader["userid"]);
                        depo.UserName = reader["username"].ToString();
                        lstDeposit.Add(depo);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            if (!reader.IsClosed) reader.Close();
            return lstDeposit;
        }

        public double GetDepositCash( DateTime date, int userid )
        {
            double amount = 0;
            string sql = string.Format("Select * from Depositcash WHERE [timestamp] >= #{0} 06:00:00# and [timestamp] <= #{1} 06:00:00# and userid={2} and Deleted=0", date.ToString("yyyy-MM-dd"), date.AddDays(1).ToString("yyyy-MM-dd"), userid);
            OleDbCommand cmd = new OleDbCommand(sql, con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            if (reader.HasRows)
            {
                while (reader.Read()) // if can read row from database
                {
                    try
                    {
                        amount += double.Parse(reader["amount"].ToString());
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            if (!reader.IsClosed) reader.Close();
            return amount;
        }

        public double GetDepositCash( DateTime date, string username )
        {
            double amount = 0;
            string sql = string.Format("Select * from Depositcash WHERE [timestamp] >= #{0} 06:00:00# and [timestamp] <= #{1} 06:00:00# and username='{2}' and Deleted=0", date.ToString("yyyy-MM-dd"), date.AddDays(1).ToString("yyyy-MM-dd"), username);
            OleDbCommand cmd = new OleDbCommand(sql, con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            if (reader.HasRows)
            {
                while (reader.Read()) // if can read row from database
                {
                    try
                    {
                        amount += double.Parse(reader["amount"].ToString());
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            if (!reader.IsClosed) reader.Close();
            return amount;
        }


        public double GetActualCOH( DateTime date, string username )
        {
            double amount = 0;
            string sql = string.Format("Select Top 1 * from checkout WHERE [timeout] = #{0} 00:00:00# and username='{1}'", date.ToString("yyyy-MM-dd"), username);
            OleDbCommand cmd = new OleDbCommand(sql, con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            if (reader.HasRows)
            {
                if (reader.Read()) // if can read row from database
                {
                    try
                    {
                        amount = double.Parse(reader["actualcash"].ToString());
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            if (!reader.IsClosed) reader.Close();
            return amount;
        }
        public bool SaveCheckOut( clsCheckOut chkout )
        {
            try
            {
                OleDbCommand cmd = null;

                string sql = String.Format("Select checkout_id from CheckOut where timeout =#{0} 00:00:00# and userid={1}", chkout.Timestamp.ToString("yyyy-MM-dd"), chkout.UserId);
                cmd = new OleDbCommand(sql, con); // creating query command
                object obj = cmd.ExecuteScalar();
                if (obj != DBNull.Value && obj != null)
                {
                    int id = Convert.ToInt16(obj);
                    if (id > 0)
                    {
                        sql = String.Format("Update checkout set expectedcash = {0}, actualcash = {1}, [timeout] =#{2:yyyy-MM-dd} 00:00:00# where checkout_id={3}", chkout.ExpectedAmount, chkout.ActualAmount, chkout.Timestamp, id);
                        cmd = new OleDbCommand(sql, con); // creating query command

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    sql = String.Format("Insert Into checkout ([expectedcash],[actualcash],[UserId],[UserName],[timeout]) VALUES({0},{1},{2},'{3}','{4:yyyy-MM-dd} 00:00:00')", chkout.ExpectedAmount, chkout.ActualAmount, chkout.UserId, chkout.UserName, chkout.Timestamp);
                    cmd = new OleDbCommand(sql, con); // creating query command

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);  // shows exception message in console if any errors occured
            }
            return false;
        }
        public List<clsCheckOut> GetAllCheckOut()
        {
            OleDbCommand cmd = null;
            cmd = new OleDbCommand(string.Format("Select * from checkout order by checkout_id"), con); // creating query command

            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            List<clsCheckOut> lstExp = new List<clsCheckOut>();
            if (reader.HasRows)
            {
                while (reader.Read()) // if can read row from database
                {
                    try
                    {
                        clsCheckOut expenses = new clsCheckOut();
                        expenses.Id = int.Parse(reader["checkout_id"].ToString());
                        expenses.ExpectedAmount = double.Parse(reader["ExpectedCash"].ToString());
                        expenses.ActualAmount = double.Parse(reader["ActualCash"].ToString());
                        expenses.UserId = int.Parse(reader["userid"].ToString());
                        expenses.UserName = reader["username"].ToString();
                        expenses.Timestamp = DateTime.Parse(reader["timeout"].ToString());
                        lstExp.Add(expenses);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            if (!reader.IsClosed) reader.Close();
            return lstExp;
        }

        public List<clsCheckOut> GetCheckOut( DateTime dateStart, DateTime dateEnd, int userid = 0 )
        {
            OleDbCommand cmd = null;
            if (userid == 0)
                cmd = new OleDbCommand(string.Format("Select * from checkout WHERE [timeout] = #{0} 00:00:00# ", dateStart.ToString("yyyy-MM-dd")), con); // creating query command
            else
                cmd = new OleDbCommand(string.Format("Select * from checkout WHERE [timeout] = #{0} 00:00:00# and userid={1}", dateStart.ToString("yyyy-MM-dd"), userid), con); // creating query command

            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            List<clsCheckOut> lstExp = new List<clsCheckOut>();
            if (reader.HasRows)
            {
                while (reader.Read()) // if can read row from database
                {
                    try
                    {
                        clsCheckOut expenses = new clsCheckOut();
                        expenses.Id = int.Parse(reader["checkout_id"].ToString());
                        expenses.ExpectedAmount = double.Parse(reader["ExpectedCash"].ToString());
                        expenses.ActualAmount = double.Parse(reader["ActualCash"].ToString());
                        expenses.UserId = int.Parse(reader["userid"].ToString());
                        expenses.UserName = reader["username"].ToString();
                        expenses.Timestamp = DateTime.Parse(reader["timeout"].ToString());
                        lstExp.Add(expenses);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            if (!reader.IsClosed) reader.Close();
            return lstExp;
        }
        public static bool AddCategory( string Category )
        {
            string sql = string.Format("Select TOP 1 categoryid from Categories where description='" + Category + "'");
            bool ret = false;
            OleDbConnection con = new OleDbConnection(Properties.Settings.Default.dbConnectionString1 + "Jet OLEDB:Database Password=@Lr3yP0$dB;");  // connection string change database name and password here.
            con.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand(sql, con); // creating query command
                object obj = cmd.ExecuteScalar(); // executes query;
                if (obj != null && obj != DBNull.Value)
                {
                    ret = false;
                }
                else
                {
                    cmd = new OleDbCommand("INSERT INTO Categories (description) VALUES('" + Category + "')", con);
                    if (cmd.ExecuteNonQuery() > 0) ret = true;
                    else ret = false;
                }
            }
            catch { }

            con.Close();
            return ret;
        }

        public static bool DeleteCategory( int id )
        {
            bool ret = false;
            OleDbConnection con = new OleDbConnection(Properties.Settings.Default.dbConnectionString1 + "Jet OLEDB:Database Password=@Lr3yP0$dB;");  // connection string change database name and password here.
            con.Open();
            try
            {
                string sql = string.Format("DELETE from Categories where categoryid=" + id.ToString());
                OleDbCommand cmd = new OleDbCommand(sql, con); // creating query command
                if (cmd.ExecuteNonQuery() > 0) ret = true;
            }
            catch { }

            con.Close();
            return ret;
        }
        public static Dictionary<int, string> GetCategories()
        {
            string sql = string.Format("Select * from Categories");
            OleDbConnection con = new OleDbConnection(Properties.Settings.Default.dbConnectionString1 + "Jet OLEDB:Database Password=@Lr3yP0$dB;");  // connection string change database name and password here.
            con.Open();

            OleDbCommand cmd = new OleDbCommand(sql, con); // creating query command
            OleDbDataReader reader = cmd.ExecuteReader(); // executes query
            Dictionary<int, string> Categories = new Dictionary<int, string>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Categories.Add(Convert.ToInt32(reader["categoryid"].ToString()), reader["description"].ToString());
                }
            }
            if (reader != null) reader.Close();
            con.Close();
            return Categories;
        }
    }

}
