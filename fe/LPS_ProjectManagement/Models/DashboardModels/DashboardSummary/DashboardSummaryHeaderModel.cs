using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.DashboardModels.DashboardSummary
{
    public class DashboardSummaryHeaderModel
    {
        public string Filter { get; set; }

        public string Year { get; set; }

        public int Month { get; set; }

        public int Week { get; set; }

        public string id { get; set; }

        public int Transformasi { get; set; }

        public int NonTransformasi { get; set; }

        public List<TableSummaryProject> ListTableSummaryProject { get; set; }
    }

    public class TableSummaryProject
    {
        public int IDProjectHeader { get; set; }

        public string ProjectName { get; set; }

        public string ProjectNo { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string RealisasiPencapaian { get; set; }
    }
}