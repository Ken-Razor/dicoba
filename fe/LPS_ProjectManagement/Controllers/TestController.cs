using net.sf.mpxj.mpp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LPS_ProjectManagement.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadProject(HttpPostedFileBase file)
        {
            // Read file content into byte[]
            var buffer = new byte[file.InputStream.Length];
            file.InputStream.Read(buffer, 0, (int)file.InputStream.Length);

            // Read the content using a new 'java' inputStream
            var reader = new MPPReader();
            var project = reader.read(new java.io.ByteArrayInputStream(buffer));

            return null;
        }
    }
}
