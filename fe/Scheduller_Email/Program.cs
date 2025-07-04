using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LPS_ProjectManagement.Helper;
using Common.Logging;
using Quartz;
using Quartz.Impl;

namespace Scheduller_Email
{

    public class Program
    {
        private static ILog Log = LogManager.GetCurrentClassLogger();
        public static void Main(string[] args)
        {
            //try
            //{
            //    Console.WriteLine("Program is started");
            //    // construct a scheduler factory
            //    ISchedulerFactory schedFact = new StdSchedulerFactory();

            //    // get a scheduler
            //    IScheduler sched = schedFact.GetScheduler();
            //    sched.Start();

            //    IJobDetail jobApprovalPending = JobBuilder.Create<ApprovalPendingJob>()
            //        .WithIdentity("ApprovalPendingEmailJob", "ApprovalPendingEmail")
            //        .Build();

            //    ITrigger triggerApprovalPending = TriggerBuilder.Create()
            //        .WithIdentity("ApprovalPendingEmailTrigger", "ApprovalPendingEmail")
            //        .WithCronSchedule("0 19 12 * * ?")
            //        .Build();

            //    IJobDetail jobRemainderProjectTrans = JobBuilder.Create<RemainderProjectTransJob>()
            //        .WithIdentity("RemainderProjectTransJob", "RemainderProjectTrans")
            //        .Build();

            //    ITrigger triggerRemainderProjectTrans = TriggerBuilder.Create()
            //        .WithIdentity("RemainderProjectTransTrigger", "RemainderProjectTrans")
            //        //.WithCronSchedule("0 0 9 ? * FRI")
            //        .WithCronSchedule("0 19 12 * * ?")
            //        .Build();

            //    //ITrigger triggerRemainderProjectTrans = TriggerBuilder.Create()
            //    //    .WithIdentity("RemainderProjectTransTrigger", "RemainderProjectTrans")
            //    //    .WithCronSchedule("0 50 23 * * ?")
            //    //    .Build();

            //    IJobDetail jobRemainderProjectNonTrans = JobBuilder.Create<RemainderProjectNonTransJob>()
            //        .WithIdentity("RemainderProjectNonTransJob", "RemainderProjectNonTrans")
            //        .Build();

            //    ITrigger triggerRemainderProjectNonTrans = TriggerBuilder.Create()
            //        .WithIdentity("RemainderProjectNonTransTrigger", "RemainderProjectNonTrans")
            //        .WithCronSchedule("0 0 8 5 * ?")
            //        .Build();

            //    IJobDetail jobGenerateKPIValue = JobBuilder.Create<GenerateKPIValueJob>()
            //        .WithIdentity("GenerateKPIValueJob", "GenerateKPIValue")
            //        .Build();

            //    ITrigger triggerGenerateKPIValue = TriggerBuilder.Create()
            //        .WithIdentity("GenerateKPIValueTrigger", "GenerateKPIValue")
            //        //.WithCronSchedule("0 30 5 5 1,4,7,10 ?")
            //        .WithCronSchedule("0 19 12 * * ?")
            //        .Build();

            //    sched.ScheduleJob(jobApprovalPending, triggerApprovalPending);
            //    sched.ScheduleJob(jobRemainderProjectTrans, triggerRemainderProjectTrans);
            //    sched.ScheduleJob(jobRemainderProjectNonTrans, triggerRemainderProjectNonTrans);
            //    sched.ScheduleJob(jobGenerateKPIValue, triggerGenerateKPIValue);
            //}
            //catch (ArgumentException e)
            //{
            //    Log.Error(e);
            //}
            Console.WriteLine("Program is started");
            var datetime = DateTime.Now;
            var dayOfMonth = datetime.Day;
            var dayOfWeek = datetime.DayOfWeek.ToString();
            var month = datetime.Month;
            sending_stat_proyek_transs();
            sending_stat_proyek_transs_norealisation();
            sending_appr_inits();
            if (dayOfWeek == "Friday")
            {
                sending_stat_proyek_transs();
            }
            if (dayOfMonth == 5)
            {
                sending_stat_proyek_nontranss();
            }
            if ((dayOfMonth == 5 && month == 1) || (dayOfMonth == 5 && month == 4) || (dayOfMonth == 5 && month == 7) || (dayOfMonth == 5 && month == 10))
            {
                GenerateKPIValues();
            }
        }

        public static void sending_appr_inits()
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
                    var status = SendEmailApprInits(item.username);
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

        public static string SendEmailApprInits(string username)
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

        public static void sending_stat_proyek_transs()
        {
            HttpClient client = new HttpClient();
            string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EmailIntegration";
            Uri baseAddress = new Uri(url);
            client.BaseAddress = baseAddress;
            client.DefaultRequestHeaders.Accept.Clear();
            var response = client.GetAsync(baseAddress.ToString()).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            List<usernamemodel> username = JsonConvert.DeserializeObject<List<usernamemodel>>(result);
            username = username.Where(x => x.isTransformasi == 1).ToList();
            Console.WriteLine("=========================================================================================================");
            Console.WriteLine("==== Sending Email Status Proyek                                                                                  ====");
            Console.WriteLine("=========================================================================================================");
            foreach (var item in username)
            {
                var status = SendEmailTranss(item.username);
                Console.WriteLine(item.username + " : " + status);
            }
        }

