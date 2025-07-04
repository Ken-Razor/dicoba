using LPS_API.Helper;
using LPS_API.Models.SystemIntegration;
using LPS_BLL;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.SystemIntegration
{
    public class PublicHolidayIntegrationController : ApiController
    {
        GlobalFunction GF = new GlobalFunction();
        IntegrationSystem IS = new IntegrationSystem();
        public string Get()
        {
            HttpClient client = new HttpClient();
            string url = ConfigurationManager.AppSettings["urlHoliday"].ToString(); 
            Uri baseAddress = new Uri(url);

            client.BaseAddress = baseAddress;

            client.DefaultRequestHeaders.Accept.Clear();

            var response = client.GetAsync(baseAddress.ToString()).Result;
            var result = response.Content.ReadAsStringAsync().Result;

            List<dynamic> Holiday = JsonConvert.DeserializeObject<List<dynamic>>(result);


            var z = ToDataTableDynamic<dynamic>(Holiday);

           
            var Data = IS.DWInsertDate(z);

            return Data;
        }

        public DataTable ToDataTableDynamic<T>(dynamic items)
        {

            DataTable dtDataTable = new DataTable();
            if (items.Count == 0) return dtDataTable;

            ((IEnumerable)items[0]).Cast<dynamic>().Select(p => p.Name).ToList().ForEach(col => { dtDataTable.Columns.Add(col); });

            ((IEnumerable)items).Cast<dynamic>().ToList().
                ForEach(data =>
                {
                    DataRow dr = dtDataTable.NewRow();
                    ((IEnumerable)data).Cast<dynamic>().ToList().ForEach(Col => { dr[Col.Name] = Col.Value; });
                    dtDataTable.Rows.Add(dr);
                });
            return dtDataTable;
        }
    }
}
