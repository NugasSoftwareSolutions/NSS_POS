using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlreySolutions.Class
{
    public static class clsUtil{
        public static bool GetApproval(clsUsers m_user, UserAccess accesslevel = UserAccess.Cashier )
        {
            if (m_user.LoginType <= (int)accesslevel)
            {
                return true;
            }
            else
            {
                frmApproval login = new frmApproval((int)accesslevel);
                if (login.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    clsUsers iuser = login.m_User;
                    if (iuser.LoginType <= (int)accesslevel) return true;
                }
            }

            return false;
        }

    }

   public enum UserAccess
   {
       Admin = 1,
       Manager = 2,
       Supervisor = 3,
       Cashier = 4
   }



}
