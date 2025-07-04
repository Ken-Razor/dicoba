using LPS_API.Models;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace LPS_API.Controllers.TransaksiControllers
{
    public class FileUploadMilestoneController
    {
        TransaksiEksekusi TE = new TransaksiEksekusi();

        public string Push([FromBody]MultiPorpose File)
        {

            //var param = File.ID.Split('|');
            //var IDDoctype = Convert.ToInt32(param[0]);
            //var ProjHead = Convert.ToInt32(param[1]);
            //var TaskID = Convert.ToInt64(param[2]);
            //var DocName = param[3];
            //var DocType = param[4];

            //var data = TE.UploadMilestone(IDDoctype, ProjHead, TaskID, DocName, DocType);

            return null;
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