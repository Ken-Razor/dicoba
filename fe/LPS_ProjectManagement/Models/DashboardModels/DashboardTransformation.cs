using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.DashboardModels
{
    public class DashboardTransformation
    {
        public string Details { get; set; }
        public double TransformationPercentase { get; set; }
        public double TotalProject { get; set; }
    }
}