using LPS_ProjectManagement.Common;
using LPS_ProjectManagement.Helper;
using LPS_ProjectManagement.Models;
using LPS_ProjectManagement.Models.DashboardModels;
using LPS_ProjectManagement.Models.DashboardModels.DashboardProject;
using LPS_ProjectManagement.Models.MasterDataModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace LPS_ProjectManagement.Controllers
{
    [CustomAuthorizationAttribute]
    [CompressFilter]
    public class BerandaController : Controller
    {
        // GET: Beranda
        public ActionResult Index()
        {
            if (Session["PersonalNumber"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else {
                var personalNumber = Session["PersonalNumber"].ToString();
                DashboardProjectHeaderModel data = new DashboardProjectHeaderModel();
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardProjectHeader";
                Uri baseAddress = new Uri(url);
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsJsonAsync(baseAddress.ToString(), data).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                DashboardProjectHeaderModel DashboardProjectHeader = JsonConvert.DeserializeObject<DashboardProjectHeaderModel>(result);
                var ListMonth = GlobalHelper.ListDropDowMonth();

                var dataDashboard = new DashboardProjectModel
                {
                    Filter = "All",
                    Year = DateTime.Now.Year.ToString(),
                    Month = DateTime.Now.Month,
                    Week = DashboardProjectHeader.Week,
                    PersonalNumber = personalNumber
                };
                client = new HttpClient();
                url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardProject";
                baseAddress = new Uri(url);
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                response = client.PostAsJsonAsync(baseAddress.ToString(), dataDashboard).Result;
                result = response.Content.ReadAsStringAsync().Result;
                DashboardProjectModel DashboardProject = JsonConvert.DeserializeObject<DashboardProjectModel>(result);

                var dataProgress = new DashboardProjectProgressModel{
                    Filter = "All",
                    Year = DateTime.Now.Year.ToString(),
                    Month = DateTime.Now.Month,
                    Week = DashboardProjectHeader.Week,
                    PersonalNumber = personalNumber
                };
                client = new HttpClient();
                url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardProjectProgress";
                baseAddress = new Uri(url);
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                response = client.PostAsJsonAsync(baseAddress.ToString(), dataProgress).Result;
                result = response.Content.ReadAsStringAsync().Result;
                List<DashboardProjectProgressModel> DashboardProjectProgress = JsonConvert.DeserializeObject<List<DashboardProjectProgressModel>>(result);

                var dataProgressPerProject = new DashboardProjectProgressPerProjectModel
                {
                    Filter = "All",
                    Year = DateTime.Now.Year.ToString(),
                    Month = DateTime.Now.Month,
                    Week = DashboardProjectHeader.Week,
                    PersonalNumber = personalNumber
                };
                client = new HttpClient();
                url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardProjectProgressPerProject";
                baseAddress = new Uri(url);
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                response = client.PostAsJsonAsync(baseAddress.ToString(), dataProgressPerProject).Result;
                result = response.Content.ReadAsStringAsync().Result;
                List<DashboardProjectProgressPerProjectModel> DashboardProjectProgressPerProject = JsonConvert.DeserializeObject<List<DashboardProjectProgressPerProjectModel>>(result);

                DashboardProjectModel dataTransNotrans = new DashboardProjectModel {
                    Filter = "All",
                    Year = DateTime.Now.Year.ToString(),
                    Month = DateTime.Now.Month,
                    Week = DashboardProjectHeader.Week,
                    PersonalNumber = personalNumber
                };
                client = new HttpClient();
                url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "Dashboard";
                baseAddress = new Uri(url);
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                response = client.PostAsJsonAsync(baseAddress.ToString(), dataTransNotrans).Result;
                result = response.Content.ReadAsStringAsync().Result;
                List<DashboardTransAndNoTransModel> DashboardProjectTransNotrans = JsonConvert.DeserializeObject<List<DashboardTransAndNoTransModel>>(result);

                var dataOverall = new DashboardProjectOverallModel {
                    Filter = "Unit Kerja",
                    Year = DateTime.Now.Year.ToString(),
                    PersonalNumber = personalNumber
                };
                client = new HttpClient();
                url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardProjectOverAll";
                baseAddress = new Uri(url);
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                response = client.PostAsJsonAsync(baseAddress.ToString(), dataOverall).Result;
                result = response.Content.ReadAsStringAsync().Result;
                List<DashboardProjectOverallModel> DashboardProjectOverall = JsonConvert.DeserializeObject<List<DashboardProjectOverallModel>>(result);

                var dataTimeseries = new DashboardProjectTimeSeriesModel {
                    Filter = "Transformasi",
                    Year = DateTime.Now.Year,
                    Month = DateTime.Now.Month,
                    Week = DashboardProjectHeader.Week,
                    PersonalNumber = personalNumber
                };
                client = new HttpClient();
                url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardProjectTimeSeries";
                baseAddress = new Uri(url);
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                response = client.PostAsJsonAsync(baseAddress.ToString(), dataTimeseries).Result;
                result = response.Content.ReadAsStringAsync().Result;
                List<DashboardProjectTimeSeriesModel> DashboardProjectTimeSeriesTransformasi = JsonConvert.DeserializeObject<List<DashboardProjectTimeSeriesModel>>(result);

                dataTimeseries.Filter = "Non Transformasi";
                client = new HttpClient();
                url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardProjectTimeSeries";
                baseAddress = new Uri(url);
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                response = client.PostAsJsonAsync(baseAddress.ToString(), dataTimeseries).Result;
                result = response.Content.ReadAsStringAsync().Result;
                List<DashboardProjectTimeSeriesModel> DashboardProjectTimeSeriesNonTransformasi = JsonConvert.DeserializeObject<List<DashboardProjectTimeSeriesModel>>(result);
                var berandaInit = new BerandaInitModel {
                    DashboardProjectHeader = DashboardProjectHeader,
                    ListMonth = ListMonth,
                    DashboardProject = DashboardProject,
                    DashboardProjectProgress = DashboardProjectProgress,
                    DashboardProjectProgressPerProject = DashboardProjectProgressPerProject,
                    DashboardTransAndNoTrans = DashboardProjectTransNotrans,
                    DashboardProjectOverall =  DashboardProjectOverall,
                    DashboardProjectTimeSeriesTransformasi = DashboardProjectTimeSeriesTransformasi,
                    DashboardProjectTimeSeriesNonTransformasi = DashboardProjectTimeSeriesNonTransformasi
                };
                //return Json(DashboardProject, JsonRequestBehavior.AllowGet);
                return View(berandaInit);
            }
        }

        public JsonResult GetProjectDepartment()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardProjectDepartment";
                Uri baseAddress = new Uri(url);

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.GetAsync(baseAddress.ToString()).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                List<DashboardProjectDepartment> ProgramModel = JsonConvert.DeserializeObject<List<DashboardProjectDepartment>>(result);

                //return Json(new { result = ProgramModel });
                return Json(ProgramModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult DashboardDetail()
        {
            ViewBag.Title = "002/I/2018 - Penguatan Budaya";
            return View();
        }
        
        public ActionResult EksekutifIndex()
        {
            return View();
        }

        public ActionResult DashboardEksekutif()
        {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MainRebornExecutive";
                Uri baseAddress = new Uri(url);

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.GetAsync(baseAddress.ToString()).Result;
                var result = response.Content.ReadAsStringAsync().Result;

            MainRibbonExecutiveModel EksekutifModel = JsonConvert.DeserializeObject<MainRibbonExecutiveModel>(result);

                //return Json(new { result = ProgramModel });
                //return Json(EksekutifModel, JsonRequestBehavior.AllowGet);
            
                return View(EksekutifModel);
        }

        public ActionResult DashboardEksekutifIT()
        {
            try
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

                    //return Json(DashboardProject, JsonRequestBehavior.AllowGet);
                    return View(DashboardProject);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult GetDashboardProjectPenggunaan(DashboardPenggunaanModel data)
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardPenggunaan";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), data).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                List<DashboardPenggunaanModel> DashboardPenggunaan = JsonConvert.DeserializeObject<List<DashboardPenggunaanModel>>(result);

                return Json(DashboardPenggunaan, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult GetProjectType()
        {
            try
            {
                DashboardTransformation dt = new DashboardTransformation();
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardTransformation";
                Uri baseAddress = new Uri(url);

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.GetAsync(baseAddress.ToString()).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                List<DashboardTransformation> ProgramModel = JsonConvert.DeserializeObject<List<DashboardTransformation>>(result);

                return Json(ProgramModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult GetAllProjectStatus()
        {
            try
            {
                DashboardTransformation dt = new DashboardTransformation();
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardTotalAllStatus";
                Uri baseAddress = new Uri(url);

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.GetAsync(baseAddress.ToString()).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                List<DashboardAllProjectStatus> ProgramModel = JsonConvert.DeserializeObject<List<DashboardAllProjectStatus>>(result);

                //return Json(new { result = ProgramModel });
                return Json(ProgramModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult GetSOData()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardSO";
                Uri baseAddress = new Uri(url);

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.GetAsync(baseAddress.ToString()).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                List<DashboardSOModel> ProgramModel = JsonConvert.DeserializeObject<List<DashboardSOModel>>(result);

                //return Json(new { result = ProgramModel });
                return Json(ProgramModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult GetSOUsedData()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardUsedSO";
                Uri baseAddress = new Uri(url);

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.GetAsync(baseAddress.ToString()).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                List<DashboardSOUsed> ProgramModel = JsonConvert.DeserializeObject<List<DashboardSOUsed>>(result);

                //return Json(new { result = ProgramModel });
                return Json(ProgramModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult GetSOProjectType(DashboardProjectTypeModel model)
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardProjectTypeSO";
                Uri baseAddress = new Uri(url);

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PutAsJsonAsync(baseAddress.ToString(), model).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                List<DashboardProjectTypeModel> ProgramModel = JsonConvert.DeserializeObject<List<DashboardProjectTypeModel>>(result);

                string data = JsonConvert.DeserializeObject<string>(result);
                string[] hasil = data.Split('|');

                if (hasil[0] == "S") return Json(new { Result = "Success", Message = hasil[1] });
                else return Json(new { Result = "Failed", Message = hasil[1] });

                //return Json(ProgramModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Failed", Message = ex.Message });
            }
        }

        public JsonResult GetDashboardEksekutif()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardEksekutif";
                Uri baseAddress = new Uri(url);

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.GetAsync(baseAddress.ToString()).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                DashboardEksekutif EksekutifModel = JsonConvert.DeserializeObject<DashboardEksekutif>(result);

                //return Json(new { result = ProgramModel });
                return Json(EksekutifModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region FIN

        public JsonResult GetDashboardTransAndNoTrans(DashboardProjectModel data)
        {
            try
            {
                data.PersonalNumber = Session["PersonalNumber"].ToString();

                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "Dashboard";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), data).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                List<DashboardTransAndNoTransModel> DashboardProject = JsonConvert.DeserializeObject<List<DashboardTransAndNoTransModel>>(result);

                return Json(DashboardProject, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult GetDashboardProjectHeader(DashboardProjectModel data)
        {
            try
            {
                data.PersonalNumber = Session["PersonalNumber"].ToString();

                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardProject";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), data).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                DashboardProjectModel DashboardProject = JsonConvert.DeserializeObject<DashboardProjectModel>(result);

                return Json(DashboardProject, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult GetDashboardProjectOverall(DashboardProjectOverallModel data)
        {
            try
            {
                data.PersonalNumber = Session["PersonalNumber"].ToString();

                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardProjectOverAll";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(),data).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                List<DashboardProjectOverallModel> DashboardProject = JsonConvert.DeserializeObject<List<DashboardProjectOverallModel>>(result);

                return Json(DashboardProject, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult GetDashboardProjectProgress(DashboardProjectProgressModel dataProgress)
        {
            try
            {
                dataProgress.PersonalNumber = Session["PersonalNumber"].ToString();

                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardProjectProgress";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), dataProgress).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                List<DashboardProjectProgressModel> DashboardProject = JsonConvert.DeserializeObject<List<DashboardProjectProgressModel>>(result);

                return Json(DashboardProject, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult GetDashboardProjectProgressPerProgress(DashboardProjectProgressModel dataProgress)
        {
            try
            {
                dataProgress.PersonalNumber = Session["PersonalNumber"].ToString();

                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardProjectProgressPerProject";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), dataProgress).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                List<DashboardProjectProgressPerProjectModel> DashboardProject = JsonConvert.DeserializeObject<List<DashboardProjectProgressPerProjectModel>>(result);

                return Json(DashboardProject, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public JsonResult GetDashboardProjectTimeSeries(DashboardProjectTimeSeriesModel data)
        {
            try
            {
                data.PersonalNumber = Session["PersonalNumber"].ToString();

                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardProjectTimeSeries";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), data).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                List<DashboardProjectTimeSeriesModel> ListDashboardProjectTimeSeries = JsonConvert.DeserializeObject<List<DashboardProjectTimeSeriesModel>>(result);

                return Json(ListDashboardProjectTimeSeries, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult GenerateDashboard()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "Dashboard";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.GetAsync(baseAddress.ToString()).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                string data = JsonConvert.DeserializeObject<string>(result);
                string[] hasil = data.Split('|');

                if (hasil[0] == "S") return Json(new { Result = "Success", Message = hasil[1] });
                else return Json(new { Result = "Failed", Message = hasil[1] });

                //return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Failed", Message = ex.Message });
            }
        }

        public JsonResult GetDdlWeek(DashboardProjectHeaderModel data)
        {
            data.Day = 1;

            HttpClient client = new HttpClient();
            string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardProjectHeader";
            Uri baseAddress = new Uri(url);

            client.BaseAddress = baseAddress;

            client.DefaultRequestHeaders.Accept.Clear();

            var response = client.PostAsJsonAsync(baseAddress.ToString(), data).Result;
            var result = response.Content.ReadAsStringAsync().Result;

            DashboardProjectHeaderModel DashboardProject = JsonConvert.DeserializeObject<DashboardProjectHeaderModel>(result);

            return Json(DashboardProject, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}