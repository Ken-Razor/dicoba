using LPS_ProjectManagement.Models.MasterDataModels;
using LPS_ProjectManagement.Models.SAPModels;
using LPS_ProjectManagement.Models.TransaksiDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.EksekusiModels
{
    public class EksekusiModel
    {
        public string Periode { get; set; }
        public string Tanggal { get; set; }
        public string Nama { get; set; }
        public List<Approver> isApproval { get; set; }
        public List<Milestone> ml { get; set; }
        public List<Constrain> cons { get; set; }
        public List<ProjectInitApprovalRoleModel> apps { get; set; }
        public List<RoleGroupModel> rgp { get; set; }
        public List<execHistory> history { get; set; }
        public List<Roleproj> Role { get; set; }
        public List<YearlyDocument> ListYearlyDocument { get; set; }
        public string RevisiDesc { get; set; }
        public string RevisiBy { get; set; }
        public string Sysrole { get; set; }
        public string Status { get; set; }
        public string ProjectStatus { get; set; }
        //new add by yr
        public int IDProjectHeader { get; set; }
        public string Keys { get; set; }
        //--
        public List<RKATModel> ListRKAT { get; set; }
    }

    public class Roleproj
    {
        public string Roles { get; set; }
    }

    public class Approver
    {
        public string Approval { get; set; }
    }

    public class Milestone
    {
        public string ID { get; set; }
        public string Milestones { get; set; }
        public string Selesai { get; set; }
        public string Status { get; set; }
        public string Button { get; set; }
    }

    public class Constrain
    {
        public string IDProjectConstraint { get; set; }
        public string IDConstraintType { get; set; }
        public string ConstraintName { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public string Problem { get; set; }
        public string Status { get; set; }
        public string Mitigasi { get; set; }
    }

    public class InsertExsekusi
    {
        public List<MPPTasknew> MPPTasks { get; set; }
        public string ProjectHeaderID { get; set; }
        public string PersonNumber { get; set; }
        public List<Constrain> conso { get; set; }
        public string Status { get; set; }
        public string Periode { get; set; }
        public List<execApproval> app { get; set; }
    }

    public class execApproval
    {
       public int IDProjectInitApprovalRole   {get; set;}
	   public int IDProjectHeader             {get; set;}
	   public int IDRoleGroup                 {get; set;}
	   public int Sequence                    {get; set;}
	   public string Username                 {get; set;}
	   public string Email                    {get; set;}
       public string PositionCode             {get; set;}
	   public string Periode                  {get; set;}
       public string ActiveDate               {get; set;}
       public string EndDate                  {get; set;}
       public int IsEnabled                   {get; set;}
    }

    public class execHistory
    {
        public string Tipe { get; set; }
        public string Keterangan { get; set; }
        public string Nama { get; set; }
        public string Tanggal { get; set; }
    }

    public class YearlyDocument
    {
        public string IDDocument { get; set; }
        public string IDDocPhase { get; set; }
        public string IDDocType { get; set; }
        public string IDProjectHeader { get; set; }
        public string DocumentName { get; set; }
        public string TaskID { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string IsActive { get; set; }
        public string StringCreatedDate { get; set; }
    }

}