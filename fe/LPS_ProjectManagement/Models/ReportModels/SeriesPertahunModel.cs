using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.ReportModels
{
    public class SeriesPertahunModel
    {
        public string Tahun { get; set; }
        public string TotalProject { get; set; }
        public string TotalAnggaran { get; set; }
        public string Pencapaian { get; set; }
        public string CapaianKPI { get; set; }
        public int thn1 { get; set; }
        public int thn2 { get; set; }
    }
}