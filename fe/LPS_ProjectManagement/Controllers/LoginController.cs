using LPS_ProjectManagement.Models;
using System;
using System.Data;
using System.Web.Mvc;

using System.DirectoryServices;
using DirectoryEntry = System.DirectoryServices.DirectoryEntry;

using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Collections.Generic;
using System.Web.Security;

namespace LPS_ProjectManagement.Controllers
{
    [CompressFilter]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login(string ReturnUrl)
        {
            if (Session["PersonalNumber"] == null)
            {
                ViewBag.ReturnUrl = ReturnUrl;
                
            }
            else
            {
                if (ReturnUrl != null)
                {
                    ReturnUrl = ReturnUrl.Replace("|", "&");
                    Response.Redirect(ReturnUrl);
                }
                else
                {
                    Response.Redirect("/Beranda/Index");
                }
                
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel Login, string returnUrl)
        {
            if (Login.Username == null && Login.Password == null)
            {
               
                return Json(new { status = "Error" });
            }
            else
            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "Authentication";
                Uri baseAddress = new Uri(url);
                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();
    
                var response = client.PostAsJsonAsync(baseAddress.ToString(), Login).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;

                    AuthenticationModel _ListUserManagement = JsonConvert.DeserializeObject<AuthenticationModel>(result);

                    if (_ListUserManagement.Keterangan == null || _ListUserManagement.Keterangan == "")
                    {
                        string Nama = _ListUserManagement.Nama.ToString();
                        string Departement = _ListUserManagement.Departement.ToString();
                        string Title = _ListUserManagement.Title.ToString() ;
                        string PersonalNumber = _ListUserManagement.PersonalNumber.ToString();
                        string RolesSystem = _ListUserManagement.RolesSystem.ToString();

                        List<RoleProject> RoleProj = _ListUserManagement.RoleProject;



                        RoleProject[] RoleProject = RoleProj.ToArray();


                        Session["Nama"] = Nama;
                        Session["PersonalNumber"] = PersonalNumber;
                        Session["Departement"] = Departement;
                        Session["Title"] = Title;
                        Session["Roles"] = RoleProject;
                        Session["RolesSysTems"] = RolesSystem;
                        //Session["IsTransformasi"] = 1;
                        return Json(new { status = "Berhasil" });
                    }
                    //if (string.IsNullOrEmpty(Login.ReturnUrl))
                    //{
                    //    return RedirectToAction("Index", "Beranda");
                    //}
                    //else
                    //{
                    //    return Redirect(Login.ReturnUrl);
                    //}

                    else
                    {
                        string Keterangan = _ListUserManagement.Keterangan.ToString();

                        return Json(new { status = Keterangan });
                    }

                }
                else
                {
                    return Json(new { status = "Ada Masalah Dengan Koneksi ke Server" });
                }               
            }
        }
        public void Logout()
        {
            try
            {
               
                Session.RemoveAll();

                Response.Redirect("~/Login/Login");
                return;
            }
            catch (Exception)
            {
                //Util.LogError(ex);
            }
         
        }



    }
}