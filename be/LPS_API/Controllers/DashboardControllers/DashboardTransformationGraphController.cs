using LPS_API.Models.DashboardModels;
using LPS_BLL;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace LPS_API.Controllers.DashboardControllers
{
    public class DashboardTransformationGraphController : ApiController
    {
        // GET: DashboardTransformationGraph
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public List<DashboardTransformationGraph> Get()
        {
            DashboardData dd = new DashboardData();
            List<DashboardTransformationGraph> lDtg = new List<DashboardTransformationGraph>();

            foreach (DataRow dr in dd.DashboardTransformationGraph().Rows)
            {
                DashboardTransformationGraph dt = new DashboardTransformationGraph();
                dt.DepartmentName = dr["Departmentname"].ToString();
                //dt.TotalTransformation = Convert.ToInt32(dr["TotalTransformation"].ToString());
                //dt.TotalNonTransformation = Convert.ToInt32(dr["TotalNonTransformation"].ToString());
                //dt.Averange = Convert.ToDouble(dr["Averange"].ToString());
            }

            return lDtg;
        }
    }
}