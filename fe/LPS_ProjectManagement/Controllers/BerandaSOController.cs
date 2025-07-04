using LPS_ProjectManagement.Models.DashboardModels;
using LPS_ProjectManagement.Models.DashboardModels.DashboardProject;
using LPS_ProjectManagement.Models.DashboardModels.DashboardSummary;
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
    public class BerandaSOController : Controller
    {
        // GET: BerandaSO
        public ActionResult Index(string Filter, string Year, int Month, int Week, int JumlahWeek)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                } else { 
                    DashboardSummaryModel DashboardSummaryModel = new DashboardSummaryModel();
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardSummary";
                    Uri baseAddress = new Uri(url);

                    DashboardSummaryModel.Filter = Filter;
                    DashboardSummaryModel.Year = Year;
                    DashboardSummaryModel.Month = Month;
                    DashboardSummaryModel.Week = Week;
                    DashboardSummaryModel.PersonalNumber = Session["PersonalNumber"].ToString(); ;

                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), DashboardSummaryModel).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    DashboardSummaryModel = JsonConvert.DeserializeObject<DashboardSummaryModel>(result);
                    DashboardSummaryModel.JumlahWeek = JumlahWeek;

                    return View(DashboardSummaryModel);
                }
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

                DashboardProjectTypeModel ProgramModel = JsonConvert.DeserializeObject<DashboardProjectTypeModel>(result);

                return Json(ProgramModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Failed", Message = ex.Message });
            }
        }

        public JsonResult GetProjectListSO(ProjectListSODashboard model)
        {
            try
            {

                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardProjectListSO";
                Uri baseAddress = new Uri(url);

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PutAsJsonAsync(baseAddress.ToString(), model).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                List<ProjectListSODashboard> ProgramModel = JsonConvert.DeserializeObject<List<ProjectListSODashboard>>(result);

                return Json(ProgramModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Failed", Message = ex.Message });
            }
        }
        
        public JsonResult GetSOStackedBar()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardSOStackedBar";
                Uri baseAddress = new Uri(url);

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.GetAsync(baseAddress.ToString()).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                DashboardSOStackedBarModel ProgramModel = JsonConvert.DeserializeObject<DashboardSOStackedBarModel>(result);

                return Json(ProgramModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Failed", Message = ex.Message });
            }
        }

        #region New
        
        public ActionResult GetSummaryHeader(DashboardSummaryHeaderModel DashboardSummaryHeaderModel)
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardSummaryHeader";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), DashboardSummaryHeaderModel).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                DashboardSummaryHeaderModel DashboardProject = JsonConvert.DeserializeObject<DashboardSummaryHeaderModel>(result);

                return Json(DashboardProject, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult GetSOStatus(DashboardSummaryStatusModel model)
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "StatusDashboardSO";
                Uri baseAddress = new Uri(url);

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), model).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                DashboardSummaryStatusModel ProgramModel = JsonConvert.DeserializeObject<DashboardSummaryStatusModel>(result);

                return Json(ProgramModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Failed", Message = ex.Message });
            }
        }

        public ActionResult StackedBar(DashboardSummaryModel DashboardSummaryModel)
        {
            try
            {
                DashboardSummaryModel.PersonalNumber = Session["PersonalNumber"].ToString();

                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardSummary";
                Uri baseAddress = new Uri(url);
                
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), DashboardSummaryModel).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                DashboardSummaryModel = JsonConvert.DeserializeObject<DashboardSummaryModel>(result);

                return Json( new { DashboardSummaryModel, JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                throw ex;
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