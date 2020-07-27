using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using HrgaEnhance.Models;

namespace HrgaEnhance.Models
{
    public class ClsMasterKaryawan
    {
        public IQueryable<tblKaryawan> getKaryawan()
        {
            LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
            return dataContext.tblKaryawans;
        }

        public ClsParameter.Karyawan getKaryawanEllipse(string sParameter)
        {
            LtsShareDataContext dataContext = new LtsShareDataContext();
            LtsHrgaEnhanceDataContext dataContext1 = new LtsHrgaEnhanceDataContext();
            VW_R_EMPLOYEE_SHARE vW_R = dataContext.VW_R_EMPLOYEE_SHAREs.Where(j => j.NRP.Equals(sParameter)).FirstOrDefault();
            tblKaryawan tbl = dataContext1.tblKaryawans.Where(j => j.Nrp.Equals(sParameter)).FirstOrDefault();
            ClsParameter.Karyawan parameter = new ClsParameter.Karyawan();

            if (tbl != null)
            {
                parameter.Nrp = tbl.Nrp;
                parameter.Nama = tbl.Nama;
                parameter.TempatLahir = tbl.TempatLahir;
                parameter.TglLahir = tbl.TglLahir;
                parameter.JenisKelamin = tbl.JenisKelamin;
                parameter.GolonganDarah = tbl.GolonganDarah;
                parameter.StatusKawin = tbl.StatusKawin;
                parameter.Agama = tbl.Agama;
                parameter.Pendidikan = tbl.Pendidikan;
                parameter.AlamatTinggal = tbl.AlamatTinggal;
                parameter.Jamsostek = tbl.Jamsostek;
                parameter.DPA = tbl.DPA;
                parameter.TglMasukPama = tbl.TglMasukPama;
                parameter.TglPensiun = tbl.TglPensiun;
                parameter.Golongan = tbl.Golongan;
                parameter.TglPromosi = tbl.TglPromosi;
                parameter.IDJabatan = tbl.IDJabatan;
                parameter.Jabatan = tbl.Jabatan;
                parameter.TglMutasi = tbl.TglMutasi;
                parameter.StatusKeluarga = tbl.StatusKeluarga;
                parameter.StatusBawaKeluarga = tbl.StatusBawaKeluarga;
                parameter.TglBawaKeluarga = tbl.TglBawaKeluarga;
                parameter.Departemen = tbl.Departemen;
                parameter.StatusPenerimaan = tbl.StatusPenerimaan;
                parameter.POH = tbl.POH;
                parameter.Gaji = tbl.Gaji;
                parameter.RateUlap = tbl.RateUlap;
                parameter.Telepon = tbl.Telepon;
                parameter.Lokasi = tbl.Lokasi;
                parameter.Approve = tbl.Approve;
                parameter.SisaCutiPeriode1 = tbl.SisaCutiPeriode1;
                parameter.SisaCutiPeriode2 = tbl.SisaCutiPeriode2;
                parameter.SisaCutiBesar = tbl.SisaCutiBesar;
                parameter.OnSite = tbl.OnSite;
                parameter.Rekening = tbl.Rekening;
                parameter.PemilikRekening = tbl.PemilikRekening;
                parameter.KodeBank = tbl.KodeBank;
                parameter.StatusPekerjaan = tbl.StatusPekerjaan;
                parameter.RewardSarana = tbl.RewardSarana;
                parameter.Company = tbl.Company;
                parameter.HariKe7 = tbl.Harike7;
                parameter.RosterCode = tbl.RosterCode;
                parameter.SisaUangObat = tbl.SisaUangObat;
                parameter.TglUpdate = tbl.TglUpdate;
                parameter.updateby = tbl.updateby;
                parameter.KTP = tbl.KTP;
                parameter.NPWP = tbl.NPWP;
                parameter.EMAIL = tbl.EMAIL;
                parameter.TeleponWA = tbl.TeleponWA;
                parameter.TanggalUpdateHarike7 = tbl.TanggalUpdateHarike7;
                parameter.JenisOperator = tbl.JenisOperator;
                parameter.Mess = tbl.Mess;
                parameter.No_Kamar = tbl.No_Kamar;
                parameter.Status_Mess = tbl.Status_Mess;
                parameter.Keterangan_Mess = tbl.Keterangan_Mess;

                return parameter;
            }
            else
            {
                parameter.Nrp = vW_R.NRP;
                parameter.Nama = vW_R.NAME;
                parameter.TempatLahir = vW_R.BIRTH_PLACE_DESC;
                parameter.TglLahir = Convert.ToDateTime(vW_R.BIRTH_DATE);
                parameter.JenisKelamin = vW_R.GENDER_CODE;
                parameter.GolonganDarah = vW_R.BLOOD_TYPE;
                parameter.StatusKawin = vW_R.MARITAL_CODE;
                parameter.Agama = vW_R.RELIGION;
                parameter.Pendidikan = vW_R.LAST_EDUCATION;
                parameter.AlamatTinggal = vW_R.RES_ADDRESS_1 + ' ' + vW_R.RES_ADDRESS_2 + ' ' + vW_R.RES_ADDRESS_3;
                parameter.Jamsostek = "";
                parameter.DPA = "";
                parameter.TglMasukPama = Convert.ToDateTime(vW_R.HIRE_DATE);
                parameter.TglPensiun = null;
                parameter.Golongan = vW_R.GOLONGAN;
                parameter.TglPromosi = null;
                parameter.IDJabatan = vW_R.POSITION_ID;
                parameter.Jabatan = vW_R.POS_TITLE;
                parameter.TglMutasi = null;
                parameter.StatusKeluarga = "";
                parameter.StatusBawaKeluarga = null;
                parameter.TglBawaKeluarga = null;
                parameter.Departemen = vW_R.DEPT_CODE;
                parameter.StatusPenerimaan = vW_R.STATUS_HIRE_DESC;
                parameter.POH = vW_R.POINT_OF_HIRE_DESC;
                parameter.Gaji = null;
                parameter.RateUlap = null;
                parameter.Telepon = "";
                parameter.Lokasi = "";
                parameter.Approve = null;
                parameter.SisaCutiPeriode1 = null;
                parameter.SisaCutiPeriode2 = null;
                parameter.SisaCutiBesar = null;
                parameter.OnSite = null;
                parameter.Rekening = "";
                parameter.PemilikRekening = "";
                parameter.KodeBank = "";
                parameter.StatusPekerjaan = "";
                parameter.RewardSarana = null;
                parameter.Company = "";
                parameter.HariKe7 = "";
                parameter.RosterCode = null;
                parameter.SisaUangObat = null;
                parameter.TglUpdate = null;
                parameter.updateby = null;
                parameter.KTP = null;
                parameter.NPWP = null;
                parameter.EMAIL = null;
                parameter.TeleponWA = null;
                parameter.TanggalUpdateHarike7 = null;
                parameter.JenisOperator = null;
                parameter.Mess = null;
                parameter.No_Kamar = null;
                parameter.Status_Mess = null;
                parameter.Keterangan_Mess = null;

                return parameter;
            }
        }

