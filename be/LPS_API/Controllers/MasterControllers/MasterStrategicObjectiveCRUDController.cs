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
    public class MasterStrategicObjectiveCRUDController : ApiController
    {
        public string Post([FromBody]StrategicObjectiveModel som)
        {
            try
            {
                MasterData md = new MasterData();
                string result = "F|Terdapat kesalahan pada API Controller";

                result = md.Insert_MasterStrategicObjective(som.IDStrategicObjective, som.StrategicObjectiveCode, som.StrategicObjectiveName, som.Description, som.CreatedBy, "Insert");

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Put([FromBody]StrategicObjectiveModel som)
        {
            try
            {
                MasterData md = new MasterData();
                string result = "F|Terdapat kesalahan pada API Controller";

                result = md.Insert_MasterStrategicObjective(som.IDStrategicObjective, som.StrategicObjectiveCode, som.StrategicObjectiveName, som.Description, som.CreatedBy, "Update");

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Delete(int IDStrategicObjective)
        {
            try
            {
                MasterData md = new MasterData();
                string result = "F|Terdapat kesalahan pada API Controller";
                StrategicObjectiveModel som = new StrategicObjectiveModel();
                som.IDStrategicObjective = IDStrategicObjective;

                result = md.Insert_MasterStrategicObjective(som.IDStrategicObjective, som.StrategicObjectiveCode, som.StrategicObjectiveName, som.Description, som.CreatedBy, "Delete");

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
