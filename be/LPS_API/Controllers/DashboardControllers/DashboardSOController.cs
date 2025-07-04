using LPS_API.Models.DashboardModels;
using LPS_BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace LPS_API.Controllers.DashboardControllers
{
    public class DashboardSOController : ApiController
    {
        // GET: DashboardSO
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public List<DashboardSOModel> Get()
        {
            DashboardData dd = new DashboardData();
            List<DashboardSOModel> lDsm = new List<DashboardSOModel>();

            foreach (DataRow dr in dd.DashboardSO().Rows)
            {
                DashboardSOModel dsm = new DashboardSOModel();
                dsm.StrategicObjectiveCode = dr["StrategicObjectiveCode"].ToString();
                dsm.TotalUsedSO = Convert.ToInt32(dr["TotalUsedSO"].ToString());

                lDsm.Add(dsm);
            }

            var json = JsonConvert.SerializeObject(lDsm);

            return lDsm;
        }
    }
}