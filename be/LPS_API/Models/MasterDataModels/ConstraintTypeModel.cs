using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.MasterDataModels
{
    public class ConstraintTypeModel
    {
        public int NoUrut { get; set; }

        public int IDConstraintType { get; set; }

        public string ConstraintName { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public Boolean IsActive { get; set; }
    }
}