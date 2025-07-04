using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LPS_API.Models.SystemIntegration;
using LPS_BLL;
using System.Data;
using LPS_API.Helper;

namespace LPS_API.Controllers.SystemIntegration
{
    public class ActuateController : ApiController
    {
        IntegrationSystem IS = new IntegrationSystem();
        GlobalFunction gf = new GlobalFunction();
        public string Post([FromBody]SO SO)
        {
             string SO_ID        = SO.SO_ID         ;
             string SO_Code      = SO.SO_Code       ;
             string SO_Name      = SO.SO_Name       ;
             string SO_Desc      = SO.SO_Desc       ;
             string SO_Year      = SO.SO_Year       ;
             string SO_IsActive  = SO.SO_IsActive   ;


            string  Status = IS.ActuateSO(
                SO_ID,
                SO_Code,
                SO_Name,
                SO_Desc,
                SO_Year,
                SO_IsActive
            );
            return Status;
        }

        public string Put([FromBody]KPI KPI)
        {
            string KPI_ID             =   KPI.KPI_ID        ;
            string KPI_SO_ID          =   KPI.KPI_SO_ID     ;
            string KPI_Code           =   KPI.KPI_Code      ;
            string KPI_Name           =   KPI.KPI_Name      ;
            string KPI_Desc           =   KPI.KPI_Desc      ;
            string KPI_Year           =   KPI.KPI_Year      ;
            string KPI_IsActive       =   KPI.KPI_IsActive  ;

            string Status = IS.ActuateKPI(
             KPI_ID           ,  
             KPI_SO_ID        ,
             KPI_Code         ,
             KPI_Name         ,
             KPI_Desc         ,
             KPI_Year         ,
             KPI_IsActive
    
             );
            return Status;
        }

    }
}
