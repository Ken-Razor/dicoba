using LPS_API.Models;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.TransaksiControllers
{
    public class UploadFileController : ApiController
    {
        TransaksiEksekusi TE = new TransaksiEksekusi();
        public string Push([FromBody]MultiPorpose File)
        {
            var param = File.ID.Split('|');
            var IDDoctype = Convert.ToInt32(param[0]);
            var ProjHead = Convert.ToInt32(param[1]);
            var PersonNumber = param[2];
            var DocName = param[3];
            var IDDocPhase = Convert.ToInt32(param[4]);
            var TaskID = Convert.ToInt64(param[5]);

            var data = TE.UploadFile(IDDoctype, ProjHead, DocName, IDDocPhase,PersonNumber, TaskID);

            return data;
        }

        public string Put([FromBody]MultiPorpose File)
        {

            var param = File.ID.Split('|');
            var ProjHead = Convert.ToInt32(param[0]);
            var TaskID = Convert.ToInt64(param[1]);
            var FileID = Convert.ToInt32(param[2]);

            var data = TE.DeleteMilestone(ProjHead, TaskID, FileID);

            return data;
        }
    }
}
