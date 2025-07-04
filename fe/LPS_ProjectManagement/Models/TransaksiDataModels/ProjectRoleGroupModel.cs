using LPS_ProjectManagement.Models.DataWareHouseModels;
using LPS_ProjectManagement.Models.MasterDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.TransaksiDataModels
{
    public class ProjectRoleGroupModel
    {
        public int IDProjectRoleGroup { get; set; }

        public int IDProjectHeader { get; set; }

        public int IDRoleGroup { get; set; }

        public int IDProgram { get; set; }

        public string RoleGroupID { get; set; }

        public string Username { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public UserAuthorizedModel UserAuthorized { get; set; }

        public RoleGroupModel RoleGroup { get; set; }

        public List<RoleGroupModel> ListRoleGroup { get; set; }
    }
}