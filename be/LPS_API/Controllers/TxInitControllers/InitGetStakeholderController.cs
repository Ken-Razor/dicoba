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

namespace LPS_API.Controllers.TxControllers
{
    public class InitGetStakeholderController : ApiController
    {
        GlobalFunction gf = new GlobalFunction();

        public List<ProjectHeaderModel> Post([FromBody]ProjectHeaderModel ph)
        {
            TxInit ti = new TxInit();
            List<ProjectHeaderModel> ListProjectHeader = new List<ProjectHeaderModel>();

            foreach (DataRow dr in ti.Get_TxProjectHeader(ph.CreatedBy).Rows)
            {
                ProjectHeaderModel ProjectHeader = new ProjectHeaderModel();
                ProjectModel Project = new ProjectModel();
                ProjectStatusModel ProjectStatus = new ProjectStatusModel();

                if (dr["IDProject"].ToString() != "") Project.IDProject = Convert.ToInt32(dr["IDProject"]);
                Project.ProjectNo = dr["ProjectNo"].ToString();
                Project.ProjectName = dr["ProjectName"].ToString();
                if (dr["IsTransformasi"].ToString() != "") Project.IsTransformasi = Convert.ToBoolean(dr["IsTransformasi"]);

                ProjectHeader.ProjectModel = Project;

                ProjectStatus.StatusName = dr["StatusName"].ToString();

                ProjectHeader.ProjectStatus = ProjectStatus;

                if (dr["NoUrut"].ToString() != "") ProjectHeader.NoUrut = Convert.ToInt32(dr["NoUrut"]);
                if (dr["IDProjectHeader"].ToString() != "") ProjectHeader.IDProjectHeader = Convert.ToInt32(dr["IDProjectHeader"]);
                if (dr["IDProject"].ToString() != "") ProjectHeader.IDProject = Convert.ToInt32(dr["IDProject"]);
                if (dr["Sequence"].ToString() != "") ProjectHeader.Sequence = Convert.ToInt32(dr["Sequence"]);
                if (dr["IDProjectStatus"].ToString() != "") ProjectHeader.IDProjectStatus = Convert.ToInt32(dr["IDProjectStatus"]);
                ProjectHeader.StartYear = dr["StartYear"].ToString();
                if (dr["StartMonth"].ToString() != "") ProjectHeader.StartMonth = Convert.ToInt32(dr["StartMonth"]);
                ProjectHeader.EndYear = dr["EndYear"].ToString();
                if (dr["EndMonth"].ToString() != "") ProjectHeader.EndMonth = Convert.ToInt32(dr["EndMonth"]);
                ProjectHeader.NoKontrak = dr["NoKontrak"].ToString();
                if (dr["ContractStartDate"].ToString() != "") ProjectHeader.ContractStartDate = Convert.ToDateTime(dr["ContractStartDate"]);
                if (dr["ContractEndDate"].ToString() != "") ProjectHeader.ContractEndDate = Convert.ToDateTime(dr["ContractEndDate"]);
                if (dr["ContractIDR"].ToString() != "") ProjectHeader.ContractIDR = Convert.ToDouble(dr["ContractIDR"]);
                if (dr["ContractUSD"].ToString() != "") ProjectHeader.ContractUSD = Convert.ToDouble(dr["ContractUSD"]);
                if (dr["WeightKPI"].ToString() != "") ProjectHeader.WeightKPI = Convert.ToDouble(dr["WeightKPI"]);
                if (dr["CreatedDate"].ToString() != "") ProjectHeader.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                ProjectHeader.CreatedBy = dr["CreatedBy"].ToString();
                if (dr["UpdatedDate"].ToString() != "") ProjectHeader.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);
                ProjectHeader.UpdatedDateString = dr["UpdatedDateString"].ToString();
                ProjectHeader.UpdatedBy = dr["UpdatedBy"].ToString();
                if (dr["IsActive"].ToString() != "") ProjectHeader.IsActive = Convert.ToBoolean(dr["IsActive"]);
                ProjectHeader.ApprovedBy = dr["ApprovedBy"].ToString();

                ListProjectHeader.Add(ProjectHeader);
            }
            return ListProjectHeader;
        }

