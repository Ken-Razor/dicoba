using LPS_API.Models.SAPModels;
using LPS_API.Models.TransaksiDataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LPS_API.Models.MasterDataModels
{
    public class ProjectModel
    {
        [DisplayName("Nomor Urut")]
        public int NoUrut { get; set; }

        [DisplayName("ID Project")]
        public int IDProject { get; set; }

        [DisplayName("ID Kategori Project")]
        public int IDKategoriProject { get; set; }

        [DisplayName("ID Program")]
        public int IDProgram { get; set; }

        [DisplayName("ID Strategic Objective")]
        public int IDStrategicObjective { get; set; }

        [DisplayName("Priority")]
        public int IDProjectPriority { get; set; }

        [DisplayName("ID Department")]
        public int IDDepartment { get; set; }

        [DisplayName("Nomor Project")]
        public string ProjectNo { get; set; }

        [DisplayName("Tahun")]
        public string Year { get; set; }

        [DisplayName("Nama Project")]
        public string ProjectName { get; set; }

        [DisplayName("Bobot Project")]
        public double Weight { get; set; }

        [DisplayName("Poin Project")]
        public double Poin { get; set; }

        [DisplayName("Deskripsi Project")]
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

        [DisplayName("Jenis Transformasi")]
        public Boolean IsTransformasi { get; set; }

        [DisplayName("Status Active")]
        public Boolean IsActive { get; set; }

        public List<ProgramModel> ListProgram { get; set; }

        public List<RKATModel> ListRKAT { get; set; }
        public List<MkuModel> ListMKU { get; set; }

        public List<StrategicObjectiveModel> ListStrategicObjective { get; set;}

        public List<KPIOrganizationModel> ListKPIOrganization { get; set; }

        public List<ProjectPriorityModel> ListProjectPriority { get; set; }

        public List<DepartmentModel> ListDepartment { get; set; }

        public List<ProjectRoleGroupModel> ListProjectRoleGroup { get; set; }

        public List<RoleGroupModel> ListRoleGroup { get; set; }

        public List<ProjectKategoriModel> ListProjectKategori { get; set; }
    }
}