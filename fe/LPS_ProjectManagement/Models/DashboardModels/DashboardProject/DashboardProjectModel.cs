using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.DashboardModels
{
    public class DashboardProjectModel
    {
        public string Filter { get; set; }

        public string Year { get; set; }

        public int Month { get; set; }

        public int Week { get; set; }
        
        public string TotalProject { get; set; }

        public string Pencapaian { get; set; }

        public string Anggaran { get; set; }

        public string Realisasi { get; set; }

        public string PersonalNumber { get; set; }
    }
}