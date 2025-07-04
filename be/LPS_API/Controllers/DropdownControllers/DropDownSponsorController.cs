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
    public class DropDownSponsorController : ApiController
    {
        public List<DropDownSponsorModel> Post([FromBody]AllDataRowModel obj)
        {
            Report r = new Report();

            DataTable dt = r.Get_DropdownSponsor(obj.Year.ToString(), obj.Month.ToString(), obj.Week.ToString());

            List<DropDownSponsorModel> ListddSponsor = new List<DropDownSponsorModel>();

            foreach (DataRow dr in dt.Rows)
            {
                DropDownSponsorModel ddSponsor = new DropDownSponsorModel();

                ddSponsor.PersonalNumber = dr["PersonalNumber"].ToString();
                ddSponsor.Username = dr["User_LoginName"].ToString();
                ddSponsor.Nama = dr["Nama"].ToString();

                ListddSponsor.Add(ddSponsor);
            }

            return ListddSponsor;
        }
    }
}
