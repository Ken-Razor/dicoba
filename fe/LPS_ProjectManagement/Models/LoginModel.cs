using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LPS_ProjectManagement.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }

    public class AuthenticationModel
    {
        public string Username { get; set; }
        public string PersonalNumber { get; set; }
        public string Nama { get; set; }
        public string Title { get; set; }
        public string Departement { get; set; }
        public string Keterangan { get; set; }
        public string RolesSystem { get; set; }
        public List<RoleProject> RoleProject { get; set; }
    }


    public class RoleProject
    {
        public string Role { get; set; }
    }
}