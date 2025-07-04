using LPS_API.Models.ReportModels;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.ReportController
{
    public class AllDataRowController : ApiController
    {
        public DataTable Post([FromBody]AllDataRowModel obj)
        {
            Report r = new Report();

            DataSet ds = r.Get_Excel_AllDataRow(obj.Year.ToString(), obj.Month, obj.Week, obj.IsTransformasi,obj.StatusProjectHeader);
            DataTable dt1 = ds.Tables[0];
            
            return dt1;
        }
    }
}

