using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.DashboardModels
{
    public class DashboardEksekutif
    {
        public List<DashboardTransformation> ListTransformationProject { get; set; }
        public decimal BudgetTransformation { get; set; }
        public decimal BudgetTransformationPercent { get; set; }

        public decimal BudgetNonTransformation { get; set; }
        public decimal BudgetNonTransformationPercent { get; set; }

        public List<GetTableEksekutif> ListEksekutif { get; set; }
        public List<DashboardAllProjectStatus> ListStatusProject { get; set; }
    }
}