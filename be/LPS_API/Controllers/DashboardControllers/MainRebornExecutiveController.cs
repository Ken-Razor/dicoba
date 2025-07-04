using LPS_API.Models.DashboardModels;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.DashboardControllers
{
    public class MainRebornExecutiveController : ApiController
    {
        public MainRibbonExecutiveModel Get()
        {
            MainRibbonExecutiveModel mre = new MainRibbonExecutiveModel();
            DashboardData dd = new DashboardData();
            DataSet ds = new DataSet();
            DataTable dt0 = new DataTable();

            ds = dd.DashboardMainRibbonExcecutive();
            dt0 = ds.Tables[0];

            double AllProject = Convert.ToInt32(dt0.Rows[0]["Transformation"]) + Convert.ToInt32(dt0.Rows[0]["NonTransformation"]);

            mre.Transformation = dt0.Rows[0]["Transformation"].ToString();
            mre.TransformationPercentage = (Convert.ToInt32(dt0.Rows[0]["Transformation"])*100/AllProject).ToString().Substring(0, 4);
            mre.NonTransformation = dt0.Rows[0]["NonTransformation"].ToString();
            mre.NonTransformationPercentage = (Convert.ToInt32(dt0.Rows[0]["NonTransformation"]) * 100 / AllProject).ToString().Substring(0, 4);
            mre.ProgressTransfomation = dt0.Rows[0]["ProgressTransfomation"].ToString();
            mre.ProgressNonTransformation = dt0.Rows[0]["ProgressNonTransformation"].ToString();
            mre.LastUpdated = dt0.Rows[0]["LastUpdated"].ToString();
            if (dt0.Rows[0]["CostTransformation"].ToString() != "") mre.CostTransformation = (Convert.ToDouble(dt0.Rows[0]["CostTransformation"]) / 1000000000).ToString().Substring(0,4);
            if (dt0.Rows[0]["CostNonTransformation"].ToString()!="") mre.CostNonTransformation = (Convert.ToDouble(dt0.Rows[0]["CostNonTransformation"]) / 1000000000).ToString().Substring(0, 4);

            return mre;
        }
    }
}
