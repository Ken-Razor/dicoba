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
    public class ProjectChangeController : Controller
    {
        // GET: ProjectChange
        #region Project Change Management
        public ActionResult ChangeManagement()
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    ChangeManagementHeaderModel cmhm = new ChangeManagementHeaderModel();
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "ChangeManagement";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    cmhm.CreatedBy = Session["PersonalNumber"].ToString();

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), cmhm).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<ChangeManagementHeaderModel> ListChangeManagementHeader = JsonConvert.DeserializeObject<List<ChangeManagementHeaderModel>>(result);

                    return View(ListChangeManagementHeader);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult ChangeManagementDetail(int IDProjectHeader)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "ChangeManagement";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    ChangeManagementHeaderModel ph = new ChangeManagementHeaderModel();
                    ph.IDProjectHeader = IDProjectHeader;
                    ph.CreatedBy = Session["PersonalNumber"].ToString();

                    var response = client.PutAsJsonAsync(baseAddress.ToString(), ph).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    ChangeManagementDetailModel ProjectHeader = JsonConvert.DeserializeObject<ChangeManagementDetailModel>(result);

                    return View(ProjectHeader);
                }
            }
            catch (Exception ex)
            {
                ChangeManagementDetailModel ProjectDetail = new ChangeManagementDetailModel();
                return View(ProjectDetail);//throw ex;
            }
        }

        public ActionResult InsertChangeManagement(ChangeManagementDetailModel ChangeManagementDetail)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    DateTime first = new DateTime(1753, 1, 1);
                    DateTime last = new DateTime(9999, 1, 1);

                    if (ChangeManagementDetail.DateRequired < first || ChangeManagementDetail.DateRequired > last) return Json(new { Result = "Failed", Message = "Tanggal Pengiriman minimal 1-Jan-1753 dan maksimal 1-Jan-9999" });
                    else if (ChangeManagementDetail.DateSubmitted < first || ChangeManagementDetail.DateSubmitted > last) return Json(new { Result = "Failed", Message = "Tanggal Dibutuhkan minimal 1-Jan-1753 dan maksimal 1-Jan-9999" });
                    else
                    {
                        HttpClient client = new HttpClient();
                        string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "ChangeManagementCRUD";
                        Uri baseAddress = new Uri(url);

                        client.BaseAddress = baseAddress;

                        client.DefaultRequestHeaders.Accept.Clear();

                        var response = client.PostAsJsonAsync(baseAddress.ToString(), ChangeManagementDetail).Result;
                        var result = response.Content.ReadAsStringAsync().Result;

                        string data = JsonConvert.DeserializeObject<string>(result);
                        string[] hasil = data.Split('|');

                        if (hasil[0] == "S") return Json(new { Result = "Success", Message = hasil[1] });
                        else return Json(new { Result = "Failed", Message = hasil[1] });
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Failed", Message = ex.Message });
            }
        }

        public ActionResult ApproveChangeManagement(ProjectHeaderModel ProjectHeader)
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "ChangeManagementCRUD";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PutAsJsonAsync(baseAddress.ToString(), ProjectHeader).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    string data = JsonConvert.DeserializeObject<string>(result);
                    string[] hasil = data.Split('|');

                    if (hasil[2] != "-")
                    {
                        UploadController UC = new UploadController();
                        UC.CreateFolder(hasil[2]);
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
    }
}