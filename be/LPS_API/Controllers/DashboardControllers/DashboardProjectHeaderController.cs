using LPS_API.Models.DashboardModels;
using LPS_API.Models.DashboardModels.DashboardProject;
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
    public class DashboardProjectHeaderController : ApiController
    {
        //[HttpGet]
        //public DashboardProjectHeader GetDashboardProjectHeader(int projectId)
        //{
        //    return DashboardProjectHeader.Get(projectId);
        //}

        public DashboardProjectHeaderModel Post(DashboardProjectHeaderModel param) {

            DashboardProjectHeaderModel dphm = new DashboardProjectHeaderModel();
            DashboardData dd = new DashboardData();
            DataTable dt = new DataTable();

            dt = dd.GetBerandaProjectHeader(param.Year,param.Month, param.Day);

            dphm.Date = dt.Rows[0]["Date"].ToString();
            dphm.Time = dt.Rows[0]["Time"].ToString();
            dphm.Year = dt.Rows[0]["Year"].ToString();
            dphm.Month = Convert.ToInt32(dt.Rows[0]["Month"]);
            dphm.Day = Convert.ToInt32(dt.Rows[0]["Day"]);
            dphm.Week = Convert.ToInt32(dt.Rows[0]["Week"]);
            dphm.JumlahWeek = Convert.ToInt32(dt.Rows[0]["JumlahWeek"]);

            return dphm;

        }

    }
}
