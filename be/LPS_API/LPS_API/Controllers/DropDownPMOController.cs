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
    public class DropDownPMOController : ApiController
    {
        public List<DropDownPMOModel> Post([FromBody]AllDataRowModel obj)
        {
            Report r = new Report();

            DataTable dt = r.Get_DropdownPMO(obj.Year.ToString(), obj.Month.ToString(), obj.Week.ToString());

            List<DropDownPMOModel> ListddPMO = new List<DropDownPMOModel>();

            foreach(DataRow dr in dt.Rows)
            {
                DropDownPMOModel ddPMOM = new DropDownPMOModel();

                ddPMOM.PersonalNumber = dr["PersonalNumber"].ToString();
                ddPMOM.Username = dr["User_LoginName"].ToString();
                ddPMOM.Nama = dr["Nama"].ToString();

                ListddPMO.Add(ddPMOM);
            }

            return ListddPMO;
        }
    }
}
