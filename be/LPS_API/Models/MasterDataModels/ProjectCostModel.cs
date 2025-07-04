using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.MasterDataModels
{
    public class ProjectCostModel
    {
        public int NoUrut { get; set; }

        public int IDProjectCost { get; set; }

        public string ProjectCostCode { get; set; }

        public string ProjectCostName { get; set; }

        public string Description { get; set; }

        public string ParentCode { get; set; }

        public string Value { get; set; }

        public string Pergeseran { get; set; }

        public string Hangus { get; set; }

        public string Realisasi { get; set; }

        public string Komitmen { get; set; }

        public string Year { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public Boolean IsActive { get; set; }
    }
}