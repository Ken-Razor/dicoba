using LPS_API.Helper;
using LPS_API.Models.ReportModels;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.ReportController
{
    public class DetailAnggaranController : ApiController
    {
        GlobalFunction gf = new GlobalFunction();

        public List<DetailAnggaranModel> Post([FromBody]DetailAnggaranModel obj)
        {
            Report r = new Report();

            DataSet ds = r.Get_Detail_Anggaran(obj.IDDirektorat, obj.IDDepartment, obj.YEAR, obj.IDSAP);
            DataTable dt1 = ds.Tables[0];
            int NoUrut = 1;

            List<DetailAnggaranModel> ListDetailAnggaran = new List<DetailAnggaranModel>();

            foreach (DataRow dr in dt1.Rows)
            {
                DetailAnggaranModel DetailAnggaran = new DetailAnggaranModel();

                DetailAnggaran.NoUrut = NoUrut.ToString();
                DetailAnggaran.DirektoratName = dr["DirektoratName"].ToString();
                DetailAnggaran.DepartmentName = dr["DepartmentName"].ToString();
                DetailAnggaran.IDSAP = dr["IDSAP"].ToString();
                DetailAnggaran.YEAR = dr["YEAR"].ToString();
                DetailAnggaran.EVDESCRIPTION = dr["EVDESCRIPTION"].ToString();
                DetailAnggaran.ACCT_CODE = dr["ACCT_CODE"].ToString();
                DetailAnggaran.EVDESCRIPTION_Detail = dr["EVDESCRIPTION_Detail"].ToString();
                DetailAnggaran.Anggaran = gf.ToRupiah(dr["Anggaran"].ToString());
                DetailAnggaran.Pergeseran = gf.ToRupiah(dr["Pergeseran"].ToString());
                DetailAnggaran.Hangus = gf.ToRupiah(dr["Hangus"].ToString());
                DetailAnggaran.Realisasi = gf.ToRupiah(dr["Realisasi"].ToString());
                DetailAnggaran.Komitmen = gf.ToRupiah(dr["Komitmen"].ToString());
                DetailAnggaran.Sisa = gf.ToRupiah((Convert.ToDouble(dr["Anggaran"]) + Convert.ToDouble(dr["Pergeseran"]) + Convert.ToDouble(dr["Hangus"]) - Convert.ToDouble(dr["Realisasi"]) - Convert.ToDouble(dr["Komitmen"])).ToString());

                ListDetailAnggaran.Add(DetailAnggaran);

                NoUrut++;
            }

            return ListDetailAnggaran;
        }
    }
}
