using LPS_API.Helper;
using LPS_API.Models.DashboardModels;
using LPS_BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace LPS_API.Controllers.DashboardControllers
{
    public class DashboardProjectDetailsController : ApiController
    {
        // GET: DashboardProjectDetails
        //public ActionResult Index()
        //{
        //    return View();
        //}


        GlobalFunction GF = new GlobalFunction();

        public DashboardProjectDetails Put([FromBody]DashboardProjectDetails model)
        {
            DashboardData dd = new DashboardData();

            var param = model.IDProject.Split('|');
            var id = param[0].ToString();
            var month = Convert.ToInt32(param[1]);
            var year =  Convert.ToInt32(param[2]);
            var week =  Convert.ToInt32(param[3]);
            DashboardProjectDetails DashboardProjectDetails = new DashboardProjectDetails();
            DashboardProjectDetails.IDProject = id;

            var ds = dd.DashboardProjectDetails(id, month , year , week);
            var dtScurve = ds.Tables[0];
            var dtMilestone = ds.Tables[1];
            var dtStakeHolder = ds.Tables[2];
            var dtConstrain = ds.Tables[3];
            var dtPencapaian = ds.Tables[4];
            var dtAnggaran = ds.Tables[5];
            var dtRealisasi = ds.Tables[6];
            var dtTimeline = ds.Tables[7];
            var dtName = ds.Tables[8];
            var dtProgress = ds.Tables[9];
            var dtType = ds.Tables[10];
            var dtReal = ds.Tables[11];
            var dtTarget = ds.Tables[12];
            
            //DashboardProjectDetails.ListTask = listTask;
            DashboardProjectDetails.ListStackHolder = GF.ConvertTo<GetStackHolderProject>(dtStakeHolder);
            DashboardProjectDetails.ListMilestone = GF.ConvertTo<GetMilestoneProject>(dtMilestone);
            DashboardProjectDetails.ListScurve = GF.ConvertTo<GetScurve>(dtScurve);
            DashboardProjectDetails.ListConstraint = GF.ConvertTo<GetProjectConstraintModel>(dtConstrain);
            DashboardProjectDetails.anggaran = dtAnggaran.Rows[0][0].ToString();
            DashboardProjectDetails.realisasi = dtRealisasi.Rows[0][0].ToString();
            DashboardProjectDetails.pencapaian = dtPencapaian.Rows[0][0].ToString();
            DashboardProjectDetails.Times = GF.ConvertTo<Timeline>(dtTimeline);
            DashboardProjectDetails.nama = dtName.Rows[0][0].ToString();
            DashboardProjectDetails.TypeTransformasi = dtType.Rows[0][0].ToString();
            if (dtType.Rows[0][0].ToString() == "1")
            {
                DashboardProjectDetails.Progress = GF.ConvertTo<GetProgress>(dtProgress);
            } else
            {
                DashboardProjectDetails.ProgressNT = GF.ConvertTo<GetProgressNT>(dtProgress);
            }
            DashboardProjectDetails.ListScurveReal = GF.ConvertTo<GetScurveReal>(dtReal);
            DashboardProjectDetails.ListScurveTarget = GF.ConvertTo<GetScurveTarget>(dtTarget);

            var json = JsonConvert.SerializeObject(DashboardProjectDetails);

            return DashboardProjectDetails;
        }
    }
}