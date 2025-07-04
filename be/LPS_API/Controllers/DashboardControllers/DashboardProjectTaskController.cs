using LPS_API.Models.DashboardModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.DashboardControllers
{
    public class DashboardProjectTaskController : ApiController
    {
        [HttpGet]
        public List<DashboardProjectTask> GetDashboardProjectTask(int projectId, string year, string month, string week)
        {
            return DashboardProjectTask.Get(projectId, year, month, week);
        }

        [HttpGet]
        public List<DashboardProjectTask> GetDashboardProjectTaskByProject(int projectId)
        {
            return DashboardProjectTask.GetByProject(projectId);
        }
    }
}
