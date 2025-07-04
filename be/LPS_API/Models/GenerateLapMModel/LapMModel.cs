using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.ReportModels
{
    public class LapMDataModel
    {
        public DateTime tanggal { get; set; }
    }

    public class LapMProgressHModel
    {
        public double Target { get; set; }
        public double Realisasi { get; set; }
        public double Pencapaian { get; set; }
        public double PencapaianLalu { get; set; }
    }

    public class LapMTSeriesModel
    {
        public string Minggu { get; set; }
        public string Periode { get; set; }
        public double Target { get; set; }
        public double Realisasi { get; set; }
    }

    public class LapMTPencapaian
    {
        public string Pencapaian { get; set; }
        public string PencapaianLalu { get; set; }
    }
    public class RealisasiAnggaran
    {
        public double Anggaran { get; set; }
        public double Realisasi { get; set; }
        public double KomitAnggaran { get; set; }
        public double Jumlah { get; set; }
        public double Persentase { get; set; }
    }
    public class LapMTStatusPerMinggu
    {
        public string Keterangan { get; set; }
        public string Minggu { get; set; }
        public string Pencapaian { get; set; }
        public string Pencapaian2 { get; set; }
        public string Pencapaian3 { get; set; }
        public string Pencapaian4 { get; set; }
        public string Pencapaian5 { get; set; }
    }
}