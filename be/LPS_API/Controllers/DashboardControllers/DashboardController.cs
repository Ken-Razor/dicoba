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
    public class DashboardController : ApiController
    {
        //test
        public string Get()
        {
            DashboardData dd = new DashboardData();

            return dd.GenerateDashboard();
        }

        public List<DashboardTransAndNoTransModel> Post(DashboardProjectModel param)
        {
            List<DashboardTransAndNoTransModel> ListDashboardTransAndNonTrans = new List<DashboardTransAndNoTransModel>();
            DashboardData dd = new DashboardData();
            DataTable dt = new DataTable();

            dt = dd.GetDashboardTransAndNoTrans(param.Year, param.Month, param.Week, param.PersonalNumber);

            foreach (DataRow data in dt.Rows)
            {
                DashboardTransAndNoTransModel dtnt = new DashboardTransAndNoTransModel();
                if (data["id"].ToString() != "") dtnt.id = Convert.ToInt32(data["id"]);
                if (data["y"].ToString() != "") dtnt.y = Convert.ToInt32(data["y"]);
                dtnt.color = data["color"].ToString();
                dtnt.name = data["name"].ToString();

                ListDashboardTransAndNonTrans.Add(dtnt);
            }

            return ListDashboardTransAndNonTrans;
        }
    }
}
