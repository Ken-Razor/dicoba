using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LPS_ProjectManagement.Common
{
    public class CustomAuthorizationAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //var handler = new HttpClientHandler
            //{
            //    ServerCertificateValidationCallback = delegate { return true; }
            //};
            var Session = filterContext.HttpContext.Session;
            string isSSO = "false";
            if (isSSO == "false")
            {
                if (Session["PersonalNumber"] == null)
                {
                    var RedirectTarget = new RouteValueDictionary { { "action", "Login" }, { "controller", "Login" }, { "ReturnURL", filterContext.HttpContext.Request.Url } };
                    filterContext.Result = new RedirectToRouteResult(RedirectTarget);
                }
            }
            else
            {
                if (Session["JWTSSO"] == null || Session["UserGid"] == null)
                {
                    var RedirectTarget = new RouteValueDictionary { { "action", "Login" }, { "controller", "Login" }, { "ReturnURL", filterContext.HttpContext.Request.Url } };
                    filterContext.Result = new RedirectToRouteResult(RedirectTarget);
                }
                else
                {
                    try
                    {
                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                        HttpClient client = new HttpClient();
                        //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["JWTSSO"].ToString());
                        string apiEndpoint = ConfigurationManager.AppSettings["SSO_SESSION_URL"] + "checksession?iLogin=" + Session["UserGid"].ToString();

                        HttpResponseMessage response = client.GetAsync(apiEndpoint).Result;
                        if (!response.IsSuccessStatusCode)
                        {
                            var RedirectTarget = new RouteValueDictionary { { "action", "Logout" }, { "controller", "Account" }, { "ReturnURL", filterContext.HttpContext.Request.Url } };
                            filterContext.Result = new RedirectToRouteResult(RedirectTarget);
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
    }
}