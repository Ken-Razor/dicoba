using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.TransaksiDataModels
{
    public class ProjectInitReviseRoleModel
    {
        public int NoUrut { get; set; }
        public int IDProjectInitApprovalHistory { get; set; }
		public string Type { get; set; }
		public string Deskripsi { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedDateString { get; set; }
        public string CreatedBy { get; set; }
    }
}