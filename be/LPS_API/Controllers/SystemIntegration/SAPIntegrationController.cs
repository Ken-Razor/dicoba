using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LPS_API.Models.SystemIntegration;
using LPS_BLL;

namespace LPS_API.Controllers.SystemIntegration
{
    public class SAPIntegrationController : ApiController
    {
        IntegrationSystem IS = new IntegrationSystem();
        public bool Post([FromBody]List<SAPIntegrationEntityRKAT> RKAT)
        {
            DataTable dtRKAT = ConvertToDataTable(RKAT);
            bool Status = IS.SAPInsertRKAT(dtRKAT);
            return Status;
        }

        private DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
            TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
