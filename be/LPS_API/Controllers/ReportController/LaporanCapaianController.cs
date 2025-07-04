using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LPS_API.Helper;
using LPS_API.Models.ReportModels;
using LPS_BLL;
namespace LPS_API.Controllers.ReportController
{
    public class LaporanCapaianController : ApiController
    {
        public LaporanCapaian Push([FromBody]PencapainParam Data)
        {

            Report R = new Report();
            GlobalFunction GF = new GlobalFunction();

            LaporanCapaian LC = new LaporanCapaian();

            List<PencapaianSO>          SO  = new List<PencapaianSO>();
            List<PencapaianTrans>    Trans  = new  List<PencapaianTrans>();
            List<PencapaianDirektorat> Dir  = new List<PencapaianDirektorat>();


            if (Data.jenisapi == "Trans")
            {
                Trans = GF.ConvertTo<PencapaianTrans>(R.Get_Report_PencapaianTransformasi(Data.week, Data.month, Data.year, Data.tipe));
            } else
            if (Data.jenisapi == "SO")
            {
                SO = GF.ConvertTo<PencapaianSO>(R.Get_Report_PencapaianSO(Data.week, Data.month, Data.year));
            } else
            if (Data.jenisapi == "Direktorat")
            {
                Dir = GF.ConvertTo<PencapaianDirektorat>(R.Get_Report_PencapaianDirektorat(Data.week, Data.month, Data.year));
            }

            LC.Dir = Dir;
            LC.Trans = Trans;
            LC.SO = SO;

            return LC;
        }
    }
}
