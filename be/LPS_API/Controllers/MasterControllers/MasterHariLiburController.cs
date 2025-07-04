using LPS_BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers
{
    public class MasterHariLiburController : ApiController
    {
        MasterData MD = new MasterData();
        public string Get()
        {
            var HariLibur = MD.Get_HariLibur();

            var rb = JsonConvert.SerializeObject(HariLibur);

            return rb;
        }
    }
}
