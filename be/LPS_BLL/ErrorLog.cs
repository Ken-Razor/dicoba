using LPS_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPS_BLL
{
    public class Error_Log
    {

       
        public string Insert_Log(string Modul, string code, string description, string User)
        {
            var oParameters = new
            {
                Modul = Modul,
                ErrorCode = code,
                Description = description,
                CreatedBy = User
            };
            try
            {
                string result = DbTransaction.DbToString("Usp_Insert_ErrorLog", oParameters, true);
                return result;
            }
            catch (Exception ex)
            {
                return "Terjadi kesalahan pada BLL Log: " + ex.Message;
            }
        }

    }
}
