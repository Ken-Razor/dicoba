using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.DashboardModels
{
    public class GetProjectConstraintModel
    {
        public string Description { get; set; }
        public string Remarks { get; set; }
        public string Problem { get; set; }
        public string Status { get; set; }
        public string Mitigasi { get; set; }
        public string CreatedDate { get; set; }
    }
}