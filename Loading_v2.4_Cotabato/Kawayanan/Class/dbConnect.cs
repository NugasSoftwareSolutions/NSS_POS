using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Xml.Serialization;
using MySql.Data.MySqlClient;
using System.IO;
using AlreySolutions.Class.Load;

namespace AlreySolutions.Class
{
    class dbConnect
    {
        MySqlConnection con = null;
        public const string DBPassword="@Lr3yP0$dB";
        public dbConnect()
        {
            try
            {
                con = new MySqlConnection(Properties.Settings.Default.dbConnectionString1 + string.Format("Password={0};",DBPassword));  // connection string change database name and password here.
                con.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetDatabaseName()
        {
            return con.DataSource;
        }
        public void Close()
        {
            if(con.State== ConnectionState.Open)
                con.Close();
        }

        public bool SaveChargedLoadTransaction(clsChargedLoadTrans charge)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            bool ret = false;
            MySqlCommand  cmd = new MySqlCommand ("Select chargeid from _chargeloadtransaction WHERE chargeid = " + charge.ChargeID.ToString() + " AND Deleted=0", con); // creating query command
            try
            {
                object obj = cmd.ExecuteScalar(); // executes query
                string sql = "";
                if (obj != null && obj != DBNull.Value) // if can read row from database
                {
                    sql = string.Format("Update _chargeloadtransaction set loadid={0},id_subdaccount={1},loadwallettrans_id={2},charged_amount={3},user_id={4},timestamp='{5}',deleted = 0,prev_balance={6},curr_balance={7},trans_balance={8},trans_amount = {9} where chargeid = {10}", charge.LoadId, charge.Id_SubDAccount,charge.LoadWalletTransId, charge.ChargedAmount, charge.User_Id, charge.Timestamp.ToString("yyy-MM-dd HH:ss:mm"), charge.PrevBalance, charge.CurrBalance, charge.TransBalance, charge.TransAmount, charge.ChargeID);
                    cmd = new MySqlCommand (sql, con); // creating query command
                    ret = cmd.ExecuteNonQuery() > 0;
                }
                else
                {
                    sql = string.Format("Insert into _chargeloadtransaction (loadid,id_subdaccount,loadwallettrans_id,charged_amount,user_id,timestamp,deleted,prev_balance,curr_balance,trans_balance,trans_amount) VALUES({0},{1},{2},{3},{4},'{5}',{6},{7},{8},{9})", charge.LoadId,charge.Id_SubDAccount, charge.LoadWalletTransId, charge.ChargedAmount, charge.User_Id, charge.Timestamp.ToString("yyy-MM-dd HH:ss:mm"), 0, charge.PrevBalance, charge.CurrBalance, charge.TransBalance, charge.TransAmount);
                    cmd = new MySqlCommand (sql, con); // creating query command
                    ret = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch { }
            return ret;
        }

        public bool SaveChargedTransaction(clsChargedTransaction charge)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            bool ret = false;
            MySqlCommand cmd = new MySqlCommand("Select chargeid from chargetransaction WHERE chargeid = " + charge.ChargeID.ToString() + " AND Deleted=0", con); // creating query command
            try
            {
                object obj = cmd.ExecuteScalar(); // executes query
                string sql = "";
                if (obj != null && obj != DBNull.Value) // if can read row from database
                {
                    sql = string.Format("Update chargetransaction set accountid={0},ornum={1},charged_amount={2},user_id={3},timestamp='{4}',deleted = 0,accountname = '{5}',prev_balance={7},curr_balance={8},trans_balance={9},interest_payment='{10}',trans_amount = {11} where chargeid = {6}", charge.AccountId, charge.ORNum, charge.ChargedAmount, charge.User_Id, charge.Timestamp.ToString("yyy-MM-dd HH:ss:mm"), charge.AccountName, charge.ChargeID, charge.PrevBalance, charge.CurrBalance, charge.TransBalance, charge.InterestPayment.ToString("yyy-MM-dd HH:ss:mm"), charge.TransAmount);
                    cmd = new MySqlCommand(sql, con); // creating query command
                    ret = cmd.ExecuteNonQuery() > 0;
                }
                else
                {
                    sql = string.Format("Insert into chargetransaction (accountid,ornum,charged_amount,user_id,timestamp,deleted,accountname,prev_balance,curr_balance,trans_balance,interest_payment,trans_amount) VALUES({0},{1},{2},{3},'{4}',{5},'{6}',{7},{8},{9},'{10}',{11})", charge.AccountId, charge.ORNum, charge.ChargedAmount, charge.User_Id, charge.Timestamp.ToString("yyy-MM-dd HH:ss:mm"), 0, charge.AccountName, charge.PrevBalance, charge.CurrBalance, charge.TransBalance, charge.InterestPayment.ToString("yyy-MM-dd HH:ss:mm"), charge.TransAmount);
                    cmd = new MySqlCommand(sql, con); // creating query command
                    ret = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch { }
            return ret;
        }
        public clsChargedLoadTrans GetChargedLoadTransaction(int loadwallettransid)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from view_chargeloadtransactions WHERE loadwallettrans_id = " + loadwallettransid.ToString() + " AND Deleted=0", con); // creating query command
            MySqlDataReader reader = cmd.ExecuteReader(); // executes query
            clsChargedLoadTrans charge = null;
            try
            {
                if (reader.HasRows && reader.Read())
                    charge = BuildChargedLoadTransaction(reader);
            }
            catch { }
            if (!reader.IsClosed) reader.Close();
            return charge;
        }

        public clsChargedTransaction GetChargedTransaction(int OrNum)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            MySqlCommand  cmd = new MySqlCommand ("Select * from view_chargetransactions WHERE ornum = " + OrNum.ToString() + " AND Deleted=0", con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
            clsChargedTransaction charge = null;
            try
            {
                if(reader.HasRows && reader.Read())
                    charge = BuildChargedTransaction(reader);
            }
            catch { }
            if (!reader.IsClosed) reader.Close();
            return charge;
        }
        public static void Backup()
        {
            try
            {
                string backup = Properties.Settings.Default.BackupPath;
                //string backup = directory + "\\iPOSBackup";
                string filename = string.Format("{0}\\backup_{1:yyyy-MM-dd_HHmmss}.sql", backup, DateTime.Now);

                if (!Directory.Exists(backup))
                {
                    Directory.CreateDirectory(backup);
                }
                using (MySqlConnection conn = new MySqlConnection(Properties.Settings.Default.dbConnectionString1 + @"PASSWORD=" + DBPassword + ";"))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(filename);
                            conn.Close();
                        }
                    }
                }
            }
            catch { }
        }
        private static clsUnclaimedCash BuildUnclaimedCash(MySqlDataReader reader)
        {
            clsUnclaimedCash uc = null;
            if (reader.HasRows) // if can read row from database
            {
                uc = new clsUnclaimedCash();
                uc.LoadAccountId = Convert.ToInt32(reader["AccountId"].ToString());
                uc.SmartMoney = reader["SmartMoney"].ToString();
                uc.RefNum = reader["RefNum"].ToString();
                uc.Amount = double.Parse(reader["Amount"].ToString());
                uc.UserId = Convert.ToInt32(reader["UserId"].ToString());
                uc.Timestamp = Convert.ToDateTime(reader["timestamp"].ToString());
            }
            return uc;
        }

        private static clsChargedLoadTrans BuildChargedLoadTransaction(MySqlDataReader reader)
        {
            clsChargedLoadTrans charge = null;
            if (reader.HasRows) // if can read row from database
            {
                charge = new clsChargedLoadTrans();
                charge.LoadId = Convert.ToInt32(reader["AccountId"].ToString());
                charge.ChargeID = Convert.ToInt32(reader["ChargeID"].ToString());
                charge.LoadWalletTransId = Convert.ToInt32(reader["LoadWalletTrans_Id"].ToString());
                charge.Id_SubDAccount = Convert.ToInt32(reader["Id_SubDAccount"].ToString());
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
            }
            return charge;
        }

        private static clsChargedTransaction BuildChargedTransaction(MySqlDataReader  reader)
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
                if (reader["prev_balance"]!=DBNull.Value)
                    charge.PrevBalance = Convert.ToDouble(reader["prev_balance"]);
                if (reader["curr_balance"] != DBNull.Value)
                    charge.CurrBalance = Convert.ToDouble(reader["curr_balance"]);
                if (reader["trans_balance"] != DBNull.Value)
                    charge.TransBalance = Math.Round(Convert.ToDouble(reader["trans_balance"]),2);
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
        public static int getTotalMonths(DateTime intpaymentdate)
        {
            return (DateTime.Now.Year - intpaymentdate.Year) * 12 + DateTime.Now.Month - intpaymentdate.Month + (DateTime.Now.Day >= intpaymentdate.Day ? 0 : -1);

        }
        public List<clsChargedTransaction> GetChargedTransactions(int accountid)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            MySqlCommand  cmd = new MySqlCommand ("Select * from view_chargetransactions WHERE accountid = " + accountid.ToString() + " AND Deleted=0", con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
            clsChargedTransaction charge = null;
            List<clsChargedTransaction> charges = new List<clsChargedTransaction>();
            if (reader.HasRows) // if can read row from database
            {
                while (reader.Read())
                {
                    try
                    {
                        charge = BuildChargedTransaction(reader);
                        if(charge!=null)
                            charges.Add(charge);
                    }
                    catch { }
                }
            }
            if (!reader.IsClosed) reader.Close();
            return charges;
        }

        public List<clsChargedLoadTrans> GetChargedLoadTransactions(int id_subdaccount)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from view_chargetransactions WHERE id_subdaccount = " + id_subdaccount.ToString() + " AND Deleted=0", con); // creating query command
            MySqlDataReader reader = cmd.ExecuteReader(); // executes query
            clsChargedLoadTrans charge = null;
            List<clsChargedLoadTrans> charges = new List<clsChargedLoadTrans>();
            if (reader.HasRows) // if can read row from database
            {
                while (reader.Read())
                {
                    try
                    {
                        charge = BuildChargedLoadTransaction(reader);
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
            MySqlCommand  cmd = new MySqlCommand ("Select SUM(trans_amount) from view_chargetransactions WHERE accountid = " + accountid.ToString() + " AND Deleted=0 and timestamp like '%" + DateTime.Now.Year + "%'", con); // creating query command
            object obj = cmd.ExecuteScalar(); // executes query
            if (obj != null && obj != DBNull.Value)
                return Convert.ToDouble(obj);
            else
                return 0;
        }
        public double GetPrincipalAmount(int accountid)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            MySqlCommand  cmd = new MySqlCommand ("Select SUM(trans_balance) from view_chargetransactions WHERE accountid = " + accountid.ToString() + " AND Deleted=0 and trans_balance>0", con); // creating query command
            object obj = cmd.ExecuteScalar(); // executes query
            if (obj != null && obj != DBNull.Value)
                return Convert.ToDouble(obj);
            else
                return 0;
        }
        public double GetTotalInterest(int actid)
        {
            double total=0;
            List<clsChargedTransaction> tmplist = GetTransWithInterest(actid);
            foreach (clsChargedTransaction ct in tmplist)
            {
                total += ct.Interest;
            }
            return Math.Round(total,2);
        }
        public List<clsChargedTransaction> GetTransWithInterest(int accountid)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            MySqlCommand  cmd = new MySqlCommand ("Select * from view_chargetransactions WHERE accountid = " + accountid.ToString() + " AND Deleted=0 AND Trans_Balance>0 and interest_payment <= '" + DateTime.Today.AddMonths(-1).ToShortDateString() + "' order by timestamp asc", con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
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
            MySqlCommand  cmd = new MySqlCommand ("Select * from view_chargetransactions WHERE accountid = " + accountid.ToString() + " AND Deleted=0 AND Trans_Balance>0 order by timestamp asc", con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
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


        public List<clsChargedLoadTrans> GetUnPaidChargedLoadTransactions(int id_subdaccount)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from view_chargetransactions WHERE id_subdaccount = " + id_subdaccount.ToString() + " AND Deleted=0 AND Trans_Balance>0 order by timestamp asc", con); // creating query command
            MySqlDataReader reader = cmd.ExecuteReader(); // executes query
            clsChargedLoadTrans charge = null;
            List<clsChargedLoadTrans> charges = new List<clsChargedLoadTrans>();
            if (reader.HasRows) // if can read row from database
            {
                while (reader.Read())
                {
                    try
                    {
                        charge = BuildChargedLoadTransaction(reader);
                        if (charge != null)
                            charges.Add(charge);
                    }
                    catch { }
                }
            }
            if (!reader.IsClosed) reader.Close();
            return charges;
        }


        public bool CancelPayment(int payref)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            MySqlCommand  cmd = new MySqlCommand ("Update PaymentInfo set Deleted=1 WHERE payment_id = " + payref.ToString() + " AND Deleted=0", con); // creating query command
            int ret = cmd.ExecuteNonQuery(); // executes query
            return ret>0;
        }

        public List<clsPaymentInfo> GetPaymentInfo(int OrNo)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            MySqlCommand  cmd = new MySqlCommand ("Select * from view_PaymentInfo WHERE OrNum = " + OrNo.ToString() + " AND Deleted=0", con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
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

        public clsPaymentInfo GetPayment(int payment_id)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from view_PaymentInfo WHERE payment_id = " + payment_id.ToString() + " AND Deleted=0 Limit 1", con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
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

        private static clsPaymentInfo BuildPaymentInfo(MySqlDataReader  reader)
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
        public List<clsPaymentInfo> GetPaymentsInfo(int accountid)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            MySqlCommand  cmd = new MySqlCommand ("Select * from view_PaymentInfo WHERE accountid = " + accountid.ToString() + " AND Deleted=0", con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
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
        public List<clsChargedTransaction> GetChargedTransFromDate(int accountid, DateTime startdate, DateTime enddate)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            MySqlCommand  cmd = new MySqlCommand (string.Format("Select * from view_chargetransactions WHERE accountid ={0} AND Deleted=0 AND timestamp between '{0} 06:00:00' and '{1} 06:00:00' ", accountid, startdate.ToString("yyyy-MM-dd"), enddate.ToString("yyyy-MM-dd")), con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
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

        public List<clsPaymentInfo> GetPaymentsInfoFromDate(DateTime startdate, DateTime enddate,string cashier)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            MySqlCommand  cmd = null;
            if (cashier != "")
            {
                cmd = new MySqlCommand (string.Format("Select * from view_paymentInfo WHERE Deleted=0 AND timestamp between '{0} 06:00:00' and '{1} 06:00:00' AND LoginName = '{2}' ", startdate.ToString("yyyy-MM-dd"), enddate.ToString("yyyy-MM-dd"), cashier), con); // creating query command
            }
            else
            {
                cmd = new MySqlCommand (string.Format("Select * from view_paymentInfo WHERE Deleted=0 AND timestamp between '{0} 06:00:00' and '{1} 06:00:00'  ", startdate.ToString("yyyy-MM-dd"), enddate.ToString("yyyy-MM-dd")), con); // creating query command
            }
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
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

        public double GetTotalPaymentsInfoFromDate(DateTime startdate, DateTime enddate, string cashier)
        {
            double ret = 0;
            if (con.State == ConnectionState.Closed) con.Open();
            MySqlCommand  cmd = null;
            if (cashier != "")
            {
                cmd = new MySqlCommand (string.Format("Select sum(amountpaid) as AmountPaid from view_paymentInfo WHERE Deleted=0 AND timestamp between '{0} 06:00:00' and '{1} 06:00:00' AND LoginName = '{2}' ", startdate.ToString("yyyy-MM-dd"), enddate.ToString("yyyy-MM-dd"), cashier), con); // creating query command
            }
            else
            {
                cmd = new MySqlCommand (string.Format("Select sum(amountpaid) as AmountPaid from view_paymentInfo WHERE Deleted=0 AND timestamp between '{0} 06:00:00' and '{1} 06:00:00'  ", startdate.ToString("yyyy-MM-dd"), enddate.ToString("yyyy-MM-dd")), con); // creating query command
            }
            object obj = cmd.ExecuteScalar(); // executes query
            if (obj != null && obj != DBNull.Value)
                ret = Convert.ToDouble(obj);
            return ret;
        }

        
        public string SavePayment(clsPaymentInfo pay)
        {
            try
            {
                string ret = "";
                MySqlCommand  cmd = null;
                MySqlCommand  cmdGetIdentity;

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
                            sql = String.Format("Insert Into paymentinfo (accountid,AmountPaid,timestamp,user_id,Deleted,remarks,ORNum) VALUES({0},{1},'{2}',{3},0,'{4}',{5})", pay.AccountId, c.Interest, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), pay.UserId, string.Format("Interest Payment: ORNum({0})", c.ORNum),c.ORNum);
                            cmd = new MySqlCommand (sql, con); // creating query command
                            cmd.ExecuteNonQuery();
                            savetrans = true;
                            cmdGetIdentity = new MySqlCommand ("SELECT @@IDENTITY", con);
                            object obj = cmdGetIdentity.ExecuteScalar();
                            if (obj != null && obj != DBNull.Value)
                                ret += string.Format("Payment ref#{0}: {1} P{2:0.00}\n", obj.ToString(), string.Format("Interest Payment: ORNum({0})", c.ORNum),c.Interest);
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
                            sql = String.Format("Insert Into paymentinfo (accountid,AmountPaid,timestamp,user_id,Deleted,remarks,ORNum) VALUES({0},{1},'{2}',{3},0,'{4}',{5})", pay.AccountId, totalPayment, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), pay.UserId, string.Format("Principal Payment: ORNum({0})", c.ORNum),c.ORNum);
                            cmd = new MySqlCommand (sql, con); // creating query command
                            cmd.ExecuteNonQuery();

                            cmdGetIdentity = new MySqlCommand ("SELECT @@IDENTITY", con);
                            object obj = cmdGetIdentity.ExecuteScalar();
                            if (obj != null && obj != DBNull.Value)
                                ret += string.Format("Payment ref#{0}: {1} P{2:0.00}\n", obj.ToString(), string.Format("Principal Payment: ORNum({0})", c.ORNum), totalPayment);
                            cmdGetIdentity = null;

                            totalPayment = 0;
                            savetrans = true;
                        }
                        else
                        {
                            sql = String.Format("Insert Into paymentinfo (accountid,AmountPaid,timestamp,user_id,Deleted,remarks,ORNum) VALUES({0},{1},'{2}',{3},0,'{4}',{5})", pay.AccountId, c.TransBalance, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), pay.UserId, string.Format("Principal Payment: ORNum({0})", c.ORNum),c.ORNum);
                            cmd = new MySqlCommand (sql, con); // creating query command
                            cmd.ExecuteNonQuery();

                            cmdGetIdentity = new MySqlCommand ("SELECT @@IDENTITY", con);
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
                //sql = String.Format("Insert Into paymentinfo (accountid,AmountPaid,timestamp,user_id,Deleted) VALUES({0},{1},'{2}',{3},0)", pay.AccountId, pay.AmountPaid, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), pay.UserId);
                //cmd = new MySqlCommand (sql, con); // creating query command

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


        public clsAccountInfo GetAccountInfo(int AccountId)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            MySqlCommand  cmd = new MySqlCommand ("Select * from AccountInfo WHERE accountid = " + AccountId.ToString() + " AND Deleted=0", con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
            clsAccountInfo account = null;
            if (reader.HasRows) // if can read row from database
            {
                reader.Read();
                account = BuildAccount(reader);
            }
            if (!reader.IsClosed) reader.Close();
            return account;
        }
        public clsLoadAccount GetLoadAccount(int loadid)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from _loadaccount WHERE load_id = " + loadid.ToString() + " AND Deleted=0", con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
            clsLoadAccount loadaccount = null;
            if (reader.HasRows) // if can read row from database
            {
                reader.Read();
                loadaccount = BuildLoadAccount(reader);
            }
            if (!reader.IsClosed) reader.Close();
            return loadaccount;
        }
        public List<clsLoadAccount> GetLoadAccounts()
        {
            if (con.State == ConnectionState.Closed) con.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from _loadaccount WHERE Deleted=0 order by loadtype", con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
            List<clsLoadAccount> lstAccounts = new List<clsLoadAccount>();
            if (reader.HasRows) // if can read row from database
            {
                while (reader.Read())
                {
                    lstAccounts.Add(BuildLoadAccount(reader));
                }
            }
            if (!reader.IsClosed) reader.Close();
            return lstAccounts;
        }
        public List<clsReloadHistory> GetReLoadHistory(int loadid)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            string sql = "Select * FROM _reloadhistory WHERE load_id = " + loadid.ToString() + " AND Deleted=0";
            if (loadid == 0) sql = "SELECT * FROM _reloadHistory WHERE Deleted = 0";
            MySqlCommand cmd = new MySqlCommand(sql, con); // creating query command
            MySqlDataReader reader = cmd.ExecuteReader(); // executes query
            List<clsReloadHistory> lstReloadHistory = new List<clsReloadHistory>();
            if (reader.HasRows) // if can read row from database
            {
                while (reader.Read())
                {
                    clsReloadHistory reload = BuildReloadHistory(reader);
                    if (reload != null) lstReloadHistory.Add(reload);
                }
            }
            if (!reader.IsClosed) reader.Close();
            return lstReloadHistory;
        }
        public List<clsEloadTransaction> GetEloadTransactions(int loadid)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from _eloadtransaction WHERE load_id = " + loadid.ToString() + " AND Deleted=0", con); // creating query command
            MySqlDataReader reader = cmd.ExecuteReader(); // executes query
            List<clsEloadTransaction> lstEloadTrans = new List<clsEloadTransaction>();
            if (reader.HasRows) // if can read row from database
            {
                while (reader.Read())
                {
                    clsEloadTransaction eLoad = BuildELoadTransaction(reader);
                    if (eLoad != null) lstEloadTrans.Add(eLoad);
                }
            }
            if (!reader.IsClosed) reader.Close();
            return lstEloadTrans;
        }
        public List<clsGCashTransaction> GetGCashTransactions(int loadid)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from _eloadtransaction WHERE load_id = " + loadid.ToString() + " AND Deleted=0", con); // creating query command
            MySqlDataReader reader = cmd.ExecuteReader(); // executes query
            List<clsGCashTransaction> lstECashTrans = new List<clsGCashTransaction>();
            if (reader.HasRows) // if can read row from database
            {
                while (reader.Read())
                {
                    clsGCashTransaction eCash = BuildECashTransaction(reader);
                    if (eCash != null) lstECashTrans.Add(eCash);
                }
            }
            if (!reader.IsClosed) reader.Close();
            return lstECashTrans;
        }

