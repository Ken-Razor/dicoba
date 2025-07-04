using LPS_API.Models.DashboardModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.DashboardControllers
{
    public class DashboardProjectStakeholderController : ApiController
    {
        [HttpGet]
        public List<DashboardProjectStakeholder> GetDashboardProjectStakeholders(int projectid, string year, string month, string week)
        {
            return DashboardProjectStakeholder.Get(projectid, year, month, week);
        }

        [HttpGet]
        public List<DashboardProjectStakeholder> GetDashboardProjectStakeholdersByProject(int projectId)
        {
            return DashboardProjectStakeholder.GetByProject(projectId);
        }
    }
}
