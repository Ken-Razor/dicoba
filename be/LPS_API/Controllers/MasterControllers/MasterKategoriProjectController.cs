using LPS_API.Models.MasterDataModels;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.MasterControllers
{
    public class MasterKategoriProjectController : ApiController
    {
        public List<ProjectKategoriModel> Get()
        {
            MasterData md = new MasterData();
            List<ProjectKategoriModel> ListKategoriModel = new List<ProjectKategoriModel>();

            foreach (DataRow dr in md.Get_MasterKategoriProject().Rows)
            {
                ProjectKategoriModel KategoriModel = new ProjectKategoriModel();

                if (dr["NoUrut"].ToString() != "") KategoriModel.NoUrut = Convert.ToInt32(dr["NoUrut"]);
                if (dr["IDKategoriProject"].ToString() != "") KategoriModel.IDKategoriProject = Convert.ToInt32(dr["IDKategoriProject"]);
                KategoriModel.KategoriName = dr["KategoriName"].ToString();
                KategoriModel.Description = dr["Description"].ToString();
                if (dr["CreatedDate"].ToString() != "") KategoriModel.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                KategoriModel.CreatedBy = dr["CreatedBy"].ToString();
                if (dr["UpdatedDate"].ToString() != "") KategoriModel.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);
                KategoriModel.UpdatedDateString = dr["UpdatedDateString"].ToString();
                KategoriModel.UpdatedBy = dr["UpdatedBy"].ToString();
                if (dr["IsActive"].ToString() != "") KategoriModel.IsActive = Convert.ToBoolean(dr["IsActive"]);

                ListKategoriModel.Add(KategoriModel);
            }
            return ListKategoriModel;

        }

        public ProjectKategoriModel Post([FromBody] ProjectKategoriModel pkm)
        {
            try
            {
                MasterData md = new MasterData();
                DataTable dt = new DataTable();
                ProjectKategoriModel KategoriModel = new ProjectKategoriModel();

                dt = md.Get_MasterKategoriProject_ByID(pkm.IDKategoriProject);

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["NoUrut"].ToString() != "") KategoriModel.NoUrut = Convert.ToInt32(dt.Rows[0]["NoUrut"]);
                    if (dt.Rows[0]["IDKategoriProject"].ToString() != "") KategoriModel.IDKategoriProject = Convert.ToInt32(dt.Rows[0]["IDKategoriProject"]);
                    KategoriModel.KategoriName = dt.Rows[0]["KategoriName"].ToString();
                    KategoriModel.Description = dt.Rows[0]["Description"].ToString();
                    if (dt.Rows[0]["IsActive"].ToString() != "") KategoriModel.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                    if (dt.Rows[0]["CreatedDate"].ToString() != "") KategoriModel.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CreatedDate"]);
                    KategoriModel.CreatedBy = dt.Rows[0]["CreatedBy"].ToString();
                    if (dt.Rows[0]["UpdatedDate"].ToString() != "") KategoriModel.UpdatedDate = Convert.ToDateTime(dt.Rows[0]["UpdatedDate"]);
                    KategoriModel.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                }

                return KategoriModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}