using LPS_ProjectManagement.Models;
using LPS_ProjectManagement.Models.UserManagementModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace LPS_ProjectManagement.Controllers
{
    public class ManajemenUserController : Controller
    {
        // GET: ManajemenUser
        public ActionResult Index()
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
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "RegisteredUserList";
                    Uri baseAddress = new Uri(url);
                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.GetAsync(baseAddress.ToString()).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        List<UserManagementModel> _ListUserManagement = JsonConvert.DeserializeObject<List<UserManagementModel>>(result);
                        return View(_ListUserManagement);
                    }
                    else
                    {
                        return View();
                    }
                }    

            }
            catch (Exception ex)
            {

                throw;
            }
           
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetDataEmployeeByName(MultiPorpose GetEmployeeData)
        {

            HttpClient client = new HttpClient();
            string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "RegisteredDetailUser";
            Uri baseAddress = new Uri(url);
            client.BaseAddress = baseAddress;

            client.DefaultRequestHeaders.Accept.Clear();

            var response = client.PostAsJsonAsync(baseAddress.ToString(), GetEmployeeData).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                List<RegisteredUserDetail> _ListUser = JsonConvert.DeserializeObject<List<RegisteredUserDetail>>(result);

                List<UserSearchList> _search = new List<UserSearchList>();

                foreach (var item in _ListUser)
                {
                    UserSearchList _searchisi = new UserSearchList();

                    _searchisi.nama = item.Nama.ToString();
                    _searchisi.personalnumber = item.PersonalNumber.ToString();
                    _searchisi.posisi = item.Posisi.ToString();

                    _search.Add(_searchisi);
                }
                return Json(new { _search });
            }
            else
            {
                return Json(new { GetData = "Terdapat Masalah Dengan Koneksi" });
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetDataEmployeeByNameNewUser(MultiPorpose GetEmployeeData)
        {

            HttpClient client = new HttpClient();
            string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "RegisteredDetailUser";
            Uri baseAddress = new Uri(url);
            client.BaseAddress = baseAddress;

            client.DefaultRequestHeaders.Accept.Clear();

            var response = client.PutAsJsonAsync(baseAddress.ToString(), GetEmployeeData).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                List<RegisteredUserDetail> _ListUser = JsonConvert.DeserializeObject<List<RegisteredUserDetail>>(result);

                List<UserSearchList> _search = new List<UserSearchList>();

                foreach (var item in _ListUser)
                {
                    UserSearchList _searchisi = new UserSearchList();

                    _searchisi.nama = item.Nama.ToString();
                    _searchisi.personalnumber = item.PersonalNumber.ToString();
                    _searchisi.posisi = item.Posisi.ToString();

                    _search.Add(_searchisi);
                }
                return Json(new { _search });
            }
            else
            {
                return Json(new { GetData = "Terdapat Masalah Dengan Koneksi" });
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetDetailEmployeeByPersonNumber(MultiPorpose GetEmployeeData)
        {

            HttpClient client = new HttpClient();
            string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "RegisteredUserList";
            Uri baseAddress = new Uri(url);
            client.BaseAddress = baseAddress;

            client.DefaultRequestHeaders.Accept.Clear();

            var response = client.PostAsJsonAsync(baseAddress.ToString(), GetEmployeeData).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;

                RegisteredUserDetail _ListUser = JsonConvert.DeserializeObject<RegisteredUserDetail>(result);
                return Json(new { _ListUser });
            }
            else
            {
                return Json(new { GetData = "Terdapat Masalah Dengan Koneksi" });
            }

        }


        public ActionResult DetailUser(string persnum)
        {
            try
            {
                if (Session["PersonalNumber"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    MultiPorpose _multi = new MultiPorpose();
                    _multi.ID = persnum;

                    HttpClient client = new HttpClient();
                    string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "RegisteredUserList";
                    Uri baseAddress = new Uri(url);

                    client.BaseAddress = baseAddress;

                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsJsonAsync(baseAddress.ToString(), _multi).Result;

                    var result = response.Content.ReadAsStringAsync().Result;

                    UserDetailInOut _ListUser = JsonConvert.DeserializeObject<UserDetailInOut>(result);

                    // DDL
                    HttpClient clients = new HttpClient();
                    string urls = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DropDownUserManagement";
                    Uri baseAddresss = new Uri(urls);

                    clients.BaseAddress = baseAddresss;

                    clients.DefaultRequestHeaders.Accept.Clear();

                    var responses = clients.GetAsync(baseAddresss.ToString()).Result;

                    var results = responses.Content.ReadAsStringAsync().Result;
                    DropDownUserManagementModel _DDLList = JsonConvert.DeserializeObject<DropDownUserManagementModel>(results);

                    _ListUser.DDLUm = _DDLList;
                    string status = "";
                    if (persnum == "RIN")
                    {
                        status = "INPUT";
                    }
                    else
                    {
                        status = "EDIT";
                    }


                    // ROLE

                    HttpClient clientRole = new HttpClient();
                    string urlROle = ConfigurationManager.AppSettings["WebAPI"].ToString() + "UserMananging" + "?PersonNumber=" + persnum;
                    Uri baseAddressROle = new Uri(urlROle);

                    clientRole.BaseAddress = baseAddressROle;

                    clientRole.DefaultRequestHeaders.Accept.Clear();

                    var responsrole = clientRole.GetAsync(baseAddressROle.ToString()).Result;

                    var resultrole = responsrole.Content.ReadAsStringAsync().Result;
                    string _Role = JsonConvert.DeserializeObject<string>(resultrole);



                    // NewUser

                    HttpClient NewUser = new HttpClient();
                    string urlNewUser = ConfigurationManager.AppSettings["WebAPI"].ToString() + "UserNew" + "?PersonNumber=" + persnum;
                    Uri baseAddressNewUser = new Uri(urlNewUser);

                    NewUser.BaseAddress = baseAddressROle;

                    NewUser.DefaultRequestHeaders.Accept.Clear();

                    var responsNewUser = NewUser.GetAsync(baseAddressNewUser.ToString()).Result;

                    var resultNewUser = responsNewUser.Content.ReadAsStringAsync().Result;
                    List<NewUserModel> _NUM = JsonConvert.DeserializeObject<List<NewUserModel>>(resultNewUser);

                    ViewBag.Role = _Role;
                    ViewBag.Persnum = persnum;
                    ViewBag.Status = status;
                    _ListUser.NUM = _NUM;
                    return View(_ListUser);
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetProjectByProgram(DropDownProgram GetProject)
        {

            HttpClient client = new HttpClient();
            string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DropDownUserManagement";
            Uri baseAddress = new Uri(url);
            client.BaseAddress = baseAddress;

            client.DefaultRequestHeaders.Accept.Clear();

            var response = client.PostAsJsonAsync(baseAddress.ToString(), GetProject).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;

                DropDownUserManagementModel _ListUser = JsonConvert.DeserializeObject<DropDownUserManagementModel>(result);

                List<DropDownProject> _ListProject = _ListUser.Projects;
                
                return Json(new { _ListProject });
            }
            else
            {
                return Json(new { GetData = "Terdapat Masalah Dengan Koneksi" });
            }

        }

        public ActionResult GetProgramByProject(DropDownProject GetProject)
        {

            HttpClient client = new HttpClient();
            string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DropDownUserManagement" + "?IDProject=" + GetProject.IDProject;
            Uri baseAddress = new Uri(url);
            client.BaseAddress = baseAddress;

            client.DefaultRequestHeaders.Accept.Clear();

            var response = client.GetAsync(baseAddress.ToString()).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;

                DropDownProgram _ListProgram = JsonConvert.DeserializeObject<DropDownProgram>(result);
                
                return Json(new { _ListProgram });
            }
            else
            {
                return Json(new { GetData = "Terdapat Masalah Dengan Koneksi" });
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertDataUser(InsertDataUser Data)
        {

            HttpClient client = new HttpClient();
            string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "UserMananging";
            Uri baseAddress = new Uri(url);
            client.BaseAddress = baseAddress;

           
            client.DefaultRequestHeaders.Accept.Clear();

            var response = client.PostAsJsonAsync(baseAddress.ToString(), Data).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;

                DropDownUserManagementModel _ListUser = JsonConvert.DeserializeObject<DropDownUserManagementModel>(result);

                List<DropDownProject> _ListProject = _ListUser.Projects;

                return Json(new { _ListProject });
            }
            else
            {
                return Json(new { GetData = "Terdapat Masalah Dengan Koneksi" });
            }

        }

        public ActionResult DeleteUser(string IDPersonal , string Username)
        {
            try
            {
               
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "UserMananging?PersonalNumber=" + IDPersonal + "&Username=" + Username;
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.DeleteAsync(baseAddress.ToString()).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateDataUser(InsertDataUser Data)
        {

            HttpClient client = new HttpClient();
            string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "UserMananging";
            Uri baseAddress = new Uri(url);
            client.BaseAddress = baseAddress;


            client.DefaultRequestHeaders.Accept.Clear();

            var response = client.PutAsJsonAsync(baseAddress.ToString(), Data).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;

                DropDownUserManagementModel _ListUser = JsonConvert.DeserializeObject<DropDownUserManagementModel>(result);

                List<DropDownProject> _ListProject = _ListUser.Projects;

                return Json(new { _ListProject });
            }
            else
            {
                return Json(new { GetData = "Terdapat Masalah Dengan Koneksi" });
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertDataUserWithRole(MultiPorpose Data)
        {

            HttpClient client = new HttpClient();
            string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "RegisteredUserList";
            Uri baseAddress = new Uri(url);
            client.BaseAddress = baseAddress;


            client.DefaultRequestHeaders.Accept.Clear();

            var response = client.PutAsJsonAsync(baseAddress.ToString(), Data).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;

                string _ListUser = JsonConvert.DeserializeObject<string>(result);

                var res = _ListUser.Split('|');

                return Json(new { result = res[1] });
            }
            else
            {
                return Json(new { GetData = "Terdapat Masalah Dengan Koneksi" });
            }

        }

    }
}