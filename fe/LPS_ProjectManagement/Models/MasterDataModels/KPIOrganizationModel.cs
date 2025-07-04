using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.MasterDataModels
{
    public class KPIOrganizationModel
    {
        public int NoUrut { get; set; }

        public int IDKPIOrganization { get; set; }

        public string KPICode { get; set; }

        public string KPIName { get; set; }

        public string Year { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public Boolean IsActive { get; set; }
    }
}