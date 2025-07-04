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
    public class MasterProjectCostCRUDController : ApiController
    {
        public string Post([FromBody]ProjectCostModel pcm)
        {
            try
            {
                MasterData md = new MasterData();
                string result = "F|Terdapat kesalahan pada API Controller";

                result = md.Insert_MasterProjectCost(pcm.IDProjectCost, pcm.ProjectCostCode, pcm.ProjectCostName, pcm.Description, pcm.CreatedBy, "Insert");

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Put([FromBody]ProjectCostModel pcm)
        {
            try
            {
                MasterData md = new MasterData();
                string result = "F|Terdapat kesalahan pada API Controller";

                result = md.Insert_MasterProjectCost(pcm.IDProjectCost, pcm.ProjectCostCode, pcm.ProjectCostName, pcm.Description, pcm.CreatedBy, "Update");

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Delete(int IDProjectCost)
        {
            try
            {
                MasterData md = new MasterData();
                string result = "F|Terdapat kesalahan pada API Controller";
                ProjectCostModel pcm = new ProjectCostModel();
                pcm.IDProjectCost = IDProjectCost;

                result = md.Insert_MasterProjectCost(pcm.IDProjectCost, pcm.ProjectCostCode, pcm.ProjectCostName, pcm.Description, pcm.CreatedBy, "Delete");

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
