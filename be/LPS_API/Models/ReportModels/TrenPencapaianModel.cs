using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.ReportModels
{
    public class TrenPencapaianModel
    {
        public int Year { get; set; }

        public int Month { get; set; }

        public int IsTransformasi { get; set; }

        public int NoUrut { get; set; }

        public int Point { get; set; }

        public string Keterangan { get; set; }

        public int TrenPencapaianTrans { get; set; }

        public int TrenPencapaianNonTrans { get; set; }
    }
}