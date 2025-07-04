using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LPS_ProjectManagement.Controllers
{
    public class ManualController : Controller
    {
        // GET: Manual
        public FileResult UserADMIN()
        {
            try
            {
                var docname = "3. Panduan Penggunaan Sistem Project Admin v.3-Training.pdf";
                var FileVirtualPath = "~/Files/" + docname;
                return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public FileResult UserPM()
        {
            try
            {
                var docname = "4.5.2. Panduan Penggunaan Sistem Group Project Manager v.1-Training.pdf";
                var FileVirtualPath = "~/Files/" + docname;
                return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}