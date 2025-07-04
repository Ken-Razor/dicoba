using LPS_ProjectManagement.Helper;
using LPS_ProjectManagement.Models;
using LPS_ProjectManagement.Models.ReportModels;
using Newtonsoft.Json;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Web.Mvc;

namespace LPS_ProjectManagement.Controllers
{
    public class ExportingController : Controller
    {
        GlobalHelper GH = new GlobalHelper();
        #region Template
        public ActionResult ProjectPlanning(int ProjectHeaderID)
        {

            try
            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "ProjectCharterandPlanning?ProjectHeaderID=" + ProjectHeaderID;
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.GetAsync(baseAddress.ToString()).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                ProjectCharterandPlanningModel FileExport = JsonConvert.DeserializeObject<ProjectCharterandPlanningModel>(result);

                return View(FileExport);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult ProjectCharter(int ProjectHeaderID)
        {

            try
            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "ProjectCharterandPlanning?ProjectHeaderID=" + ProjectHeaderID;
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.GetAsync(baseAddress.ToString()).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                ProjectCharterandPlanningModel FileExport = JsonConvert.DeserializeObject<ProjectCharterandPlanningModel>(result);

                return View(FileExport);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult CharterandPlanningFooter()
        {
            return View();
        }

        public ActionResult ProjectAmandemen(int ProjectHeaderID)
        {

            try
            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "ProjectCharterandPlanning?ProjectHeaderID=" + ProjectHeaderID;
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.GetAsync(baseAddress.ToString()).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                ProjectCharterandPlanningModel FileExport = JsonConvert.DeserializeObject<ProjectCharterandPlanningModel>(result);

                return View(FileExport);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult ReportCapaian(int week, int month , int year , string jenis, int tipe)
        {

            try
            {
                PencapainParam LP = new PencapainParam();

                LP.jenisapi = jenis;
                LP.week = week;
                LP.year = year;
                LP.month = month;

                if (jenis == "Trans")
                {
                    LP.tipe = tipe;
                 
                }
                string type = "";

                if (tipe == 0)
                {
                    type = "Non Transformasi";
                }
                else if (tipe == 1)
                {
                    type = "Transformasi";
                }
                ViewBag.Tipe = type;

                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "LaporanCapaian";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;
            
                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), LP).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                LaporanPencapaian laporanPencapaian = JsonConvert.DeserializeObject<LaporanPencapaian>(result);

                ViewBag.Month = GH.getMonthName(month);
                ViewBag.Year = year;


                return View(laporanPencapaian);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult SummaryStatusPencapaian()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "SummaryPenyampaian";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(),new { }).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                List<SummaryPenyampaianModel> pencapaianSummary = JsonConvert.DeserializeObject<List<SummaryPenyampaianModel>>(result);

                return View(pencapaianSummary);
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region Print Action
        public ActionResult PrintPlanning(int ProjectHeaderID)
        {
            try
            {

                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "ProjectCharterandPlanning?ProjectHeaderID=" + ProjectHeaderID;
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.GetAsync(baseAddress.ToString()).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                ProjectCharterandPlanningModel FileExport = JsonConvert.DeserializeObject<ProjectCharterandPlanningModel>(result);

                return new ActionAsPdf("ProjectPlanning", new { ProjectHeaderID = ProjectHeaderID })
                {
                    FileName = "PP_" + FileExport.Charter[0].Nama + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf",
                    PageSize = Rotativa.Options.Size.A4,
                    PageMargins = new Rotativa.Options.Margins(20, 10, 10, 20)
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

        public ActionResult PrintCharter(int ProjectHeaderID)
        {
            try
            {

                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "ProjectCharterandPlanning?ProjectHeaderID=" + ProjectHeaderID;
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.GetAsync(baseAddress.ToString()).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                ProjectCharterandPlanningModel FileExport = JsonConvert.DeserializeObject<ProjectCharterandPlanningModel>(result);
                //  string footer = Url.Action("CharterandPlanningFooter", "Exporting", new { Areas = "" }, Request.Url.Scheme);

                string cusomtSwitches = string.Format("--print-media-type --allow {0} --footer-html {0} --footer-spacing -10",Url.Action("CharterandPlanningFooter", "Exporting"));

                string footer = "--footer-center \"Page: [page] / [toPage]\" --footer-font-size \"9\" --footer-spacing 5 --footer-font-name \"Book Antiqua\"";
                return new ActionAsPdf("ProjectCharter", new { ProjectHeaderID = ProjectHeaderID })
                {
                    FileName = "PC_" + FileExport.Charter[0].Nama + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf",
                    PageSize = Rotativa.Options.Size.A4,
                    PageMargins = new Rotativa.Options.Margins(20, 10, 20, 20),
                    CustomSwitches = footer
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ActionResult PrintAmandemen(int ProjectHeaderID)
        {
            try
            {

                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "ProjectCharterandPlanning?ProjectHeaderID=" + ProjectHeaderID;
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.GetAsync(baseAddress.ToString()).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                ProjectCharterandPlanningModel FileExport = JsonConvert.DeserializeObject<ProjectCharterandPlanningModel>(result);

                return new ActionAsPdf("ProjectPlanning", new { ProjectHeaderID = ProjectHeaderID })
                {
                    FileName = FileExport.Charter[0].Nama + ".pdf",
                    PageSize = Rotativa.Options.Size.A4,
                    PageMargins = new Rotativa.Options.Margins(20, 10, 10, 20)
                };
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult PrintCapaianProyek(int week , int month , int year, string jenis)
        {
            try
            {
                var monthname = GH.getMonthName(month);
                var status = jenis.Split('|');

                return new ActionAsPdf("ReportCapaian", new { week =  week, month = month, year = year, jenis = status[0], tipe = status[1] })
                {
                    FileName = "LaporanCapaian" + status[0] + " " + monthname + " " + year + ".pdf",
                    PageSize = Rotativa.Options.Size.A4,
                    PageOrientation = Rotativa.Options.Orientation.Landscape,
                    PageMargins = new Rotativa.Options.Margins(20, 10, 10, 20)
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult PrintSummaryStatusPencapaian()
        {
            try
            {
                return new ActionAsPdf("SummaryStatusPencapaian")
                {
                    FileName = "SummaryStatusPencapaian" + ".pdf",
                    PageSize = Rotativa.Options.Size.A4,
                    PageOrientation = Rotativa.Options.Orientation.Landscape,
                    PageMargins = new Rotativa.Options.Margins(20, 10, 10, 20)
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult PrintExcelSummaryStatusPencapaian()
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "SummaryPenyampaian";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), new { }).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<SummaryPenyampaianModel> pencapaianSummary = JsonConvert.DeserializeObject<List<SummaryPenyampaianModel>>(result);

                    return View(pencapaianSummary);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult PrintSeriesPerTahun(int thn1, int thn2)
        {
            try
            {
                string footer = "--footer-center \"Page: [page] / [toPage]\" --footer-font-size \"9\" --footer-spacing 5 --footer-font-name \"Book Antiqua\"";
                return new ActionAsPdf("LaporanSeriesPerTahunPdf", new { thn1 = thn1, thn2 = thn2 })
                {
                    FileName = "LaporanSeriesPerTahun" + ".pdf",
                    PageSize = Rotativa.Options.Size.A4,
                    PageOrientation = Rotativa.Options.Orientation.Landscape,
                    PageMargins = new Rotativa.Options.Margins(20, 10, 10, 20),
                    CustomSwitches = footer
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult LaporanSeriesPerTahunPdf(int thn1,int thn2)
        {
            try
            {
                SeriesPertahunModel spm = new SeriesPertahunModel
                {
                    thn1 = thn1,
                    thn2 = thn2
                };
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "SeriesPertahun";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), spm).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                List<SeriesPertahunModel> ListSeriesPertahun = JsonConvert.DeserializeObject<List<SeriesPertahunModel>>(result);

                return View(ListSeriesPertahun);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ActionResult LaporanSeriesPerTahunExcel(int thn1, int thn2)
        {

            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    SeriesPertahunModel spm = new SeriesPertahunModel {
                        thn1 = thn1,
                        thn2 = thn2
                    };
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "SeriesPertahun";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), spm).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<SeriesPertahunModel> ListSeriesPertahun = JsonConvert.DeserializeObject<List<SeriesPertahunModel>>(result);

                    return View(ListSeriesPertahun);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult LaporanSumaryPelaksanaanProyekExcel(string Year, int Month)
        {

            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    SummaryModel sm = new SummaryModel { 
                        Year = Year,
                        Month = Month
                    };
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "Summary";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    //phm.IDProjectHeader = IDProjectHeader;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), sm).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<SummaryModel> ListSummary = JsonConvert.DeserializeObject<List<SummaryModel>>(result);

                    return View(ListSummary);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public ActionResult CheckMilestone(string ProjectHeaderID , string TaskID)
        //{
        //    GlobalHelper GH = new GlobalHelper();

        //    var Status = GH.CheckMilestone(ProjectHeaderID, TaskID);
        //    return Json( new { ss = Status });
        //}

        public string CheckMilestone(string ProjectHeaderID, string TaskID)
        {
            GlobalHelper GH = new GlobalHelper();

            var Status = GH.CheckMilestone(ProjectHeaderID, TaskID);

            return Status;
        }

        #endregion
    }
}