using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPS_BLL.Models
{
    public class IoperaIntegrationModel
    {
        public int ProjectHeaderId { get; set; }
        public int TaskId { get; set; }
        public string KPICode { get; set; }
        public string KodeProyek { get; set; }
        public string KPIName { get; set; }
        public double BobotKpi { get; set; }
        public string ProjectNo { get; set; }
        public string ProjectName { get; set; }
        public double Poin { get; set; }
        public double PlanPercentage { get; set; }
        public double CompletePercentage { get; set; }
        public double PlanPercentage2 { get; set; }
        public double CompletePercentage2 { get; set; }
        public double CapaianProyek { get; set; }
        public double CapaianKpi { get; set; }
        //public double BobotProyek2 { get; set; }
        //public double BobotProyek { get; set; }
        //public double Capaian { get; set; }
        //public double CapaianLembaga { get; set; }
        public string Status { get; set; }
        public string StatusKpi { get; set; }
        public string Deliverable { get; set; }
        public string Realisasi { get; set; }
        public string Pic { get; set; }
        public string PicPerson { get; set; }
        public string PicMku { get; set; }
        public string Mku { get; set; }
        public bool IsTransformasi { get; set; }
    }

    public class IoperaIntegrationParentModel
    {
        public int ProjectHeaderId { get; set; }
        public int ParentId { get; set; }
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string Notes { get; set; }
        public double PlanPercentage { get; set; }
        public double CompletePercentage { get; set; }
        public double Capaian { get; set; }
        public string OutlineNumber { get; set; }
    }

    public class IoperaIntegrationChildModel
    {
        public int ProjectHeaderId { get; set; }
        public int ParentId { get; set; }
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string Notes { get; set; }
        public double PlanPercentage { get; set; }
        public double CompletePercentage { get; set; }
        public double Capaian { get; set; }
        public string OutlineNumber { get; set; }
    }

    public class IoperaIntegrationParamModel
    {
        public string Year { get; set; }
        public string TW { get; set; }
    }

    public class EmailApprovalPendingModel
    {
        public string Periode { get; set; }
        public string ProjectNo { get; set; }
        public string ProjectName { get; set; }
        public string IsTransformasi { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public DateTime PeriodeCast { get; set; }
        public string IDProjectHeader { get; set; }
        public string PeriodeRaw { get; set; }

    }

    public class RealNameListModel
    {
        public string Username { get; set; }
        public string RealName { get; set; }
    }

}
