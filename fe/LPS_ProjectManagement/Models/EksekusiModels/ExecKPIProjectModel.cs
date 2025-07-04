using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.EksekusiModels
{
    public class ExecKPIProjectModel
    {
        public double IDMPPProjectKPI { get; set; }
        public double IDMPPProjectPlanDetail { get; set; }
		public int ProjectHeaderID { get; set; }
		public double ParentID { get; set; }
		public double TaskID { get; set; }
		public string TaskGUID { get; set; }
		public string TaskName { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string Duration { get; set; }
		public string Notes { get; set; }
		public float PercentageComplete { get; set; }
		public string OutlineLevel { get; set; }
		public string OutlineNumber { get; set; }
		public int IsMilestone { get; set; }
		public int IsActive { get; set; }
		public int IsTransform { get; set; }
		public int Bobot { get; set; }
		public int KPI { get; set; }
		public int Flag { get; set; }
	}
}