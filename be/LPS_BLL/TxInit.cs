using LPS_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPS_BLL
{
    public class TxInit
    {
        public DataTable Get_TxProjectHeader(string PersonalNumber)
        {
            var oParameters = new
            {
                PersonalNumber = PersonalNumber
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_TxProjectHeader", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Get_TxProjectHeader_ByID(int IDProjectHeader, string User)
        {
            var oParameters = new
            {
                IDProjectHeader = IDProjectHeader,
                User = User
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_Get_TxProjectHeader_ByID", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Get_TxPH_ByID_Formulir(int IDProjectHeader, string User)
        {
            var oParameters = new
            {
                IDProjectHeader = IDProjectHeader,
                User = User
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_Get_TxPH_ByID_Formulir", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Get_TxPH_ByID_Timeline(int IDProjectHeader, string User)
        {
            var oParameters = new
            {
                IDProjectHeader = IDProjectHeader,
                User = User
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_Get_TxPH_ByID_Timeline", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Get_TxPH_ByID_Stakeholder(int IDProjectHeader, string User)
        {
            var oParameters = new
            {
                IDProjectHeader = IDProjectHeader,
                User = User
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_Get_TxPH_ByID_Stakeholder", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Get_TxPH_ByID_ApprovalLog(int IDProjectHeader, string User)
        {
            var oParameters = new
            {
                IDProjectHeader = IDProjectHeader,
                User = User
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_Get_TxPH_ByID_ApprovalLog", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Get_TxPH_ByID_Document(int IDProjectHeader, string User)
        {
            var oParameters = new
            {
                IDProjectHeader = IDProjectHeader,
                User = User
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_Get_TxPH_ByID_Document", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Get_TxPH_ByID_ChgAppr(int IDProjectHeader, string User)
        {
            var oParameters = new
            {
                IDProjectHeader = IDProjectHeader,
                User = User
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_Get_TxPH_ByID_ChgAppr", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Insert_TxProjectHeader( 
            int IDProjectHeader,
            int IDProject,
            int Sequence,
            int IDProjectStatus,
            string StartYear,
            int StartMonth,
            string EndYear,
            int EndMonth,
            string NoKontrak,
            double ContractIDR,
            double ContractUSD,
            double WeightKPI,
            int IDProjectDetail,
            string Background,
            string Objective,
            string ScopeOfWork,
            string BudgetDescription,
            byte[] OrganizazationChart,
            string Constraints,
            string Assumptions,
            string Risk,
            string Approach,
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
                ContractIDR = ContractIDR,
                ContractUSD = ContractUSD,
                WeightKPI = WeightKPI,
                IDProjectDetail = IDProjectDetail,
                Background = Background,
                Objective = Objective,
                ScopeOfWork = ScopeOfWork,
                BudgetDescription = BudgetDescription,
                OrganizazationChart = OrganizazationChart,
                Constraints = Constraints,
                Assumptions = Assumptions,
                Risk = Risk,
                Approach = Approach,
                Udt_ProjectInitApprovalRole = Udt_ProjectInitApprovalRole,
                Udt_ProjectRoleGroup = Udt_ProjectRoleGroup,
                TypeTransaction = TypeTransaction,
                User = User
            };
            try
            {
                string result = DbTransaction.DbToString("Usp_Insert_TxProjectHeader", oParameters, true);
                return result;
            }
            catch (Exception ex)
            {
                string result = "F|Internal Server Error : " + ex;
                return result;
            }
        }

        public string Insert_TxPHFormulir(
            int IDProjectHeader,
            int IDProject,
            int Sequence,
            int IDProjectStatus,
            string StartYear,
            int StartMonth,
            string EndYear,
            int EndMonth,
            string NoKontrak,
            double ContractIDR,
            double ContractUSD,
            double WeightKPI,
            int IDProjectDetail,
            string Background,
            string Objective,
            string ScopeOfWork,
            string BudgetDescription,
            byte[] OrganizazationChart,
            string Constraints,
            string Assumptions,
            string Risk,
            string Approach,
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
                ContractIDR = ContractIDR,
                ContractUSD = ContractUSD,
                WeightKPI = WeightKPI,
                IDProjectDetail = IDProjectDetail,
                Background = Background,
                Objective = Objective,
                ScopeOfWork = ScopeOfWork,
                BudgetDescription = BudgetDescription,
                OrganizazationChart = OrganizazationChart,
                Constraints = Constraints,
                Assumptions = Assumptions,
                Risk = Risk,
                Approach = Approach,
                TypeTransaction = TypeTransaction,
                User = User
            };
            try
            {
                string result = DbTransaction.DbToString("Usp_Insert_TxPHFormulir", oParameters, true);
                return result;
            }
            catch (Exception ex)
            {
                string result = "F|Internal Server Error : " + ex;
                return result;
            }
        }

        public string Insert_TxPHStakeholder(
            int IDProjectHeader,
            int IDProject,
            int Sequence,
            int IDProjectStatus,
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
                Udt_ProjectInitApprovalRole = Udt_ProjectInitApprovalRole,
                Udt_ProjectRoleGroup = Udt_ProjectRoleGroup,
                TypeTransaction = TypeTransaction,
                User = User
            };
            try
            {
                string result = DbTransaction.DbToString("Usp_Insert_TxPHStakeholder", oParameters, true);
                return result;
            }
            catch (Exception ex)
            {
                string result = "F|Internal Server Error : " + ex;
                return result;
            }
        }

        public string Approve_TxProjectHeader(int IDProjectHeader, string Deskripsi, string User, string TypeTransaction)
        {
            var oParameters = new
            {
                IDProjectHeader = IDProjectHeader,
                Deskripsi = Deskripsi,
                User = User,
                TypeTransaction = TypeTransaction
            };
            try
            {
                string result = DbTransaction.DbToString("Usp_Approve_TxProjectHeader", oParameters, true);
                return result;
            }
            catch (Exception ex)
            {
                string result = "F|Internal Server Error : " + ex;
                return result;
            }
        }

        #region MPP
        public string InsertDataMPP(DataSet ds, string projectheaderid, string personnumber)
        {

            var oParameters = new
            {
                ProjectHeaderID = Convert.ToInt32(projectheaderid),
                DtTask = ds.Tables[0],
                DtResources = ds.Tables[1],
                DtResourcesAssigment = ds.Tables[2],
                DtLink = ds.Tables[3],
                PersonNumber = personnumber
            };
            try
            {
                string data = DbTransaction.DbToString("Usp_Insert_InisiasiProjectMPP", oParameters, true);

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDataMPPPlaning(string projectheaderid)
        {
            var oParameters = new
            {
                ProjectHeaderID = Convert.ToInt32(projectheaderid),

            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_Get_MPPInitiation", oParameters);

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdateDataMPP(DataSet ds, string projectheaderid, string personnumber)
        {

            var oParameters = new
            {
                ProjectHeaderID = Convert.ToInt32(projectheaderid),
                DtTask = ds.Tables[0],
                DtResources = ds.Tables[1],
                DtResourcesAssigment = ds.Tables[2],
                DtLink = ds.Tables[3],
                PersonNumber = personnumber
            };
            try
            {
                string data = DbTransaction.DbToString("Usp_Update_InisiasiProjectMPP", oParameters, true);

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<object> GetResourcesByProjectHeaderID(string projectheaderid)
        {
            var oParameters = new
            {
                ProjectHeaderID = Convert.ToInt32(projectheaderid),

            };
            try
            {
                var data = DbTransaction.DbToList<object>("Usp_Get_ProjectResources_ByProjectHeaderID", oParameters, true);

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<object> GetPlanningPercentage(DataSet dtMPP)
        {
            var oParameters = new
            {
                dtMPP = dtMPP.Tables[0]
            };
            try
            {
                var data = DbTransaction.DbToDataTable("Usp_Calculate_PlannedPercentage", oParameters, true);

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
