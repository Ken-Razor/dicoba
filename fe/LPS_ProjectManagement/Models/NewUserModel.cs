using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models
{
    public class NewUserModel
    {
        public string IDProjectHeader { get; set; }
        public string ProgramName { get; set; }
        public string ProjectNo { get; set; }
        public string ProjectName { get; set; }
        public string ProjectTeam { get; set; }
        public string ProjectAdmin { get; set; }
        public string ProjectManager { get; set; }
        public string AdminPMO { get; set; }
        public string PMO { get; set; }
        public string HeadOfPMO { get; set; }
        public string ProjectOwner { get; set; }
        public string ProjectSponsor { get; set; }
    }
}