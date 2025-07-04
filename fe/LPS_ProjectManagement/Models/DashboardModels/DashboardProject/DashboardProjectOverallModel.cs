using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.DashboardModels
{
    public class DashboardProjectOverallModel
    {
        public string Filter { get; set; }

        public string Year { get; set; }

        public int ID { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int TotalTransforamsi { get; set; }

        public int TotalNonTransforamsi { get; set; }

        public int TotalProject { get; set; }

        public string PersonalNumber { get; set; }
    }
}