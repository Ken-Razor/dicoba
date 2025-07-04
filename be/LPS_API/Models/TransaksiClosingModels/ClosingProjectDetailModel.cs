using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.TransaksiClosingModels
{
    public class ClosingProjectDetailModel
    {
        public string ProjectName { get; set; }

        public int IDProjectClosing { get; set; }

        public int IDProjectHeader { get; set; }

        public DateTime ClosingDate { get; set; }

        public string Remarks { get; set; }

        public string WhatWorkWell { get; set; }

        public string WhatDidNotWorkWell { get; set; }

        public string WhatCanBeImproved { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public string StatusName { get; set; }
        public List<GlobalDocumentModel> Document {get;set;}
    }

    public class GlobalDocumentModel
    {
          public string ID       {get;set;}
          public string DocName  {get;set;}
          public string DocType  {get;set;}
    }
}