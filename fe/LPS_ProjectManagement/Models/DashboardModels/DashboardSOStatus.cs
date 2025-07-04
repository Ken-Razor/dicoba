using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.DashboardModels
{
    public class DashboardSOStatus
    {
        public string StatusName { get; set; }
        public int Total { get; set; }

        /*Find By*/
        public string StrategicObjective { get; set; }
        public int ProjectType { get; set; }
    }
}