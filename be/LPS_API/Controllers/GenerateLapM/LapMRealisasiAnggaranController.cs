using LPS_API.Models.ReportModels;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.ReportController
{
    public class LapMRealisasiAnggaranController : ApiController
    {
        public RealisasiAnggaran Post([FromBody] LapMDataModel obj)
        {
            GenerateLapM r = new GenerateLapM();

            DataSet ds = r.Get_LapM_RealisasiAnggaran(obj.tanggal);
            DataTable dt1 = ds.Tables[0];
            List<RealisasiAnggaran> resList = new List<RealisasiAnggaran>();
            resList = (from DataRow dr in dt1.Rows
                           select new RealisasiAnggaran()
                           {
                               Anggaran = double.Parse(dr["Anggaran"].ToString()),
                               Realisasi = double.Parse(dr["Realisasi"].ToString()),
                               KomitAnggaran = double.Parse(dr["KomitAnggaran"].ToString()),
                               Jumlah = double.Parse(dr["Jumlah"].ToString()),
                               Persentase = double.Parse(dr["Persentase"].ToString())
                           }).ToList();
            return resList.FirstOrDefault();
        }
    }
}

