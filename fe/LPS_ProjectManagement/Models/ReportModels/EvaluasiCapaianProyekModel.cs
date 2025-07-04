using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.ReportModels
{
    public class EvaluasiCapaianProyekModel
    {
        public int Month { get; set; }

        public string Year { get; set; }
        public int? Week { get; set; }

        public Boolean? IsTransformasi { get; set; }

        public int IDDirektorat { get; set; }

        public int IDProgram { get; set; }

        public int IDProject { get; set; }

        public string Name { get; set; }

        public string PIC { get; set; }

        public string Waktu { get; set; }

        public string ContractIDR { get; set; }

        public string Target { get; set; }

        public string Realisasi { get; set; }

        public string Capaian { get; set; }

        public string RealisasiAnggaran { get; set; }

        public string RealisasiKomit { get; set; }

        public string Tren { get; set; }

    }
}