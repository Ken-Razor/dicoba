using LPS_API.Models.DashboardModels;
using LPS_BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace LPS_API.Controllers.DashboardControllers
{
    public class DashboardUsedSOController : ApiController
    {
        // GET: DashboardUsedSO
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public List<DashboardSOUsed> Get()
        {
            DashboardData dd = new DashboardData();
            List<DashboardSOUsed> ldsu = new List<DashboardSOUsed>();

            foreach (DataRow dr in dd.DashboardSOUsed().Rows)
            {
                DashboardSOUsed dsm = new DashboardSOUsed();
                dsm.Type = dr["Type"].ToString();
                dsm.Total = Convert.ToInt32(dr["Total"].ToString());

                ldsu.Add(dsm);
            }

            var json = JsonConvert.SerializeObject(ldsu);

            return ldsu;
        }
    }
}