using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LPS_API.Models.EksekusiModels;
using LPS_API.Models;
using LPS_BLL;
using LPS_API.Helper;
using System.Data;

namespace LPS_API.Controllers.TransaksiControllers
{
    public class EksekusiMilestoneController : ApiController
    {
        TransaksiEksekusi TE = new TransaksiEksekusi();
        GlobalFunction GF = new GlobalFunction();
        public EksekusiMilestone Push ( [FromBody]MultiPorpose data)
        {
            var split = data.ID.Split('|');
            var ProjectHeader = Convert.ToInt32(split[0]);
            var TaskID = Convert.ToInt64(split[1]);

            var datas = TE.GetDetailMilestone(ProjectHeader, TaskID);

            var TaskDetail = GF.ConvertTo<Milestone>(datas.Tables[0]);
            var File = GF.ConvertTo<MilestoneFile>(datas.Tables[1]);

            EksekusiMilestone EM = new EksekusiMilestone();

            EM.miles = TaskDetail;
            EM.file = File;
            DataTable StatusProject = datas.Tables[2];
            EM.ProjectStatus = StatusProject.Rows[0]["ProjectStatus"].ToString(); ;
            return EM;
        }
    }
}