        public ProjectHeaderModel Put([FromBody]ProjectHeaderModel ph)
        {
            TxInit ti = new TxInit();

            ProjectHeaderModel ListProjectHeader = new ProjectHeaderModel();

            ProjectModel ProjectModel = new ProjectModel();

            List<ProgramModel> ListProgramModel = new List<ProgramModel>();

            List<RKATModel> ListRKAT = new List<RKATModel>();

            List<StrategicObjectiveModel> ListStrategicObjective = new List<StrategicObjectiveModel>();

            List<KPIOrganizationModel> ListKPIOrganization = new List<KPIOrganizationModel>();

            List<ProjectPriorityModel> ListProjectPriority = new List<ProjectPriorityModel>();

            List<DepartmentModel> ListDepartment = new List<DepartmentModel>();

            //List<ProjectConstraintModel> ListProjectConstraint = new List<ProjectConstraintModel>();

            //List<ConstraintTypeModel> ListConstraintType = new List<ConstraintTypeModel>();

            //List<ProjectHeaderCostModel> ListProjectHeaderCost = new List<ProjectHeaderCostModel>();

            //List<MPPProjectPlanDetailModel> ListMPPProjectPlanDetail = new List<MPPProjectPlanDetailModel>();

            //List<ProjectCostModel> ListProjectCost = new List<ProjectCostModel>();

            List<ProjectRoleGroupModel> ListProjectRoleGroup = new List<ProjectRoleGroupModel>();

            List<ProjectInitApprovalRoleModel> ListProjectInitApprovalRole = new List<ProjectInitApprovalRoleModel>();

            List<RoleGroupModel> ListRoleGroup = new List<RoleGroupModel>();

            //List<ProjectInitReviseRoleModel> ListProjectInitRevise = new List<ProjectInitReviseRoleModel>();

            List<string> RoleInProject = new List<string>();

            ProjectStatusModel ProjectStatus = new ProjectStatusModel();

            //ProjectDetailModel ProjectDetail = new ProjectDetailModel();

            //ProjectRiskModel ProjectRisk = new ProjectRiskModel();

            //List<GlobalDocumentModel> GM = new List<GlobalDocumentModel>();

            //List<FileModel> FileModel = new List<FileModel>();

            DataSet ds = ti.Get_TxPH_ByID_Stakeholder(ph.IDProjectHeader, ph.CreatedBy);

            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];
            //DataTable dt2 = ds.Tables[2];
            //DataTable dt3 = ds.Tables[3];
            //DataTable dt4 = ds.Tables[4];
            //DataTable dt5 = ds.Tables[5];
            DataTable dt6 = ds.Tables[2];
            DataTable dt7 = ds.Tables[3];
            DataTable dt8 = ds.Tables[4];

            DataTable dt9 = ds.Tables[5];
            //DataTable dt10 = ds.Tables[10];
            //DataTable dt11 = ds.Tables[11];
            //DataTable dt12 = ds.Tables[12];
            //DataTable dt13 = ds.Tables[13];
            //DataTable dt14 = ds.Tables[14];
            //DataTable dt15 = ds.Tables[15];
            //DataTable dt16 = ds.Tables[16];
            //DataTable dt17 = ds.Tables[17];
            //DataTable dt18 = ds.Tables[18];
            DataTable dt19 = ds.Tables[6];
            //DataTable dt20 = ds.Tables[20];
            //DataTable dt21 = ds.Tables[21];
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

