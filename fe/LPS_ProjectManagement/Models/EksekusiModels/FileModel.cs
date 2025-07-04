using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.EksekusiModels
{
    public class FileModel
    {
        public List<files> listfile {get; set;}
    }

    public class files
    {
        public HttpPostedFileBase File { get; set; }
    }
}