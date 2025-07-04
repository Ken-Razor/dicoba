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
    public class DropDownOwnerController : ApiController
    {
        public List<DropDownOwnerModel> Post([FromBody]AllDataRowModel obj)
        {
            Report r = new Report();

            DataTable dt = r.Get_DropdownOwner(obj.Year.ToString(), obj.Month.ToString(), obj.Week.ToString());

            List<DropDownOwnerModel> ListddOwner = new List<DropDownOwnerModel>();

            foreach (DataRow dr in dt.Rows)
            {
                DropDownOwnerModel ddOwner = new DropDownOwnerModel();

                ddOwner.PersonalNumber = dr["PersonalNumber"].ToString();
                ddOwner.Username = dr["User_LoginName"].ToString();
                ddOwner.Nama = dr["Nama"].ToString();

                ListddOwner.Add(ddOwner);
            }

            return ListddOwner;
        }
    }
}
