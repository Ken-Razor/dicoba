using LPS_API.Helper;
using LPS_API.Models.MasterDataModels;
using LPS_API.Models.TransaksiChangeManagementModels;
using LPS_API.Models.TransaksiClosingModels;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.TransaksiChangeManagementControllers
{
    public class ChangeManagementController : ApiController
    {
        public List<ChangeManagementHeaderModel> Post([FromBody]ChangeManagementHeaderModel ph)
        {
            TransaksiChangeManagement tcm = new TransaksiChangeManagement();
            List<ChangeManagementHeaderModel> ListChangeManagementHeader = new List<ChangeManagementHeaderModel>();

            foreach (DataRow dr in tcm.Get_TransaksiChangeManagementProjectHeader(ph.CreatedBy).Rows)
            {
                ChangeManagementHeaderModel ChangeManagementHeader = new ChangeManagementHeaderModel();

                if (dr["IDProject"].ToString() != "") ChangeManagementHeader.IDProject = Convert.ToInt32(dr["IDProject"]);
                ChangeManagementHeader.ProjectNo = dr["ProjectNo"].ToString();
                ChangeManagementHeader.ProjectName = dr["ProjectName"].ToString();
                ChangeManagementHeader.StatusName = dr["StatusName"].ToString();
                if (dr["NoUrut"].ToString() != "") ChangeManagementHeader.NoUrut = Convert.ToInt32(dr["NoUrut"]);
                if (dr["IDProjectHeader"].ToString() != "") ChangeManagementHeader.IDProjectHeader = Convert.ToInt32(dr["IDProjectHeader"]);
                if (dr["Sequence"].ToString() != "") ChangeManagementHeader.Sequence = Convert.ToInt32(dr["Sequence"]);
                if (dr["IDProjectStatus"].ToString() != "") ChangeManagementHeader.IDProjectStatus = Convert.ToInt32(dr["IDProjectStatus"]);
                ChangeManagementHeader.StartYear = dr["StartYear"].ToString();
                if (dr["StartMonth"].ToString() != "") ChangeManagementHeader.StartMonth = Convert.ToInt32(dr["StartMonth"]);
                ChangeManagementHeader.EndYear = dr["EndYear"].ToString();
                if (dr["EndMonth"].ToString() != "") ChangeManagementHeader.EndMonth = Convert.ToInt32(dr["EndMonth"]);
                ChangeManagementHeader.NoKontrak = dr["NoKontrak"].ToString();
                if (dr["ContractStartDate"].ToString() != "") ChangeManagementHeader.ContractStartDate = Convert.ToDateTime(dr["ContractStartDate"]);
                if (dr["ContractEndDate"].ToString() != "") ChangeManagementHeader.ContractEndDate = Convert.ToDateTime(dr["ContractEndDate"]);
                if (dr["ContractIDR"].ToString() != "") ChangeManagementHeader.ContractIDR = Convert.ToDouble(dr["ContractIDR"]);
                if (dr["ContractUSD"].ToString() != "") ChangeManagementHeader.ContractUSD = Convert.ToDouble(dr["ContractUSD"]);
                if (dr["WeightKPI"].ToString() != "") ChangeManagementHeader.WeightKPI = Convert.ToDouble(dr["WeightKPI"]);
                if (dr["CreatedDate"].ToString() != "") ChangeManagementHeader.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                ChangeManagementHeader.CreatedBy = dr["CreatedBy"].ToString();
                ChangeManagementHeader.UpdatedDateString = dr["UpdatedDateString"].ToString();
                if (dr["UpdatedDate"].ToString() != "") ChangeManagementHeader.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);
                ChangeManagementHeader.UpdatedBy = dr["UpdatedBy"].ToString();
                if (dr["IsActive"].ToString() != "") ChangeManagementHeader.IsActive = Convert.ToBoolean(dr["IsActive"]);
                if (dr["IsTransformasi"].ToString() != "") ChangeManagementHeader.IsTransformasi = Convert.ToBoolean(dr["IsTransformasi"]);

                ListChangeManagementHeader.Add(ChangeManagementHeader);
            }
            return ListChangeManagementHeader;
        }

        public ChangeManagementDetailModel Put([FromBody]ChangeManagementHeaderModel ph)
        {
            try
            {

                ChangeManagementDetailModel cmdm = new ChangeManagementDetailModel();
                List<JenisPerubahanModel> ListJenisPerubahan = new List<JenisPerubahanModel>();
                List<ProjectChangesApprovalRoleModel> ListProjectChangesApprovalRole = new List<ProjectChangesApprovalRoleModel>();
                List<ProjectChangesReviseRoleModel> ListProjectChangesReviseRole = new List<ProjectChangesReviseRoleModel>();
                List<AlasanPerubahanModel> ListAlasanPerubahan = new List<AlasanPerubahanModel>();
                TransaksiChangeManagement tcm = new TransaksiChangeManagement();

                DataSet ds = tcm.Get_TransaksiChangeManagementProjectHeader_ByID(ph.IDProjectHeader, ph.CreatedBy);

                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];
                DataTable dt3 = ds.Tables[3];
                DataTable dt4 = ds.Tables[4];
                DataTable dt5 = ds.Tables[5];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["IDProjectHeader"].ToString() != "") cmdm.IDProjectHeader = Convert.ToInt32(dt.Rows[0]["IDProjectHeader"]);
                    if (dt.Rows[0]["IDJenisPerubahan"].ToString() != "") cmdm.IDJenisPerubahan = Convert.ToInt32(dt.Rows[0]["IDJenisPerubahan"]);

                    if (dt.Rows[0]["UpdatedDate"].ToString() != "") cmdm.UpdatedDate = Convert.ToDateTime(dt.Rows[0]["UpdatedDate"]);
                    if (dt.Rows[0]["DateSubmitted"].ToString() != "") cmdm.DateSubmitted = Convert.ToDateTime(dt.Rows[0]["DateSubmitted"]);
                    if (dt.Rows[0]["DateRequired"].ToString() != "") cmdm.DateRequired = Convert.ToDateTime(dt.Rows[0]["DateRequired"]);

                    if (dt.Rows[0]["AttachmentsOrReferences"].ToString() != "") cmdm.AttachmentsOrReferences = Convert.ToBoolean(dt.Rows[0]["AttachmentsOrReferences"]);

                    cmdm.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                    cmdm.ProjectName = dt.Rows[0]["ProjectName"].ToString();
                    cmdm.ProjectNo = dt.Rows[0]["ProjectNo"].ToString();
                    cmdm.StatusName = dt.Rows[0]["StatusName"].ToString();
                    cmdm.TypeOfCR = dt.Rows[0]["TypeOfCR"].ToString();
                    cmdm.SubmitterName = dt.Rows[0]["SubmitterName"].ToString();
                    cmdm.BriefDescriptionOfRequest = dt.Rows[0]["BriefDescriptionOfRequest"].ToString();
                    cmdm.ReasonForChange = dt.Rows[0]["ReasonForChange"].ToString();
                    cmdm.JenisPerubahan = dt.Rows[0]["JenisPerubahan"].ToString();
                    cmdm.OtherArtifactsImpacted = dt.Rows[0]["OtherArtifactsImpacted"].ToString();
                    cmdm.Catatan = dt.Rows[0]["Catatan"].ToString();
                    cmdm.Deskripsi = dt.Rows[0]["Deskripsi"].ToString().Replace('{', '<').Replace('}', '>');
                    cmdm.NeedApproval = dt.Rows[0]["NeedApproval"].ToString();
                    cmdm.PenyebabLain = dt.Rows[0]["AlasanPenyebabLain"].ToString();

                    foreach(DataRow dr in dt1.Rows)
                    {
                        JenisPerubahanModel JenisPerubahanModel = new JenisPerubahanModel();
                        if(dr["IDJenisPerubahan"].ToString() != "") JenisPerubahanModel.IDJenisPerubahan = Convert.ToInt32(dr["IDJenisPerubahan"]);
                        JenisPerubahanModel.Name = dr["Name"].ToString();
                        JenisPerubahanModel.Description = dr["Description"].ToString();
                        ListJenisPerubahan.Add(JenisPerubahanModel);
                    }

                    foreach(DataRow dr in dt2.Rows)
                    {
                        ProjectChangesApprovalRoleModel ProjectChangesApprovalRoleModel = new ProjectChangesApprovalRoleModel();
                        if(dr["NoUrut"].ToString() != "") ProjectChangesApprovalRoleModel.NoUrut = Convert.ToInt32(dr["NoUrut"]);
                        if (dr["IsEnabled"].ToString() != "") ProjectChangesApprovalRoleModel.IsEnabled = Convert.ToInt32(dr["IsEnabled"]);
                        if (dr["IDRoleGroup"].ToString() != "") ProjectChangesApprovalRoleModel.IDRoleGroup = Convert.ToInt32(dr["IDRoleGroup"]);
                        if (dr["IsApprove"].ToString() != "") ProjectChangesApprovalRoleModel.IsActive = Convert.ToBoolean(dr["IsApprove"]);

                        ProjectChangesApprovalRoleModel.Username = dr["Username"].ToString();
                        ProjectChangesApprovalRoleModel.PositionCode = dr["KodePosisi"].ToString();
                        ProjectChangesApprovalRoleModel.Jabatan = dr["Jabatan"].ToString();
                        ProjectChangesApprovalRoleModel.Nama = dr["Nama"].ToString();
                        ProjectChangesApprovalRoleModel.KodeUnitKerja = dr["KodeUnitKerja"].ToString();
                        ProjectChangesApprovalRoleModel.RoleGroupName = dr["RoleGroupName"].ToString();
                        ProjectChangesApprovalRoleModel.PersonalNumber = dr["PersonalNumber"].ToString();

                        if (dr["ActiveDate"].ToString() != "")ProjectChangesApprovalRoleModel.ActiveDate = Convert.ToDateTime(dr["ActiveDate"]);
                        if (dr["EndDate"].ToString() != "") ProjectChangesApprovalRoleModel.EndDate = Convert.ToDateTime(dr["EndDate"]);

                        ListProjectChangesApprovalRole.Add(ProjectChangesApprovalRoleModel);
                    }

                    foreach(DataRow dr in dt3.Rows)
                    {
                        ProjectChangesReviseRoleModel ProjectChangesReviseRoleModel = new ProjectChangesReviseRoleModel();

                        if (dr["NoUrut"].ToString() != "") ProjectChangesReviseRoleModel.NoUrut = Convert.ToInt32(dr["NoUrut"]);
                        ProjectChangesReviseRoleModel.Deskripsi = dr["Remarks"].ToString();
                        ProjectChangesReviseRoleModel.UpdatedDateString = dr["Type"].ToString();
                        ProjectChangesReviseRoleModel.CreatedBy = dr["CreatedBy"].ToString();
                        if (dr["CreatedDate"].ToString() != "") ProjectChangesReviseRoleModel.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);

                        ListProjectChangesReviseRole.Add(ProjectChangesReviseRoleModel);
                    }

                    foreach (DataRow dr in dt5.Rows)
                    {
                        AlasanPerubahanModel AlasanPerubahanModel = new AlasanPerubahanModel();
                        if (dr["IDAlasanPerubahan"].ToString() != "") AlasanPerubahanModel.IDAlasanPerubahan = Convert.ToInt32(dr["IDAlasanPerubahan"]);
                        AlasanPerubahanModel.Name = dr["Name"].ToString();
                        ListAlasanPerubahan.Add(AlasanPerubahanModel);
                    }

                    GlobalFunction GF = new GlobalFunction();
                    cmdm.ListJenisPerubahan = ListJenisPerubahan;
                    cmdm.ListProjectChangesApprovalRole = ListProjectChangesApprovalRole;
                    cmdm.ListProjectChangesReviseRole = ListProjectChangesReviseRole;
                    cmdm.ListAlasanPerubahan = ListAlasanPerubahan;
                    cmdm.Document = GF.ConvertTo<GlobalDocumentModel>(dt4);
                    var numbers2 = new List<int>();
                    var listIdJenisPerubahan = new List<int>();
                    if (cmdm.ReasonForChange!="") numbers2 = cmdm.ReasonForChange.Split(',').Select(Int32.Parse).ToList();
                    if (cmdm.JenisPerubahan != "") listIdJenisPerubahan = cmdm.JenisPerubahan.Split(',').Select(Int32.Parse).ToList();
                    cmdm.ListIDAlasan = numbers2;
                    cmdm.ListIDJenisPerubahan = listIdJenisPerubahan;
                }

                return cmdm;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
