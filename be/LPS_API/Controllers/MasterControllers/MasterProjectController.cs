using LPS_API.Helper;
using LPS_API.Models.DataWarehouseModels;
using LPS_API.Models.MasterDataModels;
using LPS_API.Models.SAPModels;
using LPS_API.Models.TransaksiDataModels;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers
{
    public class MasterProjectController : ApiController
    {
        GlobalFunction gf = new GlobalFunction();
        public List<ProjectModel> Get()
        {
            MasterData md = new MasterData();
            List<ProjectModel> ListProjectModel = new List<ProjectModel>();

            foreach (DataRow dr in md.Get_MasterProject().Rows)
            {
                ProjectModel ProjectModel = new ProjectModel();

                if(dr["NoUrut"].ToString()!="") ProjectModel.NoUrut = Convert.ToInt32(dr["NoUrut"]);
                if(dr["IDProject"].ToString()!="") ProjectModel.IDProject = Convert.ToInt32(dr["IDProject"]);
                if(dr["IDProgram"].ToString()!="") ProjectModel.IDProgram = Convert.ToInt32(dr["IDProgram"]);
                if(dr["IDStrategicObjective"].ToString()!="")ProjectModel.IDStrategicObjective = Convert.ToInt32(dr["IDStrategicObjective"]);
                if(dr["IDDepartment"].ToString()!="")ProjectModel.IDDepartment = Convert.ToInt32(dr["IDDepartment"]);
                //if(dr["IDKategoriProject"].ToString() != "") ProjectModel.IDKategoriProject = Convert.ToInt32(dr["IDKategoriProject"]);
                
                ProjectModel.ProjectNo = dr["ProjectNo"].ToString();
                ProjectModel.Year = dr["Year"].ToString();
                ProjectModel.ProjectName = dr["ProjectName"].ToString();
                if(dr["Weight"].ToString()!="") ProjectModel.Weight = Convert.ToDouble(dr["Weight"]);
                if (dr["CreatedDate"].ToString()!="") ProjectModel.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                ProjectModel.CreatedBy = dr["CreatedBy"].ToString();
                if(dr["UpdatedDate"].ToString()!="") ProjectModel.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);
                ProjectModel.UpdatedDateString = dr["UpdatedDateString"].ToString();
                ProjectModel.UpdatedBy = dr["UpdatedBy"].ToString();
                if(dr["IsTransformasi"].ToString()!="") ProjectModel.IsTransformasi = Convert.ToBoolean(dr["IsTransformasi"]);
                if(dr["IsActive"].ToString() != "") ProjectModel.IsActive = Convert.ToBoolean(dr["IsActive"]);

                ListProjectModel.Add(ProjectModel);
            }
            return ListProjectModel;
        }

        public ProjectModel Post([FromBody]ProjectModel pm)
        {
            try
            {
                #region Declare Object
                MasterData md = new MasterData();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();
                DataTable dt4 = new DataTable();
                DataTable dt5 = new DataTable();
                DataTable dt6 = new DataTable();
                DataTable dt7 = new DataTable();
                DataTable dt8 = new DataTable();
                DataTable dt9 = new DataTable();
                DataTable dt10 = new DataTable();
                ProjectModel ProjectModel = new ProjectModel();

                ds = md.Get_MasterProject_ByID(pm.IDProject);
                dt = ds.Tables[0];
                dt1 = ds.Tables[1];
                dt2 = ds.Tables[2];
                dt3 = ds.Tables[3];
                dt4 = ds.Tables[4];
                dt5 = ds.Tables[5];
                dt6 = ds.Tables[6];
                dt7 = ds.Tables[7];
                dt8 = ds.Tables[8];
                dt9 = ds.Tables[9];
                dt10 = ds.Tables[10];
                #endregion

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
                    if (dt.Rows[0]["IDKategoriProject"].ToString() != "") ProjectModel.IDKategoriProject = Convert.ToInt32(dt.Rows[0]["IDKategoriProject"]);
                    if (dt.Rows[0]["Poin"].ToString() != "") ProjectModel.Poin = Convert.ToDouble(dt.Rows[0]["Poin"]);
                }
                #endregion

                #region Dropdownlist Program
                List<ProgramModel> ListProgramModel = new List<ProgramModel>();
                foreach (DataRow data in dt1.Rows)
                {
                    ProgramModel ProgramModel = new ProgramModel();
                    ProgramModel.ProgramName = data["ProgramName"].ToString();
                    if (data["IDProgram"].ToString() != "") ProgramModel.IDProgram = Convert.ToInt32(data["IDProgram"]);
                    if (data["IsActive"].ToString() != "") ProgramModel.IsActive = Convert.ToBoolean(data["IsActive"]);
                    ListProgramModel.Add(ProgramModel);
                }
                ProjectModel.ListProgram = ListProgramModel;
                #endregion

                #region Table SAP RKAT
                List<RKATModel> ListRKAT = new List<RKATModel>();
                foreach (DataRow data in dt2.Rows)
                {
                    RKATModel RKAT = new RKATModel();
                    if (data["IDSAPRKAT"].ToString() != "") RKAT.IDSAPRKAT = Convert.ToInt32(data["IDSAPRKAT"]);
                    RKAT.IDSAP = data["IDSAP"].ToString();
                    RKAT.COSTCTR = data["COSTCTR"].ToString();
                    RKAT.KPI = data["KPI"].ToString();
                    RKAT.DESCRIPTION = data["DESCRIPTION"].ToString();
                    RKAT.Value = gf.ToRupiah(data["Value"].ToString());
                    ListRKAT.Add(RKAT);
                }
                ProjectModel.ListRKAT = ListRKAT;
                #endregion

                #region Dropdown SO
                List<StrategicObjectiveModel> ListStrategicObjective = new List<StrategicObjectiveModel>();
                foreach (DataRow data in dt3.Rows)
                {
                    StrategicObjectiveModel StrategicObjectiveModel = new StrategicObjectiveModel();
                    if(data["IDStrategicObjective"].ToString()!="") StrategicObjectiveModel.IDStrategicObjective = Convert.ToInt32(data["IDStrategicObjective"]);
                    StrategicObjectiveModel.StrategicObjectiveCode = data["StrategicObjectiveCode"].ToString();
                    StrategicObjectiveModel.StrategicObjectiveName = data["StrategicObjectiveName"].ToString();
                    if(data["IsActive"].ToString()!="")StrategicObjectiveModel.IsActive = Convert.ToBoolean(data["IsActive"]);
                    ListStrategicObjective.Add(StrategicObjectiveModel);
                }
                ProjectModel.ListStrategicObjective = ListStrategicObjective;
                #endregion

                #region Table KPI Organization
                List<KPIOrganizationModel> ListKPIOrganization = new List<KPIOrganizationModel>();
                foreach (DataRow data in dt4.Rows)
                {
                    KPIOrganizationModel KPIOrganization = new KPIOrganizationModel();
                    if (data["IDKPIOrganization"].ToString() != "") KPIOrganization.IDKPIOrganization = Convert.ToInt32(data["IDKPIOrganization"]);
                    KPIOrganization.KPICode = data["KPICode"].ToString();
                    KPIOrganization.KPIName = data["KPIName"].ToString();
                    KPIOrganization.Year = data["Year"].ToString();
                    ListKPIOrganization.Add(KPIOrganization);
                }
                ProjectModel.ListKPIOrganization = ListKPIOrganization;
                #endregion

                #region Table MKU
                List<MkuModel> ListMku = new List<MkuModel>();
                ListMku = gf.ConvertTo<MkuModel>(dt10);
                ProjectModel.ListMKU = ListMku;
                #endregion

                #region Dropdown Project Priority
                List<ProjectPriorityModel> ListProjectPriority = new List<ProjectPriorityModel>();
                foreach (DataRow data in dt5.Rows)
                {
                    ProjectPriorityModel ProjectPriorityModel = new ProjectPriorityModel();
                    if (data["IDProjectPriority"].ToString() != "") ProjectPriorityModel.IDProjectPriority = Convert.ToInt32(data["IDProjectPriority"]);
                    ProjectPriorityModel.Name = data["Name"].ToString();
                    if (data["IsActive"].ToString() != "") ProjectPriorityModel.IsActive = Convert.ToBoolean(data["IsActive"]);
                    ListProjectPriority.Add(ProjectPriorityModel);
                }
                ProjectModel.ListProjectPriority = ListProjectPriority;
                #endregion

                #region Dropdown Department
                List<DepartmentModel> ListDepartment = new List<DepartmentModel>();
                foreach (DataRow data in dt6.Rows)
                {
                    DepartmentModel Department = new DepartmentModel();
                    if (data["IDDepartment"].ToString() != "") Department.IDDepartment = Convert.ToInt32(data["IDDepartment"]);
                    Department.DepartmentName = data["DepartmentName"].ToString();
                    Department.CostCenter = data["CostCenter"].ToString();
                    if (data["IsActive"].ToString() != "") Department.IsActive = Convert.ToBoolean(data["IsActive"]);
                    ListDepartment.Add(Department);
                }
                ProjectModel.ListDepartment = ListDepartment;
                #endregion

                #region Table List User Project
                List<ProjectRoleGroupModel> ListProjectRoleGroup = new List<ProjectRoleGroupModel>();
                foreach (DataRow data in dt7.Rows)
                {
                    ProjectRoleGroupModel ProjectRoleGroupModel = new ProjectRoleGroupModel();
                    UserAuthorizedModel UserAuthorizedModel = new UserAuthorizedModel();
                    EmployeeModel EmployeeModel = new EmployeeModel();
                    RoleGroupModel RoleGroupModel = new RoleGroupModel();

                    if (data["KodePosisi"].ToString() != "") EmployeeModel.KodePosisi = Convert.ToInt32(data["KodePosisi"]);
                    EmployeeModel.Jabatan = data["Jabatan"].ToString();
                    EmployeeModel.Nama = data["Nama"].ToString();
                    if (data["KodeUnitKerja"].ToString() != "") EmployeeModel.KodeUnitKerja = Convert.ToInt32(data["KodeUnitKerja"]);
                    EmployeeModel.PersonalNumber = data["PersonalNumber"].ToString();

                    UserAuthorizedModel.Employee = EmployeeModel;

                    RoleGroupModel.RoleGroupName = data["RoleGroupName"].ToString();
                    RoleGroupModel.RoleGroupID = data["IDRoleGroup"].ToString();

                    ProjectRoleGroupModel.Username = data["Username"].ToString();
                    ProjectRoleGroupModel.UserAuthorized = UserAuthorizedModel;
                    ProjectRoleGroupModel.RoleGroup = RoleGroupModel;

                    List<RoleGroupModel> LRG = new List<RoleGroupModel>();
                    string[] arr = data["IDRoleGroup"].ToString().Split('|');

                    foreach(string dataArr in arr)
                    {
                        RoleGroupModel RGM = new RoleGroupModel();
                        RGM.IDRoleGroup = Convert.ToInt32(dataArr);
                        LRG.Add(RGM);
                    }
                    ProjectRoleGroupModel.ListRoleGroup = LRG;

                    ListProjectRoleGroup.Add(ProjectRoleGroupModel);
                }
                ProjectModel.ListProjectRoleGroup = ListProjectRoleGroup;
                #endregion

                #region List Role Group
                List<RoleGroupModel> ListRoleGroup = new List<RoleGroupModel>();
                foreach (DataRow data in dt8.Rows)
                {
                    RoleGroupModel RoleGroup = new RoleGroupModel();
                    if (data["IDRoleGroup"].ToString() != "") RoleGroup.IDRoleGroup = Convert.ToInt32(data["IDRoleGroup"]);
                    RoleGroup.RoleGroupName = data["RoleGroupName"].ToString();
                    ListRoleGroup.Add(RoleGroup);
                }
                ProjectModel.ListRoleGroup = ListRoleGroup;
                #endregion

                #region List Kategori Project
                List<ProjectKategoriModel> ListProjectKategori = new List<ProjectKategoriModel>();
                foreach (DataRow data in dt9.Rows)
                {
                    ProjectKategoriModel ProjectKategori = new ProjectKategoriModel();
                    if (data["IDKategoriProject"].ToString() != "") ProjectKategori.IDKategoriProject = Convert.ToInt32(data["IDKategoriProject"]);
                    ProjectKategori.KategoriName = data["KategoriName"].ToString();
                    if (data["IsActive"].ToString() != "") ProjectKategori.IsActive = Convert.ToBoolean(data["IsActive"]);
                    ListProjectKategori.Add(ProjectKategori);
                }
                ProjectModel.ListProjectKategori = ListProjectKategori;
                #endregion

                return ProjectModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
