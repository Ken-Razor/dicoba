using LPS_API.Helper;
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

    public class SeriesPertahunController : ApiController
    {
        public List<SeriesPertahunModel> Post([FromBody]SeriesPertahunModel spm)
        {
            Report r = new Report();
            List<SeriesPertahunModel> ListSeriesPertahun = new List<SeriesPertahunModel>();

            foreach (DataRow dr in r.Get_ReportSeriesPerYear(spm.thn1, spm.thn2).Rows)
            {
                SeriesPertahunModel SeriesPertahun = new SeriesPertahunModel();

                //SeriesPertahun.Tahun = Convert.ToInt32(dr["Tahun"]);
                SeriesPertahun.Tahun = dr["Tahun"].ToString();
                SeriesPertahun.TotalProject = dr["TotalProject"].ToString();
                SeriesPertahun.TotalAnggaran = dr["TotalAnggaran"].ToString();
                SeriesPertahun.Pencapaian = dr["Pencapain"].ToString();
                SeriesPertahun.CapaianKPI = dr["CapaianKPI"].ToString();

                ListSeriesPertahun.Add(SeriesPertahun);
            }
            return ListSeriesPertahun;
        }

    }
}

