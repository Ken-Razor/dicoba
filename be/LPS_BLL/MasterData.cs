using LPS_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPS_BLL
{
    public class MasterData
    {
        #region Master Program
        public DataTable Get_MasterProgram()
        {
            var oParameters = new
            {
                //username = Username
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_MasterProgram", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Get_MasterProgram_ByID(int IDProgram)
        {
            var oParameters = new
            {
                IDProgram = IDProgram
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_MasterProgram_ByID", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Insert_MasterProgram(int IDProgram, string ProgramNo, string ProgramName, string Description, string User, string TypeTransaction)
        {
            var oParameters = new
            {
                IDProgram = IDProgram,
                ProgramNo = ProgramNo,
                ProgramName = ProgramName,
                Description = Description,
                User = User,
                TypeTransaction = TypeTransaction
            };
            try
            {
                string result = DbTransaction.DbToString("Usp_Insert_MasterProgram", oParameters, true);
                return result;
            }
            catch (Exception ex)
            {
                return "Terjadi kesalahan pada BLL : " + ex.Message;
            }
        }
        #endregion

        #region Project
        public DataTable Get_MasterProject()
        {
            var oParameters = new
            {
                //username = Username
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_MasterProject", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Get_MasterProject_ByID(int IDProject)
        {
            var oParameters = new
            {
                IDProject = IDProject
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_Get_MasterProject_ByID_CatProj", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Get_SAPRKAT_ByCostCTR(string COSTCTR)
        {
            var oParameters = new
            {
                COSTCTR = COSTCTR
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_SAPRKAT_ByCOSTCTR", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Get_SAPRKAT_ByDESCRIPTION(string DESCRIPTION)
        {
            var oParameters = new
            {
                DESCRIPTION = DESCRIPTION
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_SAPRKAT_ByDESCRIPTION", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Insert_MasterProject(
            int IDProject,
            int IDProgram, 
            int IDStrategicObjective,
            int IDProjectPriority,
            int IDDepartment,
            string ProjectNo, 
            string Year,
            string ProjectName,
            double Weight,
            Boolean IsTransformasi,
            string IDKPIOrganization,
            string IDSAPRKAT,
            DataTable Udt_ProjectRoleGroup,
            string User, 
            string TypeTransaction
            ,int IDKategoriProject,
            double Poin,
            string IDMKU
        )
        {
            var oParameters = new
            {
                IDProject = IDProject,
                IDProgram = IDProgram,
                IDStrategicObjective = IDStrategicObjective,
                IDProjectPriority = IDProjectPriority,
                IDDepartment = IDDepartment,
                ProjectNo = ProjectNo,
                Year = Year,
                ProjectName = ProjectName,
                Weight = Weight,
                IsTransformasi = IsTransformasi,
                IDKPIOrganization = IDKPIOrganization,
                IDSAPRKAT = IDSAPRKAT,
                Udt_ProjectRoleGroup = Udt_ProjectRoleGroup,
                User = User,
                TypeTransaction = TypeTransaction
                ,IDKategoriProject = IDKategoriProject,
                Poin = Poin,
                IDMKU = IDMKU
            };
            try
            {
                string result = DbTransaction.DbToString("Usp_Insert_MasterProject", oParameters, true);
                return result;
            }
            catch (Exception ex)
            {
                return "Terjadi kesalahan pada BLL : " + ex.Message;
            }
        }
        #endregion

        #region Master KPI Organization
        public DataTable Get_MasterKPIOrganization()
        {
            var oParameters = new
            {
                //username = Username
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_MasterKPIOrganization", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Get_MasterKPIOrganization_ByID(int IDKPIOrganization)
        {
            var oParameters = new
            {
                IDKPIOrganization = IDKPIOrganization
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_MasterKPIOrganization_ByID", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Get_MasterKPIOrganization_ByKPIName(string KPIName)
        {
            var oParameters = new
            {
                KPIName = KPIName
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_MasterKPIOrganization_ByKPIName", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Insert_MasterKPIOrganization(int IDKPIOrganization, string KPICode, string KPIName, string Year, string Description, string User, string TypeTransaction)
        {
            var oParameters = new
            {
                IDKPIOrganization = IDKPIOrganization,
                KPICode = KPICode,
                KPIName = KPIName,
                Year = Year,
                Description = Description,
                User = User,
                TypeTransaction = TypeTransaction
            };
            try
            {
                string result = DbTransaction.DbToString("Usp_Insert_MasterKPIOrganization", oParameters, true);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Master KPI Value
        public DataTable Get_MasterKPIValue(string PersonNumber)
        {
            var oParameters = new
            {
                PersonNumber = PersonNumber
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_MasterKPIValue", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Get_MasterKPIValue_ByID(string PersonNumber, int IDProject)
        {
            var oParameters = new
            {
                PersonNumber = PersonNumber,
                IDProject = IDProject
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_MasterKPIValue_ByIDProject", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public string Insert_MasterKPIValue(string PersonNumber,int IDProject,string TW1,string TW2,string TW3,string TW4)
        {
            var oParameters = new
            {
                IDProject = IDProject,
                TW1 = TW1,
                TW2 = TW2,
                TW3 = TW3,
                TW4 = TW4,
                PersonNumber = PersonNumber
            };
            try
            {
                string result = DbTransaction.DbToString("Usp_Insert_MasterKPIValue", oParameters, true);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Master Strategic Objective
        public DataTable Get_MasterStrategicObjective()
        {
            var oParameters = new
            {
                //username = Username
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_MasterStrategicObjective", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Get_MasterStrategicObjective_ByID(int IDStrategicObjective)
        {
            var oParameters = new
            {
                IDStrategicObjective = IDStrategicObjective
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_MasterStrategicObjective_ByID", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Insert_MasterStrategicObjective(int IDStrategicObjective, string StrategicObjectiveCode, string StrategicObjectiveName, string Description, string User, string TypeTransaction)
        {
            var oParameters = new
            {
                IDStrategicObjective = IDStrategicObjective,
                StrategicObjectiveCode = StrategicObjectiveCode,
                StrategicObjectiveName = StrategicObjectiveName,
                Description = Description,
                User = User,
                TypeTransaction = TypeTransaction
            };
            try
            {
                string result = DbTransaction.DbToString("Usp_Insert_MasterStrategicObjective", oParameters, true);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Master Department
        public DataTable Get_MasterDepartment()
        {
            var oParameters = new
            {
                //username = Username
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_MasterDepartment", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Get_MasterDepartment_ByID(int IDDepartment)
        {
            var oParameters = new
            {
                IDDepartment = IDDepartment
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_Get_MasterDepartment_ByID", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Get_MasterDepartment_ByName(string DepartmentName)
        {
            var oParameters = new
            {
                DepartmentName = DepartmentName
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_MasterDepartment_ByName", oParameters,true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Insert_MasterDepartment(int IDDepartment, int IDDirektorat, string DepartmentCode, string CostCenter, string DepartmentName, string Description, string User, string TypeTransaction)
        {
            var oParameters = new
            {
                IDDepartment = IDDepartment,
                IDDirektorat = IDDirektorat,
                DepartmentCode = DepartmentCode,
                CostCenter = CostCenter,
                DepartmentName = DepartmentName,
                Description = Description,
                User = User,
                TypeTransaction = TypeTransaction
            };
            try
            {
                string result = DbTransaction.DbToString("Usp_Insert_MasterDepartment", oParameters, true);
                return result;
            }
            catch (Exception ex)
            {
                return "Terjadi kesalahan pada BLL : " + ex.Message;
            }
        }
        #endregion

        #region Master Project Cost
        public DataTable Get_MasterProjectCost()
        {
            var oParameters = new
            {
                //username = Username
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_MasterProjectCost", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Get_MasterProjectCost_ByID(int IDProjectCost)
        {
            var oParameters = new
            {
                IDProjectCost = IDProjectCost
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_MasterProjectCost_ByID", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Get_MasterProjectCost_ByName(string ProjectCostName)
        {
            var oParameters = new
            {
                ProjectCostName = ProjectCostName
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_MasterProjectCost_ByName", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Insert_MasterProjectCost(int IDProjectCost, string ProjectCostCode, string ProjectCostName, string Description, string User, string TypeTransaction)
        {
            var oParameters = new
            {
                IDProjectCost = IDProjectCost,
                ProjectCostCode = ProjectCostCode,
                ProjectCostName = ProjectCostName,
                Description = Description,
                User = User,
                TypeTransaction = TypeTransaction
            };
            try
            {
                string result = DbTransaction.DbToString("Usp_Insert_MasterProjectCost", oParameters, true);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Master HariLibur
        public List<object> Get_HariLibur()
        {
            var oParameters = new
            {
            };
            try
            {
                var data = DbTransaction.DbToList<object>("Usp_Get_Holiday", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region MasterFile
        public string DeleteFile(int ProjectHeaderID , int DocumentID)
        {
            var oParameters = new
            {
                ProjectHeaderID = ProjectHeaderID,
                DocumentID = DocumentID
            };
            try
            {
                string data = DbTransaction.DbToString("Usp_Delete_File", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetProjectNameByHeader(int ProjectHeaderID)
        {
            var oParameters = new
            {
                ProjectHeaderID = ProjectHeaderID
            };
            try
            {
                string data = DbTransaction.DbToString("Usp_Get_ProjectName_byHeaderID", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Master Direktorat
        public DataTable Get_MasterDirektorat()
        {
            var oParameters = new
            {
                //username = Username
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_MasterDirektorat", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public string Get_Root(int ProjectHeaderID)
        {
            var oParameters = new
            {
                ProjectHeaderID = ProjectHeaderID
            };
            try
            {
                string data = DbTransaction.DbToString("Usp_GetProjectHeaderRoot", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Master kategori project
        public DataTable Get_MasterKategoriProject()
        {
            var oParameters = new
            {
                //username = Username
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_MasterKategoriProject", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Get_MasterKategoriProject_ByID(int IDKategori)
        {
            var oParameters = new
            {
                IDKategori = IDKategori
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_MasterKategoriProject_ByID", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Insert_MasterKategoriProject(int IDKategoriProject, string KategoriName, string Description, string User, string TypeTransaction)
        {
            var oParameters = new
            {
                IDKategoriProject = IDKategoriProject,
                KategoriName = KategoriName,
                Description = Description,
                User = User,
                TypeTransaction = TypeTransaction
            };
            try
            {
                string result = DbTransaction.DbToString("Usp_Insert_MasterKategoriProject", oParameters, true);
                return result;
            }
            catch (Exception ex)
            {
                return "Terjadi kesalahan pada BLL : " + ex.Message;
            }
        }
        #endregion


        public string Generate_MasterKPIValue() 
        {
            var oParameters = new
            {
                //username = Username
            };
            try
            {
                string result  = DbTransaction.DbToString("Usp_Generate_ProjectKPI", oParameters, true);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
