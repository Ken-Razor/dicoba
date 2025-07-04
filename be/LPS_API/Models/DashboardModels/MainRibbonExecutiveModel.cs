using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.DashboardModels
{
    public class MainRibbonExecutiveModel
    {
        public string Transformation { get; set; }

        public string TransformationPercentage { get; set; }

        public string NonTransformation { get; set; }

        public string NonTransformationPercentage { get; set; }

        public string ProgressTransfomation { get; set; }

        public string ProgressNonTransformation { get; set; }

        public string CostTransformation { get; set; }

        public string CostNonTransformation { get; set; }

        public string LastUpdated { get; set; }
    }
}