using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using java.util;
using LPS_ProjectManagement.Helper;
using LPS_ProjectManagement.Models;
using net.sf.mpxj;
using net.sf.mpxj.mpp;
using net.sf.mpxj.reader;
using LPS_ProjectManagement.Models.EksekusiModels;
using System.IO;
using LPS_ProjectManagement.Models.TransaksiDataModels;
using Newtonsoft.Json;

namespace LPS_ProjectManagement.Controllers
{
    public class MPPController : Controller
    {
        // GET: MPP
        #region MPP Eksekusi
        private static EnumerableCollection ToEnumerable(Collection javaCollection)
        {
            return new EnumerableCollection(javaCollection);
        }

        public ActionResult GenerateMPP()
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
            var customfields = projectObj.getCustomFields();

  
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

                
                if (item.getMilestone() == true)
                {
                    _DHTMLX.type = "milestone";
                    string selesai = new java.text.SimpleDateFormat("MM").format(dates);
                    string tahun = new java.text.SimpleDateFormat("yyyy").format(dates);

                    _Miles.Milestones = item.getName();
                    _Miles.Selesai = GH.getMonthName(Convert.ToInt32(selesai)) + " " + tahun;

                    _Milestone.Add(_Miles);
                }
                else
                {
                    _DHTMLX.type = "task";
                }
                if (item.getName().Contains("milestone") == true || item.getName().Contains("Milestone") == true)
                {
                    _DHTMLX.type = "milestone";

                    string selesai = new java.text.SimpleDateFormat("MM").format(dates);
                    string tahun = new java.text.SimpleDateFormat("yyyy").format(dates);

                    _Miles.Milestones = item.getName();
                    _Miles.Selesai = GH.getMonthName(Convert.ToInt32(selesai)) + " " + tahun;

                    _Milestone.Add(_Miles);
                }

                _DHTMLX.id = item.getID().toString();
                _DHTMLX.text = item.getName();
                _DHTMLX.start_date = dateString;
                _DHTMLX.durasi = Convert.ToInt32(item.getDuration().getDuration());
                _DHTMLX.end_date = EnddateString;
                var getParent = item.getParentTask();

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

            return Json(new { Display });
        }