        public static void sending_stat_proyek_transs_norealisation()
        {
            HttpClient client = new HttpClient();
            string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EmailIntegration/GetEmailNorRealisation";
            Uri baseAddress = new Uri(url);
            client.BaseAddress = baseAddress;
            client.DefaultRequestHeaders.Accept.Clear();
            var response = client.GetAsync(baseAddress.ToString()).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            List<usernamemodel> username = JsonConvert.DeserializeObject<List<usernamemodel>>(result);
            username = username.Where(x => x.isTransformasi == 1).ToList();
            Console.WriteLine("=========================================================================================================");
            Console.WriteLine("==== Sending Email Status Proyek No Realization                                                                                  ====");
            Console.WriteLine("=========================================================================================================");
            foreach (var item in username)
            {
                var status = SendEmailTranssNoreal(item.username);
                Console.WriteLine(item.username + " : " + status);
            }
        }

        public static string SendEmailTranss(string username)
        {
            try
            {
                using (var client = new WebClient()) //WebClient  
                {

                    client.Headers.Add("Content-Type:application/json");
                    client.Headers.Add("Accept:application/json");
                    var result = client.DownloadString(ConfigurationManager.AppSettings["WebAPI"].ToString() + "EmailTrans?username=" + username);


                    return Environment.NewLine + result;
                }
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
        }
        public static string SendEmailTranssNoreal(string username)
        {
            try
            {
                using (var client = new WebClient()) //WebClient  
                {

                    client.Headers.Add("Content-Type:application/json");
                    client.Headers.Add("Accept:application/json");
                    var result = client.DownloadString(ConfigurationManager.AppSettings["WebAPI"].ToString() + "EmailTransNoReal?username=" + username);


                    return Environment.NewLine + result;
                }
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
        }

        public static void sending_stat_proyek_nontranss()
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
                var status = SendEmailNonTranss(item.username);
                Console.WriteLine(item.username + " : " + status);
            }
        }
        public static void sending_stat_proyek_nontranss_noreal()
        {
            HttpClient client = new HttpClient();
            string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EmailIntegration/GetEmailNorRealisation";
            Uri baseAddress = new Uri(url);
            client.BaseAddress = baseAddress;
            client.DefaultRequestHeaders.Accept.Clear();
            var response = client.GetAsync(baseAddress.ToString()).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            List<usernamemodel> username = JsonConvert.DeserializeObject<List<usernamemodel>>(result);
            username = username.Where(x => x.isTransformasi == 0).ToList();
            Console.WriteLine("=========================================================================================================");
            Console.WriteLine("==== Sending Email Status Proyek No Realization                                                                               ====");
            Console.WriteLine("=========================================================================================================");
            foreach (var item in username)
            {
                var status = SendEmailNonTranss(item.username);
                Console.WriteLine(item.username + " : " + status);
            }
        }

        public static string SendEmailNonTranss(string username)
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

        public static string SendEmailNonTranssNoReal(string username)
        {
            try
            {
                using (var client = new WebClient()) //WebClient  
                {

                    client.Headers.Add("Content-Type:application/json");
                    client.Headers.Add("Accept:application/json");
                    var result = client.DownloadString(ConfigurationManager.AppSettings["WebAPI"].ToString() + "EmailNonTransNoReal?username=" + username);


                    return Environment.NewLine + result;
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public static void GenerateKPIValues()
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

        public static void sending_appr_exec()
        {
            HttpClient client = new HttpClient();
            string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EmailIntegrationExec";
            Uri baseAddress = new Uri(url);

            client.BaseAddress = baseAddress;

            client.DefaultRequestHeaders.Accept.Clear();

            var response = client.GetAsync(baseAddress.ToString()).Result;
            var result = response.Content.ReadAsStringAsync().Result;

            List<usernamemodel> username = JsonConvert.DeserializeObject<List<usernamemodel>>(result);

            Console.WriteLine("=========================================================================================================");
            Console.WriteLine("==== Sending Email Execution Approval Pending                                                                                  ====");
            Console.WriteLine("=========================================================================================================");

            foreach (var item in username)
            {
                var status = SendEmailApprExec(item.username);
                Console.WriteLine(item.username + " : " + status);
            }
        }

        public static string SendEmailApprExec(string username)
        {
            try
            {
                using (var client = new WebClient()) //WebClient  
                {

                    client.Headers.Add("Content-Type:application/json");
                    client.Headers.Add("Accept:application/json");
                    var result = client.DownloadString(ConfigurationManager.AppSettings["WebAPI"].ToString() + "EmailApprExec?username=" + username);

                    return Environment.NewLine + result;
                }
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
        }

    }

    public class usernamemodel
    {
        public string username { get; set; }
        public int isTransformasi { get; set; }
        public string IDProjectHeader { get; set; }
        public string periode { get; set; }

    }

}
