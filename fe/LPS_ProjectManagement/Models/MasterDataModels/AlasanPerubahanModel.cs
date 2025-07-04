using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.MasterDataModels
{
    public class AlasanPerubahanModel
    {
        public int IDAlasanPerubahan { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public Boolean IsActive { get; set; }
    }
}