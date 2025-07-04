using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.ProyekModels
{
    public class ExecutionModel
    {
        public int ProyekPK { get; set; }

        public string NamaProyek { get; set; }

        public string NomorProyek { get; set; }
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime TanggalMulaiProyek { get; set; }
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime TanggalTutupProyek { get; set; }

        public float PersentaseKomplit { get; set; }

        //public float Durasi { get; set; }

        public float Targets { get; set; }

        public string Realisasi { get; set; }

        public string TerakhirDirubahOleh { get; set; }

        public string TerakhirDirubahPada { get; set; }

        public string Stasus { get; set; }

        public int isTransformasi { get; set; }

        public string ProjectStatus { get; set; }

        public float KPI { get; set; }
    }
}