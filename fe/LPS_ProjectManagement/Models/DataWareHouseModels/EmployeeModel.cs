using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.DataWareHouseModels
{
    public class EmployeeModel
    {
        public int IDDWEmployee { get; set; }

        public string PersonalNumber { get; set; }

        public string NIK { get; set; }

        public string Asses { get; set; }

        public string Nama { get; set; }

        public string JenisKelamin { get; set; }

        public string TempatLahir { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime PensiunDate { get; set; }

        public int Status { get; set; }

        public DateTime Leaving { get; set; }

        public int KodeUnitKerja { get; set; }

        public DateTime TanggalDiPosisi { get; set; }

        public string Posisi { get; set; }

        public int KodePosisi { get; set; }

        public DateTime TanggalDiJabatan { get; set; }

        public string Jabatan { get; set; }

        public DateTime TanggalDiPangkat { get; set; }

        public string Pangkat { get; set; }

        public string KodePangkat { get; set; }

        public string Pendidikan { get; set; }

        public string Institusi { get; set; }

        public string Agama { get; set; }

        public DateTime TanggalDiangakt { get; set; }

        public string StatusKerja { get; set; }

        public string StatusPerkawinan { get; set; }

        public int jumlahAnak { get; set; }

        public string Alamat { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }
    }
}