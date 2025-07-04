using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.MasterDataModels
{
    public class MkuModel
    {
        public int IdMku { get; set; }
        public int IdDepartment { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
    }
}