using LPS_API.Models.TransaksiClosingModels;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.TransaksiClosingControllers
{
    public class ClosingCRUDController : ApiController
    {
        public string Post([FromBody]ClosingProjectDetailModel cpdm)
        {
            try
            {
                TransaksiClosing tc = new TransaksiClosing();

                string result = tc.Insert_TransaksiClosingProjectHeader(
                    cpdm.IDProjectHeader,
                    cpdm.ClosingDate,
                    cpdm.Remarks,
                    cpdm.WhatWorkWell,
                    cpdm.WhatDidNotWorkWell,
                    cpdm.WhatCanBeImproved,
                    "Close",
                    cpdm.CreatedBy
                );

                return result;
            }
            catch(Exception ex)
            {
                string result = "F|Internal Server Error : " + ex;
                return result;
            }
        }
    }
}
