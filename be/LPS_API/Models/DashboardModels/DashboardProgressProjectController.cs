using LPS_API.Models.DashboardModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace LPS_API.Controllers.DashboardControllers
{
    public class DashboardProgressProjectController : ApiController
    {
        [HttpGet]
        public List<DashboardProgressProject> GetDashboardProgressProject(int projectid, string year, string month, string week)
        {
            return DashboardProgressProject.GetByProject(projectid, year, month, week);
        }

        [HttpGet]
        public List<DashboardProgressProject> GetDashboardProgressProject(int projectId)
        {
            return DashboardProgressProject.GetByProject(projectId);
        }
    }
}