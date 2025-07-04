using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.TransaksiDataModels
{
    public class ProjectDetailModel
    {
        public int NoUrut { get; set; }

        public int IDProjectDetail { get; set; }

        public int IDProjectHeader { get; set; }

        public string Background { get; set; }

        public string Objective { get; set; }

        public string ScopeOfWork { get; set; }

        public string BudgetDescription { get; set; }

        public byte[] OrganizationChart { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public Boolean IsActive { get; set; }
    }
}