using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.ProyekModels
{
    public class ClosingModel
    {
        public string ProjectPK { get; set; }

        public string NamaProject { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public HttpPostedFileBase DokumenSurvey { get; set; }
    }
}