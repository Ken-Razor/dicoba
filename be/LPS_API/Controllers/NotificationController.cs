using LPS_API.Models;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers
{
    public class NotificationController : ApiController
    {
        public List<NotificationModel> Post([FromBody]string not)
        {
            Report r = new Report();
            List<NotificationModel> ListNotification = new List<NotificationModel>();

            foreach (DataRow dr in r.Get_Notification(not).Rows)
            {
                NotificationModel Notify = new NotificationModel();

                Notify.ProjectName = dr["ProjectName"].ToString();
                if (dr["IDProject"].ToString() != "") Notify.IDProject = Convert.ToInt32(dr["IDProject"]);
                Notify.Category = dr["Category"].ToString();
                Notify.Phase = dr["Phase"].ToString();
                Notify.Keys = dr["Keys"].ToString();

                ListNotification.Add(Notify);
            }
            return ListNotification;
        }

        public List<NotificationModelECM> Get(string username)
        {
            Report r = new Report();
            List<NotificationModelECM> ListNotification = new List<NotificationModelECM>();
            DataTable dt = r.Get_Notification_ECM(username);
            foreach (DataRow dr in dt.Rows)
            {
                NotificationModelECM Notify = new NotificationModelECM();

                Notify.ProjectName = dr["ProjectName"].ToString();
                if (dr["IDProject"].ToString() != "") Notify.IDProject = Convert.ToInt32(dr["IDProject"]);
                Notify.Category = dr["Category"].ToString();
                Notify.Phase = dr["Phase"].ToString();
                Notify.Keys = dr["Keys"].ToString();
                Notify.URI = dr["URI"].ToString();

                ListNotification.Add(Notify);
            }
            return ListNotification;
        }
    }
}
