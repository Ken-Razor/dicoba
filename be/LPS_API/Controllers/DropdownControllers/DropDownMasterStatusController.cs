using LPS_API.Models;
using LPS_API.Models.ReportModels;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers
{
    public class DropDownMasterStatusController : ApiController
    {
        public List<DropDownMasterStatusModel> Post()
        {
            Report r = new Report();

            DataTable dt = r.Get_DropdownMasterStatus();

            List<DropDownMasterStatusModel> ListddOwner = new List<DropDownMasterStatusModel>();

            foreach (DataRow dr in dt.Rows)
            {
                DropDownMasterStatusModel ddOwner = new DropDownMasterStatusModel();

                ddOwner.Id = dr["Id"].ToString();
                ddOwner.Deskripsi = dr["Deskripsi"].ToString();

                ListddOwner.Add(ddOwner);
            }

            return ListddOwner;
        }
    }
}
