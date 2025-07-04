using LPS_ProjectManagement.Common;
using LPS_ProjectManagement.Helper;
using LPS_ProjectManagement.Models;
using LPS_ProjectManagement.Models.DashboardModels;
using LPS_ProjectManagement.Models.DashboardModels.DashboardProject;
using LPS_ProjectManagement.Models.MasterDataModels;
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
    [CustomAuthorizationAttribute]
    [CompressFilter]
    public class HomeController : Controller
    {
        // GET: Beranda
        public ActionResult Index()
        {
            if (Session["PersonalNumber"] == null)
            {
                Response.Redirect("~/Login/Login");
            }

          return RedirectToAction("Index", "Beranda");
        }

    }
}