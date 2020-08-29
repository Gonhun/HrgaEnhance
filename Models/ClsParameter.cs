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
            [Required(ErrorMessage = "NRP harus diisi")]
            public String Nrp { get; set; }

            public String Nama { get; set; }

            public String TempatLahir { get; set; }

            public DateTime? TglLahir { get; set; }

            public String JenisKelamin { get; set; }

            public String GolonganDarah { get; set; }

            public String StatusKawin { get; set; }

            public String Agama { get; set; }

            public String Pendidikan { get; set; }

            public String AlamatTinggal { get; set; }

            public String Jamsostek { get; set; }

            public String DPA { get; set; }

            public DateTime? TglMasukPama { get; set; }

            public DateTime? TglPensiun { get; set; }

            public String Golongan { get; set; }

            public DateTime? TglPromosi { get; set; }

            public String IDJabatan { get; set; }

            public String Jabatan { get; set; }

            public DateTime? TglMutasi { get; set; }

            public String StatusKeluarga { get; set; }

            public bool? StatusBawaKeluarga { get; set; }

            public DateTime? TglBawaKeluarga { get; set; }

            public String Departemen { get; set; }

            public String StatusPenerimaan { get; set; }

            public String POH { get; set; }

            public bool? Gaji { get; set; }

            public decimal? RateUlap { get; set; }

            public String Telepon { get; set; }

            public String Lokasi { get; set; }

            public bool? Approve { get; set; }

            public int? SisaCutiPeriode1 { get; set; }

            public int? SisaCutiPeriode2 { get; set; }

            public int? SisaCutiBesar { get; set; }

            public bool? OnSite { get; set; }

            public String Rekening { get; set; }

            public String PemilikRekening { get; set; }

            public String KodeBank { get; set; }

            public String StatusPekerjaan { get; set; }

            public bool? RewardSarana { get; set; }

            public String Company { get; set; }

            public String HariKe7 { get; set; }

            public int? RosterCode { get; set; }

            public double? SisaUangObat { get; set; }

            public DateTime? TglUpdate { get; set; }

            public String updateby { get; set; }

            public String KTP { get; set; }

            public String NPWP { get; set; }

            public String EMAIL { get; set; }

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
            public string REPORT_ID { get; set; }

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

            public short? CR { get; set; }

            public short? RD { get; set; }

            public short? UP { get; set; }

            public short? DE { get; set; }

        }

        public class Sutu
        {
            public string NomorST { get; set; }
            public string Nrp { get; set; }
            public DateTime? tglST { get; set; }
            public string Tujuan { get; set; }
            public string Keperluan { get; set; }
            public string Penginapan { get; set; }
            public double? Hari { get; set; }
            public DateTime? Awal { get; set; }
            public DateTime? Akhir { get; set; }
            public string Transport { get; set; }
            public int? C_Lapangan { get; set; }
            public int? C_Besar { get; set; }
            public int? C_Tahunan { get; set; }
            public int? C_Perjalanan { get; set; }
            public int? C_Kompensasi { get; set; }
            public int? C_Lain2 { get; set; }
            public string PeriodeTugas { get; set; }
            public bool? Tiket { get; set; }
            public bool? Hotel { get; set; }
            public bool? UPD { get; set; }
            public bool? JP3U { get; set; }
            public bool? Taxi_Bus { get; set; }
            public bool? B_Lain2 { get; set; }
            public int? Uang_Muka { get; set; }
            public string CutiKhusus { get; set; }
            public string AlamatCuti { get; set; }
            public string Keterangan { get; set; }
            public string SisaCuti1 { get; set; }
            public string SisaCuti2 { get; set; }
            public int? SisaCuti3 { get; set; }
            public int? SisaCuti_Tahunan { get; set; }
            public int? SisaCuti_Besar { get; set; }
            public bool? PersetujuanAtasan { get; set; }
            public string NrpAtasan { get; set; }
            public DateTime? TglPersetujuan { get; set; }
            public string Catatan { get; set; }
            public string HR_Officer { get; set; }
            public string VerifikasiHR { get; set; }
            public DateTime? TglVerifikasi { get; set; }
            public bool? PersetujuanHr { get; set; }
            public string HRGA_Head { get; set; }
            public DateTime? TglValidasi { get; set; }
            public string CatatanHrga { get; set; }
            public bool? PersetujuanHrga { get; set; }
            public string ProjectManager { get; set; }
            public DateTime? TglPersetujuanPM { get; set; }
            public string CatatanPM { get; set; }
            public bool? PersetujuanPm { get; set; }
            public string DibuatOleh { get; set; }
            public string NOINDUKSI { get; set; }
            public int? printcount { get; set; }
            public string Kategori { get; set; }
            public DateTime? PeriodeBKM { get; set; }
            public Double? BKM { get; set; }
            public string Mess { get; set; }
            public int? Extend { get; set; }
            public int? Potong { get; set; }
            public Double? Lumsum { get; set; }

        }

        public class AksesReport
        {
            public string PID_MAPPING_REPORT { get; set; }

            public string REPORT_ID { get; set; }

            public string ID_PROFILE { get; set; }
        }

        public class Kompensasi
        {
            public string PID_KOMPENSASI { get; set; }

            public string nrp { get; set; }

            public string Absent { get; set; }

            public DateTime? tanggal { get; set; }

            public int? shift { get; set; }

            public DateTime? @in { get; set; }

            public DateTime? @out { get; set; }

            public string STATUS_KOMP { get; set; }
        }

        public class Tiket
        {
            public string NOMOR { get; set; }

            public string NRP { get; set; }

            public string NO_HP { get; set; }

            public string KEPERLUAN { get; set; }

            public string AREA { get; set; }

            public string DARI { get; set; }

            public string STATUS_KELUARGA { get; set; }

            public string TUJUAN { get; set; }

            public DateTime? TANGGAL { get; set; }

            public string JAM_BERANGKAT { get; set; }

            public DateTime? TANGGAL_KEMBALI { get; set; }

            public string DARI_KEMBALI { get; set; }

            public string TUJUAN_KEMBALI { get; set; }

            public string JAM_KEMBALI { get; set; }

            public string REMARK { get; set; }

        }
    }
}