using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace HrgaEnhance.Models
{
    public class ClsParameter
    {
        public class Karyawan
        {
            #region Parameter Karyawan
            [Required(ErrorMessage = "Nrp harus diisi")]
            public String Nrp { get; set; }

            [Required(ErrorMessage = "Nama harus diisi")]
            public String Nama { get; set; }

            public String TempatLahir { get; set; }

            [Required(ErrorMessage = "Tanggal Lahir harus diisi")]
            public DateTime? TglLahir { get; set; }

            [Required(ErrorMessage = "Jenis Kelamin harus diisi")]
            public String JenisKelamin { get; set; }

            public String GolonganDarah { get; set; }

            [Required(ErrorMessage = "Status Perkawinan harus diisi")]
            public String StatusKawin { get; set; }

            [Required(ErrorMessage = "Agama harus diisi")]
            public String Agama { get; set; }

            [Required(ErrorMessage = "Pendidikan harus diisi")]
            public String Pendidikan { get; set; }

            [Required(ErrorMessage = "Alamat Tinggal harus diisi")]
            public String AlamatTinggal { get; set; }

            public String Jamsostek { get; set; }

            public String DPA { get; set; }

            [Required(ErrorMessage = "Tgl Masuk Pama harus diisi")]
            public DateTime? TglMasukPama { get; set; }

            public DateTime? TglPensiun { get; set; }

            [Required(ErrorMessage = "Golongan harus diisi")]
            public String Golongan { get; set; }

            public DateTime? TglPromosi { get; set; }

            public String IDJabatan { get; set; }

            [Required(ErrorMessage = "Jabatan harus diisi")]
            public String Jabatan { get; set; }

            public DateTime? TglMutasi { get; set; }

            public String StatusKeluarga { get; set; }

            public bool? StatusBawaKeluarga { get; set; }

            public DateTime? TglBawaKeluarga { get; set; }

            [Required(ErrorMessage = "Departemen Harus diisi")]
            public String Departemen { get; set; }

            public String StatusPenerimaan { get; set; }

            public String POH { get; set; }

            public bool? Gaji { get; set; }

            public decimal? RateUlap { get; set; }

            [Required(ErrorMessage = "Telepon Harus diisi")]
            public String Telepon { get; set; }

            public String Lokasi { get; set; }

            public bool? Approve { get; set; }

            public int? SisaCutiPeriode1 { get; set; }

            public int? SisaCutiPeriode2 { get; set; }

            public int? SisaCutiBesar { get; set; }

            [Required(ErrorMessage = "OnSite harus diisi")]
            public bool? OnSite { get; set; }

            public String Rekening { get; set; }

            public String PemilikRekening { get; set; }

            public String KodeBank { get; set; }

            public String StatusPekerjaan { get; set; }

            public bool? RewardSarana { get; set; }

            [Required(ErrorMessage = "Company harus diisi")]
            public String Company { get; set; }

            public String HariKe7 { get; set; }

            public int? RosterCode { get; set; }

            public double? SisaUangObat { get; set; }

            public DateTime? TglUpdate { get; set; }

            public String updateby { get; set; }

            [Required(ErrorMessage = "KTP harus diisi")]
            public String KTP { get; set; }

            [Required(ErrorMessage = "NPWP harus diisi")]
            public String NPWP { get; set; }

            [Required(ErrorMessage = "Email harus diisi")]
            public String EMAIL { get; set; }

            [Required(ErrorMessage = "No whatsapp harus diisi")]
            public String TeleponWA { get; set; }

            public bool? TanggalUpdateHarike7 { get; set; }

            public String JenisOperator { get; set; }

            public String Mess { get; set; }

            public String No_Kamar { get; set; }

            public bool? Status_Mess { get; set; }

            public String Keterangan_Mess { get; set; }
            #endregion
        }

        public class Absen
        {
            [Required(ErrorMessage = "Nrp harus diisi")]
            public String nrp { get; set; }

            public DateTime? tanggal { get; set; }

            [Required(ErrorMessage = "Shift harus diisi")]
            public String Shift { get; set; }
            
            public decimal? RosterCode { get; set; }

            public DateTime? @in { get; set; }
            
            public DateTime? @out { get; set; }
            
            public String Absent { get; set; }

            public Double? SKL { get; set; }

            public String Keterangan { get; set; }
        }

        public class User
        {
            public String PID_MAPPING_PROFILE { get; set; }

            [Required(ErrorMessage = "Userid harus diisi")]
            public String USERID { get; set; }

            [Required(ErrorMessage = "Profil harus diisi")]
            public int? ID_PROFILE { get; set; }

            public String LAST_UPDATE_BY { get; set; }

            public DateTime? LAST_UPDATE_DATE { get; set; }
        }

        public class Report
        {
            public string PID_REPORT { get; set; }

            public string REPORT_NAME { get; set; }

            public string REPORT_SERVER { get; set; }

            public string REPORT_PATH { get; set; }

            public string REPORT_CATEGORY { get; set; }

            public bool STATUS { get; set; }
        }

        public class Menu
        {
            public string PID_MENU { get; set; }

            [Required(ErrorMessage = "Nama Menu harus diisi")]
            public string MENU_DESC { get; set; }

            public string PARENT_PID { get; set; }

            public int? SORT_ORDER { get; set; }

            public string MENU_LINK { get; set; }

            public string CLASS { get; set; }

            public string ICON { get; set; }

            public int? POSITON_ID { get; set; }
        }

        public class Akses
        {
            public string PID_MAPPING_AKSES { get; set; }
            
            public string ID_PROFILE { get; set; }
            
            public string MENU_PID { get; set; }

            public short? C { get; set; }

            public short? R { get; set; }

            public short? U { get; set; }

            public short? D { get; set; }

        }
    }
}