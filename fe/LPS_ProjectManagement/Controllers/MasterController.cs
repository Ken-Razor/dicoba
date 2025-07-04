using LPS_ProjectManagement.Helper;
using LPS_ProjectManagement.Models.MasterDataModels;
using LPS_ProjectManagement.Models.SAPModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Excel;
using sun.util.resources.cldr.rw;
//using OfficeOpenXml;
//using OfficeOpenXml.Style;

namespace LPS_ProjectManagement.Controllers
{
    public class MasterController : Controller
    {
        // GET: Master
        #region Master Program
        public ActionResult MasterProgram()
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else {
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterProgram";
                    Uri baseAddress = new Uri(url);
                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.GetAsync(baseAddress.ToString()).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<ProgramModel> ListProgram = JsonConvert.DeserializeObject<List<ProgramModel>>(result);

                    return View(ListProgram);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult DetailProgram(int IDProgram)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    ProgramModel pm = new ProgramModel();
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterProgram";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    pm.IDProgram = IDProgram;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), pm).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    ProgramModel ProgramModel = JsonConvert.DeserializeObject<ProgramModel>(result);

                    string Dekripsi = "";
                    if (ProgramModel.Description != null)
                    {
                        Dekripsi = ProgramModel.Description.Replace('{', '<').Replace('}', '>');
                        ProgramModel.Description = Dekripsi;
                    }

                    return View(ProgramModel);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult InsertProgram(ProgramModel Program)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterProgramCRUD";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), Program).Result;
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

        public ActionResult UpdateProgram(ProgramModel Program)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterProgramCRUD";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PutAsJsonAsync(baseAddress.ToString(), Program).Result;
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

        public ActionResult DeleteProgram(ProgramModel Program)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterProgramCRUD?IDProgram=" + Program.IDProgram;
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.DeleteAsync(baseAddress.ToString()).Result;
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

        #region Master Project
        public ActionResult MasterProyek()
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterProject";
                    Uri baseAddress = new Uri(url);
                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.GetAsync(baseAddress.ToString()).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<ProjectModel> ListProject = JsonConvert.DeserializeObject<List<ProjectModel>>(result);

                    return View(ListProject);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult DetailProyek(int IDProject)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    ProjectModel pm = new ProjectModel();
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterProject";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    pm.IDProject = IDProject;


                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), pm).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    ProjectModel ProjectModel = JsonConvert.DeserializeObject<ProjectModel>(result);

