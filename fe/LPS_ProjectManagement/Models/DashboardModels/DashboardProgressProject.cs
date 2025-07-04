using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.DashboardModels
{
    public class DashboardProgressProject
    {
        public string period { get; set; }
        public decimal plan { get; set; }
        public decimal real { get; set; }
        public int status { get; set; }
    }
}