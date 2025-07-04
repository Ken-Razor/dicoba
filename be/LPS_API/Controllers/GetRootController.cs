using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers
{
    public class GetRootController : ApiController
    {
        MasterData MD = new MasterData();
        public string Get(string ProjectHeaderID)
        {
            var ID = MD.Get_Root(Convert.ToInt32(ProjectHeaderID));
            return ID;
        }
    }
}
