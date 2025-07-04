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

namespace LPS_ProjectManagement.Controllers
{
    public class ProjectInitController : Controller
    {
        readonly GlobalHelper gh = new GlobalHelper();

        // GET: ProjectInit
        #region Project Initiation

        //public ActionResult ProjectInitiation()
        //{
        //    try
        //    {
        //        if (Session["PersonalNumber"] == null)
        //        {
        //            return RedirectToAction("Login", "Login");
        //        }
        //        else
        //        {
        //            ProjectHeaderModel phm = new ProjectHeaderModel();
        //            HttpClient client = new HttpClient();
        //            string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "Initiation";
        //            Uri baseAddress = new Uri(url);

        //            client.BaseAddress = baseAddress;
        //            phm.CreatedBy = Session["PersonalNumber"].ToString();

        //            client.DefaultRequestHeaders.Accept.Clear();

        //            var response = client.PostAsJsonAsync(baseAddress.ToString(), phm).Result;
        //            var result = response.Content.ReadAsStringAsync().Result;

        //            List<ProjectHeaderModel> ListProjectHeader = JsonConvert.DeserializeObject<List<ProjectHeaderModel>>(result);

        //            return View(ListProjectHeader);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public ActionResult ProjectInitiationCreate(int IDProjectHeader)
        //{
        //    try
        //    {
        //        if (Session["PersonalNumber"] == null)
        //        {
        //            return RedirectToAction("Login", "Login");
        //        }
        //        else
        //        {
        //            string Nama = Session["Nama"].ToString();
        //            string PersonalNumber = Session["PersonalNumber"].ToString();
        //            string Departement = Session["Departement"].ToString();
        //            string Title = Session["Title"].ToString();
        //            var RoleProject = Session["RoleProject"];

        //            ProjectHeaderModel phm = new ProjectHeaderModel();
        //            HttpClient client = new HttpClient();
        //            string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "Initiation";
        //            Uri baseAddress = new Uri(url);

        //            client.BaseAddress = baseAddress;
        //            phm.IDProjectHeader = IDProjectHeader;
        //            phm.CreatedBy = PersonalNumber;

        //            client.DefaultRequestHeaders.Accept.Clear();

        //            var response = client.PutAsJsonAsync(baseAddress.ToString(), phm).Result;
        //            var result = response.Content.ReadAsStringAsync().Result;

        //            ProjectHeaderModel ProjectHeader = JsonConvert.DeserializeObject<ProjectHeaderModel>(result);

        //            return View(ProjectHeader);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ProjectHeaderModel phm = new ProjectHeaderModel();
        //        return View(phm);
        //        //throw ex;
        //    }
        //}

        //public ActionResult InsertProjectInitiation(ProjectHeaderModel ProjectHeader)
        //{
        //    try
        //    {
        //        if (Session["PersonalNumber"] == null)
        //        {
        //            return RedirectToAction("Login", "Login");
        //        }
        //        else
        //        {
        //            HttpClient client = new HttpClient();
        //            string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "InitiationCRUD";
        //            Uri baseAddress = new Uri(url);

        //            client.BaseAddress = baseAddress;

        //            client.DefaultRequestHeaders.Accept.Clear();

        //            var response = client.PostAsJsonAsync(baseAddress.ToString(), ProjectHeader).Result;
        //            var result = response.Content.ReadAsStringAsync().Result;

        //            string data = JsonConvert.DeserializeObject<string>(result);
        //            string[] hasil = data.Split('|');

        //            if (ProjectHeader.TypeTransaction == "Submit")
        //            {
        //                gh.SendEmail(ProjectHeader.IDProjectHeader.ToString(), null, "1");
        //            }
        //            else if (ProjectHeader.TypeTransaction == "Revise")
        //            {
        //                gh.SendEmail(ProjectHeader.IDProjectHeader.ToString(), null, "4");
        //            }

        //            if (hasil[0] == "S") return Json(new { Result = "Success", Message = hasil[1] });
        //            else return Json(new { Result = "Failed", Message = hasil[1] });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Result = "Failed", Message = ex.Message });
        //    }
        //}

        //public ActionResult ApproveProjectInitiation(ProjectHeaderModel ProjectHeader)
        //{
        //    try
        //    {
        //        if (Session["PersonalNumber"] == null)
        //        {
        //            return RedirectToAction("Login", "Login");
        //        }
        //        else
        //        {
        //            HttpClient client = new HttpClient();
        //            string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "InitiationCRUD";
        //            Uri baseAddress = new Uri(url);

        //            client.BaseAddress = baseAddress;

