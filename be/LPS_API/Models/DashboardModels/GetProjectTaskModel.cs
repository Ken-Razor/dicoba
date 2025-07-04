using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.DashboardModels
{
    public class GetProjectTaskModel
    {
        public string TaskName { get; set; }
        public string PIC { get; set; }
        public decimal Plan { get; set; }
        public decimal Real { get; set; }
    }
}