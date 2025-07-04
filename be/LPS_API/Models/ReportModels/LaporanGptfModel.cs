using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.ReportModels
{
    public class LaporanGptfModel
    {
        public int ProjectHeaderId { get; set; }
        public int TaskId { get; set; }
        public string ProjectNo { get; set; }
        public string ProjectName { get; set; }
        public string Waktu { get; set; }
        public string Approach { get; set; }
        public int PlanPercentage { get; set; }
        public int CompletePercentage { get; set; }
        public int Capaian { get; set; }
        public string TargetBulanan { get; set; }
        public string RealisasiBulanan { get; set; }
        public string Status { get; set; }
        public string Kendala { get; set; }
        public int IDProject { get; set; }
        public int? Parent { get; set; }
        public int IDProjectStatusLast { get; set; }
        public int IDProjectStatus { get; set; }
    }

    public class LaporanGptfParentModel
    {
        public int ProjectHeaderId { get; set; }
        public int ParentId { get; set; }
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string OutlineNumber { get; set; }
    }

    public class LaporanGptfChildModel
    {
        public int ProjectHeaderId { get; set; }
        public int ParentId { get; set; }
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string Notes { get; set; }
        public double PlanPercentage { get; set; }
        public double CompletePercentage { get; set; }
        public string OutlineNumber { get; set; }
    }

    public class LaporanGptfParamModel
    {
        public String Year { get; set; }
        public int Month { get; set; }
    }
}