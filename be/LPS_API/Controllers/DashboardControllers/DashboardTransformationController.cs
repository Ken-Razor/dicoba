using LPS_API.Models.DashboardModels;
using LPS_BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace LPS_API.Controllers.DashboardControllers
{
    public class DashboardTransformationController : ApiController
    {
        // GET: DashboardTransformation
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public List<DashboardTransformation> Get()
        {
            DashboardData dd = new DashboardData();
            List<DashboardTransformation> lDt = new List<DashboardTransformation>();

            foreach (DataRow dr in dd.DashboardTransformation().Rows)
            {
                DashboardTransformation dt = new DashboardTransformation();
                dt.Details = dr["Details"].ToString();
                dt.TransformationPercentase = Convert.ToDouble(dr["TransformasiPercentase"].ToString());
                dt.TotalProject = Convert.ToInt32(dr["TotalProject"].ToString());

                lDt.Add(dt);
            }

            var json = JsonConvert.SerializeObject(lDt);

            return lDt;
        }
    }
}