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
    public class DashboardProjectController : ApiController
    {
        public DashboardProjectModel Post(DashboardProjectModel param)
        {
            DashboardProjectModel mre = new DashboardProjectModel();
            DashboardData dd = new DashboardData();
            DataSet ds = new DataSet();
            DataTable dtTotalProject = new DataTable();

            ds = dd.GetDashboardProjectHeader(param.Filter, param.Year, param.Month, param.Week, param.PersonalNumber);
            dtTotalProject = ds.Tables[0];

            mre.TotalProject = dtTotalProject.Rows[0]["TotalProject"].ToString();
            mre.Pencapaian = dtTotalProject.Rows[0]["Pencapaian"].ToString();
            mre.Anggaran = dtTotalProject.Rows[0]["Anggaran"].ToString();
            mre.Realisasi = dtTotalProject.Rows[0]["Realisasi"].ToString();
            mre.Week = Convert.ToInt32(dtTotalProject.Rows[0]["Week"]);

            return mre;
        }
    }
}
