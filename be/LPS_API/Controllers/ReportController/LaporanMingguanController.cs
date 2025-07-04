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
    public class LaporanMingguanController : ApiController
    {
        public DataTable Post([FromBody]AllDataRowModel obj)
        {
            Report r = new Report();

            DataSet ds = r.Get_Report_Weekly(obj.Year.ToString(), obj.Month, obj.Week, obj.IsTransformasi, obj.DepartmentCode, obj.NamaProgramManager, obj.NamaProjectOwner, obj.NamaProjectSponsor);
            DataTable dt1 = ds.Tables[0];

            return dt1;
        }
    }
}
