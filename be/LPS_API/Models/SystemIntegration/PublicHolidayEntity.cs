using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Models.SystemIntegration
{
    public class PublicHolidayEntity : ApiController
    {
        public string DateKey { get; set; }
        public string Date { get; set; }
        public string Day { get; set; }
        public string DaySuffix { get; set; }
        public string Weekday { get; set; }
        public string WeekDayName { get; set; }
        public string IsWeekend { get; set; }
        public string IsHoliday { get; set; }
        public string HolidayText { get; set; }
        public string DOWInMonth { get; set; }
        public string DayOfYear { get; set; }
        public string WeekOfMonth { get; set; }
        public string WeekOfYear { get; set; }
        public string ISOWeekOfYear { get; set; }
        public string Month { get; set; }
        public string MonthName { get; set; }
        public string Quarter { get; set; }
        public string QuarterName { get; set; }
        public string Year { get; set; }
        public string Semester { get; set; }
        public string MMYYYY { get; set; }
        public string MonthYear { get; set; }
        public string FirstDayOfMonth { get; set; }
        public string LastDayOfMonth { get; set; }
        public string FirstDayOfQuarter { get; set; }
        public string LastDayOfQuarter { get; set; }
        public string FirstDayOfYear { get; set; }
        public string LastDayOfYear { get; set; }
        public string FirstDayOfNextMonth { get; set; }
        public string FirstDayOfNextYear { get; set; }
    }
}
