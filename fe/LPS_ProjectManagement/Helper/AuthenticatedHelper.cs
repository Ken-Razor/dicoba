using System;
using System.DirectoryServices;

namespace LPS_ProjectManagement.Helper
{
    public class AuthenticatedHelper
    {
        //srvr = ldap server, e.g. LDAP://domain.com 
        //usr = user name 
        //pwd = user password 
        public bool IsAuthenticated(string usr, string pwd)
        {
            string srvr = "LDAP://DC=lps,DC=corp";
            bool authenticated = false;

            try
            {
                DirectoryEntry entry = new DirectoryEntry(srvr, usr, pwd);
                object nativeObject = entry.NativeObject;
                authenticated = true;
            }
            catch (DirectoryServicesCOMException cex)
            {
                //not authenticated; reason why is in cex 
            }
            catch (Exception ex)
            {
                //not authenticated due to some other exception [this is optional] 
            }
            return authenticated;
        }
    }
}