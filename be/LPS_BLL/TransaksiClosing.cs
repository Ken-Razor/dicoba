using LPS_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPS_BLL
{
    public class TransaksiClosing
    {
        public DataTable Get_TransaksiClosingProjectHeader(string PersonalNumber)
        {
            var oParameters = new
            {
                PersonalNumber = PersonalNumber
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Usp_Get_TransaksiClosingProjectHeader", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Get_TransaksiClosingProjectHeader_ByID(int IDProjectHeader)
        {
            var oParameters = new
            {
                IDProjectHeader = IDProjectHeader
            };
            try
            {
                DataSet data = DbTransaction.DbToDataSet("Usp_Get_TransaksiClosingProjectHeader_ByID", oParameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Insert_TransaksiClosingProjectHeader(
            int IDProjectHeader,
            DateTime ClosingDate,
            string Remarks,
            string WhatWorkWell,
            string WhatDidNotWorkWell,
            string WhatCanBeImproved,
            string TypeTransaction,
            string User
        )
        {
            var oParameters = new
            {
                IDProjectHeader = IDProjectHeader,
                ClosingDate = ClosingDate,
                Remarks = Remarks,
                WhatWorkWell = WhatWorkWell,
                WhatDidNotWorkWell = WhatDidNotWorkWell,
                WhatCanBeImproved = WhatCanBeImproved,
                TypeTransaction = TypeTransaction,
                User = User
            };
            try
            {
                string result = DbTransaction.DbToString("Usp_Insert_TransaksiProjectClosing", oParameters, true);
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
