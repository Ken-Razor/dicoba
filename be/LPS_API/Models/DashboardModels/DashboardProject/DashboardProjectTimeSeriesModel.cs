using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.DashboardModels.DashboardProject
{
    public class DashboardProjectTimeSeriesModel
    {
        public string Filter { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public int Week { get; set; }

        public string PersonalNumber { get; set; }

        public string Periode { get; set; }

        public int Target { get; set; }

        public int Realisasi { get; set; }

        public string Temporary { get; set; }
    }
}