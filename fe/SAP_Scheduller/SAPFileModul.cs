using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SAP_Scheduller
{
    class SAPFileModul
    {

        public void CarryOver()
        {
            Helper Help = new Helper();
            string filepath = ConfigurationManager.AppSettings["Pelaporan_Filepath"].ToString();
            string namafile = ConfigurationManager.AppSettings["Carry_Over"].ToString();

            var username = ConfigurationManager.AppSettings["Username"].ToString();
            var password = ConfigurationManager.AppSettings["Password"].ToString();
            var hostname = ConfigurationManager.AppSettings["Hostname"].ToString();

            NetworkCredential theNetworkCredential = new NetworkCredential(@username, password);
            CredentialCache theNetCache = new CredentialCache();
            theNetCache.Add(new Uri(@hostname), "Basic", theNetworkCredential);
            string[] theFolders = Directory.GetDirectories(@filepath);

            var directory = new DirectoryInfo(filepath);
            var myFile = directory.GetFiles(namafile);

            var file = "";

            foreach (var fi in myFile)
            {
                file = fi.FullName;
            }
     
            DataTable dtCarryOver = Help.ConvertToDataTableWithComma(file);
            List<SAPIntegration> _CO = Help.ConvertTo<SAPIntegration>(dtCarryOver);

            Console.WriteLine("=========================================================================================================");
            Console.WriteLine("==== UPLOADING " + namafile);
            Console.WriteLine("=========================================================================================================");

            DataTable dtSuccess = new DataTable();
            DataTable dtFailed = new DataTable();
            dtSuccess.Columns.Add("counter");
            dtFailed.Columns.Add("counter");
            foreach (var item in _CO)
            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "SAPCarryOver";
                Uri baseAddress = new Uri(url);
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), item).Result;
                string Keterangan = "";
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    Keterangan = result;
                    Console.WriteLine(Keterangan);
                    if (result.Contains("Success"))
                    {
                        dtSuccess.Rows.Add(Keterangan);
                    } else
                    {
                        dtFailed.Rows.Add(Keterangan);
                    }
                }
                else
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    Keterangan = result;
                    Console.WriteLine(Keterangan);
                    dtFailed.Rows.Add(Keterangan);
                }
            }

            Console.WriteLine("=========================================================================================================");
            Console.WriteLine("==== " + dtSuccess.Rows.Count + " ROW HAS BEEN UPLOADED");
            Console.WriteLine("==== " + dtFailed.Rows.Count + " ROW WAS NOT UPLOADED");
            Console.WriteLine("=========================================================================================================");
        }

        public void Komitment()
        {
            Helper Help = new Helper();
            string filepath = ConfigurationManager.AppSettings["Pelaporan_Filepath"].ToString();
            string namafile = ConfigurationManager.AppSettings["Komitmen"].ToString();

            var username = ConfigurationManager.AppSettings["Username"].ToString();
            var password = ConfigurationManager.AppSettings["Password"].ToString();
            var hostname = ConfigurationManager.AppSettings["Hostname"].ToString();

            NetworkCredential theNetworkCredential = new NetworkCredential(@username, password);
            CredentialCache theNetCache = new CredentialCache();
            theNetCache.Add(new Uri(@hostname), "Basic", theNetworkCredential);
            string[] theFolders = Directory.GetDirectories(@filepath);
            var directory = new DirectoryInfo(@filepath);
            var myFile = directory.GetFiles(namafile);



            var file = "";

            foreach (var fi in myFile)
            {
                file = fi.FullName;
            }


            DataTable dtKomitmen = Help.ConvertToDataTableWithComma(file);
            List<SAPIntegration> _KOM = Help.ConvertTo<SAPIntegration>(dtKomitmen);

            Console.WriteLine("=========================================================================================================");
            Console.WriteLine("==== UPLOADING " + namafile);
            Console.WriteLine("=========================================================================================================");

            DataTable dtSuccess = new DataTable();
            DataTable dtFailed = new DataTable();
            dtSuccess.Columns.Add("counter");
            dtFailed.Columns.Add("counter");
            foreach (var item in _KOM)
            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "SAPKomitmen";
                Uri baseAddress = new Uri(url);
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), item).Result;
                string Keterangan = "";
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    Keterangan = result;
                    Console.WriteLine(Keterangan);
                    if (result.Contains("Success"))
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
                    var result = response.Content.ReadAsStringAsync().Result;
                    Keterangan = result;
                    Console.WriteLine(Keterangan);
                    dtFailed.Rows.Add(Keterangan);
                }
            }

            Console.WriteLine("=========================================================================================================");
            Console.WriteLine("==== " + dtSuccess.Rows.Count + " ROW HAS BEEN UPLOADED");
            Console.WriteLine("==== " + dtFailed.Rows.Count + " ROW WAS NOT UPLOADED");
            Console.WriteLine("=========================================================================================================");
        }

        public void Hangus()
        {
            Helper Help = new Helper();
            string filepath = ConfigurationManager.AppSettings["Pelaporan_Filepath"].ToString();
            string namafile = ConfigurationManager.AppSettings["Hangus"].ToString();

            var username = ConfigurationManager.AppSettings["Username"].ToString();
            var password = ConfigurationManager.AppSettings["Password"].ToString();
            var hostname = ConfigurationManager.AppSettings["Hostname"].ToString();

            NetworkCredential theNetworkCredential = new NetworkCredential(@username, password);
            CredentialCache theNetCache = new CredentialCache();
            theNetCache.Add(new Uri(@hostname), "Basic", theNetworkCredential);
            string[] theFolders = Directory.GetDirectories(@filepath);
            var directory = new DirectoryInfo(@filepath);
            var myFile = directory.GetFiles(namafile);



            var file = "";

            foreach (var fi in myFile)
            {
                file = fi.FullName;
            }


            DataTable dtKomitmen = Help.ConvertToDataTableWithComma(file);
            List<SAPIntegration> _KOM = Help.ConvertTo<SAPIntegration>(dtKomitmen);

            Console.WriteLine("=========================================================================================================");
            Console.WriteLine("==== UPLOADING " + namafile);
            Console.WriteLine("=========================================================================================================");

            DataTable dtSuccess = new DataTable();
            DataTable dtFailed = new DataTable();
            dtSuccess.Columns.Add("counter");
            dtFailed.Columns.Add("counter");
            foreach (var item in _KOM)
            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "SAPHangus";
                Uri baseAddress = new Uri(url);
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), item).Result;
                string Keterangan = "";
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    Keterangan = result;
                    Console.WriteLine(Keterangan);
                    if (result.Contains("Success"))
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
                    var result = response.Content.ReadAsStringAsync().Result;
                    Keterangan = result;
                    Console.WriteLine(Keterangan);
                    dtFailed.Rows.Add(Keterangan);
                }
            }

            Console.WriteLine("=========================================================================================================");
            Console.WriteLine("==== " + dtSuccess.Rows.Count + " ROW HAS BEEN UPLOADED");
            Console.WriteLine("==== " + dtFailed.Rows.Count + " ROW WAS NOT UPLOADED");
            Console.WriteLine("=========================================================================================================");
        }

        public void Pergeseran()
        {
            Helper Help = new Helper();
            string filepath = ConfigurationManager.AppSettings["Pelaporan_Filepath"].ToString();
            string namafile = ConfigurationManager.AppSettings["Pergeseran"].ToString();

            var username = ConfigurationManager.AppSettings["Username"].ToString();
            var password = ConfigurationManager.AppSettings["Password"].ToString();
            var hostname = ConfigurationManager.AppSettings["Hostname"].ToString();

            NetworkCredential theNetworkCredential = new NetworkCredential(@username, password);
            CredentialCache theNetCache = new CredentialCache();
            theNetCache.Add(new Uri(@hostname), "Basic", theNetworkCredential);
            string[] theFolders = Directory.GetDirectories(@filepath);
            var directory = new DirectoryInfo(@filepath);
            var myFile = directory.GetFiles(namafile);



            var file = "";

            foreach (var fi in myFile)
            {
                file = fi.FullName;
            }


            DataTable dtKomitmen = Help.ConvertToDataTableWithComma(file);
            List<SAPIntegration> _KOM = Help.ConvertTo<SAPIntegration>(dtKomitmen);

            Console.WriteLine("=========================================================================================================");
            Console.WriteLine("==== UPLOADING " + namafile);
            Console.WriteLine("=========================================================================================================");

            DataTable dtSuccess = new DataTable();
            DataTable dtFailed = new DataTable();
            dtSuccess.Columns.Add("counter");
            dtFailed.Columns.Add("counter");
            foreach (var item in _KOM)
            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "SAPPergeseran";
                Uri baseAddress = new Uri(url);
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), item).Result;
                string Keterangan = "";
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    Keterangan = result;
                    Console.WriteLine(Keterangan);
                    if (result.Contains("Success"))
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
                    var result = response.Content.ReadAsStringAsync().Result;
                    Keterangan = result;
                    Console.WriteLine(Keterangan);
                    dtFailed.Rows.Add(Keterangan);
                }
            }

            Console.WriteLine("=========================================================================================================");
            Console.WriteLine("==== " + dtSuccess.Rows.Count + " ROW HAS BEEN UPLOADED");
            Console.WriteLine("==== " + dtFailed.Rows.Count + " ROW WAS NOT UPLOADED");
            Console.WriteLine("=========================================================================================================");
        }

        public void Realisasi()
        {
            Helper Help = new Helper();
            string filepath = ConfigurationManager.AppSettings["Pelaporan_Filepath"].ToString();
            string namafile = ConfigurationManager.AppSettings["Realisasi"].ToString();

            var username = ConfigurationManager.AppSettings["Username"].ToString();
            var password = ConfigurationManager.AppSettings["Password"].ToString();
            var hostname = ConfigurationManager.AppSettings["Hostname"].ToString();

            NetworkCredential theNetworkCredential = new NetworkCredential(@username, password);
            CredentialCache theNetCache = new CredentialCache();
            theNetCache.Add(new Uri(@hostname), "Basic", theNetworkCredential);
            string[] theFolders = Directory.GetDirectories(@filepath);
            var directory = new DirectoryInfo(@filepath);
            var myFile = directory.GetFiles(namafile);



            var file = "";

            foreach (var fi in myFile)
            {
                file = fi.FullName;
            }


            DataTable dtKomitmen = Help.ConvertToDataTableWithComma(file);
            List<SAPIntegration> _KOM = Help.ConvertTo<SAPIntegration>(dtKomitmen);

            Console.WriteLine("=========================================================================================================");
            Console.WriteLine("==== UPLOADING " + namafile);
            Console.WriteLine("=========================================================================================================");

            DataTable dtSuccess = new DataTable();
            DataTable dtFailed = new DataTable();
            dtSuccess.Columns.Add("counter");
            dtFailed.Columns.Add("counter");
            foreach (var item in _KOM)
            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "SAPRealisasi";
                Uri baseAddress = new Uri(url);
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), item).Result;
                string Keterangan = "";
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    Keterangan = result;
                    Console.WriteLine(Keterangan);
                    if (result.Contains("Success"))
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
                    var result = response.Content.ReadAsStringAsync().Result;
                    Keterangan = result;
                    Console.WriteLine(Keterangan);
                    dtFailed.Rows.Add(Keterangan);
                }
            }

            Console.WriteLine("=========================================================================================================");
            Console.WriteLine("==== " + dtSuccess.Rows.Count + " ROW HAS BEEN UPLOADED");
            Console.WriteLine("==== " + dtFailed.Rows.Count + " ROW WAS NOT UPLOADED");
            Console.WriteLine("=========================================================================================================");
        }

        public void RKATFinal()
        {
            Helper Help = new Helper();
            string filepath = ConfigurationManager.AppSettings["Pelaporan_Filepath"].ToString();
            string namafile = ConfigurationManager.AppSettings["RKATFinal"].ToString();

            var username = ConfigurationManager.AppSettings["Username"].ToString();
            var password = ConfigurationManager.AppSettings["Password"].ToString();
            var hostname = ConfigurationManager.AppSettings["Hostname"].ToString();

            NetworkCredential theNetworkCredential = new NetworkCredential(@username, password);
            CredentialCache theNetCache = new CredentialCache();
            theNetCache.Add(new Uri(@hostname), "Basic", theNetworkCredential);
            string[] theFolders = Directory.GetDirectories(@filepath);
            var directory = new DirectoryInfo(@filepath);
            var myFile = directory.GetFiles(namafile);



            var file = "";

            foreach (var fi in myFile)
            {
                file = fi.FullName;
            }


            DataTable dtKomitmen = Help.ConvertToDataTableWithComma(file);
            List<SAPIntegration> _KOM = Help.ConvertTo<SAPIntegration>(dtKomitmen);

            Console.WriteLine("=========================================================================================================");
            Console.WriteLine("==== UPLOADING " + namafile);
            Console.WriteLine("=========================================================================================================");

            DataTable dtSuccess = new DataTable();
            DataTable dtFailed = new DataTable();
            dtSuccess.Columns.Add("counter");
            dtFailed.Columns.Add("counter");
            foreach (var item in _KOM)
            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "SAPRKATFinal";
                Uri baseAddress = new Uri(url);
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), item).Result;
                string Keterangan = "";
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    Keterangan = result;
                    Console.WriteLine(Keterangan);
                    if (result.Contains("Success"))
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
                    var result = response.Content.ReadAsStringAsync().Result;
                    Keterangan = result;
                    Console.WriteLine(Keterangan);
                    dtFailed.Rows.Add(Keterangan);
                }
            }

            Console.WriteLine("=========================================================================================================");
            Console.WriteLine("==== " + dtSuccess.Rows.Count + " ROW HAS BEEN UPLOADED");
            Console.WriteLine("==== " + dtFailed.Rows.Count + " ROW WAS NOT UPLOADED");
            Console.WriteLine("=========================================================================================================");
        }

        public void MD_Account()
        {
            Helper Help = new Helper();
            string filepath = ConfigurationManager.AppSettings["Pelaporan_Filepath"].ToString();
            string namafile = ConfigurationManager.AppSettings["MD_Account"].ToString();

            var username = ConfigurationManager.AppSettings["Username"].ToString();
            var password = ConfigurationManager.AppSettings["Password"].ToString();
            var hostname = ConfigurationManager.AppSettings["Hostname"].ToString();

            NetworkCredential theNetworkCredential = new NetworkCredential(@username, password);
            CredentialCache theNetCache = new CredentialCache();
            theNetCache.Add(new Uri(@hostname), "Basic", theNetworkCredential);
            string[] theFolders = Directory.GetDirectories(@filepath);
            var directory = new DirectoryInfo(@filepath);
            var myFile = directory.GetFiles(namafile);



            var file = "";

            foreach (var fi in myFile)
            {
                file = fi.FullName;
            }


            DataTable dtCarryOver = Help.ConvertToDataTableWithGarisKeras(file);
            List<SAPMD_Account> _KOM = Help.ConvertTo<SAPMD_Account>(dtCarryOver);

            Console.WriteLine("=========================================================================================================");
            Console.WriteLine("==== UPLOADING " + namafile);
            Console.WriteLine("=========================================================================================================");

            DataTable dtSuccess = new DataTable();
            DataTable dtFailed = new DataTable();
            dtSuccess.Columns.Add("counter");
            dtFailed.Columns.Add("counter");
            foreach (var item in _KOM)
            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "SAPMD_Account";
                Uri baseAddress = new Uri(url);
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), item).Result;
                string Keterangan = "";
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    Keterangan = result;
                    Console.WriteLine(Keterangan);
                    if (result.Contains("Success"))
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
                    var result = response.Content.ReadAsStringAsync().Result;
                    Keterangan = result;
                    Console.WriteLine(Keterangan);
                    dtFailed.Rows.Add(Keterangan);
                }
            }

            Console.WriteLine("=========================================================================================================");
            Console.WriteLine("==== " + dtSuccess.Rows.Count + " ROW HAS BEEN UPLOADED");
            Console.WriteLine("==== " + dtFailed.Rows.Count + " ROW WAS NOT UPLOADED");
            Console.WriteLine("=========================================================================================================");
        }

        public void MD_Rencana_Kerja()
        {
            Helper Help = new Helper();

            string filepath = ConfigurationManager.AppSettings["Pelaporan_Filepath"].ToString();
            string namafile = ConfigurationManager.AppSettings["MD_Rencana_Kerja"].ToString();
            //var directory = new DirectoryInfo(filepath);
            //var myFile = directory.GetFiles(namafile);

            var username = ConfigurationManager.AppSettings["Username"].ToString();
            var password = ConfigurationManager.AppSettings["Password"].ToString(); 
            var hostname = ConfigurationManager.AppSettings["Hostname"].ToString();

            NetworkCredential theNetworkCredential = new NetworkCredential(@username, password);
            CredentialCache theNetCache = new CredentialCache();
            theNetCache.Add(new Uri(@hostname), "Basic", theNetworkCredential);
            string[] theFolders = Directory.GetDirectories(@filepath);
            var directory = new DirectoryInfo(@filepath);
            var myFile = directory.GetFiles(namafile);
           


            var file = "";

            foreach (var fi in myFile)
            {
                file = fi.FullName;
            }

            DataTable dtCarryOver = Help.ConvertToDataTableWithGarisKeras(file);
            List<SAPMD_Rencana_Kerja> _KOM = Help.ConvertTo<SAPMD_Rencana_Kerja>(dtCarryOver);

            Console.WriteLine("=========================================================================================================");
            Console.WriteLine("==== UPLOADING " + namafile);
            Console.WriteLine("=========================================================================================================");

            DataTable dtSuccess = new DataTable();
            DataTable dtFailed = new DataTable();
            dtSuccess.Columns.Add("counter");
            dtFailed.Columns.Add("counter");
            foreach (var item in _KOM)
            {
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "SAPMD_Rencana_Kerja";
                Uri baseAddress = new Uri(url);
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), item).Result;
                string Keterangan = "";
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    Keterangan = result;
                    Console.WriteLine(Keterangan);
                    if (result.Contains("Success"))
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
                    var result = response.Content.ReadAsStringAsync().Result;
                    Keterangan = result;
                    Console.WriteLine(Keterangan);
                    dtFailed.Rows.Add(Keterangan);
                }
            }

            Console.WriteLine("=========================================================================================================");
            Console.WriteLine("==== " + dtSuccess.Rows.Count + " ROW HAS BEEN UPLOADED");
            Console.WriteLine("==== " + dtFailed.Rows.Count + " ROW WAS NOT UPLOADED");
            Console.WriteLine("=========================================================================================================");
        }

  
    }
}
