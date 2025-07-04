using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.ReportModels
{
    public class AllDataRowModel
    {
        public string No { get; set; }

        public string IDStrategicObjective { get; set; }

        public string StrategicObjectiveCode { get; set; }

        public string IDProgram { get; set; }

        public string ProgramNo { get; set; }

        public string IDProjectHeader { get; set; }

        public string ProjectNo { get; set; }

        public string IDDirektorat { get; set; }

        public string DirektoratName { get; set; }

        public string StrategicObjectiveName { get; set; }

        public string ProgramName { get; set; }

        public string ProjectName { get; set; }

        public string DepartmentCode { get; set; }

        public string NamaProjectManager { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string Pencapaian { get; set; }

        public string PlanPencapaian { get; set; }

        public string RealisasiPencapaian { get; set; }

        public string Kendala { get; set; }

        public string RencanaAksi { get; set; }

        public string Anggaran { get; set; }

        public string RealisasiAnggaran { get; set; }

        public string KomitAnggaran { get; set; }

        public string Target { get; set; }

        public string Realisasi { get; set; }

        public string IsTransformasi { get; set; }

        public string IDProjectStatus { get; set; }

        public string Year { get; set; }

        public string Month { get; set; }

        public string Week { get; set; }

        public string LastUpdated { get; set; }

        public string StatusProject { get; set; }

        public string NamaProgramManager { get; set; }

        public string NamaProjectOwner { get; set; }

        public string NamaProjectSponsor { get; set; }

        public string Periode { get; set; }
        public string StatusProjectHeader { get; set; }
    }
}