using LPS_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPS_BLL
{
    public class BackgroundJob
    {
        public string GenerateKpiValueJob()
        {
            var oParameters = new
            {
            };
            try
            {
                var data = DbTransaction.DbToString("Usp_Generate_ProjectKPI", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
