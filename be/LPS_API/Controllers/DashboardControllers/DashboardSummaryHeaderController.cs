using LPS_API.Models.DashboardModels.DashboardSummary;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.DashboardControllers
{
    public class DashboardSummaryHeaderController : ApiController
    {
        public DashboardSummaryHeaderModel Post(DashboardSummaryHeaderModel param)
        {
            DashboardSummaryHeaderModel DashboardSummaryHeaderModel = new DashboardSummaryHeaderModel();
            List<TableSummaryProject> ListTableSummaryProject = new List<TableSummaryProject>();
            DashboardData dd = new DashboardData();
            DataSet ds = new DataSet();

            ds = dd.GetDashboardSummaryHeader(param.Filter, param.Year, param.Month, param.Week, param.id);

            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];

            foreach(DataRow dr in dt.Rows)
            {
                if(dr["Tipe"].ToString() == "Non Transformasi") DashboardSummaryHeaderModel.NonTransformasi = Convert.ToInt32(dr["Total"]);
                if (dr["Tipe"].ToString() == "Transformasi") DashboardSummaryHeaderModel.Transformasi = Convert.ToInt32(dr["Total"]);
            }

            foreach (DataRow dr in dt1.Rows)
            {
                TableSummaryProject TableSummaryProject = new TableSummaryProject();

                TableSummaryProject.IDProjectHeader = Convert.ToInt32(dr["IDProjectHeader"]);
                TableSummaryProject.ProjectName = dr["ProjectName"].ToString();
                TableSummaryProject.ProjectNo = dr["ProjectNo"].ToString();
                TableSummaryProject.StartDate = dr["StartDate"].ToString();
                TableSummaryProject.EndDate = dr["EndDate"].ToString();
                TableSummaryProject.RealisasiPencapaian = dr["RealisasiPencapaian"].ToString();

                ListTableSummaryProject.Add(TableSummaryProject);
            }

            DashboardSummaryHeaderModel.ListTableSummaryProject = ListTableSummaryProject;

            return DashboardSummaryHeaderModel;
        }
    }
}
