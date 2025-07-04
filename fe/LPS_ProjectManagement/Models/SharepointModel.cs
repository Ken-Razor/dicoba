using System;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.SharePoint.Client;
using System.Security;

using ClientOM = Microsoft.SharePoint.Client;
using System.Configuration;
using System.Net;
using System.Net.Http;
using File = System.IO.File;

namespace LPS_ProjectManagement.Models
{
    public class SharepointModel
    {
        public ClientContext clientContext { get; set; }
        private string ServerSiteUrl = ConfigurationManager.AppSettings["SharepointDomain"].ToString();
        private string LibraryUrl = ConfigurationManager.AppSettings["SharepointFolder"].ToString();
        private string UserName = ConfigurationManager.AppSettings["SharepointUsername"].ToString();
        private string Password = ConfigurationManager.AppSettings["SharepointPassword"].ToString();
        private string DocumentList = ConfigurationManager.AppSettings["SharepointDocumentList"].ToString();
        private string Domain = @"lps";
        private Web WebClient { get; set; }

        public SharepointModel()
        {
            this.Connect();
        }

        public void Connect()  
        {  
            try  
            {  
                clientContext = new ClientContext(ServerSiteUrl);  
                var securePassword = new SecureString();  
                foreach (char c in Password)  
                {  
                    securePassword.AppendChar(c);  
                }  
                clientContext.Credentials = new NetworkCredential(UserName, Password, Domain);  
                WebClient = clientContext.Web;  
            }  
            catch (Exception ex)  
            {  
                throw new Exception($"Failed to connect to SharePoint: {ex.Message}");  
            }  
        }

        public string UploadMultiFiles(HttpRequestBase Request, HttpServerUtilityBase Server, int DocType, string ProjHead, string PersonNumber, string IDDocPhase, Int64 TaskID, string ProjectName)  
{  
    try  
    {  
        HttpPostedFileBase file = null;  
        var status = "";  
        for (int f = 0; f < Request.Files.Count; f++)  
        {  
            file = Request.Files[f] as HttpPostedFileBase;  
            string filename = Path.GetFileName(file.FileName);  
            string ext = Path.GetExtension(file.FileName);  

            if (ext != ".exe" && ext != ".mpp")  
            {  
                // Ganti GenerateFileName dengan logika langsung  
                string namafile = "";  
                if (DocType == 1) namafile = "PC_" + filename;  
                else if (DocType == 2) namafile = "PP_" + filename;  
                else if (DocType == 3) namafile = "Milestone_" + filename;  
                else if (DocType == 4) namafile = "Closing_" + filename;  
                else if (DocType == 5) namafile = "Change_" + filename;  
                else if (DocType == 6) namafile = "Lampiran_" + filename;  

                var path = Path.Combine(Server.MapPath("~/UploadFile/"), namafile);  
                file.SaveAs(path);  

                using (var fs = new FileStream(path, FileMode.Open))  
                {  
                    var fi = new FileInfo(path);  
                    var list = clientContext.Web.Lists.GetByTitle(DocumentList);  
                    clientContext.Load(list.RootFolder);  
                    clientContext.ExecuteQuery();  
                    var fileUrl = $"{list.RootFolder.ServerRelativeUrl}/{LibraryUrl.Split('/')[1]}/{ProjHead}/{fi.Name}";  
                    Microsoft.SharePoint.Client.File.SaveBinaryDirect(clientContext, fileUrl, fs, true);  
                }  

                if (File.Exists(path)) File.Delete(path);  

                string param = $"{DocType}|{ProjHead}|{PersonNumber}|{namafile}|{IDDocPhase}|{TaskID}";  

                // Ganti CallApi dengan logika HttpClient langsung  
                Models.UserManagementModels.MultiPorpose MP = new Models.UserManagementModels.MultiPorpose();  
                MP.ID = param;  
                HttpClient client = new HttpClient();  
                string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "UploadFile";  
                Uri baseAddress = new Uri(url);  

                client.BaseAddress = baseAddress;  
                client.DefaultRequestHeaders.Accept.Clear();  
                var response = client.PostAsJsonAsync(baseAddress.ToString(), MP).Result;  
                var result = response.Content.ReadAsStringAsync().Result;  

                string val = result;  
                string va = val.Remove(0, 1);  
                string final = va.Remove(va.Length - 1);  

                status = final;  
            }  
            else  
            {  
                status = "File tidak didukung";  
            }  
        }  
        return status;  
    }  
    catch (Exception ex)  
    {  
        throw new Exception($"Upload failed: {ex.Message}");  
    }  
}
 
