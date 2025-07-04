using LPS_API.Models.DashboardModels;
using LPS_API.Models.MasterDataModels;
using LPS_API.Models.ReportModels;
using LPS_BLL;
using Microsoft.Office.Server.Search.Internal.Protocols.SiteData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.DashboardControllers
{
    public class MasterSlabyParamController : ApiController
    {
        //test
        public List<MasterSLA> Get()
        {
            SLA dd = new SLA();
            DataSet ds = dd.Get_Master_Sla();
            DataTable dt1 = ds.Tables[0];
            List<MasterSLA> resList = new List<MasterSLA>();
            resList = (from DataRow dr in dt1.Rows
                       select new MasterSLA()
                       {
                           NoUrut = Convert.ToInt32(dr["NoUrut"]),
                           Id = int.Parse(dr["Id"].ToString()),
                           GroupId = int.Parse(dr["GroupId"].ToString()),
                           GroupName = dr["GroupName"].ToString(),
                           StatusSLA = dr["StatusSLA"].ToString(),
                           Peraturan = dr["Peraturan"].ToString(),
                           JasaPelayanan = dr["JasaPelayanan"].ToString(),
                           Waktu = dr["Waktu"].ToString(),
                           DihitungDari = dr["DihitungDari"].ToString(),
                           Updateby = dr["UpdateUser"].ToString(),
                           UpdateDate = DateTime.Parse(dr["UpdateDate"].ToString()),
                       }).ToList();
            return resList;
        }
        public List<MasterSLA> Post([FromBody] FilterSLAModel dm)
        {
            try
            {
                SLA md = new SLA();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                List<MasterSLA> resList = new List<MasterSLA>();
                ds = md.Get_MasterSla_ByParam(int.Parse(dm.GroupId), dm.StatusSLA, dm.Peraturan??"");
                dt = ds.Tables[0];
                resList = (from DataRow dr in dt.Rows
                           select new MasterSLA()
                           {
                               NoUrut = Convert.ToInt32(dr["NoUrut"]),
                               Id = int.Parse(dr["Id"].ToString()),
                               GroupId = int.Parse(dr["GroupId"].ToString()),
                               GroupName = dr["GroupName"].ToString(),
                               StatusSLA = dr["StatusSLA"].ToString(),
                               Peraturan = dr["Peraturan"].ToString(),
                               JasaPelayanan = dr["JasaPelayanan"].ToString(),
                               Waktu = dr["Waktu"].ToString(),
                               DihitungDari = dr["DihitungDari"].ToString(),
                               Updateby = dr["UpdateUser"].ToString(),
                               UpdateDate = DateTime.Parse(dr["UpdateDate"].ToString()),
                           }).ToList();

                return resList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
