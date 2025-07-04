using Newtonsoft.Json;
using Quartz;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Scheduller_Email
{
    public class RemainderProjectNonTransJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            sending_stat_proyek_nontrans();
        }

        public static void sending_stat_proyek_nontrans()
        {
            HttpClient client = new HttpClient();
            string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EmailIntegration";
            Uri baseAddress = new Uri(url);
            client.BaseAddress = baseAddress;
            client.DefaultRequestHeaders.Accept.Clear();
            var response = client.GetAsync(baseAddress.ToString()).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            List<usernamemodel> username = JsonConvert.DeserializeObject<List<usernamemodel>>(result);
            username = username.Where(x => x.isTransformasi == 0).ToList();
            Console.WriteLine("=========================================================================================================");
            Console.WriteLine("==== Sending Email Status Proyek                                                                                  ====");
            Console.WriteLine("=========================================================================================================");
            foreach (var item in username)
            {
                var status = SendEmailNonTrans(item.username);
                Console.WriteLine(item.username + " : " + status);
            }
        }

        public static string SendEmailNonTrans(string username)
        {
            try
            {
                using (var client = new WebClient()) //WebClient  
                {

                    client.Headers.Add("Content-Type:application/json");
                    client.Headers.Add("Accept:application/json");
                    var result = client.DownloadString(ConfigurationManager.AppSettings["WebAPI"].ToString() + "EmailNonTrans?username=" + username);


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
