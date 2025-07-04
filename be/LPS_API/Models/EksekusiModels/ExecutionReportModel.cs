using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.EksekusiModels
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
        public DateTime CreatedDate { get; set; }
    }
}