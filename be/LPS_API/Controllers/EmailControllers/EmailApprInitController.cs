using LPS_API.Helper;
using LPS_API.Models;
using LPS_BLL;
using LPS_BLL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Http;

namespace LPS_API.Controllers
{
    public class EmailApprInitController : ApiController
    {
        public string Get(string username)
        {
            try
            {
                IntegrationSystem IS = new IntegrationSystem();
                GlobalFunction GF = new GlobalFunction();
                var DS = IS.GetEmailApprovalPending(username);
                var DataList = GF.ConvertTo<EmailApprovalPendingModel>(DS.Tables[0]);
                var template = DS.Tables[1];
                var realname = GF.ConvertTo<RealNameListModel>(DS.Tables[2]).Select(q => q.RealName).FirstOrDefault();
                var AllStatus = "";
                string sedikittemplate = "";
                int i = 1;
                var application_url = ConfigurationManager.AppSettings["ApprovalPendinglink"].ToString();
                foreach (var data in DataList)
                {
                    sedikittemplate += "<tr>";
                    sedikittemplate += "<td>" + i + "</td>";
                    sedikittemplate += "<td>" + data.Periode + "</td>";
                    sedikittemplate += "<td>" + data.ProjectNo + "</td>";
                    sedikittemplate += "<td>" + data.ProjectName + "</td>";
                    sedikittemplate += "<td>" + data.IsTransformasi + "</td>";
                    sedikittemplate += $"<td><a href='"+ application_url + $"ProjectHeaderID={data.IDProjectHeader}|Keys={data.PeriodeRaw}' target='_blank'>Approval Link</a></td>";
                    sedikittemplate += "</tr>";
                    i = i + 1;
                }
                var EmailTemplate = String.Format(template.Rows[0]["Template"].ToString(), realname, sedikittemplate);
                var Email = username + "@lps.go.id";
                //var Email = "hannan.harahap@lps.go.id";
                var EmailSubject = "Daftar Project Pending Approval";
                var Status = GF.Email(EmailTemplate, Email, EmailSubject);
                AllStatus += Status;
                return AllStatus;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}

