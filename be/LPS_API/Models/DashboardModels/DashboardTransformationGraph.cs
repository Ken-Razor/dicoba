using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.DashboardModels
{
    public class TransformationGraph
    {
        public double TotalTransformation { get; set; }
    }

    public class NonTransformationGraph
    {
        public double TotalNonTransformation { get; set; }
    }

    public class AverangeGraph
    {
        public double Averange { get; set; }
    }

    public class DashboardTransformationGraph
    {
        [JsonProperty(PropertyName = "Name")]
        public string DepartmentName { get; set; }

        public List<TransformationGraph> TransformationList { get; set; }

        public List<NonTransformationGraph> NonTransformationList { get; set; }

        public List<AverangeGraph> AverangeList { get; set; }
    }
   
}