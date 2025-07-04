using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.MasterDataModels
{
    public class RoleGroupModel
    {
        public int NoUrut { get; set; }

        public int IDRoleGroup { get; set; }

        public string RoleGroupName { get; set; }

        public string RoleGroupID { get; set; }

        public string Description { get; set; }

        public int Level { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public Boolean IsActive { get; set; }
    }
}