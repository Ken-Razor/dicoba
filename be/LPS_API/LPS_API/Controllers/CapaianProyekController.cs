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
  
    public class CapaianProyekController : ApiController
    {
        public List<CapaianProyekModel> Post([FromBody]CapaianProyekModel cpm)
        {
            Report r = new Report();
            List<CapaianProyekModel> ListCapaianProyek = new List<CapaianProyekModel>();

            foreach (DataRow dr in r.Get_Report_CapaianProyek(cpm.tipe, cpm.week, cpm.month, cpm.year).Rows)
            {
                CapaianProyekModel CapaianProyek = new CapaianProyekModel();

                CapaianProyek.NamaProgram = dr["NamaProgram"].ToString();
                CapaianProyek.TotalAnggaran = dr["TotalAnggaran"].ToString();
                CapaianProyek.Status = dr["Status"].ToString();
                CapaianProyek.RataPencapain = dr["RataPencapain"].ToString();
                CapaianProyek.Realisasi = dr["Realisasi"].ToString();
                CapaianProyek.Realkomit = dr["Realkomit"].ToString();

                ListCapaianProyek.Add(CapaianProyek);
            }
            return ListCapaianProyek;
        }

    }
}

