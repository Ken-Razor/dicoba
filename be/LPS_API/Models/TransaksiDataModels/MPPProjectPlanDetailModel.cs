using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.TransaksiDataModels
{
    public class MPPProjectPlanDetailModel
    {
        public int NoUrut { get; set; }

        public int IDMPPProjectPlanDetail { get; set; }

        public int ProjectHeaderID { get; set; }

        public int ParentID { get; set; }

        public int TaskID { get; set; }

        public string TaskGUID { get; set; }

        public string TaskName { get; set; }

        public DateTime StartDate { get; set; }

        public string StartDateString { get; set; }

        public DateTime EndDate { get; set; }

        public string EndDateString { get; set; }

        public string Duration { get; set; }

        public string Notes { get; set; }

        public double PercentageComplete { get; set; }

        public string OutlineLevel { get; set; }

        public string OutlineNumber { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public Boolean IsActive { get; set; }
    }
}