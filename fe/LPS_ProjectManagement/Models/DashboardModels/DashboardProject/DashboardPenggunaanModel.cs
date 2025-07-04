using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.DashboardModels.DashboardProject
{
    public class DashboardPenggunaanModel
    {
        public string DepartementCode { get; set; }

        public int NoRealisation { get; set; }

        public int Completed { get; set; }

        public int WaitApproval { get; set; }

        public int Total { get; set; }

        public float PersenNorealisation { get; set; }

        public float PersenCompleted { get; set; }

        public float PersenWaitApproval { get; set; }

        public int IsTranformasi { get; set; }

        public string Year { get; set; }

        public int StartMonth { get; set; }

        public int EndMonth { get; set; }
    }
}