using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.ReportModels
{
    public class PDFLaporanBulananModel
    {
        public HeaderReport HeaderReport { get; set; }

        public List<DataReport> ListDataReport { get; set; }
    }

    public class HeaderReport
    {
        public string Bulan { get; set; }

        public string Year { get; set; }

        public string IsTransformasi { get; set; }

        public string Direktorat { get; set; }
    }

    public class DataReport
    {
        public string Tipe { get; set; }

        public int IDStrategicObjective { get; set; }

        public int? IDProgram { get; set; }

        public int? IDProjectHeader { get; set; }

        public int? IDDirektorat { get; set; }

        public string DirektoratCode { get; set; }

        public string DirektoratName { get; set; }

        public string StrategicObjective { get; set; }

        public string ProgramName { get; set; }

        public string ProjectName { get; set; }

        public string Name { get; set; }

        public string PIC { get; set; }

        public string Waktu { get; set; }

        public string Anggaran { get; set; }

        public string Target { get; set; }

        public string Realisasi { get; set; }

        public string RealisasiPencapaian { get; set; }

        public string Planning { get; set; }

        public string RealisasiAnggaran { get; set; }

        public string RealisasiKomit { get; set; }

        public string Tren { get; set; }

        public string TrenCurrent { get; set; }
        
        public int? IsTransformasi { get; set; }
    }
}