using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP_Scheduller
{
    class ActuateEntity
    {
    }

    class SO
    {
        public string SO_ID       {get; set;}
        public string SO_Code     {get; set;}
        public string SO_Name     {get; set;}
        public string SO_Desc     {get; set;}
        public string SO_Year     {get; set;}
        public string SO_IsActive {get; set;}
    }

    class KPI
    {
      public string KPI_ID       {get; set;}
      public string KPI_SO_ID    {get; set;}
      public string KPI_Code     {get; set;}
      public string KPI_Name     {get; set;}
      public string KPI_Desc     {get; set;}
      public string KPI_Year     {get; set;}
      public string KPI_IsActive { get; set; }
    }
}
