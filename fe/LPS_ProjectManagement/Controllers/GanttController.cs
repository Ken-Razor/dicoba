using LPS_ProjectManagement.Models.TransaksiDataModels;
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
    public class GanttController : Controller
    {
        // GET: Gantt
        public ActionResult GanttInisiasi(string ProjectHeaderID)
        {
            string PersonalNumber = Session["PersonalNumber"].ToString();
           // string Role = Session["EksekusiRole"].ToString();
            ProjectHeaderModel phm = new ProjectHeaderModel();
            HttpClient client = new HttpClient();
            string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "Initiation";
            Uri baseAddress = new Uri(url);

            client.BaseAddress = baseAddress;
            phm.IDProjectHeader = Convert.ToInt32(ProjectHeaderID);
            phm.CreatedBy = PersonalNumber;

            client.DefaultRequestHeaders.Accept.Clear();

            var response = client.PutAsJsonAsync(baseAddress.ToString(), phm).Result;
            var result = response.Content.ReadAsStringAsync().Result;

            ProjectHeaderModel ProjectHeader = JsonConvert.DeserializeObject<ProjectHeaderModel>(result);

            return View(ProjectHeader);
        }
        public ActionResult GanttEksekusi(string ProjectHeaderID , string Keys)
        {
            return View();
        }
        public string GetHariLibur()
        {
            string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterHariLibur";
            Uri baseAddress = new Uri(url);

            HttpClient client = new HttpClient();
            client.BaseAddress = baseAddress;
        
            client.DefaultRequestHeaders.Accept.Clear();

            var response = client.GetAsync(baseAddress.ToString()).Result;
            var result = response.Content.ReadAsStringAsync().Result;

            return result;
        }
    }
}