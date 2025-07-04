using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.DashboardControllers
{
    public class Dashboard2Controller : ApiController
    {
        public string Get()
        {
            DashboardData dd = new DashboardData();

            return dd.GenerateDashboard2();
        }
    }
}
