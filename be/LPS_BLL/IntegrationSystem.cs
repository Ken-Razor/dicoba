using LPS_BLL.Models;
using LPS_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPS_BLL
{
    public class IntegrationSystem
    {
        public bool SAPInsertRKAT(DataTable dtRKAT)
        {

            var oParameters = new
            {
                dtRKAT = dtRKAT
            };
            try
            {
                string value = DbTransaction.DbToString("Usp_InsertSAPRKAT", oParameters, true);

                if (value.Contains("S|"))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }


        }

        public string DWInsertKaryawan(
               string PersonalNumber                ,
               string NIK                           ,
               string Username                      ,
               string Org_Unit_Mast_Code            ,
               string Nama                          ,
               string JenisKelamin                  ,
               string TempatLahir                   ,
               string BirthDate                     ,
               string EntryDate                     ,
               string PensiunDate                   ,
               string Status                        ,
               string Leaving                       ,
               string KodeUnitKerja                 ,
               string TanggalDiPosisi               ,
               string Posisi                        ,
               string KodePosisi                    ,
               string TanggalDiJabatan              ,
               string Jabatan                       ,
               string JabatanDirektur               ,
               string TanggalDiPangkat              ,
               string Pangkat                       ,
               string KodePangkat                   ,
               string Pendidikan                    ,
               string Institusi                     ,
               string Agama                         ,
               string TanggalDiangkat               ,
               string StatusKerja                   ,
               string StatusPerkawinan              ,
               string JumlahAnak                    ,
               string Alamat                        ,
               string empl_mast_ID                  ,
               string empl_mast_Username            ,
               string empl_mast_NIP                 ,
               string empl_mast_Name                ,
               string org_unit_mast_ID              ,
               string org_unit_mast_Name            ,
               string empl_mast_ActiveStatus        ,
               string empl_mast_IsContract 
        )
        {

            var oParameters = new
            {
                PersonalNumber                      = PersonalNumber               ,
                NIK                                 = NIK                          ,
                Username                            = Username                     ,
                Org_Unit_Mast_Code                  = Org_Unit_Mast_Code           ,
                Nama                                = Nama                         ,
                JenisKelamin                        = JenisKelamin                 ,
                TempatLahir                         = TempatLahir                  ,
                BirthDate                           = BirthDate                    ,
                EntryDate                           = EntryDate                    ,
                PensiunDate                         = PensiunDate                  ,
                Status                              = Status                       ,
                Leaving                             = Leaving                      ,
                KodeUnitKerja                       = KodeUnitKerja                ,
                TanggalDiPosisi                     = TanggalDiPosisi              ,
                Posisi                              = Posisi                       ,
                KodePosisi                          = KodePosisi                   ,
                TanggalDiJabatan                    = TanggalDiJabatan             ,
                Jabatan                             = Jabatan                      ,
                JabatanDirektur                     = JabatanDirektur              ,
                TanggalDiPangkat                    = TanggalDiPangkat             ,
                Pangkat                             = Pangkat                      ,
                KodePangkat                         = KodePangkat                  ,
                Pendidikan                          = Pendidikan                   ,
                Institusi                           = Institusi                    ,
                Agama                               = Agama                        ,
                TanggalDiangkat                     = TanggalDiangkat              ,
                StatusKerja                         = StatusKerja                  ,
                StatusPerkawinan                    = StatusPerkawinan             ,
                JumlahAnak                          = JumlahAnak                   ,
                Alamat                              = Alamat                       ,
                empl_mast_ID                        = empl_mast_ID                 ,
                empl_mast_Username                  = empl_mast_Username           ,
                empl_mast_NIP                       = empl_mast_NIP                ,
                empl_mast_Name                      = empl_mast_Name               ,
                org_unit_mast_ID                    = org_unit_mast_ID             ,
                org_unit_mast_Name                  = org_unit_mast_Name           ,
                empl_mast_ActiveStatus              = empl_mast_ActiveStatus       ,
                empl_mast_IsContract                = empl_mast_IsContract
            };
            try
            {
                string value = DbTransaction.DbToString("Usp_Insert_DWEmployee", oParameters, true);

                return value;

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public string DWInsertDate(DataTable dtDate)
        {

            var oParameters = new
            {
                dtDate = dtDate
            };
            try
            {
                string value = DbTransaction.DbToString("Usp_Insert_Master_Date", oParameters, true);

                if (value.Contains("S|"))
                {
                    return value;
                }
                else
                {
                    return value;
                }

            }
            catch (Exception ex)
            {
                return ex.ToString();
                throw ex;
            }


        }

        public string SAPCarryOver
        (
            string ACCT_CODE,
            string AST_TYP,
            string AUDITTRAIL,
            string CATEGORY,
            string COSTCTR,
            string DRIVER,
            string FLOW,
            string RENCANA_KERJA,
            string RPTCURRENCY,
            string STD_BIAYA,
            string STRAT_OBJ,
            string TIME,
            string SIGNEDDATA
        )
        {

            var oParameters = new
            {

                ACCT_CODE = ACCT_CODE,
                AST_TYP = AST_TYP,
                AUDITTRAIL = AUDITTRAIL,
                CATEGORY = CATEGORY,
                COSTCTR = COSTCTR,
                DRIVER = DRIVER,
                FLOW = FLOW,
                RENCANA_KERJA = RENCANA_KERJA,
                RPTCURRENCY = RPTCURRENCY,
                STD_BIAYA = STD_BIAYA,
                STRAT_OBJ = STRAT_OBJ,
                TIME = TIME,
                SIGNEDDATA = SIGNEDDATA

            };

            try
            {
                string value = DbTransaction.DbToString("Usp_Insert_SAPCarryOver", oParameters, true);
                return value;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string SAPKomitmen
        (
            string ACCT_CODE,
            string AST_TYP,
            string AUDITTRAIL,
            string CATEGORY,
            string COSTCTR,
            string DRIVER,
            string FLOW,
            string RENCANA_KERJA,
            string RPTCURRENCY,
            string STD_BIAYA,
            string STRAT_OBJ,
            string TIME,
            string SIGNEDDATA
        )
        {

            var oParameters = new
            {

                ACCT_CODE = ACCT_CODE,
                AST_TYP = AST_TYP,
                AUDITTRAIL = AUDITTRAIL,
                CATEGORY = CATEGORY,
                COSTCTR = COSTCTR,
                DRIVER = DRIVER,
                FLOW = FLOW,
                RENCANA_KERJA = RENCANA_KERJA,
                RPTCURRENCY = RPTCURRENCY,
                STD_BIAYA = STD_BIAYA,
                STRAT_OBJ = STRAT_OBJ,
                TIME = TIME,
                SIGNEDDATA = SIGNEDDATA

            };

            try
            {
                string value = DbTransaction.DbToString("Usp_Insert_SAPKomitment", oParameters, true);

                return value;

            }
            catch (Exception ex)
            {
                //return false;
                throw ex;
            }

        }

        public string SAPHangus
        (
            string ACCT_CODE,
            string AST_TYP,
            string AUDITTRAIL,
            string CATEGORY,
            string COSTCTR,
            string DRIVER,
            string FLOW,
            string RENCANA_KERJA,
            string RPTCURRENCY,
            string STD_BIAYA,
            string STRAT_OBJ,
            string TIME,
            string SIGNEDDATA
        )
        {

            var oParameters = new
            {

                ACCT_CODE = ACCT_CODE,
                AST_TYP = AST_TYP,
                AUDITTRAIL = AUDITTRAIL,
                CATEGORY = CATEGORY,
                COSTCTR = COSTCTR,
                DRIVER = DRIVER,
                FLOW = FLOW,
                RENCANA_KERJA = RENCANA_KERJA,
                RPTCURRENCY = RPTCURRENCY,
                STD_BIAYA = STD_BIAYA,
                STRAT_OBJ = STRAT_OBJ,
                TIME = TIME,
                SIGNEDDATA = SIGNEDDATA

            };

            try
            {
                string value = DbTransaction.DbToString("Usp_Insert_SAPHangus", oParameters, true);

                return value;

            }
            catch (Exception ex)
            {
                //return false;
                throw ex;
            }

        }

        public string SAPPergeseran
        (
          string ACCT_CODE,
          string AST_TYP,
          string AUDITTRAIL,
          string CATEGORY,
          string COSTCTR,
          string DRIVER,
          string FLOW,
          string RENCANA_KERJA,
          string RPTCURRENCY,
          string STD_BIAYA,
          string STRAT_OBJ,
          string TIME,
          string SIGNEDDATA
        )
        {

            var oParameters = new
            {

                ACCT_CODE = ACCT_CODE,
                AST_TYP = AST_TYP,
                AUDITTRAIL = AUDITTRAIL,
                CATEGORY = CATEGORY,
                COSTCTR = COSTCTR,
                DRIVER = DRIVER,
                FLOW = FLOW,
                RENCANA_KERJA = RENCANA_KERJA,
                RPTCURRENCY = RPTCURRENCY,
                STD_BIAYA = STD_BIAYA,
                STRAT_OBJ = STRAT_OBJ,
                TIME = TIME,
                SIGNEDDATA = SIGNEDDATA

            };

            try
            {
                string value = DbTransaction.DbToString("Usp_Insert_SAPPergeseran", oParameters, true);

                return value;

            }
            catch (Exception ex)
            {
                //return false;
                throw ex;
            }

        }

        public string SAPRealisasi
        (
          string ACCT_CODE,
          string AST_TYP,
          string AUDITTRAIL,
          string CATEGORY,
          string COSTCTR,
          string DRIVER,
          string FLOW,
          string RENCANA_KERJA,
          string RPTCURRENCY,
          string STD_BIAYA,
          string STRAT_OBJ,
          string TIME,
          string SIGNEDDATA
        )
        {

            var oParameters = new
            {

                ACCT_CODE = ACCT_CODE,
                AST_TYP = AST_TYP,
                AUDITTRAIL = AUDITTRAIL,
                CATEGORY = CATEGORY,
                COSTCTR = COSTCTR,
                DRIVER = DRIVER,
                FLOW = FLOW,
                RENCANA_KERJA = RENCANA_KERJA,
                RPTCURRENCY = RPTCURRENCY,
                STD_BIAYA = STD_BIAYA,
                STRAT_OBJ = STRAT_OBJ,
                TIME = TIME,
                SIGNEDDATA = SIGNEDDATA

            };

            try
            {
                string value = DbTransaction.DbToString("Usp_Insert_SAPRealisasi", oParameters, true);

                return value;

            }
            catch (Exception ex)
            {
                //return false;
                throw ex;
            }

        }

        public string SAPRKATFinal
        ( 
          string ACCT_CODE,
          string AST_TYP,
          string AUDITTRAIL,
          string CATEGORY,
          string COSTCTR,
          string DRIVER,
          string FLOW,
          string RENCANA_KERJA,
          string RPTCURRENCY,
          string STD_BIAYA,
          string STRAT_OBJ,
          string TIME,
          string SIGNEDDATA
        )
        {

            var oParameters = new
            {

                ACCT_CODE = ACCT_CODE,
                AST_TYP = AST_TYP,
                AUDITTRAIL = AUDITTRAIL,
                CATEGORY = CATEGORY,
                COSTCTR = COSTCTR,
                DRIVER = DRIVER,
                FLOW = FLOW,
                RENCANA_KERJA = RENCANA_KERJA,
                RPTCURRENCY = RPTCURRENCY,
                STD_BIAYA = STD_BIAYA,
                STRAT_OBJ = STRAT_OBJ,
                TIME = TIME,
                SIGNEDDATA = SIGNEDDATA

            };

            try
            {
                string value = DbTransaction.DbToString("Usp_Insert_SAPRKATFinal", oParameters, true);

                return value;

            }
            catch (Exception ex)
            {
                //return false;
                throw ex;
            }

        }

        public string SAPAccount
        (
          string ID,
          string ACCTYPE,
          string ASSUM_TYPE,
          string DIMLIST_CF,
          string EVDESCRIPTION,
          string FS,
          string PLANNING,
          string RATETYPE,
          string REF_ACCOUNT,
          string SCALING,
          string PARENTH1,
          string PARENTH2,
          string PARENTH3,
          string PARENTH4,
          string PARENTH5
        )
        {

            var oParameters = new
            {
                ID = ID,
                ACCTYPE = ACCTYPE,
                ASSUM_TYPE = ASSUM_TYPE,
                DIMLIST_CF = DIMLIST_CF,
                EVDESCRIPTION = EVDESCRIPTION,
                FS = FS,
                PLANNING = PLANNING,
                RATETYPE = RATETYPE,
                REF_ACCOUNT = REF_ACCOUNT,
                SCALING = SCALING,
                PARENTH1 = PARENTH1,
                PARENTH2 = PARENTH2,
                PARENTH3 = PARENTH3,
                PARENTH4 = PARENTH4,
                PARENTH5 = PARENTH5
            };

            try
            {
                string value = DbTransaction.DbToString("Usp_Insert_ACCOUNT", oParameters, true);

                return value;

            }
            catch (Exception ex)
            {
                //return false;
                throw ex;
            }

        }

        public string SAPMDRENCANA
        (
           string ID,
           string ACTIVE,
           string COSTCTR,
           string EVDESCRIPTION,
           string KPI,
           string KPI_GROUP,
           string LEVEL,
           string LONG_DESC,
           string PRO_GROUP,
           string SCALING,
           string STRAT_OBJ,
           string UNCONTROLLABLE,
           string WORKPLAN_TYPE,
           string YEAR,
           string PARENTH1
         )
        {

            var oParameters = new
            {
                ID = ID,
                ACTIVE = ACTIVE,
                COSTCTR = COSTCTR,
                EVDESCRIPTION = EVDESCRIPTION,
                KPI = KPI,
                KPI_GROUP = KPI_GROUP,
                LEVEL = LEVEL,
                LONG_DESC = LONG_DESC,
                PRO_GROUP = PRO_GROUP,
                SCALING = SCALING,
                STRAT_OBJ = STRAT_OBJ,
                UNCONTROLLABLE = UNCONTROLLABLE,
                WORKPLAN_TYPE = WORKPLAN_TYPE,
                YEAR = YEAR,
                PARENTH1 = PARENTH1
            };

            try
            {
                string value = DbTransaction.DbToString("Usp_Insert_SAPMasterRKAT", oParameters, true);

                return value;

            }
            catch (Exception ex)
            {
                //return false;
                throw ex;
            }

        }
        public string ActuateSO
       (
         string SO_ID,
         string SO_Code,
         string SO_Name,
         string SO_Desc,
         string SO_Year,
         string SO_IsActive
        )
        {

            var oParameters = new
            {
                SO_Code = SO_Code,
                SO_Name = SO_Name,
                SO_Desc = SO_Desc,
                SO_Year = SO_Year,
                SO_IsActive = SO_IsActive
            };

            try
            {
                string value = DbTransaction.DbToString("Usp_Insert_ActuateSO", oParameters, true);

                return value;

            }
            catch (Exception ex)
            {
                //return false;
                throw ex;
            }

        }

        public DataSet GetEmail
         (
           int Type,
           int IDProjectHeader,
           string Periode
          )
        {

            var oParameters = new
            {
                Type = Type ,
                IDProjectHeader = IDProjectHeader,
                Periode = Periode
            };

            try
            {
                DataSet value = DbTransaction.DbToDataSet("Usp_GetEmailTemplate", oParameters);

                return value;

            }
            catch (Exception ex)
            {
                //return false;
                throw ex;
            }

        }

      public string ActuateKPI
      (
        string KPI_ID         ,  
        string KPI_SO_ID      ,
        string KPI_Code       ,
        string KPI_Name       ,
        string KPI_Desc       ,
        string KPI_Year       ,
        string KPI_IsActive
       )
        {

            var oParameters = new
            {
               KPI_ID           = KPI_ID         ,
               KPI_SO_ID        = KPI_SO_ID      ,
               KPI_Code         = KPI_Code       ,
               KPI_Name         = KPI_Name       ,
               KPI_Desc         = KPI_Desc       ,
               KPI_Year         = KPI_Year       ,
               KPI_IsActive     = KPI_IsActive
            };

            try
            {
                string value = DbTransaction.DbToString("Usp_Insert_ActuateKPI", oParameters, true);

                return value;

            }
            catch (Exception ex)
            {
                //return false;
                throw ex;
            }

        }

        public string EmailLog
        (
               int EmailTemplateID,
               string Subject,
               string Content,
               string status,
               int IDProjectHeader,
               string sentTo
        )
        {
            var oParameters = new
            {
              EmailTemplateID =  EmailTemplateID      ,
              Subject         =  Subject              ,
              Content         =  Content              ,
              status          =  status               ,
              IDProjectHeader =  IDProjectHeader      ,
              sentTo = sentTo
            };

            try
            {
                string value = DbTransaction.DbToString("Usp_Insert_EmailLog", oParameters, true);
                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CheckMilestone
       (
              int ProjectHeaderID,
              int TaskId
       )
        {
            var oParameters = new
            {
                ProjectHeaderID = ProjectHeaderID,
                TaskId = TaskId
            };

            try
            {
                DataTable value = DbTransaction.DbToDataTable("Usp_Check_Milestone", oParameters, true);
                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetEmailProject
        (
            string username
        )
        {
            var oParameters = new
            {
                Username = username
            };

            try
            {
                DataSet value = DbTransaction.DbToDataSet("Usp_Scheduller_Get_Email_Data", oParameters);
                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetEmailBulk()
        {
            var oParameters = new {};

            try
            {
                DataTable value = DbTransaction.DbToDataTable("Usp_Scheduller_GetEmailBulkInit2", oParameters, true);
                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetEmailNoRealizationBulk()
        {
            var oParameters = new { };

            try
            {
                DataTable value = DbTransaction.DbToDataTable("Usp_Scheduller_GetEmailBulkInit_noRealisation", oParameters, true);
                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetEmailBulkApprovalPending()
        {
            var oParameters = new { };

            try
            {
                DataTable value = DbTransaction.DbToDataTable("Usp_Scheduller_GetEmailBulkApprovalPending", oParameters, true);
                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable GetEmailBulkInit()
        {
            var oParameters = new {};

            try
            {
                DataTable value = DbTransaction.DbToDataTable("Usp_Scheduller_GetEmailBulkInit", oParameters, true);
                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetEmailBulkExec()
        {
            var oParameters = new{};

            try
            {
                DataTable value = DbTransaction.DbToDataTable("Usp_Scheduller_GetEmailBulkExec", oParameters, true);
                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetEmailDataTrans(string username)
        {
            var oParameters = new
            {
                Username = username
            };

            try
            {
                DataSet value = DbTransaction.DbToDataSet("Usp_Scheduller_Get_Email_DataTrans2", oParameters);
                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetEmailDataTransNoReal(string username)
        {
            var oParameters = new
            {
                Username = username
            };

            try
            {
                DataSet value = DbTransaction.DbToDataSet("Usp_Scheduller_Get_Email_DataTrans_NoRealisasi", oParameters);
                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetEmailDataNonTrans(string username)
        {
            var oParameters = new
            {
                Username = username
            };

            try
            {
                DataSet value = DbTransaction.DbToDataSet("Usp_Scheduller_Get_Email_DataNonTrans2", oParameters);
                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetEmailDataNonTransNoReal(string username)
        {
            var oParameters = new
            {
                Username = username
            };

            try
            {
                DataSet value = DbTransaction.DbToDataSet("Usp_Scheduller_Get_Email_DataNonTrans_NoRealisasi", oParameters);
                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetEmailDataApprInit(string username)
        {
            var oParameters = new
            {
                Username = username
            };

            try
            {
                DataSet value = DbTransaction.DbToDataSet("Usp_Scheduller_GetEmailDataApprInit", oParameters);
                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetEmailDataApprExec(string username)
        {
            var oParameters = new
            {
                Username = username
            };

            try
            {
                DataSet value = DbTransaction.DbToDataSet("Usp_Scheduller_GetEmailDataApprExec", oParameters);
                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDataIoperaIntegration(string year,string tw)
        {
            var oParameters = new
            {
                Year = year,
                TW = tw
            };

            try
            {
                DataSet value = DbTransaction.DbToDataSet("Usp_Get_DataIntegrasiIopera", oParameters);
                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetReportGptfPerWeek(int month,string year,int? week)
        {
            var oParameters = new
            {
                Month = month,
                Year = year,
                Week = week
            };

            try
            {
                DataSet value = DbTransaction.DbToDataSet("Usp_Get_ReportGptf_PerWeek", oParameters);
                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetEmailApprovalPending(string username)
        {
            var oParameters = new {
                Username = username
            };
            try
            {
                var data = DbTransaction.DbToDataSet("Usp_Scheduller_Get_Email_ApprovalPending", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
