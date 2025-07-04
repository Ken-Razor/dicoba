using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models
{
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

    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}