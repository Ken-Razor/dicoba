using LPS_API.Helper;
using LPS_API.Models;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers
{
    public class UserNewController : ApiController
    {
        UserManagement UM = new UserManagement();
        GlobalFunction GF = new GlobalFunction();

        public List<NewUserModel> Get(string PersonNumber)
        {
            var result = UM.AllProject(PersonNumber);
            List<NewUserModel> Res = GF.ConvertTo<NewUserModel>(result);
            return Res;
        }
    }
}
