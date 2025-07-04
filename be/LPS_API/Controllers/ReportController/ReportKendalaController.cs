using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LPS_BLL;

namespace LPS_API.Controllers.ReportController
{
    public class ReportKendalaController : ApiController
    {
        Report R = new Report();
        public List<object> Get(string Year , string Month , string Week)
        {
            var Data = R.Get_ReportKendala(Year, Month , Week);
            return Data;
        }
    }
}
