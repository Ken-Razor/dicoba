using LPS_API.Models;
using LPS_API.Models.DashboardModels;
using LPS_API.Models.MasterDataModels;
using LPS_API.Models.ReportModels;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.ErrorLog
{
    public class ErrorLogInsertController : ApiController
    {
        public string Post([FromBody] ErrLogModel dm)
        {
            try
            {
                Error_Log md = new Error_Log();
                string result = "F|Terdapat kesalahan pada API Controller";

                result = md.Insert_Log(dm.Modul,dm.Code,dm.Description,dm.CreateUser);

                return result;
            }
            catch (Exception ex)
            {
                return "Kesalahan pada API Controller : " + ex.Message;
            }
        }

     


    }
}
