using LPS_ProjectManagement.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using LPS_ProjectManagement.Models.MasterDataModels;
using LPS_ProjectManagement.Models.UserManagementModels;

namespace LPS_ProjectManagement.Helper
{
    public class GlobalHelper
    {
        public string getMonthName(int MonthNumber)
        {
            string MonthName = "";
            if (MonthNumber == 01 || MonthNumber == 1 )
            {
                MonthName = "Januari";
            }
            else
            if (MonthNumber == 02 || MonthNumber == 2)
            {
                MonthName = "Februari";
            }
            else
            if (MonthNumber == 03 || MonthNumber == 3)
            {
                MonthName = "Maret";
            }
            else
            if (MonthNumber == 04|| MonthNumber == 4)
            {
                MonthName = "April";
            }
            else
            if (MonthNumber == 05 || MonthNumber == 5)
            {
                MonthName = "Mei";
            }
            else
            if (MonthNumber == 06 || MonthNumber == 6)
            {
                MonthName = "Juni";
            }
            else
            if (MonthNumber == 07 || MonthNumber == 7)
            {
                MonthName = "Juli";
            }
            else
            if (MonthNumber == 08 || MonthNumber == 8)
            {
                MonthName = "Agustus";
            }
            else
            if (MonthNumber == 09 || MonthNumber == 9)
            {
                MonthName = "September";
            }
            else
            if (MonthNumber == 10)
            {
                MonthName = "Oktober";
            }
            else
            if (MonthNumber == 11 )
            {
                MonthName = "November";
            }
            else
            if (MonthNumber == 12)
            {
                MonthName = "Desember";
            }
            else
            {
                MonthName = "Bukan Bulan";
            }

            return MonthName;
        }

        public static List<DropDownMonth> ListDropDowMonth()
        {
            List<DropDownMonth> lddm = new List<DropDownMonth>();

            DropDownMonth DropDownMonth = new DropDownMonth();
            DropDownMonth.Month = 1;
            DropDownMonth.Description = "Januari";
            lddm.Add(DropDownMonth);

            DropDownMonth = new DropDownMonth();
            DropDownMonth.Month = 2;
            DropDownMonth.Description = "Februari";
            lddm.Add(DropDownMonth);

            DropDownMonth = new DropDownMonth();
            DropDownMonth.Month = 3;
            DropDownMonth.Description = "Maret";
            lddm.Add(DropDownMonth);

            DropDownMonth = new DropDownMonth();
            DropDownMonth.Month = 4;
            DropDownMonth.Description = "April";
            lddm.Add(DropDownMonth);

            DropDownMonth = new DropDownMonth();
            DropDownMonth.Month = 5;
            DropDownMonth.Description = "Mei";
            lddm.Add(DropDownMonth);

            DropDownMonth = new DropDownMonth();
            DropDownMonth.Month = 6;
            DropDownMonth.Description = "Juni";
            lddm.Add(DropDownMonth);

            DropDownMonth = new DropDownMonth();
            DropDownMonth.Month = 7;
            DropDownMonth.Description = "Juli";
            lddm.Add(DropDownMonth);

            DropDownMonth = new DropDownMonth();
            DropDownMonth.Month = 8;
            DropDownMonth.Description = "Agustus";
            lddm.Add(DropDownMonth);

            DropDownMonth = new DropDownMonth();
            DropDownMonth.Month = 9;
            DropDownMonth.Description = "September";
            lddm.Add(DropDownMonth);

            DropDownMonth = new DropDownMonth();
            DropDownMonth.Month = 10;
            DropDownMonth.Description = "Oktober";
            lddm.Add(DropDownMonth);

            DropDownMonth = new DropDownMonth();
            DropDownMonth.Month = 11;
            DropDownMonth.Description = "November";
            lddm.Add(DropDownMonth);

            DropDownMonth = new DropDownMonth();
            DropDownMonth.Month = 12;
            DropDownMonth.Description = "Desember";
            lddm.Add(DropDownMonth);

            return lddm;
        }

        public static List<DropDownForecastMethod> ListForecastMethod()
        {
            List<DropDownForecastMethod> fm = new List<DropDownForecastMethod>()
            {
                new DropDownForecastMethod{ Id = 1, Description = "Naive" },
                new DropDownForecastMethod{ Id = 2, Description = "Single Moving Average" },
                new DropDownForecastMethod{ Id = 3, Description = "Weight Moving Average" },
                new DropDownForecastMethod{ Id = 4, Description = "Exponential Smoothing" },
                new DropDownForecastMethod{ Id = 5, Description = "Adaptive Rate Smoothing" },
                new DropDownForecastMethod{ Id = 6, Description = "Linear Regression" }
            };

            return fm;
        }

        public static List<DropDownCategorySeriesCapaiantMethod> ListCategorySeriesCapaianMethod()
        {
            List<DropDownCategorySeriesCapaiantMethod> fm = new List<DropDownCategorySeriesCapaiantMethod>()
            {
                new DropDownCategorySeriesCapaiantMethod{ Id = "SO", Description = "SO" },
                new DropDownCategorySeriesCapaiantMethod{ Id = "Kpi", Description = "KPI" },
                new DropDownCategorySeriesCapaiantMethod{ Id = "Direktorat", Description = "Direktorat" },
                new DropDownCategorySeriesCapaiantMethod{ Id = "KategoriProyek", Description = "Kategori Proyek" },
                new DropDownCategorySeriesCapaiantMethod{ Id = "JenisProyek", Description = "Jenis Proyek" }
            };

            return fm;
        }


