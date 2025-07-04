using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.MasterDataModels
{
    public class StrategicObjectiveModel
    {
        public int NoUrut { get; set; }

        public int IDStrategicObjective { get; set; }

        public string StrategicObjectiveCode { get; set; }

        public string StrategicObjectiveName { get; set; }

        public string Description { get; set; }

        public string Year { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public Boolean IsActive { get; set; }
    }
}