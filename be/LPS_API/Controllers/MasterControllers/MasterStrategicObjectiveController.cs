using LPS_API.Models.MasterDataModels;
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
    public class MasterStrategicObjectiveController : ApiController
    {
        public List<StrategicObjectiveModel> Get()
        {
            MasterData md = new MasterData();
            List<StrategicObjectiveModel> ListStrategicObjective = new List<StrategicObjectiveModel>();

            foreach (DataRow dr in md.Get_MasterStrategicObjective().Rows)
            {
                StrategicObjectiveModel StrategicObjective = new StrategicObjectiveModel();

                if (dr["NoUrut"].ToString() != "") StrategicObjective.NoUrut = Convert.ToInt32(dr["NoUrut"]);
                if (dr["IDStrategicObjective"].ToString() != "") StrategicObjective.IDStrategicObjective = Convert.ToInt32(dr["IDStrategicObjective"]);
                StrategicObjective.StrategicObjectiveCode = dr["StrategicObjectiveCode"].ToString();
                StrategicObjective.StrategicObjectiveName = dr["StrategicObjectiveName"].ToString();
                StrategicObjective.Description = dr["Description"].ToString();
                StrategicObjective.Year = dr["Year"].ToString();
                if (dr["CreatedDate"].ToString() != "") StrategicObjective.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                StrategicObjective.CreatedBy = dr["CreatedBy"].ToString();
                if (dr["UpdatedDate"].ToString() != "") StrategicObjective.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);
                StrategicObjective.UpdatedBy = dr["UpdatedBy"].ToString();
                if (dr["IsActive"].ToString() != "") StrategicObjective.IsActive = Convert.ToBoolean(dr["IsActive"]);

                ListStrategicObjective.Add(StrategicObjective);
            }
            return ListStrategicObjective;
        }

        public StrategicObjectiveModel Post([FromBody]StrategicObjectiveModel som)
        {
            try
            {
                MasterData md = new MasterData();
                DataTable dt = new DataTable();
                StrategicObjectiveModel StrategicObjective = new StrategicObjectiveModel();

                dt = md.Get_MasterStrategicObjective_ByID(som.IDStrategicObjective);

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["NoUrut"].ToString() != "") StrategicObjective.NoUrut = Convert.ToInt32(dt.Rows[0]["NoUrut"]);
                    if (dt.Rows[0]["IDStrategicObjective"].ToString() != "") StrategicObjective.IDStrategicObjective = Convert.ToInt32(dt.Rows[0]["IDStrategicObjective"]);
                    StrategicObjective.StrategicObjectiveCode = dt.Rows[0]["StrategicObjectiveCode"].ToString();
                    StrategicObjective.StrategicObjectiveName = dt.Rows[0]["StrategicObjectiveName"].ToString();
                    StrategicObjective.Description = dt.Rows[0]["Description"].ToString();
                    StrategicObjective.Year = dt.Rows[0]["Year"].ToString();
                    StrategicObjective.CreatedBy = dt.Rows[0]["CreatedBy"].ToString();
                    if (dt.Rows[0]["CreatedDate"].ToString() != "") StrategicObjective.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CreatedDate"]);
                    StrategicObjective.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                    if (dt.Rows[0]["CreatedDate"].ToString() != "") StrategicObjective.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CreatedDate"]);
                    if (dt.Rows[0]["IsActive"].ToString() != "") StrategicObjective.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                }
                
                return StrategicObjective;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
