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
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Globalization;
using java.util;

using LPS_ProjectManagement.Helper;
using LPS_ProjectManagement.Models;
using LPS_ProjectManagement.Models.ProyekModels;
using LPS_ProjectManagement.Models.TransaksiDataModels;
using LPS_ProjectManagement.Models.EksekusiModels;
using LPS_ProjectManagement.Models.TransaksiClosingModels;
using LPS_ProjectManagement.Models.TransaksiChangeManagementModels;
using LPS_ProjectManagement.Common;

namespace LPS_ProjectManagement.Controllers
{
    public class ProjectExecController : Controller
    {
        readonly GlobalHelper gh = new GlobalHelper();

        // GET: ProjectExec
        #region Project Executing

        //public ActionResult ProjectExecution()
        //{
        //    try
        //    {
        //        if (Session["PersonalNumber"] == null)
        //        {
        //            return RedirectToAction("Login", "Login");
        //        }
        //        else
        //        {
        //            Models.UserManagementModels.MultiPorpose MP = new Models.UserManagementModels.MultiPorpose();
        //            HttpClient client = new HttpClient();
        //            string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EksekusiList";
        //            Uri baseAddress = new Uri(url);

        //            client.BaseAddress = baseAddress;
        //            MP.ID = Session["PersonalNumber"].ToString();

        //            client.DefaultRequestHeaders.Accept.Clear();

        //            var response = client.PostAsJsonAsync(baseAddress.ToString(), MP).Result;
        //            var result = response.Content.ReadAsStringAsync().Result;

        //            List<ExecutionModel> ListEksekusi = JsonConvert.DeserializeObject<List<ExecutionModel>>(result);

        //            return View(ListEksekusi);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public ActionResult ProjectExecutionCreate(int ProjectHeaderID, string Keys)
        //{
        //    try
        //    {
        //        if (Session["PersonalNumber"] == null)
        //        {
        //            return RedirectToAction("Login", "Login");
        //        }
        //        else
        //        {
        //            Session["keys"] = Keys;
        //            string Persnum = Session["PersonalNumber"].ToString();
        //            Models.UserManagementModels.MultiPorpose MP = new Models.UserManagementModels.MultiPorpose();
        //            HttpClient client = new HttpClient();
        //            string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EksekusiCRUD?ProjectID=" + ProjectHeaderID + "&Periode=" + Keys + "&Persnum=" + Persnum;
        //            Uri baseAddress = new Uri(url);

        //            client.BaseAddress = baseAddress;
        //            client.DefaultRequestHeaders.Accept.Clear();

        //            var response = client.GetAsync(baseAddress.ToString()).Result;
        //            var result = response.Content.ReadAsStringAsync().Result;

        //            EksekusiModel DetailEksekusi = JsonConvert.DeserializeObject<EksekusiModel>(result);

        //            if (DetailEksekusi.Role == null)
        //            {
        //                var zz = new List<Roleproj>();
        //                Session["EksekusiRole"] = zz;
        //                Session["SysRole"] = DetailEksekusi.Sysrole;
        //            }
        //            else
        //            {
        //                Session["EksekusiRole"] = DetailEksekusi.Role;
        //                Session["SysRole"] = DetailEksekusi.Sysrole;
        //            }

        //            return View(DetailEksekusi);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public ActionResult ProjectExecutionReport(int ProjectHeaderID, int IsTransformasi)
        //{
        //    try
        //    {
        //        if (Session["PersonalNumber"] == null)
        //        {
        //            return RedirectToAction("Login", "Login");
        //        }
        //        else
        //        {
        //            Session["IsTransformasi"] = IsTransformasi;

        //            ExecutionReportModel erm = new ExecutionReportModel();

        //            erm.IDProjectHeader = ProjectHeaderID;
        //            erm.IsTransformasi = IsTransformasi;
        //            erm.Keys = Session["PersonalNumber"].ToString();

        //            Models.UserManagementModels.MultiPorpose MP = new Models.UserManagementModels.MultiPorpose();
        //            HttpClient client = new HttpClient();
        //            string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EksekusiReport";
        //            Uri baseAddress = new Uri(url);

        //            client.BaseAddress = baseAddress;
        //            client.DefaultRequestHeaders.Accept.Clear();

        //            var response = client.PostAsJsonAsync(baseAddress.ToString(), erm).Result;
        //            var result = response.Content.ReadAsStringAsync().Result;

