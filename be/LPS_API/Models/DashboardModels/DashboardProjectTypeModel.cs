using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.DashboardModels
{
    public class DashboardProjectTypeModel
    {
        public string SOID { get; set; }
        public List<DashboardProjectTypeSO> ProjectType { get; set; }
        public List<ProjectListSODashboard> ProjectList { get; set; }
    }
}