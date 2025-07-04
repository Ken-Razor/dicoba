using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP_Scheduller
{
    class SAPIntegrationEntityRKAT
    {
        public string IDSAP { get; set; }
        public string ACTIVE { get; set; }
        public string COSTCTR { get; set; }
        public string KPI { get; set; }
        public string LEVEL { get; set; }
        public string SCALING { get; set; }
        public string STRAT_OBJ { get; set; }
        public string WORKPLAN_TYPE { get; set; }
        public string YEAR { get; set; }
        public string PARENT { get; set; }
        public string DESCRIPTION { get; set; }
        public string LONG_DESC { get; set; }
        public string EVDESCRIPTION { get; set; }
        public string KPI_GROUP { get; set; }
        public string PRO_GROUP { get; set; }
        public string UNCONTROLLABLE { get; set; }
    }

    class SAPIntegration
    {
            public string ACCT_CODE     {get;set;}
            public string AST_TYP       {get;set;}
            public string AUDITTRAIL    {get;set;}
            public string CATEGORY      {get;set;}
            public string COSTCTR       {get;set;}
            public string DRIVER        {get;set;}
            public string FLOW          {get;set;}
            public string RENCANA_KERJA {get;set;}
            public string RPTCURRENCY   {get;set;}
            public string STD_BIAYA     {get;set;}
            public string STRAT_OBJ     {get;set;}
            public string TIME          {get;set;}
            public string SIGNEDDATA    {get;set;}

    }

    class SAPMD_Account
    {
         public string ID                {get;set;}
         public string ACCTYPE           {get;set;}
         public string ASSUM_TYPE        {get;set;}
         public string DIMLIST_CF        {get;set;}
         public string EVDESCRIPTION     {get;set;}
         public string FS                {get;set;}
         public string PLANNING          {get;set;}
         public string RATETYPE          {get;set;}
         public string REF_ACCOUNT       {get;set;}
         public string SCALING           {get;set;}
         public string PARENTH1          {get;set;}
         public string PARENTH2          {get;set;}
         public string PARENTH3          {get;set;}
         public string PARENTH4          {get;set;}
         public string PARENTH5         { get; set; }
    }

    class SAPMD_Rencana_Kerja
    {
            public string ID                {get;set;}
            public string ACTIVE            {get;set;}
            public string COSTCTR           {get;set;}
            public string EVDESCRIPTION     {get;set;}
            public string KPI               {get;set;}
            public string KPI_GROUP         {get;set;}
            public string LEVEL             {get;set;}
            public string LONG_DESC         {get;set;}
            public string PRO_GROUP         {get;set;}
            public string SCALING           {get;set;}
            public string STRAT_OBJ         {get;set;}
            public string UNCONTROLLABLE    {get;set;}
            public string WORKPLAN_TYPE     {get;set;}
            public string YEAR              {get;set;}
            public string PARENTH1          {get;set;}
    }

    class LogScheduller
    {
        public string SchedulerName     {get;set;}
        public string Description       {get;set;}
        public int RowAffected          {get;set;}
        public DateTime startdate       {get;set;}
        public DateTime EndDate         {get;set;}
    }
}
