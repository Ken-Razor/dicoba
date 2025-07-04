using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPS_DAL;

namespace LPS_BLL
{
    public class UserAuthentication
    {
        public bool isregistered(string Username)
        {

            var oParameters = new
            {
                username = Username
            };
            try
            {
                string data = DbTransaction.DbToString("Usp_Get_UserAuthorized", oParameters, true);

                if (data == "true")
                {
                    return true;
                } else
                {
                    return false;
                }
             
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }


        }


        public DataSet GetEmployeFromDatawarehouse(string Username)
        {
            var oParameters = new
            {
                username = Username
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_Get_EmployeeDetail", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
