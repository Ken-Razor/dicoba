using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models
{
    public class DropDownUserManagementModel
    {
        public List<DropDownProject> Projects { get; set; }
        public List<DropDownProgram> Programs { get; set; }
        public List<DropDownRole> Roles { get; set; }

    } 

    public class DropDownProject
    {
        public int IDProject { get; set; }
        public string ProjectName { get; set; }
    }

    public class DropDownProgram
    {
        public int IDProgram { get; set; }
        public string ProgramName { get; set; }
    }

    public class DropDownRole
    {
        public int IDRoleGroup { get; set; }
        public string RoleGroupName { get; set; }
    }
}