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
    public class LapMCapaianController : ApiController
    {
        public List<LapMTPencapaian> Post([FromBody] LapMDataModel obj)
        {
            GenerateLapM r = new GenerateLapM();

            DataSet ds = r.Get_LapM_Capaian(obj.tanggal);
            DataTable dt1 = ds.Tables[0];
            List<LapMTPencapaian> resList = new List<LapMTPencapaian>();
            resList = (from DataRow dr in dt1.Rows
                           select new LapMTPencapaian()
                           {
                               Pencapaian = dr["Pencapaian"].ToString(),
                               PencapaianLalu = dr["PencapaianLalu"].ToString()
                           }).ToList();
            return resList;
        }
    }
}

