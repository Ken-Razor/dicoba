using LPS_API.Models.MasterDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.TransaksiDataModels
{
    public class ProjectHeaderCostModel
    {
        public int IDProjectHeaderCost { get; set; }

        public int IDProjectHeader { get; set; }

        public int IDProjectCost { get; set; }

        public double Value { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public ProjectCostModel ProjectCost { get; set; }
    }
}