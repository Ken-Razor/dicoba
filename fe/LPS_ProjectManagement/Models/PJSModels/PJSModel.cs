using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.PJSModels
{
    public class PJSModel
    {
        public string NoUrut { get; set; }

        public string ID { get; set; }

        public string ExistingName { get; set; }

        public string ExistingUsername { get; set; }

        public string ExistingPersonalNumber { get; set; }

        public string ExistingPositionCode { get; set; }

        public string PJSName { get; set; }

        public string PJSUsername { get; set; }

        public string PJSPersonalNumber { get; set; }

        public string PJSPositionCode { get; set; }

        public string IDRoleGroup { get; set; }

        public DateTime StartDate { get; set; }

        public string StartDateString { get; set; }

        public DateTime EndDate { get; set; }

        public string EndDateString { get; set; }

        public string Note { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedDateString { get; set; }

        public string UpdatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public string PersonalNumber { get; set; }

        public string TypeTransaction { get; set; }
    }
}