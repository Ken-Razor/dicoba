using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.ReportModels
{
    public class SeriesGrafikModel
    {
        public string Tahun { get; set; }
        public string TotalProject { get; set; }
        public string TotalAnggaran { get; set; }
        public string Pencapaian { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Week { get; set; }

    }
}