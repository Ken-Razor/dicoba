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
    public class DashboardProjectOverAllController : ApiController
    {

        public List<DashboardProjectOverallModel> Post([FromBody]DashboardProjectOverallModel param)
        {
            try
            {
                List<DashboardProjectOverallModel> ListDashboardProjectOverall = new List<DashboardProjectOverallModel>();
                DashboardData dd = new DashboardData();
                DataTable dt = new DataTable();

                dt = dd.GetDashboardProjectOverall(param.Filter, param.Year, param.PersonalNumber);

                foreach (DataRow data in dt.Rows)
                {
                    DashboardProjectOverallModel dpom = new DashboardProjectOverallModel();
                    if (data["ID"].ToString() != "") dpom.ID = Convert.ToInt32(data["ID"]);
                    if (data["TotalTransformasi"].ToString() != "") dpom.TotalTransforamsi = Convert.ToInt32(data["TotalTransformasi"]);
                    if (data["TotalNonTransformasi"].ToString() != "") dpom.TotalNonTransforamsi = Convert.ToInt32(data["TotalNonTransformasi"]);
                    if (data["TotalProject"].ToString() != "") dpom.TotalProject = Convert.ToInt32(data["TotalProject"]);
                    dpom.Code = data["Code"].ToString();
                    dpom.Name = data["Name"].ToString();

                    ListDashboardProjectOverall.Add(dpom);
                }

                return ListDashboardProjectOverall;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
