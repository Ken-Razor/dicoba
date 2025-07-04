using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.DashboardModels
{
    public class DashboardProjectTask
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public decimal Plan { get; set; }
        public decimal Real { get; set; }
        public DateTime TargetDate { get; set; }

        public DashboardProjectTask() { }
        public DashboardProjectTask(int taskId, int projectId, string taskName, decimal taskPlan, decimal taskReal, DateTime targetDate)
        {
            Id = taskId;
            ProjectId = projectId;
            Name = taskName;
            Plan = taskPlan;
            Real = taskReal;
            TargetDate = targetDate;
        }
    }
}