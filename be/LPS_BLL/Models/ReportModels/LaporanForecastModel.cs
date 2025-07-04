using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPS_BLL.Models.ReportModels
{
    public class LaporanForecastModel
    {
        public string Periode { get; set; }
        public double? Realisasi { get; set; }
        public double? Forecast { get; set; }
        public double? Error { get; set; }
        public bool? Holdout { get; set; }
    }

    public class LaporanForecastParamModel
    {
        public int ProjectHeaderId { get; set; }
        public bool IsTransformasi { get; set; }
        public int ForecastMethod { get; set; }
    }

    public class ProjectForecastModel
    {
        public int ProyekPK { get; set; }
        public string KodeProyek { get; set; }
        public string NamaProyek { get; set; }
        public int isTransformasi { get; set; }
        public DateTime TanggalMulaiProyek { get; set; }
        public DateTime TanggalSelesaiProyek { get; set; }
    }

    public enum FORECAST_METHOD
    {
        Naive = 1,
        SMA = 2,
        WMA = 3,
        ES = 4,
        ARS = 5,
        Linear = 6
    };
}
