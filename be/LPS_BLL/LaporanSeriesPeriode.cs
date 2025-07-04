using LPS_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LPS_BLL
{
    public class LaporanSeriesPeriode
    {

        public DataTable GetLaporanGrafikSeriesPeriode(string Filter, int Year)
        {
            var oParameters = new
            {
                Filter = Filter,
                Year = Year
            };
            try
            {
                DataTable dt = DbTransaction.DbToDataTable("Get_Grafik_Periode", oParameters, true);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
