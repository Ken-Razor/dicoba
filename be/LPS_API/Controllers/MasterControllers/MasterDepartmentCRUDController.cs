using LPS_API.Models.MasterDataModels;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers
{
    public class MasterDepartmentCRUDController : ApiController
    {
        public string Post([FromBody]DepartmentModel dm)
        {
            try
            {
                MasterData md = new MasterData();
                string result = "F|Terdapat kesalahan pada API Controller";
                DepartmentModel Department = new DepartmentModel();

                result = md.Insert_MasterDepartment(dm.IDDepartment, dm.IDDirektorat, dm.DepartmentCode, dm.CostCenter,dm.DepartmentName,dm.Description,dm.CreatedBy, "Insert");
                
                return result;
            }
            catch (Exception ex)
            {
                return "Kesalahan pada API Controller : " + ex.Message;
            }
        }

        public string Put([FromBody]DepartmentModel dm)
        {
            try
            {
                MasterData md = new MasterData();
                string result = "F|Terdapat kesalahan pada API Controller";
                DepartmentModel Department = new DepartmentModel();

                result = md.Insert_MasterDepartment(dm.IDDepartment, dm.IDDirektorat, dm.DepartmentCode, dm.CostCenter, dm.DepartmentName, dm.Description, dm.CreatedBy, "Update");

                return result;
            }
            catch (Exception ex)
            {
                return "Kesalahan pada API Controller : " + ex.Message;
            }
        }

        public string Delete(int IDDepartment)
        {
            try
            {
                MasterData md = new MasterData();
                string result = "F|Terdapat kesalahan pada API Controller";
                DepartmentModel dm = new DepartmentModel();
                dm.IDDepartment = IDDepartment;

                result = md.Insert_MasterDepartment(dm.IDDepartment, dm.IDDirektorat, dm.DepartmentCode, dm.CostCenter, dm.DepartmentName, dm.Description, dm.CreatedBy, "Delete");

                return result;
            }
            catch (Exception ex)
            {
                return "Kesalahan pada API Controller : " + ex.Message;
            }
        }
    }
}
