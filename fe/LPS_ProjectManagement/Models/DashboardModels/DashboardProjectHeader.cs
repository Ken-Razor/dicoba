using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.DashboardModels
{
    public class DashboardProjectHeader
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsTransformation { get; set; }
        public string Pencapaian { get; set; }
        public string Anggaran { get; set; }
        public string Realisasi { get; set; }

        public static implicit operator List<object>(DashboardProjectHeader v)
        {
            throw new NotImplementedException();
        }

        //public DashboardProjectHeader() { }
        //public DashboardProjectHeader(int projectId, string projectCode, string projectName, bool isTransformation, string pencapaian, string anggaran, string realisasi)
        //{
        //    CultureInfo culture = new CultureInfo("id-ID");
        //    Id = projectId;
        //    Code = projectCode;
        //    Name = projectName;
        //    IsTransformation = isTransformation;
        //    Pencapaian = pencapaian;
        //    Anggaran = anggaran;
        //    Realisasi = realisasi;
        //}
    }
}