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
    public class MasterSlaController : ApiController
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
        public MasterSLA Post([FromBody] MasterSLA dm)
        {
            try
            {
                SLA md = new SLA();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                MasterSLA s = new MasterSLA();
                List<StatusSLAModel> ListStatus = new List<StatusSLAModel>();
                List<GroupModel> ListGroup = new List<GroupModel>();

                ds = md.Get_MasterSla_ByID(dm.Id);
                dt = ds.Tables[0];
                dt1 = ds.Tables[1];

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["NoUrut"].ToString() != "") s.NoUrut = Convert.ToInt32(dt.Rows[0]["NoUrut"]);
                    if (dt.Rows[0]["Id"].ToString() != "") s.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    if (dt.Rows[0]["GroupId"].ToString() != "") s.GroupId = Convert.ToInt32(dt.Rows[0]["GroupId"]);
                    s.StatusSLA = dt.Rows[0]["StatusSLA"].ToString();
                    s.Peraturan = dt.Rows[0]["Peraturan"].ToString();
                    s.JasaPelayanan = dt.Rows[0]["JasaPelayanan"].ToString();
                    s.Waktu = dt.Rows[0]["Waktu"].ToString();
                    s.DihitungDari = dt.Rows[0]["DihitungDari"].ToString();
                }
                ListStatus.Add(new StatusSLAModel { IdStatus = "Berlaku", Description = "Berlaku" });
                ListStatus.Add(new StatusSLAModel { IdStatus = "Tidak Berlaku", Description = "Tidak Berlaku" });

                foreach (DataRow data in dt1.Rows)
                {
                    GroupModel g = new GroupModel();
                    if (data["Id"].ToString() != "") g.Id = Convert.ToInt32(data["Id"]);
                    g.Description = data["Description"].ToString();
                    ListGroup.Add(g);
                }

                s.ListStatus = ListStatus;
                s.ListGroup = ListGroup;
                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
