using LPS_API.Models.MasterDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.TransaksiDataModels
{
    public class ProjectConstraintModel
    {
        public int NoUrut { get; set; }

        public int IDProjectConstraint { get; set; }

        public int IDProjectHeader { get; set; }

        public int IDConstraintType { get; set; }

        public string Description { get; set; }

        public string Remarks { get; set; }

        public string Problem { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public ConstraintTypeModel ConstraintType { get; set; }
    }
}