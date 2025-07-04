using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.UserManagementModels
{
    public class UserManagementModel
    {
        public string nama { get; set; }
        public string posisi { get; set; }
        public string role { get; set; }
        public string proyek { get; set; }
        public string personnumber { get; set; }
    }

    public class MultiPorpose
    {
        public string ID { get; set; }
    }

    public class RegisteredUserDetail
    {
        public int    ID { get; set; }
        public string NIK { get; set; }
        public string Nama { get; set; }
        public string Posisi { get; set; }
        public string Perusahaan { get; set; }
        public string UnitKerja { get; set; }
        public string Email { get; set; }
        public string Alamat { get; set; }
        public string PersonalNumber { get; set; }

    }

    public class UserDetailInOut
    {
        public int ID { get; set; }
        public string NIK { get; set; }
        public string Nama { get; set; }
        public string Posisi { get; set; }
        public string Perusahaan { get; set; }
        public string UnitKerja { get; set; }
        public string Email { get; set; }
        public string Alamat { get; set; }
        public string PersonalNumber { get; set; }
        public List<AllRoles> AllRole { get; set; }
        public DropDownUserManagementModel DDLUm { get; set; }
        public List<NewUserModel> NUM { get; set; }
    }

    public class UserSearchList
    {
        public string personalnumber { get; set; }
        public string nama { get; set; }
        public string posisi { get; set; }
    }

    public class TableTypeRoles
    {
        public int IDProgram { get; set; }
        public int IDProject { get; set; }
        public string IDRoles { get; set; }
    }

    public class AllRoles
    {
        public string IDProgram { get; set; }
        public string ProgramName { get; set; }
        public string IDProject { get; set; }
        public string ProjectName { get; set; }
        public string IDRoleGroup { get; set; }
        public string RoleGroupName { get; set; }
    }

    public class InsertDataUser
    {
        public string PersonNumber { get; set; }
        public string  CreateBy { get; set; }
        public List<TableTypeRoles> RolesGroup { get; set; }
    }
}