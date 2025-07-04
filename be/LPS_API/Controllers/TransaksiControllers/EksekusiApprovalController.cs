using LPS_API.Models;
using LPS_API.Models.TransaksiDataModels;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.TransaksiControllers
{
    public class EksekusiApprovalController : ApiController
    {
        TransaksiEksekusi TE = new TransaksiEksekusi();
        public string Push([FromBody]MultiPorpose MP)
        {
            var param = MP.ID.Split('|');
            int ProjectHeaderID = Convert.ToInt32(param[0]);
            string Periode = param[1];
            string Persnum = param[2];

            string Status = TE.ApproveEksekusi(ProjectHeaderID, Periode, Persnum);

            return Status;
        }

        public string Put([FromBody]ProjectHeaderModel ph)
        {
            try
            {
                string result = TE.ReviseEksekusi(ph.IDProjectHeader, ph.TypeTransaction, ph.CreatedBy, ph.ApprovedBy);

                return result;
            }
            catch (Exception ex)
            {
                return "F|Kesalahan pada API : " + ex.Message;
            }
        }
    }
}
