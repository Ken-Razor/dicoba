using LPS_API.Models.DashboardModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.DashboardControllers
{
    public class DashboardProjectMilestoneController : ApiController
    {
        [HttpGet]
        public List<DashboardProjectMilestone> GetDashboardProjectMilestoneByProject(int projectId)
        {
            return DashboardProjectMilestone.GetByProject(projectId);
        }

        [HttpGet]
        public List<DashboardProjectMilestone> GetDashboardProjectMilestoneByProject(int projectid, string year, string month, string week)
        {
            return DashboardProjectMilestone.GetByProject(projectid, year, month, week);
        }
    }
}
