using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.ReportModels
{
    public class LaporanKendalaModel
    {
        public string ProjectNo { get; set; }
        public string IDProjectHeader      {get;set;}
        public string ProjectName          {get;set;}
        public string DepartmentCode       {get;set;}
        public string Pencapaian           {get;set;}
        public string ConstraintName       {get;set;}
        public string mitigasi             {get;set;}
        public string problem              {get;set;}
        public string remarks              { get; set; }
        public string Description { get; set; }
        public string status { get; set; }
    }
}