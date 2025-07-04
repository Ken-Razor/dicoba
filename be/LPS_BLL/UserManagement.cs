using LPS_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPS_BLL
{
    public class UserManagement
    {
        public DataTable ListRegisteredUser()
        {

            var oParameters = new
            {
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_UserAuthorizedList", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public DataSet DetailRegisteredUser(string AuthNumber)
        {
            var oParameters = new
            {
                personnumber = AuthNumber
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_Get_UserAuthorizedDetail_ByID", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DropDownProgramandRoles()
        {
            var oParameters = new
            {
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_Get_DropdownProgramAndRoles", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable DropDownProject(int IDProgram)
        {
            var oParameters = new
            {
                programid = IDProgram
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_DropdownProjectFromProgram", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable DropDownProgram(int IDProject)
        {
            var oParameters = new
            {
                ProjectID = IDProject
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_DropdownProgramFromProject", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListEmployeByName(string name)
        {
            var oParameters = new
            {
                username = name
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_EmployeeList_byName", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListEmployeByNameNew(string name)
        {
            var oParameters = new
            {
                username = name
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_EmployeeList_byName_NewUser", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string insertNewUser(string persnumber , string createdby , DataTable dt)
        {
            var oParameters = new
            {
                personnumber = persnumber,
                createby = createdby,
                ProgramProjectRole = dt
            };
            try
            {
                string data = DbTransaction.DbToString("Usp_Insert_NewUser", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public string DeleteNewUser(string Persnumber, string Username)
        {
            var oParameters = new
            {
                personnumber = Persnumber,
                Username = Username

            };
            try
            {
                string data = DbTransaction.DbToString("Usp_Delete_AuthorizedUser", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string UpdateNewUser(string persnumber, string createdby, DataTable dt)
        {
            var oParameters = new
            {
                personnumber = persnumber,
                createby = createdby,
                ProgramProjectRole = dt
            };
            try
            {
                string data = DbTransaction.DbToString("Usp_Update_NewUser", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string InsertNewUserWithRole(string persnumber, string createdby, int roleid)
        {
            var oParameters = new
            {
                NewUserPersnum = persnumber,
                RoleID = roleid,
                CreateByPersnum = createdby
            };
            try
            {
                string data = DbTransaction.DbToString("Usp_Insert_UserSystemRole", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string GetUserSystemRole(string persnumber)
        {
            var oParameters = new
            {
                Persnum = persnumber
            };
            try
            {
                string data = DbTransaction.DbToString("Usp_Get_UserRole", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable AllProject(string PersonNumber)
        {
            var oParameters = new
            {
                PersonNumber = PersonNumber
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_New_ManajemenAkun", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