        public ActionResult InsertRealisasi(List<DHTMLXDataManualNew> manualData , string ProjectHEaderID, string type, List<Constrain> Constrain, string status, string Keys, List<execApproval> ListProjectRoleGroup)
        {
            try
            {
                if (manualData != null || manualData.Count > 0)
                {

                    InsertExsekusi _MPP = new InsertExsekusi();
                    List<MPPTasknew> _MPPtask = new List<MPPTasknew>();
                    

                    foreach (var item in manualData)
                    {
                        MPPTasknew _TaskDetail = new MPPTasknew();

                        string sdate = item.start_date;
                        string edate = item.end_date;
                        string asdate = item.actual_start;
                        string aedate = item.actual_end;

                       

                        if (type == "blank")
                        {
                            var sdates = DateTime.ParseExact(sdate, "dd-MM-yyyy hh:mm", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                            var edates = DateTime.ParseExact(edate, "dd-MM-yyyy hh:mm", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                            //var asdates = DateTime.ParseExact(sdate, "dd-MM-yyyy hh:mm", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                            //var aedates = DateTime.ParseExact(edate, "dd-MM-yyyy hh:mm", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                            _TaskDetail.taskStart = sdates;
                            _TaskDetail.taskEnd = edates;
                            _TaskDetail.taskaActual_start = asdate;
                            _TaskDetail.taskActual_end = aedate;
                        }
                        else
                        {
                         
                            _TaskDetail.taskStart = Convert.ToDateTime(sdate);
                            _TaskDetail.taskEnd = Convert.ToDateTime(edate);
                            _TaskDetail.taskaActual_start = asdate;//Convert.ToDateTime(asdate);
                            _TaskDetail.taskActual_end = aedate;//Convert.ToDateTime(aedate);
                        }

                        _TaskDetail.taskID = item.id.ToString().Length <= 6 ? item.id.ToString() : item.id.ToString().Substring(item.id.ToString().Length - 6);
                        _TaskDetail.taskGUID = item.id.ToString().Length <= 6 ? item.id.ToString() : item.id.ToString().Substring(item.id.ToString().Length - 6);
                        _TaskDetail.taskName = item.text;
                        _TaskDetail.taskDuration = item.duration.ToString();
                        _TaskDetail.taskNotes = item.notes;
                    

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
                         
                        if (item.progress != "0" && item.progress != null)
                        {

                            var mm = "";
                            var change = "";
                            if (item.progress.Length > 8)
                            {
                                mm = item.progress.Substring(0, 8);
                               // change = mm.Replace('.', ',');
                            } else
                            {
                                mm = item.progress;
                                //change = item.progress.Replace('.', ',');
                            }
                           

                           
                            var z = Convert.ToDecimal(mm) * 100;
                            var mr = (float)z;
                            var round = Math.Round(z, 2);
                            var fl = (float)round;
                            
                            _TaskDetail.taskCompleted = fl;
                        } else
                        {
                            _TaskDetail.taskCompleted = 0;
                        }

                        _TaskDetail.IDMPP = item.no.ToString();
                        //if ((Convert.ToDouble(item.progress) * 100) > 0)
                        //{
                            _MPPtask.Add(_TaskDetail);
                       // }                   
                    }
                  
                    string PersonNumb = Session["PersonalNumber"].ToString();

                    _MPP.ProjectHeaderID = ProjectHEaderID.ToString();
                    _MPP.PersonNumber = PersonNumb;

                    
                    _MPP.MPPTasks = _MPPtask;
                    _MPP.conso = Constrain;
                    _MPP.Status = status;
                    _MPP.Periode = Keys;
                    _MPP.app = ListProjectRoleGroup;

                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EksekusiMain";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();
                    
                    bool IsExist = false;
                    if (IsExist == true)
                    {
                        var response = client.PutAsJsonAsync(baseAddress.ToString(), _MPP).Result;

                        if (response.IsSuccessStatusCode)
                        {
                            GlobalHelper GH = new GlobalHelper();

                            var Email = GH.SendEmail(ProjectHEaderID.ToString(), Keys, "2");
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

        public ActionResult UploadFile(string ProjectHeaderID , string TaskID)
        {
            GlobalHelper GH = new GlobalHelper();

            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];
                var r = ProjectHeaderID.Split('|');

                var fileName = Path.GetFileName(file.FileName);
                var name = "Milestone_" + fileName;
                string param = "1|" + r[0] + "|" + r[1] + "|" + name + "|txt";

                Models.UserManagementModels.MultiPorpose MP = new Models.UserManagementModels.MultiPorpose();

                MP.ID = param;

                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "UploadFile";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), MP).Result;
                var result = response.Content.ReadAsStringAsync().Result;

             
                string val = result;

                var path = Path.Combine(Server.MapPath("~/UploadFile/"), name);
                file.SaveAs(path);
            }
            return Json(new {status = "back"});
        }

        public ActionResult Delete(string ProjectHeaderID)
        {
            GlobalHelper GH = new GlobalHelper();

             var r = ProjectHeaderID.Split('|');

             string param = r[0] + "|" + r[1] + "|" + r[2];

             Models.UserManagementModels.MultiPorpose MP = new Models.UserManagementModels.MultiPorpose();

             MP.ID = param;

             HttpClient client = new HttpClient();
             string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "UploadFile";
             Uri baseAddress = new Uri(url);

             client.BaseAddress = baseAddress;
             client.DefaultRequestHeaders.Accept.Clear();

           var response = client.PutAsJsonAsync(baseAddress.ToString(), MP).Result;
           var result = response.Content.ReadAsStringAsync().Result;


           string val = result;


           return Json(new { status = "back" });
        }

        public ActionResult DownloadFile(string FileName)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "UploadFile/";
            byte[] fileBytes = System.IO.File.ReadAllBytes(path + FileName);
            string fileName = FileName;
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        public ActionResult Approve(string IDProjectHeader , string keys)
        {

            GlobalHelper GH = new GlobalHelper();

            string param = IDProjectHeader + "|" + keys + "|" + Session["PersonalNumber"].ToString();

            Models.UserManagementModels.MultiPorpose MP = new Models.UserManagementModels.MultiPorpose();

     
            MP.ID = param;

            HttpClient client = new HttpClient();
            string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EksekusiApproval";
            Uri baseAddress = new Uri(url);

            client.BaseAddress = baseAddress;
            client.DefaultRequestHeaders.Accept.Clear();

            var response = client.PostAsJsonAsync(baseAddress.ToString(), MP).Result;
            var result = response.Content.ReadAsStringAsync().Result;

            var Email = GH.SendEmail(IDProjectHeader, keys, "2");
            string val = result;

            return Json(new { val });
        }

        public ActionResult Revise(ProjectHeaderModel ProjectHeader)
        {
            try
            {

                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EksekusiApproval";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PutAsJsonAsync(baseAddress.ToString(), ProjectHeader).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                string data = JsonConvert.DeserializeObject<string>(result);
                string[] hasil = data.Split('|');

                if (hasil[0] == "S")
                {
                    GlobalHelper gh = new GlobalHelper();
                    //gh.SendEmail(ProjectHeader.IDProjectHeader.ToString(), ProjectHeader.TypeTransaction, "3");
                }
                if (hasil[0] == "S") return Json(new { Result = "Success", Message = hasil[1] });
                else return Json(new { Result = "Failed", Message = hasil[1] });

            }
            catch (Exception ex)
            {
                return Json(new { Result = "Failed", Message = ex.Message });
            }
        }

        #endregion
    }
}