                ////#region Table SAP RKAT
                ////foreach (DataRow data in dt2.Rows)
                ////{
                ////    RKATModel RKAT = new RKATModel();
                ////    if (data["NoUrut"].ToString() != "") RKAT.NoUrut = Convert.ToInt32(data["NoUrut"]);
                ////    if (data["IDSAPRKAT"].ToString() != "") RKAT.IDSAPRKAT = Convert.ToInt32(data["IDSAPRKAT"]);
                ////    RKAT.IDSAP = data["IDSAP"].ToString();
                ////    RKAT.COSTCTR = data["COSTCTR"].ToString();
                ////    RKAT.KPI = data["KPI"].ToString();
                ////    RKAT.DESCRIPTION = data["DESCRIPTION"].ToString();
                ////    RKAT.YEAR = data["YEAR"].ToString();
                ////    ListRKAT.Add(RKAT);
                ////}
                ////#endregion

                //#region Dropdown SO
                //foreach (DataRow data in dt3.Rows)
                //{
                //    StrategicObjectiveModel StrategicObjectiveModel = new StrategicObjectiveModel();
                //    if (data["IDStrategicObjective"].ToString() != "") StrategicObjectiveModel.IDStrategicObjective = Convert.ToInt32(data["IDStrategicObjective"]);
                //    StrategicObjectiveModel.StrategicObjectiveCode = data["StrategicObjectiveCode"].ToString();
                //    StrategicObjectiveModel.StrategicObjectiveName = data["StrategicObjectiveName"].ToString();
                //    if (data["IsActive"].ToString() != "") StrategicObjectiveModel.IsActive = Convert.ToBoolean(data["IsActive"]);
                //    ListStrategicObjective.Add(StrategicObjectiveModel);
                //}
                //#endregion

                //#region Table KPI Organization
                //foreach (DataRow data in dt4.Rows)
                //{
                //    KPIOrganizationModel KPIOrganization = new KPIOrganizationModel();
                //    if (data["NoUrut"].ToString() != "") KPIOrganization.NoUrut = Convert.ToInt32(data["NoUrut"]);
                //    if (data["IDKPIOrganization"].ToString() != "") KPIOrganization.IDKPIOrganization = Convert.ToInt32(data["IDKPIOrganization"]);
                //    KPIOrganization.KPICode = data["KPICode"].ToString();
                //    KPIOrganization.KPIName = data["KPIName"].ToString();
                //    KPIOrganization.Year = data["Year"].ToString();
                //    ListKPIOrganization.Add(KPIOrganization);
                //}
                //#endregion

                //#region Dropdown Project Priority
                //foreach (DataRow data in dt5.Rows)
                //{
                //    ProjectPriorityModel ProjectPriorityModel = new ProjectPriorityModel();
                //    if (data["IDProjectPriority"].ToString() != "") ProjectPriorityModel.IDProjectPriority = Convert.ToInt32(data["IDProjectPriority"]);
                //    ProjectPriorityModel.Name = data["Name"].ToString();
                //    if (data["IsActive"].ToString() != "") ProjectPriorityModel.IsActive = Convert.ToBoolean(data["IsActive"]);
                //    ListProjectPriority.Add(ProjectPriorityModel);
                //}
                //#endregion

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
            //ProjectModel.ListRKAT = ListRKAT;
            //ProjectModel.ListStrategicObjective = ListStrategicObjective;
            //ProjectModel.ListKPIOrganization = ListKPIOrganization;
            //ProjectModel.ListProjectPriority = ListProjectPriority;
            //ProjectModel.ListDepartment = ListDepartment;
            ProjectModel.ListRoleGroup = ListRoleGroup;
            ListProjectHeader.ProjectModel = ProjectModel;

            #endregion

            //----------------------------------//

