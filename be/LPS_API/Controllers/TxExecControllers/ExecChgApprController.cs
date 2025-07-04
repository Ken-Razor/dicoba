using LPS_API.Helper;
using LPS_API.Models.DataWarehouseModels;
using LPS_API.Models.MasterDataModels;
using LPS_API.Models.SAPModels;
using LPS_API.Models.TransaksiClosingModels;
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
    public class ExecChgApprController : ApiController
    {
        GlobalFunction gf = new GlobalFunction(); 

        //public List<ProjectHeaderModel> Post([FromBody]ProjectHeaderModel ph)
        //{
        //    TransaksiInitiation ti = new TransaksiInitiation();
        //    List<ProjectHeaderModel> ListProjectHeader = new List<ProjectHeaderModel>();

        //    foreach (DataRow dr in ti.Get_TransaksiProjectHeader(ph.CreatedBy).Rows)
        //    {
        //        ProjectHeaderModel ProjectHeader = new ProjectHeaderModel();
        //        ProjectModel Project = new ProjectModel();
        //        ProjectStatusModel ProjectStatus = new ProjectStatusModel();

        //        if (dr["IDProject"].ToString() != "") Project.IDProject = Convert.ToInt32(dr["IDProject"]);
        //        Project.ProjectNo = dr["ProjectNo"].ToString();
        //        Project.ProjectName = dr["ProjectName"].ToString();
        //        if (dr["IsTransformasi"].ToString() != "") Project.IsTransformasi = Convert.ToBoolean(dr["IsTransformasi"]);

        //        ProjectHeader.ProjectModel = Project;

        //        ProjectStatus.StatusName = dr["StatusName"].ToString();

        //        ProjectHeader.ProjectStatus = ProjectStatus;

        //        if (dr["NoUrut"].ToString() != "") ProjectHeader.NoUrut = Convert.ToInt32(dr["NoUrut"]);
        //        if (dr["IDProjectHeader"].ToString() != "") ProjectHeader.IDProjectHeader = Convert.ToInt32(dr["IDProjectHeader"]);
        //        if (dr["IDProject"].ToString() != "") ProjectHeader.IDProject = Convert.ToInt32(dr["IDProject"]);
        //        if (dr["Sequence"].ToString() != "") ProjectHeader.Sequence = Convert.ToInt32(dr["Sequence"]);
        //        if (dr["IDProjectStatus"].ToString() != "") ProjectHeader.IDProjectStatus = Convert.ToInt32(dr["IDProjectStatus"]);
        //        ProjectHeader.StartYear = dr["StartYear"].ToString();
        //        if (dr["StartMonth"].ToString() != "") ProjectHeader.StartMonth = Convert.ToInt32(dr["StartMonth"]);
        //        ProjectHeader.EndYear = dr["EndYear"].ToString();
        //        if (dr["EndMonth"].ToString() != "") ProjectHeader.EndMonth = Convert.ToInt32(dr["EndMonth"]);
        //        ProjectHeader.NoKontrak = dr["NoKontrak"].ToString();
        //        if (dr["ContractStartDate"].ToString() != "") ProjectHeader.ContractStartDate = Convert.ToDateTime(dr["ContractStartDate"]);
        //        if (dr["ContractEndDate"].ToString() != "") ProjectHeader.ContractEndDate = Convert.ToDateTime(dr["ContractEndDate"]);
        //        if (dr["ContractIDR"].ToString() != "") ProjectHeader.ContractIDR = Convert.ToDouble(dr["ContractIDR"]);
        //        if (dr["ContractUSD"].ToString() != "") ProjectHeader.ContractUSD = Convert.ToDouble(dr["ContractUSD"]);
        //        if (dr["WeightKPI"].ToString() != "") ProjectHeader.WeightKPI = Convert.ToDouble(dr["WeightKPI"]);
        //        if (dr["CreatedDate"].ToString() != "") ProjectHeader.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
        //        ProjectHeader.CreatedBy = dr["CreatedBy"].ToString();
        //        if (dr["UpdatedDate"].ToString() != "") ProjectHeader.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);
        //        ProjectHeader.UpdatedDateString = dr["UpdatedDateString"].ToString();
        //        ProjectHeader.UpdatedBy = dr["UpdatedBy"].ToString();
        //        if (dr["IsActive"].ToString() != "") ProjectHeader.IsActive = Convert.ToBoolean(dr["IsActive"]);
        //        ProjectHeader.ApprovedBy = dr["ApprovedBy"].ToString();

        //        ListProjectHeader.Add(ProjectHeader);
        //    }
        //    return ListProjectHeader;
        //}

        public ProjectHeaderModel Put([FromBody]ProjectHeaderModel ph)
        {
            TxInit ti = new TxInit();

            ProjectHeaderModel ListProjectHeader = new ProjectHeaderModel();

            ProjectModel ProjectModel = new ProjectModel();

            List<ProgramModel> ListProgramModel = new List<ProgramModel>();

            List<DepartmentModel> ListDepartment = new List<DepartmentModel>();

            List<ProjectInitApprovalRoleModel> ListProjectInitApprovalRole = new List<ProjectInitApprovalRoleModel>();

            List<RoleGroupModel> ListRoleGroup = new List<RoleGroupModel>();

            ProjectStatusModel ProjectStatus = new ProjectStatusModel();

            DataSet ds = ti.Get_TxPH_ByID_ChgAppr(ph.IDProjectHeader, ph.CreatedBy);

            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];
            DataTable dt6 = ds.Tables[6];
            DataTable dt7 = ds.Tables[7];
            DataTable dt8 = ds.Tables[8];
            DataTable dt9 = ds.Tables[9];
            DataTable dt10 = ds.Tables[10];
            //----------------------------------//

            #region Header
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["NoUrut"].ToString() != "") ProjectModel.NoUrut = Convert.ToInt32(dt.Rows[0]["NoUrut"]);
                if (dt.Rows[0]["IDProject"].ToString() != "") ProjectModel.IDProject = Convert.ToInt32(dt.Rows[0]["IDProject"]);
                if (dt.Rows[0]["IDProgram"].ToString() != "") ProjectModel.IDProgram = Convert.ToInt32(dt.Rows[0]["IDProgram"]);
                if (dt.Rows[0]["IDStrategicObjective"].ToString() != "") ProjectModel.IDStrategicObjective = Convert.ToInt32(dt.Rows[0]["IDStrategicObjective"]);
                if (dt.Rows[0]["IDDepartment"].ToString() != "") ProjectModel.IDDepartment = Convert.ToInt32(dt.Rows[0]["IDDepartment"]);
                ProjectModel.ProjectNo = dt.Rows[0]["ProjectNo"].ToString();
                ProjectModel.Year = dt.Rows[0]["Year"].ToString();
                ProjectModel.ProjectName = dt.Rows[0]["ProjectName"].ToString();
                if (dt.Rows[0]["Weight"].ToString() != "") ProjectModel.Weight = Convert.ToDouble(dt.Rows[0]["Weight"]);
                if (dt.Rows[0]["CreatedDate"].ToString() != "") ProjectModel.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CreatedDate"]);
                ProjectModel.CreatedBy = dt.Rows[0]["CreatedBy"].ToString();
                if (dt.Rows[0]["UpdatedDate"].ToString() != "") ProjectModel.UpdatedDate = Convert.ToDateTime(dt.Rows[0]["UpdatedDate"]);
                ProjectModel.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                if (dt.Rows[0]["IsTransformasi"].ToString() != "") ProjectModel.IsTransformasi = Convert.ToBoolean(dt.Rows[0]["IsTransformasi"]);
                if (dt.Rows[0]["IsActive"].ToString() != "") ProjectModel.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);

                #region Dropdownlist Program
                foreach (DataRow data in dt1.Rows)
                {
                    ProgramModel ProgramModel = new ProgramModel();
                    ProgramModel.ProgramName = data["ProgramName"].ToString();
                    if (data["IDProgram"].ToString() != "") ProgramModel.IDProgram = Convert.ToInt32(data["IDProgram"]);
                    if (data["IsActive"].ToString() != "") ProgramModel.IsActive = Convert.ToBoolean(data["IsActive"]);
                    ListProgramModel.Add(ProgramModel);
                }
                #endregion

                #region Dropdown Department
                foreach (DataRow data in dt6.Rows)
                {
                    DepartmentModel Department = new DepartmentModel();
                    if (data["IDDepartment"].ToString() != "") Department.IDDepartment = Convert.ToInt32(data["IDDepartment"]);
                    Department.DepartmentName = data["DepartmentName"].ToString();
                    Department.CostCenter = data["CostCenter"].ToString();
                    if (data["IsActive"].ToString() != "") Department.IsActive = Convert.ToBoolean(data["IsActive"]);
                    ListDepartment.Add(Department);
                }
                #endregion

                #region List Role Group
                foreach (DataRow data in dt8.Rows)
                {
                    RoleGroupModel RoleGroup = new RoleGroupModel();
                    if (data["IDRoleGroup"].ToString() != "") RoleGroup.IDRoleGroup = Convert.ToInt32(data["IDRoleGroup"]);
                    RoleGroup.RoleGroupName = data["RoleGroupName"].ToString();
                    if (data["Level"].ToString() != "") RoleGroup.Level = Convert.ToInt32(data["Level"]);
                    RoleGroup.Description = data["Description"].ToString();
                    ListRoleGroup.Add(RoleGroup);
                }
                #endregion

            }

            ProjectModel.ListProgram = ListProgramModel;
            ProjectModel.ListDepartment = ListDepartment;
            ProjectModel.ListRoleGroup = ListRoleGroup;
            ListProjectHeader.ProjectModel = ProjectModel;

            #endregion

            //----------------------------------//

            #region Header
            if (dt10.Rows.Count > 0)
            {
                if (dt10.Rows[0]["IDProjectHeader"].ToString() != "") ListProjectHeader.IDProjectHeader = Convert.ToInt32(dt10.Rows[0]["IDProjectHeader"]);
                if (dt10.Rows[0]["IDProject"].ToString() != "") ListProjectHeader.IDProject = Convert.ToInt32(dt10.Rows[0]["IDProject"]);
                if (dt10.Rows[0]["Sequence"].ToString() != "") ListProjectHeader.Sequence = Convert.ToInt32(dt10.Rows[0]["Sequence"]);
                if (dt10.Rows[0]["IDProjectStatus"].ToString() != "") ListProjectHeader.IDProjectStatus = Convert.ToInt32(dt10.Rows[0]["IDProjectStatus"]);
                ListProjectHeader.StartYear = dt10.Rows[0]["StartYear"].ToString();
                if (dt10.Rows[0]["StartMonth"].ToString() != "") ListProjectHeader.StartMonth = Convert.ToInt32(dt10.Rows[0]["StartMonth"]);
                ListProjectHeader.EndYear = dt10.Rows[0]["EndYear"].ToString();
                if (dt10.Rows[0]["EndMonth"].ToString() != "") ListProjectHeader.EndMonth = Convert.ToInt32(dt10.Rows[0]["EndMonth"]);
                ListProjectHeader.NoKontrak = dt10.Rows[0]["NoKontrak"].ToString();
                if (dt10.Rows[0]["ContractStartDate"].ToString() != "") ListProjectHeader.ContractStartDate = Convert.ToDateTime(dt10.Rows[0]["ContractStartDate"]);
                if (dt10.Rows[0]["ContractEndDate"].ToString() != "") ListProjectHeader.ContractEndDate = Convert.ToDateTime(dt10.Rows[0]["ContractEndDate"]);
                if (dt10.Rows[0]["ContractIDR"].ToString() != "") ListProjectHeader.ContractIDR = Convert.ToDouble(dt10.Rows[0]["ContractIDR"]);
                if (dt10.Rows[0]["ContractUSD"].ToString() != "") ListProjectHeader.ContractUSD = Convert.ToDouble(dt10.Rows[0]["ContractUSD"]);
                if (dt10.Rows[0]["WeightKPI"].ToString() != "") ListProjectHeader.WeightKPI = Convert.ToDouble(dt10.Rows[0]["WeightKPI"]);

                if (dt10.Rows[0]["CreatedDate"].ToString() != "") ListProjectHeader.CreatedDate = Convert.ToDateTime(dt10.Rows[0]["CreatedDate"]);
                ListProjectHeader.CreatedBy = dt10.Rows[0]["CreatedBy"].ToString();
                if (dt10.Rows[0]["UpdatedDate"].ToString() != "") ListProjectHeader.UpdatedDate = Convert.ToDateTime(dt10.Rows[0]["UpdatedDate"]);
                ListProjectHeader.UpdatedBy = dt10.Rows[0]["UpdatedBy"].ToString();
                if (dt10.Rows[0]["IsActive"].ToString() != "") ListProjectHeader.IsActive = Convert.ToBoolean(dt10.Rows[0]["IsActive"]);
                ListProjectHeader.NeedApproval = dt10.Rows[0]["NeedApproval"].ToString();

                ProjectStatus.StatusName = dt10.Rows[0]["StatusName"].ToString();

                //#region Detail
                //if (dt10.Rows.Count > 0)
                //{
                //    if (dt10.Rows[0]["IDProjectDetail"].ToString() != "") ProjectDetail.IDProjectDetail = Convert.ToInt32(dt10.Rows[0]["IDProjectDetail"]);
                //    if (dt10.Rows[0]["IDProjectHeader"].ToString() != "") ProjectDetail.IDProjectHeader = Convert.ToInt32(dt10.Rows[0]["IDProjectHeader"]);
                //    ProjectDetail.Background = dt10.Rows[0]["Background"].ToString().Replace('{', '<').Replace('}', '>');
                //    ProjectDetail.Objective = dt10.Rows[0]["Objective"].ToString().Replace('{', '<').Replace('}', '>');
                //    ProjectDetail.ScopeOfWork = dt10.Rows[0]["ScopeOfWork"].ToString().Replace('{', '<').Replace('}', '>');
                //    ProjectDetail.BudgetDescription = dt10.Rows[0]["BudgetDescription"].ToString().Replace('{', '<').Replace('}', '>');
                //    //if (dt10.Rows[0]["OrganizationChart"].ToString() != "") ProjectDetail.OrganizationChart = Convert.ToByte(dt10.Rows[0]["OrganizationChart"]);

                //    if (dt10.Rows[0]["CreatedDate"].ToString() != "") ProjectDetail.CreatedDate = Convert.ToDateTime(dt10.Rows[0]["CreatedDate"]);
                //    ProjectDetail.CreatedBy = dt10.Rows[0]["CreatedBy"].ToString();
                //    if (dt10.Rows[0]["UpdatedDate"].ToString() != "") ProjectDetail.UpdatedDate = Convert.ToDateTime(dt10.Rows[0]["UpdatedDate"]);
                //    ProjectDetail.UpdatedBy = dt10.Rows[0]["UpdatedBy"].ToString();
                //    if (dt10.Rows[0]["IsActive"].ToString() != "") ProjectDetail.IsActive = Convert.ToBoolean(dt10.Rows[0]["IsActive"]);
                //}
                //#endregion

                
                #region Table Init Approval

                if (dt9.Rows.Count > 0)
                {
                    foreach (DataRow data in dt9.Rows)
                    {
                        ProjectInitApprovalRoleModel ProjectInitApprovalRoleModel = new ProjectInitApprovalRoleModel();

                        if (data["NoUrut"].ToString() != "") ProjectInitApprovalRoleModel.NoUrut = Convert.ToInt32(data["NoUrut"]);
                        ProjectInitApprovalRoleModel.PositionCode = data["KodePosisi"].ToString();
                        ProjectInitApprovalRoleModel.Jabatan = data["Jabatan"].ToString();
                        ProjectInitApprovalRoleModel.Nama = data["Nama"].ToString();
                        ProjectInitApprovalRoleModel.KodeUnitKerja = data["KodeUnitKerja"].ToString();
                        ProjectInitApprovalRoleModel.PersonalNumber = data["PersonalNumber"].ToString();
                        ProjectInitApprovalRoleModel.RoleGroupName = data["RoleGroupName"].ToString();
                        ProjectInitApprovalRoleModel.IDRoleGroup = data["IDRoleGroup"].ToString();
                        ProjectInitApprovalRoleModel.Username = data["Username"].ToString();
                        if (data["ActiveDate"].ToString() != "") ProjectInitApprovalRoleModel.ActiveDate = Convert.ToDateTime(data["ActiveDate"]);
                        if (data["EndDate"].ToString() != "") ProjectInitApprovalRoleModel.EndDate = Convert.ToDateTime(data["EndDate"]);
                        if (data["IsEnabled"].ToString() != "") ProjectInitApprovalRoleModel.IsEnabled = Convert.ToInt32(data["IsEnabled"]);
                        if (data["IsApprove"].ToString() != "") ProjectInitApprovalRoleModel.IsActive = Convert.ToBoolean(data["IsApprove"]);

                        ListProjectInitApprovalRole.Add(ProjectInitApprovalRoleModel);
                    }
                }
                else
                {
                    foreach (DataRow data in dt7.Rows)
                    {
                        ProjectInitApprovalRoleModel ProjectInitApprovalRoleModel = new ProjectInitApprovalRoleModel();

                        if (data["NoUrut"].ToString() != "") ProjectInitApprovalRoleModel.NoUrut = Convert.ToInt32(data["NoUrut"]);
                        ProjectInitApprovalRoleModel.PositionCode = data["KodePosisi"].ToString();
                        ProjectInitApprovalRoleModel.Jabatan = data["Jabatan"].ToString();
                        ProjectInitApprovalRoleModel.Nama = data["Nama"].ToString();
                        ProjectInitApprovalRoleModel.KodeUnitKerja = data["KodeUnitKerja"].ToString();
                        ProjectInitApprovalRoleModel.PersonalNumber = data["PersonalNumber"].ToString();
                        ProjectInitApprovalRoleModel.RoleGroupName = data["RoleGroupName"].ToString();
                        ProjectInitApprovalRoleModel.IDRoleGroup = data["IDRoleGroup"].ToString();
                        ProjectInitApprovalRoleModel.Username = data["Username"].ToString();
                        if (data["ActiveDate"].ToString() != "") ProjectInitApprovalRoleModel.ActiveDate = Convert.ToDateTime(data["ActiveDate"]);
                        if (data["EndDate"].ToString() != "") ProjectInitApprovalRoleModel.EndDate = Convert.ToDateTime(data["EndDate"]);
                        if (data["IsEnabled"].ToString() != "") ProjectInitApprovalRoleModel.IsEnabled = Convert.ToInt32(data["IsEnabled"]);
                        if (data["IsApprove"].ToString() != "") ProjectInitApprovalRoleModel.IsActive = Convert.ToBoolean(data["IsApprove"]);

                        ListProjectInitApprovalRole.Add(ProjectInitApprovalRoleModel);
                    }
                }

                if (dt9.Rows.Count > 0)
                {
                    if (ListProjectHeader.NeedApproval == ph.CreatedBy || ListProjectHeader.NeedApproval == "1|1")
                    {
                        ListProjectHeader.NeedApproval = "1|1";
                    }
                    else
                    {
                        ListProjectHeader.NeedApproval = "0|0";
                    }
                }
                else
                {
                    ListProjectHeader.NeedApproval = "0|0";
                }


                #endregion

            }

            ListProjectHeader.ProjectStatus = ProjectStatus;
            ListProjectHeader.ListProjectInitApprovalRole = ListProjectInitApprovalRole;
            #endregion

            //----------------------------------//

            return ListProjectHeader;
        }
    }
}
