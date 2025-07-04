using LPS_BLL;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LPS_API.Models.DashboardModels
{
    public class DashboardProjectMilestone
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string TargetDate { get; set; }
        public int Status { get; set; }

        public static List<DashboardProjectMilestone> GetByProject(int projectId)
        {
            List<DashboardProjectMilestone> ldps = new List<DashboardProjectMilestone>();
            BerandaProject bp = new BerandaProject();
            DataTable dt = bp.ProjectMileStone(projectId, "", "", "");
            DashboardProjectMilestone dps = null;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dps = new DashboardProjectMilestone();
                    dps.Name = dr["Name"].ToString();
                    dps.TargetDate = dr["TargetDate"].ToString();
                    dps.Status = (int)dr["Status"];
                    ldps.Add(dps);
                }
            }
            return ldps;
        }

        public static List<DashboardProjectMilestone> GetByProject(int projectid, string year, string month, string week)
        {
            List<DashboardProjectMilestone> ldps = new List<DashboardProjectMilestone>();
            BerandaProject bp = new BerandaProject();
            DataTable dt = bp.ProjectMileStone(projectid, year, month, week);
            DashboardProjectMilestone dps = null;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dps = new DashboardProjectMilestone();
                    dps.Name = dr["Name"].ToString();
                    dps.TargetDate = dr["TargetDate"].ToString();
                    dps.Status = (int)dr["Status"];
                    ldps.Add(dps);
                }
            }
            return ldps;
        }
    }
}