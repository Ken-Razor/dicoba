using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.DashboardModels
{
    public class StatusProjectSODashboard
    {
        public List<DashboardSOStatus> StatusList { get; set; }
        public List<ProjectListSODashboard> ProjectList { get; set; }

            /*Model for Finding*/
        public string StrategicObjective { get; set; }
        public string IsTransformation { get; set; }
    }
}