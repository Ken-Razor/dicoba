using LPS_ProjectManagement.Models.DashboardModels;
using LPS_ProjectManagement.Models.DashboardModels.DashboardProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models
{
    public class BerandaInitModel
    {
        public DashboardProjectHeaderModel DashboardProjectHeader;
        public List<DropDownMonth> ListMonth;
        public DashboardProjectModel DashboardProject;
        public List<DashboardProjectProgressModel> DashboardProjectProgress;
        public List<DashboardProjectProgressPerProjectModel> DashboardProjectProgressPerProject;
        public List<DashboardTransAndNoTransModel> DashboardTransAndNoTrans;
        public List<DashboardProjectOverallModel> DashboardProjectOverall;
        public List<DashboardProjectTimeSeriesModel> DashboardProjectTimeSeriesTransformasi;
        public List<DashboardProjectTimeSeriesModel> DashboardProjectTimeSeriesNonTransformasi;
    }
}