using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LPS_BLL;
namespace LPS_API.Controllers.ReportController
{
    public class ProjectNameController : ApiController
    {
        public string Get(int ProjectHeaderID)
        {
            MasterData MD = new MasterData();
            var name = MD.GetProjectNameByHeader(ProjectHeaderID);
            return name;
        }
    }
}
