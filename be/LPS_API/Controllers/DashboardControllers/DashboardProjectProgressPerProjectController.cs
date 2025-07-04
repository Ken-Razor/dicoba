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
    public class DashboardProjectProgressPerProjectController : ApiController
    {

        public List<DashboardProjectProgressPerProjectModel> Post(DashboardProjectProgressPerProjectModel param)
        {
            List<DashboardProjectProgressPerProjectModel> ListDashboardProjectProgress = new List<DashboardProjectProgressPerProjectModel>();
            DashboardData dd = new DashboardData();
            DataTable dt = new DataTable();

            dt = dd.Get_DashboardProjectProgressPerProject(param.Year, param.Month, param.Filter, param.Week, param.PersonalNumber);

            foreach (DataRow data in dt.Rows)
            {
                DashboardProjectProgressPerProjectModel dppm = new DashboardProjectProgressPerProjectModel();
                string number= data["Pencapaian"].ToString();
                var arrn = number.Split(',');
                var arrn2 = arrn[0].Split('.');
                number = arrn2[0];
                dppm.ID= int.Parse(data["IDProjectHeader"].ToString());
                dppm.name = data["Progress"].ToString();
                dppm.color = data["Color"].ToString();
                dppm.Filter = data["Filter"].ToString();
                dppm.NamaProject= data["NamaProject"].ToString();
                dppm.Pencapaian = data["Pencapaian"].ToString();
                if (int.Parse(number) > 100)
                {
                    dppm.y = 100;
                }
                else if (int.Parse(number) < 0)
                {
                    dppm.y = 0;
                }
                else
                {
                    dppm.y = int.Parse(number);
                }
                ListDashboardProjectProgress.Add(dppm);
            }

            return ListDashboardProjectProgress;
        }

    }
}
