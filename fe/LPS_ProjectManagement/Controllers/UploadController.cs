using LPS_ProjectManagement.Helper;
using LPS_ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LPS_ProjectManagement.Controllers
{
    public class UploadController : Controller
    {
        GlobalHelper GH = new GlobalHelper();
        // GET: Upload
        public ActionResult UploadFile(string ProjHead)
        {
            try
            {
                var param = ProjHead.Split('|');
                string PersonNumber = Session["PersonalNumber"].ToString();
                string ProjectNo = GH.GetRoot(Convert.ToInt32(param[0])); // Ganti dengan nilai tetap atau ambil dari konfigurasi
                SharepointModel sharepointModel = new SharepointModel();
                var result = sharepointModel.UploadMultiFiles(Request, Server, Convert.ToInt32(param[1]), ProjectNo, PersonNumber, param[2], Convert.ToInt64(param[3]), param[0]);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { res = ex.ToString() });
            }
        }

        public ActionResult UploadFileandGetId(string ProjHead)
        {
            try
            {
                var param = ProjHead.Split('|');

                string PersonNumber = Session["PersonalNumber"].ToString();
                string ProjectNo = GH.GetRoot(Convert.ToInt32(param[0]));
                SharepointModel sharepointModel = new SharepointModel();
                var rsult = Json(sharepointModel.UploadMultiFilesandGetId(Request, Server, Convert.ToInt32(param[1]), ProjectNo //param[0]
                    , PersonNumber, param[2], Convert.ToInt64(param[3]), param[0]), JsonRequestBehavior.AllowGet);
                return rsult;

            }
            catch (Exception ex)
            {
                return Json(new { res = ex.ToString() });
            }
        }

        public ActionResult UploadFileandGetId2(string ProjHead)
        {
            try
            {
                var paramtype = Request["tipe"];
                var param = paramtype.Split('|');
                string PersonNumber = Session["PersonalNumber"].ToString();
                string ProjectNo = GH.GetRoot(Convert.ToInt32(ProjHead));
                SharepointModel sharepointModel = new SharepointModel();
                var rsult = Json(sharepointModel.UploadMultiFilesandGetId(Request, Server, Convert.ToInt32(param[0]), ProjectNo //param[0]
                    , PersonNumber, param[1], Convert.ToInt64(param[2]), ProjHead), JsonRequestBehavior.AllowGet);
                return rsult;

            }
            catch (Exception ex)
            {
                return Json(new { res = ex.ToString() });
            }
        }

        public ActionResult Download(int ProjectHeaderID , string name )
        {
            try
            {
                GlobalHelper GH = new GlobalHelper();

                var ProjectNo = GH.GetRoot(ProjectHeaderID);

                SharepointModel sharepointModel = new SharepointModel();
                sharepointModel.DownloadFile(Convert.ToString(ProjectNo), name);
                return new EmptyResult();    

            }
            catch (Exception ex)
            {
                return Json(new { res = ex.ToString() });
            }
        }

        [HttpGet]
        public ActionResult ShowFile(int ProjectHeaderID, string name)
        {
            try
            {
                GlobalHelper GH = new GlobalHelper();

                var ProjectNo = GH.GetRoot(ProjectHeaderID);

                SharepointModel sharepointModel = new SharepointModel();
                sharepointModel.DownloadPdf(Convert.ToString(ProjectNo), name);
                return new EmptyResult();

            }
            catch (Exception ex)
            {
                return Json(new { res = ex.ToString() });
            }
        }

        private Task GetFileStreamAsync(object fileName)
        {
            throw new NotImplementedException();
        }

        public string CreateFolder(string ProjectName)
        {
            try
            {
                SharepointModel sharepointModel = new SharepointModel();
                return sharepointModel.CreateFolderPerProject(ProjectName);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public ActionResult DeleteFile(string ProjectHeaderID , string DocumentID)
        {
            Models.UserManagementModels.MultiPorpose MP = new Models.UserManagementModels.MultiPorpose();

            string param = ProjectHeaderID + "|" + DocumentID;

            MP.ID = param;

            HttpClient client = new HttpClient();
            string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DeleteFile";
            Uri baseAddress = new Uri(url);

            client.BaseAddress = baseAddress;
            client.DefaultRequestHeaders.Accept.Clear();

            var response = client.PostAsJsonAsync(baseAddress.ToString(), MP).Result;
            var result = response.Content.ReadAsStringAsync().Result;


            string val = result;

            string vali = val.Remove(0, 1);
            string valu = vali.Remove(vali.Length - 1);

            return Json(new { status = valu });
        }
               
    }
}