using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.BackgroundJobControllers
{
    public class GenerateKPIValueJobController : ApiController
    {
        public string Get()
        {
            try
            {
                BackgroundJob b = new BackgroundJob();
                var res = b.GenerateKpiValueJob();
                return "Generate KPI value success";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
