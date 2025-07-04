using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.EksekusiModels
{
    public class EksekusiMilestone
    {
        public List<Milestone> miles { get; set; }
        public List<MilestoneFile> file { get; set; }
        public string ProjectStatus { get; set; }
        public string MilestoneStatus { get; set; }

    }

    public class MilestoneFile
    {
        public string DocumentName { get; set; }
        public string IDDocumentType { get; set; }
        public string IDDocumentMilestone { get; set; }
        public DateTime CreatedDate { get; set;}
    }
}