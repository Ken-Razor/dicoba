using LPS_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPS_BLL
{
    public class PJSApproval
    {
        public DataTable Get_PJSApproval()
        {
            var oParameters = new
            {
                //Username = Username
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_TransaksiPJSApproval", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Get_PJSApproval_ByID(int ID)
        {
            var oParameters = new
            {
                ID = ID
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_TransaksiPJSApproval_ByID", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Insert_PJSApproval(
            string ID,
            string ExistingUsername,
            string PJSUsername,
            string IDRoleGroup,
            DateTime StartDate,
            DateTime EndDate,
            string Note,
            string PersonalNumber,
            string TypeTransaction
            )
        {
            var oParameters = new
            {
                ID = ID,
                ExistingUsername = ExistingUsername,
                PJSUsername = PJSUsername,
                IDRoleGroup = IDRoleGroup,
                StartDate = StartDate,
                EndDate = EndDate,
                Note = Note,
                PersonalNumber = PersonalNumber,
                TypeTransaction = TypeTransaction
            };
            try
            {
                string Result = DbTransaction.DbToString("Usp_Insert_PJSApproval", oParameters, true);
                return Result;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
