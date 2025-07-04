using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.SystemIntegration
{
    public class DWEntity
    {
        public string PersonalNumber { get; set; }
        public string NIK { get; set; }
        public string Username { get; set; }
        public string Org_Unit_Mast_Code { get; set; }
        public string Nama { get; set; }
        public string JenisKelamin { get; set; }
        public string TempatLahir { get; set; }
        public string BirthDate { get; set; }
        public string EntryDate { get; set; }
        public string PensiunDate { get; set; }
        public string Status { get; set; }
        public string Leaving { get; set; }
        public string KodeUnitKerja { get; set; }
        public string TanggalDiPosisi { get; set; }
        public string Posisi { get; set; }
        public string KodePosisi { get; set; }
        public string TanggalDiJabatan { get; set; }
        public string Jabatan { get; set; }
        public string JabatanDirektur { get; set; }
        public string TanggalDiPangkat { get; set; }
        public string Pangkat { get; set; }
        public string KodePangkat { get; set; }
        public string Pendidikan { get; set; }
        public string Institusi { get; set; }
        public string Agama { get; set; }
        public string TanggalDiangkat { get; set; }
        public string StatusKerja { get; set; }
        public string StatusPerkawinan { get; set; }
        public string JumlahAnak { get; set; }
        public string Alamat { get; set; }
        public string empl_mast_ID { get; set; }
        public string empl_mast_Username { get; set; }
        public string empl_mast_NIP { get; set; }
        public string empl_mast_Name { get; set; }
        public string org_unit_mast_ID { get; set; }
        public string org_unit_mast_Name { get; set; }
        public string empl_mast_ActiveStatus { get; set; }
        public string empl_mast_IsContract { get; set; }
    }
}