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
    public class DashboardProjectTimeSeriesController : ApiController
    {

        public List<DashboardProjectTimeSeriesModel> Post(DashboardProjectTimeSeriesModel param)
        {
            List<DashboardProjectTimeSeriesModel> ListDashboardProjectTimeSeries = new List<DashboardProjectTimeSeriesModel>();
            DashboardData dd = new DashboardData();
            DataTable dt = new DataTable();

            dt = dd.GetDashboardProjectTimeSeries(param.Filter, param.Year, param.Month, param.Week, param.PersonalNumber);

            foreach (DataRow data in dt.Rows)
            {
                DashboardProjectTimeSeriesModel dptsm = new DashboardProjectTimeSeriesModel();

                dptsm.Periode = data["Periode"].ToString();
                dptsm.Target = Convert.ToInt32(data["Target"]);
                dptsm.Realisasi = Convert.ToInt32(data["Realisasi"]);
                
                ListDashboardProjectTimeSeries.Add(dptsm);
            }

            return ListDashboardProjectTimeSeries;
        }

    }
}