        private void EnsureFolderExists(ClientContext ctx, string folderUrl)  
        {  
            try  
            {  
                var folder = ctx.Web.GetFolderByServerRelativeUrl(folderUrl);  
                ctx.Load(folder);  
                ctx.ExecuteQuery();  
            }  
            catch (ServerException ex) when (ex.ServerErrorTypeName == "System.IO.FileNotFoundException")  
            {  
                // Buat folder jika tidak ada  
                ctx.Web.Folders.Add(folderUrl);  
                ctx.ExecuteQuery();  
            }  
        }  

        private void DeleteFileIfExists(ClientContext ctx, string fileUrl)  
        {  
            try  
            {  
                var file = ctx.Web.GetFileByServerRelativeUrl(fileUrl);  
                file.DeleteObject();  
                ctx.ExecuteQuery();  
            }  
            catch (Exception) { /* File tidak ada, tidak perlu dilakukan apa-apa */ }  
        }
        public string UploadMultiFilesandGetId(HttpRequestBase Request, HttpServerUtilityBase Server, int DocType, string ProjHead, string PersonNumber, string IDDocPhase, Int64 TaskID, string ProjectName)
        {
            try
            {
                HttpPostedFileBase file = null;
                var status = "";
                for (int f = 0; f < Request.Files.Count; f++)
                {
                    file = Request.Files[f] as HttpPostedFileBase;

                    string[] SubFolders = LibraryUrl.Split('/');
                    string filename = System.IO.Path.GetFileName(file.FileName);
                    string ext = Path.GetExtension(file.FileName);

                    if (ext != ".exe" && ext != ".mpp")
                    {
                        string namafile = "";
                        if (DocType == 1)
                        {
                            namafile = "PC_" + filename;
                        }
                        else
                        if (DocType == 2)
                        {
                            namafile = "PP_" + filename;
                        }
                        else
                        if (DocType == 3)
                        {
                            namafile = "Milestone_" + filename;
                        }
                        else
                        if (DocType == 4)
                        {
                            namafile = "Closing_" + filename;
                        }
                        else
                        if (DocType == 5)
                        {
                            namafile = "Change_" + filename;
                        }
                        else
                        if (DocType == 6)
                        {
                            namafile = "Lampiran_" + filename;
                        }
                        //var path = System.IO.Path.Combine(Server.MapPath("~/App_Data/uploads"), filename);
                        var path = System.IO.Path.Combine(Server.MapPath("~/UploadFile/"), namafile);
                        //var path = file.FileName;
                        file.SaveAs(path);

                        using (var fs = new FileStream(path, FileMode.Open))
                        {
                            var fi = new FileInfo(path);
                            var list = clientContext.Web.Lists.GetByTitle(DocumentList);
                            clientContext.Load(list.RootFolder);
                            clientContext.ExecuteQuery();
                            var fileUrl = String.Format("{0}/{1}/{2}/{3}", list.RootFolder.ServerRelativeUrl, SubFolders[1], ProjHead, fi.Name);

                            Microsoft.SharePoint.Client.File.SaveBinaryDirect(clientContext, fileUrl, fs, true);
                        }

                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }

                        string param = DocType + "|" + ProjHead + "|" + PersonNumber + "|" + namafile + "|" + IDDocPhase + "|" + TaskID;

                        Models.UserManagementModels.MultiPorpose MP = new Models.UserManagementModels.MultiPorpose();
                        MP.ID = param;
                        HttpClient client = new HttpClient();
                        string url = ConfigurationManager.AppSettings["WebAPI"].ToString() + "UploadFileGetId";
                        Uri baseAddress = new Uri(url);

                        client.BaseAddress = baseAddress;
                        client.DefaultRequestHeaders.Accept.Clear();
                        var response = client.PostAsJsonAsync(baseAddress.ToString(), MP).Result;
                        var result = response.Content.ReadAsStringAsync().Result;

                        string val = result;
                        string va = val.Remove(0, 1);
                        string final = va.Remove(va.Length - 1);

                        status = final;
                    }
                    else
                    {
                        status = "File tidak didukung";
                    }
                }

                return status;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //public Microsoft.SharePoint.Client.File DownloadFiles()
        //{
        //    try
        //    {
        //        string[] SubFolders = LibraryUrl.Split('/');
        //        string filename = System.IO.Path.GetFileName(file.FileName);

        //        var fi = new FileInfo(path);
        //        var list = clientContext.Web.Lists.GetByTitle(DocumentList);
        //        clientContext.Load(list.RootFolder);
        //        clientContext.ExecuteQuery();
        //        var fileUrl = String.Format("{0}/{1}/{2}/{3}", list.RootFolder.ServerRelativeUrl, SubFolders[1], ProjectName, fi.Name);

        //        return Microsoft.SharePoint.Client.File.OpenBinaryDirect(clientContext, fileUrl);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

        public string CreateFolderPerProject(string ProjectName)
        {

            try
            {
                List list = clientContext.Web.Lists.GetByTitle(DocumentList);
                var folder = list.RootFolder.Folders;
                clientContext.Load(folder);
                clientContext.ExecuteQuery();

                string[] SubFolders = LibraryUrl.Split('/');

                foreach (Folder subFolder in folder)
                {
                    if (subFolder.Name == SubFolders[1])
                    {
                        Folder folderm = AddSubFolder(subFolder, ProjectName);
                    }
                }

                return "";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
           
        }

        public Folder AddSubFolder(Folder ParentFolder, string folderName)
        {
            Folder resultFolder = ParentFolder.Folders.Add(folderName);
            clientContext.ExecuteQuery();
            return resultFolder;
        }

        public void DownloadFile(string ProjectName , string Filename)
        {
            try
            {
                HttpContext Context = HttpContext.Current;
                HttpResponse Response = HttpContext.Current.Response;
          
                byte[] Content = DownloadByte(ProjectName, Filename);

                string mimeType = MimeMapping.GetMimeMapping(Filename);

                Context.Response.ClearContent();
                Context.Response.Clear();
                Context.Response.ContentType = mimeType;
                Context.Response.AddHeader("content-disposition", "attachment; filename=" + Filename);
                Context.Response.BufferOutput = true;
                Context.Response.OutputStream.Write(Content, 0, Content.Length);
                Context.ApplicationInstance.CompleteRequest();
                Context.Response.Flush();
                Context.ApplicationInstance.CompleteRequest();
            }
            //Context.Response.End();
            catch (System.Threading.ThreadAbortException ex)
            {
                throw ex;
            }

        }

        public void DownloadPdf(string ProjectName, string Filename)
        {
            try
            {
                HttpContext Context = HttpContext.Current;
                HttpResponse Response = HttpContext.Current.Response;

                byte[] Content = DownloadByte(ProjectName, Filename);

                string mimeType = MimeMapping.GetMimeMapping(Filename);

                Context.Response.ClearContent();
                Context.Response.Clear();
                Context.Response.ContentType = mimeType;
                Context.Response.AddHeader("content-length", Content.Length.ToString());
                Context.Response.BufferOutput = true;
                Context.Response.BinaryWrite(Content);
                Context.ApplicationInstance.CompleteRequest();
                Context.Response.Flush();
                Context.ApplicationInstance.CompleteRequest();


                //string FilePath = Server.MapPath("javascript1-sample.pdf");
                //WebClient User = new WebClient();
                //Byte[] FileBuffer = User.DownloadData(FilePath);
                //if (FileBuffer != null)
                //{
                //    Response.ContentType = "application/pdf";
                //    Response.AddHeader("content-length", FileBuffer.Length.ToString());
                //    Response.BinaryWrite(FileBuffer);
                //}
            }
            
            catch (System.Threading.ThreadAbortException ex)
            {
                throw ex;
            }

        }

        public byte[] DownloadByte(string projectname , string filename)
        {
            WebClient webClient = new WebClient();
            webClient.Credentials = new NetworkCredential(UserName, Password, Domain);

            try
            {
                string[] SubFolders = LibraryUrl.Split('/');
                var list = clientContext.Web.Lists.GetByTitle(DocumentList);
                clientContext.Load(list.RootFolder);
                clientContext.ExecuteQuery();

                var fileUrl = String.Format("{0}/{1}/{2}/{3}/{4}", ServerSiteUrl, list.RootFolder.ServerRelativeUrl, SubFolders[1], projectname, filename);

               
                //set destination address
                var destination = System.Web.Hosting.HostingEnvironment.MapPath("~/UploadFile/") + filename;
                string localPath = new Uri(destination).LocalPath;
                var bytes = webClient.DownloadData(fileUrl);
                if (System.IO.File.Exists(destination))
                    System.IO.File.Delete(destination);

                return bytes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}