using LPS_API.Models.PJSModels;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.PJSController
{
    public class PJSApprovalCRUDController : ApiController
    {

        PJSApproval PJSA = new PJSApproval();

        public string Post(PJSModel data)
        {
            try
            {
                string result = PJSA.Insert_PJSApproval(
                    data.ID.ToString(),
                    data.ExistingUsername.ToString(),
                    data.PJSUsername.ToString(),
                    "",//data.IDRoleGroup.ToString(),
                    data.StartDate,
                    data.EndDate,
                    data.Note,
                    data.PersonalNumber,
                    data.TypeTransaction
                    );

                return result;
            }
            catch (Exception ex)
            {
                return "F|Kesalahan pada API : " + ex.Message;
            }

        }

    }
}
