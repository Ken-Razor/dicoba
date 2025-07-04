using LPS_API.Models.DashboardModels;
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
    public class DashboardProjectProgressController : ApiController
    {

        public List<DashboardProjectProgressModel> Post(DashboardProjectProgressModel param)
        {
            List<DashboardProjectProgressModel> ListDashboardProjectProgress = new List<DashboardProjectProgressModel>();
            DashboardData dd = new DashboardData();
            DataTable dt = new DataTable();

            dt = dd.GetDashboardProjectProgress(param.Year, param.Month, param.Filter, param.Week, param.PersonalNumber);

            foreach (DataRow data in dt.Rows)
            {
                DashboardProjectProgressModel dppm = new DashboardProjectProgressModel();
                if (data["Total"].ToString() != "") dppm.y = Convert.ToInt32(data["Total"]);
                dppm.name = data["Progress"].ToString();
                dppm.color = data["Color"].ToString();
                dppm.Filter = data["Filter"].ToString();

                ListDashboardProjectProgress.Add(dppm);
            }

            return ListDashboardProjectProgress;
        }

    }
}
