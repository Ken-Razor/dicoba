using LPS_API.Helper;
using LPS_API.Models.MasterDataModels;
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
    public class MasterDepartmentController : ApiController
    {
        public List<DepartmentModel> Get()
        {
            try
            {
                MasterData md = new MasterData();
                List<DepartmentModel> ListDepartment = new List<DepartmentModel>();

                foreach (DataRow dr in md.Get_MasterDepartment().Rows)
                {
                    DepartmentModel Department = new DepartmentModel();

                    if (dr["NoUrut"].ToString() != "") Department.NoUrut = Convert.ToInt32(dr["NoUrut"]);
                    if (dr["IDDepartment"].ToString() != "") Department.IDDepartment = Convert.ToInt32(dr["IDDepartment"]);
                    Department.DepartmentCode = dr["DepartmentCode"].ToString();
                    Department.CostCenter = dr["CostCenter"].ToString();
                    Department.DepartmentName = dr["DepartmentName"].ToString();
                    Department.Description = dr["Description"].ToString();
                    if (dr["CreatedDate"].ToString() != "") Department.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                    Department.CreatedBy = dr["CreatedBy"].ToString();
                    if (dr["UpdatedDate"].ToString() != "") Department.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);
                    Department.UpdatedDateString = dr["UpdatedDateString"].ToString();
                    Department.UpdatedBy = dr["UpdatedBy"].ToString();
                    if (dr["IsActive"].ToString() != "") Department.IsActive = Convert.ToBoolean(dr["IsActive"]);

                    ListDepartment.Add(Department);
                }
                return ListDepartment;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public DepartmentModel Post([FromBody]DepartmentModel dm)
        {
            try
            {
                MasterData md = new MasterData();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                DepartmentModel Department = new DepartmentModel();
                List<DirektoratModel> ListDirektorat = new List<DirektoratModel>();

                ds = md.Get_MasterDepartment_ByID(dm.IDDepartment);
                dt = ds.Tables[0];
                dt1 = ds.Tables[1];

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["NoUrut"].ToString() != "") Department.NoUrut = Convert.ToInt32(dt.Rows[0]["NoUrut"]);
                    if (dt.Rows[0]["IDDepartment"].ToString() != "") Department.IDDepartment = Convert.ToInt32(dt.Rows[0]["IDDepartment"]);
                    if (dt.Rows[0]["IDDirektorat"].ToString() != "") Department.IDDirektorat = Convert.ToInt32(dt.Rows[0]["IDDirektorat"]);
                    Department.DepartmentCode = dt.Rows[0]["DepartmentCode"].ToString();
                    Department.CostCenter = dt.Rows[0]["CostCenter"].ToString();
                    Department.DepartmentName = dt.Rows[0]["DepartmentName"].ToString();
                    Department.Description = dt.Rows[0]["Description"].ToString();
                    Department.CreatedBy = dt.Rows[0]["CreatedBy"].ToString();
                    if (dt.Rows[0]["CreatedDate"].ToString() != "") Department.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CreatedDate"]);
                    Department.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                    if (dt.Rows[0]["CreatedDate"].ToString() != "") Department.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CreatedDate"]);
                    if (dt.Rows[0]["IsActive"].ToString() != "") Department.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                }

                foreach(DataRow dr in dt1.Rows)
                {
                    DirektoratModel drm = new DirektoratModel();
                    if(dr["IDDirektorat"].ToString() != "") drm.IDDirektorat = Convert.ToInt32(dr["IDDirektorat"]);
                    drm.RefID = dr["RefID"].ToString();
                    drm.DirektoratCode = dr["DirektoratCode"].ToString();
                    drm.DirektoratName = dr["DirektoratName"].ToString();
                    drm.Description = dr["Description"].ToString();
                    ListDirektorat.Add(drm);
                }

                Department.ListDirektorat = ListDirektorat;

                return Department;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DepartmentModel> Put([FromBody] DepartmentModel dm)
        {
            try
            {
                GlobalFunction gf = new GlobalFunction();
                MasterData md = new MasterData();
                DataTable ds = new DataTable();
                List<DepartmentModel> Department = new List<DepartmentModel>();
                List<DirektoratModel> ListDirektorat = new List<DirektoratModel>();

                ds = md.Get_MasterDepartment_ByName(dm.DepartmentName);
                Department = gf.ConvertTo<DepartmentModel>(ds);

                return Department;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
