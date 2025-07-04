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
    public class SAPRKATFinalController : ApiController
    {
        GlobalFunction GF = new GlobalFunction();
        IntegrationSystem IS = new IntegrationSystem();
        public string Push([FromBody]SAPIntegration Data)
        {

            var ACCT_CODE = Data.ACCT_CODE;
            var AST_TYP = Data.AST_TYP;
            var AUDITTRAIL = Data.AUDITTRAIL;
            var CATEGORY = Data.CATEGORY;
            var COSTCTR = Data.COSTCTR;
            var DRIVER = Data.DRIVER;
            var FLOW = Data.FLOW;
            var RENCANA_KERJA = Data.RENCANA_KERJA;
            var RPTCURRENCY = Data.RPTCURRENCY;
            var STD_BIAYA = Data.STD_BIAYA;
            var STRAT_OBJ = Data.STRAT_OBJ;
            var TIME = Data.TIME;
            var SIGNEDDATA = Data.SIGNEDDATA;

            var status = IS.SAPRKATFinal(
                    ACCT_CODE,
                    AST_TYP,
                    AUDITTRAIL,
                    CATEGORY,
                    COSTCTR,
                    DRIVER,
                    FLOW,
                    RENCANA_KERJA,
                    RPTCURRENCY,
                    STD_BIAYA,
                    STRAT_OBJ,
                    TIME,
                    SIGNEDDATA
                );
            return status;
        }
    }
}
