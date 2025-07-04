using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.DashboardModels
{
    public class GetTableEksekutif
    {
        public int IDProject { get; set; }
        public string ProjectNo { get; set; }
        public string ProjectName { get; set; }
        public int IsTransformation { get; set; }
        public string Initiation { get; set; }
        public int Perkembangan { get; set; }
        public int Anggaran { get; set; }
    }
}