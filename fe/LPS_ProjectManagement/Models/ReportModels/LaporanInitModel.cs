using LPS_ProjectManagement.Models.DashboardModels.DashboardProject;
using LPS_ProjectManagement.Models.MasterDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace LPS_ProjectManagement.Models.ReportModels
{
    public class LaporanInitModel
    {
        public DashboardProjectHeaderModel DashboardProjectHeaderModel;
        public List<DropDownMonth> ListMonth;
        public List<DepartmentModel> ListDepartment;
        public List<DropDownPMOModel> ListPMO;
        public List<DropDownOwnerModel> ListOwner;
        public List<DropDownSponsorModel> ListSponsor;
        public List<DirektoratModel> ListDirektoratModel;
    }
}