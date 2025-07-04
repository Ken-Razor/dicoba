using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.TransaksiChangeManagementModels
{
    public class ProjectChangesApprovalRoleModel
    {
        public int NoUrut { get; set; }

        public int IDProjectInitApprovalRole { get; set; }

        public int IDProjectHeader { get; set; }

        public int Sequence { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string PositionCode { get; set; }

        public string Jabatan { get; set; }

        public string Nama { get; set; }

        public string KodeUnitKerja { get; set; }

        public string PersonalNumber { get; set; }

        public string RoleGroupName { get; set; }

        public int IDRoleGroup { get; set; }

        public DateTime ActiveDate { get; set; }

        public DateTime EndDate { get; set; }

        public int IsEnabled { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public Boolean IsActive { get; set; }
    }
}