using LPS_BLL.Models.ReportModels;
using LPS_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPS_BLL
{
    public class LaporanSeriesGrafikCapaian
    {
        public List<LaporanSeriesGrafikCapaianHeaderModel> GetSeriesGrafikCapaianFisikHeader(LaporanSeriesGrafikCapaianParamModel param)
        {

            var oParameters = new
            {
                Year = param.Year,
                Month = param.Month,
                Week = param.Week,
                Category = param.Category
            };
            try
            {
                var data = DbTransaction.DbToList<LaporanSeriesGrafikCapaianHeaderModel>("Usp_Get_GrafikCapaianFisikHeader", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LaporanSeriesGrafikCapaianHeaderKpiModel> GetSeriesGrafikCapaianKpiHeader(LaporanSeriesGrafikCapaianParamModel param)
        {

            var oParameters = new
            {
                Year = param.Year,
                Category = param.Category,
                TW = param.Tw
            };
            try
            {
                var data = DbTransaction.DbToList<LaporanSeriesGrafikCapaianHeaderKpiModel>("Usp_Get_GrafikCapaianKpiHeader", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LaporanSeriesGrafikCapaianDetailModel> GetSeriesGrafikCapaianFisikDetail(LaporanSeriesGrafikCapaianParamModel param)
        {

            var oParameters = new
            {
                Year = param.Year,
                Month = param.Month,
                Week = param.Week,
                Category = param.Category
            };
            try
            {
                var data = DbTransaction.DbToList<LaporanSeriesGrafikCapaianDetailModel>("Usp_Get_GrafikCapaianFisikDetail", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LaporanSeriesGrafikCapaianDetailModel> GetSeriesGrafikCapaianKpiDetail(LaporanSeriesGrafikCapaianParamModel param)
        {

            var oParameters = new
            {
                Year = param.Year,
                Category = param.Category,
                TW = param.Tw
            };
            try
            {
                var data = DbTransaction.DbToList<LaporanSeriesGrafikCapaianDetailModel>("Usp_Get_GrafikCapaianKpiDetail2", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
