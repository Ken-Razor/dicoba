using LPS_ProjectManagement.Models.MasterDataModels;
using LPS_ProjectManagement.Models.TransaksiClosingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.TransaksiChangeManagementModels
{
    public class ChangeManagementDetailModel
    {
        public string ProjectName { get; set; }

        public string ProjectNo { get; set; }

        public int IDProjectHeader { get; set; }

        public int IDJenisPerubahan { get; set; }

        public string TypeOfCR { get; set; }

        public string SubmitterName { get; set; }

        public string BriefDescriptionOfRequest { get; set; }

        public DateTime DateSubmitted { get; set; }

        public DateTime DateRequired { get; set; }

        public string ReasonForChange { get; set; }

        public string JenisPerubahan { get; set; }

        public string OtherArtifactsImpacted { get; set; }

        public Boolean AttachmentsOrReferences { get; set; }

        public string Catatan { get; set; }

        public string Deskripsi { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public Boolean IsActive { get; set; }

        public string StatusName { get; set; }

        public string NeedApproval { get; set; }

        public string PenyebabLain { get; set; }

        public bool IsCancel { get; set; }

        public List<int> ListIDAlasan { get; set; }

        public List<int> ListIDJenisPerubahan { get; set; }

        public List<JenisPerubahanModel> ListJenisPerubahan { get; set; }

        public List<AlasanPerubahanModel> ListAlasanPerubahan { get; set; }

        public List<ProjectChangesReviseRoleModel> ListProjectChangesReviseRole { get; set; }

        public List<ProjectChangesApprovalRoleModel> ListProjectChangesApprovalRole { get; set; }

        public List<GlobalDocumentModel> Document { get; set; }
    }
}