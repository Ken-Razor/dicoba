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
    public class MasterKPIOrganizationController : ApiController
    {
        public List<KPIOrganizationModel> Get()
        {
            MasterData md = new MasterData();
            List<KPIOrganizationModel> ListKPIOrganization = new List<KPIOrganizationModel>();

            foreach (DataRow dr in md.Get_MasterKPIOrganization().Rows)
            {
                KPIOrganizationModel KPIOrganization = new KPIOrganizationModel();

                if (dr["NoUrut"].ToString() != "") KPIOrganization.NoUrut = Convert.ToInt32(dr["NoUrut"]);
                if (dr["IDKPIOrganization"].ToString() != "") KPIOrganization.IDKPIOrganization = Convert.ToInt32(dr["IDKPIOrganization"]);
                KPIOrganization.KPICode = dr["KPICode"].ToString();
                KPIOrganization.KPIName = dr["KPIName"].ToString();
                KPIOrganization.Year = dr["Year"].ToString();
                KPIOrganization.Description = dr["Description"].ToString();
                if (dr["CreatedDate"].ToString() != "") KPIOrganization.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                KPIOrganization.CreatedBy = dr["CreatedBy"].ToString();
                if (dr["UpdatedDate"].ToString() != "") KPIOrganization.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);
                KPIOrganization.UpdatedBy = dr["UpdatedBy"].ToString();
                if (dr["IsActive"].ToString() != "") KPIOrganization.IsActive = Convert.ToBoolean(dr["IsActive"]);

                ListKPIOrganization.Add(KPIOrganization);
            }
            return ListKPIOrganization;
        }

        public KPIOrganizationModel Post([FromBody]KPIOrganizationModel kpiom)
        {
            try
            {
                MasterData md = new MasterData();
                DataTable dt = new DataTable();
                KPIOrganizationModel KPIOrganization = new KPIOrganizationModel();

                dt = md.Get_MasterKPIOrganization_ByID(kpiom.IDKPIOrganization);

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["NoUrut"].ToString() != "") KPIOrganization.NoUrut = Convert.ToInt32(dt.Rows[0]["NoUrut"]);
                    if (dt.Rows[0]["IDKPIOrganization"].ToString() != "") KPIOrganization.IDKPIOrganization = Convert.ToInt32(dt.Rows[0]["IDKPIOrganization"]);
                    KPIOrganization.KPICode = dt.Rows[0]["KPICode"].ToString();
                    KPIOrganization.KPIName = dt.Rows[0]["KPIName"].ToString();
                    KPIOrganization.Year = dt.Rows[0]["Year"].ToString();
                    KPIOrganization.Description = dt.Rows[0]["Description"].ToString();
                    KPIOrganization.CreatedBy = dt.Rows[0]["CreatedBy"].ToString();
                    if (dt.Rows[0]["CreatedDate"].ToString() != "") KPIOrganization.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CreatedDate"]);
                    KPIOrganization.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                    if (dt.Rows[0]["CreatedDate"].ToString() != "") KPIOrganization.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CreatedDate"]);
                    if (dt.Rows[0]["IsActive"].ToString() != "") KPIOrganization.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                }

                return KPIOrganization;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<KPIOrganizationModel> Put([FromBody]KPIOrganizationModel kpiom)
        {
            try
            {
                MasterData md = new MasterData();
                DataTable dt = new DataTable();
                List<KPIOrganizationModel> ListKPIOrganization = new List<KPIOrganizationModel>();

                dt = md.Get_MasterKPIOrganization_ByKPIName(kpiom.KPIName);

                foreach (DataRow dr in dt.Rows)
                {
                    KPIOrganizationModel KPIOrganization = new KPIOrganizationModel();

                    if (dr["NoUrut"].ToString() != "") KPIOrganization.NoUrut = Convert.ToInt32(dr["NoUrut"]);
                    if (dr["IDKPIOrganization"].ToString() != "") KPIOrganization.IDKPIOrganization = Convert.ToInt32(dr["IDKPIOrganization"]);
                    KPIOrganization.KPICode = dr["KPICode"].ToString();
                    KPIOrganization.KPIName = dr["KPIName"].ToString();
                    KPIOrganization.Year = dr["Year"].ToString();
                    KPIOrganization.Description = dr["Description"].ToString();
                    KPIOrganization.CreatedBy = dr["CreatedBy"].ToString();
                    if (dr["CreatedDate"].ToString() != "") KPIOrganization.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                    KPIOrganization.UpdatedBy = dr["UpdatedBy"].ToString();
                    if (dr["CreatedDate"].ToString() != "") KPIOrganization.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                    if (dr["IsActive"].ToString() != "") KPIOrganization.IsActive = Convert.ToBoolean(dr["IsActive"]);

                    ListKPIOrganization.Add(KPIOrganization);
                }

                return ListKPIOrganization;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
