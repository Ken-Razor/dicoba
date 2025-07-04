using LPS_API.Models.ReportModels;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.ReportController
{
    public class TrenPencapaianController : ApiController
    {
        public List<TrenPencapaianModel> Post(TrenPencapaianModel data)
        {
            Report r = new Report();

            DataSet ds = r.Get_Report_TrenPencapaian(data.Year, data.Month);
            DataTable dt1 = ds.Tables[0];
            List<TrenPencapaianModel> ListTrenPencapaian = new List<TrenPencapaianModel>();

            foreach(DataRow dr in dt1.Rows)
            {
                TrenPencapaianModel TrenPencapaian = new TrenPencapaianModel();
                
                TrenPencapaian.NoUrut = Convert.ToInt32(dr["NoUrut"]);
                TrenPencapaian.Point = Convert.ToInt32(dr["Point"]);
                TrenPencapaian.Keterangan = dr["Keterangan"].ToString();
                TrenPencapaian.TrenPencapaianTrans = Convert.ToInt32(dr["TrenPencapaianTrans"]);
                TrenPencapaian.TrenPencapaianNonTrans = Convert.ToInt32(dr["TrenPencapaianNonTrans"]);

                ListTrenPencapaian.Add(TrenPencapaian);
            }

            return ListTrenPencapaian;
        }
    }
}
