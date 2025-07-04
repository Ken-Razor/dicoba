using System.Data;
using System.Linq;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace SAP_Scheduller
{
    class Program
    {
        //static private string DWPekerjaAPI = ConfigurationManager.AppSettings["DataWarehouseIntegrationAPI"].ToString();


        public static void Main(string[] args)
        {
            #region Employee Scheduler
            //DataEmployee();
            //DataKPI();
            //DataSO();
            #endregion

            #region SAP Scheduler
            SAPFileModul SFM = new SAPFileModul();
            SFM.CarryOver();
            SFM.Komitment();
            SFM.Hangus();
            SFM.MD_Rencana_Kerja();
            SFM.MD_Account();
            SFM.Pergeseran();
            SFM.RKATFinal();
            SFM.Realisasi();
            #endregion
        }
        protected static void DataWareHouseDownloader()
        {
            //Uri baseAddress = new Uri(DWPekerjaAPI);
            //HttpClient ClassHttpClient = new HttpClient();
            //ClassHttpClient.BaseAddress = baseAddress;
            //ClassHttpClient.DefaultRequestHeaders.Accept.Clear();

            //var response = ClassHttpClient.PostAsJsonAsync(baseAddress.ToString(), _SAPRKAT).Result;

            //if (response.IsSuccessStatusCode)
            //{
            //    var result = response.Content.ReadAsStringAsync().Result;

            //    string Keterangan = result;

            //}
        }
        protected static void DatawarehouseRKAT()
        {
            Helper Help = new Helper();
            string filepath = ConfigurationManager.AppSettings["Pelaporan_Filepath"].ToString();
            string namafile = ConfigurationManager.AppSettings["Carry_Over"].ToString();
            var directory = new DirectoryInfo(filepath);
            var myFile = directory.GetFiles(namafile);
            //.OrderByDescending(f => f.LastWriteTime)
            //.First();
            var file = "";
            foreach (var fi in myFile)
            {
                file = fi.FullName;
            }
            //string file = myFile.FullName;
            DataTable dtCarryOver = ConvertToDataTableWithComma(file);
            HttpClient client = new HttpClient();
            string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "SAPIntegration";
            Uri baseAddress = new Uri(url);
            client.BaseAddress = baseAddress;
            client.DefaultRequestHeaders.Accept.Clear();
            //var response = client.PostAsJsonAsync(baseAddress.ToString(), _SAPRKAT).Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    var result = response.Content.ReadAsStringAsync().Result;
            //    string Keterangan = result;
            //}
        }

        public static DataTable ConvertToDataTableWithComma(string filePath)
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
        protected static void DataSO()
        {
            try
            {
                Helper help = new Helper();
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["ActuateAPI"].ToString() + "dataSO";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.GetAsync(baseAddress.ToString()).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                List<SO> Employee = JsonConvert.DeserializeObject<List<SO>>(result);

                DataTable dtSuccess = new DataTable();
                DataTable dtFailed = new DataTable();
                dtSuccess.Columns.Add("counter");
                dtFailed.Columns.Add("counter");

                foreach (var item in Employee)
                {
                  
                    HttpClient localclient = new HttpClient();
                    string localurl = ConfigurationManager.AppSettings["WebAPI"].ToString() + "Actuate";
                    Uri localbaseAddress = new Uri(localurl);

                    localclient.BaseAddress = localbaseAddress;

                    localclient.DefaultRequestHeaders.Accept.Clear();

                    var localresponse = localclient.PostAsJsonAsync(localbaseAddress.ToString(), item).Result;
                   

                    string Keterangan = "";
                    if (localresponse.IsSuccessStatusCode)
                    {
                        var localresult = localresponse.Content.ReadAsStringAsync().Result;
                        Keterangan = localresult;
                        Console.WriteLine(Keterangan);
                        if (localresult.Contains("Success"))
                        {
                            dtSuccess.Rows.Add(Keterangan);
                        }
                        else
                        {
                            dtFailed.Rows.Add(Keterangan);
                        }
                    }
                    else
                    {
                        var localresult = localresponse.Content.ReadAsStringAsync().Result;
                        Keterangan = localresult;
                        Console.WriteLine(Keterangan);
                        dtFailed.Rows.Add(Keterangan);
                    }


                }
            }
            catch (Exception ex)
            {

                throw;
            }         
        }
        protected static void DataKPI()
        {
            try
            {
                Helper help = new Helper();
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["ActuateAPI"].ToString() + "dataKPI";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.GetAsync(baseAddress.ToString()).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                List<KPI> KPI = JsonConvert.DeserializeObject<List<KPI>>(result);

                DataTable dtSuccess = new DataTable();
                DataTable dtFailed = new DataTable();
                dtSuccess.Columns.Add("counter");
                dtFailed.Columns.Add("counter");

                foreach (var item in KPI)
                {

                    HttpClient localclient = new HttpClient();
                    string localurl = ConfigurationManager.AppSettings["WebAPI"].ToString() + "Actuate";
                    Uri localbaseAddress = new Uri(localurl);

                    localclient.BaseAddress = localbaseAddress;

                    localclient.DefaultRequestHeaders.Accept.Clear();

                    var localresponse = localclient.PutAsJsonAsync(localbaseAddress.ToString(), item).Result;


                    string Keterangan = "";
                    if (localresponse.IsSuccessStatusCode)
                    {
                        var localresult = localresponse.Content.ReadAsStringAsync().Result;
                        Keterangan = localresult;
                        Console.WriteLine(Keterangan);
                        if (localresult.Contains("Success"))
                        {
                            dtSuccess.Rows.Add(Keterangan);
                        }
                        else
                        {
                            dtFailed.Rows.Add(Keterangan);
                        }
                    }
                    else
                    {
                        var localresult = localresponse.Content.ReadAsStringAsync().Result;
                        Keterangan = localresult;
                        Console.WriteLine(Keterangan);
                        dtFailed.Rows.Add(Keterangan);
                    }


                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected static void DataEmployee()
        {
            try
            {
                Helper help = new Helper();
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["ActuateAPI"].ToString() + "datapegawai";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.GetAsync(baseAddress.ToString()).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                List<DWEntity> Emp = JsonConvert.DeserializeObject<List<DWEntity>>(result);

                DataTable dtSuccess = new DataTable();
                DataTable dtFailed = new DataTable();
                dtSuccess.Columns.Add("counter");
                dtFailed.Columns.Add("counter");

                foreach (var item in Emp)
                {

                    HttpClient localclient = new HttpClient();
                    string localurl = ConfigurationManager.AppSettings["WebAPI"].ToString() + "DataWarehouseIntegration";
                    Uri localbaseAddress = new Uri(localurl);

                    localclient.BaseAddress = localbaseAddress;

                    localclient.DefaultRequestHeaders.Accept.Clear();

                    var localresponse = localclient.PostAsJsonAsync(localbaseAddress.ToString(), item).Result;


                    string Keterangan = "";
                    if (localresponse.IsSuccessStatusCode)
                    {
                        var localresult = localresponse.Content.ReadAsStringAsync().Result;
                        Keterangan = localresult;
                        Console.WriteLine(Keterangan);
                        if (localresult.Contains("Success"))
                        {
                            dtSuccess.Rows.Add(Keterangan);
                        }
                        else
                        {
                            dtFailed.Rows.Add(Keterangan);
                        }
                    }
                    else
                    {
                        var localresult = localresponse.Content.ReadAsStringAsync().Result;
                        Keterangan = localresult;
                        Console.WriteLine(Keterangan);
                        dtFailed.Rows.Add(Keterangan);
                    }


                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
