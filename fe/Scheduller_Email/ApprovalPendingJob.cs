using LPS_ProjectManagement.Helper;
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
    public class ApprovalPendingJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            sending_appr_init();
        }

        public static void sending_appr_init()
        {
            try
            {
                GlobalHelper gh = new GlobalHelper();

                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EmailIntegration/GetEmailApprovalPending";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.GetAsync(baseAddress.ToString()).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                List<usernamemodel> usernamemdl = JsonConvert.DeserializeObject<List<usernamemodel>>(result);
                Console.WriteLine("=========================================================================================================");
                Console.WriteLine("==== Sending Email Initiation Approval Pending                                                       ====");
                Console.WriteLine("=========================================================================================================");

                foreach (var item in usernamemdl)
                {
                    var status = SendEmailApprInit(item.username);
                    Console.WriteLine(item.username + " : " + status);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
            //var status = SendEmailApprInit();
            //Console.WriteLine(status);
        }

        public static string SendEmailApprInit(string username)
        {
            try
            {
                using (var client = new WebClient()) //WebClient  
                {

                    client.Headers.Add("Content-Type:application/json");
                    client.Headers.Add("Accept:application/json");
                    var result = client.DownloadString(ConfigurationManager.AppSettings["WebAPI"].ToString() + "EmailApprInit?username=" + username);
                    //var result = client.DownloadString(ConfigurationManager.AppSettings["WebAPI"].ToString() + "EmailApprInit");


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
