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
    }
}
