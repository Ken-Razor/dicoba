using LPS_API.Models.DashboardModels;
using LPS_API.Models.DashboardModels.DashboardSummary;
using LPS_BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace LPS_API.Controllers.DashboardControllers
{
    public class StatusDashboardSOController : ApiController
    {

        public DashboardSummaryStatusModel Post([FromBody]DashboardSummaryStatusModel model)
        {
            try
            {
                DashboardData dd = new DashboardData();
                DashboardSummaryStatusModel DashboardSummaryStatusModel = new DashboardSummaryStatusModel();
                List<TableSummaryProject> ListTableSummaryProject = new List<TableSummaryProject>();

                DataSet ds = dd.DashboardSO(model.Filter, model.Code, model.IsTransformasi, model.Year, model.Month, model.Week);
                DataTable dtStatusList = ds.Tables[0];
                DataTable dtProjectList = ds.Tables[1];

                if(dtStatusList.Rows.Count > 0)
                {
                    DashboardSummaryStatusModel.Draft = Convert.ToInt32(dtStatusList.Rows[0]["Draft"]);
                    DashboardSummaryStatusModel.JauhDibawahTarget = Convert.ToInt32(dtStatusList.Rows[0]["JauhDibawahTarget"]);
                    DashboardSummaryStatusModel.DibawahTarget = Convert.ToInt32(dtStatusList.Rows[0]["DibawahTarget"]);
                    DashboardSummaryStatusModel.SesuaiTarget = Convert.ToInt32(dtStatusList.Rows[0]["SesuaiTarget"]);
                    DashboardSummaryStatusModel.DiatasTarget = Convert.ToInt32(dtStatusList.Rows[0]["DiatasTarget"]);
                    DashboardSummaryStatusModel.Completed = Convert.ToInt32(dtStatusList.Rows[0]["Completed"]);
                }
                else
                {
                    DashboardSummaryStatusModel.Draft = 0;
                    DashboardSummaryStatusModel.JauhDibawahTarget = 0;
                    DashboardSummaryStatusModel.DibawahTarget = 0;
                    DashboardSummaryStatusModel.SesuaiTarget = 0;
                    DashboardSummaryStatusModel.DiatasTarget = 0;
                    DashboardSummaryStatusModel.Completed = 0;
                }

                foreach (DataRow dr in dtProjectList.Rows)
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

                DashboardSummaryStatusModel.ListTableSummaryProject = ListTableSummaryProject;

                return DashboardSummaryStatusModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}