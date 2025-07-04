using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.DashboardModels
{
    public class DashboardSOStatus
    {
        public List<StatusProjectSODashboard> StatusList { get; set; }
        public List<ProjectListSODashboard> ProjectList { get; set; }

        /*Find By*/
        public string StrategicObjective { get; set; }
        public int ProjectType { get; set; }
    }
}