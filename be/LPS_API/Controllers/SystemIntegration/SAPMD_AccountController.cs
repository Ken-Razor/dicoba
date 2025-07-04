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
    public class SAPMD_AccountController : ApiController
    {
        GlobalFunction GF = new GlobalFunction();
        IntegrationSystem IS = new IntegrationSystem();
        public string Push([FromBody]SAPMD_Account Data)
        {

            string ID               = Data.ID               ;
            string ACCTYPE          = Data.ACCTYPE          ;
            string ASSUM_TYPE       = Data.ASSUM_TYPE       ;
            string DIMLIST_CF       = Data.DIMLIST_CF       ;
            string EVDESCRIPTION    = Data.EVDESCRIPTION    ;
            string FS               = Data.FS               ;
            string PLANNING         = Data.PLANNING         ;
            string RATETYPE         = Data.RATETYPE         ;
            string REF_ACCOUNT      = Data.REF_ACCOUNT      ;
            string SCALING          = Data.SCALING          ;
            string PARENTH1         = Data.PARENTH1         ;
            string PARENTH2         = Data.PARENTH2         ;
            string PARENTH3         = Data.PARENTH3         ;
            string PARENTH4         = Data.PARENTH4         ;
            string PARENTH5 = Data.PARENTH5;

            var status = IS.SAPAccount(
                   ID                ,
                   ACCTYPE           ,
                   ASSUM_TYPE        ,
                   DIMLIST_CF        ,
                   EVDESCRIPTION     ,
                   FS                ,
                   PLANNING          ,
                   RATETYPE          ,
                   REF_ACCOUNT       ,
                   SCALING           ,
                   PARENTH1          ,
                   PARENTH2          ,
                   PARENTH3          ,
                   PARENTH4          ,
                   PARENTH5
                );
            return status;
        }
    }
}
