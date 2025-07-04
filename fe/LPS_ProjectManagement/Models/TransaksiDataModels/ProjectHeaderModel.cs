using LPS_ProjectManagement.Models.MasterDataModels;
using LPS_ProjectManagement.Models.TransaksiClosingModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.TransaksiDataModels
{
    public class ProjectHeaderModel
    {
        public int NoUrut { get; set; }

        public int IDProjectHeader { get; set; }

        public int IDProject { get; set; }

        public int Sequence { get; set; }

        public int IDProjectStatus { get; set; }

        public string StartYear { get; set; }

        public int StartMonth { get; set; }

        public string EndYear { get; set; }

        public int EndMonth { get; set; }

        public string NoKontrak { get; set; }
        
        public DateTime ContractStartDate { get; set; }
        
        public DateTime ContractEndDate { get; set; }

        public double ContractIDR { get; set; }

        public double ContractUSD { get; set; }

        public double WeightKPI { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedDateString { get; set; }

        public string UpdatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public string TypeTransaction { get; set; }

        public string ApprovedBy { get; set; }

        public string NeedApproval { get; set; }

        public string TotalAnggaran { get; set; }

        public string KodeMataAnggaran { get; set; }

        public int Tag { get; set; }

        public List<string> RoleInProject { get; set; }

        public ProjectModel ProjectModel { get; set; }

        public ProjectDetailModel ProjectDetail { get; set; }

        public ProjectStatusModel ProjectStatus { get; set; }

        public ProjectRiskModel ProjectRisk { get; set; }

        public List<ProjectInitReviseRoleModel> ProjectInitRevise { get; set; }

        public List<ProjectConstraintModel> ListProjectConstraint { get; set; }

        public List<ConstraintTypeModel> ListConstraintType { get; set; }

        public List<ProjectHeaderCostModel> ListProjectHeaderCost { get; set; }

        public List<MPPProjectPlanDetailModel> ListMPPProjectPlanDetail { get; set; }

        public List<ProjectCostModel> ListProjectCost { get; set; }

        public List<ProjectRoleGroupModel> ListProjectRoleGroup { get; set; }

        public List<ProjectInitApprovalRoleModel> ListProjectInitApprovalRole { get; set; }

        public List<FileModel> ListFile { get; set; }

        public List<GlobalDocumentModel> GlobalDocument { get; set; }
        public List<MasterSLAModel> ListSLA { get; set; }
        public List<StatusSLAModel> ListStatus { get; set; }
        public List<GroupModel> ListGroup { get; set; }
    }
}