            #region Header
            if (dt9.Rows.Count > 0)
            {
                if (dt9.Rows[0]["IDProjectHeader"].ToString() != "") ListProjectHeader.IDProjectHeader = Convert.ToInt32(dt9.Rows[0]["IDProjectHeader"]);
                if (dt9.Rows[0]["IDProject"].ToString() != "") ListProjectHeader.IDProject = Convert.ToInt32(dt9.Rows[0]["IDProject"]);
                if (dt9.Rows[0]["Sequence"].ToString() != "") ListProjectHeader.Sequence = Convert.ToInt32(dt9.Rows[0]["Sequence"]);
                if (dt9.Rows[0]["IDProjectStatus"].ToString() != "") ListProjectHeader.IDProjectStatus = Convert.ToInt32(dt9.Rows[0]["IDProjectStatus"]);
                ListProjectHeader.StartYear = dt9.Rows[0]["StartYear"].ToString();
                if (dt9.Rows[0]["StartMonth"].ToString() != "") ListProjectHeader.StartMonth = Convert.ToInt32(dt9.Rows[0]["StartMonth"]);
                ListProjectHeader.EndYear = dt9.Rows[0]["EndYear"].ToString();
                if (dt9.Rows[0]["EndMonth"].ToString() != "") ListProjectHeader.EndMonth = Convert.ToInt32(dt9.Rows[0]["EndMonth"]);
                ListProjectHeader.NoKontrak = dt9.Rows[0]["NoKontrak"].ToString();
                if (dt9.Rows[0]["ContractStartDate"].ToString() != "") ListProjectHeader.ContractStartDate = Convert.ToDateTime(dt9.Rows[0]["ContractStartDate"]);
                if (dt9.Rows[0]["ContractEndDate"].ToString() != "") ListProjectHeader.ContractEndDate = Convert.ToDateTime(dt9.Rows[0]["ContractEndDate"]);
                if (dt9.Rows[0]["ContractIDR"].ToString() != "") ListProjectHeader.ContractIDR = Convert.ToDouble(dt9.Rows[0]["ContractIDR"]);
                if (dt9.Rows[0]["ContractUSD"].ToString() != "") ListProjectHeader.ContractUSD = Convert.ToDouble(dt9.Rows[0]["ContractUSD"]);
                if (dt9.Rows[0]["WeightKPI"].ToString() != "") ListProjectHeader.WeightKPI = Convert.ToDouble(dt9.Rows[0]["WeightKPI"]);

                if (dt9.Rows[0]["CreatedDate"].ToString() != "") ListProjectHeader.CreatedDate = Convert.ToDateTime(dt9.Rows[0]["CreatedDate"]);
                ListProjectHeader.CreatedBy = dt9.Rows[0]["CreatedBy"].ToString();
                if (dt9.Rows[0]["UpdatedDate"].ToString() != "") ListProjectHeader.UpdatedDate = Convert.ToDateTime(dt9.Rows[0]["UpdatedDate"]);
                ListProjectHeader.UpdatedBy = dt9.Rows[0]["UpdatedBy"].ToString();
                if (dt9.Rows[0]["IsActive"].ToString() != "") ListProjectHeader.IsActive = Convert.ToBoolean(dt9.Rows[0]["IsActive"]);
                ListProjectHeader.NeedApproval = dt9.Rows[0]["NeedApproval"].ToString();

                ProjectStatus.StatusName = dt9.Rows[0]["StatusName"].ToString();

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

                //#region Table Constraint
                //foreach (DataRow data in dt11.Rows)
                //{
                //    ProjectConstraintModel ProjectConstraintModel = new ProjectConstraintModel();
                //    if (data["IDProjectConstraint"].ToString() != "") ProjectConstraintModel.IDProjectConstraint = Convert.ToInt32(data["IDProjectConstraint"]);
                //    ProjectConstraintModel.Description = data["Description"].ToString();
                //    ProjectConstraintModel.Problem = data["Problem"].ToString();
                //    ProjectConstraintModel.Remarks = data["Remarks"].ToString();

                //    ConstraintTypeModel ConstraintTypeModel = new ConstraintTypeModel();
                //    if (data["IDConstraintType"].ToString() != "") ConstraintTypeModel.IDConstraintType = Convert.ToInt32(data["IDConstraintType"]);
                //    ConstraintTypeModel.ConstraintName = data["ConstraintName"].ToString();

                //    ProjectConstraintModel.ConstraintType = ConstraintTypeModel;

                //    ListProjectConstraint.Add(ProjectConstraintModel);
                //}
                //#endregion

                //#region Dropdown Constraint
                //foreach (DataRow data in dt12.Rows)
                //{
                //    ConstraintTypeModel ConstraintType = new ConstraintTypeModel();
                //    if (data["IDConstraintType"].ToString() != "") ConstraintType.IDConstraintType = Convert.ToInt32(data["IDConstraintType"]);
                //    ConstraintType.ConstraintName = data["ConstraintName"].ToString();
                //    ListConstraintType.Add(ConstraintType);
                //}
                //#endregion

                //#region Table Project Cost
                //foreach (DataRow data in dt13.Rows)
                //{
                //    ProjectCostModel ProjectCostModel = new ProjectCostModel();
                //    if (data["IDProjectCost"].ToString() != "") ProjectCostModel.IDProjectCost = Convert.ToInt32(data["IDProjectCost"]);
                //    ProjectCostModel.ProjectCostName = data["ProjectCostName"].ToString();
                //    ProjectCostModel.ProjectCostCode = data["ProjectCostCode"].ToString();

                //    ProjectHeaderCostModel ProjectHeaderCostModel = new ProjectHeaderCostModel();
                //    if (data["IDProjectHeaderCost"].ToString() != "") ProjectHeaderCostModel.IDProjectHeaderCost = Convert.ToInt32(data["IDProjectHeaderCost"]);
                //    if (data["IDProjectCost"].ToString() != "") ProjectHeaderCostModel.IDProjectCost = Convert.ToInt32(data["IDProjectCost"]);
                //    if (data["Value"].ToString() != "") ProjectHeaderCostModel.Value = Convert.ToDouble(data["Value"]);
                //    ProjectHeaderCostModel.ProjectCost = ProjectCostModel;

                //    ListProjectHeaderCost.Add(ProjectHeaderCostModel);
                //}
                //#endregion

                //#region Table Milestone
                //foreach (DataRow data in dt14.Rows)
                //{
                //    MPPProjectPlanDetailModel MPPProjectPlanDetailModel = new MPPProjectPlanDetailModel();
                //    if (data["TaskID"].ToString() != "") MPPProjectPlanDetailModel.TaskID = Convert.ToInt32(data["TaskID"]);
                //    MPPProjectPlanDetailModel.TaskName = data["TaskName"].ToString();
                //    MPPProjectPlanDetailModel.StartDateString = data["StartDateString"].ToString();

                //    ListMPPProjectPlanDetail.Add(MPPProjectPlanDetailModel);
                //}
                //#endregion

                #region Table Init Approval
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
                #endregion

                //#region Dropdown Project Cost
                //foreach (DataRow data in dt15.Rows)
                //{
                //    ProjectCostModel ProjectCost = new ProjectCostModel();
                //    if (data["IDProjectCost"].ToString() != "") ProjectCost.IDProjectCost = Convert.ToInt32(data["IDProjectCost"]);
                //    ProjectCost.ProjectCostName = data["ProjectCostName"].ToString();
                //    ProjectCost.ProjectCostCode = data["ProjectCostCode"].ToString();
                //    ListProjectCost.Add(ProjectCost);
                //}
                //#endregion

                //#region Risk
                //if (dt16.Rows.Count > 0)
                //{
                //    if (dt16.Rows[0]["IDProjectRisk"].ToString() != "") ProjectRisk.IDProjectRisk = Convert.ToInt32(dt16.Rows[0]["IDProjectRisk"]);
                //    if (dt16.Rows[0]["IDProjectHeader"].ToString() != "") ProjectRisk.IDProjectHeader = Convert.ToInt32(dt16.Rows[0]["IDProjectHeader"]);
                //    ProjectRisk.Constraints = dt16.Rows[0]["Constraints"].ToString().Replace('{', '<').Replace('}', '>');
                //    ProjectRisk.Assumptions = dt16.Rows[0]["Assumptions"].ToString().Replace('{', '<').Replace('}', '>');
                //    ProjectRisk.Risk = dt16.Rows[0]["Risk"].ToString().Replace('{', '<').Replace('}', '>');
                //    ProjectRisk.Approach = dt16.Rows[0]["Approach"].ToString().Replace('{', '<').Replace('}', '>');

                //    if (dt16.Rows[0]["CreatedDate"].ToString() != "") ProjectRisk.CreatedDate = Convert.ToDateTime(dt16.Rows[0]["CreatedDate"]);
                //    ProjectRisk.CreatedBy = dt16.Rows[0]["CreatedBy"].ToString();
                //    if (dt16.Rows[0]["UpdatedDate"].ToString() != "") ProjectDetail.UpdatedDate = Convert.ToDateTime(dt16.Rows[0]["UpdatedDate"]);
                //    ProjectRisk.UpdatedBy = dt16.Rows[0]["UpdatedBy"].ToString();
                //    if (dt16.Rows[0]["IsActive"].ToString() != "") ProjectRisk.IsActive = Convert.ToBoolean(dt16.Rows[0]["IsActive"]);
                //}
                //#endregion

                //#region Revise
                //foreach (DataRow data in dt18.Rows)
                //{
                //    ProjectInitReviseRoleModel ProjectInitRevise = new ProjectInitReviseRoleModel();

                //    if (data["NoUrut"].ToString() != "") ProjectInitRevise.NoUrut = Convert.ToInt32(data["NoUrut"]);
                //    ProjectInitRevise.Deskripsi = data["Remarks"].ToString();
                //    ProjectInitRevise.UpdatedDateString = data["Type"].ToString();
                //    ProjectInitRevise.CreatedBy = data["CreatedBy"].ToString();
                //    if (data["CreatedDate"].ToString() != "") ProjectInitRevise.CreatedDate = Convert.ToDateTime(data["CreatedDate"]);

                //    ListProjectInitRevise.Add(ProjectInitRevise);
                //}
                //#endregion

                #region Role In Project
                foreach (DataRow data in dt19.Rows)
                {
                    RoleInProject.Add(data["RoleInProject"].ToString());
                }
                #endregion

                //#region Total Anggaran
                //ListProjectHeader.TotalAnggaran = gf.ToRupiah(dt20.Rows[0]["TotalAnggaran"].ToString());
                //#endregion
            }

