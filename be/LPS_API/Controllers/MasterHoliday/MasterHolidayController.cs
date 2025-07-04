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
    public class MasterHolidayController : ApiController
    {
        //test
        public List<MasterHoliday> Get(int tahun)
        {
            Holiday dd = new Holiday();
            DataSet ds = dd.Get_Master_Holiday(tahun);
            DataTable dt1 = ds.Tables[0];
            List<MasterHoliday> resList = new List<MasterHoliday>();
            resList = (from DataRow dr in dt1.Rows
                       select new MasterHoliday()
                       {
                           IDHoliday = Convert.ToInt32(dr["IDHoliday"]),
                           Nama = dr["Nama"].ToString(),
                           TglMulai = DateTime.Parse(dr["TglMulai"].ToString()),
                           TglSelesai = DateTime.Parse(dr["TglSelesai"].ToString()),
                           //CreatedBy = dr["CreatedBy"].ToString(),
                           //CreatedDate = DateTime.Parse(dr["CreatedDate"].ToString()),
                           //UpdatedBy = dr["UpdatedBy"].ToString(),
                           //UpdatedDate = DateTime.Parse(dr["UpdatedDate"].ToString()),
                       }).ToList();
            return resList;
        }
        public List<ddlYear> Post()
        {
            try
            {
                Holiday md = new Holiday();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                List<ddlYear> ListTahun = new List<ddlYear>();

                ds = md.Get_Holiday_tahun();
                dt = ds.Tables[0];

                foreach (DataRow data in dt.Rows)
                {
                    ddlYear g = new ddlYear();
                    g.id = int.Parse(data["tahun"].ToString());
                    g.Description = data["tahun"].ToString();
                    ListTahun.Add(g);
                }
                return ListTahun;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
