using LPS_API.Models.DashboardModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.DashboardControllers
{
    public class DashboardProjectConstraintController : ApiController
    {

        [HttpGet]
        public List<DashboardProjectConstraint> GetDashboardProjectConstraintByProject(int projectId)
        {
            return DashboardProjectConstraint.GetByProject(projectId);
        }
    }
}
