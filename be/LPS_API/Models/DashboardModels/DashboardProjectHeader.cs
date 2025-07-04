using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LPS_API.Models.DashboardModels
{
    public class DashboardProjectHeader
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsTransformation { get; set; }
        public string Pencapaian { get; set; }
        public string Anggaran { get; set; }
        public string Realisasi { get; set; }

        public static DashboardProjectHeader Get(int projectId)
        {
            BerandaProject bp = new BerandaProject();
            DashboardProjectHeader dhp = new DashboardProjectHeader();
            DataTable dt = bp.ProjectHeader(projectId);
            if (dt.Rows.Count > 0)
            {
                dhp.Id = (int)dt.Rows[0]["IDProject"];
                dhp.Code = dt.Rows[0]["Code"].ToString();
                dhp.Name = dt.Rows[0]["Name"].ToString();
                dhp.IsTransformation = (bool)dt.Rows[0]["IsTransformasi"];
                dhp.Pencapaian = dt.Rows[0]["Pencapaian"].ToString();
                dhp.Anggaran = dt.Rows[0]["Anggaran"].ToString();
                dhp.Realisasi = dt.Rows[0]["Realisasi"].ToString();
            }
            return dhp;
        }
    }
}