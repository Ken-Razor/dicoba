using LPS_API.Models.MasterDataModels;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace LPS_API.Controllers.MasterControllers
{
    public class MasterKategoriProjectCRUDController : ApiController
    {
        public string Post([FromBody]ProjectKategoriModel pkm)
        {
            try
            {
                MasterData md = new MasterData();
                string result = "F|Terdapat kesalahan pada API Controller";

                result = md.Insert_MasterKategoriProject(pkm.IDKategoriProject, pkm.KategoriName, pkm.Description, pkm.CreatedBy, "Insert");

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Put([FromBody]ProjectKategoriModel pkm)
        {
            try
            {
                MasterData md = new MasterData();
                string result = "F|Terdapat kesalahan pada API Controller";

                result = md.Insert_MasterKategoriProject(pkm.IDKategoriProject, pkm.KategoriName, pkm.Description, pkm.CreatedBy, "Update");

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Delete(int IDKategoriProject )
        {
            try
            {
                MasterData md = new MasterData();
                string result = "F|Terdapat kesalahan pada API Controller";
                ProjectKategoriModel pkm = new ProjectKategoriModel();
                pkm.IDKategoriProject = IDKategoriProject;

                result = md.Insert_MasterKategoriProject(pkm.IDKategoriProject, pkm.KategoriName, pkm.Description, pkm.CreatedBy, "Delete");

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}