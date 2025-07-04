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
    public class LapMPencapaianMingguanController : ApiController
    {
        public List<LapMTStatusPerMinggu> Post([FromBody] LapMDataModel obj)
        {
            GenerateLapM r = new GenerateLapM();

            DataSet ds = r.Get_LapM_PencapaianperMinggu(obj.tanggal);
            DataTable dt1 = ds.Tables[0];
            List<LapMTStatusPerMinggu> resList = new List<LapMTStatusPerMinggu>();
            resList = (from DataRow dr in dt1.Rows
                           select new LapMTStatusPerMinggu()
                           {
                               Keterangan = dr["Keterangan"].ToString(),
                               Minggu = dr["Minggu"].ToString(),
                               Pencapaian = dr["Pencapaian"].ToString(),
                               Pencapaian2 = dr["Pencapaian2"].ToString(),
                               Pencapaian3 = dr["Pencapaian3"].ToString(),
                               Pencapaian4 = dr["Pencapaian4"].ToString(),
                               Pencapaian5 = dr["Pencapaian5"].ToString(),
                           }).ToList();
            return resList;
        }
    }
}

