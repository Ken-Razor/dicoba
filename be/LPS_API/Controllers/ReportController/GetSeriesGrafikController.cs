//using LPS_API.Models.ReportModels;
using LPS_API.Models.ReportModels;
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
    public class GetSeriesGrafikController : ApiController
    {

        public List<LaporanGrafikSeriesPeriode> Post(LaporanGrafikSeriesPeriode param)
        {
            List<LaporanGrafikSeriesPeriode> ListDashboardProjectTimeSeries = new List<LaporanGrafikSeriesPeriode>();
            LaporanSeriesPeriode dd = new LaporanSeriesPeriode();
            DataTable dt = new DataTable();

            dt = dd.GetLaporanGrafikSeriesPeriode(param.Filter, param.Year);

            foreach (DataRow data in dt.Rows)
            {
                LaporanGrafikSeriesPeriode dptsm = new LaporanGrafikSeriesPeriode();

                dptsm.Periode = data["Periode"].ToString();
                dptsm.Hasil = Convert.ToDouble(data["Hasil"]);
                dptsm.BelumMulai = Convert.ToDouble(data["BelumMulai"]);
                dptsm.Complete = Convert.ToDouble(data["Complete"]);

                ListDashboardProjectTimeSeries.Add(dptsm);
            }

            return ListDashboardProjectTimeSeries;
        }

        //public List<SeriesGrafikModel> Post(SeriesGrafikModel param)
        //{
        //    List<SeriesGrafikModel> ListSeriesGrafik = new List<SeriesGrafikModel>();
        //    DashboardData dd = new DashboardData();
        //    DataTable dt = new DataTable();

        //    dt = dd.GetSeriesGrafik(param.Year, param.Month, param.Week);

        //    foreach (DataRow data in dt.Rows)
        //    {
        //        SeriesGrafikModel sgm = new SeriesGrafikModel();

        //        sgm.Tahun = data["Periode"].ToString();
        //        sgm.TotalProject = data["TotalProject"].ToString();
        //        sgm.TotalAnggaran = data["TotalAnggaran"].ToString();
        //        sgm.Pencapaian = data["Pencapaian"].ToString();

        //        ListSeriesGrafik.Add(sgm);
        //    }

        //    return ListSeriesGrafik;
        //}

    }
}
