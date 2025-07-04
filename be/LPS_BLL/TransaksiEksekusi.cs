using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPS_DAL;
namespace LPS_BLL
{
    public class TransaksiEksekusi
    {
        MasterData MD = new MasterData();
        public List<object> GetListEksekusi(string personnumber )
        {

            var oParameters = new
            {
                personnumber = personnumber
            };
            try
            {
                var data = DbTransaction.DbToList<object>("Usp_Get_ProjectEksekusiList", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDetailEksekusi(int IDPRoject, string Periode, string Persnum)
        {

            var oParameters = new
            {
                ProjectHeaderID = IDPRoject,
                Periode = Periode,
                Persnum = Persnum
            };
            try
            {
                var data = DbTransaction.DbToDataSet("Usp_Get_ProjectEksekusiDetail", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetMPPProject(int IDPRoject, string periode)
        {

            var oParameters = new
            {
                ProjectHeaderID = IDPRoject,
                Periode = periode
            };
            try
            {
                var data = DbTransaction.DbToDataSet("Usp_Get_MPPProjectEksekusi", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetExecutionReport(int IDProjectHeader, int IsTransformasi)
        {
            var oParameters = new
            {
                IDProjectHeader = IDProjectHeader,
                Tipe = IsTransformasi
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_ProjectEksekusiReportPerPeriode", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDetailMilestone(int IDPRoject, Int64 TaskID)
        {
            //var ID = Convert.ToInt32(MD.Get_Root(IDPRoject));
            var oParameters = new
            {
                ProjectHeaderID = IDPRoject,
                TaskID = TaskID
            };
            try
            {
                var data = DbTransaction.DbToDataSet("Usp_Get_ProjectEksekusiMilestonesDetail", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string InsertEksekusi(int IDPRoject, DataTable dtTask , string PersonNumber , DataTable Constraint , string status, string Periode, DataTable dtRole, string year , int month , int week)
        {

            var oParameters = new
            {
                ProjectHeaderID = IDPRoject,
                dtType = dtTask,
                PersonNumber = PersonNumber,
                dtConstraint = Constraint,
                Status = status,
                Periode = Periode,
                dtApproval = dtRole,
                Year    = year,
                Month   = month,
                Week    = week
            };
            try
            {
                var data = DbTransaction.DbToString("Usp_Insert_ProjectEksekusi", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string UploadFile(int IDDocumentType , int ProjectHeaderID,  string DocumentName , int IDDocumentPhase, string Personnumber, Int64 TaskID)
        {

            var oParameters = new
            {
                personnumber          = Personnumber ,
                documentname          = DocumentName ,
                doctype               = IDDocumentType ,
                docphase              = IDDocumentPhase ,
                ProjectHeaderID       = ProjectHeaderID ,
                TaskID                = TaskID
            };

            try
            {
                var data = DbTransaction.DbToString("Usp_Upload_File", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string UploadFileandGetId(int IDDocumentType, int ProjectHeaderID, string DocumentName, int IDDocumentPhase, string Personnumber, Int64 TaskID)
        {

            var oParameters = new
            {
                personnumber = Personnumber,
                documentname = DocumentName,
                doctype = IDDocumentType,
                docphase = IDDocumentPhase,
                ProjectHeaderID = ProjectHeaderID,
                TaskID = TaskID
            };

            try
            {
                var data = DbTransaction.DbToString("Usp_Upload_File_andgetId", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteMilestone(int ProjectHeaderID, Int64 TaskID, int IDDoc)
        {

            var oParameters = new
            {
                ProjectHeaderID = ProjectHeaderID,
                TaskID = TaskID,
                IDDoc = IDDoc
            };

            try
            {
                var data = DbTransaction.DbToString("Usp_Delete_FileMilestone", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ApproveEksekusi(int ProjectHeaderID,string Periode, string Persnum)
        {

            var oParameters = new
            {
                IDProjectHeader = ProjectHeaderID,
                Persnum = Persnum,
                Periode = Periode
            };

            try
            {
                var data = DbTransaction.DbToString("Usp_Approve_ProjectEksekusiPerPeriode", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ReviseEksekusi(int ProjectHeaderID, string Periode, string Persnum, string Description)
        {

            var oParameters = new
            {
                IDProjectHeader = ProjectHeaderID,
                Persnum = Persnum,
                Periode = Periode,
                Description = Description
            };

            try
            {
                var data = DbTransaction.DbToString("Usp_Revise_ProjectEksekusiPerPeriode", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetExecutionReportALL(int IDProjectHeader, int IsTransformasi)
        {
            var oParameters = new
            {
                IDProjectHeader = IDProjectHeader,
                Tipe = 0
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_ProjectEksekusiReportPerPeriodeALL", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetExecutionDashboardReportALL(int IDProjectHeader, int IsTransformasi)
        {
            var oParameters = new
            {
                IDProjectHeader = IDProjectHeader,
                Tipe = 0
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_ProjectEksekusiDasboardReportPerPeriodeALL", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetExecutionDashboardReportProblemNMitigasi(int IDProjectHeader, int IsTransformasi)
        {
            var oParameters = new
            {
                IDProjectHeader = IDProjectHeader,
                Tipe = 0
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_ProjectEksekusiDasboardReportProblemNMitigasi", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetExecutionReportTrendWithOutCurrent(int IDProjectHeader, int IsTransformasi)
        {
            var oParameters = new
            {
                IDProjectHeader = IDProjectHeader,
                Tipe = 0
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_ProjectEksekusiReportPerPeriodeWithOutCurrent", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetExecutionReportCurrent(int IDProjectHeader, int IsTransformasi)
        {
            var oParameters = new
            {
                IDProjectHeader = IDProjectHeader,
                Tipe = 0
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_ProjectEksekusiReportPerPeriodeCurrent", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string AddReliasasi(int IDProjectHeader)
        {
            var oParameters = new
            {
                ProjectHEaderID = IDProjectHeader,
            };
            try
            {
                string data = DbTransaction.DbToString("Usp_Insert_ProjectPlanIFLate", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CheckRealisasi(int IDProjectHeader, int personalnumber)
        {
            var oParameters = new
            {
                @personnumber = personalnumber,
                @projectheaderID = IDProjectHeader
            };
            try
            {
                string data = DbTransaction.DbToString("Usp_Validate_UserForAddingRealitation", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CheckBeforePeriodeIsComplete(int IDProjectHeader, string Periode)
        {
            var oParameters = new
            {
                @IDProjectHeader = IDProjectHeader,
                @Periode = Periode
            };
            try
            {
                string data = DbTransaction.DbToString("Usp_Check_BeforePeriodeIsComplete", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                return "F|" + ex.Message;
            }
        }

        public string Insert_ChgApvProjectHeader(
           int IDProjectHeader,
           int IDProject,
           int Sequence,
           int IDProjectStatus,
           string StartYear,
           int StartMonth,
           string EndYear,
           int EndMonth,
           string NoKontrak,
           DataTable Udt_ProjectInitApprovalRole,
           DataTable Udt_ProjectRoleGroup,
           string TypeTransaction,
           string User
        )
        {
            var oParameters = new
            {
                IDProjectHeader = IDProjectHeader,
                IDProject = IDProject,
                Sequence = Sequence,
                IDProjectStatus = IDProjectStatus,
                StartYear = StartYear,
                StartMonth = StartMonth,
                EndYear = EndYear,
                EndMonth = EndMonth,
                NoKontrak = NoKontrak,
                Udt_ProjectInitApprovalRole = Udt_ProjectInitApprovalRole,
                Udt_ProjectRoleGroup = Udt_ProjectRoleGroup,
                TypeTransaction = TypeTransaction,
                User = User
            };
            try
            {
                string result = DbTransaction.DbToString("Usp_Insert_ChgApvProjectHeader", oParameters, true);
                return result;
            }
            catch (Exception ex)
            {
                string result = "F|Internal Server Error : " + ex;
                return result;
            }
        }
    }
}
