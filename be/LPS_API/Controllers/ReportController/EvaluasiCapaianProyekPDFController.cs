using LPS_API.Helper;
using LPS_API.Models.ReportModels;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace LPS_API.Controllers.ReportController
{
    public class EvaluasiCapaianProyekPDFController : ApiController
    {
        [HttpPost]
        [Route("api/EvaluasiCapaianProyekPDF/GenerateLaporanGptfPerWeek")]
        public LaporanPerMingguGptfModel GenerateLaporanGptfPerWeek([FromBody] EvaluasiCapaianProyekModel ecp)
        {
            IntegrationSystem I = new IntegrationSystem();
            GlobalFunction gf = new GlobalFunction();
            DataSet ds = I.GetReportGptfPerWeek(ecp.Month, ecp.Year, ecp.Week);
            List<DataListReportGptf> dt = gf.ConvertTo<DataListReportGptf>(ds.Tables[0]);
            List<DataListReportGptf> dtBeforeLastWeek = gf.ConvertTo<DataListReportGptf>(ds.Tables[1]);
            var dtHeader = dt.Select(q => q.IDProgram).Distinct().ToList();
            List<DataHeaderReportGptf> header = new List<DataHeaderReportGptf>();
            foreach (var item in dtHeader)
            {
                var dataHeader = new DataHeaderReportGptf();
                dataHeader.IDProgram = item;
                dataHeader.ProgramName = dt.Where(x => x.IDProgram == item).Select(q => q.ProgramName).FirstOrDefault();
                header.Add(dataHeader);
            }

            foreach (var item in dt)
            {
                item.TargetLastWeek = dtBeforeLastWeek.Where(x => x.IDProjectHeader == item.IDProjectHeader).Select(q => q.Target).FirstOrDefault();
                item.RealisasiLastWeek = dtBeforeLastWeek.Where(x => x.IDProjectHeader == item.IDProjectHeader).Select(q => q.Realisasi).FirstOrDefault();
                item.PencapaianLastWeek = dtBeforeLastWeek.Where(x => x.IDProjectHeader == item.IDProjectHeader).Select(q => q.Pencapaian).FirstOrDefault();
            }

            var headers = new HeaderReportGptf
            {
                Month = ecp.Month,
                Year = ecp.Year,
                Week = ecp.Week
            };

            var laporangGptfPerMinggu = new LaporanPerMingguGptfModel { 
                HeaderReport = headers,
                HeaderDataReport = header,
                ListDataReport = dt
            };
            return laporangGptfPerMinggu;
        }

        [HttpPost]
        [Route("api/EvaluasiCapaianProyekPDF/GenerateLaporanEvaluasiCapaianByKpi")]
        public PDFLaporanBulananModel GenerateLaporanEvaluasiCapaianByKPI([FromBody] EvaluasiCapaianProyekModel ecp)
        {
            Report r = new Report();

            DataSet ds = r.Get_PDF_EvaluasiCapaianProyek_BroupByKpi(ecp.Month, ecp.Year, ecp.IsTransformasi, ecp.IDDirektorat, ecp.Week);
            DataTable dt1 = ds.Tables[0];
            DataTable dt2 = ds.Tables[1];

            PDFLaporanBulananModel PDFLaporanBulananModel = new PDFLaporanBulananModel();
            HeaderReport HeaderReport = new HeaderReport();
            List<DataReport> ListDataReportModel = new List<DataReport>();

            foreach (DataRow dr in dt1.Rows)
            {
                HeaderReport.Bulan = dr["Bulan"].ToString();
                HeaderReport.Year = dr["Year"].ToString();
                HeaderReport.IsTransformasi = dr["IsTransformasi"].ToString();
                HeaderReport.Direktorat = dr["Direktorat"].ToString();
            }

            PDFLaporanBulananModel.HeaderReport = HeaderReport;

            foreach (DataRow dr in dt2.Rows)
            {
                DataReport DataReport = new DataReport();

                DataReport.Tipe = dr["Tipe"].ToString();

                if (dr["IDStrategicObjective"].ToString() != "") DataReport.IDStrategicObjective = Convert.ToInt32(dr["IDStrategicObjective"]);

                if (dr["IDProgram"].ToString() != "") DataReport.IDProgram = Convert.ToInt32(dr["IDProgram"]);
                else DataReport.IDProgram = null;

                if (dr["IDProjectHeader"].ToString() != "") DataReport.IDProjectHeader = Convert.ToInt32(dr["IDProjectHeader"]);
                else DataReport.IDProjectHeader = null;

                if (dr["IDDirektorat"].ToString() != "") DataReport.IDDirektorat = Convert.ToInt32(dr["IDDirektorat"]);
                else DataReport.IDDirektorat = null;

                DataReport.DirektoratName = dr["DirektoratName"].ToString();
                DataReport.StrategicObjective = dr["StrategicObjectiveName"].ToString();
                DataReport.ProgramName = dr["ProgramName"].ToString();
                DataReport.ProjectName = dr["ProjectName"].ToString();
                DataReport.Name = dr["Name"].ToString();
                DataReport.PIC = dr["PIC"].ToString();
                DataReport.Waktu = dr["Waktu"].ToString();
                DataReport.Anggaran = dr["Anggaran"].ToString();
                DataReport.Target = dr["Target"].ToString();
                DataReport.Realisasi = dr["Realisasi"].ToString();
                DataReport.RealisasiPencapaian = dr["RealisasiPencapaian"].ToString();
                DataReport.Planning = dr["Planning"].ToString();
                DataReport.RealisasiAnggaran = dr["RealisasiAnggaran"].ToString();
                DataReport.RealisasiKomit = dr["RealisasiKomit"].ToString();
                DataReport.Tren = dr["Tren"].ToString();

                if (dr["IsTransformasi"].ToString() != "") DataReport.IsTransformasi = Convert.ToInt32(dr["IsTransformasi"]);
                else DataReport.IsTransformasi = null;

                ListDataReportModel.Add(DataReport);
            }

            PDFLaporanBulananModel.ListDataReport = ListDataReportModel;

            return PDFLaporanBulananModel;
        }

        [HttpPost]
        [Route("api/EvaluasiCapaianProyekPDF/GenerateLaporanEvaluasiCapaianByCategory")]
        public PDFLaporanBulananModel GenerateLaporanEvaluasiCapaianByCategory([FromBody] EvaluasiCapaianProyekModel ecp)
        {
            Report r = new Report();

            DataSet ds = r.Get_PDF_EvaluasiCapaianProyek_BroupByKategori(ecp.Month, ecp.Year, ecp.IsTransformasi, ecp.IDDirektorat, ecp.Week);
            DataTable dt1 = ds.Tables[0];
            DataTable dt2 = ds.Tables[1];

            PDFLaporanBulananModel PDFLaporanBulananModel = new PDFLaporanBulananModel();
            HeaderReport HeaderReport = new HeaderReport();
            List<DataReport> ListDataReportModel = new List<DataReport>();

            foreach (DataRow dr in dt1.Rows)
            {
                HeaderReport.Bulan = dr["Bulan"].ToString();
                HeaderReport.Year = dr["Year"].ToString();
                HeaderReport.IsTransformasi = dr["IsTransformasi"].ToString();
                HeaderReport.Direktorat = dr["Direktorat"].ToString();
            }

            PDFLaporanBulananModel.HeaderReport = HeaderReport;

            foreach (DataRow dr in dt2.Rows)
            {
                DataReport DataReport = new DataReport();

                DataReport.Tipe = dr["Tipe"].ToString();

                if (dr["IDStrategicObjective"].ToString() != "") DataReport.IDStrategicObjective = Convert.ToInt32(dr["IDStrategicObjective"]);

                if (dr["IDProgram"].ToString() != "") DataReport.IDProgram = Convert.ToInt32(dr["IDProgram"]);
                else DataReport.IDProgram = null;

                if (dr["IDProjectHeader"].ToString() != "") DataReport.IDProjectHeader = Convert.ToInt32(dr["IDProjectHeader"]);
                else DataReport.IDProjectHeader = null;

                if (dr["IDDirektorat"].ToString() != "") DataReport.IDDirektorat = Convert.ToInt32(dr["IDDirektorat"]);
                else DataReport.IDDirektorat = null;

                DataReport.DirektoratName = dr["DirektoratName"].ToString();
                DataReport.StrategicObjective = dr["StrategicObjectiveName"].ToString();
                DataReport.ProgramName = dr["ProgramName"].ToString();
                DataReport.ProjectName = dr["ProjectName"].ToString();
                DataReport.Name = dr["Name"].ToString();
                DataReport.PIC = dr["PIC"].ToString();
                DataReport.Waktu = dr["Waktu"].ToString();
                DataReport.Anggaran = dr["Anggaran"].ToString();
                DataReport.Target = dr["Target"].ToString();
                DataReport.Realisasi = dr["Realisasi"].ToString();
                DataReport.RealisasiPencapaian = dr["RealisasiPencapaian"].ToString();
                DataReport.Planning = dr["Planning"].ToString();
                DataReport.RealisasiAnggaran = dr["RealisasiAnggaran"].ToString();
                DataReport.RealisasiKomit = dr["RealisasiKomit"].ToString();
                DataReport.Tren = dr["Tren"].ToString();

                if (dr["IsTransformasi"].ToString() != "") DataReport.IsTransformasi = Convert.ToInt32(dr["IsTransformasi"]);
                else DataReport.IsTransformasi = null;

                ListDataReportModel.Add(DataReport);
            }

            PDFLaporanBulananModel.ListDataReport = ListDataReportModel;

            return PDFLaporanBulananModel;
        }

        public PDFLaporanBulananModel Post([FromBody]EvaluasiCapaianProyekModel ecp)
        {
            Report r = new Report();
            
            DataSet ds = r.Get_PDF_EvaluasiCapaianProyek(ecp.Month, ecp.Year, ecp.IsTransformasi, ecp.IDDirektorat, ecp.Week);
            DataTable dt1 = ds.Tables[0];
            DataTable dt2 = ds.Tables[1];

            PDFLaporanBulananModel PDFLaporanBulananModel = new PDFLaporanBulananModel();
            HeaderReport HeaderReport = new HeaderReport();
            List<DataReport> ListDataReportModel = new List<DataReport>();

            foreach(DataRow dr in dt1.Rows)
            {
                HeaderReport.Bulan = dr["Bulan"].ToString();
                HeaderReport.Year = dr["Year"].ToString();
                HeaderReport.IsTransformasi = dr["IsTransformasi"].ToString();
                HeaderReport.Direktorat = dr["Direktorat"].ToString();
            }

            PDFLaporanBulananModel.HeaderReport = HeaderReport;

            foreach(DataRow dr in dt2.Rows)
            {
                DataReport DataReport = new DataReport();

                DataReport.Tipe = dr["Tipe"].ToString();

                if(dr["IDStrategicObjective"].ToString() != "") DataReport.IDStrategicObjective = Convert.ToInt32(dr["IDStrategicObjective"]);

                if (dr["IDProgram"].ToString() != "") DataReport.IDProgram = Convert.ToInt32(dr["IDProgram"]);
                else DataReport.IDProgram = null;

                if (dr["IDProjectHeader"].ToString() != "") DataReport.IDProjectHeader = Convert.ToInt32(dr["IDProjectHeader"]);
                else DataReport.IDProjectHeader = null;

                if (dr["IDDirektorat"].ToString() != "") DataReport.IDDirektorat = Convert.ToInt32(dr["IDDirektorat"]);
                else DataReport.IDDirektorat = null;
                
                DataReport.DirektoratName = dr["DirektoratName"].ToString();
                DataReport.StrategicObjective = dr["StrategicObjectiveName"].ToString();
                DataReport.ProgramName = dr["ProgramName"].ToString();
                DataReport.ProjectName = dr["ProjectName"].ToString();
                DataReport.Name = dr["Name"].ToString();
                DataReport.PIC = dr["PIC"].ToString();
                DataReport.Waktu = dr["Waktu"].ToString();
                DataReport.Anggaran = dr["Anggaran"].ToString();
                DataReport.Target = dr["Target"].ToString();
                DataReport.Realisasi = dr["Realisasi"].ToString();
                DataReport.RealisasiPencapaian = dr["RealisasiPencapaian"].ToString();
                DataReport.Planning = dr["Planning"].ToString();
                DataReport.RealisasiAnggaran = dr["RealisasiAnggaran"].ToString();
                DataReport.RealisasiKomit = dr["RealisasiKomit"].ToString();
                DataReport.Tren = dr["Tren"].ToString();
                DataReport.TrenCurrent = dr["TrenCurrent"].ToString();

                if (dr["IsTransformasi"].ToString() != "") DataReport.IsTransformasi = Convert.ToInt32(dr["IsTransformasi"]);
                else DataReport.IsTransformasi = null;

                ListDataReportModel.Add(DataReport);
            }

            PDFLaporanBulananModel.ListDataReport = ListDataReportModel;

            return PDFLaporanBulananModel;
        }

        public PDFLaporanBulananModel Put([FromBody]EvaluasiCapaianProyekModel ecp)
        {
            Report r = new Report();

            DataSet ds = r.Get_PDF_EvaluasiCapaianProyek_BroupByDirektorat(ecp.Month, ecp.Year, ecp.IsTransformasi, ecp.IDDirektorat, ecp.Week);
            DataTable dt1 = ds.Tables[0];
            DataTable dt2 = ds.Tables[1];

            PDFLaporanBulananModel PDFLaporanBulananModel = new PDFLaporanBulananModel();
            HeaderReport HeaderReport = new HeaderReport();
            List<DataReport> ListDataReportModel = new List<DataReport>();

            foreach (DataRow dr in dt1.Rows)
            {
                HeaderReport.Bulan = dr["Bulan"].ToString();
                HeaderReport.Year = dr["Year"].ToString();
                HeaderReport.IsTransformasi = dr["IsTransformasi"].ToString();
                HeaderReport.Direktorat = dr["Direktorat"].ToString();
            }

            PDFLaporanBulananModel.HeaderReport = HeaderReport;

            foreach (DataRow dr in dt2.Rows)
            {
                DataReport DataReport = new DataReport();

                DataReport.Tipe = dr["Tipe"].ToString();

                if (dr["IDStrategicObjective"].ToString() != "") DataReport.IDStrategicObjective = Convert.ToInt32(dr["IDStrategicObjective"]);

                if (dr["IDProgram"].ToString() != "") DataReport.IDProgram = Convert.ToInt32(dr["IDProgram"]);
                else DataReport.IDProgram = null;

                if (dr["IDProjectHeader"].ToString() != "") DataReport.IDProjectHeader = Convert.ToInt32(dr["IDProjectHeader"]);
                else DataReport.IDProjectHeader = null;

                if (dr["IDDirektorat"].ToString() != "") DataReport.IDDirektorat = Convert.ToInt32(dr["IDDirektorat"]);
                else DataReport.IDDirektorat = null;
                
                DataReport.DirektoratName = dr["DirektoratName"].ToString();
                DataReport.StrategicObjective = dr["StrategicObjectiveName"].ToString();
                DataReport.ProgramName = dr["ProgramName"].ToString();
                DataReport.ProjectName = dr["ProjectName"].ToString();
                DataReport.Name = dr["Name"].ToString();
                DataReport.PIC = dr["PIC"].ToString();
                DataReport.Waktu = dr["Waktu"].ToString();
                DataReport.Anggaran = dr["Anggaran"].ToString();
                DataReport.Target = dr["Target"].ToString();
                DataReport.Realisasi = dr["Realisasi"].ToString();
                DataReport.RealisasiPencapaian = dr["RealisasiPencapaian"].ToString();
                DataReport.Planning = dr["Planning"].ToString();
                DataReport.RealisasiAnggaran = dr["RealisasiAnggaran"].ToString();
                DataReport.RealisasiKomit = dr["RealisasiKomit"].ToString();
                DataReport.Tren = dr["Tren"].ToString();

                if (dr["IsTransformasi"].ToString() != "") DataReport.IsTransformasi = Convert.ToInt32(dr["IsTransformasi"]);
                else DataReport.IsTransformasi = null;

                ListDataReportModel.Add(DataReport);
            }

            PDFLaporanBulananModel.ListDataReport = ListDataReportModel;

            return PDFLaporanBulananModel;
        }

    }
}
