using LPS_API.Models.TransaksiDataModels;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.TransaksiControllers
{
    public class InitiationCRUDController : ApiController
    {
        public string Post([FromBody]ProjectHeaderModel ph)
        {
            try
            {
                TransaksiInitiation ti = new TransaksiInitiation();
                ProjectDetailModel pd = ph.ProjectDetail;
                ProjectRiskModel pr = ph.ProjectRisk;
                DataRow dr;

                #region Table Constraint
                DataTable Udt_ProjectConstraint = new DataTable();
                Udt_ProjectConstraint.Clear();
                Udt_ProjectConstraint.Columns.Add("IDProjectConstraint");
                Udt_ProjectConstraint.Columns.Add("IDProjectHeader");
                Udt_ProjectConstraint.Columns.Add("IDConstraintType");
                Udt_ProjectConstraint.Columns.Add("Description");
                Udt_ProjectConstraint.Columns.Add("Remarks");
                Udt_ProjectConstraint.Columns.Add("Problem");

                if (ph.ListProjectConstraint != null)
                    foreach (var data in ph.ListProjectConstraint)
                    {
                        dr = Udt_ProjectConstraint.NewRow();

                        dr["IDProjectConstraint"] = data.IDProjectConstraint;
                        dr["IDProjectHeader"] = data.IDProjectHeader;
                        dr["IDConstraintType"] = data.IDConstraintType;
                        dr["Description"] = data.Description;
                        dr["Remarks"] = data.Remarks;
                        dr["Problem"] = data.Problem;

                        Udt_ProjectConstraint.Rows.Add(dr);
                    }
                #endregion

                #region Table Cost
                //DataTable Udt_ProjectHeaderCost = new DataTable();
                //Udt_ProjectHeaderCost.Clear();
                //Udt_ProjectHeaderCost.Columns.Add("IDProjectHeaderCost");
                //Udt_ProjectHeaderCost.Columns.Add("IDProjectHeader");
                //Udt_ProjectHeaderCost.Columns.Add("IDProjectCost");
                //Udt_ProjectHeaderCost.Columns.Add("Value");

                //if (ph.ListProjectHeaderCost != null)
                //    foreach (var data in ph.ListProjectHeaderCost)
                //    {
                //        dr = Udt_ProjectHeaderCost.NewRow();

                //        dr["IDProjectHeaderCost"] = data.IDProjectHeaderCost;
                //        dr["IDProjectHeader"] = data.IDProjectHeader;
                //        dr["IDProjectCost"] = data.IDProjectCost;
                //        dr["Value"] = data.Value;

                //        Udt_ProjectHeaderCost.Rows.Add(dr);
                //    }
                #endregion

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

                string result = ti.Insert_TransaksiProjectHeader(
                    ph.IDProjectHeader,
                    ph.IDProject,
                    ph.Sequence,
                    ph.IDProjectStatus,
                    ph.StartYear,
                    ph.StartMonth,
                    ph.EndYear,
                    ph.EndMonth,
                    ph.NoKontrak,
                    //ph.ContractStartDate,
                    //ph.ContractEndDate,
                    ph.ContractIDR,
                    ph.ContractUSD,
                    ph.WeightKPI,
                    pd.IDProjectDetail,
                    pd.Background,
                    pd.Objective,
                    pd.ScopeOfWork,
                    pd.BudgetDescription,
                    pd.OrganizationChart,
                    //Udt_ProjectConstraint,
                    //Udt_ProjectHeaderCost,
                    pr.Constraints,
                    pr.Assumptions,
                    pr.Risk,
                    pr.Approach,
                    Udt_ProjectInitApprovalRole,
                    Udt_ProjectRoleGroup,
                    ph.TypeTransaction,
                    ph.CreatedBy
                    );

                return result;
            }
            catch(Exception ex)
            {
                return "F|Kesalahan pada API : " + ex.Message;
            }
        }

        public string Put([FromBody]ProjectHeaderModel ph)
        {
            try
            {
                TransaksiInitiation ti = new TransaksiInitiation();

                string result = ti.Approve_TransaksiProjectHeader(ph.IDProjectHeader, ph.ApprovedBy, ph.CreatedBy, ph.TypeTransaction);

                return result;
            }
            catch(Exception ex)
            {
                return "F|Kesalahan pada API : " + ex.Message;
            }
        }
    }
}
