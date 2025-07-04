using LPS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LPS_BLL;
namespace LPS_API.Controllers
{
    public class DeleteFileController : ApiController
    {
        public string post([FromBody]MultiPorpose MP)
        {
            MasterData MD = new MasterData();

            var param = MP.ID.Split('|');

            var ProjHeaderID = Convert.ToInt32(param[0]);
            var DocID = Convert.ToInt32(param[1]);
            string result = MD.DeleteFile(ProjHeaderID, DocID);
            return result;
        }
    }
}
