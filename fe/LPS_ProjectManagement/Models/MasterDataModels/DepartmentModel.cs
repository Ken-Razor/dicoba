using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.MasterDataModels
{
    public class DepartmentModel
    {
        public int NoUrut { get; set; }

        public int IDDepartment { get; set; }

        public string DepartmentCode { get; set; }

        public string CostCenter { get; set; }

        public string DepartmentName { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedDateString { get; set; }

        public string UpdatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public int IDDirektorat { get; set; }

        public List<DirektoratModel> ListDirektorat { get; set; }
    }
}