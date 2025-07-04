using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.TransaksiChangeManagementModels
{
    public class ChangeManagementHeaderModel
    {
        public int NoUrut { get; set; }

        public int IDProject { get; set; }

        public string ProjectNo { get; set; }

        public string ProjectName { get; set; }

        public int IDProjectHeader { get; set; }

        public int Sequence { get; set; }

        public int IDProjectStatus { get; set; }

        public string StartYear { get; set; }

        public int StartMonth { get; set; }

        public string EndYear { get; set; }

        public int EndMonth { get; set; }

        public string NoKontrak { get; set; }

        public DateTime ContractStartDate { get; set; }

        public DateTime ContractEndDate { get; set; }

        public double ContractIDR { get; set; }

        public double ContractUSD { get; set; }

        public double WeightKPI { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedDateString { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public string StatusName { get; set; }

        public Boolean? IsTransformasi { get; set; }
    }
}