using LPS_API.Models.DashboardModels;
using LPS_API.Models.MasterDataModels;
using LPS_API.Models.ReportModels;
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
    public class MasterHolidayCRUDController : ApiController
    {
        public string Post([FromBody] MasterHoliday dm)
        {
            try
            {
                Holiday md = new Holiday();
                string result = "F|Terdapat kesalahan pada API Controller";

                result = md.Insert_Update_Master_Holiday(dm.IDHoliday, dm.Nama, dm.TglMulai, dm.TglSelesai, dm.CreatedBy);

                return result;
            }
            catch (Exception ex)
            {
                return "Kesalahan pada API Controller : " + ex.Message;
            }
        }

        public string Delete(int Id)
        {
            try
            {
                Holiday md = new Holiday();
                string result = "F|Terdapat kesalahan pada API Controller";
                MasterSLA dm = new MasterSLA();
                dm.Id = Id;

                result = md.Delete_Master_Holiday(Id);

                return result;
            }
            catch (Exception ex)
            {
                return "Kesalahan pada API Controller : " + ex.Message;
            }
        }


    }
}
