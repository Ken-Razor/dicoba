using LPS_API.Models.ReportModels;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.ReportController
{
    public class LapMProTimesSeriesController : ApiController
    {
        public List<LapMTSeriesModel> Post([FromBody] LapMDataModel obj)
        {
            GenerateLapM r = new GenerateLapM();

            DataSet ds = r.Get_LapM_ProjectTimeSeries(obj.tanggal);
            DataTable dt1 = ds.Tables[0];
            List<LapMTSeriesModel> resList = new List<LapMTSeriesModel>();
            resList = (from DataRow dr in dt1.Rows
                           select new LapMTSeriesModel()
                           {
                               Periode = DateTime.Parse(dr["Periode"].ToString()).ToString("MMM"),
                               Minggu = dr["Minggu"].ToString(),
                               Target = Convert.ToDouble(dr["Target"]),
                               Realisasi = Convert.ToDouble(dr["Realisasi"]),
                           }).ToList();
            return resList;
        }
    }
}

