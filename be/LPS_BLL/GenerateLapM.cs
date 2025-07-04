using LPS_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPS_BLL
{
    public class GenerateLapM
    {

        public DataSet Get_LapM_ProgressHeader( DateTime tanggal )
        {
            var oParameters = new
            {
                Date = tanggal
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_Get_LapM_ProgressHeader", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Get_LapM_ProjectTimeSeries(DateTime tanggal)
        {
            var oParameters = new
            {
                Date = tanggal
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_Get_LapM_ProjectTimeSeries", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Get_LapM_Capaian(DateTime tanggal)
        {
            var oParameters = new
            {
                Date = tanggal
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_Get_LapM_StatusPencapaian", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Get_LapM_RealisasiAnggaran(DateTime tanggal)
        {
            var oParameters = new
            {
                Date = tanggal
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_Get_LapM_RealisasiAnggaran", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Get_LapM_PencapaianperMinggu(DateTime tanggal)
        {
            var oParameters = new
            {
                Date = tanggal
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_Get_LapM_StatusPerMinggu", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
