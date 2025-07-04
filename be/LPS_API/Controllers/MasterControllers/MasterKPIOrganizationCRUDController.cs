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
    public class MasterKPIOrganizationCRUDController : ApiController
    {
        public string Post([FromBody]KPIOrganizationModel kpiom)
        {
            try
            {
                MasterData md = new MasterData();
                string result = "F|Terdapat kesalahan pada API Controller";

                result = md.Insert_MasterKPIOrganization(kpiom.IDKPIOrganization, kpiom.KPICode, kpiom.KPIName, kpiom.Year, kpiom.Description, kpiom.CreatedBy, "Insert");

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Put([FromBody]KPIOrganizationModel kpiom)
        {
            try
            {
                MasterData md = new MasterData();
                string result = "F|Terdapat kesalahan pada API Controller";

                result = md.Insert_MasterKPIOrganization(kpiom.IDKPIOrganization, kpiom.KPICode, kpiom.KPIName, kpiom.Year, kpiom.Description, kpiom.CreatedBy, "Update");

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Delete(int IDKPIOrganization)
        {
            try
            {
                MasterData md = new MasterData();
                string result = "F|Terdapat kesalahan pada API Controller";
                KPIOrganizationModel kpiom = new KPIOrganizationModel();
                kpiom.IDKPIOrganization = IDKPIOrganization;

                result = md.Insert_MasterKPIOrganization(kpiom.IDKPIOrganization, kpiom.KPICode, kpiom.KPIName, kpiom.Year, kpiom.Description, kpiom.CreatedBy, "Delete");

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
