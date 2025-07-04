using LPS_API.Models.SystemIntegration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.SystemIntegration
{
    public class ActuateKPIController : ApiController
    {
        public string Push([FromBody]KPI Datas)
        {
            string SO_ID = SO.SO_ID;
            string SO_Code = SO.SO_Code;
            string SO_Name = SO.SO_Name;
            string SO_Desc = SO.SO_Desc;
            string SO_Year = SO.SO_Year;
            string SO_IsActive = SO.SO_IsActive;


            string Status = IS.ActuateSO(
                SO_ID,
                SO_Code,
                SO_Name,
                SO_Desc,
                SO_Year,
                SO_IsActive
            );
            return Status;
        }
    }
}
