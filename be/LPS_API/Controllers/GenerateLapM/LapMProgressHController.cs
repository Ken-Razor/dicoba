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
    public class LapMProgressHController : ApiController
    {
        public LapMProgressHModel Post([FromBody] LapMDataModel obj)
        {
            GenerateLapM r = new GenerateLapM();

            DataSet ds = r.Get_LapM_ProgressHeader(obj.tanggal);
            DataTable dt1 = ds.Tables[0];
            List<LapMProgressHModel> resList = new List<LapMProgressHModel>();
            if (dt1!=null)
            {
                if (dt1.Rows.Count>=1)
                {
                    resList = (from DataRow dr in dt1.Rows
                               select new LapMProgressHModel()
                               {
                                   Target = Convert.ToDouble(dr["Target"]??0),
                                   Realisasi = Convert.ToDouble(dr["Realisasi"]??0),
                                   Pencapaian = Convert.ToDouble(dr["Pencapaian"] ?? 0),
                                   PencapaianLalu = Convert.ToDouble(dr["PencapaianLalu"] ?? 0)
                               }).ToList();  
                }
            }
            return resList.FirstOrDefault();
        }
    }
}

