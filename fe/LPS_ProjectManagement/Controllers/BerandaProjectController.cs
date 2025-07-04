using LPS_ProjectManagement.Models.DashboardModels;
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
    public class BerandaProjectController : Controller
    {
        public int IDProject { get; set; }
        // GET: BerandaProject
        public ActionResult Index(int ID, int Month , int Year , int Week)
        {
            if (Session["PersonalNumber"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                DashboardProjectDetails pm = new DashboardProjectDetails();

                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardProjectDetails";
                Uri baseAddress = new Uri(url);
                pm.IDProject = ID.ToString() + "|" + Month.ToString() + "|" + Year.ToString() + "|" + Week.ToString();

                

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PutAsJsonAsync(baseAddress.ToString(), pm).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                DashboardProjectDetails ProgramModel = JsonConvert.DeserializeObject<DashboardProjectDetails>(result);

                return View(ProgramModel);
                //return View();
            }
        }

        public ActionResult GetProjectDetails(DashboardProjectDetails model)
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardProjectDetails";
                Uri baseAddress = new Uri(url);

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PutAsJsonAsync(baseAddress.ToString(), model).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                DashboardProjectDetails ProgramModel = JsonConvert.DeserializeObject<DashboardProjectDetails>(result);

                //string data = JsonConvert.DeserializeObject<string>(result);
                //string[] hasil = data.Split('|');

                //if (hasil[0] == "S") return Json(new { Result = "Success", Message = hasil[1] });
                //else return Json(new { Result = "Failed", Message = hasil[1] });

                return Json(ProgramModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Failed", Message = ex.Message });
            }
        }

        #region FIN

        public JsonResult GetDashboardProjectHeader(DashboardProjectModel data)
        {
            try
            {
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

        #endregion
    }
}