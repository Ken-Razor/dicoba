using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LPS_API.Models;
using LPS_API.Models.EksekusiModels;
using LPS_BLL;

namespace LPS_API.Controllers.TxExecControllers 
{
    public class ExecListChgApprController : ApiController 
    {
        TxExec TE = new TxExec();
        public List<object> Push([FromBody]MultiPorpose persnum)
        {
            var Data = TE.GetListExecChgAppr(persnum.ID);
            return Data;
        }

    }
}
