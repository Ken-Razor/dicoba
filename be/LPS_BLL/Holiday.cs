using LPS_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPS_BLL
{
    public class Holiday
    {

        public DataSet Get_Master_Holiday(int tahun)
        {
            var oParameters = new
            {
                tahun = tahun,
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_Get_MasterHoliday", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Get_Master_Holiday_byId(int id)
        {
            var oParameters = new
            {
                ID = id,
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_Get_Holiday_byId", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Insert_Update_Master_Holiday(int Id, string nama, DateTime TglMulai, DateTime Tglselesai, string user)
        {
            var oParameters = new
            {
                ID = Id,
                nama = nama,
                TglMulai = TglMulai,
                TglSelesai = Tglselesai,
                usr = user
            };
            try
            {
                string result = DbTransaction.DbToString("Usp_Insert_Holiday", oParameters, true);
                return result;
            }
            catch (Exception ex)
            {
                return "Terjadi kesalahan pada BLL Holiday: " + ex.Message;
            }
        }

        public string Delete_Master_Holiday(int Id)
        {
            var oParameters = new
            {
                ID = Id
            };
            try
            {
                string result = DbTransaction.DbToString("Usp_Delete_Holiday", oParameters, true);
                return result;
            }
            catch (Exception ex)
            {
                return "Terjadi kesalahan pada BLL Holiday: " + ex.Message;
            }
        }
        public DataSet Get_Holiday_tahun()
        {
            var oParameters = new
            {
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_Get_HolidayYear", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
