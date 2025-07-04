using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.MasterControllers
{
    public class MasterKPIValueGenerateController : ApiController
    {
        public string Post()
        {
            try
            {
                MasterData md = new MasterData();
                string result = "F|Terdapat kesalahan pada API Controller";
                 
                result = md.Generate_MasterKPIValue(); 

                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
