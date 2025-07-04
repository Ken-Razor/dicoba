using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.DashboardModels
{
    public class DashboardProjectMilestone
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime TargetDate { get; set; }
        public ProjectMilestoneStatus Status { get; set; }

        public DashboardProjectMilestone() { }
        public DashboardProjectMilestone(int milestoneId, int projectId, string milestoneName, DateTime targetDate, ProjectMilestoneStatus milestoneStatus)
        {
            Id = milestoneId;
            ProjectId = projectId;
            Name = milestoneName;
            TargetDate = targetDate;
            Status = milestoneStatus;
        }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProjectMilestoneStatus
    {
        NotStarted = 0,
        OnProgress = 1,
        Completed = 2
    }
}