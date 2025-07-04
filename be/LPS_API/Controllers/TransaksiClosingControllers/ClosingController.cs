using LPS_API.Helper;
using LPS_API.Models.TransaksiClosingModels;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.TransaksiClosingControllers
{
    public class ClosingController : ApiController
    {
        public List<ClosingProjectHeaderModel> Post([FromBody]ClosingProjectHeaderModel ph)
        {
            TransaksiClosing tc = new TransaksiClosing();
            List<ClosingProjectHeaderModel> ListClosingProjectHeader = new List<ClosingProjectHeaderModel>();

            foreach (DataRow dr in tc.Get_TransaksiClosingProjectHeader(ph.CreatedBy).Rows)
            {
                ClosingProjectHeaderModel ClosingProjectHeader = new ClosingProjectHeaderModel();

                if (dr["IDProject"].ToString() != "") ClosingProjectHeader.IDProject = Convert.ToInt32(dr["IDProject"]);
                ClosingProjectHeader.ProjectNo = dr["ProjectNo"].ToString();
                ClosingProjectHeader.ProjectName = dr["ProjectName"].ToString();
                ClosingProjectHeader.StatusName = dr["StatusName"].ToString();
                if (dr["NoUrut"].ToString() != "") ClosingProjectHeader.NoUrut = Convert.ToInt32(dr["NoUrut"]);
                if (dr["IDProjectHeader"].ToString() != "") ClosingProjectHeader.IDProjectHeader = Convert.ToInt32(dr["IDProjectHeader"]);
                if (dr["Sequence"].ToString() != "") ClosingProjectHeader.Sequence = Convert.ToInt32(dr["Sequence"]);
                if (dr["IDProjectStatus"].ToString() != "") ClosingProjectHeader.IDProjectStatus = Convert.ToInt32(dr["IDProjectStatus"]);
                ClosingProjectHeader.StartYear = dr["StartYear"].ToString();
                if (dr["StartMonth"].ToString() != "") ClosingProjectHeader.StartMonth = Convert.ToInt32(dr["StartMonth"]);
                ClosingProjectHeader.EndYear = dr["EndYear"].ToString();
                if (dr["EndMonth"].ToString() != "") ClosingProjectHeader.EndMonth = Convert.ToInt32(dr["EndMonth"]);
                ClosingProjectHeader.NoKontrak = dr["NoKontrak"].ToString();
                if (dr["ContractStartDate"].ToString() != "") ClosingProjectHeader.ContractStartDate = Convert.ToDateTime(dr["ContractStartDate"]);
                if (dr["ContractEndDate"].ToString() != "") ClosingProjectHeader.ContractEndDate = Convert.ToDateTime(dr["ContractEndDate"]);
                if (dr["ContractIDR"].ToString() != "") ClosingProjectHeader.ContractIDR = Convert.ToDouble(dr["ContractIDR"]);
                if (dr["ContractUSD"].ToString() != "") ClosingProjectHeader.ContractUSD = Convert.ToDouble(dr["ContractUSD"]);
                if (dr["WeightKPI"].ToString() != "") ClosingProjectHeader.WeightKPI = Convert.ToDouble(dr["WeightKPI"]);
                ClosingProjectHeader.UpdatedDateString = dr["UpdatedDateString"].ToString();
                if (dr["CreatedDate"].ToString() != "") ClosingProjectHeader.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                ClosingProjectHeader.CreatedBy = dr["CreatedBy"].ToString();
                if (dr["UpdatedDate"].ToString() != "") ClosingProjectHeader.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);
                ClosingProjectHeader.UpdatedBy = dr["UpdatedBy"].ToString();
                if (dr["IsActive"].ToString() != "") ClosingProjectHeader.IsActive = Convert.ToBoolean(dr["IsActive"]);
                if (dr["IsTransformasi"].ToString() != "") ClosingProjectHeader.IsTransformasi = Convert.ToBoolean(dr["IsTransformasi"]);

                ListClosingProjectHeader.Add(ClosingProjectHeader);
            }
            return ListClosingProjectHeader;
        }

        public ClosingProjectDetailModel Put([FromBody]int IDProjectHeader)
        {
            try
            {

                ClosingProjectDetailModel cpdm = new ClosingProjectDetailModel();
                TransaksiClosing tc = new TransaksiClosing();

                DataSet ds = tc.Get_TransaksiClosingProjectHeader_ByID(IDProjectHeader);

                DataTable dt = ds.Tables[0];
                DataTable dt2 = ds.Tables[1];


                GlobalFunction GF = new GlobalFunction();


                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["IDProjectHeader"].ToString() != "") cpdm.IDProjectHeader = Convert.ToInt32(dt.Rows[0]["IDProjectHeader"]);
                    if (dt.Rows[0]["IDProjectClosing"].ToString() != "") cpdm.IDProjectClosing = Convert.ToInt32(dt.Rows[0]["IDProjectClosing"]);

                    if (dt.Rows[0]["UpdatedDate"].ToString() != "") cpdm.UpdatedDate = Convert.ToDateTime(dt.Rows[0]["UpdatedDate"]);
                    if (dt.Rows[0]["CreatedDate"].ToString() != "") cpdm.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CreatedDate"]);

                    cpdm.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                    cpdm.CreatedBy = dt.Rows[0]["CreatedBy"].ToString();

                    if (dt.Rows[0]["IsActive"].ToString() != "") cpdm.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                    if (dt.Rows[0]["ClosingDate"].ToString() != "") cpdm.ClosingDate = Convert.ToDateTime(dt.Rows[0]["ClosingDate"]);
                    cpdm.ProjectName = dt.Rows[0]["ProjectName"].ToString();
                    cpdm.Remarks = dt.Rows[0]["Remarks"].ToString().Replace('{', '<').Replace('}', '>');
                    cpdm.StatusName = dt.Rows[0]["StatusName"].ToString();
                    cpdm.WhatCanBeImproved = dt.Rows[0]["WhatCanBeImproved"].ToString().Replace('{', '<').Replace('}', '>');
                    cpdm.WhatDidNotWorkWell = dt.Rows[0]["WhatDidNotWorkWell"].ToString().Replace('{', '<').Replace('}', '>');
                    cpdm.WhatWorkWell = dt.Rows[0]["WhatWorkWell"].ToString().Replace('{', '<').Replace('}', '>');
                }

                cpdm.Document = GF.ConvertTo<GlobalDocumentModel>(dt2);
                return cpdm;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
