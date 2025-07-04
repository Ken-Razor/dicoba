using LPS_API.Models.DataWarehouseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.TransaksiDataModels
{
    public class UserAuthorizedModel
    {
        public int IDUserAuthorized { get; set; }

        public string Username { get; set; }

        public int PersonNumber { get; set; }

        public DateTime LastLogin { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public EmployeeModel Employee { get; set; }
    }
}