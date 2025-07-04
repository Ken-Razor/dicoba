using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.EksekusiModels
{
    public class ExecutionReportModel
    {
        public int NoUrut { get; set; }

        public string Tanggal { get; set; }

        public string Keys { get; set; }

        public double Real { get; set; }

        public double Plan { get; set; }

        public string Approval { get; set; }

        public string UpdateDate { get; set; }

        public string Status { get; set; }

        public int IDProjectHeader { get; set; }

        public int IsTransformasi { get; set; }
    }

    public class ExecutionReport2Model
    {
        public int NoUrut { get; set; }

        public string Tanggal { get; set; }

        public string Keys { get; set; }

        public double Real { get; set; }

        public double Plan { get; set; }

        public string Approval { get; set; }

        public string UpdateDate { get; set; }

        public string Status { get; set; }
        public string Keterangan { get; set; }
        public string Kendala { get; set; }
        public string vars { get; set; }
        public int IDProjectHeader { get; set; }

        public int IsTransformasi { get; set; }
    }

    public class ExecutionProblemReportModel
    {
        public int IDProjectHeader { get; set; }
        public int IsTransformasi { get; set; }
        public int NoUrut { get; set; }
        public string Jenis { get; set; }
        public string Deskripsi { get; set; }

        public string Remark { get; set; }

        public string Problem { get; set; }

        public string Mitigasi { get; set; }
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime CreatedDate { get; set; }
    }

    public class ExecutionReportModelList
    {
        public string StatusTombol { get; set; }
        public List<ExecutionReportModel> All {get;set;}
        public List<ExecutionReportModel> Current { get; set; }
        public List<ExecutionReportModel> Without { get; set; }
    }

    public class ExecutionReport2ModelList
    {
        public List<ExecutionReport2Model> All { get; set; }
        public List<ExecutionReport2Model> AllDesc { get; set; }
        public List<ExecutionProblemReportModel> ProblemnMitigasi { get; set; }
    }

}