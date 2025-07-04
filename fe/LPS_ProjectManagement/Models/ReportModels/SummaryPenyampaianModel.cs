using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.ReportModels
{
    public class SummaryPenyampaianModel
    {
        public string Direktorat { get; set; }
        public string DraftProjAdmin { get; set; }
        public string SubmitProjAdmin { get; set; }
        public string ApproveProjManager { get; set; }
        public string ApproveProgManager { get; set; } 
    }
}