using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SAP_Scheduller
{
    public class Helper
    {
        public DataTable ConvertToDataTableWithComma(string filePath)
        {
            DataTable tbl = new DataTable();

            string[] lines = System.IO.File.ReadAllLines(filePath);
            var colname = lines[0].Split(',');
            for (int col = 0; col < colname.Length; col++)
                tbl.Columns.Add(new DataColumn(colname[col].ToString()));


            foreach (string line in lines.Skip(1))
            {
                var cols = line.Split(',');

                DataRow dr = tbl.NewRow();
                for (int cIndex = 0; cIndex < colname.Length; cIndex++)
                {
                    dr[cIndex] = cols[cIndex];
                }

                tbl.Rows.Add(dr);
            }

            return tbl;
        }

        public DataTable ConvertToDataTableWithGarisKeras(string filePath)
        {
            DataTable tbl = new DataTable();

            string[] lines = System.IO.File.ReadAllLines(filePath);
            var colname = lines[0].Split('|');
            for (int col = 0; col < colname.Length; col++)
                tbl.Columns.Add(new DataColumn(colname[col].ToString()));


            foreach (string line in lines.Skip(1))
            {
                var cols = line.Split('|');

                DataRow dr = tbl.NewRow();
                for (int cIndex = 0; cIndex < colname.Length; cIndex++)
                {
                    dr[cIndex] = cols[cIndex];
                }

                tbl.Rows.Add(dr);
            }

            return tbl;
        }

        public List<T> ConvertTo<T>(DataTable datatable) where T : new()
        {
            List<T> Temp = new List<T>();
            try
            {
                List<string> columnsNames = new List<string>();
                foreach (DataColumn DataColumn in datatable.Columns)
                    columnsNames.Add(DataColumn.ColumnName);
                Temp = datatable.AsEnumerable().ToList().ConvertAll<T>(row => getObject<T>(row, columnsNames));
                return Temp;
            }
            catch
            {
                return Temp;
            }

        }
        public T getObject<T>(DataRow row, List<string> columnsName) where T : new()
        {
            T obj = new T();
            try
            {
                string columnname = "";
                string value = "";
                PropertyInfo[] Properties;
                Properties = typeof(T).GetProperties();
                foreach (PropertyInfo objProperty in Properties)
                {
                    columnname = columnsName.Find(name => name.ToLower() == objProperty.Name.ToLower());
                    if (!string.IsNullOrEmpty(columnname))
                    {
                        value = row[columnname].ToString();
                        if (!string.IsNullOrEmpty(value))
                        {
                            if (Nullable.GetUnderlyingType(objProperty.PropertyType) != null)
                            {
                                value = row[columnname].ToString().Replace("$", "").Replace(",", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(Nullable.GetUnderlyingType(objProperty.PropertyType).ToString())), null);
                            }
                            else
                            {
                                value = row[columnname].ToString().Replace("%", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(objProperty.PropertyType.ToString())), null);
                            }
                        }
                    }
                }
                return obj;
            }
            catch
            {
                return obj;
            }
        }

        public DataTable ToDataTable<T>(IList<T> data)
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

        //public static void InsertLog(string SchedulerName, string Description , int RowAffected , DateTime startdate , DateTime EndDate)
        //{
        //    try
        //    {
                

        //        HttpClient client = new HttpClient();
        //        string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "SchedullerLog";
        //        Uri baseAddress = new Uri(url);
        //        client.BaseAddress = baseAddress;
        //        client.DefaultRequestHeaders.Accept.Clear();

        //        var response = client.PostAsJsonAsync(baseAddress.ToString(), item).Result;
        //        string Keterangan = "";
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var result = response.Content.ReadAsStringAsync().Result;
        //            Keterangan = result;
        //            Console.WriteLine(Keterangan);
        //        }
        //        else
        //        {
        //            var result = response.Content.ReadAsStringAsync().Result;
        //            Keterangan = result;
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
           
        //}

    }
}
