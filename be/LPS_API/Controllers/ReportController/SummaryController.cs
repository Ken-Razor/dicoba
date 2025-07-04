using LPS_API.Models.ReportModels;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.ReportController
{
    public class SummaryController : ApiController
    {
        public List<SummaryModel> Post([FromBody]SummaryModel sm)
        {
            Report r = new Report();
            List<SummaryModel> ListSummary = new List<SummaryModel>();

            foreach (DataRow dr in r.Get_Report_Summary(sm.Month, sm.Year).Rows)
            {
                SummaryModel Summary = new SummaryModel();

                if (dr["IDStrategicObjective"].ToString() != "") Summary.IDStrategicObjective = Convert.ToInt32(dr["IDStrategicObjective"]);
                Summary.StrategicObjectiveName = dr["StrategicObjectiveName"].ToString();
                if (dr["JumlahProject"].ToString() != "") Summary.JumlahProject = Convert.ToInt32(dr["JumlahProject"]);

                if (dr["DiatasTarget_T"].ToString() != "") Summary.DiatasTarget_T = Convert.ToInt32(dr["DiatasTarget_T"]);
                if (dr["SesuaiTarget_T"].ToString() != "") Summary.SesuaiTarget_T = Convert.ToInt32(dr["SesuaiTarget_T"]);
                if (dr["DibawahTarget_T"].ToString() != "") Summary.DibawahTarget_T = Convert.ToInt32(dr["DibawahTarget_T"]);
                if (dr["JauhDibawahTarget_T"].ToString() != "") Summary.JauhDibawahTarget_T = Convert.ToInt32(dr["JauhDibawahTarget_T"]);
                if (dr["BelumDimulai_T"].ToString() != "") Summary.BelumDimulai_T = Convert.ToInt32(dr["BelumDimulai_T"]);
                if (dr["Selesai_T"].ToString() != "") Summary.Selesai_T = Convert.ToInt32(dr["Selesai_T"]);

                if (dr["DiatasTarget_NT"].ToString() != "") Summary.DiatasTarget_NT = Convert.ToInt32(dr["DiatasTarget_NT"]);
                if (dr["SesuaiTarget_NT"].ToString() != "") Summary.SesuaiTarget_NT = Convert.ToInt32(dr["SesuaiTarget_NT"]);
                if (dr["DibawahTarget_NT"].ToString() != "") Summary.DibawahTarget_NT = Convert.ToInt32(dr["DibawahTarget_NT"]);
                if (dr["JauhDibawahTarget_NT"].ToString() != "") Summary.JauhDibawahTarget_NT = Convert.ToInt32(dr["JauhDibawahTarget_NT"]);
                if (dr["BelumDimulai_NT"].ToString() != "") Summary.BelumDimulai_NT = Convert.ToInt32(dr["BelumDimulai_NT"]);
                if (dr["Selesai_NT"].ToString() != "") Summary.Selesai_NT = Convert.ToInt32(dr["Selesai_NT"]);

                ListSummary.Add(Summary);
            }
            return ListSummary;
        }

    }
}
