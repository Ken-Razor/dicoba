using LPS_API.Models.PJSModels;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.PJSController
{
    public class PJSApprovalController : ApiController
    {

        PJSApproval PJSA = new PJSApproval();

        public List<PJSModel> Get()
        {
            try
            {
                List<PJSModel> ListPJSApproval = new List<PJSModel>();

                foreach (DataRow dr in PJSA.Get_PJSApproval().Rows)
                {
                    PJSModel PJS = new PJSModel();

                    if (dr["ID"].ToString() != "") PJS.ID = Convert.ToInt32(dr["ID"]);

                    PJS.NoUrut = dr["NoUrut"].ToString();
                    PJS.ExistingName = dr["ExistingName"].ToString();
                    PJS.ExistingUsername = dr["ExistingUsername"].ToString();
                    PJS.ExistingPersonalNumber = dr["ExistingPersonalNumber"].ToString();
                    PJS.ExistingPositionCode = dr["ExistingPositionCode"].ToString();

                    PJS.PJSName = dr["PJSName"].ToString();
                    PJS.PJSUsername = dr["PJSUsername"].ToString();
                    PJS.PJSPersonalNumber = dr["PJSPersonalNumber"].ToString();
                    PJS.PJSPositionCode = dr["PJSPositionCode"].ToString();

                    PJS.IDRoleGroup = dr["IDRoleGroup"].ToString();
                    PJS.StartDateString = dr["StartDateString"].ToString();
                    PJS.EndDateString = dr["EndDateString"].ToString();

                    if (dr["CreatedDate"].ToString() != "") PJS.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                    PJS.CreatedBy = dr["CreatedBy"].ToString();
                    if (dr["UpdatedDate"].ToString() != "") PJS.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);
                    PJS.UpdatedDateString = dr["UpdatedDateString"].ToString();
                    PJS.UpdatedBy = dr["UpdatedBy"].ToString();
                    if (dr["IsActive"].ToString() != "") PJS.IsActive = Convert.ToBoolean(dr["IsActive"]);

                    ListPJSApproval.Add(PJS);
                }

                return ListPJSApproval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public PJSModel Post(PJSModel data)
        {
            try
            {
                PJSModel PJSModel = new PJSModel();
                DataTable dt = PJSA.Get_PJSApproval_ByID(data.ID);

                if(dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];

                    if (dr["ID"].ToString() != "") PJSModel.ID = Convert.ToInt32(dr["ID"]);

                    PJSModel.NoUrut = dr["NoUrut"].ToString();
                    PJSModel.ExistingName = dr["ExistingName"].ToString();
                    PJSModel.ExistingUsername = dr["ExistingUsername"].ToString();
                    PJSModel.ExistingPersonalNumber = dr["ExistingPersonalNumber"].ToString();
                    PJSModel.ExistingPositionCode = dr["ExistingPositionCode"].ToString();

                    PJSModel.PJSName = dr["PJSName"].ToString();
                    PJSModel.PJSUsername = dr["PJSUsername"].ToString();
                    PJSModel.PJSPersonalNumber = dr["PJSPersonalNumber"].ToString();
                    PJSModel.PJSPositionCode = dr["PJSPositionCode"].ToString();

                    if (dr["IDRoleGroup"].ToString() != "") PJSModel.IDRoleGroup = dr["IDRoleGroup"].ToString();
                    if (dr["StartDate"].ToString() != "") PJSModel.StartDate = Convert.ToDateTime(dr["StartDate"]);
                    if (dr["EndDate"].ToString() != "") PJSModel.EndDate = Convert.ToDateTime(dr["EndDate"]);
                    PJSModel.Note = dr["Note"].ToString();

                    if (dr["CreatedDate"].ToString() != "") PJSModel.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                    PJSModel.CreatedBy = dr["CreatedBy"].ToString();
                    if (dr["UpdatedDate"].ToString() != "") PJSModel.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);
                    PJSModel.UpdatedDateString = dr["UpdatedDateString"].ToString();
                    PJSModel.UpdatedBy = dr["UpdatedBy"].ToString();
                    if (dr["IsActive"].ToString() != "") PJSModel.IsActive = Convert.ToBoolean(dr["IsActive"]);
                }
                
                return PJSModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
