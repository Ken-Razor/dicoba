using LPS_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPS_BLL
{
    public class BerandaProject
    {
        public DataTable ProjectHeader(int idproject)
        {
            var oParameters = new
            {
                IDProject = idproject
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Get_BerandaProjectHeader", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ProjectStakeholder(int projectid, string year, string month, string week)
        {
            var oParameters = new
            {
                IDProject = projectid,
                Year = year,
                Month = month,
                Week = week
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Get_BerandaProjectStakeholder", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ProjectTask(int projectid, string year, string month, string week)
        {
            var oParameters = new
            {
                IDProject = projectid,
                Year = year,
                Month = month,
                Week = week
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Get_BerandaProjectTask", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ProjectMileStone(int projectid, string year, string month, string week)
        {
            var oParameters = new
            {
                IDProject = projectid,
                Year = year,
                Month = month,
                Week = week
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Get_BerandaProjectMileStone", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ProjectConstraint(int idproject)
        {
            var oParameters = new
            {
                IDProject = idproject
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Get_BerandaProjectConstraint", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ProjectProgress(int projectid, string year, string month, string week)
        {
            var oParameters = new
            {
                IDProject = projectid,
                Year = year,
                Month = month,
                Week = week
            };
            try
            {
                DataTable data = DbTransaction.DbToDataTable("Get_BerandaProjectProgress", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
