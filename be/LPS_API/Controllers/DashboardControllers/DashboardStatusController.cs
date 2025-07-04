

using LPS_API.Models.DashboardModels;
using LPS_BLL;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace LPS_API.Controllers.DashboardControllers
{
    public class DashboardStatusController : ApiController
    {
        // GET: DashboardStatus
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public DashboardProjectDetails Put([FromBody]DashboardProjectDetails model)
        //{
        //    DashboardData dd = new DashboardData();
        //    List<GetProjectTaskModel> listTask = new List<GetProjectTaskModel>();
        //    List<GetProjectConstraintModel> listConstraint = new List<GetProjectConstraintModel>();

        //    DashboardProjectDetails DashboardProjectDetails = new DashboardProjectDetails();
        //    DashboardProjectDetails.IDProject = model.IDProject;

        //    var ds = dd.DashboardProjectDetails(model.IDProject);
        //    var dtTaskList = ds.Tables[0];
        //    var dtConstraintList = ds.Tables[1];

        //    foreach (DataRow item in dtTaskList.Rows)
        //    {
        //        GetProjectTaskModel _Task = new GetProjectTaskModel();

        //        _Task.TaskName = item["TaskName"].ToString();
        //        _Task.PIC = item["PIC"].ToString();
        //        _Task.Plan = 0;
        //        _Task.Real = 0;

        //        listTask.Add(_Task);
        //    }

        //    DashboardProjectDetails.ListTask = listTask;

        //    foreach (DataRow item in dtConstraintList.Rows)
        //    {
        //        GetProjectConstraintModel _Constraint = new GetProjectConstraintModel();

        //        _Constraint.Constraint = item["Description"].ToString();

        //        listConstraint.Add(_Constraint);
        //    }

        //    /*Please Delete this Example Data if you already get real data */
           

        //    DashboardProjectDetails.ListMilestone = listMilesStone;

        //    var json = JsonConvert.SerializeObject(DashboardProjectDetails);

        //    return DashboardProjectDetails;
        //}
    }
}