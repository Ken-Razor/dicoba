using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using LPS_API.Helper;
using LPS_API.Models;
using LPS_BLL;

namespace LPS_API.Controllers.SystemIntegration
{
    public class EmailIntegrationController : ApiController
    {
        public string Post([FromBody]EmailModel data)
        {
            int type = Convert.ToInt32(data.Type);
            int projectHeaderID = Convert.ToInt32(data.IDProjectHeader);
            string periode = data.Periode;

            IntegrationSystem IS = new IntegrationSystem();
            GlobalFunction GF = new GlobalFunction();
            DataSet EmailMain = IS.GetEmail(type, projectHeaderID, periode);
            DataTable Template = EmailMain.Tables[0];
            DataTable Detail = EmailMain.Tables[1];

            string status = "";
            string Email = "";
            string EmailFormat = "";
            string EmailSubject = "";
            if (Detail.Rows[0][0].ToString().Contains("E|") == false)
            {
                string UrlLink = ConfigurationManager.AppSettings["urllink"].ToString() + projectHeaderID.ToString();
                if (type == 1)
                {
                    EmailFormat = String.Format(Template.Rows[0]["Template"].ToString(), Detail.Rows[0][3].ToString(), Detail.Rows[0][1].ToString(), Detail.Rows[0][2].ToString(), UrlLink);
                    Email = Detail.Rows[0][0].ToString() + "@lps.go.id";
                    EmailSubject = "[Need Approval] Project Initation and Planning - " + Detail.Rows[0][1].ToString();
                    status = GF.Email(EmailFormat, Email, EmailSubject);

                    var log = IS.EmailLog(type, EmailSubject, "", status, projectHeaderID, Email);
                }
                else if (type == 2)
                {
                    EmailFormat = String.Format(Template.Rows[0]["Template"].ToString(), Detail.Rows[0][4].ToString(), Detail.Rows[0][1].ToString(), Detail.Rows[0][2].ToString(), Detail.Rows[0][3].ToString());
                    Email = Detail.Rows[0][0].ToString() + "@lps.go.id";
                    EmailSubject = "Aplikasi Pengolalaan Proyek ( Project Execution Approval )";
                    status = GF.Email(EmailFormat, Email, EmailSubject);

                    var log = IS.EmailLog(type, EmailSubject, "", status, projectHeaderID, Email);
                }
                else if (type == 3)
                {
                    for (int i = 0; i < Detail.Rows.Count; i++)
                    {
                        EmailFormat = String.Format(Template.Rows[i]["Template"].ToString(), Detail.Rows[i][4].ToString(), Detail.Rows[i][1].ToString(), Detail.Rows[i][2].ToString(), Detail.Rows[i][3].ToString(), UrlLink);
                        Email = Detail.Rows[i][0].ToString() + "@lps.go.id";
                        EmailSubject = "[Need Revise] Project Execution - " + Detail.Rows[0][1].ToString();
                        status = GF.Email(EmailFormat, Email, EmailSubject);

                        var log = IS.EmailLog(type, EmailSubject, "", status, projectHeaderID, Email);
                    }                
                }
                else if (type == 4)
                {
                    EmailFormat = String.Format(Template.Rows[0]["Template"].ToString(), Detail.Rows[0][4].ToString(), Detail.Rows[0][1].ToString(), Detail.Rows[0][2].ToString(), Detail.Rows[0][3].ToString(), UrlLink);
                    Email = Detail.Rows[0][0].ToString() + "@lps.go.id";
                    EmailSubject = "[Need Revise] Project Initation and Planning - " + Detail.Rows[0][1].ToString();
                    status = GF.Email(EmailFormat, Email, EmailSubject);

                    var log = IS.EmailLog(type, EmailSubject, "", status, projectHeaderID, Email);
                }


            
     
                
            }
            else
            {
                status = "Tidak ada penerima email";
            }
            return status;
        }

        [HttpGet]
        public List<Reciever> Get()
        {
            List<Reciever> Rec = new List<Reciever>();
            IntegrationSystem IS = new IntegrationSystem();
            GlobalFunction GF = new GlobalFunction();
            DataTable DT = IS.GetEmailBulk();

            Rec = GF.ConvertTo<Reciever>(DT);

            return Rec;
        }

        [HttpGet]
        [Route("api/EmailIntegration/GetEmailNorRealisation")]
        public List<Reciever> GetEmailNorRealisation()
        {
            List<Reciever> Rec = new List<Reciever>();
            IntegrationSystem IS = new IntegrationSystem();
            GlobalFunction GF = new GlobalFunction();
            DataTable DT = IS.GetEmailNoRealizationBulk();

            Rec = GF.ConvertTo<Reciever>(DT);

            return Rec;
        }

        [HttpGet]
        [Route("api/EmailIntegration/GetEmailApprovalPending")]
        public List<Reciever> GetEmailBulkApprovalEnding()
        {
            List<Reciever> Rec = new List<Reciever>();
            IntegrationSystem IS = new IntegrationSystem();
            GlobalFunction GF = new GlobalFunction();
            DataTable DT = IS.GetEmailBulkApprovalPending();

            Rec = GF.ConvertTo<Reciever>(DT);

            return Rec;
        }

    }
}
