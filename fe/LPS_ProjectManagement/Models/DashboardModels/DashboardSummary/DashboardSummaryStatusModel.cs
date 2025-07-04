using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.DashboardModels.DashboardSummary
{
    public class DashboardSummaryStatusModel
    {
        public string Filter { get; set; }

        public string Code { get; set; }

        public int? IsTransformasi { get; set; }

        public string Year { get; set; }

        public int Month { get; set; }

        public int Week { get; set; }

        public int Draft { get; set; }

        public int JauhDibawahTarget { get; set; }

        public int DibawahTarget { get; set; }

        public int SesuaiTarget { get; set; }

        public int DiatasTarget { get; set; }

        public int Completed { get; set; }

        public List<TableSummaryProject> ListTableSummaryProject { get; set; }
    }
}