using LPS_API.Models.MasterDataModels;
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
    public class EvaluasiCapaianProyekController : ApiController
    {
        public List<EvaluasiCapaianProyekModel> Post([FromBody]EvaluasiCapaianProyekModel ecp)
        {
            Report r = new Report();
            List<EvaluasiCapaianProyekModel> ListEvaluasiCapaianProyek = new List<EvaluasiCapaianProyekModel>();
            DataSet ds = r.Get_Report_EvaluasiCapaianProyek(ecp.Month, ecp.Year, ecp.IsTransformasi, ecp.IDProgram, ecp.IDDirektorat,ecp.Week);
            DataTable dt0 = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];

            foreach (DataRow dr in dt0.Rows)
            {
                EvaluasiCapaianProyekModel EvaluasiCapaianProyek = new EvaluasiCapaianProyekModel();

                if (dr["IDProgram"].ToString() != "") EvaluasiCapaianProyek.IDProgram = Convert.ToInt32(dr["IDProgram"]);
                if (dr["IDProject"].ToString() != "") EvaluasiCapaianProyek.IDProject = Convert.ToInt32(dr["IDProject"]);
                if (dr["IsTransformasi"].ToString() != "") EvaluasiCapaianProyek.IsTransformasi = Convert.ToBoolean(dr["IsTransformasi"]);
                EvaluasiCapaianProyek.Name = dr["Name"].ToString();
                EvaluasiCapaianProyek.PIC = dr["PIC"].ToString();
                EvaluasiCapaianProyek.Waktu = dr["Waktu"].ToString();
                EvaluasiCapaianProyek.ContractIDR = dr["ContractIDR"].ToString();
                EvaluasiCapaianProyek.Target = dr["Target"].ToString();
                EvaluasiCapaianProyek.Realisasi = dr["Realisasi"].ToString();
                EvaluasiCapaianProyek.Capaian = dr["Capaian"].ToString();
                EvaluasiCapaianProyek.RealisasiAnggaran = dr["RealisasiAnggaran"].ToString();
                EvaluasiCapaianProyek.RealisasiKomit = dr["RealisasiKomit"].ToString();
                EvaluasiCapaianProyek.Tren = dr["Tren"].ToString();
                
                ListEvaluasiCapaianProyek.Add(EvaluasiCapaianProyek);
            }
            return ListEvaluasiCapaianProyek;
        }

        public List<ListEvaluasiCapaianProyekModel> Put([FromBody]ListEvaluasiCapaianProyekModel ecp)
        {
            Report r = new Report();
            List<ListEvaluasiCapaianProyekModel> ListEvaluasiCapaianProyek = new List<ListEvaluasiCapaianProyekModel>();
            DataTable dt0 = r.Get_List_EvaluasiCapaianProyek(ecp.Month, ecp.Year, ecp.IsTransformasi, ecp.IDDirektorat,ecp.Week);
            foreach (DataRow dr in dt0.Rows)
            {
                ListEvaluasiCapaianProyekModel EvaluasiCapaianProyek = new ListEvaluasiCapaianProyekModel();

                if (dr["NoUrut"].ToString() != "") EvaluasiCapaianProyek.NoUrut = Convert.ToInt32(dr["NoUrut"]);
                if (dr["IDProgram"].ToString() != "") EvaluasiCapaianProyek.IDProgram = Convert.ToInt32(dr["IDProgram"]);
                EvaluasiCapaianProyek.ProgramName = dr["ProgramName"].ToString();
                EvaluasiCapaianProyek.ProgramNo = dr["ProgramNo"].ToString();
                EvaluasiCapaianProyek.Description = dr["Description"].ToString();
                EvaluasiCapaianProyek.Year = dr["Year"].ToString();
                if (dr["Month"].ToString() != "") EvaluasiCapaianProyek.Month = Convert.ToInt32(dr["Month"]);
                if (dr["IsTransformasi"].ToString() != "") EvaluasiCapaianProyek.IsTransformasi = Convert.ToBoolean(dr["IsTransformasi"]);
                
                ListEvaluasiCapaianProyek.Add(EvaluasiCapaianProyek);
            }
            return ListEvaluasiCapaianProyek;
        }
        
    }
}
