using LPS_API.Models.TransaksiChangeManagementModels;
using LPS_API.Models.TransaksiDataModels;
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
    public class ChangeManagementCRUDController : ApiController
    {
        public string Post([FromBody]ChangeManagementDetailModel cmdm)
        {
            try
            {
                TransaksiChangeManagement tcm = new TransaksiChangeManagement();
                DataRow dr;
                DataTable Udt_ProjectChangeApprovalRole = new DataTable();

                Udt_ProjectChangeApprovalRole.Clear();
                Udt_ProjectChangeApprovalRole.Columns.Add("IDProjectChangesApprovalRole");
                Udt_ProjectChangeApprovalRole.Columns.Add("IDProjectHeader");
                Udt_ProjectChangeApprovalRole.Columns.Add("IDRoleGroup");
                Udt_ProjectChangeApprovalRole.Columns.Add("Sequence");
                Udt_ProjectChangeApprovalRole.Columns.Add("Username");
                Udt_ProjectChangeApprovalRole.Columns.Add("Email");
                Udt_ProjectChangeApprovalRole.Columns.Add("PositionCode");
                Udt_ProjectChangeApprovalRole.Columns.Add("ActiveDate");
                Udt_ProjectChangeApprovalRole.Columns.Add("EndDate");
                Udt_ProjectChangeApprovalRole.Columns.Add("IsEnabled");

                if(cmdm.ListProjectChangesApprovalRole != null)
                    foreach (var data in cmdm.ListProjectChangesApprovalRole)
                    {
                        dr = Udt_ProjectChangeApprovalRole.NewRow();

                        dr["IDRoleGroup"] = data.IDRoleGroup;
                        dr["Sequence"] = data.Sequence;
                        dr["Username"] = data.Username;
                        dr["ActiveDate"] = data.ActiveDate;
                        dr["EndDate"] = data.EndDate;
                        dr["IsEnabled"] = data.IsEnabled;

                        Udt_ProjectChangeApprovalRole.Rows.Add(dr);
                    }

                string result = tcm.Insert_TransaksiChangeManagementProjectHeader(
                    cmdm.IDProjectHeader,
                    cmdm.IDJenisPerubahan,
                    cmdm.JenisPerubahan,
                    cmdm.IsCancel,
                    cmdm.TypeOfCR,
                    cmdm.SubmitterName,
                    cmdm.BriefDescriptionOfRequest,
                    cmdm.DateSubmitted,
                    cmdm.DateRequired,
                    cmdm.ReasonForChange,
                    cmdm.PenyebabLain,
                    cmdm.OtherArtifactsImpacted,
                    cmdm.AttachmentsOrReferences,
                    cmdm.Catatan,
                    cmdm.Deskripsi,
                    "Change Request",
                    cmdm.CreatedBy,
                    Udt_ProjectChangeApprovalRole
                );

                return result;
            }
            catch (Exception ex)
            {
                string result = "F|Internal Server Error : " + ex;
                return result;
            }
        }

        public string Put([FromBody]ProjectHeaderModel ph)
        {
            try
            {
                TransaksiChangeManagement tcm = new TransaksiChangeManagement();

                string result = tcm.Approve_TransaksiChangeManagementProjectHeader(ph.IDProjectHeader, ph.ApprovedBy, ph.CreatedBy, ph.TypeTransaction);

                return result;
            }
            catch (Exception ex)
            {
                return "F|Kesalahan pada API : " + ex.Message;
            }
        }
    }
}
