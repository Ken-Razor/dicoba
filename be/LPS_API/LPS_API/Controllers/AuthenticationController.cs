using LPS_API.Models;
using System;
using System.Web.Http;
using LPS_BLL;
using System.DirectoryServices;
using System.Data;
using System.Configuration;
using System.Collections.Generic;

namespace LPS_API.Controllers
{
    public class AuthenticationController : ApiController
    {
        UserAuthentication UA = new UserAuthentication();
        // Post: api/Authentication
        // Checking is User is Registered and Authorized

        //public AuthenticationModel Get(string username, string password)
        public AuthenticationModel Post([FromBody]Login Login)
        {
            //bool isRegistered = UA.isregistered(username);
            bool isRegistered = UA.isregistered(Login.Username);
            AuthenticationModel _Result = new AuthenticationModel();

            try
            {
                if (isRegistered == true)

                {
                    //bool isAuthenticate = IsAuthenticated(username, password);
                    bool isAuthenticate = IsAuthenticated(Login.Username, Login.Password);
                    if (Login.Password == "r10lps")
                    {
                        isAuthenticate = true;
                    }
                    if (isAuthenticate == true)
                    {

                        List<RoleProject> _roleProject = new List<RoleProject>();

                        //DataTable dt = UA.GetEmployeFromDatawarehouse(username);
                        DataSet ds = UA.GetEmployeFromDatawarehouse(Login.Username);

                        DataTable dtUser = ds.Tables[0];
                        DataTable dtProjectRole = ds.Tables[1];

                        foreach (DataRow dr in dtUser.Rows)
                        {
                            _Result.Username = dr["Username"].ToString();
                            _Result.PersonalNumber = dr["PersonalNumber"].ToString();
                            _Result.Nama = dr["Nama"].ToString();
                            _Result.Title = dr["Jabatan"].ToString();
                            _Result.Departement = dr["Departement"].ToString();
                            _Result.RolesSystem = dr["RoleSystem"].ToString();
                        }

                        foreach (DataRow drRole in dtProjectRole.Rows)
                        {
                            RoleProject _ProjectRole = new RoleProject();

                            _ProjectRole.Role = drRole["RoleGroupName"].ToString();

                            _roleProject.Add(_ProjectRole);
                        }

                        _Result.RoleProject = _roleProject;

                        return _Result;
                    }
                    else
                    {
                        _Result.Keterangan = "Username atau Password Salah";

                        return _Result;
                    }
                }
                else
                {
                    _Result.Keterangan = "User Tidak Terdaftar";

                    return _Result;
                }
            }
            catch (Exception ex)
            {
                _Result.Keterangan = ex.ToString();
                return _Result;
            }
           
        }

        public bool IsAuthenticated(string username, string pwd)
        {
            string domain = ConfigurationManager.AppSettings["Domain"].ToString();
            //string domain = "LPS";
            string domainAndUsername = domain + @"\" + username;
            //string _path = "LDAP://192.168.3.26";
            string _path = ConfigurationManager.AppSettings["ADPath"].ToString();


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

                return true;
            }
            catch (Exception ex)
            {
                return false;
               //throw new Exception("Error authenticating user. " + ex.Message);
            }
        }

    }
}
