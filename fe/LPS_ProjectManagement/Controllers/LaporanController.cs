using java.io;
using LPS_ProjectManagement.Helper;
using LPS_ProjectManagement.Models;
using LPS_ProjectManagement.Models.DashboardModels.DashboardProject;
using LPS_ProjectManagement.Models.MasterDataModels;
using LPS_ProjectManagement.Models.ReportModels;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace LPS_ProjectManagement.Controllers
{
    public class LaporanController : Controller
    {
        GlobalHelper gh = new GlobalHelper();

        // GET: Laporan
        #region Laporan Capaian Evaluasi Proyeks

        public ActionResult LaporanTransformasi()
        {
            if (Session["PersonalNumber"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterDirektorat";
                Uri baseAddress = new Uri(url);
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.GetAsync(baseAddress.ToString()).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                List<DirektoratModel> ListProgram = JsonConvert.DeserializeObject<List<DirektoratModel>>(result);

                DashboardProjectHeaderModel data = new DashboardProjectHeaderModel();
                data.Day = 1;
                data.Year = DateTime.Now.Year.ToString();
                data.Month = DateTime.Now.Month;
                client = new HttpClient();
                url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardProjectHeader";
                baseAddress = new Uri(url);
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                response = client.PostAsJsonAsync(baseAddress.ToString(), data).Result;
                result = response.Content.ReadAsStringAsync().Result;
                DashboardProjectHeaderModel DashboardProject = JsonConvert.DeserializeObject<DashboardProjectHeaderModel>(result);
                var ListMonth = GlobalHelper.ListDropDowMonth();
                LaporanInitModel initModel= new LaporanInitModel
                {
                    ListDirektoratModel = ListProgram,
                    DashboardProjectHeaderModel = DashboardProject,
                    ListMonth = ListMonth
                };
                return View(initModel);
            }
        }
        
        public ActionResult LaporanTransformasiDetail()
        {
            try
            {
                EvaluasiCapaianProyekModel ecpm = new EvaluasiCapaianProyekModel();

                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EvaluasiCapaianProyek";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;
                //phm.IDProjectHeader = IDProjectHeader;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), ecpm).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                List<EvaluasiCapaianProyekModel> ListEvaluasiCapaianProyek = JsonConvert.DeserializeObject<List<EvaluasiCapaianProyekModel>>(result);

                return View(ListEvaluasiCapaianProyek);
            }
            catch (Exception ex)
            {
                List<EvaluasiCapaianProyekModel> ListEvaluasiCapaianProyek = new List<EvaluasiCapaianProyekModel>();
                return View(ListEvaluasiCapaianProyek);//throw ex;
            }
        }

        public ActionResult LaporanEvaluasi(EvaluasiCapaianProyekModel ecpm)
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EvaluasiCapaianProyek";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;
                //phm.IDProjectHeader = IDProjectHeader;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), ecpm).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                List<EvaluasiCapaianProyekModel> ListEvaluasiCapaianProyek = JsonConvert.DeserializeObject<List<EvaluasiCapaianProyekModel>>(result);

                return Json(new { Result = "Success", Data = ListEvaluasiCapaianProyek }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                List<EvaluasiCapaianProyekModel> ListEvaluasiCapaianProyek = new List<EvaluasiCapaianProyekModel>();
                return Json(new { Result = "Failed", Message = "Terjadi kesalahan pada sistem, mohon capture halaman ini dan kirimkan ke IT Help Desk. Error Message :" + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ListLaporanEvaluasi(ListEvaluasiCapaianProyekModel obj)
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EvaluasiCapaianProyek";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PutAsJsonAsync(baseAddress.ToString(), obj).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                List<ListEvaluasiCapaianProyekModel> ListEvaluasiCapaianProyek = JsonConvert.DeserializeObject<List<ListEvaluasiCapaianProyekModel>>(result);

                return Json(new { Result = "Success", Data = ListEvaluasiCapaianProyek }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                List<ListEvaluasiCapaianProyekModel> ListEvaluasiCapaianProyek = new List<ListEvaluasiCapaianProyekModel>();
                return Json(new { Result = "Failed", Data = ListEvaluasiCapaianProyek }, JsonRequestBehavior.AllowGet);//throw ex;
            }
        }

        public ActionResult ExportToPDF(Boolean? IsTransformasi, int Month, string Year, int IDDirektorat,int? Week)
        {
            try
            {
                EvaluasiCapaianProyekModel ecpm = new EvaluasiCapaianProyekModel();
                ecpm.IsTransformasi = IsTransformasi;
                ecpm.Month = Month;
                ecpm.Year = Year;
                ecpm.IDDirektorat = IDDirektorat;
                ecpm.Week = Week;
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EvaluasiCapaianProyekPDF";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), ecpm).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                
                PDFLaporanBulananModel ds = JsonConvert.DeserializeObject<PDFLaporanBulananModel>(result);
                
                return View(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult ExportToPDFGroupByDirektorat(Boolean? IsTransformasi, int Month, string Year, int IDDirektorat,int? Week)
        {
            try
            {
                EvaluasiCapaianProyekModel ecpm = new EvaluasiCapaianProyekModel();
                ecpm.IsTransformasi = IsTransformasi;
                ecpm.Month = Month;
                ecpm.Year = Year;
                ecpm.IDDirektorat = IDDirektorat;
                ecpm.Week = Week;
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EvaluasiCapaianProyekPDF";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;
                //phm.IDProjectHeader = IDProjectHeader;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PutAsJsonAsync(baseAddress.ToString(), ecpm).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                //List<EvaluasiCapaianProyekModel> ListEvaluasiCapaianProyek = JsonConvert.DeserializeObject<List<EvaluasiCapaianProyekModel>>(result);
                PDFLaporanBulananModel ds = JsonConvert.DeserializeObject<PDFLaporanBulananModel>(result);

                //return Json(new { Result = "Success", Data = ListEvaluasiCapaianProyek }, JsonRequestBehavior.AllowGet);
                //return View(ListEvaluasiCapaianProyek);
                return View(ds);
            }
            catch (Exception ex)
            {
                List<EvaluasiCapaianProyekModel> ListEvaluasiCapaianProyek = new List<EvaluasiCapaianProyekModel>();
                //return Json(new { Result = "Failed", Data = ListEvaluasiCapaianProyek }, JsonRequestBehavior.AllowGet);//throw ex;
                return View(ListEvaluasiCapaianProyek);
            }
        }

        public ActionResult PrintCapaianEvaluasi(Boolean? IsTransformasi, int Month, string Year, int? IDDirektorat,int? Week/*EvaluasiCapaianProyekModel ecpm*/)
        {
            try
            {
                string footer = "--footer-center \"Page: [page] / [toPage]\" --footer-font-size \"9\" --footer-spacing 5 --footer-font-name \"Book Antiqua\"";
                return new ActionAsPdf(
                    "ExportToPDF", new { IsTransformasi = IsTransformasi, Month = Month, Year = Year, IDDirektorat = IDDirektorat, Week = Week }
                    )
                {
                    FileName = "Laporan Evaluasi Capaian Proyek " + Month + "-" + Year + ".pdf",
                    PageSize = Rotativa.Options.Size.A4,
                    PageOrientation = Rotativa.Options.Orientation.Landscape,
                    PageMargins = new Rotativa.Options.Margins(15, 10, 15, 10),
                    CustomSwitches = footer
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult PrintCapaianEvaluasiGroupByDirektorat(Boolean? IsTransformasi, int Month, string Year, int? IDDirektorat,int? Week/*EvaluasiCapaianProyekModel ecpm*/)
        {
            try
            {
                string footer = "--footer-center \"Page: [page] / [toPage]\" --footer-font-size \"9\" --footer-spacing 5 --footer-font-name \"Book Antiqua\"";
                return new ActionAsPdf(
                    "ExportToPDFGroupByDirektorat", new { IsTransformasi = IsTransformasi, Month = Month, Year = Year, IDDirektorat = IDDirektorat, Week = Week }
                    )
                {
                    FileName = "Laporan Evaluasi Perdirektorat " + Month + "-" + Year + ".pdf",
                    PageSize = Rotativa.Options.Size.A4,
                    PageOrientation = Rotativa.Options.Orientation.Landscape,
                    PageMargins = new Rotativa.Options.Margins(15, 10, 15, 10),
                    CustomSwitches = footer
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult ExportExcelCapaianEvaluasi(Boolean? IsTransformasi, int Month, string Year, int IDDirektorat, int? Week)
        {

            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    EvaluasiCapaianProyekModel ecpm = new EvaluasiCapaianProyekModel();
                    ecpm.IsTransformasi = IsTransformasi;
                    ecpm.Month = Month;
                    ecpm.Year = Year;
                    ecpm.IDDirektorat = IDDirektorat;
                    ecpm.Week = Week;
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EvaluasiCapaianProyekPDF";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), ecpm).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    PDFLaporanBulananModel ds = JsonConvert.DeserializeObject<PDFLaporanBulananModel>(result);

                    return View(ds);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult ExportExcelCapaianEvaluasiDirektorat(Boolean? IsTransformasi, int Month, string Year, int IDDirektorat, int? Week)
        {

            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    EvaluasiCapaianProyekModel ecpm = new EvaluasiCapaianProyekModel();
                    ecpm.IsTransformasi = IsTransformasi;
                    ecpm.Month = Month;
                    ecpm.Year = Year;
                    ecpm.IDDirektorat = IDDirektorat;
                    ecpm.Week = Week;
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EvaluasiCapaianProyekPDF";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PutAsJsonAsync(baseAddress.ToString(), ecpm).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    PDFLaporanBulananModel ds = JsonConvert.DeserializeObject<PDFLaporanBulananModel>(result);

                    return View(ds);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult ExportExcelCapaianEvaluasiKpi(Boolean? IsTransformasi, int Month, string Year, int IDDirektorat, int? Week)
        {

            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    EvaluasiCapaianProyekModel ecpm = new EvaluasiCapaianProyekModel();
                    ecpm.IsTransformasi = IsTransformasi;
                    ecpm.Month = Month;
                    ecpm.Year = Year;
                    ecpm.IDDirektorat = IDDirektorat;
                    ecpm.Week = Week;
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EvaluasiCapaianProyekPDF/GenerateLaporanEvaluasiCapaianByKpi";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), ecpm).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    PDFLaporanBulananModel ds = JsonConvert.DeserializeObject<PDFLaporanBulananModel>(result);

                    return View(ds);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult ExportExcelCapaianEvaluasiKategori(Boolean? IsTransformasi, int Month, string Year, int IDDirektorat, int? Week)
        {

            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    EvaluasiCapaianProyekModel ecpm = new EvaluasiCapaianProyekModel();
                    ecpm.IsTransformasi = IsTransformasi;
                    ecpm.Month = Month;
                    ecpm.Year = Year;
                    ecpm.IDDirektorat = IDDirektorat;
                    ecpm.Week = Week;
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EvaluasiCapaianProyekPDF/GenerateLaporanEvaluasiCapaianByCategory";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), ecpm).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    PDFLaporanBulananModel ds = JsonConvert.DeserializeObject<PDFLaporanBulananModel>(result);

                    return View(ds);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult ExportExcelReportGptfPerWeek(int Month, string Year, int? Week)
        {

            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    EvaluasiCapaianProyekModel ecpm = new EvaluasiCapaianProyekModel();
                    ecpm.Month = Month;
                    ecpm.Year = Year;
                    ecpm.Week = Week;
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EvaluasiCapaianProyekPDF/GenerateLaporanGptfPerWeek";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), ecpm).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    LaporanPerMingguGptfModel ds = JsonConvert.DeserializeObject<LaporanPerMingguGptfModel>(result);

                    return View(ds);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult PrintCapaianEvaluasiGroupByKpi(Boolean? IsTransformasi, int Month, string Year, int? IDDirektorat, int? Week/*EvaluasiCapaianProyekModel ecpm*/)
        {
            try
            {
                string footer = "--footer-center \"Page: [page] / [toPage]\" --footer-font-size \"9\" --footer-spacing 5 --footer-font-name \"Book Antiqua\"";
                return new ActionAsPdf(
                    "ExportToPDFGroupByKpi", new { IsTransformasi = IsTransformasi, Month = Month, Year = Year, IDDirektorat = IDDirektorat, Week = Week }
                    )
                {
                    FileName = "Laporan Evaluasi Per KPI " + Month + "-" + Year + ".pdf",
                    PageSize = Rotativa.Options.Size.A4,
                    PageOrientation = Rotativa.Options.Orientation.Landscape,
                    PageMargins = new Rotativa.Options.Margins(15, 10, 15, 10),
                    CustomSwitches = footer
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult ExportToPDFGroupByKpi(Boolean? IsTransformasi, int Month, string Year, int IDDirektorat, int? Week)
        {
            try
            {
                EvaluasiCapaianProyekModel ecpm = new EvaluasiCapaianProyekModel();
                ecpm.IsTransformasi = IsTransformasi;
                ecpm.Month = Month;
                ecpm.Year = Year;
                ecpm.IDDirektorat = IDDirektorat;
                ecpm.Week = Week;
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EvaluasiCapaianProyekPDF/GenerateLaporanEvaluasiCapaianByKpi";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), ecpm).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                PDFLaporanBulananModel ds = JsonConvert.DeserializeObject<PDFLaporanBulananModel>(result);

                return View(ds);
            }
            catch (Exception ex)
            {
                List<EvaluasiCapaianProyekModel> ListEvaluasiCapaianProyek = new List<EvaluasiCapaianProyekModel>();
                return View(ListEvaluasiCapaianProyek);
            }
        }

        public ActionResult PrintCapaianEvaluasiGroupByCategory(Boolean? IsTransformasi, int Month, string Year, int? IDDirektorat, int? Week/*EvaluasiCapaianProyekModel ecpm*/)
        {
            try
            {
                string footer = "--footer-center \"Page: [page] / [toPage]\" --footer-font-size \"9\" --footer-spacing 5 --footer-font-name \"Book Antiqua\"";
                return new ActionAsPdf(
                    "ExportToPDFGroupByCategory", new { IsTransformasi = IsTransformasi, Month = Month, Year = Year, IDDirektorat = IDDirektorat, Week = Week }
                    )
                {
                    FileName = "Laporan Evaluasi Per Category " + Month + "-" + Year + ".pdf",
                    PageSize = Rotativa.Options.Size.A4,
                    PageOrientation = Rotativa.Options.Orientation.Landscape,
                    PageMargins = new Rotativa.Options.Margins(15, 10, 15, 10),
                    CustomSwitches = footer
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult ExportToPDFGroupByCategory(Boolean? IsTransformasi, int Month, string Year, int IDDirektorat, int? Week)
        {
            try
            {
                EvaluasiCapaianProyekModel ecpm = new EvaluasiCapaianProyekModel();
                ecpm.IsTransformasi = IsTransformasi;
                ecpm.Month = Month;
                ecpm.Year = Year;
                ecpm.IDDirektorat = IDDirektorat;
                ecpm.Week = Week;
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EvaluasiCapaianProyekPDF/GenerateLaporanEvaluasiCapaianByCategory";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), ecpm).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                PDFLaporanBulananModel ds = JsonConvert.DeserializeObject<PDFLaporanBulananModel>(result);

                return View(ds);
            }
            catch (Exception ex)
            {
                List<EvaluasiCapaianProyekModel> ListEvaluasiCapaianProyek = new List<EvaluasiCapaianProyekModel>();
                return View(ListEvaluasiCapaianProyek);
            }
        }

        #endregion



        #region Laporan Tren Pencapaian

        public ActionResult LaporanTrenPencapaian()
        {
            if (Session["PersonalNumber"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View();
            }
        }

        public ActionResult LaporanTrenPencapaianSearch(TrenPencapaianModel TrenPencapaian)
        {
            if (Session["PersonalNumber"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                try
                {
                    List<TrenPencapaianModel> ListTrenPencapaian = new List<TrenPencapaianModel>();
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "TrenPencapaian";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), TrenPencapaian).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    ListTrenPencapaian = JsonConvert.DeserializeObject<List<TrenPencapaianModel>>(result);

                    return Json(new { Result = "Success", Data = ListTrenPencapaian }, JsonRequestBehavior.AllowGet);
                }
                catch(Exception ex)
                {
                    return Json(new { Result = "Error", Message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        public ActionResult DownloadTrenPencapaian(int Year, int Month)
        {
            if (Session["PersonalNumber"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                try
                {
                    TrenPencapaianModel TrenPencapaian = new TrenPencapaianModel();
                    TrenPencapaian.Year = Year;
                    TrenPencapaian.Month = Month;

                    List<TrenPencapaianModel> ListTrenPencapaian = new List<TrenPencapaianModel>();
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "TrenPencapaian";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), TrenPencapaian).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    ListTrenPencapaian = JsonConvert.DeserializeObject<List<TrenPencapaianModel>>(result);

                    return View(ListTrenPencapaian);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        #endregion

        #region Laporan Summary

        public ActionResult LaporanSumaryPelaksanaanProyek()
        {
            if (Session["PersonalNumber"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View();
            }
        }

        public ActionResult LaporanSumaryPelaksanaanProyekSearch(SummaryModel sm)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "Summary";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    //phm.IDProjectHeader = IDProjectHeader;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), sm).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<SummaryModel> ListSummary = JsonConvert.DeserializeObject<List<SummaryModel>>(result);

                    return Json(new { Result = "Success", Data = ListSummary }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                List<SummaryModel> ListSummary = new List<SummaryModel>();
                return Json(new { Result = "Failed", Data = ListSummary }, JsonRequestBehavior.AllowGet);//throw ex;
            }
        }

        public ActionResult LaporanCapaian(int week , int month , int year ,int tipe)
        {
            try {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    PencapainParam LP = new PencapainParam();

                    LP.jenisapi = "Trans";
                    LP.week = week;
                    LP.year = year;
                    LP.month = month;


                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "LaporanCapaian";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    //phm.IDProjectHeader = IDProjectHeader;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), LP).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    LaporanPencapaian laporanPencapaian = JsonConvert.DeserializeObject<LaporanPencapaian>(result);

                    return View(laporanPencapaian);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult LaporanCapaianSO(int week, int month, int year)
        {
            try
            {

                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {

                    PencapainParam LP = new PencapainParam();

                    LP.jenisapi = "SO";
                    LP.week = week;
                    LP.year = year;
                    LP.month = month;
                    
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "LaporanCapaian";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), LP).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    LaporanPencapaian laporanPencapaian = JsonConvert.DeserializeObject<LaporanPencapaian>(result);

                    return View(laporanPencapaian);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult LaporanCapaianDirektorat(int week, int month, int year)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {

                    PencapainParam LP = new PencapainParam();

                    LP.jenisapi = "Direktorat";
                    LP.week = week;
                    LP.year = year;
                    LP.month = month;


                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "LaporanCapaian";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    //phm.IDProjectHeader = IDProjectHeader;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), LP).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    LaporanPencapaian laporanPencapaian = JsonConvert.DeserializeObject<LaporanPencapaian>(result);

                    return View(laporanPencapaian);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult LaporanCapaianProyek()
        {
            return View();
        }

        public ActionResult LaporanCapaianProyekSearch(CapaianProyekModel cpm)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "CapaianProyek";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    //phm.IDProjectHeader = IDProjectHeader;
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), cpm).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<CapaianProyekModel> ListCapaianProyek = JsonConvert.DeserializeObject<List<CapaianProyekModel>>(result);

                    return Json(new { Result = "Success", Data = ListCapaianProyek }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                List<CapaianProyekModel> ListCapaianProyek = new List<CapaianProyekModel>();
                return Json(new { Result = "Failed", Data = ListCapaianProyek }, JsonRequestBehavior.AllowGet);//throw ex;
            }
        }

        public ActionResult LaporanProgramPrintint (int week , int month, int year,int tipe)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    PencapainParam LP = new PencapainParam();

                    LP.jenisapi = "Trans";
                    LP.week = week;
                    LP.year = year;
                    LP.month = month;


                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "LaporanCapaian";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    //phm.IDProjectHeader = IDProjectHeader;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), LP).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    LaporanPencapaian laporanPencapaian = JsonConvert.DeserializeObject<LaporanPencapaian>(result);

                    return View(laporanPencapaian);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #region Laporan All Data

        public ActionResult LaporanAllData()
        {
            if (Session["PersonalNumber"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                DashboardProjectHeaderModel data = new DashboardProjectHeaderModel();
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardProjectHeader";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), data).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                DashboardProjectHeaderModel DashboardProject = JsonConvert.DeserializeObject<DashboardProjectHeaderModel>(result);

                client = new HttpClient();
                url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DropDownMasterStatus";
                baseAddress = new Uri(url);
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                response = client.PostAsJsonAsync(baseAddress.ToString(), string.Empty).Result;
                result = response.Content.ReadAsStringAsync().Result;
                List<DropDownMasterStatusModel> ListDdl = JsonConvert.DeserializeObject<List<DropDownMasterStatusModel>>(result);

                ViewBag.ListDdl = ListDdl;

                return View(DashboardProject);
            }
        }

        public ActionResult LaporanAllDataSearch(AllDataRowModel obj)
        {
            try
            {
                List<AllDataRowModel> ListData = new List<AllDataRowModel>();
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "AllDataRow";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), obj).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                System.Data.DataTable table = JsonConvert.DeserializeObject<System.Data.DataTable>(result);

                int Row = 0;
                foreach (DataRow dr in table.Rows)
                {
                    Row = Row + 1;
                    AllDataRowModel data = new AllDataRowModel();

                    data.No = Row.ToString();
                    data.KPICode = dr["KPICode"].ToString();
                    data.StrategicObjectiveCode = dr["StrategicObjectiveCode"].ToString();
                    data.StrategicObjectiveName = dr["StrategicObjectiveName"].ToString();
                    data.ProgramNo = dr["ProgramNo"].ToString();
                    data.ProgramName = dr["ProgramName"].ToString();
                    data.DepartmentCode = dr["DepartmentCode"].ToString();
                    data.NamaProjectManager = dr["NamaProjectManager"].ToString();
                    data.ProjectNo = dr["ProjectNo"].ToString();
                    data.ProjectName = dr["ProjectName"].ToString();

                    if (dr["IsTransformasi"].ToString() == "True") data.IsTransformasi = "Transformasi";
                    else data.IsTransformasi = "Non Transformasi";

                    data.StartDate = dr["StartDate"].ToString();
                    data.EndDate = dr["EndDate"].ToString();

                    data.Target = dr["Target"].ToString();
                    data.Realisasi = dr["Realisasi"].ToString();

                    data.PlanPencapaian = dr["PlanPencapaian"].ToString() + "%";
                    data.RealisasiPencapaian = dr["RealisasiPencapaian"].ToString() + "%";
                    data.Pencapaian = dr["Pencapaian"].ToString() + "%";
                    data.Kendala = dr["Kendala"].ToString();
                    data.RencanaAksi = dr["RencanaAksi"].ToString();
                    data.Anggaran = gh.ToRupiah(dr["Anggaran"].ToString());
                    data.KomitAnggaran = gh.ToRupiah(dr["KomitAnggaran"].ToString());
                    data.RealisasiAnggaran = gh.ToRupiah(dr["RealisasiAnggaran"].ToString());

                    if (dr["Anggaran"].ToString() == "0")
                    {
                        data.PersenRealisasiAnggaran = "0%";
                    }
                    else
                    {
                        data.PersenRealisasiAnggaran = Math.Round((100 * ( Convert.ToDouble(dr["RealisasiAnggaran"]) / Convert.ToDouble(dr["Anggaran"])))).ToString() + "%";
                    }

                    data.LastUpdated = dr["LastUpdated"].ToString();
                    data.StatusProject = dr["StatusProject"].ToString();
                    data.NamaProgramManager = dr["NamaProgramManager"].ToString();
                    data.Periode = dr["Periode"].ToString();
                    data.StatusCapaian = dr["Pencapaian"].ToString();
                    data.StatusProjectHeader = dr["StatusProjectHeader"].ToString();

                    ListData.Add(data);
                }

                return Json(new { Result = "Success", Data = ListData }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Failed", Message = ex.Message.ToString() }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult ExportExcelAllDataRow(string Year, string Month, string Week, string IsTransformasi, string StatusProjectHeader)
        {
            try
            {
                AllDataRowModel obj = new AllDataRowModel();

                obj.Year = Year;
                obj.Month = Month;
                obj.Week = Week;
                obj.IsTransformasi = IsTransformasi;
                obj.StatusProjectHeader = StatusProjectHeader;
                GlobalHelper gh = new GlobalHelper();

                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "AllDataRow";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), obj).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                System.Data.DataTable table = JsonConvert.DeserializeObject<System.Data.DataTable>(result);

                System.Data.DataTable dt1 = new System.Data.DataTable();

                dt1.Columns.Add("Year");
                dt1.Columns.Add("Month");
                dt1.Columns.Add("Week");

                DataRow dr = dt1.NewRow();

                dr["Year"] = Year;
                dr["Month"] = Month;
                dr["Week"] = Week;

                dt1.Rows.Add(dr);

                DataSet ds = new DataSet();
                ds.Tables.Add(table);
                ds.Tables.Add(dt1);
                
                return View(ds);

            }
            catch (Exception ex)
            {
                
                throw ex;

            }
        }

        #endregion

        #region Laporan Mingguan

        public ActionResult LaporanMingguan()
        {
            if (Session["PersonalNumber"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                DashboardProjectHeaderModel data = new DashboardProjectHeaderModel();
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardProjectHeader";
                Uri baseAddress = new Uri(url);
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsJsonAsync(baseAddress.ToString(), data).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                DashboardProjectHeaderModel DashboardProject = JsonConvert.DeserializeObject<DashboardProjectHeaderModel>(result);

                var ListMonth = GlobalHelper.ListDropDowMonth();

                var dataDept = new DepartmentModel { IDDirektorat = 0 };
                client = new HttpClient();
                url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DetailAnggaranHeader";
                baseAddress = new Uri(url);
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                response = client.PostAsJsonAsync(baseAddress.ToString(), dataDept).Result;
                result = response.Content.ReadAsStringAsync().Result;
                List<DepartmentModel> ListDepartment = JsonConvert.DeserializeObject<List<DepartmentModel>>(result);

                var dataTime = new AllDataRowModel
                {
                    Year = DateTime.Now.Year.ToString(),
                    Month = DashboardProject.Month.ToString(),
                    Week = DashboardProject.Week.ToString()
                };
                client = new HttpClient();
                url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DropDownPMO";
                baseAddress = new Uri(url);
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                response = client.PostAsJsonAsync(baseAddress.ToString(), dataTime).Result;
                result = response.Content.ReadAsStringAsync().Result;
                List<DropDownPMOModel> ListPMO = JsonConvert.DeserializeObject<List<DropDownPMOModel>>(result);

                client = new HttpClient();
                url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DropDownOwner";
                baseAddress = new Uri(url);
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                response = client.PostAsJsonAsync(baseAddress.ToString(), dataTime).Result;
                result = response.Content.ReadAsStringAsync().Result;
                List<DropDownOwnerModel> ListOwner = JsonConvert.DeserializeObject<List<DropDownOwnerModel>>(result);

                client = new HttpClient();
                url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DropDownSponsor";
                baseAddress = new Uri(url);
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                response = client.PostAsJsonAsync(baseAddress.ToString(), dataTime).Result;
                result = response.Content.ReadAsStringAsync().Result;
                List<DropDownSponsorModel> ListSponsor = JsonConvert.DeserializeObject<List<DropDownSponsorModel>>(result);

                LaporanInitModel initModel = new LaporanInitModel
                {
                    DashboardProjectHeaderModel = DashboardProject,
                    ListMonth = ListMonth,
                    ListDepartment = ListDepartment,
                    ListPMO = ListPMO,
                    ListOwner = ListOwner,
                    ListSponsor = ListSponsor
                };

                return View(initModel);
            }
        }

        public ActionResult LaporanMingguanSearch(AllDataRowModel obj)
        {
            try
            {
                List<AllDataRowModel> ListData = new List<AllDataRowModel>();
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "LaporanMingguan";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), obj).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                System.Data.DataTable table = JsonConvert.DeserializeObject<System.Data.DataTable>(result);

                int Row = 0;
                foreach (DataRow dr in table.Rows)
                {
                    Row = Row + 1;
                    AllDataRowModel data = new AllDataRowModel();

                    data.No = Row.ToString();
                    data.KPICode = dr["KPICode"].ToString();
                    data.StrategicObjectiveCode = dr["StrategicObjectiveCode"].ToString();
                    data.StrategicObjectiveName = dr["StrategicObjectiveName"].ToString();
                    data.ProgramNo = dr["ProgramNo"].ToString();
                    data.ProgramName = dr["ProgramName"].ToString();
                    data.DepartmentCode = dr["DepartmentCode"].ToString();
                    data.NamaProjectManager = dr["NamaProjectManager"].ToString();
                    data.ProjectNo = dr["ProjectNo"].ToString();
                    data.ProjectName = dr["ProjectName"].ToString();

                    if (dr["IsTransformasi"].ToString() == "True") data.IsTransformasi = "Transformasi";
                    else data.IsTransformasi = "Non Transformasi";

                    data.StartDate = dr["StartDate"].ToString();
                    data.EndDate = dr["EndDate"].ToString();

                    data.Target = dr["Target"].ToString();
                    data.Realisasi = dr["Realisasi"].ToString();

                    data.PlanPencapaian = dr["PlanPencapaian"].ToString() + "%";
                    data.RealisasiPencapaian = dr["RealisasiPencapaian"].ToString() + "%";
                    data.Pencapaian = dr["Pencapaian"].ToString() + "%";
                    data.Kendala = dr["Kendala"].ToString();
                    data.RencanaAksi = dr["RencanaAksi"].ToString();
                    data.Anggaran = gh.ToRupiah(dr["Anggaran"].ToString());
                    data.KomitAnggaran = gh.ToRupiah(dr["KomitAnggaran"].ToString());
                    data.RealisasiAnggaran = gh.ToRupiah(dr["RealisasiAnggaran"].ToString());

                    if (dr["Anggaran"].ToString() == "0")
                    {
                        data.PersenRealisasiAnggaran = "0%";
                    }
                    else
                    {
                        data.PersenRealisasiAnggaran = Math.Round((100 * ((Convert.ToDouble(dr["KomitAnggaran"]) + Convert.ToDouble(dr["RealisasiAnggaran"])) / Convert.ToDouble(dr["Anggaran"])))).ToString() + "%";
                    }

                    data.LastUpdated = dr["LastUpdated"].ToString();
                    data.StatusProject = dr["StatusProject"].ToString();
                    data.NamaProgramManager = dr["NamaProgramManager"].ToString();
                    data.Periode = dr["Periode"].ToString();
                    data.NamaProjectOwner = dr["NamaProjectOwner"].ToString();
                    data.NamaProjectSponsor = dr["NamaProjectSponsor"].ToString();

                    ListData.Add(data);
                }

                return Json(new { Result = "Success", Data = ListData }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Failed", Message = ex.Message.ToString() }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult ExportExcelLaporanMingguan(string Year, string Month, string Week, string IsTransformasi, string DepartmentCode, string NamaProgramManager, string NamaProjectOwner, string NamaProjectSponsor)
        {
            try
            {
                AllDataRowModel obj = new AllDataRowModel();

                obj.Year = Year;
                obj.Month = Month;
                obj.Week = Week;
                obj.IsTransformasi = IsTransformasi;
                obj.DepartmentCode = DepartmentCode;
                obj.NamaProgramManager = NamaProgramManager;
                obj.NamaProjectOwner = NamaProjectOwner;
                obj.NamaProjectSponsor = NamaProjectSponsor;

                GlobalHelper gh = new GlobalHelper();

                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "LaporanMingguan";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), obj).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                System.Data.DataTable table = JsonConvert.DeserializeObject<System.Data.DataTable>(result);

                System.Data.DataTable dt1 = new System.Data.DataTable();

                dt1.Columns.Add("Year");
                dt1.Columns.Add("Month");
                dt1.Columns.Add("Week");

                DataRow dr = dt1.NewRow();

                dr["Year"] = Year;
                dr["Month"] = Month;
                dr["Week"] = Week;

                dt1.Rows.Add(dr);

                DataSet ds = new DataSet();
                ds.Tables.Add(table);
                ds.Tables.Add(dt1);

                return View(ds);

            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        public ActionResult LaporanMonitoringMingguan()
        {
            if (Session["PersonalNumber"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                DashboardProjectHeaderModel data = new DashboardProjectHeaderModel();
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardProjectHeader";
                Uri baseAddress = new Uri(url);
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsJsonAsync(baseAddress.ToString(), data).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                DashboardProjectHeaderModel DashboardProject = JsonConvert.DeserializeObject<DashboardProjectHeaderModel>(result);

                var ListMonth = GlobalHelper.ListDropDowMonth();

                var dataDept = new DepartmentModel { IDDirektorat = 0 };
                client = new HttpClient();
                url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DetailAnggaranHeader";
                baseAddress = new Uri(url);
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                response = client.PostAsJsonAsync(baseAddress.ToString(), dataDept).Result;
                result = response.Content.ReadAsStringAsync().Result;
                List<DepartmentModel> ListDepartment = JsonConvert.DeserializeObject<List<DepartmentModel>>(result);

                var dataTime = new AllDataRowModel
                {
                    Year = DateTime.Now.Year.ToString(),
                    Month = DashboardProject.Month.ToString(),
                    Week = DashboardProject.Week.ToString()
                };
                client = new HttpClient();
                url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DropDownPMO";
                baseAddress = new Uri(url);
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                response = client.PostAsJsonAsync(baseAddress.ToString(), dataTime).Result;
                result = response.Content.ReadAsStringAsync().Result;
                List<DropDownPMOModel> ListPMO = JsonConvert.DeserializeObject<List<DropDownPMOModel>>(result);

                LaporanInitModel initModel = new LaporanInitModel
                {
                    DashboardProjectHeaderModel = DashboardProject,
                    ListMonth = ListMonth,
                    ListDepartment = ListDepartment,
                    ListPMO = ListPMO
                };
                return View(initModel);
            }
        }

        public ActionResult LaporanMonitoringMingguanSearch(AllDataRowModel obj)
        {
            try
            {
                List<AllDataRowModel> ListData = new List<AllDataRowModel>();
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "LaporanMingguanMonitoring";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), obj).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                System.Data.DataTable table = JsonConvert.DeserializeObject<System.Data.DataTable>(result);

                int Row = 0;
                foreach (DataRow dr in table.Rows)
                {
                    Row = Row + 1;
                    AllDataRowModel data = new AllDataRowModel();

                    data.No = Row.ToString();
                    data.KPICode = dr["KPICode"].ToString();
                    data.StrategicObjectiveCode = dr["StrategicObjectiveCode"].ToString();
                    data.StrategicObjectiveName = dr["StrategicObjectiveName"].ToString();
                    data.ProgramNo = dr["ProgramNo"].ToString();
                    data.ProgramName = dr["ProgramName"].ToString();
                    data.DepartmentCode = dr["DepartmentCode"].ToString();
                    data.NamaProjectManager = dr["NamaProjectManager"].ToString();
                    data.ProjectNo = dr["ProjectNo"].ToString();
                    data.ProjectName = dr["ProjectName"].ToString();

                    if (dr["IsTransformasi"].ToString() == "True") data.IsTransformasi = "Transformasi";
                    else data.IsTransformasi = "Non Transformasi";

                    data.StartDate = dr["StartDate"].ToString();
                    data.EndDate = dr["EndDate"].ToString();

                    data.Target = dr["Target"].ToString();
                    data.Realisasi = dr["Realisasi"].ToString();

                    data.PlanPencapaian = dr["PlanPencapaian"].ToString() + "%";
                    data.RealisasiPencapaian = dr["RealisasiPencapaian"].ToString() + "%";
                    data.Pencapaian = dr["Pencapaian"].ToString() + "%";
                    data.Kendala = dr["Kendala"].ToString();
                    data.RencanaAksi = dr["RencanaAksi"].ToString();
                    data.Anggaran = gh.ToRupiah(dr["Anggaran"].ToString());
                    data.KomitAnggaran = gh.ToRupiah(dr["KomitAnggaran"].ToString());
                    data.RealisasiAnggaran = gh.ToRupiah(dr["RealisasiAnggaran"].ToString());

                    if (dr["Anggaran"].ToString() == "0")
                    {
                        data.PersenRealisasiAnggaran = "0%";
                    }
                    else
                    {
                        data.PersenRealisasiAnggaran = Math.Round((100 * ((Convert.ToDouble(dr["KomitAnggaran"]) + Convert.ToDouble(dr["RealisasiAnggaran"])) / Convert.ToDouble(dr["Anggaran"])))).ToString() + "%";
                    }

                    data.LastUpdated = dr["LastUpdated"].ToString();
                    data.StatusProject = dr["StatusProject"].ToString();
                    data.NamaProgramManager = dr["NamaProgramManager"].ToString();
                    data.Periode = dr["Periode"].ToString();

                    ListData.Add(data);
                }

                return Json(new { Result = "Success", Data = ListData }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Failed", Message = ex.Message.ToString() }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult ExportExcelLaporanMonitoringMingguan(string Year, string Month, string Week, string IsTransformasi, string DepartmentCode, string NamaProgramManager)
        {
            try
            {
                AllDataRowModel obj = new AllDataRowModel();

                obj.Year = Year;
                obj.Month = Month;
                obj.Week = Week;
                obj.IsTransformasi = IsTransformasi;
                obj.DepartmentCode = DepartmentCode;
                obj.NamaProgramManager = NamaProgramManager;

                GlobalHelper gh = new GlobalHelper();

                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "LaporanMingguanMonitoring";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), obj).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                System.Data.DataTable table = JsonConvert.DeserializeObject<System.Data.DataTable>(result);

                System.Data.DataTable dt1 = new System.Data.DataTable();

                dt1.Columns.Add("Year");
                dt1.Columns.Add("Month");
                dt1.Columns.Add("Week");

                DataRow dr = dt1.NewRow();

                dr["Year"] = Year;
                dr["Month"] = Month;
                dr["Week"] = Week;

                dt1.Rows.Add(dr);

                DataSet ds = new DataSet();
                ds.Tables.Add(table);
                ds.Tables.Add(dt1);

                return View(ds);

            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        #endregion

        #region Laporan Detail Anggaran

        public ActionResult LaporanDetailAnggaranView()
        {
            if (Session["PersonalNumber"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterDirektorat";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.GetAsync(baseAddress.ToString()).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                List<DirektoratModel> ListDirektoratModel = JsonConvert.DeserializeObject<List<DirektoratModel>>(result);

                return View(ListDirektoratModel);
            }
        }

        public ActionResult LaporanDetailAnggaranHeader(DepartmentModel data)
        {

            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DetailAnggaranHeader";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), data).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<DepartmentModel> ListDepartment = JsonConvert.DeserializeObject<List<DepartmentModel>>(result);

                    return Json(new { Result = "Success", Data = ListDepartment }, JsonRequestBehavior.AllowGet);
                }
            }
            catch(Exception ex)
            {
                return Json(new { Result = "Failed", Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            
        }

        public ActionResult SearchDetailAnggaranHeader(DetailAnggaranModel data)
        {

            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DetailAnggaran";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), data).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<DetailAnggaranModel> ListDetailAnggran = JsonConvert.DeserializeObject<List<DetailAnggaranModel>>(result);

                    return Json(new { Result = "Success", Data = ListDetailAnggran }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Failed", Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult ExportExcelDetailAnggaran(string Year, string Direktorat, string UnitKerja, string IDSAP)
        {

            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    DetailAnggaranModel data = new DetailAnggaranModel();
                    data.YEAR = Year;
                    data.IDDirektorat = Convert.ToInt32(Direktorat);
                    data.IDDepartment = Convert.ToInt32(UnitKerja);
                    data.IDSAP = IDSAP;

                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DetailAnggaran";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), data).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<DetailAnggaranModel> ListDetailAnggran = JsonConvert.DeserializeObject<List<DetailAnggaranModel>>(result);

                    return View(ListDetailAnggran);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        #region Laporan Kendala

        public ActionResult LaporanKendalaReport()
        {
            if (Session["PersonalNumber"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                DashboardProjectHeaderModel data = new DashboardProjectHeaderModel();
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardProjectHeader";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), data).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                DashboardProjectHeaderModel DashboardProject = JsonConvert.DeserializeObject<DashboardProjectHeaderModel>(result);

                return View(DashboardProject);
            }
        }

        public ActionResult LaporanKendala(AllDataRowModel obj)
        {
            try
            {

                Models.UserManagementModels.MultiPorpose MP = new Models.UserManagementModels.MultiPorpose();
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "ReportKendala?Year=" + obj.Year + "&Month="+ obj.Month + "&Week=" + obj.Week;
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.GetAsync(baseAddress.ToString()).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                List<LaporanKendalaModel> ListData = JsonConvert.DeserializeObject<List<LaporanKendalaModel>>(result);

                return Json(new { Result = "Success", data = ListData }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Failed", Message = ex.Message.ToString() }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult PrintKendala(string Year , string Month , string Week)
        {
            try
            {

                Models.UserManagementModels.MultiPorpose MP = new Models.UserManagementModels.MultiPorpose();
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "ReportKendala?Year=" + Year + "&Month=" + Month + "&Week=" + Week;
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.GetAsync(baseAddress.ToString()).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                List<LaporanKendalaModel> ListData = JsonConvert.DeserializeObject<List<LaporanKendalaModel>>(result);
                return View(ListData);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Lapoan GPTF
        public ActionResult LaporanGptf()
        {
            if (Session["PersonalNumber"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View();
            }
        }

        public ActionResult LaporanGptfSearch(LaporanGptfParamModel param)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "LaporanGptf";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    //phm.IDProjectHeader = IDProjectHeader;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), param).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<LaporanGptfModel> ListSummary = JsonConvert.DeserializeObject<List<LaporanGptfModel>>(result);

                    return Json(new { Result = "Success", Data = ListSummary }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                List<SummaryModel> ListSummary = new List<SummaryModel>();
                return Json(new { Result = "Failed", Data = ListSummary }, JsonRequestBehavior.AllowGet);//throw ex;
            }
        }

        public ActionResult ExportLaporanGptfExcel(LaporanGptfParamModel param)
        {

            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "LaporanGptf";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), param).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<LaporanGptfModel> laporanGptf = JsonConvert.DeserializeObject<List<LaporanGptfModel>>(result);

                    var laporanGptfView = new LaporanGptfViewModel
                    {
                        LaporanGptf = laporanGptf,
                        Param = param
                    };

                    return View(laporanGptfView);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Laporan Forecast
        public ActionResult LaporanForecast()
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    Models.UserManagementModels.MultiPorpose MP = new Models.UserManagementModels.MultiPorpose();
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "LaporanForecast/GetListProject";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    MP.ID = Session["PersonalNumber"].ToString();

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), MP).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<ProjectForecastModel> ListProject = JsonConvert.DeserializeObject<List<ProjectForecastModel>>(result);

                    return View(ListProject);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public ActionResult GenerateForecast(LaporanForecastParamModel param)
        //{
        //    try
        //    {
        //        if (Session["PersonalNumber"] == null)
        //        {
        //            return RedirectToAction("Login", "Login");
        //        }
        //        else
        //        {
        //            param.ForecastMethodName = GlobalHelper.ListForecastMethod().Where(x => x.Id == param.ForecastMethod).Select(q => q.Description).FirstOrDefault();
        //            Models.UserManagementModels.MultiPorpose MP = new Models.UserManagementModels.MultiPorpose();
        //            HttpClient client = new HttpClient();
        //            string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "LaporanForecast/GenerateForecast";
        //            Uri baseAddress = new Uri(url);

        //            client.BaseAddress = baseAddress;
        //            MP.ID = Session["PersonalNumber"].ToString();

        //            client.DefaultRequestHeaders.Accept.Clear();

        //            var response = client.PostAsJsonAsync(baseAddress.ToString(), param).Result;
        //            var result = response.Content.ReadAsStringAsync().Result;

        //            List<LaporanForecastModel> forecast = JsonConvert.DeserializeObject<List<LaporanForecastModel>>(result);
        //            var forecastViewModel = new LaporanForecastViewModel {
        //                Param = param,
        //                ForecastModel = forecast
        //            };
        //            return View(forecastViewModel);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public ActionResult GenerateForecast(LaporanForecastParamModel param)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    return View(param);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult GenerateTimeSeriesForecast(LaporanForecastParamModel param)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "LaporanForecast/GenerateForecast";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), param).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<LaporanForecastModel> forecast = JsonConvert.DeserializeObject<List<LaporanForecastModel>>(result);

                    return Json(new { Result = "Success", Data = forecast }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                List<SummaryModel> ListSummary = new List<SummaryModel>();
                return Json(new { Result = "Failed", Data = ListSummary }, JsonRequestBehavior.AllowGet);//throw ex;
            }
        }

        public ActionResult ExportLaporanForecastExcel(int ProjectHeaderId,int ForecastMethod,bool IsTransformasi,string ProjectName,string ForecastMethodName)
        {
            try
            {
                var param = new LaporanForecastParamModel
                {
                    ProjectHeaderId = ProjectHeaderId,
                    ForecastMethod = ForecastMethod,
                    IsTransformasi = IsTransformasi,
                    ProjectName = ProjectName,
                    ForecastMethodName = ForecastMethodName
                };
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "LaporanForecast/GenerateForecast";
                Uri baseAddress = new Uri(url);
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsJsonAsync(baseAddress.ToString(), param).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                List<LaporanForecastModel> forecast = JsonConvert.DeserializeObject<List<LaporanForecastModel>>(result);
                var excelResult = new LaporanForecastExcelModel { 
                    LaporanForecast = forecast,
                    LaporanLaporanForecastParam = param
                };
                return View(excelResult);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Dropdown list

        public ActionResult DropdownlistPMO(AllDataRowModel data)
        {

            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DropDownPMO";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), data).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<DropDownPMOModel> ListDepartment = JsonConvert.DeserializeObject<List<DropDownPMOModel>>(result);

                    return Json(new { Result = "Success", Data = ListDepartment }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Failed", Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult DropdownlistOwner(AllDataRowModel data)
        {

            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DropDownOwner";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), data).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<DropDownOwnerModel> ListDepartment = JsonConvert.DeserializeObject<List<DropDownOwnerModel>>(result);

                    return Json(new { Result = "Success", Data = ListDepartment }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Failed", Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult DropdownlistSponsor(AllDataRowModel data)
        {

            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DropDownSponsor";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), data).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<DropDownSponsorModel> ListDepartment = JsonConvert.DeserializeObject<List<DropDownSponsorModel>>(result);

                    return Json(new { Result = "Success", Data = ListDepartment }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Failed", Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        #endregion

        public ActionResult LaporanSumaryPenyampaian()
        {
            if (Session["PersonalNumber"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View();
            }
        }

        public ActionResult SummaryPenyampaianSearch()
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    SummaryPenyampaianModel data = new SummaryPenyampaianModel();
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "SummaryPenyampaian";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), data).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<SummaryPenyampaianModel> ListSummaryPenyampaian = JsonConvert.DeserializeObject<List<SummaryPenyampaianModel>>(result);

                    return Json(new { Result = "Success", Data = ListSummaryPenyampaian }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                List<SummaryPenyampaianModel> ListSummaryPenyampaian = new List<SummaryPenyampaianModel>();
                return Json(new { Result = "Failed", Data = ListSummaryPenyampaian }, JsonRequestBehavior.AllowGet);//throw ex;
            }
        }

        public ActionResult LaporanSeriesPertahun()
        {
            if (Session["PersonalNumber"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View();
            }
        }

        public ActionResult LaporanSeriesPertahunSearch(SeriesPertahunModel spm)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "SeriesPertahun";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), spm).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<SeriesPertahunModel> ListSeriesPertahun = JsonConvert.DeserializeObject<List<SeriesPertahunModel>>(result);

                    return Json(new { Result = "Success", Data = ListSeriesPertahun }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                List<SeriesPertahunModel> ListSeriesPertahun = new List<SeriesPertahunModel>();
                return Json(new { Result = "Failed", Data = ListSeriesPertahun }, JsonRequestBehavior.AllowGet);//throw ex;
            }
        }

        public ActionResult LaporanSeriesGrafik()
        {
            if (Session["PersonalNumber"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                string[] Filter = { "Proyek", "Anggaran", "Fisik", "KPI" };
                var laporanSeriesGrafik = new List<List<LaporanGrafikSeriesPeriode>>();
                foreach (var filter in Filter)
                {
                    var data = new LaporanGrafikSeriesPeriode
                    {
                        Filter = filter,
                        Year = DateTime.Now.Year
                    };
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "GetSeriesGrafik";
                    Uri baseAddress = new Uri(url);
                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Accept.Clear();
                    var response = client.PostAsJsonAsync(baseAddress.ToString(), data).Result;
                    var result = response.Content.ReadAsStringAsync().Result;
                    List<LaporanGrafikSeriesPeriode> ListDashboardProjectTimeSeriesProyek = JsonConvert.DeserializeObject<List<LaporanGrafikSeriesPeriode>>(result);
                    laporanSeriesGrafik.Add(ListDashboardProjectTimeSeriesProyek);
                }
                return View(laporanSeriesGrafik);
            }
        }

        public JsonResult GetSeriesGrafik(LaporanGrafikSeriesPeriode data)
        {
            try
            {

                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "GetSeriesGrafik";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), data).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                List<LaporanGrafikSeriesPeriode> ListDashboardProjectTimeSeries = JsonConvert.DeserializeObject<List<LaporanGrafikSeriesPeriode>>(result);

                return Json(ListDashboardProjectTimeSeries, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult LaporanSeriesGrafikCapaian()
        {
            if (Session["PersonalNumber"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var data = new DashboardProjectHeaderModel();
                data.Day = 1;
                data.Year = DateTime.Now.Year.ToString();
                data.Month = DateTime.Now.Month;

                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardProjectHeader";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), data).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                DashboardProjectHeaderModel DashboardProject = JsonConvert.DeserializeObject<DashboardProjectHeaderModel>(result);

                return View(DashboardProject);
            }
        }

        public ActionResult GetSeriesGrafikCapaianFisik(LaporanSeriesGrafikCapaianParamModel param)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "LaporanSeriesGrafikCapaian/GetSeriesCapaianFisik";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), param).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    LaporanSeriesGrafikCapaianViewModel grafikCapaianFisik = JsonConvert.DeserializeObject<LaporanSeriesGrafikCapaianViewModel>(result);

                    return Json(new { Result = "Success", Data = grafikCapaianFisik }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                LaporanSeriesGrafikCapaianViewModel grafikCapaianFisik = new LaporanSeriesGrafikCapaianViewModel();
                return Json(new { Result = "Failed", Data = grafikCapaianFisik }, JsonRequestBehavior.AllowGet);//throw ex;
            }
        }

        public ActionResult GetSeriesGrafikCapaianKpi(LaporanSeriesGrafikCapaianParamModel param)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "LaporanSeriesGrafikCapaian/GetSeriesCapaianKpi";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), param).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    LaporanSeriesGrafikCapaianKpiViewModel grafikCapaianKpi = JsonConvert.DeserializeObject<LaporanSeriesGrafikCapaianKpiViewModel>(result);

                    return Json(new { Result = "Success", Data = grafikCapaianKpi }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                LaporanSeriesGrafikCapaianKpiViewModel grafikCapaianKpi = new LaporanSeriesGrafikCapaianKpiViewModel();
                return Json(new { Result = "Failed", Data = grafikCapaianKpi }, JsonRequestBehavior.AllowGet);//throw ex;
            }
        }

        public ActionResult LaporanSeriesPerTahunExcel(string JenisCapaian,string Year,int Month,int Week,string Category,string Tw)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    var monthName = GlobalHelper.ListDropDowMonth().Where(x => x.Month == Month).Select(q => q.Description).FirstOrDefault();
                    var categoryName = GlobalHelper.ListCategorySeriesCapaianMethod().Where(x => x.Id == Category).Select(q => q.Description).FirstOrDefault();
                    LaporanSeriesGrafikCapaianParamModel param = new LaporanSeriesGrafikCapaianParamModel
                    {
                        Year = Year,
                        Month = Month,
                        Week = Week,
                        Category = Category,
                        Tw = Tw,
                        MonthName = monthName,
                        CategoryName = categoryName,
                        JenisCapaian = JenisCapaian 

                    };
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "LaporanSeriesGrafikCapaian/GetSeriesCapaianKpiDetail";
                    if (JenisCapaian == "Fisik")
                    {
                        url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "LaporanSeriesGrafikCapaian/GetSeriesCapaianFisikDetail";
                    }
                    Uri baseAddress = new Uri(url);
                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Accept.Clear();
                    var response = client.PostAsJsonAsync(baseAddress.ToString(), param).Result;
                    var result = response.Content.ReadAsStringAsync().Result;
                    List<LaporanSeriesGrafikCapaianDetailModel> detail = JsonConvert.DeserializeObject<List<LaporanSeriesGrafikCapaianDetailModel>>(result);
                    var grafikCapaianExcel = new LaporanSeriesGrafikCapaianExcelModel {
                        Param = param,
                        Detail = detail
                    };
                    return View("ExportExcelSeriesCapaian",grafikCapaianExcel);
                }
            }
            catch (Exception ex)
            {
                throw ex;   
            }
        }

    }
}