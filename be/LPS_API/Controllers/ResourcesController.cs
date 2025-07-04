using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LPS_BLL;

namespace LPS_API.Controllers
{
    public class ResourcesController : ApiController
    {
        TransaksiInitiation TI = new TransaksiInitiation();
        public List<object> Get(string ProjectHeaderID)
        {
            var task = TI.GetResourcesByProjectHeaderID(ProjectHeaderID);
            return task;
        }
    }
}
