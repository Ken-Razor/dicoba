using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.TransaksiDataModels
{
    public class ProjectRiskModel
    {
        public int IDProjectRisk { get; set; }

        public int IDProjectHeader { get; set; }

        public string Constraints { get; set; }

        public string Assumptions { get; set; }

        public string Risk { get; set; }

        public string Approach { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public Boolean IsActive { get; set; }
    }

    public class FileModel
    {
        public int ID { get; set; }
        public string DocName { get; set; }
    }
}