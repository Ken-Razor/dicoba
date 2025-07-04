using LPS_API.Models.DashboardModels;
using LPS_BLL;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;

namespace LPS_API.Controllers.DashboardControllers
{
    public class DashboardSOStackedBarController : ApiController
    {
        // GET: DashboardSOStackedBar
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public DashboardSOStackedBarModel Get()
        {
                DashboardData dd = new DashboardData();
                DashboardSOStackedBarModel model = new DashboardSOStackedBarModel();
                List<SODetails> detailSo = new List<SODetails>();
                List<ProgressSO> soProgress = new List<ProgressSO>();

                /*Please delete this dummy data if you already get real data*/
                SODetails modelSO = new SODetails();
                modelSO.SOCode = "2017.SO9";
                modelSO.SOName = "Terwujudnya tatakelola yang baik sekali";
                detailSo.Add(modelSO);

                modelSO = new SODetails();
                modelSO.SOCode = "2017.SO11.123456789";
                modelSO.SOName = "Terjaganya likuiditas dan efisiensi keuangan";
                detailSo.Add(modelSO);

                modelSO = new SODetails();
                modelSO.SOCode = "2018.SO.04";
                modelSO.SOName = "Penanganan bank gagal secara optimal";
                detailSo.Add(modelSO);

                modelSO = new SODetails();
                modelSO.SOCode = "2017.SO9";
                modelSO.SOName = "Terwujudnya tatakelola yang baik";
                detailSo.Add(modelSO);

                modelSO = new SODetails();
                modelSO.SOCode = "2018.SO.02";
                modelSO.SOName = "Program penjaminan simpanan dan resolusi bank yang efektif";
                detailSo.Add(modelSO);

                //modelSO = new SODetails();
                //modelSO.SOCode = "2018.SO.01";
                //modelSO.SOName = "Terciptanya kepercayaan publik terhadap program penjaminan simpanan";
                //detailSo.Add(modelSO);

                //modelSO = new SODetails();
                //modelSO.SOCode = "2017.SO10";
                //modelSO.SOName = "Pengelolaan keuangan yang efisien dan akuntabel";
                //detailSo.Add(modelSO);

                //modelSO = new SODetails();
                //modelSO.SOCode = "2017.SO6";
                //modelSO.SOName = "Penanganan bank yang diselamatkan secara tuntas dan optimal";
                //detailSo.Add(modelSO);

                model.ListSoDetails = detailSo;

                ProgressSO progressModel = new ProgressSO();
                List<Progress> data = new List<Progress>();

                progressModel.StatusName = "Red";
                Progress progress = new Progress();
                progress.ProgressData = 9;
                data.Add(progress);

                progress = new Progress();
                progress.ProgressData = 7;
                data.Add(progress);

                progress = new Progress();
                progress.ProgressData = 5;
                data.Add(progress);

                progress = new Progress();
                progress.ProgressData = 3;
                data.Add(progress);

                progress = new Progress();
                progress.ProgressData = 1;
                data.Add(progress);

                progressModel.Progres = data;
          
                soProgress.Add(progressModel);

                progressModel = new ProgressSO();
                progressModel.StatusName = "Yellow";
                data = new List<Progress>();
                progress = new Progress();
                progress.ProgressData = 9;
                data.Add(progress);

                progress = new Progress();
                progress.ProgressData = 7;
                data.Add(progress);

                progress = new Progress();
                progress.ProgressData = 5;
                data.Add(progress);

                progress = new Progress();
                progress.ProgressData = 3;
                data.Add(progress);

                progress = new Progress();
                progress.ProgressData = 1;
                data.Add(progress);

                progressModel.Progres = data;

                soProgress.Add(progressModel);

                progressModel = new ProgressSO();
                progressModel.StatusName = "Green";
                data = new List<Progress>();
                progress = new Progress();
                progress.ProgressData = 9;
                data.Add(progress);

                progress = new Progress();
                progress.ProgressData = 7;
                data.Add(progress);

                progress = new Progress();
                progress.ProgressData = 5;
                data.Add(progress);

                progress = new Progress();
                progress.ProgressData = 3;
                data.Add(progress);

                progress = new Progress();
                progress.ProgressData = 1;
                data.Add(progress);

                progressModel.Progres = data;

                soProgress.Add(progressModel);

                progressModel = new ProgressSO();
                progressModel.StatusName = "Blue";
                data = new List<Progress>();
                progress = new Progress();
                progress.ProgressData = 9;
                data.Add(progress);

                progress = new Progress();
                progress.ProgressData = 7;
                data.Add(progress);

                progress = new Progress();
                progress.ProgressData = 5;
                data.Add(progress);

                progress = new Progress();
                progress.ProgressData = 3;
                data.Add(progress);

                progress = new Progress();
                progress.ProgressData = 1;
                data.Add(progress);

                progressModel.Progres = data;

                soProgress.Add(progressModel);

                model.ListProgressSO = soProgress;

                var json = JsonConvert.SerializeObject(model);

            return model;
        }
    }
}