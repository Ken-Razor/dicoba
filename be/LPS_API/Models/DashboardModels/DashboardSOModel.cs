using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.DashboardModels
{
    public class DashboardSOModel
    {
        public string StrategicObjectiveCode { get; set; }
        public int TotalUsedSO { get; set; }
    }
}