        //            List<ExecutionReportModel> DetailEksekusi = JsonConvert.DeserializeObject<List<ExecutionReportModel>>(result);

        //            // Past

        //            HttpClient clientPast = new HttpClient();
        //            string urlPast = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EksekusiReport";
        //            Uri baseAddressPast = new Uri(urlPast);

        //            clientPast.BaseAddress = baseAddressPast;
        //            clientPast.DefaultRequestHeaders.Accept.Clear();

        //            var responsePast = clientPast.PutAsJsonAsync(baseAddressPast.ToString(), erm).Result;
        //            var resultPast = responsePast.Content.ReadAsStringAsync().Result;

        //            List<ExecutionReportModel> DetailEksekusiPast = JsonConvert.DeserializeObject<List<ExecutionReportModel>>(resultPast);

        //            // ALL

        //            HttpClient clientALL = new HttpClient();
        //            string urlALL = ConfigurationManager.AppSettings["WebAPI"].ToString() + "TrendRealisasi";
        //            Uri baseAddressALL = new Uri(urlALL);

        //            clientALL.BaseAddress = baseAddressALL;
        //            clientALL.DefaultRequestHeaders.Accept.Clear();

        //            var responseALL = clientALL.PostAsJsonAsync(baseAddressALL.ToString(), erm).Result;
        //            var resultALL = responseALL.Content.ReadAsStringAsync().Result;

        //            List<ExecutionReportModel> DetailEksekusiALL = JsonConvert.DeserializeObject<List<ExecutionReportModel>>(resultALL);


        //            // Status

        //            HttpClient clientStatus = new HttpClient();
        //            string urlStatus = ConfigurationManager.AppSettings["WebAPI"].ToString() + "TrendRealisasi";
        //            Uri baseAddressStatus = new Uri(urlStatus);

        //            clientStatus.BaseAddress = baseAddressStatus;
        //            clientStatus.DefaultRequestHeaders.Accept.Clear();

        //            var responseStatus = clientStatus.PutAsJsonAsync(baseAddressStatus.ToString(), erm).Result;
        //            var resultStatus = responseStatus.Content.ReadAsStringAsync().Result;

        //            string StatusTombol = JsonConvert.DeserializeObject<string>(resultStatus);

        //            ExecutionReportModelList List = new ExecutionReportModelList();

        //            List.All = DetailEksekusiALL;
        //            List.Current = DetailEksekusi;
        //            List.Without = DetailEksekusiPast;
        //            List.StatusTombol = StatusTombol;

        //            return View(List);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public string GetMPPExecution(string ProjectHeaderID)
        {
            try
            {
                Models.UserManagementModels.MultiPorpose MP = new Models.UserManagementModels.MultiPorpose();
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "ExecCRUD";
                Uri baseAddress = new Uri(url);

                MP.ID = ProjectHeaderID;
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), MP).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                MPPDHTMLXEksekusi ListMPP = JsonConvert.DeserializeObject<MPPDHTMLXEksekusi>(result);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult MilestoneDetail(string ProjectHeaderID, string TaskID, string MilestoneStatus)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    var param = ProjectHeaderID + "|" + TaskID;

                    Models.UserManagementModels.MultiPorpose MP = new Models.UserManagementModels.MultiPorpose();

                    MP.ID = param;

                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EksekusiMilestone";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), MP).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    var Role = (List<Roleproj>)Session["EksekusiRole"];
                    var SysRole = Session["SysRole"].ToString();

                    EksekusiMilestone DetailMilestone = JsonConvert.DeserializeObject<EksekusiMilestone>(result);

                    DetailMilestone.MilestoneStatus = MilestoneStatus;

                    ViewBag.Role = Role;
                    ViewBag.Sysrole = SysRole;

                    return View(DetailMilestone);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult AddRealisasi(int ProjectHeaderID, int IsTransformasi)
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "TrendRealisasi" + "?erm=" + Convert.ToInt32(ProjectHeaderID) + "&Persnum=" + Session["PersonalNumber"];
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.GetAsync(baseAddress.ToString()).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                return RedirectToAction("ExecReport", "ProjectExec", new { ProjectHeaderID = ProjectHeaderID, IsTransformasi = IsTransformasi });
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult CheckBeforePeriode(CheckBeforePeriodeModel param)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EksekusiCheckBeforePeriode";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), param).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    string data = JsonConvert.DeserializeObject<string>(result);
                    string[] hasil = data.Split('|');

