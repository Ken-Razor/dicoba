using LPS_API.Models.DashboardModels;
using LPS_BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace LPS_API.Controllers.DashboardControllers
{
    public class DashboardProjectListSOController : ApiController
    {
        // GET: DashboardProjectListSO
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public List<ProjectListSODashboard> Put([FromBody] ProjectListSODashboard model)
        {
            DashboardData dd = new DashboardData();
            List<ProjectListSODashboard> lPlso = new List<ProjectListSODashboard>();

            foreach (DataRow dr in dd.DashboardProjectListSO(model.StatusName, model.IsTransformation, model.StrategicObjective).Rows)
            {
                ProjectListSODashboard plso = new ProjectListSODashboard();
                plso.IDProject = Convert.ToInt32(dr["IDProject"].ToString());
                plso.ProjectNo = dr["ProjectNo"].ToString();
                plso.ProjectName = dr["ProjectName"].ToString();
                plso.ContractStartDate = dr["ContractStartDate"].ToString();
                plso.ContractEndDate = dr["ContractEndDate"].ToString();
                plso.StatusName = dr["StatusName"].ToString();

                lPlso.Add(plso);
            }

            var json = JsonConvert.SerializeObject(lPlso);

            return lPlso;
        }
    }
}