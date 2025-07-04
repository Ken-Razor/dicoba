using LPS_API.Models.MasterDataModels;
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
    public class MasterProjectCRUDController : ApiController
    {
        public string Post([FromBody]ProjectModel pm)
        {
            try
            {
                MasterData md = new MasterData();
                string result = "F|Terdapat kesalahan pada API Controller";
                DepartmentModel Department = new DepartmentModel();

                string IDKPIOrganization = "";
                string IDSAPRKAT = "";
                string IDMKU = "";

                DataTable Udt_ProjectRoleGroup = new DataTable();
                DataRow dr;
                Udt_ProjectRoleGroup.Clear();
                Udt_ProjectRoleGroup.Columns.Add("IDRoleGroup");
                Udt_ProjectRoleGroup.Columns.Add("Username");

                if (pm.ListKPIOrganization != null)
                    foreach (var data in pm.ListKPIOrganization)
                    {
                        IDKPIOrganization = IDKPIOrganization + data.IDKPIOrganization.ToString() + "|";
                    }

                if (pm.ListRKAT != null)
                    foreach (var data in pm.ListRKAT)
                    {
                        IDSAPRKAT = IDSAPRKAT + data.IDSAPRKAT + "|";
                    }

                if (pm.ListMKU != null)
                    foreach (var data in pm.ListMKU)
                    {
                        IDMKU = IDMKU + data.IdDepartment + "|";
                    }

                if (pm.ListProjectRoleGroup != null)
                    foreach (var data in pm.ListProjectRoleGroup)
                    {
                        string[] arrRole = data.RoleGroupID.ToString().Split('|');
                        foreach (var dataRole in arrRole)
                        {
                            dr = Udt_ProjectRoleGroup.NewRow();
                            dr["IDRoleGroup"] = dataRole;
                            dr["Username"] = data.Username;
                            Udt_ProjectRoleGroup.Rows.Add(dr);
                        }
                    }

                result = md.Insert_MasterProject(
                    pm.IDProject,
                    pm.IDProgram,
                    pm.IDStrategicObjective,
                    pm.IDProjectPriority,
                    pm.IDDepartment,
                    pm.ProjectNo,
                    pm.Year,
                    pm.ProjectName,
                    pm.Weight,
                    pm.IsTransformasi,
                    IDKPIOrganization,
                    IDSAPRKAT,
                    Udt_ProjectRoleGroup,
                    pm.CreatedBy,
                    "Insert"
                    ,pm.IDKategoriProject,
                    pm.Poin,
                    IDMKU
                );

                return result;
            }
            catch (Exception ex)
            {
                return "Kesalahan pada API Controller : " + ex.Message;
            }
        }

        public string Put([FromBody]ProjectModel pm)
        {
            try
            {
                MasterData md = new MasterData();
                string result = "F|Terdapat kesalahan pada API Controller";
                DepartmentModel Department = new DepartmentModel();

                string IDKPIOrganization = "";
                string IDSAPRKAT = "";
                string IDMKU = "";

                DataTable Udt_ProjectRoleGroup = new DataTable();
                DataRow dr;
                Udt_ProjectRoleGroup.Clear();
                Udt_ProjectRoleGroup.Columns.Add("IDRoleGroup");
                Udt_ProjectRoleGroup.Columns.Add("Username");

                if (pm.ListKPIOrganization != null)
                    foreach (var data in pm.ListKPIOrganization)
                    {
                        IDKPIOrganization = IDKPIOrganization + data.IDKPIOrganization.ToString() + "|";
                    }

                if (pm.ListRKAT != null)
                    foreach (var data in pm.ListRKAT)
                    {
                        IDSAPRKAT = IDSAPRKAT + data.IDSAPRKAT + "|";
                    }

                if (pm.ListMKU != null)
                    foreach (var data in pm.ListMKU)
                    {
                        IDMKU = IDMKU + data.IdDepartment + "|";
                    }

                if (pm.ListProjectRoleGroup != null)
                    foreach(var data in pm.ListProjectRoleGroup)
                    {
                        string[] arrRole = data.RoleGroupID.ToString().Split('|');
                        foreach(var dataRole in arrRole)
                        {
                            dr = Udt_ProjectRoleGroup.NewRow();
                            dr["IDRoleGroup"] = dataRole;
                            dr["Username"] = data.Username;
                            Udt_ProjectRoleGroup.Rows.Add(dr);
                        }
                    }

                result = md.Insert_MasterProject(
                    pm.IDProject,
                    pm.IDProgram,
                    pm.IDStrategicObjective,
                    pm.IDProjectPriority,
                    pm.IDDepartment,
                    pm.ProjectNo,
                    pm.Year,
                    pm.ProjectName,
                    pm.Weight,
                    pm.IsTransformasi,
                    IDKPIOrganization,
                    IDSAPRKAT,
                    Udt_ProjectRoleGroup,
                    pm.CreatedBy,
                    "Update"
                    ,pm.IDKategoriProject,
                    pm.Poin,
                    IDMKU
                );

                return result;
            }
            catch (Exception ex)
            {
                return "Kesalahan pada API Controller : " + ex.Message;
            }
        }

        public string Delete(int IDProject, string TypeTransaction)
        {
            try
            {
                MasterData md = new MasterData();
                string result = "F|Terdapat kesalahan pada API Controller";
                ProjectModel pm = new ProjectModel();
                pm.IDProject = IDProject;

                string IDKPIOrganization = "";
                string IDSAPRKAT = "";
                string IDMKU = "";

                DataTable Udt_ProjectRoleGroup = new DataTable();
                Udt_ProjectRoleGroup.Clear();
                Udt_ProjectRoleGroup.Columns.Add("IDRoleGroup");
                Udt_ProjectRoleGroup.Columns.Add("Username");
                
                result = md.Insert_MasterProject(
                    pm.IDProject,
                    pm.IDProgram,
                    pm.IDStrategicObjective,
                    pm.IDProjectPriority,
                    pm.IDDepartment,
                    pm.ProjectNo,
                    pm.Year,
                    pm.ProjectName,
                    pm.Weight,
                    pm.IsTransformasi,
                    IDKPIOrganization,
                    IDSAPRKAT,
                    Udt_ProjectRoleGroup,
                    pm.CreatedBy,
                    TypeTransaction
                    ,pm.IDKategoriProject,
                    pm.Poin,
                    IDMKU
                );

                return result;
            }
            catch (Exception ex)
            {
                return "Kesalahan pada API Controller : " + ex.Message;
            }
        }
    }
}
