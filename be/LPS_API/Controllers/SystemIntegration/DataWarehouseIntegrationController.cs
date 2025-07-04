using LPS_API.Helper;
using LPS_API.Models.DataWarehouseModels;
using LPS_API.Models.SystemIntegration;
using LPS_BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.SystemIntegration
{
    public class DataWarehouseIntegrationController : ApiController
    {
        GlobalFunction GF = new GlobalFunction();
        IntegrationSystem IS = new IntegrationSystem();
        public string Post([FromBody]DWEntity Data)
        {
            try
            {
               string PersonalNumber             = Data.PersonalNumber            ;
               string NIK                        = Data.NIK                       ;
               string Username                   = Data.Username                  ;
               string Org_Unit_Mast_Code         = Data.Org_Unit_Mast_Code        ;
               string Nama                       = Data.Nama                      ;
               string JenisKelamin               = Data.JenisKelamin              ;
               string TempatLahir                = Data.TempatLahir               ;
               string BirthDate                  = Data.BirthDate                 ;
               string EntryDate                  = Data.EntryDate                 ;
               string PensiunDate                = Data.PensiunDate               ;
               string Status                     = Data.Status                    ;
               string Leaving                    = Data.Leaving                   ;
               string KodeUnitKerja              = Data.KodeUnitKerja             ;
               string TanggalDiPosisi            = Data.TanggalDiPosisi           ;
               string Posisi                     = Data.Posisi                    ;
               string KodePosisi                 = Data.KodePosisi                ;
               string TanggalDiJabatan           = Data.TanggalDiJabatan          ;
               string Jabatan                    = Data.Jabatan                   ;
               string JabatanDirektur            = Data.JabatanDirektur           ;
               string TanggalDiPangkat           = Data.TanggalDiPangkat          ;
               string Pangkat                    = Data.Pangkat                   ;
               string KodePangkat                = Data.KodePangkat               ;
               string Pendidikan                 = Data.Pendidikan                ;
               string Institusi                  = Data.Institusi                 ;
               string Agama                      = Data.Agama                     ;
               string TanggalDiangkat            = Data.TanggalDiangkat           ;
               string StatusKerja                = Data.StatusKerja               ;
               string StatusPerkawinan           = Data.StatusPerkawinan          ;
               string JumlahAnak                 = Data.JumlahAnak                ;
               string Alamat                     = Data.Alamat                    ;
               string empl_mast_ID               = Data.empl_mast_ID              ;
               string empl_mast_Username         = Data.empl_mast_Username        ;
               string empl_mast_NIP              = Data.empl_mast_NIP             ;
               string empl_mast_Name             = Data.empl_mast_Name            ;
               string org_unit_mast_ID           = Data.org_unit_mast_ID          ;
               string org_unit_mast_Name         = Data.org_unit_mast_Name        ;
               string empl_mast_ActiveStatus     = Data.empl_mast_ActiveStatus    ;
               string empl_mast_IsContract       = Data.empl_mast_IsContract;

                var result = IS.DWInsertKaryawan(
                        PersonalNumber          ,
                        NIK                     ,
                        Username                ,
                        Org_Unit_Mast_Code      ,
                        Nama                    ,
                        JenisKelamin            ,
                        TempatLahir             ,
                        BirthDate               ,
                        EntryDate               ,
                        PensiunDate             ,
                        Status                  ,
                        Leaving                 ,
                        KodeUnitKerja           ,
                        TanggalDiPosisi         ,
                        Posisi                  ,
                        KodePosisi              ,
                        TanggalDiJabatan        ,
                        Jabatan                 ,
                        JabatanDirektur         ,
                        TanggalDiPangkat        ,
                        Pangkat                 ,
                        KodePangkat             ,
                        Pendidikan              ,
                        Institusi               ,
                        Agama                   ,
                        TanggalDiangkat         ,
                        StatusKerja             ,
                        StatusPerkawinan        ,
                        JumlahAnak              ,
                        Alamat                  ,
                        empl_mast_ID            ,
                        empl_mast_Username      ,
                        empl_mast_NIP           ,
                        empl_mast_Name          ,
                        org_unit_mast_ID        ,
                        org_unit_mast_Name      ,
                        empl_mast_ActiveStatus  ,
                        empl_mast_IsContract
                    );

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    


    }
}
