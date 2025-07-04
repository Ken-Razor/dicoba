using Quartz;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Scheduller_Email
{
    public class GenerateKPIValueJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            GenerateKPIValue();
        }

        public static void GenerateKPIValue()
        {
            Console.WriteLine("=========================================================================================================");
            Console.WriteLine("==== Generating KPI Value                                                                            ====");
            Console.WriteLine("=========================================================================================================");
            try
            {
                using (var client = new WebClient()) //WebClient  
                {

                    client.Headers.Add("Content-Type:application/json");
                    client.Headers.Add("Accept:application/json");
                    var result = client.DownloadString(ConfigurationManager.AppSettings["WebAPI"].ToString() + "GenerateKPIValueJob");

                    Console.WriteLine(Environment.NewLine + result);
                }
            }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.ToString());
             }
        }
    }
}
