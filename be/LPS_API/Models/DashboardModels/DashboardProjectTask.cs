using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LPS_API.Models.DashboardModels
{
    public class DashboardProjectTask
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Plan { get; set; }
        public string Real { get; set; }
        //public DateTime TargetDate { get; set; }

        public static List<DashboardProjectTask> Get(int projectid, string year, string month, string week)
        {
            List<DashboardProjectTask> ldps = new List<DashboardProjectTask>();
            BerandaProject bp = new BerandaProject();
            DataTable dt = bp.ProjectTask(projectid, year, month, week);
            DashboardProjectTask dps = null;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dps = new DashboardProjectTask();
                    dps.Name = dr["name"].ToString();
                    dps.Plan = dr["plan"].ToString();
                    dps.Real = dr["real"].ToString();
                    ldps.Add(dps);
                }
            }
            return ldps;
        }

        public static List<DashboardProjectTask> GetByProject(int projectId)
        {
            List<DashboardProjectTask> ldps = new List<DashboardProjectTask>();
            BerandaProject bp = new BerandaProject();
            DataTable dt = bp.ProjectTask(projectId, "", "", "");
            DashboardProjectTask dps = null;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dps = new DashboardProjectTask();
                    dps.Name = dr["name"].ToString();
                    dps.Plan = dr["plan"].ToString();
                    dps.Real = dr["real"].ToString();
                    ldps.Add(dps);
                }
            }
            return ldps;
        }
    }
}