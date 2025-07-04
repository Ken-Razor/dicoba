using LPS_API.Models.MasterDataModels;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.MasterControllers
{
    public class MasterKPIValueController : ApiController
    {

        public List<KPIValueModel> Get()
        {
            MasterData md = new MasterData();
            List<KPIValueModel> ListKPIValue = new List<KPIValueModel>();

            foreach (DataRow dr in md.Get_MasterKPIValue("100010").Rows)
            {
                KPIValueModel KPIValue = new KPIValueModel();

                KPIValue.NoUrut = dr["NoUrut"].ToString();
                if (dr["IDKPIValue"].ToString() != "") KPIValue.IDKPIValue = Convert.ToInt32(dr["IDKPIValue"]);
                if (dr["IDProject"].ToString() != "") KPIValue.IDProject = Convert.ToInt32(dr["IDProject"]);
                KPIValue.ProjectName = dr["ProjectName"].ToString();
                KPIValue.ProjectNo = dr["ProjectNo"].ToString();
                KPIValue.TW1 = dr["TW1"].ToString();
                KPIValue.TW2 = dr["TW2"].ToString();
                KPIValue.TW3 = dr["TW3"].ToString();
                KPIValue.TW4 = dr["TW4"].ToString();

                ListKPIValue.Add(KPIValue);
            }
            return ListKPIValue;
        }
        
        public KPIValueModel Post(KPIValueModel obj)
        {
            MasterData md = new MasterData();
            KPIValueModel KPIValue = new KPIValueModel();
            DataTable dt = md.Get_MasterKPIValue_ByID(obj.PersonNumber, obj.IDProject);

            if(dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                KPIValue.NoUrut = dr["NoUrut"].ToString();
                if (dr["IDKPIValue"].ToString() != "") KPIValue.IDKPIValue = Convert.ToInt32(dr["IDKPIValue"]);
                if (dr["IDProject"].ToString() != "") KPIValue.IDProject = Convert.ToInt32(dr["IDProject"]);
                KPIValue.ProjectName = dr["ProjectName"].ToString();
                KPIValue.ProjectNo = dr["ProjectNo"].ToString();
                KPIValue.TW1 = dr["TW1"].ToString();
                KPIValue.TW2 = dr["TW2"].ToString();
                KPIValue.TW3 = dr["TW3"].ToString();
                KPIValue.TW4 = dr["TW4"].ToString();

            }
            
            return KPIValue;
        }

    }
}
