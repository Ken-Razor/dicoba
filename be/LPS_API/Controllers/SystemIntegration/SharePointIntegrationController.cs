using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Web.Http;
using LPS_API.Models.SystemIntegration;
using Microsoft.SharePoint.Client;

namespace LPS_API.Controllers.SystemIntegration
{
    public class SharePointIntegrationController : ApiController
    {


        public string Post()
        {
            var username = ConfigurationManager.AppSettings["SharepointUsername"].ToString(); 
            var password = ConfigurationManager.AppSettings["SharepointPassword"].ToString();       
            var domain = ConfigurationManager.AppSettings["SharepointDomain"].ToString();          
            var location = ConfigurationManager.AppSettings["SharepointFolder"].ToString();
            var fileName = @"C:\123.txt";
            var targetUrl = "/Shared Documents";

            using (var ctx = new ClientContext(webUri))
            {
                ctx.Credentials = new SharePointOnlineCredentials(username, password);

                //Upload file
                var targetFileUrl = String.Format("{0}/{1}", targetUrl, Path.GetFileName(targetUrl));
                using (var fs = new FileStream(sourceFilePath, FileMode.Open))
                {
                    Microsoft.SharePoint.Client.File.SaveBinaryDirect(ctx, targetFileUrl, fs, true);
                }

                //Set document properties
                var uploadedFile = ctx.Web.GetFileByServerRelativeUrl(targetFileUrl);
                var listItem = uploadedFile.ListItemAllFields;
                listItem["DocumentType"] = "Information";
                listItem.Update();
                ctx.ExecuteQuery();

            }
            //using (var clientContext = new ClientContext(domain))
            //{
            //    using (var fs = new FileStream(fileName, FileMode.Open))
            //    {
            //        clientContext.Credentials = new NetworkCredential(username, password, domain);
            //        var fi = new FileInfo(fileName);
            //        var list = clientContext.Web.Lists.GetByTitle(location);
            //        clientContext.Load(list.RootFolder);
            //        clientContext.ExecuteQuery();
            //        var fileUrl = String.Format("{0}/{1}", list.RootFolder.ServerRelativeUrl, fi.Name);

            //        Microsoft.SharePoint.Client.File.SaveBinaryDirect(clientContext, fileUrl, fs, true);
            //    }
            //}
            return null;
        }
        
    }
}
