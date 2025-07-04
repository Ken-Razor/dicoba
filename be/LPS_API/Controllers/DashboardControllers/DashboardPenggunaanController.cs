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
    public class DashboardPenggunaanController : ApiController
    {
        public List<DashboardPenggunaanModel> Post(DashboardPenggunaanModel param)
        {
            List<DashboardPenggunaanModel> ListDashboardPenggunaan = new List<DashboardPenggunaanModel>();
            DashboardData dd = new DashboardData();
            DataTable dt = new DataTable();

            dt = dd.GetDashboardPenggunaan(param.Year, param.StartMonth, param.EndMonth, param.IsTranformasi);
            foreach (DataRow item in dt.Rows)
            {
                DashboardPenggunaanModel model = new DashboardPenggunaanModel();
                model.DepartementCode = item["DepartmentCode"].ToString();
                model.NoRealisation = Convert.ToInt32(item["NoRealisation"].ToString());
                model.Completed = Convert.ToInt32(item["Completed"].ToString());
                model.WaitApproval = Convert.ToInt32(item["WaitApproval"].ToString());
                model.Total = Convert.ToInt32(item["Total"].ToString());

                model.PersenNorealisation = float.Parse(item["PersenNorealisation"].ToString());
                model.PersenCompleted = float.Parse(item["PersenCompleted"].ToString());
                model.PersenWaitApproval = float.Parse(item["PersenWaitApproval"].ToString());
                ListDashboardPenggunaan.Add(model);
            }

            return ListDashboardPenggunaan;
        }
    }
}
