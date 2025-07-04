using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.ReportModels
{
    public class LaporanGrafikSeriesPeriode
    {
        public string Filter { get; set; }

        public int Year { get; set; }

        public string Periode { get; set; }

        public double Hasil { get; set; }

        public double BelumMulai { get; set; }

        public double Complete { get; set; }
    }
}