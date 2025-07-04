using LPS_API.Models.MasterDataModels;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers
{
    public class MasterProgramCRUDController : ApiController
    {
        public string Post([FromBody]ProgramModel pm)
        {
            try
            {
                MasterData md = new MasterData();
                string result = "F|Terdapat kesalahan pada API Controller";

                result = md.Insert_MasterProgram(pm.IDProgram, pm.ProgramNo, pm.ProgramName, pm.Description, pm.CreatedBy, "Insert");

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Put([FromBody]ProgramModel pm)
        {
            try
            {
                MasterData md = new MasterData();
                string result = "F|Terdapat kesalahan pada API Controller";

                result = md.Insert_MasterProgram(pm.IDProgram, pm.ProgramNo, pm.ProgramName, pm.Description, pm.CreatedBy, "Update");

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Delete(int IDProgram)
        {
            try
            {
                MasterData md = new MasterData();
                string result = "F|Terdapat kesalahan pada API Controller";
                ProgramModel pm = new ProgramModel();
                pm.IDProgram = IDProgram;

                result = md.Insert_MasterProgram(pm.IDProgram, pm.ProgramNo, pm.ProgramName, pm.Description, pm.CreatedBy, "Delete");

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
