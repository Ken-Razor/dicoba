using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.ReportModels
{
    public class LaporanCapaian
    {
        public List<PencapaianTrans> Trans { get; set; }
        public List<PencapaianSO> SO { get; set; }
        public List<PencapaianDirektorat> Dir { get; set; }
    }

    public class PencapaianTrans
    {
        public string NamaProgram { get; set; }
        public string RataPencapain { get; set; }
        public string TotalAnggaran { get; set; }
        public string Status { get; set; }
        public string Realisasi { get; set; }
        public string Realkomit { get; set; }
    }

    public class PencapaianSO
    {
        public string NamaSO { get; set; }
        public string RataPencapain { get; set; }
        public string TotalAnggaran { get; set; }
        public string Status { get; set; }
        public string Realisasi { get; set; }
        public string Realkomit { get; set; }
    }

    public class PencapaianDirektorat
    {
        public string NamaDirektorat { get; set; }
        public string RataPencapain { get; set; }
        public string TotalAnggaran { get; set; }
        public string Status { get; set; }
        public string Realisasi { get; set; }
        public string Realkomit { get; set; }
    }

    public class PencapainParam
    {
        public int tipe { get; set; }
        public int week { get; set; }
        public int year { get; set; }
        public int month { get; set; }
        public string jenisapi { get; set; }
    }
}