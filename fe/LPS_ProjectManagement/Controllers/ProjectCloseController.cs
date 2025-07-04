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
    public class ProjectCloseController : Controller
    {
        // GET: ProjectClose
        #region Project Closing

        public ActionResult ProjectClosing()
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    ClosingProjectHeaderModel cphm = new ClosingProjectHeaderModel();
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "Closing";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    cphm.CreatedBy = Session["PersonalNumber"].ToString();

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), cphm).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<ClosingProjectHeaderModel> ListClosingProjectHeader = JsonConvert.DeserializeObject<List<ClosingProjectHeaderModel>>(result);

                    return View(ListClosingProjectHeader);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult ProjectClosingCreate(int IDProjectHeader)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    //string Nama = Session["Nama"].ToString();
                    //string PersonalNumber = Session["PersonalNumber"].ToString();
                    //string Departement = Session["Departement"].ToString();
                    //string Title = Session["Title"].ToString();
                    //var RoleProject = Session["RoleProject"];

                    //ProjectHeaderModel phm = new ProjectHeaderModel();

                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "Closing";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;
                    //phm.IDProjectHeader = IDProjectHeader;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PutAsJsonAsync(baseAddress.ToString(), IDProjectHeader).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    ClosingProjectDetailModel ProjectHeader = JsonConvert.DeserializeObject<ClosingProjectDetailModel>(result);

                    return View(ProjectHeader);
                }
            }
            catch (Exception ex)
            {
                ClosingProjectDetailModel ProjectDetail = new ClosingProjectDetailModel();
                return View(ProjectDetail);//throw ex;
            }
        }

        public ActionResult InsertProjectClosing(ClosingProjectDetailModel ClosingProjectDetail)
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

                    if (ClosingProjectDetail.ClosingDate > first && ClosingProjectDetail.ClosingDate < last)
                    {
                        HttpClient client = new HttpClient();
                        string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "ClosingCRUD";
                        Uri baseAddress = new Uri(url);

                        client.BaseAddress = baseAddress;

                        client.DefaultRequestHeaders.Accept.Clear();

                        var response = client.PostAsJsonAsync(baseAddress.ToString(), ClosingProjectDetail).Result;
                        var result = response.Content.ReadAsStringAsync().Result;

                        string data = JsonConvert.DeserializeObject<string>(result);
                        string[] hasil = data.Split('|');

                        if (hasil[0] == "S") return Json(new { Result = "Success", Message = hasil[1] });
                        else return Json(new { Result = "Failed", Message = hasil[1] });
                    }
                    else
                    {
                        return Json(new { Result = "Failed", Message = "Tanggal Closing minimal 1-Jan-1753 dan maksimal 1-Jan-9999" });
                    }
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