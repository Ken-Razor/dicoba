using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.MasterDataModels
{
    public class MasterHolidayModel
    {
        public int IDHoliday { get; set; }
        public string Nama { get; set; }
        public DateTime TglMulai { get; set; }
        public DateTime TglSelesai { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }

    public class ddlYear
    {
        public int id { get; set; }

        public string Description { get; set; }

    }
}