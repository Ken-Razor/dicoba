using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.DashboardModels
{
    public class DashboardProjectConstraint
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Rule { get; set; }

        public DashboardProjectConstraint() { }
        public DashboardProjectConstraint(int constraintId, int projectId, string constraintName, string constraintRule)
        {
            Id = constraintId;
            ProjectId = projectId;
            Name = constraintName;
            Rule = constraintRule;
        }
    }
}