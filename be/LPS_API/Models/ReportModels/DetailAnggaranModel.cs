using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.ReportModels
{
    public class DetailAnggaranModel
    {
        public int IDDirektorat { get; set; }

        public int IDDepartment { get; set; }

        public string NoUrut { get; set; }

        public string DirektoratName { get; set; }

        public string DepartmentName { get; set; }

        public string IDSAP { get; set; }

        public string YEAR { get; set; }

        public string EVDESCRIPTION { get; set; }

        public string ACCT_CODE { get; set; }

        public string EVDESCRIPTION_Detail { get; set; }

        public string Anggaran { get; set; }

        public string Pergeseran { get; set; }

        public string Hangus { get; set; }

        public string Realisasi { get; set; }

        public string Komitmen { get; set; }

        public string Sisa { get; set; }
    }
}