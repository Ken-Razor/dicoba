using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.MasterDataModels
{
    public class ProjectKategoriModel
    {
        [DisplayName("Nomor Urut")]
        public int NoUrut { get; set; }

        [DisplayName("ID Kategori")]
        public int IDKategoriProject { get; set; }

        [DisplayName("Nama Kategori")]
        public string KategoriName { get; set; }

        [DisplayName("Deskripsi Program")]
        public string Description { get; set; }

        [DisplayName("Status Active")]
        public Boolean IsActive { get; set; }

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
    }
}