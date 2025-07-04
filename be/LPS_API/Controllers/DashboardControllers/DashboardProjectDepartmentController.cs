using LPS_API.Models.DashboardModels;
using LPS_BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace LPS_API.Controllers.DashboardControllers
{
    public class DashboardProjectDepartmentController : ApiController
    {
        // GET: DashboardProjectDepartment
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public List<DashboardProjectDepartment> Get()
        {
            DashboardData dd = new DashboardData();
            List<DashboardProjectDepartment> lps = new List<DashboardProjectDepartment>();

            foreach (DataRow dr in dd.DashboardProjectDepartment().Rows)
            {
                DashboardProjectDepartment dt = new DashboardProjectDepartment();
                dt.Type = dr["Type"].ToString();
                dt.GP = Convert.ToInt32(dr["GP"].ToString());
                dt.GSPO = Convert.ToInt32(dr["GSPO"].ToString());
                dt.GSTF = Convert.ToInt32(dr["GSTF"].ToString());
                dt.TES2 = Convert.ToInt32(dr["TES2"].ToString());
                dt.TESqwer = Convert.ToInt32(dr["TESqwer"].ToString());
                dt.dfg = Convert.ToInt32(dr["dfg"].ToString());
                dt.asdfgh = Convert.ToInt32(dr["asdfgh"].ToString());
                dt.asd = Convert.ToInt32(dr["asd"].ToString());

                lps.Add(dt);
            }

            var json = JsonConvert.SerializeObject(lps);

            return lps;
        }
    }
}