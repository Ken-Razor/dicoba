using LPS_ProjectManagement.Models.PJSModels;
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
    public class PJSController : Controller
    {
        // GET: PJS
        public ActionResult PJS()
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "PJSApproval";
                    Uri baseAddress = new Uri(url);
                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.GetAsync(baseAddress.ToString()).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    List<PJSModel> ListModel = JsonConvert.DeserializeObject<List<PJSModel>>(result);

                    return View(ListModel);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public ActionResult PJSDetil(int ID)
        {
            PJSModel PJSModel = new PJSModel();
            PJSModel.ID = ID.ToString();

            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "PJSApproval";
                    Uri baseAddress = new Uri(url);
                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), PJSModel).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    PJSModel ListModel = JsonConvert.DeserializeObject<PJSModel>(result);

                    return View(ListModel);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult PJSInsert(PJSModel data)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    if(data.StartDate > data.EndDate) { return Json(new { Result = "Failed", Message = "Tanggal mulai tidak boleh lebih dari tanggal selesai" }); }
                    if(data.StartDate < Convert.ToDateTime("1753-01-01")) { return Json(new { Result = "Failed", Message = "Tanggal mulai minimal : 1 Januari 1753" }); }
                    if (data.EndDate > Convert.ToDateTime("9999-12-31")) { return Json(new { Result = "Failed", Message = "Tanggal berakhir maksimal : 31 Desember 9999" }); }
                    if(data.ExistingUsername == null) { return Json(new { Result = "Failed", Message = "Pilih user terlebih dahulu" }); }
                    if (data.PJSUsername == null) { return Json(new { Result = "Failed", Message = "Pilih PJS terlebih dahulu" }); }
                    if (data.PJSUsername == data.ExistingUsername) { return Json(new { Result = "Failed", Message = "PJS tidak boleh sama dengan user yang diwakilkan" }); }
                    else
                    {

                        if (data.Note == null) data.Note = "";

                        data.PersonalNumber = Session["PersonalNumber"].ToString();

                        HttpClient client = new HttpClient();
                        string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "PJSApprovalCRUD";
                        Uri baseAddress = new Uri(url);

                        client.BaseAddress = baseAddress;

                        client.DefaultRequestHeaders.Accept.Clear();

                        var response = client.PostAsJsonAsync(baseAddress.ToString(), data).Result;
                        var result = response.Content.ReadAsStringAsync().Result;

                        string Return = JsonConvert.DeserializeObject<string>(result);
                        string[] hasil = Return.Split('|');

                        if (hasil[0] == "S") return Json(new { Result = "Success", Message = hasil[1] });
                        else return Json(new { Result = "Failed", Message = hasil[1] });

                    }

                }
            }
            catch(Exception ex)
            {
                return Json(new { Result = "Failed", Message = ex.Message });
            }
        }

        public ActionResult PJSDelete(PJSModel data)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    data.PersonalNumber = Session["PersonalNumber"].ToString();
                    data.ExistingUsername = "";
                    data.PJSUsername = "";
                    data.StartDate = DateTime.Now;
                    data.EndDate = DateTime.Now;
                    data.Note = "";

                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "PJSApprovalCRUD";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), data).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    string Return = JsonConvert.DeserializeObject<string>(result);
                    string[] hasil = Return.Split('|');

                    if (hasil[0] == "S") return Json(new { Result = "Success", Message = hasil[1] });
                    else return Json(new { Result = "Failed", Message = hasil[1] });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Failed", Message = ex.Message });
            }
        }

    }
}