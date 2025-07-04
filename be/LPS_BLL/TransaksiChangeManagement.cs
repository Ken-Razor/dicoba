using LPS_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPS_BLL
{
    public class TransaksiChangeManagement
    {
        public DataTable Get_TransaksiChangeManagementProjectHeader(string PersonalNumber)
        {
            var oParameters = new
            {
                PersonalNumber = PersonalNumber
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_TransaksiChangeManagementProjectHeader", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Get_TransaksiChangeManagementProjectHeader_ByID(int IDProjectHeader, string User)
        {
            var oParameters = new
            {
                IDProjectHeader = IDProjectHeader,
                User = User
            };
            try
            {
                DataSet ds = DbTransaction.DbToDataSet("Usp_Get_TransaksiChangeManagementProjectHeader_ByID", oParameters);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Insert_TransaksiChangeManagementProjectHeader(
            int IDProjectHeader,
            int IDJenisPerubahan,
            string JenisPerubahan,
            bool IsCancel,
            string TypeOfCR,
            string SubmitterName,
            string BriefDescriptionOfRequest,
            DateTime DateSubmitted,
            DateTime DateRequired,
            string ReasonForChange,
            string PenyebabLain,
            string OtherArtifactsImpacted,
            Boolean AttachmentsOrReferences,
            string Catatan,
            string Deskripsi,
            string TypeTransaction,
            string User,
            DataTable Udt_ProjectChangeApprovalRole
        )
        {
            var oParameters = new
            {
                IDProjectHeader = IDProjectHeader,
                IDJenisPerubahan = IDJenisPerubahan,
                JenisPerubahan = JenisPerubahan,
                IsCancel = IsCancel,
                TypeOfCR = TypeOfCR,
                SubmitterName = SubmitterName,
                BriefDescriptionOfRequest = BriefDescriptionOfRequest,
                DateSubmitted = DateSubmitted,
                DateRequired = DateRequired,
                ReasonForChange = ReasonForChange,
                PenyebabLain = PenyebabLain,
                OtherArtifactsImpacted = OtherArtifactsImpacted,
                AttachmentsOrReferences = AttachmentsOrReferences,
                Catatan = Catatan,
                Deskripsi = Deskripsi,
                TypeTransaction = TypeTransaction,
                User = User,
                Udt_ProjectChangeApprovalRole = Udt_ProjectChangeApprovalRole
            };
            try
            {
                string result = DbTransaction.DbToString("Usp_Insert_TransaksiChangeManagement", oParameters, true);
                return result;
            }
            catch (Exception ex)
            {
                string result = "F|Internal Server Error : " + ex;
                return result;
            }
        }

        public string Approve_TransaksiChangeManagementProjectHeader(int IDProjectHeader, string Deskripsi, string User, string TypeTransaction)
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
                string result = DbTransaction.DbToString("Usp_Approve_TransaksiChangeProjectHeader", oParameters, true);
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
