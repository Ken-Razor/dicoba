using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LPS_API.Models.MasterDataModels
{
    public class ProgramModel
    {
        [DisplayName("Nomor Urut")]
        public int NoUrut { get; set; }

        [DisplayName("ID Program")]
        public int IDProgram { get; set; }

        [DisplayName("Nomor Program")]
        public string ProgramNo { get; set; }

        [DisplayName("Nama Program")]
        public string ProgramName { get; set; }

        [DisplayName("Deskripsi Program")]
        public string Description { get; set; }

        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }

        [DisplayName("Created By")]
        public string CreatedBy { get; set; }

        [DisplayName("Updated Date")]
        public DateTime UpdatedDate { get; set; }

        [DisplayName("Updated Date")]
        public string UpdatedDateString { get; set; }

        [DisplayName("Updated By")]
        public string UpdatedBy { get; set; }

        [DisplayName("Status Active")]
        public Boolean IsActive { get; set; }
    }
}