        public bool insertKaryawan(ClsParameter.Karyawan sClsKaryawan)
        {
            LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
            tblKaryawan iTbl = new tblKaryawan();
            bool Status;
            try
            {
                iTbl.Nrp = sClsKaryawan.Nrp;
                iTbl.Nama = sClsKaryawan.Nama;
                iTbl.TempatLahir = sClsKaryawan.TempatLahir;
                iTbl.TglLahir = sClsKaryawan.TglLahir;
                iTbl.JenisKelamin = sClsKaryawan.JenisKelamin;
                iTbl.GolonganDarah = sClsKaryawan.GolonganDarah;
                iTbl.StatusKawin = sClsKaryawan.StatusKawin;
                iTbl.Agama = sClsKaryawan.Agama;
                iTbl.Pendidikan = sClsKaryawan.Pendidikan;
                iTbl.AlamatTinggal = sClsKaryawan.AlamatTinggal;
                iTbl.Jamsostek = sClsKaryawan.Jamsostek;
                iTbl.DPA = sClsKaryawan.DPA;
                iTbl.TglMasukPama = sClsKaryawan.TglMasukPama;
                iTbl.TglPensiun = sClsKaryawan.TglPensiun;
                iTbl.Golongan = sClsKaryawan.Golongan;
                iTbl.TglPromosi = sClsKaryawan.TglPromosi;
                iTbl.IDJabatan = sClsKaryawan.IDJabatan;
                iTbl.Jabatan = sClsKaryawan.Jabatan;
                iTbl.TglMutasi = sClsKaryawan.TglMutasi;
                iTbl.StatusKeluarga = sClsKaryawan.StatusKeluarga;
                iTbl.StatusBawaKeluarga = sClsKaryawan.StatusBawaKeluarga;
                iTbl.TglBawaKeluarga = sClsKaryawan.TglBawaKeluarga;
                iTbl.Departemen = sClsKaryawan.Departemen;
                iTbl.StatusPenerimaan = sClsKaryawan.StatusPenerimaan;
                iTbl.POH = sClsKaryawan.POH;
                iTbl.Gaji = sClsKaryawan.Gaji;
                iTbl.RateUlap = sClsKaryawan.RateUlap;
                iTbl.Telepon = sClsKaryawan.Telepon;
                iTbl.Lokasi = sClsKaryawan.Lokasi;
                iTbl.Approve = sClsKaryawan.Approve;
                iTbl.SisaCutiPeriode1 = sClsKaryawan.SisaCutiPeriode1;
                iTbl.SisaCutiPeriode2 = sClsKaryawan.SisaCutiPeriode2;
                iTbl.SisaCutiBesar = sClsKaryawan.SisaCutiBesar;
                iTbl.OnSite = sClsKaryawan.OnSite;
                iTbl.Rekening = sClsKaryawan.Rekening;
                iTbl.PemilikRekening = sClsKaryawan.PemilikRekening;
                iTbl.KodeBank = sClsKaryawan.KodeBank;
                iTbl.StatusPekerjaan = sClsKaryawan.StatusPekerjaan;
                iTbl.RewardSarana = sClsKaryawan.RewardSarana;
                iTbl.Company = sClsKaryawan.Company;
                iTbl.Harike7 = sClsKaryawan.HariKe7;
                iTbl.RosterCode = sClsKaryawan.RosterCode;
                iTbl.SisaUangObat = sClsKaryawan.SisaUangObat;
                iTbl.TglUpdate = sClsKaryawan.TglUpdate;
                iTbl.updateby = sClsKaryawan.updateby;
                iTbl.KTP = sClsKaryawan.KTP;
                iTbl.NPWP = sClsKaryawan.NPWP;
                iTbl.EMAIL = sClsKaryawan.EMAIL;
                iTbl.TeleponWA = sClsKaryawan.TeleponWA;
                iTbl.TanggalUpdateHarike7 = sClsKaryawan.TanggalUpdateHarike7;
                iTbl.JenisOperator = sClsKaryawan.JenisOperator;
                iTbl.Mess = sClsKaryawan.Mess;
                iTbl.No_Kamar = sClsKaryawan.No_Kamar;
                iTbl.Status_Mess = sClsKaryawan.Status_Mess;
                iTbl.Keterangan_Mess = sClsKaryawan.Keterangan_Mess;

                dataContext.tblKaryawans.InsertOnSubmit(iTbl);
                dataContext.SubmitChanges();
                dataContext.Dispose();

                Status = true;
            }
            catch(Exception e)
            {
                Status = false;
            }
            return Status;
        }

