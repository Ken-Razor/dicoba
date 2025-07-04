using LPS_API.Models.DashboardModels;
using LPS_BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace LPS_API.Controllers.DashboardControllers
{
    public class DashboardProjectTypeSOController : ApiController
    {
        // GET: DashboardProjectTypeSO
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public DashboardProjectTypeModel Put([FromBody]DashboardProjectTypeModel model)
        {
            DashboardData dd = new DashboardData();
            List<DashboardProjectTypeSO> lPT = new List<DashboardProjectTypeSO>();
            List<ProjectListSODashboard> lPL = new List<ProjectListSODashboard>();

            DashboardProjectTypeModel DashboardSO = new DashboardProjectTypeModel();

            var ds = dd.DashboardProjectTypeSO(model.SOID);
            var dtProjectType = ds.Tables[0];
            var dtProjectList = ds.Tables[1];

            foreach (DataRow item in dtProjectType.Rows)
            {
                DashboardProjectTypeSO _Detail = new DashboardProjectTypeSO();

                _Detail.Type = item["Type"].ToString();
                _Detail.Total = Convert.ToInt32(item["Total"].ToString());

                lPT.Add(_Detail);
            }

            DashboardSO.ProjectType = lPT;

            foreach (DataRow item in dtProjectList.Rows)
            {
                ProjectListSODashboard _Detail = new ProjectListSODashboard();

                _Detail.IDProject = Convert.ToInt32(item["IDProject"].ToString());
                _Detail.ProjectNo = item["ProjectNo"].ToString();
                _Detail.ProjectName = item["ProjectName"].ToString();
                _Detail.ContractStartDate = item["ContractStartDate"].ToString();
                _Detail.ContractEndDate = item["ContractEndDate"].ToString();
                _Detail.StatusName = item["StatusName"].ToString();

                lPL.Add(_Detail);
            }

            DashboardSO.ProjectList = lPL;

            var json = JsonConvert.SerializeObject(lPT);

            return DashboardSO;
        }
    }
}