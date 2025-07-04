using LPS_API.Models.DashboardModels;
using LPS_BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace LPS_API.Controllers.DashboardControllers
{
    public class DashboardEksekutifController : ApiController
    {
        public DashboardEksekutif Get()
        {
            DashboardData dd = new DashboardData();
            List<GetTableEksekutif> listTableEksekutif = new List<GetTableEksekutif>();
            List<DashboardAllProjectStatus> listStatus = new List<DashboardAllProjectStatus>();
            List<DashboardTransformation> transformationDetails = new List<DashboardTransformation>();

            DashboardEksekutif modelEksekutif = new DashboardEksekutif();

            /*Get Project Status Data*/
            var dtStatus = new DataTable();
            dtStatus = dd.DashboardAllStatus();

            foreach (DataRow item in dtStatus.Rows)
            {
                DashboardAllProjectStatus model = new DashboardAllProjectStatus();
                model.StatusName = item["StatusName"].ToString();
                model.Total = Convert.ToInt32(item["Total"].ToString());

                listStatus.Add(model);
            }

            modelEksekutif.ListStatusProject = listStatus;

            /*Please Delete this Example Data if you already get real data */
            //var dtTableEks = new DataTable();

            GetTableEksekutif modelEks = new GetTableEksekutif();
            modelEks.ProjectNo = "128-xxi-008";
            modelEks.ProjectName = "Pembuatan Website LPS";
            modelEks.IsTransformation = 1;
            modelEks.Initiation = "Planning";
            modelEks.Perkembangan = Convert.ToInt32(50);
            modelEks.Anggaran = Convert.ToInt32(70);
            listTableEksekutif.Add(modelEks);

            modelEks = new GetTableEksekutif();
            modelEks.ProjectNo = "128-xxi-007";
            modelEks.ProjectName = "Pembuatan Website LPS";
            modelEks.IsTransformation = 1;
            modelEks.Initiation = "Execution";
            modelEks.Perkembangan = Convert.ToInt32(85);
            modelEks.Anggaran = Convert.ToInt32(72);
            listTableEksekutif.Add(modelEks);

            modelEks = new GetTableEksekutif();
            modelEks.ProjectNo = "128-xxi-006";
            modelEks.ProjectName = "Pembuatan Website LPS";
            modelEks.IsTransformation = 0;
            modelEks.Initiation = "Closing";
            modelEks.Perkembangan = Convert.ToInt32(36);
            modelEks.Anggaran = Convert.ToInt32(42);
            listTableEksekutif.Add(modelEks);

            modelEks = new GetTableEksekutif();
            modelEks.ProjectNo = "128-xxi-005";
            modelEks.ProjectName = "Pembuatan Website LPS";
            modelEks.IsTransformation = 1;
            modelEks.Initiation = "Closing";
            modelEks.Perkembangan = Convert.ToInt32(90);
            modelEks.Anggaran = Convert.ToInt32(98);
            listTableEksekutif.Add(modelEks);

            modelEks = new GetTableEksekutif();
            modelEks.ProjectNo = "128-xxi-004";
            modelEks.ProjectName = "Pembuatan Website LPS";
            modelEks.IsTransformation = 0;
            modelEks.Initiation = "Closing";
            modelEks.Perkembangan = Convert.ToInt32(20);
            modelEks.Anggaran = Convert.ToInt32(12);
            listTableEksekutif.Add(modelEks);

            modelEksekutif.ListEksekutif = listTableEksekutif;

            var dtTransformation = dd.DashboardTransformation();
            
            foreach(DataRow dr in dtTransformation.Rows)
            {
                DashboardTransformation transformation = new DashboardTransformation();
                transformation.Details = dr["Details"].ToString();
                transformation.TotalProject = Convert.ToInt32(dr["TotalProject"].ToString());
                transformation.TransformationPercentase = Convert.ToDouble(dr["TransformasiPercentase"].ToString());

                transformationDetails.Add(transformation);
            }

            modelEksekutif.ListTransformationProject = transformationDetails;

            /*Please Delete this Example Data if you already get real data */
            modelEksekutif.BudgetTransformation = Convert.ToDecimal(7.8);
            modelEksekutif.BudgetNonTransformation = Convert.ToDecimal(10.2);
            modelEksekutif.BudgetNonTransformationPercent = Convert.ToDecimal(70.2);
            modelEksekutif.BudgetTransformationPercent = Convert.ToDecimal(50.7);
            
            var json = JsonConvert.SerializeObject(modelEksekutif);

            return modelEksekutif;
        }
    }
}