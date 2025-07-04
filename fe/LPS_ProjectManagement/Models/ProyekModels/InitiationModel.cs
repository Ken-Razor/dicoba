using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.ProyekModels
{
    public class InitiationModel
    {
        public int ProyekPK { get; set; }

        public string NamaProyek { get; set; }

        public string NomorProyek { get; set; }

        public string TanggalMulaiProyek { get; set; }

        public string TanggalTutupProyek { get; set; }
    }
}