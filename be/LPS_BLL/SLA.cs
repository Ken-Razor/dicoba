using LPS_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPS_BLL
{
    public class SLA
    {

        public DataSet Get_Master_Sla( )
        {
            var oParameters = new
            {
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_SLA_GetALl", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Insert_Update_Master_SLA(long Id, int GrooupId, string StatusSLA, string Peraturan, string Keterangan, string Waktu, string DihitungDari, string User, string TypeTransaction)
        {
            var oParameters = new
            {
                Id = Id,
                GroupId = GrooupId,
                StatusSLA = StatusSLA,
                Peraturan = Peraturan,
                Keterangan = Keterangan,
                Waktu = Waktu,
                DihitungDari = DihitungDari,
                User = User,
                TypeTransaction = TypeTransaction
            };
            try
            {
                string result = DbTransaction.DbToString("Usp_SLA_InsertUpdate", oParameters, true);
                return result;
            }
            catch (Exception ex)
            {
                return "Terjadi kesalahan pada BLL SLA: " + ex.Message;
            }
        }
        public DataSet Get_MasterSla_ByID(long Id)
        {
            var oParameters = new
            {
                Id = Id
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_SLA_Getby_id", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Get_MasterSla_ByParam(int GroupId, string StatusSLA, string Peraturan)
        {
            var oParameters = new
            {
                GroupId = GroupId,
                Status = StatusSLA,
                peraturan = Peraturan
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_SLA_GetALl_byParam", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
