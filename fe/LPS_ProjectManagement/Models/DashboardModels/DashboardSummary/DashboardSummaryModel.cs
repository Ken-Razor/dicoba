using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.DashboardModels.DashboardSummary
{
    public class DashboardSummaryModel
    {
        public string Filter { get; set; }

        public string Year { get; set; }

        public int Month { get; set; }

        public int Week { get; set; }

        public int JumlahWeek { get; set; }

        public string[] Categories { get; set; }

        public string PersonalNumber { get; set; }

        public List<StakedBar> ListStakedBar { get; set; }
    }

    public class StakedBar
    {
        public int id { get; set; }

        public string name { get; set; }

        public string color { get; set; }

        public int[] data { get; set; }
    }
}