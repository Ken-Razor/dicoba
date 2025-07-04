using LPS_API.Helper;
using LPS_API.Models.SAPModels;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.SAPControllers
{
    public class SAPRKATController : ApiController
    {
        GlobalFunction gf = new GlobalFunction();
        public List<RKATModel> Post([FromBody]RKATModel rkatm)
        {
            MasterData md = new MasterData();
            List<RKATModel> ListRKaT = new List<RKATModel>();

            foreach (DataRow dr in md.Get_SAPRKAT_ByDESCRIPTION(rkatm.DESCRIPTION).Rows)
            {
                RKATModel RKAT = new RKATModel();

                if (dr["NoUrut"].ToString() != "") RKAT.NoUrut = Convert.ToInt32(dr["NoUrut"]);
                if (dr["IDSAPRKAT"].ToString() != "") RKAT.IDSAPRKAT = Convert.ToInt32(dr["IDSAPRKAT"]);
                RKAT.IDSAP = dr["IDSAP"].ToString();
                RKAT.ACTIVE = dr["ACTIVE"].ToString();
                RKAT.COSTCTR = dr["COSTCTR"].ToString();
                RKAT.KPI = dr["KPI"].ToString();
                RKAT.LEVEL = dr["LEVEL"].ToString();
                RKAT.SCALING = dr["SCALING"].ToString();
                RKAT.STRAT_OBJ = dr["STRAT_OBJ"].ToString();
                RKAT.WORKPLAN_TYPE = dr["WORKPLAN_TYPE"].ToString();
                RKAT.YEAR = dr["YEAR"].ToString();
                RKAT.PARENT = dr["PARENT"].ToString();
                RKAT.DESCRIPTION = dr["DESCRIPTION"].ToString();
                RKAT.LONG_DESC = dr["LONG_DESC"].ToString();
                RKAT.EVDESCRIPTION = dr["EVDESCRIPTION"].ToString();
                RKAT.KPI_GROUP = dr["KPI_GROUP"].ToString();
                RKAT.PRO_GROUP = dr["PRO_GROUP"].ToString();
                RKAT.UNCONTROLLABLE = dr["UNCONTROLLABLE"].ToString();
                RKAT.Value = gf.ToRupiah(dr["Value"].ToString());

                ListRKaT.Add(RKAT);
            }
            return ListRKaT;
        }
    }
}
