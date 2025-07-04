using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.DashboardModels
{
    public class DashboardProjectStakeholder
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }

        public DashboardProjectStakeholder() { }
        public DashboardProjectStakeholder(int stakeholderId, int projectId, string stakeholderRole, string stakeholderName)
        {
            Id = stakeholderId;
            ProjectId = projectId;
            Role = stakeholderRole;
            Name = stakeholderName;
        }
    }
}