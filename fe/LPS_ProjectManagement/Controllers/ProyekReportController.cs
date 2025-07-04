using LPS_ProjectManagement.Models;
using LPS_ProjectManagement.Models.ProyekModels;
using LPS_ProjectManagement.Models.TransaksiDataModels;
using net.sf.mpxj;
using net.sf.mpxj.mpp;
using net.sf.mpxj.reader;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using LPS_ProjectManagement.Helper;
using System.Collections.ObjectModel;
using java.util;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Globalization;
using LPS_ProjectManagement.Models.EksekusiModels;


namespace LPS_ProjectManagement.Controllers
{
    public class ProyekReportController : Controller
    {
        GlobalHelper gh = new GlobalHelper();

        // GET: Proyek
        #region Project Executing

        public ActionResult ProjectExecutionReport(int ProjectHeaderID)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {

                    ExecutionReport2Model erm = new ExecutionReport2Model();

                    erm.IDProjectHeader = ProjectHeaderID;
                    erm.Keys = Session["PersonalNumber"].ToString();

                    Models.UserManagementModels.MultiPorpose MP = new Models.UserManagementModels.MultiPorpose();
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EksekusiDashboardReport";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), erm).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<ExecutionReport2Model> DetailEksekusi = JsonConvert.DeserializeObject<List<ExecutionReport2Model>>(result);
                    var DetailDesc = DetailEksekusi.OrderByDescending(x => x.vars).ToList();

                    // Problem n Mitigasi
                    ExecutionProblemReportModel erm2 = new ExecutionProblemReportModel();
                    erm2.IDProjectHeader = ProjectHeaderID;
                    erm2.IsTransformasi = 0;

                    HttpClient clientMitigasi = new HttpClient();
                    string urlMitigasi = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EksekusiDashboardProblemReport";
                    Uri baseAddressMitigasi = new Uri(urlMitigasi);

                    clientMitigasi.BaseAddress = baseAddressMitigasi;
                    clientMitigasi.DefaultRequestHeaders.Accept.Clear();

                    var responseMitigasi = clientMitigasi.PostAsJsonAsync(baseAddressMitigasi.ToString(), erm2).Result;
                    var resultMitigasi = responseMitigasi.Content.ReadAsStringAsync().Result;

                    List<ExecutionProblemReportModel> DetailEksekusiMitigasi = JsonConvert.DeserializeObject<List<ExecutionProblemReportModel>>(resultMitigasi);


                    ExecutionReport2ModelList List = new ExecutionReport2ModelList();

                    List.All = DetailEksekusi;
                    List.ProblemnMitigasi = DetailEksekusiMitigasi;
                    List.AllDesc = DetailDesc;
                    return View(List);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult ExportExcelEksekusi(int ProjectHeaderID)
        {
            try
            {
                ExecutionReport2Model erm = new ExecutionReport2Model();

                erm.IDProjectHeader = ProjectHeaderID;
                erm.Keys = Session["PersonalNumber"].ToString();

                Models.UserManagementModels.MultiPorpose MP = new Models.UserManagementModels.MultiPorpose();
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EksekusiDashboardReport";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), erm).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                var newres = new ExecutionReport2ModelList();
                List<ExecutionReport2Model> DetailEksekusi = JsonConvert.DeserializeObject<List<ExecutionReport2Model>>(result);
                newres.AllDesc = DetailEksekusi.OrderBy(x => x.vars).ToList();

                return View(newres);

            }
            catch (Exception ex)
            {

                throw ex;

            }
        }
        public ActionResult ExportExcelMitigasi(int ProjectHeaderID)
        {
            try
            {
                // Problem n Mitigasi
                ExecutionProblemReportModel erm2 = new ExecutionProblemReportModel();
                erm2.IDProjectHeader = ProjectHeaderID;
                erm2.IsTransformasi = 0;

                HttpClient clientMitigasi = new HttpClient();
                string urlMitigasi = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EksekusiDashboardProblemReport";
                Uri baseAddressMitigasi = new Uri(urlMitigasi);

                clientMitigasi.BaseAddress = baseAddressMitigasi;
                clientMitigasi.DefaultRequestHeaders.Accept.Clear();

                var responseMitigasi = clientMitigasi.PostAsJsonAsync(baseAddressMitigasi.ToString(), erm2).Result;
                var resultMitigasi = responseMitigasi.Content.ReadAsStringAsync().Result;
                var newres = new ExecutionReport2ModelList();
                List<ExecutionProblemReportModel> DetailEksekusiMitigasi = JsonConvert.DeserializeObject<List<ExecutionProblemReportModel>>(resultMitigasi);
                newres.ProblemnMitigasi = DetailEksekusiMitigasi;
                return View(newres);

            }
            catch (Exception ex)
            {

                throw ex;

            }
        }
        #endregion


    }
}