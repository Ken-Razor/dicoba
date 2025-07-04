using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.MasterDataModels
{
    public class KPIValueModel
    {
        public string NoUrut { get; set; }

        public int IDKPIValue { get; set; }

        public int IDProject { get; set; }

        public string ProjectName { get; set; }

        public string ProjectNo { get; set; }

        public string TW1 { get; set; }

        public string TW2 { get; set; }

        public string TW3 { get; set; }

        public string TW4 { get; set; }

        public string PersonNumber { get; set; }
    }
}