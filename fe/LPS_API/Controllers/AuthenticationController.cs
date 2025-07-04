using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers
{
    public class AuthenticationController : ApiController
    {


        public string CheckActiveUser(string username,string password)
        {

            try
            {
                bool IsRegister = IsRegistered(username);
                if (IsRegister == true)
                {
                    bool IsActiveUser = IsAuthenticated(username, password);

                    return 
                }
                else
                {
                    return
                }
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }


        public bool IsRegistered(string username)
        {
            return true;   
        }
        // GET api/<controller>/5
        public bool IsAuthenticated(string username , string pwd)
        {
            string domainAndUsername = domain + @"\" + username;
            string _path = "LDAP://192.168.10.24";
            DirectoryEntry entry = new DirectoryEntry(_path, domainAndUsername, pwd);

            try
            {
                //Bind to the native AdsObject to force authentication.
                object obj = entry.NativeObject;

                DirectorySearcher search = new DirectorySearcher(entry);

                search.Filter = "(SAMAccountName=" + username + ")";
                search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();

                if (null == result)
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error authenticating user. " + ex.Message);
            }

            return true;
        }
    }
}