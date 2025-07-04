using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.ReportModels
{
    public class LaporanForecastModel
    {
        public string Periode { get; set; }
        public double? Realisasi { get; set; }
        public double? Forecast { get; set; }
    }

    public class LaporanForecastExcelModel
    {
        public List<LaporanForecastModel> LaporanForecast { get; set; }
        public LaporanForecastParamModel LaporanLaporanForecastParam { get; set; }
    }

    public class LaporanForecastParamModel
    {
        public int ProjectHeaderId { get; set; }
        public bool IsTransformasi { get; set; }
        public int ForecastMethod { get; set; }
        public string ProjectName { get; set; }
        public string ForecastMethodName { get; set; }
    }

    public class LaporanForecastViewModel
    {
        public LaporanForecastParamModel Param { get; set; }
        public List<LaporanForecastModel> ForecastModel { get; set; }
    }

    public class ProjectForecastModel
    {
        public int ProyekPK { get; set; }
        public string KodeProyek { get; set; }
        public string NamaProyek { get; set; }
        public int isTransformasi { get; set; }
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime TanggalMulaiProyek { get; set; }
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime TanggalSelesaiProyek { get; set; }
    }

}