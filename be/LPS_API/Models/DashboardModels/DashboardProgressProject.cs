using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LPS_API.Models.DashboardModels
{
    public class DashboardProgressProject
    {
        public string period { get; set; }
        public decimal plan { get; set; }
        public decimal real { get; set; }
        public int status { get; set; }

        public static List<DashboardProgressProject> GetByProject(int projectId)
        {
            List<DashboardProgressProject> ldps = new List<DashboardProgressProject>();
            BerandaProject bp = new BerandaProject();
            DataTable dt = bp.ProjectProgress(projectId, "", "", "");
            DashboardProgressProject dps = null;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dps = new DashboardProgressProject();
                    dps.period = dr["period"].ToString();
                    dps.plan = decimal.Parse(dr["plan"].ToString());
                    dps.real = decimal.Parse(dr["real"].ToString());
                    dps.status = (int)dr["status"];
                    ldps.Add(dps);
                }
            }
            return ldps;
        }
        public static List<DashboardProgressProject> GetByProject(int projectid, string year, string month, string week)
        {
            List<DashboardProgressProject> ldps = new List<DashboardProgressProject>();
            BerandaProject bp = new BerandaProject();
            DataTable dt = bp.ProjectProgress(projectid, year, month, week);
            DashboardProgressProject dps = null;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dps = new DashboardProgressProject();
                    dps.period = dr["period"].ToString();
                    dps.plan = decimal.Parse(dr["plan"].ToString());
                    dps.real = decimal.Parse(dr["real"].ToString());
                    dps.status = (int)dr["status"];
                    ldps.Add(dps);
                }
            }
            return ldps;
        }
    }
}