        public string GetProjectName(int ProjectHeaderID)
        {
            HttpClient client = new HttpClient();
            string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "ProjectName?ProjectHeaderID=" + ProjectHeaderID;
            Uri baseAddress = new Uri(url);

            client.BaseAddress = baseAddress;
            client.DefaultRequestHeaders.Accept.Clear();

            var response = client.GetAsync(baseAddress.ToString()).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            var val = result.Remove(0, 1);
            var val1 = val.Remove(val.Length - 1);
            return val1;
        }

        public string GetProjectNameMaster(int IDProject)
        {
            try
            {
                ProjectModel pm = new ProjectModel();
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "MasterProject";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;
                pm.IDProject = IDProject;


                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), pm).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                ProjectModel ProjectModel = JsonConvert.DeserializeObject<ProjectModel>(result);

                return ProjectModel.ProjectName;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public string SendEmail(string IDProjectHeader, string Periode , string tipe)
        {
            try
            {
                EmailModel em = new EmailModel();
                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "EmailIntegration";
                Uri baseAddress = new Uri(url);
                em.IDProjectHeader = IDProjectHeader;
                em.Periode = Periode;
                em.Type = tipe;

                client.BaseAddress = baseAddress;
               

                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), em).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                string res = JsonConvert.DeserializeObject<string>(result);

                return res;
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
        }

        public static List<int> ListDropDownYear(int yearBack = 0, bool sortAscending = true)
        {
            List<int> lddy = new List<int>();

            if (sortAscending && yearBack >= 0)
            {
                for (int i = 0; i <= yearBack; i++)
                {
                    lddy.Add(DateTime.Now.Year + i);
                }
            }
            else if (sortAscending && yearBack <= 0)
            {
                for (int i = 0; i >= yearBack; i--)
                {
                    lddy.Add(DateTime.Now.Year + yearBack - i);
                }
            }
            else if (!sortAscending && yearBack >= 0)
            {
                for (int i = 0; i <= yearBack; i++)
                {
                    lddy.Add(DateTime.Now.Year + yearBack - i);
                }
            }
            else if (!sortAscending && yearBack <= 0)
            {
                for (int i = 0; i >= yearBack; i--)
                {
                    lddy.Add(DateTime.Now.Year + i);
                }
            }

            return lddy;
        }

        public static int NumberOfWeekInMonth(int year, int month)
        {
            int daysInMonth = DateTime.DaysInMonth(year, month);
            return NumberOfWeekInMonth(year, month, daysInMonth);
        }

        public static int NumberOfWeekInMonth(int year, int month, int daysInMonth)
        {
            //extract the month
            var firstOfMonth = new DateTime(year, month, 1);
            //days of week starts by default as Sunday = 0
            var firstDayOfMonth = (int)firstOfMonth.DayOfWeek;
            var weeksInMonth = (int)Math.Ceiling((firstDayOfMonth + daysInMonth) / 7.0);

            return weeksInMonth;
        }

        public static List<int> ListDropDownWeek(int year, int month, bool untilToday = false)
        {
            int daysInMonth = untilToday ? DateTime.Now.Day : DateTime.DaysInMonth(year, month);
            List<int> lddw = new List<int>();
            int numberOfWeek = NumberOfWeekInMonth(year, month, daysInMonth);

            return lddw;
        }

        public string CheckMilestone(string ProjectHeaderID , string taskID )
        {

            try
            {
                MultiPorpose MP = new MultiPorpose();


                HttpClient client = new HttpClient();
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "Milestone";
                Uri baseAddress = new Uri(url);

                client.BaseAddress = baseAddress;
                MP.ID = taskID + "|" + ProjectHeaderID;


                client.DefaultRequestHeaders.Accept.Clear();

                var response = client.PostAsJsonAsync(baseAddress.ToString(), MP).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                //string status = JsonConvert.DeserializeObject<string>(result);
               
                return result;
            }
            catch (Exception)
            {

                return "Error";
            }
        
        }

        public string ToRupiah(string angka)
        {
            string result = "";
            string F = "";
            string L1 = "";
            string L2 = "";
            string L3 = "";
            string L4 = "";
            string L5 = "";
            string L6 = "";

            if (angka.Length > 3)
            {
                L1 = "." + angka.Substring(angka.Length - 3, 3);
                F = angka.Substring(0, angka.Length - 3);
            }
            if (angka.Length > 6)
            {
                L2 = "." + angka.Substring(angka.Length - 6, 3);
                F = angka.Substring(0, angka.Length - 6);
            }
            if (angka.Length > 9)
            {
                L3 = "." + angka.Substring(angka.Length - 9, 3);
                F = angka.Substring(0, angka.Length - 9);
            }
            if (angka.Length > 12)
            {
                L4 = "." + angka.Substring(angka.Length - 12, 3);
                F = angka.Substring(0, angka.Length - 12);
            }
            if (angka.Length > 15)
            {
                L5 = "." + angka.Substring(angka.Length - 15, 3);
                F = angka.Substring(0, angka.Length - 15);
            }
            if (angka.Length > 18)
            {
                L6 = "." + angka.Substring(angka.Length - 18, 3);
                F = angka.Substring(0, angka.Length - 18);
            }

            if (angka.Length <= 3)
            {
                result = "Rp" + angka + ",-";
            }
            else
            {
                result = "Rp" + F + L6 + L5 + L4 + L3 + L2 + L1 + ",-";
            }

            return result;

        }

        public string GetRoot(int ProjectHeaderID)
        {
            HttpClient client = new HttpClient();
            string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "GetRoot?ProjectHeaderID=" + ProjectHeaderID;
            Uri baseAddress = new Uri(url);

            client.BaseAddress = baseAddress;
            client.DefaultRequestHeaders.Accept.Clear();

            var response = client.GetAsync(baseAddress.ToString()).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            var val = result.Remove(0, 1);
            var val1 = val.Remove(val.Length - 1);
            return val1;
        }

    }
}