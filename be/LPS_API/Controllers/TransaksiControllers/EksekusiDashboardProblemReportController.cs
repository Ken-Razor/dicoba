using LPS_API.Models.EksekusiModels;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.TransaksiControllers
{
    public class EksekusiDashboardProblemReportController : ApiController
    {

        public List<ExecutionProblemReportModel> Post([FromBody] ExecutionProblemReportModel erm)
        {
            try
            {
                List<ExecutionProblemReportModel> result = new List<ExecutionProblemReportModel>();
                TransaksiEksekusi te = new TransaksiEksekusi();

                DataTable dt = te.GetExecutionDashboardReportProblemNMitigasi(erm.IDProjectHeader, 0);

                for (int x = 0; x < dt.Rows.Count; x++)
                {
                    ExecutionProblemReportModel er = new ExecutionProblemReportModel();
                    er.NoUrut = x + 1;
                    if (dt.Rows[x]["IDProjectHeader"].ToString() != "") er.IDProjectHeader = Convert.ToInt32(dt.Rows[x]["IDProjectHeader"]);
                    er.Jenis = dt.Rows[x]["Jenis"].ToString();
                    er.Deskripsi = dt.Rows[x]["Deskripsi"].ToString();
                    er.Remark = dt.Rows[x]["Remark"].ToString();
                    er.Problem = dt.Rows[x]["Problem"].ToString();
                    er.Mitigasi = dt.Rows[x]["Mitigasi"].ToString();
                    er.CreatedDate = DateTime.Parse(dt.Rows[x]["CreatedDate"].ToString());
                    result.Add(er);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

    }
}