            ListProjectHeader.ProjectStatus = ProjectStatus;
            //ListProjectHeader.ProjectDetail = ProjectDetail;
            //ListProjectHeader.ListProjectConstraint = ListProjectConstraint;
            //ListProjectHeader.ListConstraintType = ListConstraintType;
            //ListProjectHeader.ListProjectHeaderCost = ListProjectHeaderCost;
            //ListProjectHeader.ListMPPProjectPlanDetail = ListMPPProjectPlanDetail;
            ListProjectHeader.ListProjectInitApprovalRole = ListProjectInitApprovalRole;
            //ListProjectHeader.ListProjectCost = ListProjectCost;
            //ListProjectHeader.ProjectRisk = ProjectRisk;
            //ListProjectHeader.ProjectInitRevise = ListProjectInitRevise;
            ListProjectHeader.RoleInProject = RoleInProject;
            #endregion

            //----------------------------------//


            //if (dt17.Rows.Count > 0)
            //{
            //    Helper.GlobalFunction GF = new Helper.GlobalFunction();
            //    ListProjectHeader.ListFile = GF.ConvertTo<FileModel>(dt17);
            //}
            //if (dt21.Rows.Count > 0)
            //{
            //    Helper.GlobalFunction GF = new Helper.GlobalFunction();
            //    ListProjectHeader.GlobalDocument = GF.ConvertTo<GlobalDocumentModel>(dt21);
            //}


            return ListProjectHeader;
        }
    }
}
