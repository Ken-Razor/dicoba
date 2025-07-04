using LPS_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPS_BLL
{
    public class Report
    {

        #region Evaluasi Capaian Proyek

        public DataSet Get_Report_EvaluasiCapaianProyek(
            int Month,
            string Year,
            Boolean? IsTransformasi,
            int IDProgram,
            int IDDirektorat,
            int? Week
            )
        {
            var oParameters = new
            {
                Month = Month,
                Year = Year,
                IsTransformasi = IsTransformasi,
                IDProgram = IDProgram,
                IDDirektorat = IDDirektorat,
                Week = Week
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_Get_Report_EvaluasiCapaianProyek", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Get_PDF_EvaluasiCapaianProyek(
            int Month,
            string Year,
            Boolean? IsTransformasi,
            int? IDDirektorat,
            int? Week
            )
        {
            var oParameters = new
            {
                Month = Month,
                Year = Year,
                IsTransformasi = IsTransformasi,
                IDDirektorat = IDDirektorat,
                Week = Week
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_Get_PDF_EvaluasiCapaianProyek", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Get_PDF_EvaluasiCapaianProyek_BroupByDirektorat(
            int Month,
            string Year,
            Boolean? IsTransformasi,
            int? IDDirektorat,
            int? Week
            )
        {
            var oParameters = new
            {
                Month = Month,
                Year = Year,
                IsTransformasi = IsTransformasi,
                IDDirektorat = IDDirektorat,
                Week = Week
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_Get_PDF_EvaluasiCapaianProyek_GroupByDirektorat", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Get_PDF_EvaluasiCapaianProyek_BroupByKategori(
    int Month,
    string Year,
    Boolean? IsTransformasi,
    int? IDDirektorat,
    int? Week
    )
        {
            var oParameters = new
            {
                Month = Month,
                Year = Year,
                IsTransformasi = IsTransformasi,
                IDDirektorat = IDDirektorat,
                Week = Week
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_Get_PDF_EvaluasiCapaianProyek_GroupByKategori", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Get_PDF_EvaluasiCapaianProyek_BroupByKpi(
    int Month,
    string Year,
    Boolean? IsTransformasi,
    int? IDDirektorat,
    int? Week
    )
        {
            var oParameters = new
            {
                Month = Month,
                Year = Year,
                IsTransformasi = IsTransformasi,
                IDDirektorat = IDDirektorat,
                Week = Week
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_Get_PDF_EvaluasiCapaianProyek_GroupByKPI", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Get_List_EvaluasiCapaianProyek(
            int Month,
            string Year,
            Boolean? IsTransformasi,
            int IDDirektorat,
            int? Week
            )
        {
            var oParameters = new
            {
                Month = Month,
                Year = Year,
                IsTransformasi = IsTransformasi,
                IDDirektorat = IDDirektorat,
                Week = Week
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_Get_List_EvaluasiCapaianProyek", oParameters);
                return data.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        public DataSet Get_Report_ProjectCharter( int ProjectHeaderID )
        {
            var oParameters = new
            {
                ProjectHeaderID = ProjectHeaderID
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_Get_ReportProjectCharter", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Get_Report_Summary(int Month, string Year)
        {
            var oParameters = new
            {
                Month = Month,
                Year = Year
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_Report_Summary", oParameters,true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Get_Report_PencapaianTransformasi(int week , int month , int year , int tipe)
        {
            var oParameters = new
            {
                week        = week,
                month       = month,
                year        = year,
                tipe        = tipe
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_Report_SummaryTransformasiNonTransformasi", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Get_Report_PencapaianSO(int week, int month, int year)
        {
            var oParameters = new
            {
                week = week,
                month = month,
                year = year
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_Report_SummaryPerSO", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Get_Report_PencapaianDirektorat(int week, int month, int year)
        {
            var oParameters = new
            {
                week = week,
                month = month,
                year = year
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_Report_SummaryPerDirektorat", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Get_Report_CapaianProyek(int tipe, int week, int month, int year)
        {
            var oParameters = new
            {
                week = week,
                month = month,
                year = year,
                tipe = tipe
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_Report_SummaryTransformasiNonTransformasi", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Get_Notification(string PersonNumber)
        {
            var oParameters = new
            {
                PersonNumber = PersonNumber
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_Notifikasi", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<object> Get_ReportKendala(string Year, string Month, string Week)
        {
            var oParameters = new
            {
                Year = Year,
                Month = Month,
                Week = Week
            };
            try
            {
                List<object> ds = DbTransaction.DbToList<object>("Usp_Get_RekapKendala", oParameters, true);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataTable Get_Notification_ECM(string PersonNumber)
        {
            var oParameters = new
            {
                namauser = PersonNumber
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_Notifikasi_ECM", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region All Data & Weekly Report
        
        public DataSet Get_Excel_AllDataRow(string Year, string Month, string Week, string IsTransformasi, string StatusProjectHeader)
        {
            var oParameters = new
            {
                Year = Year,
                Month = Month,
                Week = Week,
                IsTransformasi = IsTransformasi,
                StatusProjectHeader = StatusProjectHeader
            };
            try
            {
                DataSet ds = DbTransaction.DbToDataSet("Usp_Get_Excel_AllDataRow", oParameters);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Get_Report_Weekly(string Year, string Month, string Week, string IsTransformasi, string UnitKerja, string UsernamePMO, string UsernameOwner, string UsernameSponsor)
        {
            var oParameters = new
            {
                Year = Year,
                Month = Month,
                Week = Week,
                IsTransformasi = IsTransformasi,
                UnitKerja = UnitKerja,
                UsernamePMO = UsernamePMO,
                UsernameOwner = UsernameOwner,
                UsernameSponsor = UsernameSponsor
            };
            try
            {
                DataSet ds = DbTransaction.DbToDataSet("Usp_Get_Report_Weekly", oParameters);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Get_Report_WeeklyMonitoring(string Year, string Month, string Week, string IsTransformasi, string UnitKerja, string UsernamePMO)
        {
            var oParameters = new
            {
                Year = Year,
                Month = Month,
                Week = Week,
                IsTransformasi = IsTransformasi,
                UnitKerja = UnitKerja,
                UsernamePMO = UsernamePMO
            };
            try
            {
                DataSet ds = DbTransaction.DbToDataSet("Usp_Get_Report_WeeklyMonitoring", oParameters);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Get_DropdownPMO(string Year, string Month, string Week)
        {
            var oParameters = new
            {
                Year = Year,
                Month = Month,
                Week = Week
            };
            try
            {
                DataTable dt = DbTransaction.DbToDataTable("Usp_Get_DropdownPMO", oParameters, true);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Get_DropdownOwner(string Year, string Month, string Week)
        {
            var oParameters = new
            {
                Year = Year,
                Month = Month,
                Week = Week
            };
            try
            {
                DataTable dt = DbTransaction.DbToDataTable("Usp_Get_DropdownOwner", oParameters, true);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Get_DropdownSponsor(string Year, string Month, string Week)
        {
            var oParameters = new
            {
                Year = Year,
                Month = Month,
                Week = Week
            };
            try
            {
                DataTable dt = DbTransaction.DbToDataTable("Usp_Get_DropdownSponsor", oParameters, true);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Get_DropdownMasterStatus()
        {
            var oParameters = new
            {

            };
            try
            {
                DataTable dt = DbTransaction.DbToDataTable("Usp_Get_DropdownMasterStatus", oParameters, true);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Report Anggaran

        public DataSet Get_Detail_AnggaraHeader(int IDDirektorat)
        {
            var oParameters = new
            {
                IDDirektorat = IDDirektorat
            };
            try
            {
                DataSet ds = DbTransaction.DbToDataSet("Usp_Get_Report_DetailAnggaran_Header", oParameters);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Get_Detail_Anggaran(int IDDirektorat, int IDDepartment, string Year, string IDSAP)
        {
            var oParameters = new
            {
                IDDirektorat = IDDirektorat,
                IDDepartment = IDDepartment,
                Year = Year,
                IDSAP = IDSAP
            };
            try
            {
                DataSet ds = DbTransaction.DbToDataSet("Usp_Get_Report_DetailAnggaran", oParameters);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Report Tren

        public DataSet Get_Report_TrenPencapaian(int Year, int Month)
        {
            var oParameters = new
            {
                Year = Year,
                Month = Month
            };
            try
            {
                DataSet ds = DbTransaction.DbToDataSet("Usp_Get_Report_TrenPencapaian", oParameters);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        public DataTable Get_ReportSeriesPerYear(int thn1, int thn2)
        {
            var oParameters = new
            {
                thn1 = thn1,
                thn2 = thn2
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_ReportSeriesPerYear", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Get_ReportSummaryPenyampaian()
        {
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_ReportSummaryPenyampaian", true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Get_ReportGptf(int month,string year)
        {
            var oParameters = new
            {
                Month = month,
                Year = year
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_Get_ReportGptf2",oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