        //            client.DefaultRequestHeaders.Accept.Clear();

        //            var response = client.PutAsJsonAsync(baseAddress.ToString(), ProjectHeader).Result;
        //            var result = response.Content.ReadAsStringAsync().Result;

        //            string data = JsonConvert.DeserializeObject<string>(result);
        //            string[] hasil = data.Split('|');

        //            //gh.SendEmail(ProjectHeader.IDProjectHeader.ToString(), null, "1");

        //            if (ProjectHeader.TypeTransaction == "Approve")
        //            {
        //                gh.SendEmail(ProjectHeader.IDProjectHeader.ToString(), null, "1");
        //            }
        //            else if (ProjectHeader.TypeTransaction == "Revise")
        //            {
        //                gh.SendEmail(ProjectHeader.IDProjectHeader.ToString(), null, "4");
        //            }

        //            if (hasil[0] == "S") return Json(new { Result = "Success", Message = hasil[1] });
        //            else return Json(new { Result = "Failed", Message = hasil[1] });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Result = "Failed", Message = ex.Message });
        //    }
        //}

        #endregion

        #region new initiation

        public ActionResult Init()
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    ProjectHeaderModel phm = new ProjectHeaderModel();
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "Init";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    phm.CreatedBy = Session["PersonalNumber"].ToString();

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), phm).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<ProjectHeaderModel> ListProjectHeader = JsonConvert.DeserializeObject<List<ProjectHeaderModel>>(result);

                    return View(ListProjectHeader);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult InitCreate(int IDProjectHeader)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "InitGetFormulir";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    phm.IDProjectHeader = IDProjectHeader;
                    phm.CreatedBy = PersonalNumber;
                    phm.Tag = 1;

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

        public ActionResult InitSubmit(int IDProjectHeader)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "Init";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    phm.IDProjectHeader = IDProjectHeader;
                    phm.CreatedBy = PersonalNumber;
                    phm.Tag = 1;

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
        
        public ActionResult InitTab1(int IDProjectHeader)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "InitGetFormulir";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    phm.IDProjectHeader = IDProjectHeader;
                    phm.CreatedBy = PersonalNumber;
                    phm.Tag = 1;

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

        public ActionResult InitTab2(int IDProjectHeader)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "InitGetMPPP";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    phm.IDProjectHeader = IDProjectHeader;
                    phm.CreatedBy = PersonalNumber;
                    phm.Tag = 1;

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

        public ActionResult InitTab3(int IDProjectHeader)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "InitGetStakeholder";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    phm.IDProjectHeader = IDProjectHeader;
                    phm.CreatedBy = PersonalNumber;
                    phm.Tag = 1;

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

        public ActionResult InitTab4(int IDProjectHeader)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "InitGetApprovalLog";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    phm.IDProjectHeader = IDProjectHeader;
                    phm.CreatedBy = PersonalNumber;
                    phm.Tag = 1;

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

        public ActionResult InitTab5(int IDProjectHeader)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "InitGetDocument";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    phm.IDProjectHeader = IDProjectHeader;
                    phm.CreatedBy = PersonalNumber;
                    phm.Tag = 1;

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

        public ActionResult InitInsert(ProjectHeaderModel ProjectHeader)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "InitCRUD";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), ProjectHeader).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    string data = JsonConvert.DeserializeObject<string>(result);
                    string[] hasil = data.Split('|');

                    if (ProjectHeader.TypeTransaction == "Submit")
                    {
                        gh.SendEmail(ProjectHeader.IDProjectHeader.ToString(), null, "1");
                    }
                    else if (ProjectHeader.TypeTransaction == "Revise")
                    {
                        gh.SendEmail(ProjectHeader.IDProjectHeader.ToString(), null, "4");
                    }

                    if (hasil[0] == "S") 
                        return Json(new { Result = "Success", Message = hasil[1] });
                    else 
                        return Json(new { Result = "Failed", Message = hasil[1] });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Failed", Message = ex.Message });
            }
        }

        public ActionResult InitInsertFormulir(ProjectHeaderModel ProjectHeader)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "InitCRUDFormulir";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), ProjectHeader).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    string data = JsonConvert.DeserializeObject<string>(result);
                    string[] hasil = data.Split('|');

                    if (ProjectHeader.TypeTransaction == "Submit")
                    {
                        gh.SendEmail(ProjectHeader.IDProjectHeader.ToString(), null, "1");
                    }
                    else if (ProjectHeader.TypeTransaction == "Revise")
                    {
                        gh.SendEmail(ProjectHeader.IDProjectHeader.ToString(), null, "4");
                    }

                    if (hasil[0] == "S")
                        return Json(new { Result = "Success", Message = hasil[1] });
                    else
                        return Json(new { Result = "Failed", Message = hasil[1] });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Failed", Message = ex.Message });
            }
        }

        public ActionResult InitInsertStakeholder(ProjectHeaderModel ProjectHeader)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "InitCRUDStakeholder";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), ProjectHeader).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    string data = JsonConvert.DeserializeObject<string>(result);
                    string[] hasil = data.Split('|');

                    if (ProjectHeader.TypeTransaction == "Submit")
                    {
                        gh.SendEmail(ProjectHeader.IDProjectHeader.ToString(), null, "1");
                    }
                    else if (ProjectHeader.TypeTransaction == "Revise")
                    {
                        gh.SendEmail(ProjectHeader.IDProjectHeader.ToString(), null, "4");
                    }

                    if (hasil[0] == "S")
                        return Json(new { Result = "Success", Message = hasil[1] });
                    else
                        return Json(new { Result = "Failed", Message = hasil[1] });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Failed", Message = ex.Message });
            }
        }

        public ActionResult InitApprove(ProjectHeaderModel ProjectHeader)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "InitCRUD";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PutAsJsonAsync(baseAddress.ToString(), ProjectHeader).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    string data = JsonConvert.DeserializeObject<string>(result);
                    string[] hasil = data.Split('|');

                    //gh.SendEmail(ProjectHeader.IDProjectHeader.ToString(), null, "1");

                    if (ProjectHeader.TypeTransaction == "Approve")
                    {
                        gh.SendEmail(ProjectHeader.IDProjectHeader.ToString(), null, "1");
                    }
                    else if (ProjectHeader.TypeTransaction == "Revise")
                    {
                        gh.SendEmail(ProjectHeader.IDProjectHeader.ToString(), null, "4");
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

        #region UploadMPP Inisiasi

        public ActionResult LoadProject()
        {
            GlobalHelper GH = new GlobalHelper();
            HttpPostedFileBase file = Request.Files[0];
            // Read file content into byte[]
            ProjectReader reader = new MPPReader();
            ProjectFile projectObj = reader.read(new ikvm.io.InputStreamWrapper(file.InputStream));

            MPPModel _MPPm = new MPPModel();

            List<MPPTask> _MPPt = new List<MPPTask>();
            List<MPPResources> _MPPr = new List<MPPResources>();
            List<MPPResourcesAssigment> _MPPra = new List<MPPResourcesAssigment>();

            var task = ToEnumerable(projectObj.getAllTasks());
            var resource = ToEnumerable(projectObj.getAllResources());
            var resourceAssignments = ToEnumerable(projectObj.getAllResourceAssignments());

            MPPTaskDHTMLXDisplay Display = new MPPTaskDHTMLXDisplay();
            List<MPPTaskDHTMLX> data = new List<MPPTaskDHTMLX>();
            List<MPPTaskDHTMLXLink> DHMLXLink = new List<MPPTaskDHTMLXLink>();
            List<MPPMilestone> _Milestone = new List<MPPMilestone>();
            //_MPPm.MPPResouceAssigment = _MPPra;
            _MPPm.MPPResource = _MPPr;
            _MPPm.MPPTasks = _MPPt;

            foreach (Task item in task)
            {


                MPPTaskDHTMLX _DHTMLX = new MPPTaskDHTMLX();
                MPPMilestone _Miles = new MPPMilestone();



                //var date = Convert.ToDateTime(item.taskStart);
                var dates = item.getStart();
                string dateString = new java.text.SimpleDateFormat("dd-MM-yyyy HH:mm:ss").format(dates);
                string EnddateString = new java.text.SimpleDateFormat("dd-MM-yyyy HH:mm:ss").format(item.getFinish());


                if (item.getMilestone() == true || item.getName().Contains("milestone") == true || item.getName().Contains("Milestone") == true)
                {
                    _DHTMLX.type = "milestone";
                    string selesai = new java.text.SimpleDateFormat("MM").format(dates);
                    string tahun = new java.text.SimpleDateFormat("yyyy").format(dates);
                    _Miles.ID = Convert.ToInt32(item.getID().ToString());
                    _Miles.Milestones = item.getName();
                    _Miles.Selesai = GH.getMonthName(Convert.ToInt32(selesai)) + " " + tahun;

                    _Milestone.Add(_Miles);
                }
                else
                {
                    _DHTMLX.type = "task";
                }
                //if (item.getName().Contains("milestone") == true || item.getName().Contains("Milestone") == true)
                //{
                //    _DHTMLX.type = "milestone";

                //    string selesai = new java.text.SimpleDateFormat("MM").format(dates);
                //    string tahun = new java.text.SimpleDateFormat("yyyy").format(dates);

                //    _Miles.Milestones = item.getName();
                //    _Miles.Selesai = GH.getMonthName(Convert.ToInt32(selesai)) + " " + tahun;

                //    _Milestone.Add(_Miles);
                //}

                _DHTMLX.id = item.getID().toString();
                _DHTMLX.text = item.getName();
                _DHTMLX.start_date = dateString;
                _DHTMLX.durasi = Convert.ToInt32(item.getDuration().getDuration());
                _DHTMLX.end_date = EnddateString;
                var getParent = item.getParentTask();
                var HasChild = item.getChildTasks();
                var HC = HasChild.ToString();

                if (HC != "[]")
                {
                    _DHTMLX.type = "project";
                }

                if (getParent != null)
                {
                    _DHTMLX.parent = getParent.getID().toString();


                }
                var predecessor = item.getPredecessors().ToString();
                List<string> termsList = new List<string>();
                var myRegex = new Regex(@"(?<=-> \[Task id=)\d+");
                Match matchResult = myRegex.Match(predecessor);
                while (matchResult.Success)
                {
                    termsList.Add(matchResult.Value);
                    matchResult = matchResult.NextMatch();
                }

                _DHTMLX.predecessor = String.Join(", ", termsList);
                _DHTMLX.no = item.getID().toString();
                var x = item.getPercentageComplete();
                var z = item.getPercentageWorkComplete();


                var getresource = item.getResourceAssignments();

                List<string> stringName = new List<string>();
                Iterator m = getresource.iterator();
                while (m.hasNext())
                {
                    ResourceAssignment ra = (ResourceAssignment)m.next();
                    var mm = ra.getUnits().doubleValue();

                    Resource r = ra.getResource();


                    // we get the resource from the resource assignment
                    if (mm != 100)
                    {
                        stringName.Add(r.getName() + '[' + mm + ']');
                    }
                    else
                    {
                        if (r == null)
                        {
                            stringName.Add("");
                        }
                        else
                        {
                            stringName.Add(r.getName());
                        }

                    }

                    // print the name of the Resource. If you want to do the same than GetResourceNames, just add each name in a String and you will have the same results at the end.
                }

                _DHTMLX.resources = String.Join(", ", stringName).ToString();
                _DHTMLX.notes = item.getNotes();
                _DHTMLX.percentcomplate = item.getPercentageComplete().doubleValue().ToString();
                data.Add(_DHTMLX);
            }
            var i = 1;
            foreach (Task pred in task)
            {


                MPPTaskDHTMLXLink _DHTMLXLink = new MPPTaskDHTMLXLink();
                //var date = Convert.ToDateTime(item.taskStart);

                var predecessor = pred.getPredecessors().ToString();
                List<string> termsList = new List<string>();
                List<string> succesor = new List<string>();
                var myRegex = new Regex(@"(?<=-> \[Task id=)\d+");
                Match matchResult = myRegex.Match(predecessor);
                while (matchResult.Success)
                {
                    termsList.Add(matchResult.Value);
                    matchResult = matchResult.NextMatch();
                }

                var myRegexs = new Regex(@"(?<=Relation \[Task id=)\d+");
                Match matchResults = myRegexs.Match(predecessor);
                while (matchResults.Success)
                {
                    succesor.Add(matchResults.Value);
                    matchResults = matchResults.NextMatch();
                }
                var u = i;
                if (termsList.Count >= 1)
                {

                    for (int z = 0; z < termsList.Count; z++)
                    {
                        _DHTMLXLink.id = i;
                        _DHTMLXLink.source = Convert.ToInt32(termsList[z]);
                        _DHTMLXLink.target = Convert.ToInt32(succesor[z]);
                        _DHTMLXLink.type = "0";
                        DHMLXLink.Add(_DHTMLXLink);
                        u++;
                    }
                }
                i = u;
            }


            data.RemoveAt(0);

            Display.data = data;
            Display.link = DHMLXLink;
            //  var ordered = _Milestone.OrderBy(ID => ID).ToList();
            Display.milestone = _Milestone;

            return Json(new { Display });
        }

        public ActionResult InsertMPP(string ProjectHeaderId)
        {
            try
            {
                HttpPostedFileBase fileMPP = Request.Files[0];
                ProjectReader readers = new MPPReader();
                ProjectFile projectObjs = readers.read(new ikvm.io.InputStreamWrapper(fileMPP.InputStream));

                MPPModel _MPP = new MPPModel();
                List<MPPTask> _MPPtask = new List<MPPTask>();
                List<MPPResources> _MPPresources = new List<MPPResources>();
                List<MPPResourcesAssigment> _MPPResourceAssigement = new List<MPPResourcesAssigment>();
                List<MPPTaskDHTMLXLink> _MPPTaskDHTMLXLink = new List<MPPTaskDHTMLXLink>();

                var task = ToEnumerable(projectObjs.getAllTasks());
                var resource = ToEnumerable(projectObjs.getAllResources());

                foreach (Task taskdetail in task)
                {
                    MPPTask _MPPtaskDetail = new MPPTask();
                    var getParent = taskdetail.getParentTask();
                    string startdate = new java.text.SimpleDateFormat("dd-MM-yyyy HH:mm:ss").format(taskdetail.getStart());
                    string enddate = new java.text.SimpleDateFormat("dd-MM-yyyy HH:mm:ss").format(taskdetail.getFinish());

                    var strdate = DateTime.ParseExact(startdate, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    var endate = DateTime.ParseExact(enddate, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                    if (getParent != null)
                    {
                        _MPPtaskDetail.taskParent = getParent.getID().toString();
                    }
                    _MPPtaskDetail.taskID = taskdetail.getID().toString();
                    _MPPtaskDetail.taskGUID = taskdetail.getGUID().toString();
                    _MPPtaskDetail.taskName = taskdetail.getName();

                    _MPPtaskDetail.taskStart = strdate;
                    _MPPtaskDetail.taskEnd = endate;
                    _MPPtaskDetail.taskDuration = taskdetail.getDuration().getDuration().ToString();
                    _MPPtaskDetail.taskCompleted = taskdetail.getPercentageComplete().floatValue();
                    _MPPtaskDetail.taskOutlineLevel = taskdetail.getOutlineLevel().doubleValue().ToString();
                    _MPPtaskDetail.taskOutlineNumber = taskdetail.getOutlineNumber();
                    if (taskdetail.getMilestone() == true)
                    {
                        _MPPtaskDetail.taskType = "1";
                    }
                    else
                    {
                        _MPPtaskDetail.taskType = "0";
                    }

                    Iterator ResourceAssigment = taskdetail.getResourceAssignments().iterator();

                    // Get ResourcesData
                    while (ResourceAssigment.hasNext())
                    {

                        MPPResourcesAssigment _MPPtaskResourceAssigment = new MPPResourcesAssigment();

                        ResourceAssignment ra = (ResourceAssignment)ResourceAssigment.next();

                        _MPPtaskResourceAssigment.TaskID = ra.getTask().getID().toString();
                        _MPPtaskResourceAssigment.Unit = ra.getUnits().floatValue();
                        if (ra.getResource() != null)
                        {
                            if (ra.getResource().getID().toString() != "" || ra.getResource().getID().toString() != " " || ra.getResource().getID().toString() != null &&
                                ra.getResource().getEmailAddress() != "" || ra.getResource().getEmailAddress() != " " || ra.getResource().getEmailAddress() != null)
                            {
                                _MPPtaskResourceAssigment.ResourceID = ra.getResource().getID().toString();
                                _MPPtaskResourceAssigment.ResourceEmail = ra.getResource().getEmailAddress();
                            }
                            _MPPResourceAssigement.Add(_MPPtaskResourceAssigment);
                        }

                    }

                    //Get Predecessor And Successor
                    var predecessor = taskdetail.getPredecessors().ToString();

                    List<string> termsList = new List<string>();
                    List<string> succesor = new List<string>();

                    var myRegex = new Regex(@"(?<=-> \[Task id=)\d+");
                    Match matchResult = myRegex.Match(predecessor);
                    while (matchResult.Success)
                    {
                        termsList.Add(matchResult.Value);
                        matchResult = matchResult.NextMatch();
                    }

                    var myRegexs = new Regex(@"(?<=Relation \[Task id=)\d+");
                    Match matchResults = myRegexs.Match(predecessor);
                    while (matchResults.Success)
                    {
                        succesor.Add(matchResults.Value);
                        matchResults = matchResults.NextMatch();
                    }
                    if (termsList.Count >= 1)
                    {
                        for (int z = 0; z < termsList.Count; z++)
                        {
                            MPPTaskDHTMLXLink _MPPtaskLink = new MPPTaskDHTMLXLink();

                            _MPPtaskLink.source = Convert.ToInt32(termsList[z]);
                            _MPPtaskLink.target = Convert.ToInt32(succesor[z]);

                            _MPPTaskDHTMLXLink.Add(_MPPtaskLink);
                        }
                    }

                    _MPPtaskDetail.taskNotes = taskdetail.getNotes();
                    _MPPtask.Add(_MPPtaskDetail);
                }
                foreach (Resource resourcelist in resource)
                {
                    if (
                        resourcelist.getName() != "" || resourcelist.getName() != " " &&
                        resourcelist.getEmailAddress() != "" || resourcelist.getEmailAddress() != " "
                       )
                    {
                        MPPResources _MPPresourcesList = new MPPResources();

                        _MPPresourcesList.ResourceName = resourcelist.getName();
                        _MPPresourcesList.ResourceID = resourcelist.getID().toString();
                        _MPPresourcesList.Email = resourcelist.getEmailAddress();

                        _MPPresources.Add(_MPPresourcesList);
                    }

                }

                _MPP.MPPTasks = _MPPtask;
                _MPP.MPPResourceAssigment = _MPPResourceAssigement;
                _MPP.MPPResource = _MPPresources;
                _MPP.MPPLink = _MPPTaskDHTMLXLink;
                _MPP.ProjectHeaderID = ProjectHeaderId;
                _MPP.PersonNumber = Session["PersonalNumber"].ToString();

                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MPP";
                Uri baseAddress = new Uri(url);
                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();
                bool IsExist = MPPisExist(Convert.ToInt32(ProjectHeaderId));
                if (IsExist == true)
                {
                    var response = client.PutAsJsonAsync(baseAddress.ToString(), _MPP).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;

                        string Keterangan = result;

                        return Json(new { status = Keterangan });
                    }
                    else
                    {
                        return Json(new { status = "Ada Masalah Dengan Koneksi ke Server" });
                    }
                }
                else
                {
                    var response = client.PostAsJsonAsync(baseAddress.ToString(), _MPP).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;

                        string Keterangan = result;

                        return Json(new { status = Keterangan });
                    }
                    else
                    {
                        return Json(new { status = "Ada Masalah Dengan Koneksi ke Server" });
                    }
                }
            }
            catch (Exception ex)
            {

                return Json(new { status = ex.ToString() });
            }



        }

        private static EnumerableCollection ToEnumerable(Collection javaCollection)
        {
            return new EnumerableCollection(javaCollection);
        }

        public ActionResult GetMPPPlaning(int ProjectHeaderId)
        {
            try

            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MPP?HeaderID=" + ProjectHeaderId;
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.GetAsync(baseAddress.ToString()).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                MPPDHTMLX ListMPP = JsonConvert.DeserializeObject<MPPDHTMLX>(result);


                return Json(new { ListMPP });

            }
            catch (Exception ex)
            {
                return Json(new { Result = ex.ToString() });
            }
        }

        private bool MPPisExist(int ProjectHeaderId)
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MPP?HeaderID=" + ProjectHeaderId;
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.GetAsync(baseAddress.ToString()).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                MPPDHTMLX ListMPP = JsonConvert.DeserializeObject<MPPDHTMLX>(result);

                bool status = false;

                if (ListMPP.GanttChart.Count() > 0)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }

                return status;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult InsertMPPManual(List<DHTMLXDataManual> manualData, List<DHTMLXLinkManual> manualLink, string ProjectHEaderID, List<ReosourceManual> manualResource)
        {
            if (manualData != null || manualData.Count > 0)
            {

                MPPModel _MPP = new MPPModel();
                List<MPPTask> _MPPtask = new List<MPPTask>();
                List<MPPResources> _MPPresources = new List<MPPResources>();
                List<MPPResourcesAssigment> _MPPResourceAssigement = new List<MPPResourcesAssigment>();
                List<MPPTaskDHTMLXLink> _MPPTaskDHTMLXLink = new List<MPPTaskDHTMLXLink>();

                foreach (var item in manualData)
                {
                    MPPTask _TaskDetail = new MPPTask();

                    string startdate = new java.text.SimpleDateFormat("dd-MM-yyyy HH:mm:ss").format(item.start_date);
                    string enddate = new java.text.SimpleDateFormat("dd-MM-yyyy HH:mm:ss").format(item.end_date);

                    _TaskDetail.taskID = item.id.ToString().Substring(item.id.ToString().Length - 6);
                    _TaskDetail.taskGUID = item.id.ToString().Substring(item.id.ToString().Length - 6);
                    _TaskDetail.taskName = item.text;
                    _TaskDetail.taskDuration = item.duration.ToString();
                    _TaskDetail.taskNotes = item.notes;
                    _TaskDetail.taskStart = Convert.ToDateTime(startdate);
                    _TaskDetail.taskEnd = Convert.ToDateTime(enddate);

                    if (item.parent == 0)
                    {
                        _TaskDetail.taskParent = item.parent.ToString();
                    }
                    else
                    {
                        _TaskDetail.taskParent = item.parent.ToString().Substring(item.parent.ToString().Length - 6);
                    }
                    if (item.type == "milestone")
                    {
                        _TaskDetail.taskType = "1";
                    }
                    else
                    {
                        _TaskDetail.taskType = "0";
                    }

                    _MPPtask.Add(_TaskDetail);
                }
                if (manualLink != null)
                {
                    foreach (var itemLink in manualLink)
                    {
                        MPPTaskDHTMLXLink _LinkDetail = new MPPTaskDHTMLXLink();

                        _LinkDetail.id = itemLink.id;
                        _LinkDetail.source = Convert.ToInt32(itemLink.source.Substring(itemLink.source.Length - 6));
                        _LinkDetail.target = Convert.ToInt32(itemLink.target.Substring(itemLink.target.Length - 6));
                        _LinkDetail.type = Convert.ToString(itemLink.type);

                        _MPPTaskDHTMLXLink.Add(_LinkDetail);
                    }
                    _MPP.MPPLink = _MPPTaskDHTMLXLink;
                }

                if (manualResource != null)
                {
                    foreach (var resourcesData in manualResource)
                    {
                        MPPResources _MPPR = new MPPResources();

                        _MPPR.ResourceID = resourcesData.key;
                        _MPPR.ResourceName = resourcesData.label;

                        _MPPresources.Add(_MPPR);
                    }
                    _MPP.MPPResource = _MPPresources;
                }

                string PersonNumb = Session["PersonalNumber"].ToString();

                _MPP.ProjectHeaderID = ProjectHEaderID.ToString();
                _MPP.PersonNumber = PersonNumb;
                _MPP.MPPTasks = _MPPtask;

                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MPP";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();
                bool IsExist = MPPisExist(Convert.ToInt32(ProjectHEaderID));
                if (IsExist == true)
                {
                    var response = client.PutAsJsonAsync(baseAddress.ToString(), _MPP).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;

                        string Keterangan = result;

                        return Json(new { status = Keterangan });
                    }
                    else
                    {
                        return Json(new { status = "Ada Masalah Dengan Koneksi ke Server" });
                    }
                }
                else
                {
                    var response = client.PostAsJsonAsync(baseAddress.ToString(), _MPP).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;

                        string Keterangan = result;

                        return Json(new { status = Keterangan });
                    }
                    else
                    {
                        return Json(new { status = "Ada Masalah Dengan Koneksi ke Server" });
                    }
                }
            }
            else
            {
                return Json(new { status = "Tidak Ada Task" });
            }
        }

        public string GetReseources(string ProjectHeaderID)
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "Resources?ProjectHeaderID=" + ProjectHeaderID;
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.GetAsync(baseAddress.ToString()).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                //List<object> ListResources = JsonConvert.DeserializeObject<List<object>>(result);

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        public ActionResult InsertMPPNew(List<DHTMLXDataManual> manualData, List<DHTMLXLinkManual> manualLink, string ProjectHEaderID, List<ReosourceManual> manualResource, string type)
        {
            try
            {
                if (manualData != null || manualData.Count > 0)
                {

                    MPPModel _MPP = new MPPModel();
                    List<MPPTask> _MPPtask = new List<MPPTask>();
                    List<MPPResources> _MPPresources = new List<MPPResources>();
                    List<MPPResourcesAssigment> _MPPResourceAssigement = new List<MPPResourcesAssigment>();
                    List<MPPTaskDHTMLXLink> _MPPTaskDHTMLXLink = new List<MPPTaskDHTMLXLink>();

                    foreach (var item in manualData)
                    {
                        MPPTask _TaskDetail = new MPPTask();



                        string sdate = item.start_date;
                        string edate = item.end_date;
                        DateTime s = Convert.ToDateTime(sdate);
                        _TaskDetail.taskStart = Convert.ToDateTime(sdate);
                        _TaskDetail.taskEnd = Convert.ToDateTime(edate);
                        //if (type == "blank")
                        //{
                        //    var sdates = DateTime.ParseExact(sdate, "dd/mm/yyyy hh:mm", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                        //    var edates = DateTime.ParseExact(edate, "dd/mm/yyyy hh:mm", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);

                        //    _TaskDetail.taskStart = sdates;
                        //    _TaskDetail.taskEnd = edates;
                        //} else
                        //{
                        //    var sdates = DateTime.ParseExact(sdate, "dd-MM-yyyy hh:mm", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                        //    var edates = DateTime.ParseExact(edate, "dd-MM-yyyy hh:mm", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                        //    _TaskDetail.taskStart = sdates;
                        //    _TaskDetail.taskEnd = sdates;
                        //}

                        _TaskDetail.taskID = item.id.ToString().Length <= 6 ? item.id.ToString() : item.id.ToString().Substring(item.id.ToString().Length - 6);
                        _TaskDetail.taskGUID = item.id.ToString().Length <= 6 ? item.id.ToString() : item.id.ToString().Substring(item.id.ToString().Length - 6);
                        _TaskDetail.taskName = item.text;
                        _TaskDetail.taskDuration = item.duration.ToString();
                        _TaskDetail.taskNotes = item.notes;

                        var Outnum = item.wbs.Split('.');

                        _TaskDetail.taskOutlineNumber = item.wbs;
                        _TaskDetail.taskOutlineLevel = Outnum.Length.ToString();


                        if (item.parent == 0)
                        {
                            _TaskDetail.taskParent = item.parent.ToString();
                        }
                        else
                        {
                            _TaskDetail.taskParent = item.parent.ToString().Length <= 6 ? item.parent.ToString() : item.parent.ToString().Substring(item.parent.ToString().Length - 6); //item.parent.ToString().Substring(item.parent.ToString().Length - 6);
                        }
                        if (item.type == "milestone")
                        {
                            _TaskDetail.taskType = "1";
                        }
                        else
                        {
                            _TaskDetail.taskType = "0";
                        }

                        _MPPtask.Add(_TaskDetail);
                    }
                    if (manualLink != null)
                    {
                        foreach (var itemLink in manualLink)
                        {
                            MPPTaskDHTMLXLink _LinkDetail = new MPPTaskDHTMLXLink();

                            _LinkDetail.id = itemLink.id;
                            if (itemLink.source.Length > 5)
                            {
                                _LinkDetail.source = Convert.ToInt32(itemLink.source.Substring(itemLink.source.Length - 6));
                                _LinkDetail.target = Convert.ToInt32(itemLink.target.Substring(itemLink.target.Length - 6));
                            }
                            else
                            {
                                _LinkDetail.source = Convert.ToInt32(itemLink.source);
                                _LinkDetail.target = Convert.ToInt32(itemLink.target);
                            }

                            _LinkDetail.type = Convert.ToString(itemLink.type);

                            _MPPTaskDHTMLXLink.Add(_LinkDetail);
                        }
                        _MPP.MPPLink = _MPPTaskDHTMLXLink;
                    }

                    if (manualResource != null)
                    {
                        foreach (var resourcesData in manualResource)
                        {
                            MPPResources _MPPR = new MPPResources();

                            _MPPR.ResourceID = resourcesData.key;
                            _MPPR.ResourceName = resourcesData.label;

                            _MPPresources.Add(_MPPR);
                        }
                        _MPP.MPPResource = _MPPresources;
                    }

                    string PersonNumb = Session["PersonalNumber"].ToString();

                    _MPP.ProjectHeaderID = ProjectHEaderID.ToString();
                    _MPP.PersonNumber = PersonNumb;
                    _MPP.MPPTasks = _MPPtask;

                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MPP";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();
                    bool IsExist = MPPisExist(Convert.ToInt32(ProjectHEaderID));
                    if (IsExist == true)
                    {
                        var response = client.PutAsJsonAsync(baseAddress.ToString(), _MPP).Result;

                        if (response.IsSuccessStatusCode)
                        {
                            var result = response.Content.ReadAsStringAsync().Result;

                            string Keterangan = result;

                            return Json(new { status = Keterangan });
                        }
                        else
                        {
                            var result = response.Content.ReadAsStringAsync().Result;

                            return Json(new { status = result });
                        }
                    }
                    else
                    {
                        var response = client.PostAsJsonAsync(baseAddress.ToString(), _MPP).Result;

                        if (response.IsSuccessStatusCode)
                        {
                            var result = response.Content.ReadAsStringAsync().Result;

                            string Keterangan = result;

                            return Json(new { status = Keterangan });
                        }
                        else
                        {
                            var result = response.Content.ReadAsStringAsync().Result;

                            return Json(new { status = result });
                        }
                    }
                }
                else
                {
                    return Json(new { status = "Tidak Ada Task" });
                }
            }
            catch (Exception ex)
            {

                return Json(ex.ToString());
            }
        }

    }
}