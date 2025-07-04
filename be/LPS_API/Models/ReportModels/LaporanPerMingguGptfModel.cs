using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.ReportModels
{
    public class LaporanPerMingguGptfModel
    {
        public HeaderReportGptf HeaderReport { get; set; }
        public List<DataHeaderReportGptf> HeaderDataReport { get; set; }
        public List<DataListReportGptf> ListDataReport { get; set; }
    }

    public class HeaderReportGptf
    {
        public int Month { get; set; }

        public string Year { get; set; }

        public int? Week { get; set; }

    }

    public class DataHeaderReportGptf
    {
        public int IDProgram { get; set; }
        public string ProgramName { get; set; }
    }

    public class DataListReportGptf
    {
        public int IDProjectHeader { get; set; }
        public int IDProgram { get; set; }
        public string ProgramName { get; set; }
        public string ProgramNo { get; set; }
        public string Pic { get; set; }
        public string ProjectNo { get; set; }
        public string ProjectName { get; set; }
        public int Target { get; set; }
        public int Realisasi { get; set; }
        public int Pencapaian { get; set; }
        public string Kendala { get; set; }
        public string Aksi { get; set; }
        public DateTime TargetFinished { get; set; }
        public int IDProjectStatus { get; set; }
        public DateTime? DateFinished { get; set; }
        public int TargetLastWeek { get; set; }
        public int RealisasiLastWeek { get; set; }
        public int PencapaianLastWeek { get; set; }
    }
}