using LPS_API.Models.MasterDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.ReportModels
{
    public class ListEvaluasiCapaianProyekModel
    {
        public int NoUrut { get; set; }

        public int Month { get; set; }
        
        public string Year { get; set; }
        public int? Week { get; set; }

        public Boolean? IsTransformasi { get; set; }

        public int IDProgram { get; set; }

        public string ProgramName { get; set; }

        public string ProgramNo { get; set; }

        public string Description { get; set; }

        public int IDDirektorat { get; set; }
    }
}