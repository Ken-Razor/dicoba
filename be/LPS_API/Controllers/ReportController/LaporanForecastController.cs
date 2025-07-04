using LPS_API.Models;
using LPS_BLL;
using LPS_BLL.Models.ReportModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.ReportController
{
    public class LaporanForecastController : ApiController
    {
        [HttpPost]
        [Route("api/LaporanForecast/GetListProject")]
        public List<ProjectForecastModel> GetListProject([FromBody] MultiPorpose persnum)
        {
            Forecast f = new Forecast();
            var Data = f.GetListEksekusi(persnum.ID);
            return Data;
        }

        [HttpPost]
        [Route("api/LaporanForecast/GenerateForecast")]
        public List<LaporanForecastModel> GenerateForecast([FromBody] LaporanForecastParamModel param)
        {
            List<LaporanForecastModel> result = new List<LaporanForecastModel>();
            Forecast f = new Forecast();
            result = f.GetListEksekusiForecast(param.ProjectHeaderId);
            f.ForecastProccess(result, param.ForecastMethod);
            return result;
        }

    }
}
