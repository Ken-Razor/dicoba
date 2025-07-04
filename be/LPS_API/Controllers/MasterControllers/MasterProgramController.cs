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
    public class MasterProgramController : ApiController
    {
        public List<ProgramModel> Get()
        {
            MasterData md = new MasterData();
            List<ProgramModel> ListProgramModel = new List<ProgramModel>();

            foreach (DataRow dr in md.Get_MasterProgram().Rows)
            {
                ProgramModel ProgramModel = new ProgramModel();

                if(dr["NoUrut"].ToString()!="") ProgramModel.NoUrut = Convert.ToInt32(dr["NoUrut"]);
                if (dr["IDProgram"].ToString() != "") ProgramModel.IDProgram = Convert.ToInt32(dr["IDProgram"]);
                ProgramModel.ProgramNo = dr["ProgramNo"].ToString();
                ProgramModel.ProgramName = dr["ProgramName"].ToString();
                ProgramModel.Description = dr["Description"].ToString();
                if (dr["CreatedDate"].ToString() != "") ProgramModel.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                ProgramModel.CreatedBy = dr["CreatedBy"].ToString();
                if (dr["UpdatedDate"].ToString() != "") ProgramModel.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);
                ProgramModel.UpdatedDateString = dr["UpdatedDateString"].ToString();
                ProgramModel.UpdatedBy = dr["UpdatedBy"].ToString();
                if (dr["IsActive"].ToString() != "") ProgramModel.IsActive = Convert.ToBoolean(dr["IsActive"]);

                ListProgramModel.Add(ProgramModel);
            }
            return ListProgramModel;
        }

        public ProgramModel Post([FromBody]ProgramModel pm)
        {
            try
            {
                MasterData md = new MasterData();
                DataTable dt = new DataTable();
                ProgramModel ProgramModel = new ProgramModel();

                dt = md.Get_MasterProgram_ByID(pm.IDProgram);

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["NoUrut"].ToString() != "") ProgramModel.NoUrut = Convert.ToInt32(dt.Rows[0]["NoUrut"]);
                    if (dt.Rows[0]["IDProgram"].ToString() != "") ProgramModel.IDProgram = Convert.ToInt32(dt.Rows[0]["IDProgram"]);
                    ProgramModel.ProgramNo = dt.Rows[0]["ProgramNo"].ToString();
                    ProgramModel.ProgramName = dt.Rows[0]["ProgramName"].ToString();
                    ProgramModel.Description = dt.Rows[0]["Description"].ToString();
                    ProgramModel.CreatedBy = dt.Rows[0]["CreatedBy"].ToString();
                    if (dt.Rows[0]["CreatedDate"].ToString() != "") ProgramModel.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CreatedDate"]);
                    ProgramModel.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                    if (dt.Rows[0]["CreatedDate"].ToString() != "") ProgramModel.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CreatedDate"]);
                    if (dt.Rows[0]["IsActive"].ToString() != "") ProgramModel.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                }

                return ProgramModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
