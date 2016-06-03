using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Win32;
using System.Net.NetworkInformation;

namespace License
{
    public class POSLicense
    {
        public const string AppName = "POS System";
        public static bool ValidateLicense(string license)
        {
            string regcode = GetRegistrationCode();
            List<string> lstcode = regcode.Split("-".ToCharArray()).ToList();
            string strcode = "";
            foreach (string code in lstcode)
            {
                strcode += getSHA1(code);

            }
            string scrambled = ScrambleCode(ScrambleCode(strcode));
            if (scrambled == license) return true;
            return false;
        }

        public static string EncryptPassword(string password)
        {
            if (password != "") return ScrambleCode(getSHA1(password));
            return "";
        }
        private static string ScrambleCode(string code)
        {
            string ret = "";
            int ctr = 0;
            foreach (char c in code)
            {
                if (ctr % 3 == 0)
                {
                    ret = c.ToString() + ret ;
                }
                else
                {
                    ret += c.ToString();
                }
                ctr++;
            }
            return ret;
        }

        private static string getSHA1(string code) 
        { 
            return BitConverter.ToString(SHA1Managed.Create().ComputeHash(Encoding.Default.GetBytes(code))).Replace("-", ""); 
        }
        public static string GetRegistrationCode()
        {
            string regVal  = GetRegistryValue("RegistrationCode-" + AppName);
            string regcode = GetRegCode(regVal);
            if (regVal == "")
            {
                SetRegistryRegCode(regcode);
            }
            return regcode;
        }
        private static string GetRegCode(string regcode="")
        {
            string tmpReg = "";
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet )
                {
                    string strAdd = "";
                    PhysicalAddress address = nic.GetPhysicalAddress();
                    byte[] bytes = address.GetAddressBytes();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        // Display the physical address in hexadecimal.
                        strAdd += string.Format("{0}", bytes[i].ToString("X2"));
                    }
                    strAdd = nic.Id.Replace("{", "").Replace("}", "") + "-" + strAdd;
                    tmpReg = strAdd;
                    if (regcode == "")
                        return strAdd;
                    else if (regcode == strAdd)
                        return strAdd;

                }
            }
            return tmpReg;
        }

        public static string GetRegistryValue(string key)
        {
            RegistryKey regkey = Registry.CurrentUser.CreateSubKey(AppName);
            string ret = regkey.GetValue(key + (key.Contains("-")?"": "-" + AppName), "").ToString();
            regkey.Close();
            return ret;
        }
        public static void SetCompany(string company)
        {
            RegistryKey regkey = Registry.CurrentUser.CreateSubKey(AppName);
            regkey.SetValue("Company-" + AppName, company);
            regkey.Close();
        }

        public static void SetRegistryLicense(string license)
        {
            RegistryKey regkey = Registry.CurrentUser.CreateSubKey(AppName);
            regkey.SetValue("LicenseKey-" + AppName, license);
            regkey.Close();

        }

        public static void SetRegistryRegCode(string regcode)
        {
            RegistryKey regkey = Registry.CurrentUser.CreateSubKey(AppName);
            regkey.SetValue("RegistrationCode-"+AppName, regcode);
            regkey.Close();

        }

    }
}
