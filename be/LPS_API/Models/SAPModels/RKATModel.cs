using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.SAPModels
{
    public class RKATModel
    {
        public int NoUrut { get; set; }

        public int IDSAPRKAT { get; set; }

        public string IDSAP { get; set; }

        public string ACTIVE { get; set; }

        public string COSTCTR { get; set; }

        public string KPI { get; set; }

        public string LEVEL { get; set; }

        public string SCALING { get; set; }

        public string STRAT_OBJ { get; set; }

        public string WORKPLAN_TYPE { get; set; }

        public string YEAR { get; set; }

        public string PARENT { get; set; }

        public string DESCRIPTION { get; set; }

        public string LONG_DESC { get; set; }

        public string EVDESCRIPTION { get; set; }

        public string KPI_GROUP { get; set; }

        public string PRO_GROUP { get; set; }

        public string UNCONTROLLABLE { get; set; }

        public string Value { get; set; }
    }
}