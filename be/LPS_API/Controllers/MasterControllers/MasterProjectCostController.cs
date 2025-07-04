using LPS_API.Models.MasterDataModels;
using LPS_API.Helper;
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
    public class MasterProjectCostController : ApiController
    {
        GlobalFunction gf = new GlobalFunction();
        public List<ProjectCostModel> Get()
        {
            MasterData md = new MasterData();
            List<ProjectCostModel> ListProjectCost = new List<ProjectCostModel>();

            foreach (DataRow dr in md.Get_MasterProjectCost().Rows)
            {
                ProjectCostModel ProjectCost = new ProjectCostModel();

                if (dr["NoUrut"].ToString() != "") ProjectCost.NoUrut = Convert.ToInt32(dr["NoUrut"]);
                if (dr["IDProjectCost"].ToString() != "") ProjectCost.IDProjectCost = Convert.ToInt32(dr["IDProjectCost"]);
                ProjectCost.ProjectCostCode = dr["ProjectCostCode"].ToString();
                ProjectCost.ProjectCostName = dr["ProjectCostName"].ToString();
                ProjectCost.Description = dr["Description"].ToString();
                ProjectCost.ParentCode = dr["ParentCode"].ToString();
                ProjectCost.Year = dr["Year"].ToString();

                if (dr["Value"].ToString() != "") ProjectCost.Value = gf.ToRupiah(dr["Value"].ToString());
                if (dr["Pergeseran"].ToString() != "") ProjectCost.Pergeseran = gf.ToRupiah(dr["Pergeseran"].ToString());
                if (dr["Hangus"].ToString() != "") ProjectCost.Hangus = gf.ToRupiah(dr["Hangus"].ToString());
                if (dr["Realisasi"].ToString() != "") ProjectCost.Realisasi = gf.ToRupiah(dr["Realisasi"].ToString());
                if(dr["Komitmen"].ToString() != "")ProjectCost.Komitmen = gf.ToRupiah(dr["Komitmen"].ToString());

                if (dr["CreatedDate"].ToString() != "") ProjectCost.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                ProjectCost.CreatedBy = dr["CreatedBy"].ToString();
                if (dr["UpdatedDate"].ToString() != "") ProjectCost.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);
                ProjectCost.UpdatedBy = dr["UpdatedBy"].ToString();
                if (dr["IsActive"].ToString() != "") ProjectCost.IsActive = Convert.ToBoolean(dr["IsActive"]);

                ListProjectCost.Add(ProjectCost);
            }
            return ListProjectCost;
        }

        public ProjectCostModel Post([FromBody]ProjectCostModel pcm)
        {
            try
            {
                MasterData md = new MasterData();
                DataTable dt = new DataTable();
                ProjectCostModel ProjectCost = new ProjectCostModel();

                dt = md.Get_MasterProjectCost_ByID(pcm.IDProjectCost);

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["NoUrut"].ToString() != "") ProjectCost.NoUrut = Convert.ToInt32(dt.Rows[0]["NoUrut"]);
                    if (dt.Rows[0]["IDProjectCost"].ToString() != "") ProjectCost.IDProjectCost = Convert.ToInt32(dt.Rows[0]["IDProjectCost"]);
                    ProjectCost.ProjectCostCode = dt.Rows[0]["ProjectCostCode"].ToString();
                    ProjectCost.ProjectCostName = dt.Rows[0]["ProjectCostName"].ToString();
                    ProjectCost.Description = dt.Rows[0]["Description"].ToString();
                    ProjectCost.ParentCode = dt.Rows[0]["ParentCode"].ToString();
                    ProjectCost.Value = dt.Rows[0]["Value"].ToString();
                    ProjectCost.Realisasi = dt.Rows[0]["Realisasi"].ToString();
                    ProjectCost.CreatedBy = dt.Rows[0]["CreatedBy"].ToString();
                    if (dt.Rows[0]["CreatedDate"].ToString() != "") ProjectCost.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CreatedDate"]);
                    ProjectCost.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                    if (dt.Rows[0]["CreatedDate"].ToString() != "") ProjectCost.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CreatedDate"]);
                    if (dt.Rows[0]["IsActive"].ToString() != "") ProjectCost.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                }

                return ProjectCost;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProjectCostModel> Put([FromBody]ProjectCostModel pcm)
        {
            try
            {
                MasterData md = new MasterData();
                List<ProjectCostModel> ListProjectCost = new List<ProjectCostModel>();

                foreach (DataRow dr in md.Get_MasterProjectCost_ByName(pcm.ProjectCostName).Rows)
                {
                    ProjectCostModel ProjectCost = new ProjectCostModel();

                    if (dr["NoUrut"].ToString() != "") ProjectCost.NoUrut = Convert.ToInt32(dr["NoUrut"]);
                    if (dr["IDProjectCost"].ToString() != "") ProjectCost.IDProjectCost = Convert.ToInt32(dr["IDProjectCost"]);
                    ProjectCost.ProjectCostCode = dr["ProjectCostCode"].ToString();
                    ProjectCost.ProjectCostName = dr["ProjectCostName"].ToString();
                    ProjectCost.Description = dr["Description"].ToString();
                    ProjectCost.ParentCode = dr["ParentCode"].ToString();
                    ProjectCost.Value = dr["Value"].ToString();
                    ProjectCost.Realisasi = dr["Realisasi"].ToString();
                    if (dr["CreatedDate"].ToString() != "") ProjectCost.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                    ProjectCost.CreatedBy = dr["CreatedBy"].ToString();
                    if (dr["UpdatedDate"].ToString() != "") ProjectCost.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);
                    ProjectCost.UpdatedBy = dr["UpdatedBy"].ToString();
                    if (dr["IsActive"].ToString() != "") ProjectCost.IsActive = Convert.ToBoolean(dr["IsActive"]);

                    ListProjectCost.Add(ProjectCost);
                }
                return ListProjectCost;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
