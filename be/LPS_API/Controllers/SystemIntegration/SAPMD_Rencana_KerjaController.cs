using LPS_API.Helper;
using LPS_API.Models.SystemIntegration;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.SystemIntegration
{
    public class SAPMD_Rencana_KerjaController : ApiController
    {
        GlobalFunction GF = new GlobalFunction();
        IntegrationSystem IS = new IntegrationSystem();
        public string Push([FromBody]SAPMD_Rencana_Kerja Data)
        {

          string ID                 = Data.ID             ;
          string ACTIVE             = Data.ACTIVE         ;
          string COSTCTR            = Data.COSTCTR        ;
          string EVDESCRIPTION      = Data.EVDESCRIPTION  ;
          string KPI                = Data.KPI            ;
          string KPI_GROUP          = Data.KPI_GROUP      ;
          string LEVEL              = Data.LEVEL          ;
          string LONG_DESC          = Data.LONG_DESC      ;
          string PRO_GROUP          = Data.PRO_GROUP      ;
          string SCALING            = Data.SCALING        ;
          string STRAT_OBJ          = Data.STRAT_OBJ      ;
          string UNCONTROLLABLE     = Data.UNCONTROLLABLE ;
          string WORKPLAN_TYPE      = Data.WORKPLAN_TYPE  ;
          string YEAR               = Data.YEAR           ;
          string PARENTH1           = Data.PARENTH1;

          var status = IS.SAPMDRENCANA(
                  ID                    ,
                  ACTIVE                ,
                  COSTCTR               ,
                  EVDESCRIPTION         ,
                  KPI                   ,
                  KPI_GROUP             ,
                  LEVEL                 ,
                  LONG_DESC             ,
                  PRO_GROUP             ,
                  SCALING               ,
                  STRAT_OBJ             ,
                  UNCONTROLLABLE        ,
                  WORKPLAN_TYPE         ,
                  YEAR                  ,
                  PARENTH1
           );
           return status;
        }
    }
}
