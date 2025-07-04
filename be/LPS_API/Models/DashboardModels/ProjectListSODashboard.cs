using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.DashboardModels
{
    public class ProjectListSODashboard
    {
        public int IDProject { get; set; }
        public string ProjectNo { get; set; }
        public string ProjectName { get; set; }
        public string ContractStartDate { get; set; }
        public string ContractEndDate { get; set; }
        public string StatusName { get; set; }

        /*Finding Model*/
        public string StatusNameFinding { get; set; }
        public int IsTransformation { get; set; }
        public string StrategicObjective { get; set; }
    }
}