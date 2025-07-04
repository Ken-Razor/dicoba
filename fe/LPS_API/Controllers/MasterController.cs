using LPS_API.DataAccessHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers
{
    public class MasterController : ApiController
    {

        public DataTable GetData()
        {

            var oParameters = new
            {
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("dbo.Usp_Get_MasterProgram", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }


        }


    }
}
