using LPS_API.Models.EksekusiModels;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.TransaksiControllers
{
    public class EksekusiCheckBeforePeriodeController : ApiController
    {
        public string Post(CheckBeforePeriodeModel CheckBeforePeriode)
        {
            try
            {
                TransaksiEksekusi TE = new TransaksiEksekusi();

                string hasil = TE.CheckBeforePeriodeIsComplete(CheckBeforePeriode.IDProjectHeader, CheckBeforePeriode.Periode);

                return hasil;
            }
            catch (Exception ex)
            {
                return "F|" + ex.Message;
            }
        }
    }
}
