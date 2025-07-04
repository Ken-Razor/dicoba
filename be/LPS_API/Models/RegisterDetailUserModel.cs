using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models
{
    public class RegisterDetailUserModel
    {
        public string IDUser { get; set; }

    }

    public class TableTypeRoles
    {
        public int IDProgram { get; set; }
        public int IDProject { get; set; }
        public string IDRoles { get; set; }
    }

    public class MultiPorpose
    {
        public string ID { get; set; }
    }

    public class InsertDataUser
    {
        public string PersonNumber { get; set; }
        public string CreateBy { get; set; }
        public List<TableTypeRoles> RolesGroup { get; set; }
    }
}