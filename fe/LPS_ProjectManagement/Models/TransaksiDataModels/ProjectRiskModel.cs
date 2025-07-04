using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.TransaksiDataModels
{
    public class ProjectRiskModel
    {
        public int IDProjectRisk { get; set; }

        public int IDProjectHeader { get; set; }

        public string Constraints { get; set; }

        public string Assumptions { get; set; }

        public string Risk { get; set; }

        public string Approach { get; set; }
    }

    public class FileModel
    {
        public int ID { get; set; }
        public string DocName { get; set; }
    }
}