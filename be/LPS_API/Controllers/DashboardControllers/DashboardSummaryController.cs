using LPS_API.Models.DashboardModels.DashboardSummary;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.DashboardControllers
{
    public class DashboardSummaryController : ApiController
    {
        public DashboardSummaryModel Post(DashboardSummaryModel param)
        {
            DashboardSummaryModel DashboardSummaryModel = new DashboardSummaryModel();
            List<StakedBar> ListStakedBar = new List<StakedBar>();
            DashboardData dd = new DashboardData();
            DataTable dt = new DataTable();

            dt = dd.GetDashboardSummary(param.Filter, param.Year, param.Month, param.Week, param.PersonalNumber);

            DashboardSummaryModel.Filter = param.Filter;
            DashboardSummaryModel.Year = param.Year;
            DashboardSummaryModel.Month = param.Month;
            DashboardSummaryModel.Week = param.Week;

            string[] x = new string[dt.Rows.Count];

            for(int i=0; i<dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i]["Name"].ToString();
            }

            DashboardSummaryModel.Categories = x;

            for (int i=2; i<dt.Columns.Count - 1; i++)
            {
                StakedBar StakedBar = new StakedBar();
                int[] Data = new int[dt.Rows.Count];
                string Name = dt.Columns[i].ColumnName;

                if (Name == "BelumDimulai") Name = "Belum Dimulai";
                if (Name == "Completed") Name = "Completed";
                if (Name == "JauhDibawahTarget") Name = "Jauh Dibawah Target";
                if (Name == "DibawahTarget") Name = "Dibawah Target";
                if (Name == "SesuaiTarget") Name = "Sesuai Target";
                if (Name == "DiatasTarget") Name = "Diatas Target";

                string Color = "";
                if (i == 2) Color = "#dcddde";
                if (i == 3) Color = "#58595b";
                if (i == 4) Color = "#d85d5d";
                if (i == 5) Color = "#efd31c";
                if (i == 6) Color = "#6dff66";
                if (i == 7) Color = "#6663ff";

                //StakedBar.id = Convert.ToInt32(dt.Rows[j]["ID"]);
                StakedBar.color = Color;
                StakedBar.name = Name;

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (i == 2)
                    {
                        Data[j] = Convert.ToInt32(dt.Rows[j]["BelumDimulai"]);
                    }
                    else if (i == 3)
                    {
                        Data[j] = Convert.ToInt32(dt.Rows[j]["Completed"]);
                    }
                    else if (i == 4)
                    {
                        Data[j] = Convert.ToInt32(dt.Rows[j]["JauhDibawahTarget"]);
                    }
                    else if (i == 5)
                    {
                        Data[j] = Convert.ToInt32(dt.Rows[j]["DibawahTarget"]);
                    }
                    else if (i == 6)
                    {
                        Data[j] = Convert.ToInt32(dt.Rows[j]["SesuaiTarget"]);
                    }
                    else if(i == 7)
                    {
                        Data[j] = Convert.ToInt32(dt.Rows[j]["DiatasTarget"]);
                    }
                }

                StakedBar.data = Data;

                ListStakedBar.Add(StakedBar);
            }
            DashboardSummaryModel.ListStakedBar = ListStakedBar;
            return DashboardSummaryModel;
        }
    }
}
