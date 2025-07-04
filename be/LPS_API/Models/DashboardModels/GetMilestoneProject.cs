using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.DashboardModels
{
    public class GetMilestoneProject
    {
        public int id { get; set; }
        public string MilestoneTask { set; get; }
        public string MilestoneProgress { get; set; }
        public string Selesai { get; set; }
    }
}