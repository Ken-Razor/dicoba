using LPS_API.Models.DashboardModels;
using LPS_API.Models.MasterDataModels;
using LPS_API.Models.ReportModels;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.DashboardControllers
{
    public class MasterDetailHolidayController : ApiController
    {
        //test
        public MasterHoliday Get(int Id)
        {
            Holiday dd = new Holiday();
            DataSet ds = dd.Get_Master_Holiday_byId(Id);
            DataTable dt = ds.Tables[0];
            MasterHoliday s = new MasterHoliday();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["IDHoliday"].ToString() != "") s.IDHoliday = Convert.ToInt32(dt.Rows[0]["IDHoliday"]);
                s.Nama = dt.Rows[0]["Nama"].ToString();
                s.TglMulai = DateTime.Parse(dt.Rows[0]["TglMulai"].ToString());
                s.TglSelesai = DateTime.Parse(dt.Rows[0]["TglSelesai"].ToString());
            }
            return s;
        }

    }
}
