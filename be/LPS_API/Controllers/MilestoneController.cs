using LPS_API.Models;
using LPS_BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers
{
    public class MilestoneController : ApiController
    {
        IntegrationSystem IS = new IntegrationSystem();
        MasterData MD = new MasterData();
        public string Post(MultiPorpose MP)
        {
            var param = MP.ID.Split('|');
            var TaskID = Convert.ToInt32(param[0]);
            var ProjectHeaderID = Convert.ToInt32(param[1]);
            //var ID = Convert.ToInt32(MD.Get_Root(ProjectHeaderID));
            string value = DataTableToJSONWithJSONNet(IS.CheckMilestone(ProjectHeaderID, TaskID));

            return value;
        }

        private string DataTableToJSONWithJSONNet(DataTable table)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }


    }
}
