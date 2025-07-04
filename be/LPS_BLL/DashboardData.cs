using LPS_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPS_BLL
{
    public class DashboardData
    {
        public DataTable DashboardProjectStatus()
        {
            var oParameters = new
            {
                //currentMonth = CurrentMonth,
                //currentYear = CurrentYear
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Get_DashboardProjectStatus", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable DashboardTransformation()
        {
            var oParameters = new
            {
                //currentMonth = CurrentMonth,
                //currentYear = CurrentYear
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Get_DashboardTransformation", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable DashboardAllStatus()
        {
            var oParameters = new
            {
                //currentMonth = CurrentMonth,
                //currentYear = CurrentYear
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Get_AllStatusDashboard", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable DashboardProjectDepartment()
        {
            var oParameters = new
            {
                //currentMonth = CurrentMonth,
                //currentYear = CurrentYear
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Get_TableProjectDepartment", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable DashboardTransformationGraph()
        {
            var oParameters = new
            {
                //currentMonth = CurrentMonth,
                //currentYear = CurrentYear
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Get_DashboardTransformationGraph", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable DashboardSO()
        {
            var oParameters = new
            {
                //currentMonth = CurrentMonth,
                //currentYear = CurrentYear
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Get_DashboardSOChart", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable DashboardSOUsed()
        {
            var oParameters = new
            {
                //currentMonth = CurrentMonth,
                //currentYear = CurrentYear
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Get_SOUsed", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DashboardProjectTypeSO(string SOId)
        {
            var oParameters = new
            {
                StrategicObjective = SOId
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Get_ProjectTypeDashboardSO", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DashboardSO(string Filter, string Code, int? IsTransformasi, string Year, int Month, int Week)
        {
            var oParameters = new
            {
                Filter =Filter,
                Code= Code,
                IsTransformasi= IsTransformasi,
                Year= Year,
                Month= Month,
                Week= Week
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Get_DashboardSummaryStatus", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable DashboardProjectListSO(string statusProject, int ProjectType, string SO)
        {
            var oParameters = new
            {
                StatusName = statusProject,
                 isTransformation = ProjectType,
                StrategicObjective = SO
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Get_ProjectListDashboardSO", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DashboardProjectDetails(string IDProjectHeader, int month , int year , int week )
        {
            var oParameters = new
            {
                ProjectHeaderID = IDProjectHeader,
                week       = week                ,
                month      = month               ,
                year       = year                
                //currentYear = CurrentYear
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Get_DashboardProjectDetail", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region FIN

        public DataSet DashboardMainRibbonExcecutive()
        {
            var oParameters = new
            {
                //currentMonth = CurrentMonth,
                //currentYear = CurrentYear
            };
            try
            {
                DataSet ds = DbTransaction.DbToDataSet("Usp_Main_Ribbon_Executive", oParameters);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetBerandaProjectHeader(string Year, int? Month, int? Day)
        {
            var oParameters = new
            {
                Year = Year,
                Month = Month,
                Day = Day
            };
            try
            {
                DataTable dt = DbTransaction.DbToDataTable("Get_BerandaProjectHeader", oParameters, true);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDashboardProjectHeader(string Filter, string Year, int Month, int Week, string PersonalNumber)
        {
            var oParameters = new
            {
                Filter = Filter,
                Year = Year,
                Month = Month,
                Week = Week,
                PersonalNumber = PersonalNumber
            };
            try
            {
                DataSet ds = DbTransaction.DbToDataSet("Get_DashboardProjectHeader", oParameters);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDashboardTransAndNoTrans(string Year, int Month, int Week, string PersonalNumber)
        {
            var oParameters = new
            {
                Year = Year,
                Month = Month,
                Week = Week,
                PersonalNumber = PersonalNumber
            };
            try
            {
                DataTable dt = DbTransaction.DbToDataTable("Get_DashboardTransAndNoTrans", oParameters,true);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataTable GetDashboardPenggunaan(string Year, int MonthStart, int MontEnd, int isTransformasi)
        {
            var oParameters = new
            {
                Year = Year,
                MonthStart = MonthStart,
                MonthEnd = MontEnd,
                IsTranformasi = isTransformasi
            };
            try
            {
                DataTable dt = DbTransaction.DbToDataTable("Usp_Get_Dashboard_Penggunaan", oParameters, true);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDashboardProjectOverall(string Filter, string Year, string PersonalNumber)
        {
            var oParameters = new
            {
                Filter = Filter,
                Year = Year,
                PersonalNumber = PersonalNumber
            };
            try
            {
                DataTable dt = DbTransaction.DbToDataTable("Get_DashboardProjectOverall", oParameters, true);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDashboardProjectTimeSeries(string Filter, int Year, int Month, int Week, string PersonalNumber)
        {
            var oParameters = new
            {
                Filter = Filter,
                Year = Year,
                Month = Month,
                Week = Week,
                PersonalNumber = PersonalNumber
            };
            try
            {
                DataTable dt = DbTransaction.DbToDataTable("Get_DashboardProjectTimeSeries", oParameters, true);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetSeriesGrafik(string Filter, int Year, int Month, int Week, string PersonalNumber)
        {
            var oParameters = new
            {
                Filter = Filter,
                Year = Year,
                Month = Month,
                Week = Week,
                PersonalNumber = PersonalNumber
            };
            try
            {
                DataTable dt = DbTransaction.DbToDataTable("Get_SeriesGrafik", oParameters, true);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDashboardProjectProgress(string Year, int Month, string Filter, int Week, string PersonalNumber)
        {
            var oParameters = new
            {
                Year = Year,
                Month = Month,
                Filter = Filter,
                Week = Week,
                PersonalNumber = PersonalNumber
            };
            try
            {
                DataTable dt = DbTransaction.DbToDataTable("Get_DashboardProjectProgress", oParameters, true);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Get_DashboardProjectProgressPerProject(string Year, int Month, string Filter, int Week, string PersonalNumber)
        {
            var oParameters = new
            {
                Year = Year,
                Month = Month,
                Filter = Filter,
                Week = Week,
                PersonalNumber = PersonalNumber
            };
            try
            {
                DataTable dt = DbTransaction.DbToDataTable("Get_DashboardProjectProgressPerProject", oParameters, true);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDashboardSummary(string Filter, string Year, int Month, int Week, string PersonalNumber)
        {
            var oParameters = new
            {
                Filter = Filter,
                Year = Year,
                Month = Month,
                Week = Week,
                PersonalNumber = PersonalNumber
            };
            try
            {
                DataTable dt = DbTransaction.DbToDataTable("Get_DashboardSummary", oParameters, true);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDashboardSummaryHeader(string Filter, string Year, int Month, int Week, string ID)
        {
            var oParameters = new
            {
                Year = Year,
                Month = Month,
                Filter = Filter,
                Week = Week,
                ID = ID
            };
            try
            {
                DataSet ds = DbTransaction.DbToDataSet("Get_DashboardSummaryHeader", oParameters);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GenerateDashboard()
        {
            var oParameters = new
            {
                Date = DateTime.Now,
                Year = DateTime.Now.Year,
                Month = DateTime.Now.Month,
                Day = DateTime.Now.Day
            };
            try
            {
                DataTable dt = DbTransaction.DbToDataTable("GenerateDashboard", oParameters, true);
                string Result = dt.Rows[0]["Result"].ToString();
                return Result;
            }
            catch (Exception ex)
            {
                return "Internal Server Error : " + ex.Message;
            }
        }

        public string GenerateDashboard2()
        {
            var oParameters = new
            {
                Date = DateTime.Now,
                Year = DateTime.Now.Year,
                Month = DateTime.Now.Month,
                Day = DateTime.Now.Day
            };
            try
            {
                DataTable dt = DbTransaction.DbToDataTable("GenerateDashboard2", oParameters, true);
                string Result = dt.Rows[0]["Result"].ToString();
                return Result;
            }
            catch (Exception ex)
            {
                return "Internal Server Error : " + ex.Message;
            }
        }

        #endregion
    }
}
