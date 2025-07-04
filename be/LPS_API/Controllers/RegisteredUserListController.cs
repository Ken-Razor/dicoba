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
    public class RegisteredUserListController : ApiController
    {
        UserManagement UM = new UserManagement();

        public List<RegisteredUserList> Get()
        {
            DataTable dt = UM.ListRegisteredUser();
            List<RegisteredUserList> _ListUser = new List<RegisteredUserList>();

            foreach (DataRow dr in dt.Rows)
            {
                RegisteredUserList _Result = new RegisteredUserList();

                _Result.nama = dr["Nama"].ToString();
                _Result.posisi = dr["Posisi"].ToString();
                _Result.proyek = dr["Project"].ToString();
                _Result.role = dr["Roles"].ToString();
                _Result.personnumber = dr["PersonNumber"].ToString();

                _ListUser.Add(_Result);
            }

            return _ListUser;
        }

        public RegisteredUserDetail Push([FromBody]MultiPorpose Detail)
        {
            DataSet ds = UM.DetailRegisteredUser(Detail.ID);
            DataTable UserDetail = ds.Tables[0];
            DataTable AllRoles = ds.Tables[1];

            RegisteredUserDetail _UserDetail = new RegisteredUserDetail();

            List<AllRoles> _AllRoles = new List<AllRoles>();

            foreach (DataRow druser in UserDetail.Rows)
            {
                _UserDetail.NIK = druser["NIK"].ToString();
                _UserDetail.Nama = druser["Nama"].ToString();
                _UserDetail.Posisi = druser["Posisi"].ToString();
                _UserDetail.Perusahaan = druser["Perusahaan"].ToString();
                _UserDetail.UnitKerja = druser["Departement"].ToString();
                _UserDetail.Email = druser["Email"].ToString();
                _UserDetail.Alamat = druser["Alamat"].ToString();
            }

            if (AllRoles.Rows.Count > 0)
            {
                foreach (DataRow drAllRoles in AllRoles.Rows)
                {
                    AllRoles _AllRolesContent = new AllRoles();


                    string Roles = drAllRoles["Roles"].ToString();
                    if (Roles != null && Roles != "")
                    {
                        string RolesSubOne = Roles.Remove(Roles.Length - 1);
                        _AllRolesContent.RoleGroupName = RolesSubOne;
                    }
                    
                    _AllRolesContent.IDProgram = drAllRoles["IDProgram"].ToString();
                    _AllRolesContent.ProgramName = drAllRoles["ProgramName"].ToString();
                    _AllRolesContent.IDProject = drAllRoles["IDProject"].ToString();
                    _AllRolesContent.ProjectName = drAllRoles["ProjectName"].ToString();
                    _AllRolesContent.IDRoleGroup = drAllRoles["RolesID"].ToString();
                 

                    _AllRoles.Add(_AllRolesContent);
                }
            }

            _UserDetail.AllRole = _AllRoles;

            return _UserDetail;
        }

        public string Put([FromBody]MultiPorpose Detail)
        {
            var Param = Detail.ID.Split('|');

            string NewUserPersnum = Param[0];
            string RoleID = Param[1];
            string CreateBYPersnum = Param[2];

            var result = UM.InsertNewUserWithRole(NewUserPersnum, CreateBYPersnum, Convert.ToInt32(RoleID));
            return result;
        }
    }
}
