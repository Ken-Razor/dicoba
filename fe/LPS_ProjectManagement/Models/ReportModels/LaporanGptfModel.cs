using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.ReportModels
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
    }

    public class LaporanGptfParamModel{
        public String Year { get; set; }
        public int Month { get; set; }
    }

    public class LaporanGptfViewModel
    {
        public List<LaporanGptfModel> LaporanGptf { get; set; }
        public LaporanGptfParamModel Param { get; set; }
    }

}