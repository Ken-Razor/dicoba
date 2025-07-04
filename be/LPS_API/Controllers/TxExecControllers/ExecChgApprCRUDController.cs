using LPS_API.Models.TransaksiDataModels;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.TxExecControllers
{
    public class ExecChgApprCRUDController : ApiController 
    {
        public string Post([FromBody]ProjectHeaderModel ph)
        {
            try
            {
                TxExec ti = new TxExec();
                //ProjectDetailModel pd = ph.ProjectDetail;
                //ProjectRiskModel pr = ph.ProjectRisk;
                DataRow dr;

                #region Table Init Approval Role

                DataTable Udt_ProjectInitApprovalRole = new DataTable();
                Udt_ProjectInitApprovalRole.Clear();
                Udt_ProjectInitApprovalRole.Columns.Add("IDProjectInitApprovalRole");
                Udt_ProjectInitApprovalRole.Columns.Add("IDProjectHeader");
                Udt_ProjectInitApprovalRole.Columns.Add("IDRoleGroup");
                Udt_ProjectInitApprovalRole.Columns.Add("Sequence");
                Udt_ProjectInitApprovalRole.Columns.Add("Username");
                Udt_ProjectInitApprovalRole.Columns.Add("Email");
                Udt_ProjectInitApprovalRole.Columns.Add("PositionCode");
                Udt_ProjectInitApprovalRole.Columns.Add("ActiveDate");
                Udt_ProjectInitApprovalRole.Columns.Add("EndDate");
                Udt_ProjectInitApprovalRole.Columns.Add("IsEnabled");

                if (ph.ListProjectInitApprovalRole != null)
                    foreach (var data in ph.ListProjectInitApprovalRole)
                    {
                        dr = Udt_ProjectInitApprovalRole.NewRow();

                        dr["IDRoleGroup"] = data.IDRoleGroup;
                        dr["Sequence"] = data.Sequence;
                        dr["Username"] = data.Username;
                        dr["ActiveDate"] = data.ActiveDate;
                        dr["EndDate"] = data.EndDate;
                        dr["IsEnabled"] = data.IsEnabled;

                        Udt_ProjectInitApprovalRole.Rows.Add(dr);
                    }
                #endregion

                #region Table Role Group
                DataTable Udt_ProjectRoleGroup = new DataTable();
                Udt_ProjectRoleGroup.Clear();
                Udt_ProjectRoleGroup.Columns.Add("IDRoleGroup");
                Udt_ProjectRoleGroup.Columns.Add("Username");

                if (ph.ListProjectRoleGroup != null)
                    foreach (var data in ph.ListProjectRoleGroup)
                    {
                        dr = Udt_ProjectRoleGroup.NewRow();

                        dr["IDRoleGroup"] = data.IDProjectRoleGroup;
                        dr["Username"] = data.Username;

                        Udt_ProjectRoleGroup.Rows.Add(dr);
                    }
                #endregion

                string result = ti.Insert_ChgApvProjectHeader(
                    ph.IDProjectHeader,
                    ph.IDProject,
                    ph.Sequence,
                    ph.IDProjectStatus,
                    ph.StartYear,
                    ph.StartMonth,
                    ph.EndYear,
                    ph.EndMonth,
                    ph.NoKontrak,
                    Udt_ProjectInitApprovalRole,
                    Udt_ProjectRoleGroup,
                    ph.TypeTransaction,
                    ph.CreatedBy
                    );

                return result;
            }
            catch (Exception ex)
            {
                return "F|Kesalahan pada API : " + ex.Message;
            }
        }

        //public string Put([FromBody]ProjectHeaderModel ph)
        //{
        //    try
        //    {
        //        TransaksiInitiation ti = new TransaksiInitiation();

        //        string result = ti.Approve_TransaksiProjectHeader(ph.IDProjectHeader, ph.ApprovedBy, ph.CreatedBy, ph.TypeTransaction);

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return "F|Kesalahan pada API : " + ex.Message;
        //    }
        //}
    }
}
