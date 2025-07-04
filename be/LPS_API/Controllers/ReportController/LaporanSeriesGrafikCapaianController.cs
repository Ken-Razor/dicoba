using LPS_BLL;
using LPS_BLL.Models.ReportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.ReportController
{
    public class LaporanSeriesGrafikCapaianController : ApiController
    {
        [HttpPost]
        [Route("api/LaporanSeriesGrafikCapaian/GetSeriesCapaianFisik")]
        public LaporanSeriesGrafikCapaianViewModel GetSeriesCapaianFisik([FromBody] LaporanSeriesGrafikCapaianParamModel param)
        {
            LaporanSeriesGrafikCapaianViewModel d = new LaporanSeriesGrafikCapaianViewModel();
            LaporanSeriesGrafikCapaian f = new LaporanSeriesGrafikCapaian();
            //d.HeaderModel = f.GetSeriesGrafikCapaianFisikHeader(param);
            d.DetailModel = f.GetSeriesGrafikCapaianFisikDetail(param);
            var idList = d.DetailModel.Select(q => q.Id).Distinct().ToList();
            d.HeaderModel = new List<LaporanSeriesGrafikCapaianHeaderModel>();
            foreach (var item in idList)
            {
                var header = new LaporanSeriesGrafikCapaianHeaderModel();
                header.Id = item;
                header.Name = d.DetailModel.Where(x => x.Id == item).Select(q => q.Name).FirstOrDefault();
                header.RataRataCapaian = Math.Round(d.DetailModel.Where(x => x.Id == item).ToList().Average(q => q.RealisasiPencapaian), 0);
                d.HeaderModel.Add(header);
            }
            return d;
        }

        [HttpPost]
        [Route("api/LaporanSeriesGrafikCapaian/GetSeriesCapaianKpi")]
        public LaporanSeriesGrafikCapaianKpiViewModel GetSeriesCapaianKpi([FromBody] LaporanSeriesGrafikCapaianParamModel param)
        {
            LaporanSeriesGrafikCapaianKpiViewModel d = new LaporanSeriesGrafikCapaianKpiViewModel();
            LaporanSeriesGrafikCapaian f = new LaporanSeriesGrafikCapaian();
            d.DetailModel = f.GetSeriesGrafikCapaianKpiDetail(param);
            //d.HeaderModel = f.GetSeriesGrafikCapaianKpiHeader(param);
            foreach (var item in d.DetailModel)
            {
                var totalPoin = d.DetailModel.Where(x => x.Id == item.Id).Sum(q => q.Poin);
                item.Bobot = totalPoin != 0? Math.Round(item.Poin / totalPoin,3) : 0;
            }
            var categoryCodeList = d.DetailModel.Select(q => q.Id).Distinct().ToList();
            d.HeaderModel = new List<LaporanSeriesGrafikCapaianHeaderKpiModel>();
            
            foreach (var item in categoryCodeList)
            {
                var header = new LaporanSeriesGrafikCapaianHeaderKpiModel();
                header.Id = item;
                header.Name = d.DetailModel.Where(x => x.Id == item).Select(q => q.Name).FirstOrDefault();
                header.CapaianKpi = Math.Round(d.DetailModel.Where(x => x.Id == item).ToList().Sum(q => (q.RealisasiPencapaian/100) * q.Bobot),3);
                d.HeaderModel.Add(header);
            }
            return d;
        }

        [HttpPost]
        [Route("api/LaporanSeriesGrafikCapaian/GetSeriesCapaianKpiDetail")]
        public List<LaporanSeriesGrafikCapaianDetailModel> GetSeriesCapaianKpiDetail([FromBody] LaporanSeriesGrafikCapaianParamModel param)
        {
            List<LaporanSeriesGrafikCapaianDetailModel> d = new List<LaporanSeriesGrafikCapaianDetailModel>();
            LaporanSeriesGrafikCapaian f = new LaporanSeriesGrafikCapaian();
            d = f.GetSeriesGrafikCapaianKpiDetail(param);
            foreach (var item in d)
            {
                var totalPoin = d.Where(x => x.Id == item.Id).Sum(q => q.Poin);
                item.Bobot = totalPoin != 0 ? Math.Round(item.Poin / totalPoin, 3) : 0;
            }
            return d;
        }

        [HttpPost]
        [Route("api/LaporanSeriesGrafikCapaian/GetSeriesCapaianFisikDetail")]
        public List<LaporanSeriesGrafikCapaianDetailModel> GetSeriesCapaianFisikDetail([FromBody] LaporanSeriesGrafikCapaianParamModel param)
        {
            List<LaporanSeriesGrafikCapaianDetailModel> d = new List<LaporanSeriesGrafikCapaianDetailModel>();
            LaporanSeriesGrafikCapaian f = new LaporanSeriesGrafikCapaian();
            d = f.GetSeriesGrafikCapaianFisikDetail(param);
            return d;
        }

    }
}
