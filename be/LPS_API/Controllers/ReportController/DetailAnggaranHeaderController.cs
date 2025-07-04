using LPS_API.Models.MasterDataModels;
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
    public class DetailAnggaranHeaderController : ApiController
    {
        public List<DepartmentModel> Post([FromBody]DepartmentModel obj)
        {
            Report r = new Report();

            DataSet ds = r.Get_Detail_AnggaraHeader(obj.IDDirektorat);
            DataTable dt1 = ds.Tables[0];

            List<DepartmentModel> ListDepartment = new List<DepartmentModel>();

            foreach(DataRow dr in dt1.Rows)
            {
                DepartmentModel Department = new DepartmentModel();
                Department.IDDepartment = Convert.ToInt32(dr["IDDepartment"]);
                Department.DepartmentCode = dr["DepartmentCode"].ToString();
                Department.DepartmentName = dr["DepartmentName"].ToString();
                ListDepartment.Add(Department);
            }

            return ListDepartment;
        }
    }
}
