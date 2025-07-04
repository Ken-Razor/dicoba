using LPS_API.Models.EksekusiModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LPS_API.Helper;
using System.ComponentModel;
using LPS_API.Models.TransaksiDataModels;
using LPS_BLL;

namespace LPS_API.Controllers.TransaksiControllers
{
    public class EksekusiMainController : ApiController
    {
        GlobalFunction GF = new GlobalFunction();
        TransaksiEksekusi TE = new TransaksiEksekusi();
        public string InsertEksekusi([FromBody]InsertExsekusi Data)
        {


            var param = Data.Periode.Split('-');
            var year = param[0];
            var month = param[1];
            var week = param[2];

            DataTable dtPercentage = new DataTable();
            DataTable dtCOnstrain = new DataTable();
            DataTable dtRole = new DataTable();
            if (Data.MPPTasks.Count > 0)
            {
                try
                {
                    dtPercentage = ListToDataTable<MPPTaskNew>(Data.MPPTasks);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            if (Data.conso != null && Data.conso.Count > 0 )
            {
                dtCOnstrain = ListToDataTable<Constrain>(Data.conso);
            } else
            {
                dtCOnstrain.Columns.Add("IDProjectConstraint");
                dtCOnstrain.Columns.Add("IDProjectHeader");
                dtCOnstrain.Columns.Add("IDConstraintType");
                dtCOnstrain.Columns.Add("Description");
                dtCOnstrain.Columns.Add("Remarks");
                dtCOnstrain.Columns.Add("Problem");
                dtCOnstrain.Columns.Add("Status");
                dtCOnstrain.Columns.Add("Mitigasi");
            }
            if (Data.app != null && Data.app.Count > 0)
            {
                dtRole = ListToDataTable<execApproval>(Data.app);

            }
            else
            {
                 dtRole.Columns.Add("IDProjectInitApprovalRole" );
                 dtRole.Columns.Add("IDProjectHeader");
                 dtRole.Columns.Add("IDRoleGroup");
                 dtRole.Columns.Add("Sequence");
                 dtRole.Columns.Add("Username");
                 dtRole.Columns.Add("Email");
                 dtRole.Columns.Add("PositionCode");
                 dtRole.Columns.Add("Periode");
                 dtRole.Columns.Add("ActiveDate");
                 dtRole.Columns.Add("EndDate");
                 dtRole.Columns.Add("IsEnabled");
            }
            try
            {
                var datas = TE.InsertEksekusi(Convert.ToInt32(Data.ProjectHeaderID), dtPercentage, Data.PersonNumber, dtCOnstrain, Data.Status, Data.Periode, dtRole, year, Convert.ToInt32(month), Convert.ToInt32(week));
                return datas;
            }
            catch (Exception ex)
            {

                throw;
            }

            return null;
        }

        public static DataTable ListToDataTable<T>(IList<T> data)
        {
            DataTable table = new DataTable();

            //special handling for value types and string
            if (typeof(T).IsValueType || typeof(T).Equals(typeof(string)))
            {

                DataColumn dc = new DataColumn("Value");
                table.Columns.Add(dc);
                foreach (T item in data)
                {
                    DataRow dr = table.NewRow();
                    dr[0] = item;
                    table.Rows.Add(dr);
                }
            }
            else
            {
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
                foreach (PropertyDescriptor prop in properties)
                {
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
                foreach (T item in data)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                    {
                        try
                        {
                            row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                        }
                        catch (Exception ex)
                        {
                            row[prop.Name] = DBNull.Value;
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            return table;
        }
    }
}
