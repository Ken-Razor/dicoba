using LPS_API.Helper;
using LPS_API.Models.ReportModels;
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
    public class SummaryPenyampaianController : ApiController
    {
        public List<SummaryPenyampaianModel> Post([FromBody]SummaryPenyampaianModel spm)
        {
            Report r = new Report();
            List<SummaryPenyampaianModel> ListSummaryPenyampaian  = new List<SummaryPenyampaianModel>();

            foreach (DataRow dr in r.Get_ReportSummaryPenyampaian().Rows)
            {
                SummaryPenyampaianModel SummaryPenyampaian = new SummaryPenyampaianModel();

                SummaryPenyampaian.Direktorat = dr["Direktorat"].ToString();
                SummaryPenyampaian.DraftProjAdmin = dr["DraftProjAdmin"].ToString();
                SummaryPenyampaian.SubmitProjAdmin = dr["SubmitProjAdmin"].ToString();
                SummaryPenyampaian.ApproveProjManager = dr["ApproveProjManager"].ToString();
                SummaryPenyampaian.ApproveProgManager = dr["ApproveProgManager"].ToString();

                ListSummaryPenyampaian.Add(SummaryPenyampaian);
            }
            return ListSummaryPenyampaian;
        }
    }
}
