using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.ReportModels
{
    public class CapaianProyekModel
    {
        public int IDProjectHeader { get; set; }

        public int IDProgram { get; set; }

        public string NamaProgram { get; set; }

        public string RataPencapain { get; set; }

        public string Status { get; set; }

        public string TotalAnggaran { get; set; }

        public string Realisasi { get; set; }

        public string Realkomit { get; set; }

        public int month { get; set; }

        public int year { get; set; }

        public int tipe { get; set; }

        public int week { get; set; }
    }
}