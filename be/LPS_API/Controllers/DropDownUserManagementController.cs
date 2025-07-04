using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LPS_API.Models;
using LPS_BLL;

namespace LPS_API.Controllers
{
    public class DropDownUserManagementController : ApiController
    {
        UserManagement UM = new UserManagement();

        public DropDownUserManagementModel Get()
        {
            DropDownUserManagementModel _DDL = new DropDownUserManagementModel();

            List<DropDownProgram> _DDLProgram = new List<DropDownProgram>();
            List<DropDownRole> _DDLRoles = new List<DropDownRole>();

            var DS = UM.DropDownProgramandRoles();

            DataTable dtProgram = DS.Tables[0];
            DataTable dtRoles = DS.Tables[1];

            foreach (DataRow drProgram in dtProgram.Rows)
            {
                var _DDLProgramSatuan = new DropDownProgram();

                _DDLProgramSatuan.IDProgram = Convert.ToInt32(drProgram["IDProgram"]);
                _DDLProgramSatuan.ProgramName = drProgram["ProgramName"].ToString();

                _DDLProgram.Add(_DDLProgramSatuan);
            }

            foreach (DataRow drRoles in dtRoles.Rows)
            {
                var _DDLRolesSatuan = new DropDownRole();

                _DDLRolesSatuan.IDRoleGroup = Convert.ToInt32(drRoles["IDRoleGroup"]);
                _DDLRolesSatuan.RoleGroupName = drRoles["RoleGroupName"].ToString();

                _DDLRoles.Add(_DDLRolesSatuan);
            }

            _DDL.Programs = _DDLProgram;
            _DDL.Roles = _DDLRoles;

            return _DDL;
        }

        public DropDownProgram Get(int IDProject)
        {
            DropDownProgram _Program = new DropDownProgram();

            DataTable dt = UM.DropDownProgram(IDProject);

            if(dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                _Program.IDProgram = Convert.ToInt32(dr["IDProgram"]);
                _Program.ProgramName = dr["ProgramName"].ToString();

            }

            return _Program;
        }

        public DropDownUserManagementModel Post([FromBody]DropDownProgram Program)
        {
            DropDownUserManagementModel _DDL = new DropDownUserManagementModel();

            List<DropDownProject> _DDLProject = new List<DropDownProject>();

            var dt = UM.DropDownProject(Program.IDProgram);

            foreach (DataRow drProject in dt.Rows)
            {
                var _DDLProjactSatuan = new DropDownProject();

                _DDLProjactSatuan.IDProject = Convert.ToInt32(drProject["IDProject"]);
                _DDLProjactSatuan.ProjectName = drProject["ProjectName"].ToString();

                _DDLProject.Add(_DDLProjactSatuan); 
            }

            _DDL.Projects = _DDLProject;
            return _DDL;
        }
    }
}
