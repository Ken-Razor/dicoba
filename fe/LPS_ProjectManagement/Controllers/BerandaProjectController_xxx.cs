using LPS_ProjectManagement.Models.DashboardModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LPS_ProjectManagement.Controllers
{
    public class BerandaProjectController : Controller
    {
        public int IDProject { get; set; }
        // GET: BerandaProject
        public async Task<ActionResult> Index(int id)
        {
            if (Session["PersonalNumber"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                DashboardProjectDetails projectDetails = new DashboardProjectDetails();
                projectDetails.ProjectHeader = new DashboardProjectHeader() { Id = id };


                using (HttpClient client = new HttpClient())
                {
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardProjectHeader";
                    UriBuilder uriBuilder = new UriBuilder(url);
                    NameValueCollection queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
                    queryString["projectId"] = id.ToString();
                    uriBuilder.Query = queryString.ToString();
                    url = uriBuilder.ToString();

                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        DashboardProjectHeader result = response.Content.ReadAsAsync<DashboardProjectHeader>().Result;
                        projectDetails.ProjectHeader = result;
                    }                    
                }

                using (HttpClient client = new HttpClient())
                {
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardProjectStakeholder";
                    UriBuilder uriBuilder = new UriBuilder(url);
                    NameValueCollection queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
                    queryString["projectId"] = id.ToString();
                    uriBuilder.Query = queryString.ToString();
                    url = uriBuilder.ToString();

                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        List<DashboardProjectStakeholder> result = response.Content.ReadAsAsync<List<DashboardProjectStakeholder>>().Result;
                        projectDetails.ListStackHolder = result;
                    }
                }

                using (HttpClient client = new HttpClient())
                {
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardProjectConstraint";
                    UriBuilder uriBuilder = new UriBuilder(url);
                    NameValueCollection queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
                    queryString["projectId"] = id.ToString();
                    uriBuilder.Query = queryString.ToString();
                    url = uriBuilder.ToString();

                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        List<DashboardProjectConstraint> result = response.Content.ReadAsAsync<List<DashboardProjectConstraint>>().Result;
                        projectDetails.ListConstraint = result;
                    }
                }

                using (HttpClient client = new HttpClient())
                {
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardProjectMilestone";
                    UriBuilder uriBuilder = new UriBuilder(url);
                    NameValueCollection queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
                    queryString["projectId"] = id.ToString();
                    uriBuilder.Query = queryString.ToString();
                    url = uriBuilder.ToString();

                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        List<DashboardProjectMilestone> result = response.Content.ReadAsAsync<List<DashboardProjectMilestone>>().Result;
                        projectDetails.ListMilestone = result;
                    }
                }

                using (HttpClient client = new HttpClient())
                {
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardProjectTask";
                    UriBuilder uriBuilder = new UriBuilder(url);
                    NameValueCollection queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
                    queryString["projectId"] = id.ToString();
                    uriBuilder.Query = queryString.ToString();
                    url = uriBuilder.ToString();

                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        List<DashboardProjectTask> result = response.Content.ReadAsAsync<List<DashboardProjectTask>>().Result;
                        projectDetails.ListTask = result;
                    }
                }

                using (HttpClient client = new HttpClient())
                {
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DashboardProgressProject";
                    UriBuilder uriBuilder = new UriBuilder(url);
                    NameValueCollection queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
                    queryString["projectId"] = id.ToString();
                    uriBuilder.Query = queryString.ToString();
                    url = uriBuilder.ToString();

                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        List<DashboardProgressProject> result = response.Content.ReadAsAsync<List<DashboardProgressProject>>().Result;
                        projectDetails.ProgressProject = result;
                    }
                }

                return View(projectDetails);
            }
        }
    }
}