                    return View(ProjectModel);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult TableSAPRkAT(RKATModel RKAT)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "SAPRKAT";
                    Uri baseAddress = new Uri(url);
                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), RKAT).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        List<RKATModel> ListRKAT = JsonConvert.DeserializeObject<List<RKATModel>>(result);

                        return Json(new { ListRKAT });
                    }
                    else
                    {
                        return Json(new { GetData = "Terdapat Masalah Dengan Koneksi" });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult TableMasterKPI(KPIOrganizationModel KPIO)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    if (KPIO.KPIName != null)
                    {
                        HttpClient client = new HttpClient();
                        string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterKPIOrganization";
                        Uri baseAddress = new Uri(url);
                        client.BaseAddress = baseAddress;

                        client.DefaultRequestHeaders.Accept.Clear();

                        var response = client.PutAsJsonAsync(baseAddress.ToString(), KPIO).Result;

                        if (response.IsSuccessStatusCode)
                        {
                            var result = response.Content.ReadAsStringAsync().Result;
                            List<KPIOrganizationModel> ListKPIOrganization = JsonConvert.DeserializeObject<List<KPIOrganizationModel>>(result);

                            return Json(new { ListKPIOrganization });
                        }
                        else
                        {
                            return Json(new { GetData = "Terdapat Masalah Dengan Koneksi" });
                        }
                    }
                    else
                    {
                        List<KPIOrganizationModel> ListKPIOrganization = new List<KPIOrganizationModel>();
                        return Json(new { ListKPIOrganization });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult TableMasterUnitKerja(DepartmentModel dep)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    if (dep.DepartmentName != null)
                    {
                        HttpClient client = new HttpClient();
                        string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterDepartment";
                        Uri baseAddress = new Uri(url);
                        client.BaseAddress = baseAddress;

                        client.DefaultRequestHeaders.Accept.Clear();

                        var response = client.PutAsJsonAsync(baseAddress.ToString(), dep).Result;

                        if (response.IsSuccessStatusCode)
                        {
                            var result = response.Content.ReadAsStringAsync().Result;
                            List<DepartmentModel> ListDepartment = JsonConvert.DeserializeObject<List<DepartmentModel>>(result);

                            return Json(new { ListDepartment });
                        }
                        else
                        {
                            return Json(new { GetData = "Terdapat Masalah Dengan Koneksi" });
                        }
                    }
                    else
                    {
                        List<DepartmentModel> ListDepartment = new List<DepartmentModel>();
                        return Json(new { ListDepartment });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult InsertProyek(ProjectModel Project)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    UploadController UC = new UploadController();

                   // UC.CreateFolder(Project.ProjectName);

                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterProjectCRUD";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), Project).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    string data = JsonConvert.DeserializeObject<string>(result);
                    string[] hasil = data.Split('|');
                 
                    GlobalHelper GH = new GlobalHelper();
                    UC.CreateFolder(hasil[2]);
                    if (hasil[0] == "S") return Json(new { Result = "Success", Message = hasil[1] });
                    else return Json(new { Result = "Failed", Message = hasil[1] });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Failed", Message = ex.Message });
            }
        }
        
        public ActionResult UpdateProyek(ProjectModel Project)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    GlobalHelper GH = new GlobalHelper();
                    //string oldname = GH.GetProjectNameMaster(Project.IDProject);

                    //if (oldname != Project.ProjectName)
                    //{
                    //    UploadController UC = new UploadController();
                    //    UC.CreateFolder(Project.ProjectName);
                    //}
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterProjectCRUD";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PutAsJsonAsync(baseAddress.ToString(), Project).Result;
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

        public ActionResult DeleteProyek(ProjectModel Project)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterProjectCRUD?IDProject=" + Project.IDProject + "&TypeTransaction=" + Project.Description;
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.DeleteAsync(baseAddress.ToString()).Result;
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

        #region Master Strategic Objective
        public ActionResult MasterSO()
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterStrategicObjective";
                    Uri baseAddress = new Uri(url);
                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.GetAsync(baseAddress.ToString()).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<StrategicObjectiveModel> ListStrategicObjective = JsonConvert.DeserializeObject<List<StrategicObjectiveModel>>(result);

                    return View(ListStrategicObjective);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult DetailMasterSO(int IDStrategicObjective)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    StrategicObjectiveModel som = new StrategicObjectiveModel();
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterStrategicObjective";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    som.IDStrategicObjective = IDStrategicObjective;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), som).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    StrategicObjectiveModel StrategicObjective = JsonConvert.DeserializeObject<StrategicObjectiveModel>(result);

                    return View(StrategicObjective);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult InsertMasterSO(StrategicObjectiveModel StrategicObjective)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterStrategicObjectiveCRUD";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), StrategicObjective).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    string data = JsonConvert.DeserializeObject<string>(result);
                    string[] hasil = data.Split('|');

                    if (hasil[0] == "S") return Json(new { Result = "Success", Message = hasil[1] });
                    else return Json(new { Result = "Failed", Message = hasil[1] });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult UpdateMasterSO(StrategicObjectiveModel StrategicObjective)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterStrategicObjectiveCRUD";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PutAsJsonAsync(baseAddress.ToString(), StrategicObjective).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    string data = JsonConvert.DeserializeObject<string>(result);
                    string[] hasil = data.Split('|');

                    if (hasil[0] == "S") return Json(new { Result = "Success", Message = hasil[1] });
                    else return Json(new { Result = "Failed", Message = hasil[1] });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult DeleteMasterSO(StrategicObjectiveModel StrategicObjective)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterStrategicObjectiveCRUD?IDStrategicObjective=" + StrategicObjective.IDStrategicObjective;
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.DeleteAsync(baseAddress.ToString()).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    string data = JsonConvert.DeserializeObject<string>(result);
                    string[] hasil = data.Split('|');

                    if (hasil[0] == "S") return Json(new { Result = "Success", Message = hasil[1] });
                    else return Json(new { Result = "Failed", Message = hasil[1] });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Master KPI
        public ActionResult MasterKPI()
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterKPIOrganization";
                    Uri baseAddress = new Uri(url);
                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.GetAsync(baseAddress.ToString()).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<KPIOrganizationModel> ListKPIOrganization = JsonConvert.DeserializeObject<List<KPIOrganizationModel>>(result);

                    return View(ListKPIOrganization);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult DetailKPI(int IDKPIOrganization)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    KPIOrganizationModel kpiom = new KPIOrganizationModel();
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterKPIOrganization";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    kpiom.IDKPIOrganization = IDKPIOrganization;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), kpiom).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    KPIOrganizationModel KPIOrganization = JsonConvert.DeserializeObject<KPIOrganizationModel>(result);

                    return View(KPIOrganization);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult InsertKPI(KPIOrganizationModel KPIOrganization)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterKPIOrganizationCRUD";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), KPIOrganization).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    string data = JsonConvert.DeserializeObject<string>(result);
                    string[] hasil = data.Split('|');

                    if (hasil[0] == "S") return Json(new { Result = "Success", Message = hasil[1] });
                    else return Json(new { Result = "Failed", Message = hasil[1] });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult UpdateKPI(KPIOrganizationModel KPIOrganization)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterKPIOrganizationCRUD";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PutAsJsonAsync(baseAddress.ToString(), KPIOrganization).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    string data = JsonConvert.DeserializeObject<string>(result);
                    string[] hasil = data.Split('|');

                    if (hasil[0] == "S") return Json(new { Result = "Success", Message = hasil[1] });
                    else return Json(new { Result = "Failed", Message = hasil[1] });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult DeleteKPI(KPIOrganizationModel KPIOrganization)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterKPIOrganizationCRUD?IDKPIOrganization=" + KPIOrganization.IDKPIOrganization;
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.DeleteAsync(baseAddress.ToString()).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    string data = JsonConvert.DeserializeObject<string>(result);
                    string[] hasil = data.Split('|');

                    if (hasil[0] == "S") return Json(new { Result = "Success", Message = hasil[1] });
                    else return Json(new { Result = "Failed", Message = hasil[1] });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        #endregion

        #region Master KPI Value

        public ActionResult MasterKPIValue()
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterKPIValue";
                    Uri baseAddress = new Uri(url);
                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.GetAsync(baseAddress.ToString()).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<KPIValueModel> ListKPIValueModel = JsonConvert.DeserializeObject<List<KPIValueModel>>(result);

                    return View(ListKPIValueModel);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult DetailKPIValue(KPIValueModel obj)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterKPIValue";
                    Uri baseAddress = new Uri(url);
                    obj.PersonNumber = Session["PersonalNumber"].ToString();

                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), obj).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    KPIValueModel KPIValueModel = JsonConvert.DeserializeObject<KPIValueModel>(result);
                    
                    return View(KPIValueModel);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult UpdateKPIValue(KPIValueModel obj)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterKPIValueCRUD";
                    Uri baseAddress = new Uri(url);

                    obj.PersonNumber = Session["PersonalNumber"].ToString();
                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), obj).Result;
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
        
        public ActionResult GenerateKPIValue()
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterKPIValueGenerate";
                    Uri baseAddress = new Uri(url);

                    KPIValueModel obj = new KPIValueModel
                    {
                        PersonNumber = Session["PersonalNumber"].ToString()
                    };

                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), obj).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    string data = JsonConvert.DeserializeObject<string>(result);
                    string[] hasil = data.Split('|');

                    if (hasil[0] == "S") return Json(new { Result = "Success", Message = hasil[1] }, JsonRequestBehavior.AllowGet);
                    else return Json(new { Result = "Failed", Message = hasil[1] }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Failed", Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        #endregion

        #region Master Project Cost
        public ActionResult MasterProyekCost()
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterProjectCost";
                    Uri baseAddress = new Uri(url);
                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Accept.Clear();
                    var response = client.GetAsync(baseAddress.ToString()).Result;
                    var result = response.Content.ReadAsStringAsync().Result;
                   
                    var ListProjectCost = JsonConvert.DeserializeObject<List<ProjectCostModel>>(result);
                    if(ListProjectCost.Count <= 0)
                    {
                        ListProjectCost = new List<ProjectCostModel>();
                        ListProjectCost.Add(new ProjectCostModel{NoUrut=0});
                    }
                    return View(ListProjectCost);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult MasterProyekCostJson()
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterProjectCost";
                    Uri baseAddress = new Uri(url);
                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.GetAsync(baseAddress.ToString()).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<ProjectCostModel> ListProjectCost = JsonConvert.DeserializeObject<List<ProjectCostModel>>(result);

                    return Json(new { data = ListProjectCost }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult MasterProyekCostByName(ProjectCostModel ProjectCost)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    if (ProjectCost.ProjectCostName != null)
                    {
                        HttpClient client = new HttpClient();
                        string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterProjectCost";
                        Uri baseAddress = new Uri(url);
                        client.BaseAddress = baseAddress;

                        client.DefaultRequestHeaders.Accept.Clear();

                        var response = client.PutAsJsonAsync(baseAddress.ToString(), ProjectCost).Result;

                        if (response.IsSuccessStatusCode)
                        {
                            var result = response.Content.ReadAsStringAsync().Result;
                            List<ProjectCostModel> ListProjectCost = JsonConvert.DeserializeObject<List<ProjectCostModel>>(result);

                            return Json(new { ListProjectCost });
                        }
                        else
                        {
                            return Json(new { GetData = "Terdapat Masalah Dengan Koneksi" });
                        }
                    }
                    else
                    {
                        List<ProjectCostModel> ListProjectCost = new List<ProjectCostModel>();
                        return Json(new { ListProjectCost });
                    }
                }  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult MasterProyekCostByID(ProjectCostModel ProjectCost)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterProjectCost";
                    Uri baseAddress = new Uri(url);
                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), ProjectCost).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        ProjectCost = JsonConvert.DeserializeObject<ProjectCostModel>(result);

                        return Json(new { ProjectCost });
                    }
                    else
                    {
                        return Json(new { GetData = "Terdapat Masalah Dengan Koneksi" });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult DetailProyekCost(int IDProjectCost)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    ProjectCostModel pcm = new ProjectCostModel();
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterProjectCost";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    pcm.IDProjectCost = IDProjectCost;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), pcm).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    ProjectCostModel ProjectCost = JsonConvert.DeserializeObject<ProjectCostModel>(result);

                    return View(ProjectCost);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult InsertProyekCost(ProjectCostModel ProjectCost)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterProjectCostCRUD";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), ProjectCost).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    string data = JsonConvert.DeserializeObject<string>(result);
                    string[] hasil = data.Split('|');

                    if (hasil[0] == "S") return Json(new { Result = "Success", Message = hasil[1] });
                    else return Json(new { Result = "Failed", Message = hasil[1] });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult UpdateProyekCost(ProjectCostModel ProjectCost)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterProjectCostCRUD";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PutAsJsonAsync(baseAddress.ToString(), ProjectCost).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    string data = JsonConvert.DeserializeObject<string>(result);
                    string[] hasil = data.Split('|');

                    if (hasil[0] == "S") return Json(new { Result = "Success", Message = hasil[1] });
                    else return Json(new { Result = "Failed", Message = hasil[1] });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult DeleteProyekCost(ProjectCostModel ProjectCost)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterProjectCostCRUD?IDProjectCost=" + ProjectCost.IDProjectCost;
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.DeleteAsync(baseAddress.ToString()).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    string data = JsonConvert.DeserializeObject<string>(result);
                    string[] hasil = data.Split('|');

                    if (hasil[0] == "S") return Json(new { Result = "Success", Message = hasil[1] });
                    else return Json(new { Result = "Failed", Message = hasil[1] });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        #endregion

        #region Master Department
        public ActionResult MasterDepartement()
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterDepartment";
                    Uri baseAddress = new Uri(url);
                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.GetAsync(baseAddress.ToString()).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<DepartmentModel> ListDepartment = JsonConvert.DeserializeObject<List<DepartmentModel>>(result);

                    return View(ListDepartment);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult DetailDepartment(int IDDepartment)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    DepartmentModel dm = new DepartmentModel();
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterDepartment";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    dm.IDDepartment = IDDepartment;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), dm).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    DepartmentModel Department = JsonConvert.DeserializeObject<DepartmentModel>(result);

                    string Dekripsi = "";
                    if (Department.Description != null)
                    {
                        Dekripsi = Department.Description;
                        Department.Description = Dekripsi.Replace('{', '<').Replace('}', '>');
                    }

                    return View(Department);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult InsertDepartment(DepartmentModel Department)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterDepartmentCRUD";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), Department).Result;
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

        public ActionResult UpdateDepartment(DepartmentModel Department)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterDepartmentCRUD";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PutAsJsonAsync(baseAddress.ToString(), Department).Result;
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

        public ActionResult DeleteDepartment(DepartmentModel Department)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterDepartmentCRUD?IDDepartment=" + Department.IDDepartment;
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.DeleteAsync(baseAddress.ToString()).Result;
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

        #region Master Project Group
        public ActionResult MasterProjectGroup()
        {
            return View();
        }

        public ActionResult DetailProjectGroup()
        {
            return View();
        }
        #endregion

        #region Direktorat
        public ActionResult MasterDirektoratJson()
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterDirektorat";
                    Uri baseAddress = new Uri(url);
                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.GetAsync(baseAddress.ToString()).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<DirektoratModel> ListProgram = JsonConvert.DeserializeObject<List<DirektoratModel>>(result);

                    //return View(ListProgram);
                    return Json(new { data = ListProgram }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Kategori Project
        public ActionResult MasterKategoriProject()
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterKategoriProject";
                    Uri baseAddress = new Uri(url);
                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.GetAsync(baseAddress.ToString()).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<ProjectKategoriModel> ListKategori = JsonConvert.DeserializeObject<List<ProjectKategoriModel>>(result);

                    return View(ListKategori);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult DetailKategoriProject(int IDKategoriProject)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    ProjectKategoriModel pkm = new ProjectKategoriModel();
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterKategoriProject";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    pkm.IDKategoriProject = IDKategoriProject;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), pkm).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    ProjectKategoriModel PkModel = JsonConvert.DeserializeObject<ProjectKategoriModel>(result);

                    string Dekripsi = "";
                    if (PkModel.Description != null)
                    {
                        Dekripsi = PkModel.Description.Replace('{', '<').Replace('}', '>');
                        PkModel.Description = Dekripsi;
                    }

                    return View(PkModel);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult InsertKategoriProject(ProjectKategoriModel Kategori)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterKategoriProjectCRUD";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), Kategori).Result;
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

        public ActionResult UpdateKategoriProject(ProjectKategoriModel Kategori)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterKategoriProjectCRUD";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PutAsJsonAsync(baseAddress.ToString(), Kategori).Result;
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

        public ActionResult DeleteKategoriProject(ProjectKategoriModel Kategori)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterKategoriProjectCRUD?IDKategoriProject=" + Kategori.IDKategoriProject;
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.DeleteAsync(baseAddress.ToString()).Result;
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

        #region Master SLA
        public ActionResult MasterSLA()
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterSla";
                    Uri baseAddress = new Uri(url);
                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.GetAsync(baseAddress.ToString()).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<MasterSLAModel> ListProgram = JsonConvert.DeserializeObject<List<MasterSLAModel>>(result);

                    return View(ListProgram);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult DetailSLA(int Id)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    MasterSLAModel dm = new MasterSLAModel();
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterSla";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    dm.Id = Id;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), dm).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    MasterSLAModel sla = JsonConvert.DeserializeObject<MasterSLAModel>(result);

                    return View(sla);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult InsertSLA(MasterSLAModel Program)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterSlaCRUD";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), Program).Result;
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
        public ActionResult UpdateSLA(MasterSLAModel Program)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterSlaCRUD";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PutAsJsonAsync(baseAddress.ToString(), Program).Result;
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
        public ActionResult DeleteSLA(MasterSLAModel Program)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterSlaCRUD?Id=" + Program.Id;
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.DeleteAsync(baseAddress.ToString()).Result;
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

        #region Holiday
        public ActionResult MasterHoliday()
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
                    client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterHoliday";
                    Uri baseAddress = new Uri(url);
                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Accept.Clear();
                    var response = client.PostAsJsonAsync(baseAddress.ToString(), string.Empty).Result;
                    var result = response.Content.ReadAsStringAsync().Result;
                    List<ddlYear> ListDdl = JsonConvert.DeserializeObject<List<ddlYear>>(result);

                    return View(ListDdl);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult GetHolidays(int tahun)
        {
            HttpClient client = new HttpClient();
            string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterHoliday?tahun=" + tahun;
            Uri baseAddress = new Uri(url);
            client.BaseAddress = baseAddress;

            client.DefaultRequestHeaders.Accept.Clear();

            var response = client.GetAsync(baseAddress.ToString()).Result;
            var result = response.Content.ReadAsStringAsync().Result;

            List<MasterHolidayModel> res = new List<MasterHolidayModel>();
            try
            {
                res = JsonConvert.DeserializeObject<List<MasterHolidayModel>>(result);
            }
            catch (JsonException ex)
            {
                Console.WriteLine("JSON deserialization error: " + ex.Message);
            }

            return Json(new { data = res });
        }

        public ActionResult DetailHoliday(int Id)
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
                    client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterDetailHoliday?Id="+Id;
                    Uri baseAddress = new Uri(url);
                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Accept.Clear();
                    var response = client.GetAsync(baseAddress.ToString()).Result;
                    var result = response.Content.ReadAsStringAsync().Result;
                    MasterHolidayModel sla = JsonConvert.DeserializeObject<MasterHolidayModel>(result);

                    return View(sla);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult InsertHoliday(MasterHolidayModel Program)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterHolidayCRUD";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), Program).Result;
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
        public ActionResult DeleteHoliday(MasterSLAModel Program)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterHolidayCRUD?Id=" + Program.Id;
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.DeleteAsync(baseAddress.ToString()).Result;
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

    }
}