using LPS_ProjectManagement.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LPS_ProjectManagement.Controllers
{
    public class NotificationController : Controller
    {
        // GET: Notification
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Notification(string PersonNumber)
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "Notification";
                Uri baseAddress = new Uri(url);
                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                //using (var res = await client.PostAsJsonAsync(baseAddress.ToString(), PersonNumber))
                //{
                //    var result = res.Content.ReadAsStringAsync();

                //    List<NotificationModel> Notification = JsonConvert.DeserializeObject<List<NotificationModel>>(result.Result);

                //    return Json(Notification);
                //}
                var response = client.PostAsJsonAsync(baseAddress.ToString(), PersonNumber).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                List<NotificationModel> Notification = JsonConvert.DeserializeObject<List<NotificationModel>>(result);

                return Json(Notification);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}