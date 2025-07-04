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
    public class MasterDirektoratController : ApiController
    {
        public List<DirektoratModel> Get()
        {
            try
            {
                MasterData md = new MasterData();
                List<DirektoratModel> ListDirektorat = new List<DirektoratModel>();

                foreach (DataRow dr in md.Get_MasterDirektorat().Rows)
                {
                    DirektoratModel Direktorat = new DirektoratModel();

                    if (dr["IDDirektorat"].ToString() != "")Direktorat.IDDirektorat = Convert.ToInt32(dr["IDDirektorat"]);

                    Direktorat.DirektoratCode = dr["DirektoratCode"].ToString();
                    Direktorat.DirektoratName = dr["DirektoratName"].ToString();
                    Direktorat.Description = dr["Description"].ToString();

                    ListDirektorat.Add(Direktorat);
                }
                return ListDirektorat;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
