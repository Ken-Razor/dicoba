using LPS_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPS_BLL
{
    public class TransaksiInitiation
    {
        public DataTable Get_TransaksiProjectHeader(string PersonalNumber)
        {
            var oParameters = new
            {
                PersonalNumber = PersonalNumber
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_TransaksiProjectHeader", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Get_TransaksiProjectHeader_ByID(int IDProjectHeader, string User)
        {
            var oParameters = new
            {
                IDProjectHeader = IDProjectHeader,
                User = User
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_Get_TransaksiProjectHeader_ByID", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Get_StringRKAT_ByID(int IDProjectHeader, string User)
        {
            var oParameters = new
            {
                IDProjectHeader = IDProjectHeader,
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_Get_StringRKAT_ByID", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Insert_TransaksiProjectHeader(
            int IDProjectHeader,
            int IDProject,
            int Sequence,
            int IDProjectStatus,
            string StartYear,
            int StartMonth,
            string EndYear,
            int EndMonth,
            string NoKontrak,
            //DateTime ContractStartDate,
            //DateTime ContractEndDate,
            double ContractIDR,
            double ContractUSD,
            double WeightKPI,
            int IDProjectDetail,
            string Background,
            string Objective,
            string ScopeOfWork,
            string BudgetDescription,
            byte[] OrganizazationChart,
            //DataTable Udt_ProjectConstraint,
            //DataTable Udt_ProjectHeaderCost,
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
                //ContractStartDate = ContractStartDate,
                //ContractEndDate = ContractEndDate,
                ContractIDR = ContractIDR,
                ContractUSD = ContractUSD,
                WeightKPI = WeightKPI,
                IDProjectDetail = IDProjectDetail,
                Background = Background,
                Objective = Objective,
                ScopeOfWork = ScopeOfWork,
                BudgetDescription = BudgetDescription,
                OrganizazationChart = OrganizazationChart,
                //Udt_ProjectConstraint = Udt_ProjectConstraint,
                //Udt_ProjectHeaderCost = Udt_ProjectHeaderCost,
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
                string result = DbTransaction.DbToString("Usp_Insert_TransaksiProjectHeader", oParameters, true);
                return result;
            }
            catch (Exception ex)
            {
                string result = "F|Internal Server Error : " + ex;
                return result;
            }
        }

        public string Approve_TransaksiProjectHeader(int IDProjectHeader, string Deskripsi, string User, string TypeTransaction)
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
                string result = DbTransaction.DbToString("Usp_Approve_TransaksiProjectHeader", oParameters, true);
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
