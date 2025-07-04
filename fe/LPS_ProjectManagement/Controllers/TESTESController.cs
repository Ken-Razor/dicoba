using LPS_ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LPS_ProjectManagement.Controllers
{
    public class TESTESController : Controller
    {

        public ActionResult index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            try
            {
                //newSharePoint sharepointModel = new newSharePoint();
                //sharepointModel.UploadFile();
                ////return null;
                //SharepointModel sharepointModel = new SharepointModel();
                //return Json(sharepointModel.UploadMultiFiles(Request, Server), JsonRequestBehavior.AllowGet);
                return null;
            }
            catch (Exception ex)
            {
                return Json(new { res = ex.ToString() });
            }
        }

        public ActionResult Download(string ServerUrl, string RelativeUrl)
        {
            try
            {
                SharepointModel sharepointModel = new SharepointModel();
                return null;
             //   return Json(sharepointModel.DownloadFiles(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { res = ex.ToString() });
            }
        }


    }
}