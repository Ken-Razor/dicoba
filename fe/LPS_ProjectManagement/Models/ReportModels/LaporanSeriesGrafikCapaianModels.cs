using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.ReportModels
{
    public class LaporanSeriesGrafikCapaianHeaderModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double RataRataCapaian { get; set; }
    }

    public class LaporanSeriesGrafikCapaianHeaderKpiModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double CapaianKpi { get; set; }
    }


    public class LaporanSeriesGrafikCapaianDetailModel
    {
        public string IDProjectHeader { get; set; }
        public string ProjectNo { get; set; }
        public string ProjectName { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Waktu { get; set; }
        public double RealisasiPencapaian { get; set; }
        public double Poin { get; set; }
        public double Bobot { get; set; }
    }
    public class LaporanSeriesGrafikCapaianViewModel
    {
        public List<LaporanSeriesGrafikCapaianHeaderModel> HeaderModel { get; set; }
        public List<LaporanSeriesGrafikCapaianDetailModel> DetailModel { get; set; }
    }

    public class LaporanSeriesGrafikCapaianKpiViewModel
    {
        public List<LaporanSeriesGrafikCapaianHeaderKpiModel> HeaderModel { get; set; }
        public List<LaporanSeriesGrafikCapaianDetailModel> DetailModel { get; set; }
    }

    public class LaporanSeriesGrafikCapaianExcelModel
    {
        public LaporanSeriesGrafikCapaianParamModel Param { get; set; }
        public List<LaporanSeriesGrafikCapaianDetailModel> Detail { get; set; }
    }

    public class LaporanSeriesGrafikCapaianParamModel
    {
        public string Year { get; set; }
        public int Month { get; set; }
        public int Week { get; set; }
        public string Category { get; set; }
        public string Tw { get; set; }
        public string MonthName { get; set; }
        public string CategoryName { get; set; }
        public string JenisCapaian { get; set; }
    }
}