        public bool updateKaryawan(ClsParameter.Karyawan sClsKaryawan)
        {
            LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
            tblKaryawan iTbl = dataContext.tblKaryawans.Where(j => j.Nrp.Equals(sClsKaryawan.Nrp)).FirstOrDefault();
            bool Status;

            try
            {
                iTbl.Nama = sClsKaryawan.Nama;
                iTbl.TempatLahir = sClsKaryawan.TempatLahir;
                iTbl.TglLahir = sClsKaryawan.TglLahir;
                iTbl.JenisKelamin = sClsKaryawan.JenisKelamin;
                iTbl.GolonganDarah = sClsKaryawan.GolonganDarah;
                iTbl.StatusKawin = sClsKaryawan.StatusKawin;
                iTbl.Agama = sClsKaryawan.Agama;
                iTbl.Pendidikan = sClsKaryawan.Pendidikan;
                iTbl.AlamatTinggal = sClsKaryawan.AlamatTinggal;
                iTbl.Jamsostek = sClsKaryawan.Jamsostek;
                iTbl.DPA = sClsKaryawan.DPA;
                iTbl.TglMasukPama = sClsKaryawan.TglMasukPama;
                iTbl.TglPensiun = sClsKaryawan.TglPensiun;
                iTbl.Golongan = sClsKaryawan.Golongan;
                iTbl.TglPromosi = sClsKaryawan.TglPromosi;
                iTbl.IDJabatan = sClsKaryawan.IDJabatan;
                iTbl.Jabatan = sClsKaryawan.Jabatan;
                iTbl.TglMutasi = sClsKaryawan.TglMutasi;
                iTbl.StatusKeluarga = sClsKaryawan.StatusKeluarga;
                iTbl.StatusBawaKeluarga = sClsKaryawan.StatusBawaKeluarga;
                iTbl.TglBawaKeluarga = sClsKaryawan.TglBawaKeluarga;
                iTbl.Departemen = sClsKaryawan.Departemen;
                iTbl.StatusPenerimaan = sClsKaryawan.StatusPenerimaan;
                iTbl.POH = sClsKaryawan.POH;
                iTbl.Gaji = sClsKaryawan.Gaji;
                iTbl.RateUlap = sClsKaryawan.RateUlap;
                iTbl.Telepon = sClsKaryawan.Telepon;
                iTbl.Lokasi = sClsKaryawan.Lokasi;
                iTbl.Approve = sClsKaryawan.Approve;
                iTbl.SisaCutiPeriode1 = sClsKaryawan.SisaCutiPeriode1;
                iTbl.SisaCutiPeriode2 = sClsKaryawan.SisaCutiPeriode2;
                iTbl.SisaCutiBesar = sClsKaryawan.SisaCutiBesar;
                iTbl.OnSite = sClsKaryawan.OnSite;
                iTbl.Rekening = sClsKaryawan.Rekening;
                iTbl.PemilikRekening = sClsKaryawan.PemilikRekening;
                iTbl.KodeBank = sClsKaryawan.KodeBank;
                iTbl.StatusPekerjaan = sClsKaryawan.StatusPekerjaan;
                iTbl.RewardSarana = sClsKaryawan.RewardSarana;
                iTbl.Company = sClsKaryawan.Company;
                iTbl.Harike7 = sClsKaryawan.HariKe7;
                iTbl.RosterCode = sClsKaryawan.RosterCode;
                iTbl.SisaUangObat = sClsKaryawan.SisaUangObat;
                iTbl.TglUpdate = sClsKaryawan.TglUpdate;
                iTbl.updateby = sClsKaryawan.updateby;
                iTbl.KTP = sClsKaryawan.KTP;
                iTbl.NPWP = sClsKaryawan.NPWP;
                iTbl.EMAIL = sClsKaryawan.EMAIL;
                iTbl.TeleponWA = sClsKaryawan.TeleponWA;
                iTbl.TanggalUpdateHarike7 = sClsKaryawan.TanggalUpdateHarike7;
                iTbl.JenisOperator = sClsKaryawan.JenisOperator;
                iTbl.Mess = sClsKaryawan.Mess;
                iTbl.No_Kamar = sClsKaryawan.No_Kamar;
                iTbl.Status_Mess = sClsKaryawan.Status_Mess;
                iTbl.Keterangan_Mess = sClsKaryawan.Keterangan_Mess;

                dataContext.SubmitChanges();
                dataContext.Dispose();
                Status = true;
            }
            catch(Exception e)
            {
                Status = false;
            }
            return Status;
        }
    }
}