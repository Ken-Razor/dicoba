using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LPS_API.Models.DashboardModels
{
    public class DashboardProjectConstraint
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Rule { get; set; }

        public static List<DashboardProjectConstraint> GetByProject(int projectId)
        {
            List<DashboardProjectConstraint> ldpc = new List<DashboardProjectConstraint>();
            DashboardProjectConstraint dpc = null;
            BerandaProject bp = new BerandaProject();
            DataTable dt = bp.ProjectConstraint(projectId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dpc = new DashboardProjectConstraint();
                    dpc.Name = dr["Name"].ToString();
                    dpc.Rule = dr["Rule"].ToString();
                    ldpc.Add(dpc);
                }
            }
            return ldpc;
        }
    }
}