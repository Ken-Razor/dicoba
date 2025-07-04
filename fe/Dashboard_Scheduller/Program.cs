using System;
using System.Net.Http;
using System.Configuration;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using System.Threading;

namespace Dashboard_Scheduller
{
    class Program
    {
        static void Main(string[] args)
        {
            Dashboard();
        }

        protected static void Dashboard()
        {
            try
            {

                Console.WriteLine("---------------");
                Console.WriteLine("-----MULAI-----");
                Console.WriteLine("---------------");

                HttpClient client = new HttpClient();
                string Method = ConfigurationManager.AppSettings["Method"].ToString();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + Method;
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;
                client.Timeout = new TimeSpan(3, 0, 0);
                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.GetAsync(baseAddress.ToString()).Result;
                
                var result = response.Content.ReadAsStringAsync().Result;

                string Hasil = JsonConvert.DeserializeObject<string>(result);

                Console.WriteLine("-- "+Hasil+" --");
                Console.WriteLine("---------------");

                Thread.Sleep(5000);

                Console.WriteLine("----SELESAI----");
                Console.WriteLine("---------------");

                Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
                Console.WriteLine("-----ERROR-----");
                Console.WriteLine("---------------");
                Console.WriteLine(ex.Message);

                Thread.Sleep(5000);

            }
        }
    }
}
