using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Scheduller_Calendar
{
    class Program
    {
        static void Main(string[] args)
        {

            var result = Date();
            Console.WriteLine(result);

        }

        public static string Date()
        {
            try
            {
                using (var client = new WebClient()) //WebClient  
                {

                    client.Headers.Add("Content-Type:application/json");
                    client.Headers.Add("Accept:application/json");
                    //var result = client.DownloadString(ConfigurationManager.AppSettings["WebAPI"].ToString() + "Holiday/GetHoliday");
                    var result = client.DownloadString(ConfigurationManager.AppSettings["WebAPI"].ToString() + "PublicHolidayIntegration");


                    return Environment.NewLine + result;
                }
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
        }

    }
}



