using LPS_ProjectManagement.Helper;
using LPS_ProjectManagement.Models;
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
    public class MsWordController : Controller
    {
        // GET: MsWord
        public ActionResult Index(string PHID)
        {
            try
            {
                string ProjectHeaderID = PHID;
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
        public ActionResult ProjectPlan(string PHID)
        {
            try
            {
                string ProjectHeaderID = PHID;
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

    }
}