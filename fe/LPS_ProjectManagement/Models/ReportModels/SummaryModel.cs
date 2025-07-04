using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.ReportModels
{
    public class SummaryModel
    {
        public int IDStrategicObjective { get; set; }

        public string StrategicObjectiveName { get; set; }

        public int JumlahProject { get; set; }

        public int DiatasTarget_T { get; set; }

        public int SesuaiTarget_T { get; set; }

        public int DibawahTarget_T { get; set; }

        public int JauhDibawahTarget_T { get; set; }

        public int BelumDimulai_T { get; set; }

        public int Selesai_T { get; set; }

        public int DiatasTarget_NT { get; set; }

        public int SesuaiTarget_NT { get; set; }

        public int DibawahTarget_NT { get; set; }

        public int JauhDibawahTarget_NT { get; set; }

        public int BelumDimulai_NT { get; set; }

        public int Selesai_NT { get; set; }

        public int Month { get; set; }

        public string Year { get; set; }
    }
}