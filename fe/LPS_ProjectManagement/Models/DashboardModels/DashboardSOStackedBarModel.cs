using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.DashboardModels
{
    public class DashboardSOStackedBarModel
    {
        public List<SODetails> ListSoDetails { get; set; }

        public List<ProgressSO> ListProgressSO { get; set; }
    }

    public class ProgressSO
    {
        public string StatusName { get; set; }
        public List<Progress> Progres { get; set; }
    }

    public class Progress
    {
        public int ProgressData { get; set; }
    }

    public class SODetails
    {
        public string SOCode { get; set; }
        public string SOName { get; set; }
    }
}