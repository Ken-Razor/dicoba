using LPS_API.Helper;
using LPS_API.Models;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;

namespace LPS_API.Controllers
{
    public class EmailApprExecController : ApiController
    {
        public string Get(string username)
        {
            IntegrationSystem IS = new IntegrationSystem();
            GlobalFunction GF = new GlobalFunction();
            DataSet DS = IS.GetEmailDataApprExec(username);
            DataTable dtsedikit = DS.Tables[0];
            DataTable dtjauh = DS.Tables[1];
            DataTable dtTemplate = DS.Tables[2];
            DataTable dtName = DS.Tables[3];
            string RealName = dtName.Rows[0]["empl_mast_Name"].ToString();

            var AllStatus = "";

            if (dtsedikit.Rows.Count > 0)
            {
                string sedikittemplate = "";

                int i = 1;
                foreach (DataRow item in dtsedikit.Rows)
                {
                    sedikittemplate += "<tr>";
                    sedikittemplate += "<td>" + i + "</td>";
                    sedikittemplate += "<td>" + item["ProjectName"].ToString() + "</td>";
                    sedikittemplate += "<td>" + item["Planing"].ToString() + "</td>";
                    sedikittemplate += "<td>" + item["Realisasi"].ToString() + "</td>";
                    sedikittemplate += "<td>" + item["Pencapaian"].ToString() + "</td>";
                    sedikittemplate += "<td style='" + item["Status"].ToString() + "'>&nbsp;</td>";
                    if (item["LastUpdate"].ToString().Contains("1900"))
                    {
                        sedikittemplate += "<td> - </td>";

                    }
                    else
                    {
                        sedikittemplate += "<td>" + item["LastUpdate"].ToString() + "</td>";
                    }
                    sedikittemplate += "<td>" + item["IsTransformasi"] + "</td>";
                    sedikittemplate += "</tr>";

                    i = i + 1;
                }


                var EmailTemplate = String.Format(dtTemplate.Rows[0]["Template"].ToString(), RealName, sedikittemplate);

                var Email = username + "@lps.go.id";
                //var Email = "yovy.ramadhan@lps.go.id";
                var EmailSubject = "Daftar Project yang di bawah target";
                var Status = GF.Email(EmailTemplate, Email, EmailSubject);

                AllStatus += Status;
            }

            return AllStatus;
        }
    }
}

