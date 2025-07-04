using LPS_API.Models.DashboardModels;
using LPS_BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace LPS_API.Controllers.DashboardControllers
{
    public class DashboardTotalAllStatusController : ApiController
    {
        // GET: DashboardTotalAllStatus
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public List<DashboardAllProjectStatus> Get()
        {
            DashboardData dd = new DashboardData();
            List<DashboardAllProjectStatus> lps = new List<DashboardAllProjectStatus>();

            foreach (DataRow dr in dd.DashboardAllStatus().Rows)
            {
                DashboardAllProjectStatus dt = new DashboardAllProjectStatus();
                dt.StatusName = dr["StatusName"].ToString();
                dt.Total = Convert.ToInt32(dr["Total"].ToString());

                lps.Add(dt);
            }

            var json = JsonConvert.SerializeObject(lps);

            return lps;
        }
    }
}