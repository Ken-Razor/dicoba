using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.MasterDataModels
{
    public class DirektoratModel
    {
        public int IDDirektorat { get; set; }

        public string RefID { get; set; }

        public string DirektoratCode { get; set; }

        public string DirektoratName { get; set; }

        public string Description { get; set; }

        public Boolean IsActive { get; set; }
    }
}