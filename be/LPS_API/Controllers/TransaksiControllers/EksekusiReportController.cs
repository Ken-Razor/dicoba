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
    public class EksekusiReportController : ApiController
    {

        public List<ExecutionReportModel> Post([FromBody]ExecutionReportModel erm)
        {
            try
            {
                List<ExecutionReportModel> result = new List<ExecutionReportModel>();
                TransaksiEksekusi te = new TransaksiEksekusi();

                DataTable dt = te.GetExecutionReportCurrent(erm.IDProjectHeader, erm.IsTransformasi);

                for (int x = 0; x < dt.Rows.Count; x++)
                {
                    ExecutionReportModel er = new ExecutionReportModel();
                    er.NoUrut = x + 1;
                    if (dt.Rows[x]["IDProjectHeader"].ToString() != "") er.IDProjectHeader = Convert.ToInt32(dt.Rows[x]["IDProjectHeader"]);
                    if (dt.Rows[x]["Reals"].ToString() != "") er.Real = Convert.ToInt32(dt.Rows[x]["Reals"]);
                    if (dt.Rows[x]["Plans"].ToString() != "") er.Plan = Convert.ToInt32(dt.Rows[x]["Plans"]);
                    er.Approval = dt.Rows[x]["Approval"].ToString();
                    er.Status = dt.Rows[x]["Status"].ToString();
                    er.UpdateDate = dt.Rows[x]["UpdateDate"].ToString();
                    er.Tanggal = dt.Rows[x]["Periode"].ToString();
                    er.Keys = dt.Rows[x]["Keys"].ToString();

                    result.Add(er);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ExecutionReportModel> Put([FromBody]ExecutionReportModel erm)
        {
            try
            {
                List<ExecutionReportModel> result = new List<ExecutionReportModel>();
                TransaksiEksekusi te = new TransaksiEksekusi();

                DataTable dt = te.GetExecutionReportTrendWithOutCurrent(erm.IDProjectHeader, erm.IsTransformasi);

                for (int x = 0; x < dt.Rows.Count; x++)
                {
                    ExecutionReportModel er = new ExecutionReportModel();
                    er.NoUrut = x + 1;
                    if (dt.Rows[x]["IDProjectHeader"].ToString() != "") er.IDProjectHeader = Convert.ToInt32(dt.Rows[x]["IDProjectHeader"]);
                    if (dt.Rows[x]["Reals"].ToString() != "") er.Real = Convert.ToInt32(dt.Rows[x]["Reals"]);
                    if (dt.Rows[x]["Plans"].ToString() != "") er.Plan = Convert.ToInt32(dt.Rows[x]["Plans"]);
                    er.Approval = dt.Rows[x]["Approval"].ToString();
                    er.Status = dt.Rows[x]["Status"].ToString();
                    er.UpdateDate = dt.Rows[x]["UpdateDate"].ToString();
                    er.Tanggal = dt.Rows[x]["Periode"].ToString();
                    er.Keys = dt.Rows[x]["Keys"].ToString();

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
