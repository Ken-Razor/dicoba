using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.DashboardModels
{
    public class DashboardStatusProject
    {
        public string StatusName { get; set; }
        public double Percentase { get; set; }
        public int Total { get; set; }
    }
}