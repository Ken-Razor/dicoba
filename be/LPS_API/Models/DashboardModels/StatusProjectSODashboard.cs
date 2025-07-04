using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.DashboardModels
{
    public class StatusProjectSODashboard
    {
        public string StatusName { get; set; }
        public int Total { get; set; }
        public string StrategicObjective { get; set; }

        /*Model for Finding*/
        public string IsTransformation { get; set; }
    }
}