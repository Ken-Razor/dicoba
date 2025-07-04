using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.DashboardModels
{
    public class DashboardProjectProgressPerProjectModel
    {
        public string Filter { get; set; }

        public string Year { get; set; }

        public int Month { get; set; }

        public int Week { get; set; }

        public string name { get; set; }

        public int y { get; set; }

        public string color { get; set; }

        public int ID { get; set; }

        public string PersonalNumber { get; set; }
        public string NamaProject { get; set; }
        public string Pencapaian { get; set; }
    }
}