        public bool SaveAccountInfo(clsAccountInfo ac)
        {
            bool ret = false;
            if (con.State == ConnectionState.Closed) con.Open();

            MySqlCommand  cmd = null;
            if (ac.AccountId == 0) 
                cmd = new MySqlCommand ("Select accountid from AccountInfo WHERE AccountName = '" + ac.AccountName.ToString() + "' AND Deleted=0", con); // creating query command
            else
                cmd = new MySqlCommand ("Select accountid from AccountInfo WHERE accountid = " + ac.AccountId.ToString() + " AND Deleted=0", con); // creating query command

            object obj = cmd.ExecuteScalar();
            if (obj != null && obj != DBNull.Value) // if can read row from database
            {
                cmd = new MySqlCommand(string.Format("Update AccountInfo set AccountName = '{0}', creditlimit={1},YTD={2},Principal={3},Interest={4},LastComputedInterest='{6:yyyy-MM-dd HH:mm:ss}' where accountid={5}", ac.AccountName, ac.CreditLimit, ac.YTDTransaction, ac.PrincipalBalance, ac.TotalInterest, ac.AccountId, ac.LastComputedInterest), con);
                ret = cmd.ExecuteNonQuery() > 0;
            }
            else
            {
                cmd = new MySqlCommand (string.Format("Insert into AccountInfo (AccountName,CreditLImit,Deleted,YTD,Principal,Interest,LastComputedInterest) VALUES('{0}',{1},0,{2},{3},{4},'{5:yyyy-MM-dd HH:mm:ss}')", ac.AccountName, ac.CreditLimit, ac.YTDTransaction, ac.PrincipalBalance, ac.TotalInterest,ac.LastComputedInterest), con);
                ret = cmd.ExecuteNonQuery() > 0;
            }
            return ret;
        }