                    if (hasil[0] == "S") return Json(new { Result = "Success", Message = hasil[1] });
                    else return Json(new { Result = "Failed", Message = hasil[1] });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Failed", Message = ex.Message });
            }
        }

        #endregion

        #region New Project Execution
        public ActionResult Exec()
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EksekusiList";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    MP.ID = Session["PersonalNumber"].ToString();

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), MP).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<ExecutionModel> ListEksekusi = JsonConvert.DeserializeObject<List<ExecutionModel>>(result);

                    return View(ListEksekusi);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult ExecReport(int ProjectHeaderID, int IsTransformasi)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    Session["IsTransformasi"] = IsTransformasi;

                    ExecutionReportModel erm = new ExecutionReportModel();

                    erm.IDProjectHeader = ProjectHeaderID;
                    erm.IsTransformasi = IsTransformasi;
                    erm.Keys = Session["PersonalNumber"].ToString();

                    Models.UserManagementModels.MultiPorpose MP = new Models.UserManagementModels.MultiPorpose();
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EksekusiReport";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), erm).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<ExecutionReportModel> DetailEksekusi = JsonConvert.DeserializeObject<List<ExecutionReportModel>>(result);

                    // Past

                    HttpClient clientPast = new HttpClient();
                    string urlPast = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EksekusiReport";
                    Uri baseAddressPast = new Uri(urlPast);

                    clientPast.BaseAddress = baseAddressPast;
                    clientPast.DefaultRequestHeaders.Accept.Clear();

                    var responsePast = clientPast.PutAsJsonAsync(baseAddressPast.ToString(), erm).Result;
                    var resultPast = responsePast.Content.ReadAsStringAsync().Result;

                    List<ExecutionReportModel> DetailEksekusiPast = JsonConvert.DeserializeObject<List<ExecutionReportModel>>(resultPast);

                    // ALL

                    HttpClient clientALL = new HttpClient();
                    string urlALL = ConfigurationManager.AppSettings["WebAPI"].ToString() + "TrendRealisasi";
                    Uri baseAddressALL = new Uri(urlALL);

                    clientALL.BaseAddress = baseAddressALL;
                    clientALL.DefaultRequestHeaders.Accept.Clear();

                    var responseALL = clientALL.PostAsJsonAsync(baseAddressALL.ToString(), erm).Result;
                    var resultALL = responseALL.Content.ReadAsStringAsync().Result;

                    List<ExecutionReportModel> DetailEksekusiALL = JsonConvert.DeserializeObject<List<ExecutionReportModel>>(resultALL);


                    // Status

                    HttpClient clientStatus = new HttpClient();
                    string urlStatus = ConfigurationManager.AppSettings["WebAPI"].ToString() + "TrendRealisasi";
                    Uri baseAddressStatus = new Uri(urlStatus);

                    clientStatus.BaseAddress = baseAddressStatus;
                    clientStatus.DefaultRequestHeaders.Accept.Clear();

                    var responseStatus = clientStatus.PutAsJsonAsync(baseAddressStatus.ToString(), erm).Result;
                    var resultStatus = responseStatus.Content.ReadAsStringAsync().Result;

                    string StatusTombol = JsonConvert.DeserializeObject<string>(resultStatus);

                    ExecutionReportModelList List = new ExecutionReportModelList();

                    List.All = DetailEksekusiALL;
                    List.Current = DetailEksekusi;
                    List.Without = DetailEksekusiPast;
                    List.StatusTombol = StatusTombol;

                    return View(List);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
 
        public ActionResult ExecCreate(int ProjectHeaderID, string Keys)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    Session["keys"] = Keys;
                    string Persnum = Session["PersonalNumber"].ToString();
                    Models.UserManagementModels.MultiPorpose MP = new Models.UserManagementModels.MultiPorpose();
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "ExecCRUDDetail?ProjectID=" + ProjectHeaderID + "&Periode=" + Keys + "&Persnum=" + Persnum;
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.GetAsync(baseAddress.ToString()).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    EksekusiModel DetailEksekusi = JsonConvert.DeserializeObject<EksekusiModel>(result);

                    if (DetailEksekusi.Role == null)
                    {
                        var zz = new List<Roleproj>();
                        Session["EksekusiRole"] = zz;
                        Session["SysRole"] = DetailEksekusi.Sysrole;
                    }
                    else
                    {
                        Session["EksekusiRole"] = DetailEksekusi.Role;
                        Session["SysRole"] = DetailEksekusi.Sysrole;
                    }

                    return View(DetailEksekusi);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult ExecTab1(int ProjectHeaderID, string Keys)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    Session["keys"] = Keys;
                    string Persnum = Session["PersonalNumber"].ToString();
                    Models.UserManagementModels.MultiPorpose MP = new Models.UserManagementModels.MultiPorpose();
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "ExecCRUDDetail?ProjectID=" + ProjectHeaderID + "&Periode=" + Keys + "&Persnum=" + Persnum;
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.GetAsync(baseAddress.ToString()).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    EksekusiModel DetailEksekusi = JsonConvert.DeserializeObject<EksekusiModel>(result);

                    if (DetailEksekusi.Role == null)
                    {
                        var zz = new List<Roleproj>();
                        Session["EksekusiRole"] = zz;
                        Session["SysRole"] = DetailEksekusi.Sysrole;
                    }
                    else
                    {
                        Session["EksekusiRole"] = DetailEksekusi.Role;
                        Session["SysRole"] = DetailEksekusi.Sysrole;
                    }

                    return View(DetailEksekusi);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult ExecTab2(int ProjectHeaderID, string Keys)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    Session["keys"] = Keys;
                    string Persnum = Session["PersonalNumber"].ToString();
                    Models.UserManagementModels.MultiPorpose MP = new Models.UserManagementModels.MultiPorpose();
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "ExecCRUDApproval?ProjectID=" + ProjectHeaderID + "&Periode=" + Keys + "&Persnum=" + Persnum;
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.GetAsync(baseAddress.ToString()).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    EksekusiModel DetailEksekusi = JsonConvert.DeserializeObject<EksekusiModel>(result);

                    if (DetailEksekusi.Role == null)
                    {
                        var zz = new List<Roleproj>();
                        Session["EksekusiRole"] = zz;
                        Session["SysRole"] = DetailEksekusi.Sysrole;
                    }
                    else
                    {
                        Session["EksekusiRole"] = DetailEksekusi.Role;
                        Session["SysRole"] = DetailEksekusi.Sysrole;
                    }

                    return View(DetailEksekusi);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult ExecTab3(int ProjectHeaderID, string Keys)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    Session["keys"] = Keys;
                    string Persnum = Session["PersonalNumber"].ToString();
                    Models.UserManagementModels.MultiPorpose MP = new Models.UserManagementModels.MultiPorpose();
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "ExecCRUDApprovalLog?ProjectID=" + ProjectHeaderID + "&Periode=" + Keys + "&Persnum=" + Persnum;
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.GetAsync(baseAddress.ToString()).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    EksekusiModel DetailEksekusi = JsonConvert.DeserializeObject<EksekusiModel>(result);

                    if (DetailEksekusi.Role == null)
                    {
                        var zz = new List<Roleproj>();
                        Session["EksekusiRole"] = zz;
                        Session["SysRole"] = DetailEksekusi.Sysrole;
                    }
                    else
                    {
                        Session["EksekusiRole"] = DetailEksekusi.Role;
                        Session["SysRole"] = DetailEksekusi.Sysrole;
                    }

                    return View(DetailEksekusi);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult ExecTab4(int ProjectHeaderID, string Keys)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    Session["keys"] = Keys;
                    string Persnum = Session["PersonalNumber"].ToString();
                    Models.UserManagementModels.MultiPorpose MP = new Models.UserManagementModels.MultiPorpose();
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "ExecCRUDTrend?ProjectID=" + ProjectHeaderID + "&Periode=" + Keys + "&Persnum=" + Persnum;
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.GetAsync(baseAddress.ToString()).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    EksekusiModel DetailEksekusi = JsonConvert.DeserializeObject<EksekusiModel>(result);

                    if (DetailEksekusi.Role == null)
                    {
                        var zz = new List<Roleproj>();
                        Session["EksekusiRole"] = zz;
                        Session["SysRole"] = DetailEksekusi.Sysrole;
                    }
                    else
                    {
                        Session["EksekusiRole"] = DetailEksekusi.Role;
                        Session["SysRole"] = DetailEksekusi.Sysrole;
                    }

                    return View(DetailEksekusi);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult ExecTab5(int ProjectHeaderID, string Keys)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    Session["keys"] = Keys;
                    string Persnum = Session["PersonalNumber"].ToString();
                    Models.UserManagementModels.MultiPorpose MP = new Models.UserManagementModels.MultiPorpose();
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "ExecCRUDProcurement?ProjectID=" + ProjectHeaderID + "&Periode=" + Keys + "&Persnum=" + Persnum;
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.GetAsync(baseAddress.ToString()).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    EksekusiModel DetailEksekusi = JsonConvert.DeserializeObject<EksekusiModel>(result);

                    if (DetailEksekusi.Role == null)
                    {
                        var zz = new List<Roleproj>();
                        Session["EksekusiRole"] = zz;
                        Session["SysRole"] = DetailEksekusi.Sysrole;
                    }
                    else
                    {
                        Session["EksekusiRole"] = DetailEksekusi.Role;
                        Session["SysRole"] = DetailEksekusi.Sysrole;
                    }

                    return View(DetailEksekusi);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult ExecTab6(int ProjectHeaderID, string Keys)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    Session["keys"] = Keys;
                    string Persnum = Session["PersonalNumber"].ToString();
                    Models.UserManagementModels.MultiPorpose MP = new Models.UserManagementModels.MultiPorpose();
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "ExecCRUDLaporan?ProjectID=" + ProjectHeaderID + "&Periode=" + Keys + "&Persnum=" + Persnum;
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.GetAsync(baseAddress.ToString()).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    EksekusiModel DetailEksekusi = JsonConvert.DeserializeObject<EksekusiModel>(result);

                    if (DetailEksekusi.Role == null)
                    {
                        var zz = new List<Roleproj>();
                        Session["EksekusiRole"] = zz;
                        Session["SysRole"] = DetailEksekusi.Sysrole;
                    }
                    else
                    {
                        Session["EksekusiRole"] = DetailEksekusi.Role;
                        Session["SysRole"] = DetailEksekusi.Sysrole;
                    }

                    return View(DetailEksekusi);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Project Change Approval
        public ActionResult ExecChgAppr()
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "ExecListChgAppr";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    MP.ID = Session["PersonalNumber"].ToString();

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), MP).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<ExecutionModel> ListEksekusi = JsonConvert.DeserializeObject<List<ExecutionModel>>(result);

                    return View(ListEksekusi);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult ExecChgApprCreate(int IDProjectHeader)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    string Nama = Session["Nama"].ToString();
                    string PersonalNumber = Session["PersonalNumber"].ToString();
                    string Departement = Session["Departement"].ToString();
                    string Title = Session["Title"].ToString();
                    var RoleProject = Session["RoleProject"];

                    ProjectHeaderModel phm = new ProjectHeaderModel();
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "ExecChgAppr";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    phm.IDProjectHeader = IDProjectHeader;
                    phm.CreatedBy = PersonalNumber;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PutAsJsonAsync(baseAddress.ToString(), phm).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    ProjectHeaderModel ProjectHeader = JsonConvert.DeserializeObject<ProjectHeaderModel>(result);

                    return View(ProjectHeader);
                }
            }
            catch (Exception ex)
            {
                ProjectHeaderModel phm = new ProjectHeaderModel();
                return View(phm);
                //throw ex;
            }
        }

        public ActionResult ExecChgApprInsert(ProjectHeaderModel ProjectHeader)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "ExecChgApprCRUD";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), ProjectHeader).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    string data = JsonConvert.DeserializeObject<string>(result);
                    string[] hasil = data.Split('|');

                    if (ProjectHeader.TypeTransaction == "Submit")
                    {
                        //gh.SendEmail(ProjectHeader.IDProjectHeader.ToString(), null, "1");
                    }
                    else if (ProjectHeader.TypeTransaction == "Revise")
                    {
                        //gh.SendEmail(ProjectHeader.IDProjectHeader.ToString(), null, "4");
                    }

                    if (hasil[0] == "S") return Json(new { Result = "Success", Message = hasil[1] });
                    else return Json(new { Result = "Failed", Message = hasil[1] });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Failed", Message = ex.Message });
            }
        }
        #endregion

        #region KPI
        public ActionResult ExecKPIProject() 
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EksekusiList";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    MP.ID = Session["PersonalNumber"].ToString();

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), MP).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<ExecutionModel> ListEksekusi = JsonConvert.DeserializeObject<List<ExecutionModel>>(result);

                    return View(ListEksekusi);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult ExecKPIProjectDetil()
        {
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}