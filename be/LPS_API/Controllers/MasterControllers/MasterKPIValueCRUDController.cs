using LPS_API.Models.MasterDataModels;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.MasterControllers
{
    public class MasterKPIValueCRUDController : ApiController
    {
        public string Post(KPIValueModel obj)
        {
            try
            {
                MasterData md = new MasterData();
                string result = "F|Terdapat kesalahan pada API Controller";

                result = md.Insert_MasterKPIValue(
                    obj.PersonNumber,
                    obj.IDProject,
                    obj.TW1,
                    obj.TW2,
                    obj.TW3,
                    obj.TW4);

                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