        public bool DeleteAccountInfo(int accountid)
        {
            bool ret = false;
            if (con.State == ConnectionState.Closed) con.Open();
            try
            {
                MySqlCommand  cmd = new MySqlCommand ("Select accountid from AccountInfo WHERE accountid = " + accountid.ToString() + " AND Deleted=0", con); // creating query command
                object obj = cmd.ExecuteScalar();
                if (obj != null && obj != DBNull.Value) // if can read row from database
                {
                    cmd = new MySqlCommand (string.Format("Update AccountInfo set deleted = 1 where accountid={0}", accountid), con);
                    ret = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch { }
            return ret;
        }

        public static List<clsAccountInfo> GetAccountInfoList(string name="")
        {
            MySqlConnection  dbCon = new MySqlConnection (Properties.Settings.Default.dbConnectionString1 + string.Format("Password={0};",DBPassword));  // connection string change database name and password here.
            if (dbCon.State == ConnectionState.Closed) dbCon.Open();
            MySqlCommand  cmd = null;
            if(name=="")
                cmd = new MySqlCommand ("Select * from AccountInfo where Deleted=0 order by AccountName", dbCon); // creating query command
            else
                cmd = new MySqlCommand ("Select * from AccountInfo where AccountName like '%" + name + "%' and Deleted=0 order by AccountName", dbCon); // creating query command

            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
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

        private static clsAccountInfo BuildAccount(MySqlDataReader  reader)
        {
            clsAccountInfo account = new clsAccountInfo();
            try
            {
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

                try
                {
                    if (reader["LastComputedInterest"] == DBNull.Value || reader["LastComputedInterest"] == null)
                    {
                        account.LastComputedInterest = DateTime.MinValue;
                        updateneeded = true;
                    }
                    else
                        account.LastComputedInterest = DateTime.Parse(reader["LastComputedInterest"].ToString());
                }
                catch {
                    account.LastComputedInterest = DateTime.MinValue;
                    updateneeded = true;
                }
                

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
            }
            catch(Exception ex) { }

            return account;
        }


        public clsProductItem GetProductItem(string barcode)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            MySqlCommand  cmd = new MySqlCommand ("Select * from view_Items WHERE barcode = '" + barcode.Replace("'", "''") + "' AND Deleted=0", con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
            clsProductItem proditem = null;
            if (reader.HasRows) // if can read row from database
            {
                reader.Read();
                proditem = BuildProductITem(reader);

            }
            if (!reader.IsClosed) reader.Close();
            return proditem;
        }

        public int ChangeBarcode( string oldBarcode, string newBarcode )
        {
            if (con.State == ConnectionState.Closed) con.Open();
            MySqlCommand  cmd = new MySqlCommand ("Update Items set barcode = '" + newBarcode.Replace("'", "''") + "' WHERE barcode='" + oldBarcode.Replace("'", "''") + "'", con); // creating query command
            int ret = cmd.ExecuteNonQuery(); // executes query

            cmd = new MySqlCommand ("Update Inventory set barcode = '" + newBarcode.Replace("'", "''") + "' WHERE barcode='" + oldBarcode.Replace("'", "''") + "'", con); // creating query command
            ret += cmd.ExecuteNonQuery(); // executes query
            cmd = new MySqlCommand ("Update TransactionHistory set barcode = '" + newBarcode.Replace("'", "''") + "' WHERE barcode='" + oldBarcode.Replace("'", "''") + "'", con); // creating query command
            ret += cmd.ExecuteNonQuery(); // executes query
            cmd = new MySqlCommand ("Update TempTransactionHistory set barcode = '" + newBarcode.Replace("'", "''") + "' WHERE barcode='" + oldBarcode.Replace("'", "''") + "'", con); // creating query command
            ret += cmd.ExecuteNonQuery(); // executes query

            return ret;
        }

        private static string ToCamelCase( string description )
        {
            string ret = "";
            List<string> lst = description.Split(" ".ToCharArray()).ToList();
            foreach (string str in lst)
            {
                if (str.Length > 1)
                {
                    ret += str.Substring(0, 1).ToUpper();
                    ret += str.Substring(1).ToLower();
                }
                else
                {
                    ret += str;
                }
                ret += " ";
            }
            return ret;
        }
        private static clsProductItem BuildProductITem(MySqlDataReader  reader )
        {
            clsProductItem proditem = new clsProductItem();
            proditem.ID = Int32.Parse(reader["ID"].ToString());
            proditem.BarCode = reader["barcode"].ToString();
            proditem.Description = reader["description"].ToString().ToUpper();
            proditem.Amount = Math.Round(double.Parse(reader["amount"].ToString()),2);
            proditem.WSAmount = Math.Round(double.Parse(reader["wsamount"].ToString()),2);
            proditem.TotalInventoryQty = double.Parse(reader["QtyAvailable"].ToString());
            proditem.QtySold = double.Parse(reader["QtySold"].ToString());
            proditem.Unit = reader["unit"].ToString();
            proditem.Imagepath = reader["ImagePath"].ToString();
            proditem.WSMinimum = Int32.Parse(reader["WSMinimum"].ToString());
            proditem.Capital = Math.Round(double.Parse(reader["capital"].ToString()),2);
            proditem.InStorage = Int32.Parse(reader["instorage"].ToString());
            proditem.CriticalLevel = Int32.Parse(reader["CriticalLevel"].ToString());
            proditem.CategoryId = Int32.Parse(reader["categoryid"].ToString());
            proditem.Category = reader["category"].ToString();
            return proditem;
        }
        private static clsLoadAccount BuildLoadAccount(MySqlDataReader reader)
        {
            clsLoadAccount loadaccount = new clsLoadAccount();
            loadaccount.LoadId = Int32.Parse(reader["Load_Id"].ToString());
            loadaccount.Description = reader["Description"].ToString();
            loadaccount.CurrentBalance = Math.Round(double.Parse(reader["Available_Balance"].ToString()), 2) + clsUnclaimedCash.TotalUnclaimedCash(loadaccount.LoadId);
            loadaccount.AvailableBalance = Math.Round(double.Parse(reader["Available_Balance"].ToString()), 2);
            loadaccount.LoadType = (LoadAccountType)int.Parse(reader["LoadType"].ToString());
            loadaccount.AccountNum = reader["AccountNum"].ToString();
            loadaccount.MobileNum = reader["MobileNum"].ToString();
            loadaccount.ImgFile = reader["ImgFile"] != DBNull.Value ? (byte[])(reader["ImgFile"]) : null;
            return loadaccount;
        }
        private static clsSubDAccount BuildSubDAccount(MySqlDataReader reader)
        {
            clsSubDAccount subd = new clsSubDAccount();
            subd.Id_subdAccounts = Int32.Parse(reader["Id_subdAccounts"].ToString());
            subd.LoadId = Int32.Parse(reader["loadid"].ToString());
            subd.Name = reader["Name"].ToString();
            subd.MobileNum = reader["MobileNum"].ToString();
            subd.Balance = Math.Round(double.Parse(reader["Balance"].ToString()), 2);
            subd.Discount = Math.Round(double.Parse(reader["Discount"].ToString()), 2);
            return subd;
        }

        private static clsReloadHistory BuildReloadHistory(MySqlDataReader reader)
        {
            clsReloadHistory reload = new clsReloadHistory();
            reload.ReloadId = Int32.Parse(reader["ReloadId"].ToString());
            reload.UserId = Int32.Parse(reader["UserId"].ToString());
            reload.Load_Id = Int32.Parse(reader["Load_Id"].ToString());
            reload.RefNum = reader["RefNum"].ToString();
            reload.Amount = double.Parse(reader["Amount"].ToString());
            reload.Timestamp = DateTime.Parse(reader["Timestamp"].ToString());
            reload.RemainingBalance = double.Parse(reader["remainingBalance"].ToString());
            reload.EcashTransId = int.Parse(reader["ecashtransid"].ToString());
            reload.Remarks = reader["remarks"].ToString();
            reload.TransactionAmount = double.Parse(reader["transaction_amount"].ToString());
         
            return reload;
        }

        private static clsEloadTransaction BuildELoadTransaction(MySqlDataReader reader)
        {
            clsEloadTransaction eload = new clsEloadTransaction();
            eload.ELoadTrans_Id = Int32.Parse(reader["ELoadTrans_Id"].ToString());
            eload.Load_Id = Int32.Parse(reader["Load_Id"].ToString());
            eload.UserId = Int32.Parse(reader["UserId"].ToString());
            eload.AccountId = Int32.Parse(reader["AccountId"].ToString());
            eload.Transaction_Amount = double.Parse(reader["Transaction_Amount"].ToString());
            eload.AmountDue = double.Parse(reader["AmountDue"].ToString());
            eload.Discount = double.Parse(reader["Discount"].ToString());
            eload.Timestamp = DateTime.Parse(reader["Timestamp"].ToString());
            eload.RefNum = reader["RefNum"].ToString();
            eload.Remarks = reader["Remarks"].ToString();
            eload.MobileNum = reader["MobileNum"].ToString();
            eload.UserId = int.Parse(reader["UserId"].ToString());
            eload.ELoadStatusId = (ELoadStatus) int.Parse(reader["eloadstatus_id"].ToString());
            return eload;
        }

        private static clsGCashTransaction BuildECashTransaction(MySqlDataReader reader)
        {
            clsGCashTransaction ecash = new clsGCashTransaction();
            ecash.GCashtTransId = Int32.Parse(reader["ELoadTrans_Id"].ToString());
            ecash.Load_Id = Int32.Parse(reader["Load_Id"].ToString());
            ecash.UserId = Int32.Parse(reader["UserId"].ToString());
            ecash.AccountId = Int32.Parse(reader["AccountId"].ToString());
            ecash.TransAmount = double.Parse(reader["TransactionAmount"].ToString());
            ecash.SvcFeeAmount = double.Parse(reader["SvcFeeAmount"].ToString());
            ecash.SenderName = reader["SenderName"].ToString();
            ecash.SenderContact = reader["SenderContact"].ToString();
            ecash.RecipientName = reader["RecipientName"].ToString();
            ecash.RecipientContact = reader["RecipientContact"].ToString();
            ecash.RefNum = reader["RefNum"].ToString();
            ecash.Remarks = reader["Remarks"].ToString();
            ecash.TransactionType = (GCashTransType)int.Parse(reader["StatusId"].ToString());
            ecash.TransDate = DateTime.Parse(reader["DateReceived"].ToString());
            ecash.DateCancelled = DateTime.Parse(reader["DateCancelled"].ToString());
            return ecash;
        }
        private static clsGCashTransaction BuildGCashTransaction(MySqlDataReader reader)
        {
            clsGCashTransaction ecash = new clsGCashTransaction();
            ecash.GCashtTransId = Int32.Parse(reader["EcashTransId"].ToString());
            ecash.Load_Id = Int32.Parse(reader["LoadId"].ToString());
            ecash.UserId = Int32.Parse(reader["UserId"].ToString());
            ecash.AccountId = Int32.Parse(reader["AccountId"].ToString());
            ecash.TransAmount = double.Parse(reader["TransactionAmount"].ToString());
            ecash.SvcFeeAmount = double.Parse(reader["SvcFeeAmount"].ToString());
            ecash.SenderName = reader["SenderName"].ToString();
            ecash.SenderContact = reader["SenderContact"].ToString();
            ecash.RecipientName = reader["RecipientName"].ToString();
            ecash.RecipientContact = reader["RecipientContact"].ToString();
            ecash.RefNum = reader["RefNum"].ToString();
            ecash.Remarks = reader["Remarks"].ToString();
            ecash.TransactionType = (GCashTransType)int.Parse(reader["transtype"].ToString());
            ecash.TransDate = DateTime.Parse(reader["transdate"].ToString());
            if(reader["cancelDate"].ToString() != "") ecash.DateCancelled = DateTime.Parse(reader["cancelDate"].ToString());
            ecash.GCashNumber = reader["gcashnumber"].ToString();
            ecash.TenderedAmount = double.Parse(reader["TenderedAmount"].ToString());

            return ecash;
        }

        private static clsLoadWalletTransaction BuildLoadWalletTransaction(MySqlDataReader reader)
        {
            clsLoadWalletTransaction loadwallet = new clsLoadWalletTransaction();
            loadwallet.LoadwalletTransId = Int32.Parse(reader["loadwallettrans_id"].ToString());
            loadwallet.Load_Id = Int32.Parse(reader["Load_Id"].ToString());
            loadwallet.UserId = Int32.Parse(reader["UserId"].ToString());

            loadwallet.AmtDue = double.Parse(reader["Trans_Amount"].ToString());
            loadwallet.LoadAmount = double.Parse(reader["Load_Amount"].ToString());
            loadwallet.DiscountPercentage = double.Parse(reader["Discount"].ToString());
            loadwallet.Timestamp = DateTime.Parse(reader["Timestamp"].ToString());
            loadwallet.Remarks = reader["Remarks"].ToString();
            loadwallet.MobileNum = reader["MobileNum"].ToString();
            loadwallet.UserId = int.Parse(reader["UserId"].ToString());
            loadwallet.SubDId = int.Parse(reader["id_subdaccount"].ToString());
            return loadwallet;
        }
        private static clsSmartCashTransaction BuildSCashTransaction(MySqlDataReader reader)
        {
            clsSmartCashTransaction ecash = new clsSmartCashTransaction();
            ecash.SCashTransId = Int32.Parse(reader["EcashTransId"].ToString());
            ecash.Load_Id = Int32.Parse(reader["LoadId"].ToString());
            ecash.UserId = Int32.Parse(reader["UserId"].ToString());
            ecash.AccountId = Int32.Parse(reader["AccountId"].ToString());
            ecash.TransAmount = double.Parse(reader["TransactionAmount"].ToString());
            ecash.SvcFeeAmount = double.Parse(reader["SvcFeeAmount"].ToString());
            ecash.SenderName = reader["SenderName"].ToString();
            ecash.SenderContact = reader["SenderContact"].ToString();
            ecash.RecipientName = reader["RecipientName"].ToString();
            ecash.RecipientContact = reader["RecipientContact"].ToString();
            ecash.RefNum = reader["RefNum"].ToString();
            ecash.Remarks = reader["Remarks"].ToString();
            ecash.TransType = (SCashTranstype)int.Parse(reader["transtype"].ToString());
            ecash.PaymentMode = (SCashPaymentMode)int.Parse(reader["PaymentMode"].ToString());
            ecash.TenderedAmount = double.Parse(reader["TenderedAmount"].ToString());
            ecash.TransDate = DateTime.Parse(reader["transdate"].ToString());

            return ecash;
        }
        private static clsProductItem BuildProductITemAsOf( MySqlDataReader  reader ,DateTime asOf)
        {
            MySqlCommand  cmd = null;
            MySqlConnection  dbCon = new MySqlConnection ();
            
            clsProductItem proditem = new clsProductItem();
            proditem.ID = Int32.Parse(reader["ID"].ToString());
            proditem.BarCode = reader["barcode"].ToString();
            proditem.Description = reader["description"].ToString();
            proditem.Amount = Math.Round(double.Parse(reader["amount"].ToString()), 2);
            proditem.WSAmount = Math.Round(double.Parse(reader["wsamount"].ToString()), 2);

            cmd = new MySqlCommand (String.Format("Select sum(Qty) from view_Items where Deleted = 0 and Barcode ='{0}'",proditem.BarCode.Trim()), dbCon);
            object obj = cmd.ExecuteScalar();
            if (obj != DBNull.Value && obj != null)
            {
                proditem.QtySold = double.Parse(obj.ToString());
            }
            cmd = new MySqlCommand (String.Format("Select sum(Qty) from inventory where Deleted = 0 and Barcode ='{0}'",proditem.BarCode.Trim()), dbCon);
            obj = cmd.ExecuteScalar();
            if (obj != DBNull.Value && obj != null)
            {
                proditem.TotalInventoryQty = double.Parse(obj.ToString())-proditem.QtySold;
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

        public List<clsProductItem> GetProductItems(string description)
        {
            MySqlCommand  cmd = new MySqlCommand ("Select * from view_Items WHERE description like '%" + description.Replace("'", "''") + "%' and Deleted=0", con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
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

        public List<clsInventory> getInventory(string BarCode)
        {
            string sql = "";
            if (BarCode == "")
                sql = String.Format("Select * from view_Inventory WHERE deleted=0 order by ID desc");
            else
                sql = String.Format("Select * from view_Inventory WHERE Barcode like '{0}' and deleted = 0 order by ID desc", BarCode);
            
            MySqlCommand  cmd = new MySqlCommand (sql, con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
            List<clsInventory> inventories = new List<clsInventory>();
            if (reader.HasRows)
            {
                while (reader.Read()) // if can read row from database
                {
                    clsInventory inventory = new clsInventory();
                    inventory.Description= reader["Description"].ToString();
                    inventory.BarCode = reader["BarCode"].ToString();
                    inventory.DateAdded = DateTime.Parse( reader["DateAdded"].ToString());
                    inventory.Quantity = int.Parse(reader["Qty"].ToString());
                    inventory.Capital = double.Parse(reader["Capital"].ToString());
                    try
                    {
                        inventory.ExpiryDate = DateTime.Parse(reader["ExpiryDate"].ToString());
                    }
                    catch {
                        inventory.ExpiryDate = inventory.DateAdded;
                    }
                    inventory.Remarks = reader["Remarks"].ToString();
                    inventories.Add(inventory);
                }
            }
            if (!reader.IsClosed) reader.Close();
            return inventories;
        }

        public List<clsInventory> GetPurchases(DateTime startdate,DateTime enddate,string remarks)
        {
            string sql = "";
            if(remarks == "")
                sql = String.Format("Select * from view_Inventory WHERE DateAdded between '{0:yyyy/MM/dd 06:00:00}' and '{1:yyyy/MM/dd 06:00:00}' and deleted=0 order by dateadded desc", startdate, enddate.AddDays(1));
            else
                sql = String.Format("Select * from view_Inventory WHERE DateAdded between '{0:yyyy/MM/dd 06:00:00}' and '{1:yyyy/MM/dd 06:00:00}' and remarks like '%{2}%' and deleted=0 order by dateadded desc", startdate, enddate.AddDays(1), remarks);

            MySqlCommand  cmd = new MySqlCommand (sql, con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
            List<clsInventory> inventories = new List<clsInventory>();
            if (reader.HasRows)
            {
                while (reader.Read()) // if can read row from database
                {
                    clsInventory inventory = new clsInventory();
                    inventory.Description = reader["Description"].ToString();
                    inventory.BarCode = reader["BarCode"].ToString();
                    inventory.DateAdded = Convert.ToDateTime(reader["DateAdded"]);
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


        public double getInventoryQty(string BarCode)
        {
            string sql = "";
            double ret = 0;
            if (BarCode != "")
            {
                sql = String.Format("Select sum(qty) as TotalQty from view_Inventory WHERE Barcode ='{0}' and deleted=0", BarCode);
                try
                {
                    MySqlCommand  cmd = new MySqlCommand (sql, con); // creating query command
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

        public bool DeleteProductItem(string barcode)
        {
            try
            {
                MySqlCommand  cmd = new MySqlCommand (String.Format("Select * from Items where Barcode = '{0}' AND Deleted=0", barcode), con);
                if (RecExists(cmd.ExecuteReader()) == true)
                {
                    cmd = new MySqlCommand (String.Format("Update Items Set Deleted = 1 where Barcode = '{0}' AND Deleted=0;", barcode), con); // creating query command
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        cmd = new MySqlCommand (String.Format("Update Inventory Set Deleted = 1 where Barcode = '{0}' AND Deleted=0;", barcode), con); // creating query command
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

        public bool DeleteProductItem(Int32 id)
        {
            try
            {
                MySqlCommand  cmd = new MySqlCommand (String.Format("Select ID from Items where ID = {0} AND Deleted=0", id), con);
                if (cmd.ExecuteScalar()!=null)
                {
                    cmd = new MySqlCommand (String.Format("Delete from Items where ID = {0} AND Deleted=0", id), con); // creating query command
                    return cmd.ExecuteNonQuery()>0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);  // shows exception message in console if any errors occured
            }
            return false;
        }

        public List<clsProductItem> SearchProductItems(string searchString)
        {
            List<clsProductItem> lstProdItems = new List<clsProductItem>();
            try
            {
                MySqlCommand  cmd = null;
                if(searchString=="")
                    cmd = new MySqlCommand (String.Format("Select * from view_Items where Deleted = 0 order by description"), con);                   
                else
                    cmd = new MySqlCommand (String.Format("Select * from view_Items where (Barcode like '%{0}%' OR Description like '%{0}%') AND Deleted = 0 order by description", searchString.Replace("'", "''")), con);
                MySqlDataReader  reader = cmd.ExecuteReader();
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

        public List<clsProductItem> SearchProductItemsAsOf( string searchString ,DateTime asOf)
        {
            List<clsProductItem> lstProdItems = new List<clsProductItem>();
            try
            {
                MySqlCommand  cmd = null;
                if (searchString == "")
                    cmd = new MySqlCommand (String.Format("Select * from view_Items where Deleted = 0 order by description"), con);
                else
                    cmd = new MySqlCommand (String.Format("Select * from view_Items where (Barcode like '%{0}%' OR Description like '%{0}%') AND Deleted = 0 order by description", searchString.Replace("'", "''")), con);
                MySqlDataReader  reader = cmd.ExecuteReader();
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

                            cmd = new MySqlCommand (String.Format("Select sum(Qty) from view_transaction where Deleted = 0 and Barcode ='{0}' and transdate<'{1:yyyy-MM-dd}'", proditem.BarCode.Trim(), asOf.AddDays(1).ToShortDateString()), con);
                            object obj = cmd.ExecuteScalar();
                            if (obj != DBNull.Value && obj != null)
                            {
                                proditem.QtySold = double.Parse(obj.ToString());
                            }
                            else
                            {
                                proditem.QtySold = 0;
                            }
                            cmd = new MySqlCommand (String.Format("Select sum(Qty) from inventory where Deleted = 0 and Barcode ='{0}' and dateadded<'{1:yyyy-MM-dd}'", proditem.BarCode.Trim(), asOf.AddDays(1).ToShortDateString()), con);
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

        public int ExecuteNonQuery(string sql,ref string errormsg)
        {
            try
            {
                MySqlCommand  cmd = null;
                cmd = new MySqlCommand (sql, con);
                errormsg = "";
                return cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                errormsg = ex.Message;
            }
            return -1;
        }

        public bool SaveProductItem(clsProductItem proditem)
        {
            try
            {
                MySqlCommand  cmd = new MySqlCommand (String.Format("Select * from Items where Barcode = '{0}' AND Deleted = 0", proditem.BarCode.Trim()), con);
                if (RecExists(cmd.ExecuteReader()) == false)
                {
                    cmd = new MySqlCommand (String.Format("Insert Into Items(barcode,description,amount,wsamount,qtyavailable,imagepath,wsminimum,capital,qtysold,unit,instorage,criticalLevel,categoryid,deleted) VALUES('{0}','{1}',{2:0.00},{3:0.00},{4},'{5}',{6},{7},0,'{8}',{9},{10},{11},0)", proditem.BarCode, proditem.Description.Replace("'", "''"), proditem.Amount, proditem.WSAmount, proditem.TotalInventoryQty,proditem.Imagepath,proditem.WSMinimum,proditem.Capital,proditem.Unit,proditem.InStorage,proditem.CriticalLevel,proditem.CategoryId), con); // creating query command
                    
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                }
                else
                {
                    string sql = String.Format("Update Items Set Description = '{0}', Amount = {1:0.00}, WSAmount={2:0.00},QtyAvailable={3},ImagePath='{5}',WSMinimum={6},Capital={7},QtySold={8},Unit='{9}',InStorage={10},CriticalLevel={11},categoryid={12} WHERE Barcode ='{4}'", proditem.Description.Replace("'", "''"), proditem.Amount, proditem.WSAmount, proditem.TotalInventoryQty, proditem.BarCode, proditem.Imagepath, proditem.WSMinimum, proditem.Capital, proditem.QtySold, proditem.Unit, proditem.InStorage,proditem.CriticalLevel,proditem.CategoryId);
                    cmd = new MySqlCommand (sql, con); // creating query command

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

        public bool SaveInventory(clsInventory inventory)
        {
            try
            {
                string sql = String.Format("Insert Into Inventory(Barcode,DateAdded,Qty,Capital,Remarks,ExpiryDate,Deleted)VALUES('{0}','{5:yyyy-MM-dd HH:mm:ss}',{1},{2},'{3}','{4:yyyy-MM-dd HH:mm:ss}',0)", inventory.BarCode, inventory.Quantity, inventory.Capital, inventory.Remarks, inventory.ExpiryDate, inventory.DateAdded);
                MySqlCommand  cmd = new MySqlCommand (sql, con); // creating query command

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

        public bool DeleteReceipt(Int32 ReceiptID)
        {
            try
            {
                MySqlCommand  cmd = null;
                cmd = new MySqlCommand (String.Format("Update Receipt Set Deleted=1 Where ORNumber={0}", ReceiptID),con);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    try
                    {
                        cmd = new MySqlCommand (String.Format("Update ChargeTransaction Set Deleted=1 Where ORNum={0}", ReceiptID), con);
                        cmd.ExecuteNonQuery();
                    }
                    catch { }
                    return RemoveFromHistory(ReceiptID);
                }
            }
            catch(Exception ex){
                string error = ex.Message;
            }
             return false;
        }

        public bool DeleteTempReceipt( Int32 ReceiptID )
        {
            try
            {
                MySqlCommand  cmd = null;
                cmd = new MySqlCommand (String.Format("Update TempReceipt Set Deleted=1 Where ORNumber={0}", ReceiptID), con);
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

        public static double GetTotalDiscount(Int32 ReceiptID)
        {
            MySqlConnection  dbCon = new MySqlConnection (Properties.Settings.Default.dbConnectionString1 + string.Format("Password={0};",DBPassword));  // connection string change database name and password here.
            MySqlCommand  cmd = null;
            double ret = 0;
            try
            {
                dbCon.Open();
                cmd = new MySqlCommand (string.Format("Select sum(discount) as Total from TransactionHistory WHERE OrNumber={0} and Deleted=0", ReceiptID), dbCon); // creating query command

                object obj = cmd.ExecuteScalar(); // executes query
                if (obj != null && obj != DBNull.Value)
                    ret = Convert.ToDouble(obj);
            }
            catch { }
            dbCon.Close();
            return ret;
        }
        public bool CreateReceipt(ref Int32 ReceiptID,  string cashier,double AmountDue,double CashTendered, double srdiscount,double itemdiscount,Int32 accountid,DateTime transdate)
        {
            try
            {
                MySqlCommand  cmd = null;
                MySqlCommand  cmdGetIdentity;
                if (ReceiptID == 0)
                {
                    cmd = new MySqlCommand(String.Format("Insert Into Receipt(CustomerName,AmountDue,CashTendered,TransDate,Discount,ItemDiscount,AccountId, Deleted) Values('{0}',{1},{2},'{3}',{4},{5},{6},0)", cashier, AmountDue, CashTendered, transdate.ToString("yyyy-MM-dd HH:mm:ss"), srdiscount, itemdiscount, accountid), con); // creating query command
                    cmd.ExecuteNonQuery();
                    cmdGetIdentity = new MySqlCommand ("SELECT @@IDENTITY", con);
                    object obj = cmdGetIdentity.ExecuteScalar();
                    if(obj!=null && obj!= DBNull.Value)
                        ReceiptID = Convert.ToInt32(obj);
                    cmdGetIdentity = null;
                }
                else
                {
                    cmd = new MySqlCommand (String.Format("Select * from Receipt where ORNumber = {0} AND Deleted = 0",ReceiptID), con);
                    if (RecExists(cmd.ExecuteReader()) == false)
                    {
                        cmd = new MySqlCommand(String.Format("Insert Into Receipt(CustomerName,AmountDue,CashTendered,TransDate,Discount,ItemDiscount, Deleted) Values('{0}',{1},{2},'{3}',{4},{5},0)", cashier, AmountDue, CashTendered, transdate.ToString("yyyy-MM-dd HH:mm:ss"), srdiscount, itemdiscount), con); // creating query command
                        cmdGetIdentity = new MySqlCommand ("SELECT @@IDENTITY", con);
                        object obj = cmdGetIdentity.ExecuteScalar();
                        if (obj != null && obj != DBNull.Value)
                            ReceiptID = Convert.ToInt32(obj);
                        cmdGetIdentity = null;
                    }
                    else
                    {
                        cmd = new MySqlCommand (String.Format("Update Receipt Set CustomerName='{0}',AmountDue={1},CashTendered={2},Discount={3},ItemDiscount={5},AccountId={6} WHERE ORNumber={4}", cashier, AmountDue, CashTendered, srdiscount, ReceiptID,itemdiscount,accountid), con); // creating query command
                        cmd.ExecuteNonQuery();
                    }
                }

                //if (ReceiptID==0)
                //{
                //    cmd = new MySqlCommand ("Select Top 1 ORNumber from Receipt Order by ORNumber desc", con);
                //    MySqlDataReader  reader = cmd.ExecuteReader();
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
        private bool RecExists(MySqlDataReader dbr)
        {
            bool found = dbr.HasRows;
            dbr.Close();
            return found;
        }
        public bool CreateTempReceipt( ref Int32 ReceiptID, string cashier, double AmountDue, double CashTendered, double srdiscount, double itemdiscount, Int32 accountid )
        {
            try
            {
                MySqlCommand  cmd = null;
                MySqlCommand  cmdGetIdentity;
                if (ReceiptID == 0)
                {
                    cmd = new MySqlCommand (String.Format("Insert Into TempReceipt(CustomerName,AmountDue,CashTendered,TransDate,Discount,ItemDiscount,AccountId, Deleted) Values('{0}',{1},{2},'{3}',{4},{5},{6},0)", cashier, AmountDue, CashTendered, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString(), srdiscount, itemdiscount, accountid), con); // creating query command
                    cmd.ExecuteNonQuery();
                    cmdGetIdentity = new MySqlCommand ("SELECT @@IDENTITY", con);
                    object obj = cmdGetIdentity.ExecuteScalar();
                    if (obj != null && obj != DBNull.Value)
                        ReceiptID = Convert.ToInt32(obj);
                    cmdGetIdentity = null;
                }
                else
                {
                    cmd = new MySqlCommand (String.Format("Select * from TempReceipt where ORNumber = {0} AND Deleted = 0", ReceiptID), con);
                    if (RecExists(cmd.ExecuteReader())==false)
                    {
                        cmd = new MySqlCommand (String.Format("Insert Into TempReceipt(CustomerName,AmountDue,CashTendered,TransDate,Discount,ItemDiscount, Deleted) Values('{0}',{1},{2},'{3}',{4},{5},0)", cashier, AmountDue, CashTendered, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString(), srdiscount, itemdiscount), con); // creating query command
                        cmdGetIdentity = new MySqlCommand ("SELECT @@IDENTITY", con);
                        object obj = cmdGetIdentity.ExecuteScalar();
                        if (obj != null && obj != DBNull.Value)
                            ReceiptID = Convert.ToInt32(obj);
                        cmdGetIdentity = null;
                    }
                    else
                    {
                        cmd = new MySqlCommand (String.Format("Update TempReceipt Set CustomerName='{0}',AmountDue={1},CashTendered={2},Discount={3},ItemDiscount={5},AccountId={6} WHERE ORNumber={4}", cashier, AmountDue, CashTendered, srdiscount, ReceiptID, itemdiscount, accountid), con); // creating query command
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

        public bool RemoveFromHistory(Int32 receiptid)
        {
            try
            {
                MySqlCommand  cmd = new MySqlCommand (String.Format("Update TransactionHistory Set Deleted=1 WHERE ORNumber = {0}", receiptid), con); // creating query command

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
                MySqlCommand  cmd = new MySqlCommand (String.Format("Update TempTransactionHistory Set Deleted=1 WHERE ORNumber = {0}", receiptid), con); // creating query command

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

        public bool AddTransaction(clsPurchasedItem purchaseditem)
        {
            try
            {
                MySqlCommand  cmd = new MySqlCommand (String.Format("Insert Into TransactionHistory (ORNumber,Barcode,Description,Amount,Qty,TotalAmount,IsWholeSale,userid,Deleted,Discount,Capital,unit,instorage) Values({0},'{1}','{2}',{3},{4},{5},{6},{7},0,{8},{9},'{10}',{11})", purchaseditem.ORNumber, purchaseditem.BarCode.Replace("'", "''"),
                    purchaseditem.Description.Replace("'","''"), purchaseditem.Amount, purchaseditem.Qty, purchaseditem.Amount * purchaseditem.Qty, purchaseditem.IsWholeSale ? 1 : 0, purchaseditem.UserID, purchaseditem.Discount,purchaseditem.Capital,purchaseditem.Unit,purchaseditem.InStorage), con); // creating query command

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
                MySqlCommand  cmd = new MySqlCommand (String.Format("Insert Into TempTransactionHistory (ORNumber,Barcode,Description,Amount,Qty,TotalAmount,IsWholeSale,userid,Deleted,Discount,Capital,unit,instorage) Values({0},'{1}','{2}',{3},{4},{5},{6},{7},0,{8},{9},'{10}',{11})", purchaseditem.ORNumber, purchaseditem.BarCode.Replace("'", "''"),
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

        public Receipt RetrieveReceiptInfo(Int32 ORNum)
        {
            Receipt receipt = new Receipt();
            string sql = String.Format("Select * from view_Receipt where ORNumber = {0} AND Deleted=0 Order By ORNumber Desc LIMIT 1", ORNum);
            MySqlCommand  cmd = new MySqlCommand (sql, con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
            if (reader.Read()) // if can read row from database
            {
                receipt.ORNumber = int.Parse(reader["ORNumber"].ToString());
                receipt.CashierName = reader["CustomerName"].ToString();
                receipt.CashTendered = double.Parse(reader["CashTendered"].ToString());
                receipt.TransDate = DateTime.Parse(reader["TransDate"].ToString());
                receipt.SeniorDiscount = double.Parse(reader["Discount"].ToString());
                receipt.Accountid = int.Parse(reader["Accountid"].ToString());
                receipt.AccountName = reader["AccountName"].ToString();
            }
            if (!reader.IsClosed) reader.Close();
            receipt.PurchasedItems = GetPurchasedItems(receipt.ORNumber);
            return receipt;
        }

        public Receipt RetrieveTempReceiptInfo( Int32 ORNum )
        {
            Receipt receipt = new Receipt();
            string sql = String.Format("Select * from TempReceipt where ORNumber = {0} AND Deleted=0 Order By ORNumber Desc Limit 1", ORNum);
            MySqlCommand  cmd = new MySqlCommand (sql, con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
            if (reader.Read()) // if can read row from database
            {
                receipt.ORNumber = int.Parse(reader["ORNumber"].ToString());
                receipt.CashierName = reader["CustomerName"].ToString();
                receipt.CashTendered = double.Parse(reader["CashTendered"].ToString());
                receipt.TransDate = DateTime.Parse(reader["TransDate"].ToString());
                receipt.SeniorDiscount = double.Parse(reader["Discount"].ToString());
            }
            if (!reader.IsClosed) reader.Close();
            receipt.PurchasedItems = GetPurchasedItems(receipt.ORNumber);

            return receipt;
        }
        public List<Receipt> GetTempReceiptInfo()
        {
            List<Receipt> lstReceipt = new List<Receipt>();
            string sql = String.Format("Select * from TempReceipt WHERE Deleted=0 Order By ORNumber Asc");
            MySqlCommand  cmd = new MySqlCommand (sql, con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query

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

                    //receipt.PurchasedItems = GetTempPurchasedItems(receipt.ORNumber);
                    receipt.SeniorDiscount = double.Parse(reader["Discount"].ToString());
                    try
                    {
                        if (reader["itemdiscount"] != DBNull.Value)
                            receipt.WholeSaleDiscount = double.Parse(reader["ItemDiscount"].ToString());
                    }
                    catch { }
                    lstReceipt.Add(receipt);
                }
                if (!reader.IsClosed) reader.Close();
                foreach (Receipt or in lstReceipt)
                {
                    or.PurchasedItems = GetTempPurchasedItems(or.ORNumber);
                }
            }
            if (!reader.IsClosed) reader.Close();

            return lstReceipt;
        }

        public List<Receipt> GetReceiptInfo(DateTime startdate , DateTime enddate,string cashier,bool includepurchases=true)
        {
            List<Receipt> lstReceipt = new List<Receipt>();
            string sql = String.Format("Select * from view_Receipt WHERE TransDate >= '{0:yyyy/MM/dd 06:00:00}' and TransDate<= '{1:yyyy/MM/dd 06:00:00}' and Deleted=0 and CustomerName like '%{2}%' Order By TransDate Asc", startdate, enddate, cashier);
            MySqlCommand  cmd = new MySqlCommand (sql, con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query

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
                    
                    receipt.SeniorDiscount = double.Parse(reader["Discount"].ToString());
                    receipt.AccountName = reader["AccountName"].ToString();
                    try
                    { 
                        if(reader["itemdiscount"]!=DBNull.Value)
                    receipt.WholeSaleDiscount = double.Parse(reader["ItemDiscount"].ToString());
                    }catch{
                    }

                    lstReceipt.Add(receipt);
                }
                if (!reader.IsClosed) reader.Close();

                foreach (Receipt receipt in lstReceipt)
                {
                    receipt.PurchasedItems = (includepurchases ? GetPurchasedItems(receipt.ORNumber) : new Dictionary<string, clsPurchasedItem>());
                }
            }
            if (!reader.IsClosed) reader.Close();

            return lstReceipt;
        }

        public List<double> GetSalesInfo(DateTime startdate, DateTime enddate, string cashier)
        {
            List<double> ret=new List<double>();
            double totsales = 0,totcharges=0,totalincome=0,totaldiscount=0,totAddlDisc =0;
            string sql = "";

            if(cashier=="")
                sql = String.Format("Select sum(AmountDue) from Receipt WHERE TransDate between '{0:yyyy/MM/dd 06:00:00}' and '{1:yyyy/MM/dd 06:00:00}' and deleted=0", startdate, enddate);
            else 
                sql = String.Format("Select sum(AmountDue) from Receipt WHERE TransDate between '{0:yyyy/MM/dd 06:00:00}' and '{1:yyyy/MM/dd 06:00:00}' and CustomerName = '{2}' and deleted=0", startdate, enddate, cashier);
            MySqlCommand  cmd = new MySqlCommand (sql, con); // creating query command
            object obj = cmd.ExecuteScalar(); // executes query
            if (obj != null && obj != DBNull.Value)
            {
                totsales = Convert.ToDouble(obj);
            }

            if (cashier == "")
                sql = String.Format("Select sum(discount*qty) from view_transaction WHERE TransDate between '{0:yyyy/MM/dd 06:00:00}' and '{1:yyyy/MM/dd 06:00:00}' and deleted=0", startdate, enddate);
            else
                sql = String.Format("Select sum(discount*qty) from view_transaction WHERE TransDate between '{0:yyyy/MM/dd 06:00:00}' and '{1:yyyy/MM/dd 06:00:00}' and UserName = '{2}' and deleted=0", startdate, enddate, cashier);
            cmd = new MySqlCommand (sql, con); // creating query command
            obj = cmd.ExecuteScalar(); // executes query
            if (obj != null && obj != DBNull.Value)
            {
                totaldiscount = Convert.ToDouble(obj);
            }


            if (cashier == "")
                sql = String.Format("Select sum(discount) from receipt WHERE TransDate between '{0:yyyy/MM/dd 06:00:00}' and '{1:yyyy/MM/dd 06:00:00}' and deleted=0", startdate, enddate);
            else
                sql = String.Format("Select sum(discount) from receipt WHERE TransDate between '{0:yyyy/MM/dd 06:00:00}' and '{1:yyyy/MM/dd 06:00:00}' and CustomerName = '{2}' and deleted=0", startdate, enddate, cashier);
            cmd = new MySqlCommand (sql, con); // creating query command
            obj = cmd.ExecuteScalar(); // executes query
            if (obj != null && obj != DBNull.Value)
            {
                totAddlDisc = Convert.ToDouble(obj);
            }


            if(cashier=="")
                sql = String.Format("Select sum((amount-discount-capital)*qty) from view_transaction WHERE TransDate between '{0:yyyy/MM/dd 06:00:00}' and '{1:yyyy/MM/dd 06:00:00}' and deleted=0", startdate, enddate);
            else
                sql = String.Format("Select sum((amount-discount-capital)*qty) from view_transaction WHERE TransDate between '{0:yyyy/MM/dd 06:00:00}' and '{1:yyyy/MM/dd 06:00:00}' and UserName = '{2}' and deleted=0", startdate, enddate, cashier);
            cmd = new MySqlCommand (sql, con); // creating query command
            obj = cmd.ExecuteScalar(); // executes query
            if (obj != null && obj != DBNull.Value)
            {
                totalincome = Math.Round(Convert.ToDouble(obj),2)-totAddlDisc;
            }
            if(cashier=="")
                sql = String.Format("Select sum(charged_amount) from view_chargetransactions WHERE timestamp >= '{0:yyyy/MM/dd 06:00:00}' and timestamp<= '{1:yyyy/MM/dd 06:00:00}' and Deleted=0", startdate, enddate);
            else
                sql = String.Format("Select sum(charged_amount) from view_chargetransactions WHERE timestamp >= '{0:yyyy/MM/dd 06:00:00}' and timestamp<= '{1:yyyy/MM/dd 06:00:00}' and Deleted=0 and LoginName = '{2}'", startdate, enddate, cashier);
            cmd = new MySqlCommand (sql, con); // creating query command
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

        public Int32 GetSoldItems(string barcode)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            string sql = String.Format("Select sum(qty) from TransactionHistory WHERE barcode='{0}' and Deleted=0", barcode);
            MySqlCommand  cmd = new MySqlCommand (sql, con); // creating query command
            object obj= cmd.ExecuteScalar(); // executes query
            if (obj == DBNull.Value) return 0;
            Int32 ret = Convert.ToInt32(obj);
            return ret;
        }


        public static Int32 GetNextORNumber()
        {
            string sql = String.Format("Select ORNumber from Receipt order by ORNumber Desc");
            MySqlConnection  con = new MySqlConnection (Properties.Settings.Default.dbConnectionString1 + string.Format("Password={0};",DBPassword));  // connection string change database name and password here.
            con.Open();
            try
            {
                MySqlCommand  cmd = new MySqlCommand (sql, con); // creating query command
                MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
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
            MySqlConnection  con = new MySqlConnection (Properties.Settings.Default.dbConnectionString1 + string.Format("Password={0};",DBPassword));  // connection string change database name and password here.
            con.Open();

            MySqlCommand  cmd = new MySqlCommand (sql, con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
            try
            {
                if (reader.HasRows == true && reader.Read()) // if can read row from database
                {
                    Int32 ret = Int32.Parse(reader["SKU_ID"].ToString()) + 1;
                    if (!reader.IsClosed) reader.Close();
                    cmd = new MySqlCommand (string.Format("Update SKU set SKU_ID={0}", ret), con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return ret;
                }
                else
                {
                    reader.Close();
                    cmd = new MySqlCommand (string.Format("Insert Into SKU(ID,SKU_ID) VALUES(1,100)"), con);
                    cmd.ExecuteNonQuery();
                    if (!reader.IsClosed) reader.Close();
                    con.Close();
                    return GetNextSKU();
                }
            }
            catch { }
            if (!reader.IsClosed) reader.Close();
            con.Close();
            return 1;
        }

        public double GetTotalQtySold(string barcode)
        {
            double totalqty = 0;
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();
                MySqlCommand  cmd = new MySqlCommand ("Select sum(qty) as TotalQty from transactionhistory WHERE barcode = '" + barcode.Replace("'", "''") + "' AND Deleted=0", con); // creating query command
                MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
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

        private Dictionary<string, clsPurchasedItem> GetPurchasedItems(Int32 ORNum)
        {
            Dictionary<string, clsPurchasedItem> dicPurchasedItems = new Dictionary<string, clsPurchasedItem>();
            string sql = string.Format("Select * from view_transaction3 where ORNumber = {0} and Deleted=0 " , ORNum);
            MySqlCommand  cmd = new MySqlCommand (sql, con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
            if (reader.HasRows)
            {
                try
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
                        if (dicPurchasedItems.ContainsKey(item.BarCode) == false) dicPurchasedItems.Add(item.BarCode, item);

                    }
                }
                catch { }
            }
            if (!reader.IsClosed) reader.Close();
            return dicPurchasedItems;
        }

        public List<clsPurchasedItem> GetTransactionsFrmDate(DateTime startDate, DateTime endDate)
        {
            List<clsPurchasedItem> dicPurchasedItems = new List<clsPurchasedItem>();
            string sql = string.Format("Select * from view_transaction3 where transdate between '{0}' and '{1}' and Deleted=0 ", startDate,endDate);
            MySqlCommand  cmd = new MySqlCommand (sql, con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
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
            MySqlCommand  cmd = new MySqlCommand (sql, con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
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

        public Dictionary<string, clsPurchasedItem> GetProductSales(DateTime dateStart, DateTime dateEnd, string username = "")
        {
            Dictionary<string, clsPurchasedItem> dicPurchasedItems = new Dictionary<string, clsPurchasedItem>();
            string sql = String.Format("Select * from view_transaction WHERE TransDate between '{0:yyyy/MM/dd 06:00:00}' and '{1:yyyy/MM/dd 06:00:00}' and deleted = 0 Order by Barcode", dateStart, dateEnd,username);

            MySqlCommand  cmd = new MySqlCommand (sql, con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
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

        public bool UserNameExists(string username)
        {
            MySqlCommand  cmd = new MySqlCommand (string.Format("Select LoginName from UserAccount where LoginName = '{0}'",username), con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
            bool ret = reader.HasRows;
            reader.Close();
            con.Close();
            return ret;

        }
        public static bool HaveAdmin()
        {
            try
            {
                MySqlConnection  con = new MySqlConnection (Properties.Settings.Default.dbConnectionString1 + string.Format("Password={0};",DBPassword));  // connection string change database name and password here.
                con.Open();

                string sql = string.Format("Select * from UserAccount where LoginType=1 AND Enabled=1");
                MySqlCommand  cmd = new MySqlCommand (sql, con); // creating query command
                MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
                bool ret = reader.HasRows;
                reader.Close();
                con.Close();
                return ret;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public clsUsers Login(string username, string password)
        {
            string sql = string.Format("Select * from UserAccount where LoginName = '{0}' and Password = '{1}'", username, License.POSLicense.EncryptPassword(password));
            MySqlCommand  cmd = new MySqlCommand (sql, con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
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
            MySqlCommand  cmd = new MySqlCommand (sql, con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
            List<string > users = new List<string>();
            if (reader.HasRows)
            {
                while(reader.Read())
                    users.Add(reader["LoginName"].ToString());
            }
            reader.Close();
            return users;
        }
        public List<clsUsers> GetUsers()
        {
            string sql = string.Format("Select * from UserAccount");
            MySqlCommand  cmd = new MySqlCommand (sql, con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
            List<clsUsers> users = new List<clsUsers>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    clsUsers user = new clsUsers();
                    user.UserId = Convert.ToInt32(reader["UserId"].ToString());
                    user.UserName = reader["LoginName"].ToString();
                    user.LoginType = Convert.ToInt32(reader["LoginType"]);
                    user.Enabled = Convert.ToInt32(reader["Enabled"]) == 1 ? true : false ;
                    user.Password = "";
                    users.Add(user);
                }
            }
            reader.Close();
            return users;
        }
        public bool SaveUser(clsUsers user)
        {
            try
            {
                MySqlCommand  cmd = new MySqlCommand (String.Format("Select * from UserAccount where LoginName = '{0}'", user.UserName), con);
                if (RecExists(cmd.ExecuteReader()) == false)
                {
                    string sql = String.Format("Insert Into UserAccount (LoginType,LoginName,Password,Enabled,LoginAttemp) VALUES({0},'{1}','{2}',{3},{4})", user.LoginType, user.UserName, License.POSLicense.EncryptPassword(user.Password), user.Enabled ? 1 : 0, user.LogInAttempt);
                    cmd = new MySqlCommand (sql, con); // creating query command

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
                        sql = String.Format("Update UserAccount Set LoginType = {0}, Password]= '{1}', Enabled]={2},[LoginAttemp]={3},[LoginName ='{4}' WHERE LoginName ='{4}'", user.LoginType, License.POSLicense.EncryptPassword(user.Password), user.Enabled ? 1 : 0, user.LogInAttempt, user.UserName);
                    }
                    else
                    {
                        sql = String.Format("Update UserAccount Set LoginType = {0}, Enabled]={1},[LoginAttemp]={2} WHERE LoginName ='{3}'", user.LoginType, user.Enabled ? 1 : 0, user.LogInAttempt, user.UserName);
                    }
                    
                    cmd = new MySqlCommand (sql, con); // creating query command

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

        public bool SaveExpenses(clsExpenses expenses)
        {
            try
            {
                MySqlCommand  cmd = null;
                string sql ="";
                if (expenses.Expense_id > 0)
                {
                    sql = String.Format("Update expenses set Description]='{0}',[Amount]={1} where expense_id = {2}", expenses.Description, expenses.Amount,expenses.Expense_id);
                    cmd = new MySqlCommand (sql, con); // creating query command

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                }
                else
                {
                    sql = String.Format("Insert Into expenses (Description,Amount,UserId,UserName,Timestamp,Deleted) VALUES('{0}',{1},{2},'{3}','{4:yyyy-MM-dd HH:mm:ss}',0)", expenses.Description, expenses.Amount, expenses.UserId, expenses.UserName, expenses.Timestamp);
                    cmd = new MySqlCommand (sql, con); // creating query command

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




        public bool DeleteExpenses(Int32 ExpenseId)
        {
            try
            {
                MySqlCommand  cmd = null;
                cmd = new MySqlCommand (String.Format("Update expenses Set Deleted=1 Where expense_id={0}", ExpenseId), con);
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

        public List<clsExpenses> GetExpenses(DateTime dateStart,DateTime dateEnd, string username="")
        {
            MySqlCommand  cmd = null;
            if (username =="")
                cmd = new MySqlCommand (string.Format("Select * from expenses WHERE timestamp between '{0} 06:00:00' and '{1} 06:00:00' and Deleted=0", dateStart.ToString("yyyy-MM-dd"), dateEnd.ToString("yyyy-MM-dd")), con); // creating query command
            else
                cmd = new MySqlCommand (string.Format("Select * from expenses WHERE timestamp between '{0} 06:00:00' and '{1} 06:00:00' and Deleted=0 and username='{2}'", dateStart.ToString("yyyy-MM-dd"), dateEnd.ToString("yyyy-MM-dd"),username), con); // creating query command
            
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
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


        public double GetTotalExpenses(DateTime dateStart, DateTime dateEnd, string username = "")
        {
            MySqlCommand  cmd = null;
            double ret = 0;
            try
            {
                if (username == "")
                    cmd = new MySqlCommand (string.Format("Select sum(amount) as Total from expenses WHERE timestamp between '{0} 06:00:00' and '{1} 06:00:00' and Deleted=0", dateStart.ToString("yyyy-MM-dd"), dateEnd.ToString("yyyy-MM-dd")), con); // creating query command
                else
                    cmd = new MySqlCommand (string.Format("Select sum(amount) as Total from expenses WHERE timestamp between '{0} 06:00:00' and '{1} 06:00:00' and Deleted=0 and username='{2}'", dateStart.ToString("yyyy-MM-dd"), dateEnd.ToString("yyyy-MM-dd"), username), con); // creating query command

                object obj = cmd.ExecuteScalar(); // executes query
                if (obj != null && obj != DBNull.Value)
                    ret = Convert.ToDouble(obj);
            }
            catch { }

           return ret ;
        }

        public bool SaveInitialCash(clsInitCash initCash)
        {
            try
            {
                MySqlCommand  cmd = null;

                string sql = String.Format("Select id from initialcash where timestamp between '{0} 06:00:00' and '{1} 06:00:00' and userid={2}",initCash.Timestamp.ToString("yyyy-MM-dd"),initCash.Timestamp.AddDays(1).ToString("yyyy-MM-dd"),initCash.UserId);
                cmd = new MySqlCommand (sql, con); // creating query command
                object obj = cmd.ExecuteScalar();
                if (obj != DBNull.Value && obj != null)
                {
                    int id = Convert.ToInt16(obj);
                    if (id > 0)
                    {
                        sql = String.Format("Update initialcash set amount = {0}, Timestamp ='{1:yyyy-MM-dd HH:mm:ss}' where id={2}", initCash.Amount,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), id);
                        cmd = new MySqlCommand (sql, con); // creating query command

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    sql = String.Format("Insert Into initialcash (Amount,UserId,UserName,Timestamp,Deleted) VALUES({0},{1},'{2}','{3}',0)", initCash.Amount, initCash.UserId, initCash.UserName, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd = new MySqlCommand (sql, con); // creating query command

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

        public bool DeleteInitialCash(Int32 initCashId)
        {
            try
            {
                MySqlCommand  cmd = null;
                cmd = new MySqlCommand (String.Format("Update initialcash Set Deleted=1 Where id={0}", initCashId), con);
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

        public double GetInitialCash(DateTime date,int userid)
        {
            double amount = 0;
            string sql = string.Format("Select * from initialcash WHERE timestamp >= '{0} 06:00:00' and timestamp <= '{1} 06:00:00' and userid={2} and Deleted=0", date.ToString("yyyy-MM-dd"), date.AddDays(1).ToString("yyyy-MM-dd"), userid);
            MySqlCommand  cmd = new MySqlCommand (sql, con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
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

        public double GetInitialCash(DateTime date, string username)
        {
            double amount = 0;
            string sql = string.Format("Select * from initialcash WHERE timestamp >= '{0} 06:00:00' and timestamp <= '{1} 06:00:00' and username='{2}' and Deleted=0", date.ToString("yyyy-MM-dd"), date.AddDays(1).ToString("yyyy-MM-dd"), username);
            MySqlCommand  cmd = new MySqlCommand (sql, con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
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
        public double TotalUnclaimedCash(int accountid)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            MySqlCommand  cmd = new MySqlCommand ("Select sum(amount) from _unclaimedcash WHERE accountid = " + accountid.ToString() + " AND Deleted=0", con); // creating query command
            object obj = cmd.ExecuteScalar();
            if (obj != null && obj != DBNull.Value)
                return Convert.ToDouble(obj);
            return 0;
        }

        public List<clsUnclaimedCash> GetUnclaimedCash(int accountid)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            MySqlCommand  cmd = new MySqlCommand ("Select * from _unclaimedcash WHERE accountid = " + accountid.ToString() + " AND Deleted=0 order by timestamp asc", con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
            clsUnclaimedCash uc = null;
            List<clsUnclaimedCash> lstUc = new List<clsUnclaimedCash>();
            if (reader.HasRows) // if can read row from database
            {
                while (reader.Read())
                {
                    try
                    {
                        uc = BuildUnclaimedCash(reader);
                        if (uc != null)
                            lstUc.Add(uc);
                    }
                    catch { }
                }
            }
            if (!reader.IsClosed) reader.Close();
            return lstUc;
        }

        public clsUnclaimedCash GetUnclaimedCash(string refnum, int accountid)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from _unclaimedcash WHERE refnum = '{0}' AND Deleted=0", con); // creating query command
            MySqlDataReader reader = cmd.ExecuteReader(); // executes query
            clsUnclaimedCash uc = null;
            if (reader.HasRows) // if can read row from database
            {
                if (reader.Read())
                {
                    try
                    {
                        uc = BuildUnclaimedCash(reader);
                    }
                    catch { }
                }
            }
            if (!reader.IsClosed) reader.Close();
            return uc;
        }

        public bool SaveUnclaimedCash(clsUnclaimedCash unclaimed)
        {
            try
            {
                MySqlCommand cmd = null;

                string sql = String.Format("Select id_unclaimedcash from _unclaimedcash where refnum='{0}' and accountid = {1} and deleted=0", unclaimed.RefNum,unclaimed.LoadAccountId);
                cmd = new MySqlCommand(sql, con); // creating query command
                object obj = cmd.ExecuteScalar();
                if (obj != DBNull.Value && obj != null)
                {
                    int id = Convert.ToInt16(obj);
                    if (id > 0)
                    {
                        sql = String.Format("Update _unclaimedcash set amount = {0}, refnum ='{1}', smartmoney='{2}',userid = {3},timestamp='{4:yyyy-MM-dd HH:mm:ss}' where id_unclaimedcash={5}", unclaimed.Amount, unclaimed.RefNum,unclaimed.SmartMoney,unclaimed.UserId,DateTime.Now, id);
                        cmd = new MySqlCommand(sql, con); // creating query command

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    sql = String.Format("Insert Into _unclaimedcash (Amount,accountid, UserId,refnum,smartmoney,Timestamp,Deleted) VALUES({0},{1},{2},'{3}','{4}','{5:yyyy-MM-dd HH:mm:ss}',0)", unclaimed.Amount,unclaimed.LoadAccountId, unclaimed.UserId, unclaimed.RefNum,unclaimed.SmartMoney, unclaimed.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd = new MySqlCommand(sql, con); // creating query command

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
        public bool ClaimCash(string refnum)
        {
            try
            {
                MySqlCommand cmd = null;
                cmd = new MySqlCommand(String.Format("Update _unclaimedcash Set Deleted=1 Where refnum= '{0}'", refnum), con);
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


        public bool SaveDepositCash( clsDepositCash initCash )
        {
            try
            {
                MySqlCommand  cmd = null;

                string sql = String.Format("Select id from Depositcash where timestamp between '{0} 06:00:00' and '{1} 06:00:00' and userid={2}", initCash.Timestamp.ToString("yyyy-MM-dd"), initCash.Timestamp.AddDays(1).ToString("yyyy-MM-dd"), initCash.UserId);
                cmd = new MySqlCommand (sql, con); // creating query command
                object obj = cmd.ExecuteScalar();
                if (obj != DBNull.Value && obj != null)
                {
                    int id = Convert.ToInt16(obj);
                    if (id > 0)
                    {
                        sql = String.Format("Update Depositcash set amount = {0}, Timestamp ='{1:yyyy-MM-dd HH:mm:ss}' where id={2}", initCash.Amount, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), id);
                        cmd = new MySqlCommand (sql, con); // creating query command

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    sql = String.Format("Insert Into Depositcash (Amount,UserId,UserName,Timestamp,Deleted) VALUES({0},{1},'{2}','{3}',0)", initCash.Amount, initCash.UserId, initCash.UserName, initCash.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd = new MySqlCommand (sql, con); // creating query command

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
                MySqlCommand  cmd = null;
                cmd = new MySqlCommand (String.Format("Update Depositcash Set Deleted=1 Where id={0}", initCashId), con);
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

        public double GetDepositCash( DateTime date, int userid )
        {
            double amount = 0;
            string sql = string.Format("Select * from Depositcash WHERE timestamp >= '{0} 06:00:00' and timestamp <= '{1} 06:00:00' and userid={2} and Deleted=0", date.ToString("yyyy-MM-dd"), date.AddDays(1).ToString("yyyy-MM-dd"), userid);
            MySqlCommand  cmd = new MySqlCommand (sql, con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
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
            string sql = string.Format("Select * from Depositcash WHERE timestamp >= '{0} 06:00:00' and timestamp <= '{1} 06:00:00' and username='{2}' and Deleted=0", date.ToString("yyyy-MM-dd"), date.AddDays(1).ToString("yyyy-MM-dd"), username);
            MySqlCommand  cmd = new MySqlCommand (sql, con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
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


        public double GetActualCOH(DateTime date, string username)
        {
            double amount = 0;
            string sql = string.Format("Select * from checkout WHERE timeout = '{0} 00:00:00' and username='{1}' Limit 1", date.ToString("yyyy-MM-dd"), username);
            MySqlCommand  cmd = new MySqlCommand (sql, con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
            if (reader.HasRows)
            {
                if(reader.Read()) // if can read row from database
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
        public int GetCheckOutID(DateTime date, string username)
        {
            int id = 0;
            string sql = string.Format("Select * from checkout WHERE timeout = '{0} 00:00:00' and username='{1}' Limit 1", date.ToString("yyyy-MM-dd"), username);
            MySqlCommand cmd = new MySqlCommand(sql, con); // creating query command
            MySqlDataReader reader = cmd.ExecuteReader(); // executes query
            if (reader.HasRows)
            {
                if (reader.Read()) // if can read row from database
                {
                    try
                    {
                        id = int.Parse(reader["checkout_id"].ToString());
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            if (!reader.IsClosed) reader.Close();
            return id;
        }
        public bool SaveCheckOut(clsCheckOut chkout)
        {
            try
            {
                MySqlCommand  cmd = null;

                string sql = String.Format("Select checkout_id from CheckOut where timeout ='{0} 00:00:00' and userid={1}", chkout.Timestamp.ToString("yyyy-MM-dd"), chkout.UserId);
                cmd = new MySqlCommand (sql, con); // creating query command
                object obj = cmd.ExecuteScalar();
                if (obj != DBNull.Value && obj != null)
                {
                    int id = Convert.ToInt16(obj);
                    if (id > 0)
                    {
                        sql = String.Format("Update checkout set expectedcash = {0}, actualcash = {1}, timeout ='{2:yyyy-MM-dd} 00:00:00' where checkout_id={3}", chkout.ExpectedAmount, chkout.ActualAmount, chkout.Timestamp, id);
                        cmd = new MySqlCommand (sql, con); // creating query command

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    sql = String.Format("Insert Into checkout (expectedcash,actualcash,UserId,UserName,timeout) VALUES({0},{1},{2},'{3}','{4:yyyy-MM-dd} 00:00:00')", chkout.ExpectedAmount, chkout.ActualAmount, chkout.UserId, chkout.UserName, chkout.Timestamp);
                    cmd = new MySqlCommand (sql, con); // creating query command

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

        public List<clsCheckOut> GetCheckOut(DateTime dateStart, DateTime dateEnd, int userid = 0)
        {
            MySqlCommand  cmd = null;
            if (userid == 0)
                cmd = new MySqlCommand (string.Format("Select * from checkout WHERE timeout = '{0} 00:00:00' ", dateStart.ToString("yyyy-MM-dd")), con); // creating query command
            else
                cmd = new MySqlCommand (string.Format("Select * from checkout WHERE timeout = '{0} 00:00:00' and userid={1}", dateStart.ToString("yyyy-MM-dd"), userid), con); // creating query command

            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
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
        public static bool AddCategory(string Category)
        {
            string sql = string.Format("Select categoryid from Categories where description='" + Category + "' Limit 1");
            bool ret = false;
            MySqlConnection  con = new MySqlConnection (Properties.Settings.Default.dbConnectionString1 + string.Format("Password={0};",DBPassword));  // connection string change database name and password here.
            con.Open();
            try
            {
                MySqlCommand  cmd = new MySqlCommand (sql, con); // creating query command
                MySqlCommand cmdGetIdentity; 
                
                object obj = cmd.ExecuteScalar(); // executes query;
                if (obj != null && obj != DBNull.Value)
                {
                    ret = false;
                }
                else
                {
                    cmd = new MySqlCommand ("INSERT INTO Categories (description) VALUES('" + Category + "')", con);
                    if (cmd.ExecuteNonQuery() > 0) ret = true;
                    else ret = false; 
                    
                    cmdGetIdentity = new MySqlCommand("SELECT @@IDENTITY", con);
                    obj = cmdGetIdentity.ExecuteScalar();
                    int id = 0;
                    if (obj != null && obj != DBNull.Value)
                    {
                        id = Convert.ToInt32(obj);
                        clsProductItem item = new clsProductItem();
                        item.BarCode = "A" + id.ToString();
                        item.Description = string.Format("New Item ({0})", Category);
                        item.Amount = 1;
                        item.Capital = 1;
                        item.WSAmount = 1;
                        item.CategoryId = id;
                        item.Category = Category;
                        item.CriticalLevel = 10;
                        item.InStorage = 0;
                        item.Imagepath = "";
                        item.Unit = "pc";
                        item.Save();
                    }

                    
                }
            }
            catch { }

            con.Close();
            return ret;
        }

        public static bool DeleteCategory(int id)
        {
            bool ret = false;
            MySqlConnection  con = new MySqlConnection (Properties.Settings.Default.dbConnectionString1 + string.Format("Password={0};",DBPassword));  // connection string change database name and password here.
            con.Open();
            try
            {
                string sql = string.Format("DELETE from Categories where categoryid=" + id.ToString());
                MySqlCommand  cmd = new MySqlCommand (sql, con); // creating query command
                if (cmd.ExecuteNonQuery()>0) ret = true;
            }
            catch { }

            con.Close();
            return ret;
        }

        public static Dictionary<int,string> GetCategories()
        {
            string sql = string.Format("Select * from Categories");
            MySqlConnection  con = new MySqlConnection (Properties.Settings.Default.dbConnectionString1 + string.Format("Password={0};",DBPassword));  // connection string change database name and password here.
            con.Open();

            MySqlCommand  cmd = new MySqlCommand (sql, con); // creating query command
            MySqlDataReader  reader = cmd.ExecuteReader(); // executes query
            Dictionary<int, string> Categories = new Dictionary<int, string>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Categories.Add(Convert.ToInt32(reader["categoryid"].ToString()), reader["description"].ToString());
                }
            }
            if(reader!=null) reader.Close();
            con.Close();
            return Categories;
        }


        public bool SaveGCash(clsGCashTransaction gcashtrans, ref int id)
        {
            bool ret = false;
            if (con.State == ConnectionState.Closed) con.Open();

            MySqlCommand cmd = null;
            cmd = new MySqlCommand("Select refnum from _gcashtransaction WHERE refnum = '" + gcashtrans.RefNum + "' AND Deleted=0", con); // creating query command
            
            if (gcashtrans.TransactionType == GCashTransType.RemitCancel || gcashtrans.TransactionType == GCashTransType.RemitSend)
            {
                cmd = new MySqlCommand(string.Format("Insert into _gcashtransaction (userid,accountid,loadid,TransactionAmount,SvcFeeAmount,SenderName,SenderContact,RecipientName,RecipientContact,RefNum,Remarks,transtype,transdate,country,gcashnumber,tenderedAmount,deleted) VALUES ({0},{1}, {2},{3},{4},'{5}','{6}','{7}','{8}','{9}','{10}',{11},'{12:yyyy-MM-dd HH:mm:ss}','{13}','{14}',{15},0) ",
                      gcashtrans.UserId, gcashtrans.AccountId, gcashtrans.Load_Id, gcashtrans.TransAmount, gcashtrans.SvcFeeAmount, gcashtrans.SenderName.Replace("'", "''"), gcashtrans.SenderContact.Replace("'", "''"), gcashtrans.RecipientName.Replace("'", "''"), gcashtrans.RecipientContact.Replace("'", "''"), gcashtrans.RefNum.Replace("'", "''"), gcashtrans.Remarks.Replace("'", "''"), (int)gcashtrans.TransactionType, gcashtrans.TransDate, gcashtrans.Country.Replace("'", "''"), gcashtrans.GCashNumber.Replace("'", "''"), gcashtrans.TenderedAmount), con);
                ret = cmd.ExecuteNonQuery() > 0;
                id = dbConnect.GetLastGCashTransId();
            }

            else
            {
                object obj = cmd.ExecuteScalar();
                if (obj != null && obj != DBNull.Value) // if can read row from database
                {
                    cmd = new MySqlCommand(string.Format("Update _gcashtransaction set userid = {1},accountid = {2},loadid = {3},TransactionAmount = {4},SvcFeeAmount = {5},SenderName = '{6}',SenderContact = '{7}',RecipientName = '{8}',RecipientContact = '{9}',RefNum = '{10}',Remarks = '{11}',transtype = {12},transdate='{13:yyyy-MM-dd HH:mm:ss}',country='{14}',gcashnumber='{15}',tenderedAmount={16} WHERE refnum = '{10}';",
                        gcashtrans.GCashtTransId, gcashtrans.UserId, gcashtrans.AccountId, gcashtrans.Load_Id, gcashtrans.TransAmount, gcashtrans.SvcFeeAmount, gcashtrans.SenderName.Replace("'", "''"), gcashtrans.SenderContact.Replace("'", "''"), gcashtrans.RecipientName.Replace("'", "''"), gcashtrans.RecipientContact, gcashtrans.RefNum.Replace("'", "''"), gcashtrans.Remarks.Replace("'", "''"), (int)gcashtrans.TransactionType, gcashtrans.TransDate, gcashtrans.Country.Replace("'", "''"), gcashtrans.GCashNumber.Replace("'", "''"), gcashtrans.TenderedAmount), con);
                    ret = cmd.ExecuteNonQuery() > 0;
                }
                else
                {

                    cmd = new MySqlCommand(string.Format("Insert into _gcashtransaction (userid,accountid,loadid,TransactionAmount,SvcFeeAmount,SenderName,SenderContact,RecipientName,RecipientContact,RefNum,Remarks,transtype,transdate,country,gcashnumber,tenderedAmount,deleted) VALUES ({0},{1}, {2},{3},{4},'{5}','{6}','{7}','{8}','{9}','{10}',{11},'{12:yyyy-MM-dd HH:mm:ss}','{13}','{14}',{15},0) ",
                        gcashtrans.UserId, gcashtrans.AccountId, gcashtrans.Load_Id, gcashtrans.TransAmount, gcashtrans.SvcFeeAmount, gcashtrans.SenderName.Replace("'", "''"), gcashtrans.SenderContact.Replace("'", "''"), gcashtrans.RecipientName.Replace("'", "''"), gcashtrans.RecipientContact.Replace("'", "''"), gcashtrans.RefNum.Replace("'", "''"), gcashtrans.Remarks.Replace("'", "''"), (int)gcashtrans.TransactionType, gcashtrans.TransDate, gcashtrans.Country.Replace("'", "''"), gcashtrans.GCashNumber.Replace("'", "''"), gcashtrans.TenderedAmount), con);
                    ret = cmd.ExecuteNonQuery() > 0;
                    id = dbConnect.GetLastGCashTransId();
                }
            }
            return ret;
        }

        public bool SaveELoad(clsEloadTransaction eLoad, ref int id)
        {
            bool ret = false;
            if (con.State == ConnectionState.Closed) con.Open();

            MySqlCommand cmd = null;
            cmd = new MySqlCommand("Select eloadtrans_id from _eloadtransaction WHERE eloadtrans_id = '" + eLoad.ELoadTrans_Id.ToString() + "' AND Deleted=0", con); // creating query command

            object obj = cmd.ExecuteScalar();
            if (obj != null && obj != DBNull.Value) // if can read row from database
            {
                cmd = new MySqlCommand(string.Format("Update _eloadtransaction set load_id = {1},transaction_amount = {2},amountdue = {3},discount = {4},timestamp = '{5:yyyy-MM-dd HH:mm:ss}',refnum = '{6}',remarks = '{7}',accountid = {8},userid = {9},mobilenum = '{10}',eloadstatus_id = {11},TenderedAmount={12} WHERE eloadtrans_id = {0};",
                    eLoad.ELoadTrans_Id, eLoad.Load_Id, eLoad.Transaction_Amount, eLoad.AmountDue, eLoad.Discount, eLoad.Timestamp, eLoad.RefNum, eLoad.Remarks, eLoad.AccountId, eLoad.UserId, eLoad.MobileNum, (int)eLoad.ELoadStatusId,eLoad.TenderedAmount), con);
                ret = cmd.ExecuteNonQuery() > 0;
            }
            else
            {
                cmd = new MySqlCommand(string.Format("Insert into _eloadtransaction (load_id,transaction_amount,amountdue,discount,timestamp,refnum,remarks,accountid,userid,mobilenum,eloadstatus_id,deleted,TenderedAmount) VALUES ( {0},{1},{2},{3},'{4:yyyy-MM-dd HH:mm:ss}','{5}','{6}',{7},{8},'{9}',{10},0,{11}) ",
                    eLoad.Load_Id, eLoad.Transaction_Amount, eLoad.AmountDue, eLoad.Discount, eLoad.Timestamp, eLoad.RefNum, eLoad.Remarks, eLoad.AccountId, eLoad.UserId, eLoad.MobileNum, (int)eLoad.ELoadStatusId,eLoad.TenderedAmount), con);
                ret = cmd.ExecuteNonQuery() > 0;
                id = dbConnect.GetLastELoadTransId();
            }
            return ret;
        }

        public bool SaveReLoadHistory(clsReloadHistory reload)
        {
            bool ret = false;
            if (con.State == ConnectionState.Closed) con.Open();

            MySqlCommand cmd = null;
            cmd = new MySqlCommand("Select reloadid from _reloadhistory WHERE reloadid = '" + reload.ReloadId.ToString() + "' AND Deleted=0", con); // creating query command

            object obj = cmd.ExecuteScalar();
            if (obj != null && obj != DBNull.Value) // if can read row from database
            {
                cmd = new MySqlCommand(string.Format("Update _reloadhistory set userid = {1},load_id = {2},refnum = '{3}',amount = {4},timestamp = '{5:yyyy-MM-dd HH:mm:ss}',Remarks = '{6}',ecashtransid = {7},remainingbalance = {8},transaction_amount = {9}, reloadType = {10} WHERE reloadid = {0};",
                    reload.ReloadId,reload.UserId, reload.Load_Id, reload.RefNum, reload.Amount, reload.Timestamp,reload.Remarks,reload.EcashTransId,reload.RemainingBalance,reload.TransactionAmount, reload.ReloadType), con);
                ret = cmd.ExecuteNonQuery() > 0;
            }
            else
            {
                cmd = new MySqlCommand(string.Format("Insert into _reloadhistory (userid,load_id ,refnum ,amount ,timestamp ,deleted,remarks,ecashtransid,remainingbalance,transaction_amount,reloadType) VALUES ( {0},{1},'{2}',{3},'{4:yyyy-MM-dd HH:mm:ss}',0,'{5}',{6},{7},{8}, {9}) ",
                    reload.UserId, reload.Load_Id, reload.RefNum, reload.Amount, reload.Timestamp, reload.Remarks, reload.EcashTransId, reload.RemainingBalance, reload.TransactionAmount, reload.ReloadType), con);
                ret = cmd.ExecuteNonQuery() > 0;

            }
            return ret;
        }
        public bool SaveSubDAccount(clsSubDAccount subd)
        {
            bool ret = false;
            if (con.State == ConnectionState.Closed) con.Open();

            MySqlCommand cmd = null;
            cmd = new MySqlCommand("Select id_subdaccounts from _subdaccounts WHERE mobilenum = '" + subd.MobileNum + "' AND Deleted=0", con); // creating query command

            object obj = cmd.ExecuteScalar();
            if (obj != null && obj != DBNull.Value) // if can read row from database
            {
                cmd = new MySqlCommand(string.Format("Update _subdaccounts set Name = '{1}',MobileNum = '{2}',Loadid = {3},Balance = {4}, Discount= {5} WHERE id_subdaccounts = {0};",
                    subd.Id_subdAccounts, subd.Name, subd.MobileNum, subd.LoadId, subd.Balance,subd.Discount), con);
            }
            else
            {
                cmd = new MySqlCommand(string.Format("Insert into _subdaccounts (Name,MobileNum,Loadid,Balance,Discount,deleted) VALUES ('{0}','{1}',{2},{3},{4}, 0) ",
                    subd.Name, subd.MobileNum, subd.LoadId, subd.Balance,subd.Discount), con);
            }
            ret = cmd.ExecuteNonQuery() > 0;
            return ret;
        }

        public bool DeleteSubDAccount(clsSubDAccount subd)
        {
            bool ret = false;
            if (con.State == ConnectionState.Closed) con.Open();

            MySqlCommand cmd = null;
            cmd = new MySqlCommand(string.Format("Update _subdaccounts set Deleted = 1 WHERE id_subdaccounts = {0};", subd.Id_subdAccounts), con);
            ret = cmd.ExecuteNonQuery() > 0;
            return ret;
        }

        public clsSubDAccount GetSubDAccount(string mobile)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from _subdaccounts WHERE mobilenum = '" + mobile + "' AND Deleted=0", con); // creating query command
            MySqlDataReader reader = cmd.ExecuteReader(); // executes query
            clsSubDAccount subdaccount = null;
            if (reader.HasRows) // if can read row from database
            {
                reader.Read();
                subdaccount = BuildSubDAccount(reader);
            }
            if (!reader.IsClosed) reader.Close();
            return subdaccount;
        }

        public List<clsSubDAccount> GetSubDAccounts(int loadid, string searchstr = "")
        {
            if (con.State == ConnectionState.Closed) con.Open();
            MySqlCommand cmd = null;
            if (searchstr == "")
                cmd = new MySqlCommand("Select * from _subdaccounts where loadid = " + loadid.ToString().Trim() + " and Deleted=0 order by Name", con); // creating query command
            else
                cmd = new MySqlCommand("Select * from _subdaccounts where (Name like '%" + searchstr + "%' or mobilenum like '%" + searchstr + "%') and loadid = " + loadid.ToString().Trim() + " and Deleted=0 order by Name", con); // creating query command

            MySqlDataReader reader = cmd.ExecuteReader(); // executes query
            clsSubDAccount subd = null;
            List<clsSubDAccount> lstSubd = new List<clsSubDAccount>();

            if (reader.HasRows) // if can read row from database
            {
                while (reader.Read())
                {
                    subd = BuildSubDAccount(reader);
                    lstSubd.Add(subd);
                }
            }
            if (!reader.IsClosed) reader.Close();
            return lstSubd;
        }
        public bool SaveLoadAccount(clsLoadAccount loadaccount)
        {
            bool ret = false;
            if (con.State == ConnectionState.Closed) con.Open();

            MySqlCommand cmd = null;
            cmd = new MySqlCommand("Select load_id from _loadaccount WHERE load_id = '" + loadaccount.LoadId.ToString() + "' AND Deleted=0", con); // creating query command

            object obj = cmd.ExecuteScalar();
            if (obj != null && obj != DBNull.Value) // if can read row from database
            {
                cmd = new MySqlCommand(string.Format("Update _loadaccount set Description = '{1}',current_balance = {2},available_balance = {3},loadtype = {4},accountnum = '{5}',mobilenum = '{6}',imgfile = @ImgFile WHERE load_id = {0};",
                    loadaccount.LoadId, loadaccount.Description, loadaccount.CurrentBalance, loadaccount.AvailableBalance, (int)loadaccount.LoadType, loadaccount.AccountNum, loadaccount.MobileNum), con);
            }
            else
            {
                cmd = new MySqlCommand(string.Format("Insert into _loadaccount (Description,current_balance,available_balance,loadtype,accountnum,mobilenum,imgfile,deleted) VALUES ('{0}',{1},{2},{3},'{4}','{5}',@ImgFile, 0) ",
                    loadaccount.Description, loadaccount.CurrentBalance, loadaccount.AvailableBalance, (int)loadaccount.LoadType, loadaccount.AccountNum, loadaccount.MobileNum), con);
            }
            if (loadaccount.ImgFile != null)
            {
                cmd.Parameters.Add("@ImgFile", MySqlDbType.LongBlob, loadaccount.ImgFile.Length);
                cmd.Parameters["@ImgFile"].Value = loadaccount.ImgFile;
            }
            else
            {
                cmd.Parameters.Add("@ImgFile", MySqlDbType.LongBlob, 0);
                cmd.Parameters["@ImgFile"].Value = null;
            }

            ret = cmd.ExecuteNonQuery() > 0;
            return ret;
        }


        public bool DeleteLoadAccount(clsLoadAccount loadaccount)
        {
            bool ret = false;
            if (con.State == ConnectionState.Closed) con.Open();

            MySqlCommand cmd = null;
            cmd = new MySqlCommand(string.Format("Update _loadaccount set Deleted = 1 WHERE load_id = {0};", loadaccount.LoadId), con);
            ret = cmd.ExecuteNonQuery() > 0;
            return ret;
        }

        public bool SaveLoadWallet(clsLoadWalletTransaction eLoad, ref int id)
        {
            bool ret = false;
            if (con.State == ConnectionState.Closed) con.Open();

            MySqlCommand cmd = null;
            cmd = new MySqlCommand("Select loadwallettrans_id from _loadwallettransactions WHERE loadwallettrans_id = '" + eLoad.LoadwalletTransId.ToString() + "' AND Deleted=0", con); // creating query command

            object obj = cmd.ExecuteScalar();
            if (obj != null && obj != DBNull.Value) // if can read row from database
            {
                cmd = new MySqlCommand(string.Format("Update _loadwallettransactions set load_id = {0},trans_amount = {1},load_amount = {2},discount = {3},timestamp = '{4:yyyy-MM-dd HH:mm:ss}',userid = {5},mobilenum = '{6}',TenderedAmount={7},id_subdaccount={9} WHERE loadwallettrans_id = {8};",
                    eLoad.Load_Id,eLoad.AmtDue,eLoad.LoadAmount,eLoad.DiscountPercentage,eLoad.Timestamp,eLoad.UserId,eLoad.MobileNum,eLoad.TenderedAmount,eLoad.LoadwalletTransId,eLoad.SubDId), con);
                ret = cmd.ExecuteNonQuery() > 0;
            }
            else
            {
                cmd = new MySqlCommand(string.Format("Insert into _loadwallettransactions (load_id,trans_amount,load_amount,discount,timestamp,userid,mobilenum,TenderedAmount,id_subdaccount) VALUES ({0},{1},{2},{3},'{4:yyyy-MM-dd HH:mm:ss}',{5},'{6}',{7},{8}) ",
                    eLoad.Load_Id, eLoad.AmtDue, eLoad.LoadAmount, eLoad.DiscountPercentage, eLoad.Timestamp, eLoad.UserId, eLoad.MobileNum, eLoad.TenderedAmount,eLoad.SubDId), con);
                ret = cmd.ExecuteNonQuery() > 0;
                id = dbConnect.GetLastLoadWalletTransId();
            }
            return ret;
        }

        #region SERVICE FEE
        public List<clsServiceFee> GetServiceFees(int id = 0)
        {
            List<clsServiceFee> lstRet = new List<clsServiceFee>();

            if (con.State == ConnectionState.Closed) con.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM _EcashServiceFee Where Deleted = 0 order by AmountTo", con); // creating query command
            if (id > 0) cmd = new MySqlCommand("SELECT * FROM _EcashServiceFee Where loadAccountId =" + id.ToString() + " AND Deleted = 0 order by AmountTo", con);
            MySqlDataReader reader = cmd.ExecuteReader(); // executes query
            if (reader.HasRows) // if can read row from database
            {
                while (reader.Read())
                {
                    try
                    {
                        clsServiceFee fee = new clsServiceFee()
                        {
                            ServiceFeeID = int.Parse(reader["servicefeeid"].ToString()),
                            AmountFrom = double.Parse(reader["amountfrom"].ToString()),
                            AmountTo = double.Parse(reader["amountto"].ToString()),
                            EcashFee = double.Parse(reader["ecashServicefee"].ToString()),
                            P2PFee = double.Parse(reader["p2pServicefee"].ToString()),
                            Load_id = int.Parse(reader["loadAccountId"].ToString()),
                            Rebate = double.Parse(reader["rebate"].ToString()),
                            Remarks = reader["remarks"].ToString()
                        };
                        lstRet.Add(fee);
                    }
                    catch { }
                }
            }
            if (!reader.IsClosed) reader.Close();
            return lstRet;
        }
        public bool SaveServiceFee(clsServiceFee svcfee)
        {
            bool ret = false;
            if (con.State == ConnectionState.Closed) con.Open();

            MySqlCommand cmd = null;
            cmd = new MySqlCommand("Select servicefeeid from _EcashServiceFee WHERE amountfrom = " + svcfee.AmountFrom.ToString() + " and amountto = " + svcfee.AmountTo.ToString() + " AND loadAccountId = " + svcfee.Load_id.ToString() + " AND Deleted=0", con); // creating query command

            object obj = cmd.ExecuteScalar();
            if (obj != null && obj != DBNull.Value) // if can read row from database
            {
                cmd = new MySqlCommand(string.Format("Update _EcashServiceFee set amountfrom = {1},amountto = {2},ecashServicefee = {3},P2PServicefee = {4},loadAccountId = {5}, rebate ={6},remarks = '{7}' WHERE servicefeeid = {0};",
                    svcfee.ServiceFeeID, svcfee.AmountFrom, svcfee.AmountTo, svcfee.EcashFee, svcfee.P2PFee, svcfee.Load_id, svcfee.Rebate, svcfee.Remarks), con);
            }
            else
            {
                cmd = new MySqlCommand(string.Format("Insert into _EcashServiceFee (amountfrom,amountto,ecashServicefee,P2PServicefee,loadAccountId,rebate,remarks) VALUES ({0},{1},{2},{3},{4},{5},'{6}') ",
                    svcfee.AmountFrom, svcfee.AmountTo, svcfee.EcashFee, svcfee.P2PFee, svcfee.Load_id, svcfee.Rebate, svcfee.Remarks), con);
            }
            
            ret = cmd.ExecuteNonQuery() > 0;
            return ret;
        }
        public bool DeleteServiceFee(int id)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            MySqlCommand cmd = new MySqlCommand("Update _EcashServiceFee set Deleted=1 WHERE servicefeeid = " + id.ToString(), con); // creating query command
            int ret = cmd.ExecuteNonQuery(); // executes query
            return ret > 0;
        }
        #endregion
    #region Load Account
        public static double GetRemainingLoadBalance(int Loadid)
        {
            string sql = String.Format("Select remainingbalance Total from _reloadHistory where  load_id = {0} and deleted = 0 ORDER BY reloadid DESC",Loadid);
            MySqlConnection con = new MySqlConnection(Properties.Settings.Default.dbConnectionString1 + string.Format("Password={0};", DBPassword));  // connection string change database name and password here.
            con.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, con); // creating query command
                MySqlDataReader reader = cmd.ExecuteReader(); // executes query
                if (reader.HasRows == true && reader.Read()) // if can read row from database
                {
                    double ret = double.Parse(reader["Total"].ToString());
                    if (!reader.IsClosed) reader.Close();
                    con.Close();
                    return ret;
                }
                if (!reader.IsClosed) reader.Close();
            }
            catch { }
            con.Close();
            return 0;
        } 
    #endregion
        public static Int32 GetLastGCashTransId()
        {
            string sql = String.Format("Select ecashtransid from _gcashtransaction order by ecashtransid Desc");
            MySqlConnection con = new MySqlConnection(Properties.Settings.Default.dbConnectionString1 + string.Format("Password={0};", DBPassword));  // connection string change database name and password here.
            con.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, con); // creating query command
                MySqlDataReader reader = cmd.ExecuteReader(); // executes query
                if (reader.HasRows == true && reader.Read()) // if can read row from database
                {
                    Int32 ret = Int32.Parse(reader["ecashtransid"].ToString());
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
        public static Int32 GetLastReloadHistoryId()
        {
            string sql = String.Format("Select reloadid from _reloadhistory order by reloadid Desc");
            MySqlConnection con = new MySqlConnection(Properties.Settings.Default.dbConnectionString1 + string.Format("Password={0};", DBPassword));  // connection string change database name and password here.
            con.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, con); // creating query command
                MySqlDataReader reader = cmd.ExecuteReader(); // executes query
                if (reader.HasRows == true && reader.Read()) // if can read row from database
                {
                    Int32 ret = Int32.Parse(reader["reloadid"].ToString());
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
        #region REPORTS LOADING STATION
        public List<clsReloadHistory> GetReLoadHistoryReport(DateTime dateStart,DateTime dateEnd,int userid ,int loadid)
        {
            string sql = "Select * FROM _reloadhistory WHERE load_id = " + loadid.ToString() + " AND Deleted=0";

            if (userid > 0 && loadid > 0)
                sql = string.Format("Select * from _reloadhistory WHERE timestamp between '{0} 06:00:00' and '{1} 06:00:00' and userid = {2} and load_id = {3} and Deleted=0", dateStart.ToString("yyyy-MM-dd"), dateEnd.ToString("yyyy-MM-dd"), userid, loadid);
            else if (userid > 0 && loadid == 0)
                sql = string.Format("Select * from _reloadhistory WHERE timestamp between '{0} 06:00:00' and '{1} 06:00:00' and userid = {2} and Deleted=0", dateStart.ToString("yyyy-MM-dd"), dateEnd.ToString("yyyy-MM-dd"), userid);
            else if (userid == 0 && loadid > 0)
                sql = string.Format("Select * from _reloadhistory WHERE timestamp between '{0} 06:00:00' and '{1} 06:00:00' and load_id = {2} and Deleted=0", dateStart.ToString("yyyy-MM-dd"), dateEnd.ToString("yyyy-MM-dd"), loadid);
            else if (userid == 0 && loadid == 0)
                sql = string.Format("Select * FROM _reloadhistory WHERE timestamp between '{0} 06:00:00' and '{1} 06:00:00' AND Deleted=0", dateStart.ToString("yyyy-MM-dd"), dateEnd.ToString("yyyy-MM-dd"));


            if (con.State == ConnectionState.Closed) con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con); // creating query command
            MySqlDataReader reader = cmd.ExecuteReader(); // executes query
            List<clsReloadHistory> lstReloadHistory = new List<clsReloadHistory>();
            if (reader.HasRows) // if can read row from database
            {
                List<clsUsers> lstuser = clsUsers.GetUsers();
                while (reader.Read())
                {
                    clsReloadHistory reload = BuildReloadHistory(reader);

                    if (reload != null)
                    {
                        clsUsers cashier = lstuser.Find(x => x.UserId == reload.UserId);
                        if(cashier != null) reload.UserName = cashier.UserName;
                        lstReloadHistory.Add(reload);
                    }
                }
            }
            if (!reader.IsClosed) reader.Close();
            return lstReloadHistory;
        }

        public List<clsGCashTransaction> GetGcashTransactionReport(DateTime dateStart, DateTime dateEnd, int userid, string customer)
        {
            string sql = "";

            if (userid > 0)
                sql = string.Format("Select * from view_gcashtransactions WHERE transdate between '{0} 06:00:00' and '{1} 06:00:00' and userid = {2} and Deleted=0", dateStart.ToString("yyyy-MM-dd"), dateEnd.ToString("yyyy-MM-dd"), userid);
            else if (customer != "")
                sql = string.Format("Select * from view_gcashtransactions WHERE transdate between '{0} 06:00:00' and '{1} 06:00:00' and sendername LIKE '%{2}%' and Deleted=0", dateStart.ToString("yyyy-MM-dd"), dateEnd.ToString("yyyy-MM-dd"), customer);
            else if (customer != "" && userid > 0)
                sql = string.Format("Select * from view_gcashtransactions WHERE transdate between '{0} 06:00:00' and '{1} 06:00:00' and sendername LIKE '%{2}%' and userid = {3} and Deleted=0", dateStart.ToString("yyyy-MM-dd"), dateEnd.ToString("yyyy-MM-dd"),customer, userid);
            
            else
                sql = string.Format("Select * from view_gcashtransactions WHERE transdate between '{0} 06:00:00' and '{1} 06:00:00' and Deleted=0", dateStart.ToString("yyyy-MM-dd"), dateEnd.ToString("yyyy-MM-dd"));

            if (con.State == ConnectionState.Closed) con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con); // creating query command
            MySqlDataReader reader = cmd.ExecuteReader(); // executes query
            List<clsGCashTransaction> lstReloadHistory = new List<clsGCashTransaction>();
            if (reader.HasRows) // if can read row from database
            {
                List<clsUsers> lstuser = clsUsers.GetUsers();
                while (reader.Read())
                {
                    clsGCashTransaction reload = BuildGCashTransaction(reader);

                    if (reload != null)
                    {
                        reload.UserName = reader["Loginname"].ToString();
                        reload.AccountName = reader["Description"].ToString();
                        lstReloadHistory.Add(reload);
                    }
                }
            }
            if (!reader.IsClosed) reader.Close();
            return lstReloadHistory;
        }
        public List<clsSmartCashTransaction> GetScashTransactionReport(DateTime dateStart, DateTime dateEnd, int userid, string customer)
        {
            string sql = "";

            if (userid > 0)
                sql = string.Format("Select * from view_scashtransaction WHERE transdate between '{0} 06:00:00' and '{1} 06:00:00' and userid = {2} and Deleted=0", dateStart.ToString("yyyy-MM-dd"), dateEnd.ToString("yyyy-MM-dd"), userid);
            else if (customer != "")
                sql = string.Format("Select * from view_scashtransaction WHERE transdate between '{0} 06:00:00' and '{1} 06:00:00' and sendername LIKE '%{2}%' and Deleted=0", dateStart.ToString("yyyy-MM-dd"), dateEnd.ToString("yyyy-MM-dd"), customer);
            else if (customer != "" && userid > 0)
                sql = string.Format("Select * from view_scashtransaction WHERE transdate between '{0} 06:00:00' and '{1} 06:00:00' and sendername LIKE '%{2}%' and userid = {3} and Deleted=0", dateStart.ToString("yyyy-MM-dd"), dateEnd.ToString("yyyy-MM-dd"), customer, userid);

            else
                sql = string.Format("Select * from view_scashtransaction WHERE transdate between '{0} 06:00:00' and '{1} 06:00:00' and Deleted=0", dateStart.ToString("yyyy-MM-dd"), dateEnd.ToString("yyyy-MM-dd"));

            if (con.State == ConnectionState.Closed) con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con); // creating query command
            MySqlDataReader reader = cmd.ExecuteReader(); // executes query
            List<clsSmartCashTransaction> lstReloadHistory = new List<clsSmartCashTransaction>();
            if (reader.HasRows) // if can read row from database
            {
                while (reader.Read())
                {
                    clsSmartCashTransaction reload = BuildSCashTransaction(reader);

                    if (reload != null)
                    {
                        reload.UserName = reader["Loginname"].ToString();
                        reload.AccountName = reader["Description"].ToString();
                        lstReloadHistory.Add(reload);
                    }
                }
            }
            if (!reader.IsClosed) reader.Close();
            return lstReloadHistory;
        }

        public List<clsEloadTransaction> GetELoadTransactionReport(DateTime dateStart, DateTime dateEnd, int userid, int loadid)
        {
            string sql = "Select * FROM _eloadtransaction WHERE load_id = " + loadid.ToString() + " AND Deleted=0";

            if (userid > 0 && loadid > 0)
                sql = string.Format("Select * from _eloadtransaction WHERE timestamp between '{0} 06:00:00' and '{1} 06:00:00' and userid = {2} and load_id = {3} and Deleted=0", dateStart.ToString("yyyy-MM-dd"), dateEnd.ToString("yyyy-MM-dd"), userid, loadid);
            else if (userid > 0 && loadid == 0)
                sql = string.Format("Select * from _eloadtransaction WHERE timestamp between '{0} 06:00:00' and '{1} 06:00:00' and userid = {2} and Deleted=0", dateStart.ToString("yyyy-MM-dd"), dateEnd.ToString("yyyy-MM-dd"), userid);
            else if (userid == 0 && loadid > 0)
                sql = string.Format("Select * from _eloadtransaction WHERE timestamp between '{0} 06:00:00' and '{1} 06:00:00' and load_id = {2} and Deleted=0", dateStart.ToString("yyyy-MM-dd"), dateEnd.ToString("yyyy-MM-dd"), loadid);
            else if (userid == 0 && loadid == 0)
                sql = string.Format("Select * FROM _eloadtransaction WHERE timestamp between '{0} 06:00:00' and '{1} 06:00:00' AND Deleted=0", dateStart.ToString("yyyy-MM-dd"), dateEnd.ToString("yyyy-MM-dd"));


            if (con.State == ConnectionState.Closed) con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con); // creating query command
            MySqlDataReader reader = cmd.ExecuteReader(); // executes query
            List<clsEloadTransaction> lstReloadHistory = new List<clsEloadTransaction>();
            if (reader.HasRows) // if can read row from database
            {
                List<clsUsers> lstuser = clsUsers.GetUsers();
                while (reader.Read())
                {
                    clsEloadTransaction reload = BuildELoadTransaction(reader);

                    if (reload != null)
                    {
                        clsUsers cashier = lstuser.Find(x => x.UserId == reload.UserId);
                        if (cashier != null) reload.UserName = cashier.UserName;
                        lstReloadHistory.Add(reload);
                    }
                }
            }
            if (!reader.IsClosed) reader.Close();
            return lstReloadHistory;
        }
        public List<clsLoadWalletTransaction> GetLoadWalletTransactionsReport(DateTime dateStart, DateTime dateEnd, int userid, int loadid)
        {
            string sql = "Select * FROM _loadwallettransactions WHERE load_id = " + loadid.ToString() + " AND Deleted=0";

            if (userid > 0 && loadid > 0)
                sql = string.Format("Select * from _loadwallettransactions WHERE timestamp between '{0} 06:00:00' and '{1} 06:00:00' and userid = {2} and load_id = {3} and Deleted=0", dateStart.ToString("yyyy-MM-dd"), dateEnd.ToString("yyyy-MM-dd"), userid, loadid);
            else if (userid > 0 && loadid == 0)
                sql = string.Format("Select * from _loadwallettransactions WHERE timestamp between '{0} 06:00:00' and '{1} 06:00:00' and userid = {2} and Deleted=0", dateStart.ToString("yyyy-MM-dd"), dateEnd.ToString("yyyy-MM-dd"), userid);
            else if (userid == 0 && loadid > 0)
                sql = string.Format("Select * from _loadwallettransactions WHERE timestamp between '{0} 06:00:00' and '{1} 06:00:00' and load_id = {2} and Deleted=0", dateStart.ToString("yyyy-MM-dd"), dateEnd.ToString("yyyy-MM-dd"), loadid);
            else if (userid == 0 && loadid == 0)
                sql = string.Format("Select * FROM _loadwallettransactions WHERE timestamp between '{0} 06:00:00' and '{1} 06:00:00' AND Deleted=0", dateStart.ToString("yyyy-MM-dd"), dateEnd.ToString("yyyy-MM-dd"));


            if (con.State == ConnectionState.Closed) con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con); // creating query command
            MySqlDataReader reader = cmd.ExecuteReader(); // executes query
            List<clsLoadWalletTransaction> lstLoadWaletTrans = new List<clsLoadWalletTransaction>();
            if (reader.HasRows) // if can read row from database
            {
                List<clsUsers> lstuser = clsUsers.GetUsers();
                while (reader.Read())
                {
                    clsLoadWalletTransaction reload = BuildLoadWalletTransaction(reader);

                    if (reload != null)
                    {
                        clsUsers cashier = lstuser.Find(x => x.UserId == reload.UserId);
                        if (cashier != null) reload.Username = cashier.UserName;
                        lstLoadWaletTrans.Add(reload);
                    }
                }
            }
            if (!reader.IsClosed) reader.Close();
            return lstLoadWaletTrans;
        }
        #endregion
       

        #region SMART PADALA
        public static Int32 GetLastSCashTransId()
        {
            string sql = String.Format("Select ecashtransid from _scashtransaction order by ecashtransid Desc");
            MySqlConnection con = new MySqlConnection(Properties.Settings.Default.dbConnectionString1 + string.Format("Password={0};", DBPassword));  // connection string change database name and password here.
            con.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, con); // creating query command
                MySqlDataReader reader = cmd.ExecuteReader(); // executes query
                if (reader.HasRows == true && reader.Read()) // if can read row from database
                {
                    Int32 ret = Int32.Parse(reader["ecashtransid"].ToString());
                    if (!reader.IsClosed) reader.Close();
                    con.Close();
                    return ret;
                }
                if (!reader.IsClosed) reader.Close();
            }
            catch { }
            con.Close();
            return 0;
        }
        public bool SaveSCash(clsSmartCashTransaction sc, ref int id)
        {
            bool ret = false;
            if (con.State == ConnectionState.Closed) con.Open();
            string sql = "";
            MySqlCommand cmd = null;
            cmd = new MySqlCommand("Select refnum from _scashtransaction WHERE refnum = '" + sc.RefNum + "' AND Deleted=0", con); // creating query command
            
            object obj = cmd.ExecuteScalar();
                if (obj != null && obj != DBNull.Value) // if can read row from database
                {
                    //sql = string.Format("Update _scashtransaction set userid={0},accountid ={1},loadid ={2},TransactionAmount ={3},SvcFeeAmount ={4},SenderName ='{5}',SenderContact ='{6}',RecipientName ='{7}',RecipientContact ='{8}',RecepientAccNum ='{9}',RefNum ='{10}',Remarks ='{11}',transtype ={12},transdate='{13:yyyy-MM-dd HH:mm:ss}',tenderedAmount={14},deleted=0,paymentMode = {15}, TotalAmtTransfered = {16}, AccountNum = '{17}' WHERE refnum = '{10}';",
                    //   sc.UserId, sc.AccountId, sc.Load_Id, sc.TransAmount, sc.SvcFeeAmount, sc.SenderName.Replace("'", "''"), sc.SenderContact.Replace("'", "''"), sc.RecipientName.Replace("'", "''"), sc.RecipientContact, sc.RecepientAccNum, sc.RefNum.Replace("'", "''"), sc.Remarks.Replace("'", "''"), (int)sc.TransType, sc.TransDate, sc.TenderedAmount, (int)sc.PaymentMode,sc.TotalAmtTransfered,sc.SenderAccnum);

                    sql = string.Format("Update _scashtransaction set deleted = 1 WHERE refnum = '{0}' ", sc.RefNum);
                    cmd = new MySqlCommand(sql, con);
                    cmd.ExecuteNonQuery();

                }
               
                    sql = string.Format("Insert into _scashtransaction (userid,accountid,loadid,TransactionAmount,SvcFeeAmount,SenderName,SenderContact,RecipientName,RecipientContact,RecepientAccNum,RefNum,Remarks,transtype,transdate,tenderedAmount,deleted,paymentMode,TotalAmtTransfered,AccountNum) VALUES ({0},{1},{2},{3},{4},'{5}','{6}','{7}','{8}','{9}','{10}','{11}',{12},'{13:yyyy-MM-dd HH:mm:ss}',{14},0,{15},{16},'{17}') ",
                          sc.UserId, sc.AccountId, sc.Load_Id, sc.TransAmount, sc.SvcFeeAmount, sc.SenderName, sc.SenderContact, sc.RecipientName, sc.RecipientContact, sc.RecepientAccNum, sc.RefNum, sc.Remarks, (int)sc.TransType, sc.TransDate, sc.TenderedAmount, (int)sc.PaymentMode, sc.TotalAmtTransfered, sc.SenderAccnum);
                    cmd = new MySqlCommand(sql, con);

                    ret = cmd.ExecuteNonQuery() > 0;
                    id = dbConnect.GetLastSCashTransId();
                           
            return ret;
        }
        
        #endregion
        #region E-Load
        public static Int32 GetLastELoadTransId()
        {
            string sql = String.Format("Select eloadtrans_id from _eloadtransaction order by eloadtrans_id Desc");
            MySqlConnection con = new MySqlConnection(Properties.Settings.Default.dbConnectionString1 + string.Format("Password={0};", DBPassword));  // connection string change database name and password here.
            con.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, con); // creating query command
                MySqlDataReader reader = cmd.ExecuteReader(); // executes query
                if (reader.HasRows == true && reader.Read()) // if can read row from database
                {
                    Int32 ret = Int32.Parse(reader["eloadtrans_id"].ToString());
                    if (!reader.IsClosed) reader.Close();
                    con.Close();
                    return ret;
                }
                if (!reader.IsClosed) reader.Close();
            }
            catch { }
            con.Close();
            return 0;
        }
        public static Int32 GetLastLoadWalletTransId()
        {
            string sql = String.Format("Select loadwallettrans_id from _loadwallettransactions order by loadwallettrans_id Desc");
            MySqlConnection con = new MySqlConnection(Properties.Settings.Default.dbConnectionString1 + string.Format("Password={0};", DBPassword));  // connection string change database name and password here.
            con.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, con); // creating query command
                MySqlDataReader reader = cmd.ExecuteReader(); // executes query
                if (reader.HasRows == true && reader.Read()) // if can read row from database
                {
                    Int32 ret = Int32.Parse(reader["loadwallettrans_id"].ToString());
                    if (!reader.IsClosed) reader.Close();
                    con.Close();
                    return ret;
                }
                if (!reader.IsClosed) reader.Close();
            }
            catch { }
            con.Close();
            return 0;
        }
        #endregion


        #region LOADING STATION SALES
        public double GetLoadingStationTotalCashIn(DateTime startdate, DateTime enddate, int cashier)
        {
            double totsales = 0;
            string sql = "";
            if (cashier == 0)
                sql = String.Format("Select sum(transaction_amount) from _reloadhistory WHERE timestamp between '{0:yyyy/MM/dd 06:00:00}' and '{1:yyyy/MM/dd 06:00:00}' and transaction_amount > 0 and deleted=0", startdate, enddate);
            else
                sql = String.Format("Select sum(transaction_amount) from _reloadhistory WHERE timestamp between '{0:yyyy/MM/dd 06:00:00}' and '{1:yyyy/MM/dd 06:00:00}' and transaction_amount > 0 and userid = {2} and deleted=0", startdate, enddate, cashier);
            MySqlCommand cmd = new MySqlCommand(sql, con); // creating query command
            object obj = cmd.ExecuteScalar(); // executes query
            if (obj != null && obj != DBNull.Value)
            {
                totsales = Convert.ToDouble(obj);
            }
            return totsales;
        }
        public double GetLoadingStationTotalCashOut(DateTime startdate, DateTime enddate, int cashier)
        {
            double totsales = 0;
            string sql = "";
            if (cashier == 0)
                sql = String.Format("Select sum(transaction_amount) from _reloadhistory WHERE timestamp between '{0:yyyy/MM/dd 06:00:00}' and '{1:yyyy/MM/dd 06:00:00}' and transaction_amount < 0 and deleted=0", startdate, enddate);
            else
                sql = String.Format("Select sum(transaction_amount) from _reloadhistory WHERE timestamp between '{0:yyyy/MM/dd 06:00:00}' and '{1:yyyy/MM/dd 06:00:00}' and transaction_amount < 0 and userid = {2} and deleted=0", startdate, enddate, cashier);
            MySqlCommand cmd = new MySqlCommand(sql, con); // creating query command
            object obj = cmd.ExecuteScalar(); // executes query
            if (obj != null && obj != DBNull.Value)
            {
                totsales = Convert.ToDouble(obj);
            }
            return totsales;
        }
        #endregion


        #region CHECK OUT
        public List<clsCheckOutItem> GetCheckOutItems(int checkoutId)
        {
            List<clsCheckOutItem> lstRet = new List<clsCheckOutItem>();
            try
            {
                MySqlCommand cmd = new MySqlCommand(string.Format("Select * from checkoutitem WHERE checkout_id = {0} And Deleted = 0", checkoutId), con); // creating query command

                MySqlDataReader reader = cmd.ExecuteReader(); // executes query
                if (reader.HasRows)
                {
                    while (reader.Read()) // if can read row from database
                    {
                        try
                        {
                            clsCheckOutItem expenses = new clsCheckOutItem();
                            expenses.ID = int.Parse(reader["id"].ToString());
                            expenses.CheckOutId = int.Parse(reader["checkout_id"].ToString());
                            expenses.ExpectedAmount = double.Parse(reader["ExpectedAmount"].ToString());
                            expenses.ActualAmount = double.Parse(reader["ActualAmount"].ToString());
                            expenses.Description = reader["description"].ToString();
                            expenses.Remarks = reader["remarks"].ToString();
                            lstRet.Add(expenses);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                if (!reader.IsClosed) reader.Close();
            }
            catch
            {

            }
            return lstRet;
        }

        public bool SaveCheckOutItem(clsCheckOutItem sc)
        {
            bool ret = false;
            if (con.State == ConnectionState.Closed) con.Open();
            string sql = "";
            try
            {
                MySqlCommand cmd = null;
                if (sc.ID > 0)
                {
                    sql = string.Format("Update checkoutitem set description = '{0}', ExpectedAmount = {1}, ActualAmount = {2}, checkout_id = {3}, remarks = '{4}' where id = {5} ",
                        sc.Description, sc.ExpectedAmount, sc.ActualAmount, sc.CheckOutId, sc.Remarks, sc.ID);
                }
                else
                {
                    sql = string.Format("INSERT INTO checkoutitem (description, ExpectedAmount, ActualAmount, checkout_id, remarks) Values('{0}', {1}, {2}, {3}, '{4}') ",
                        sc.Description, sc.ExpectedAmount, sc.ActualAmount, sc.CheckOutId, sc.Remarks);
                }
                cmd = new MySqlCommand(sql, con);

                ret = cmd.ExecuteNonQuery() > 0;
            }
            catch { }
            return ret;
        }
        public bool DeleteCheckOutItem(int checkoutid)
        {
            bool ret = false;
            if (con.State == ConnectionState.Closed) con.Open();
            string sql = "";
            try
            {
                sql = string.Format("Update checkoutitem set deleted = 1 where checkout_id = {0} ", checkoutid);

                MySqlCommand  cmd = new MySqlCommand(sql, con);

                ret = cmd.ExecuteNonQuery() > 0;
            }
            catch { }
            return ret;
        }

        #endregion
    }

 }
