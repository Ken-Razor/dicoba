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
    public class MasterSlaCRUDController : ApiController
    {
        public string Post([FromBody] MasterSLA dm)
        {
            try
            {
                SLA md = new SLA();
                string result = "F|Terdapat kesalahan pada API Controller";

                result = md.Insert_Update_Master_SLA(dm.Id, dm.GroupId, dm.StatusSLA, dm.Peraturan, dm.JasaPelayanan, dm.Waktu, dm.DihitungDari, dm.Uuser, "Insert");

                return result;
            }
            catch (Exception ex)
            {
                return "Kesalahan pada API Controller : " + ex.Message;
            }
        }

        public string Put([FromBody] MasterSLA dm)
        {
            try
            {
                SLA md = new SLA();
                string result = "F|Terdapat kesalahan pada API Controller";

                result = md.Insert_Update_Master_SLA(dm.Id, dm.GroupId,dm.StatusSLA, dm.Peraturan, dm.JasaPelayanan, dm.Waktu, dm.DihitungDari, dm.Uuser, "Update");
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
                SLA md = new SLA();
                string result = "F|Terdapat kesalahan pada API Controller";
                MasterSLA dm = new MasterSLA();
                dm.Id = Id;

                result = md.Insert_Update_Master_SLA(dm.Id, 0,"", "","","", "", "", "Delete");

                return result;
            }
            catch (Exception ex)
            {
                return "Kesalahan pada API Controller : " + ex.Message;
            }
        }


    }
}
