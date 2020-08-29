using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace HrgaEnhance.Models
{
    public class ClsMasterSutu
    {
        public IQueryable<vw_SUTU> getSutu(string sParameter)
        {
            LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
            
            if(sParameter == "CUTI")
            {
                return dataContext.vw_SUTUs.Where(j => j.Keperluan.Equals("CUTI")).OrderByDescending(j => j.tglST);
            }
            else if (sParameter == "DINAS")
            {
                return dataContext.vw_SUTUs.Where(j => j.Keperluan.Equals("DINAS")).OrderByDescending(j => j.tglST);
            }
            else
            {
                return dataContext.vw_SUTUs.Where(j => j.Keperluan.Equals("TUGAS")).OrderByDescending(j => j.tglST);
            }
        }

        public IQueryable<tbl_keterangan_Cuti> getKetCuti()
        {
            LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
            return dataContext.tbl_keterangan_Cutis.Where(i => i.Keterangan.Contains("Cuti Normal"));
        }

        public bool validSutu(ClsParameter.Sutu sClsSutu)
        {
            LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();

            try
            {
                tblSutu iTbl = dataContext.tblSutus.Where(j => j.NomorST.Equals(sClsSutu.NomorST)).FirstOrDefault();

                if(iTbl == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool insertSutu(ClsParameter.Sutu sClsSutu)
        {
            LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();

            try
            {
                tblSutu iTbl = new tblSutu();
                iTbl.NomorST = "BARU";
                iTbl.Nrp = sClsSutu.Nrp;
                iTbl.tglST = System.DateTime.Now;
                iTbl.Tujuan = sClsSutu.Tujuan;
                iTbl.Keperluan = sClsSutu.Keperluan;
                iTbl.Penginapan = sClsSutu.Penginapan;
                iTbl.Hari = sClsSutu.Hari;
                iTbl.Awal = sClsSutu.Awal;
                iTbl.Akhir = sClsSutu.Akhir;
                iTbl.Transport = sClsSutu.Transport;
                iTbl.C_Lapangan = sClsSutu.C_Lapangan;
                iTbl.C_Besar = sClsSutu.C_Besar;
                iTbl.C_Tahunan = sClsSutu.C_Tahunan;
                iTbl.C_Perjalanan = sClsSutu.C_Perjalanan;
                iTbl.C_Kompensasi = sClsSutu.C_Kompensasi;
                iTbl.C_Lain2 = sClsSutu.C_Lain2;
                iTbl.PeriodeTugas = sClsSutu.PeriodeTugas;
                iTbl.Tiket = sClsSutu.Tiket;
                iTbl.Hotel = sClsSutu.Hotel;
                iTbl.UPD = sClsSutu.UPD;
                iTbl.JP3U = sClsSutu.JP3U;
                iTbl.Taxi_Bus = sClsSutu.Taxi_Bus;
                iTbl.B_Lain2 = sClsSutu.B_Lain2;
                iTbl.Uang_Muka = sClsSutu.Uang_Muka;
                iTbl.CutiKhusus = sClsSutu.CutiKhusus;
                iTbl.AlamatCuti = sClsSutu.AlamatCuti;
                iTbl.Keterangan = sClsSutu.Keterangan;
                iTbl.SisaCuti1 = sClsSutu.SisaCuti1;
                iTbl.SisaCuti2 = sClsSutu.SisaCuti2;
                iTbl.SisaCuti3 = sClsSutu.SisaCuti3;
                iTbl.SisaCuti_Tahunan = sClsSutu.SisaCuti_Tahunan;
                iTbl.SisaCuti_Besar = sClsSutu.SisaCuti_Besar;
                iTbl.DibuatOleh = sClsSutu.DibuatOleh;
                iTbl.NOINDUKSI = sClsSutu.NOINDUKSI;
                iTbl.printcount = sClsSutu.printcount;
                iTbl.Kategori = sClsSutu.Kategori;
                iTbl.PeriodeBKM = sClsSutu.PeriodeBKM;
                iTbl.BKM = sClsSutu.BKM;
                iTbl.Extend = sClsSutu.Extend;
                iTbl.Potong = sClsSutu.Potong;
                iTbl.Lumsum = sClsSutu.Lumsum;

                dataContext.tblSutus.InsertOnSubmit(iTbl);
                dataContext.SubmitChanges();
                dataContext.Dispose();

                return true;
            }
            catch(Exception e)
            {
                e.ToString();
                return false;
            }
        }

        public bool insertTiket(ClsParameter.Tiket sClsTiket, string iStrSessNrp)
        {
            LtsHrgaEnhanceDataContext dataContextHrga = new LtsHrgaEnhanceDataContext();
            LtsGesitDataContext dataContextGesit = new LtsGesitDataContext();
            try
            {
                //var tanggalST = Convert.ToDateTime(sClsTiket.TANGGAL).ToShortDateString();
                var printTgl = Convert.ToDateTime(sClsTiket.TANGGAL, CultureInfo.CurrentCulture).ToString("yyyy-MM-dd");
                vw_SUTU vw_ = dataContextHrga.vw_SUTUs.Where(i => i.Nrp.Equals(sClsTiket.NRP) && i.awalst == Convert.ToDateTime(printTgl).Date && i.Keperluan.Equals(sClsTiket.KEPERLUAN)).FirstOrDefault();
                tblKaryawan tbl_ = dataContextHrga.tblKaryawans.Where(i => i.Nrp.Equals(sClsTiket.NRP)).FirstOrDefault();
                TBL_T_TRAVEL_REQUEST ITbl = new TBL_T_TRAVEL_REQUEST();

                //ITbl.NOMOR = vw_.NomorST;
                ITbl.NRP = sClsTiket.NRP;
                ITbl.NAMA = tbl_.Nama;
                ITbl.STATUS_KELUARGA = tbl_.StatusKeluarga;
                ITbl.KEPERLUAN = sClsTiket.KEPERLUAN;
                ITbl.NO_HP = sClsTiket.NO_HP;
                ITbl.DARI = sClsTiket.DARI;
                ITbl.TUJUAN = sClsTiket.TUJUAN;
                ITbl.TANGGAL = sClsTiket.TANGGAL;
                ITbl.JAM_BERANGKAT = sClsTiket.JAM_BERANGKAT;
                ITbl.TANGGAL_KEMBALI = sClsTiket.TANGGAL_KEMBALI;
                ITbl.DARI_KEMBALI = sClsTiket.DARI_KEMBALI;
                ITbl.TUJUAN_KEMBALI = sClsTiket.TUJUAN_KEMBALI;
                ITbl.JAM_KEMBALI = sClsTiket.JAM_KEMBALI;

                dataContextGesit.TBL_T_TRAVEL_REQUESTs.InsertOnSubmit(ITbl);
                dataContextGesit.SubmitChanges();
                dataContextGesit.Dispose();

                return true;
            }
            catch(Exception e)
            {
                e.ToString();
                return false;
            }
        }

        public bool updateSutu(ClsParameter.Sutu sClsSutu)
        {
            LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();

            try
            {
                tblSutu iTbl = dataContext.tblSutus.Where(j => j.NomorST.Equals(sClsSutu.NomorST)).FirstOrDefault();

                iTbl.Hari = sClsSutu.Hari;
                iTbl.Awal = sClsSutu.Awal;
                iTbl.Akhir = sClsSutu.Akhir;
                iTbl.Transport = sClsSutu.Transport;
                iTbl.C_Lapangan = sClsSutu.C_Lapangan;
                iTbl.C_Besar = sClsSutu.C_Besar;
                iTbl.C_Tahunan = sClsSutu.C_Tahunan;
                iTbl.C_Perjalanan = sClsSutu.C_Perjalanan;
                iTbl.C_Kompensasi = sClsSutu.C_Kompensasi;
                iTbl.C_Lain2 = sClsSutu.C_Lain2;
                iTbl.PeriodeTugas = sClsSutu.PeriodeTugas;
                iTbl.Tiket = sClsSutu.Tiket;
                iTbl.Hotel = sClsSutu.Hotel;
                iTbl.UPD = sClsSutu.UPD;
                iTbl.JP3U = sClsSutu.JP3U;
                iTbl.Taxi_Bus = sClsSutu.Taxi_Bus;
                iTbl.B_Lain2 = sClsSutu.B_Lain2;
                iTbl.Uang_Muka = sClsSutu.Uang_Muka;
                iTbl.CutiKhusus = sClsSutu.CutiKhusus;
                iTbl.AlamatCuti = sClsSutu.AlamatCuti;
                iTbl.Keterangan = sClsSutu.Keterangan;
                iTbl.SisaCuti1 = sClsSutu.SisaCuti1;
                iTbl.SisaCuti2 = sClsSutu.SisaCuti2;
                iTbl.SisaCuti3 = sClsSutu.SisaCuti3;
                iTbl.SisaCuti_Tahunan = sClsSutu.SisaCuti_Tahunan;
                iTbl.SisaCuti_Besar = sClsSutu.SisaCuti_Besar;

                dataContext.SubmitChanges();
                dataContext.Dispose();

                return true;
            }
            catch(Exception e)
            {
                e.ToString();
                return false;
            }
        }

        public bool approvalSutu(ClsParameter.Sutu sClsSutu, string iStrSessNrp)
        {
            LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();

            try
            {
                tblSutu iTbl = dataContext.tblSutus.Where(j => j.NomorST.Equals(sClsSutu.NomorST)).FirstOrDefault();

                iTbl.PersetujuanHr = true;
                iTbl.TglValidasi = System.DateTime.Now;
                iTbl.TglVerifikasi = System.DateTime.Now;
                iTbl.TglPersetujuan = System.DateTime.Now;
                iTbl.HR_Officer = iStrSessNrp;
                iTbl.VerifikasiHR = "OK";
                iTbl.Catatan = "OK";

                iTbl.PersetujuanAtasan = true;

                iTbl.PersetujuanHrga = true;
                iTbl.HRGA_Head = "System";
                iTbl.CatatanHrga = "Approved By System";

                iTbl.PersetujuanPm = true;
                iTbl.ProjectManager = "System";
                iTbl.TglPersetujuanPM = System.DateTime.Now;
                iTbl.CatatanPM = "Approved By System";

                dataContext.SubmitChanges();
                dataContext.Dispose();

                return true;
            }
            catch(Exception e)
            {
                e.ToString();
                return false;
            }
        }

        public bool rejectSutu(ClsParameter.Sutu sClsSutu, string iStrSessNrp)
        {
            LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();

            try
            {
                tblSutu iTbl = dataContext.tblSutus.Where(j => j.NomorST.Equals(sClsSutu.NomorST)).FirstOrDefault();

                iTbl.PersetujuanHr = false;
                iTbl.TglValidasi = System.DateTime.Now;
                iTbl.TglVerifikasi = System.DateTime.Now;
                iTbl.TglPersetujuan = System.DateTime.Now;
                iTbl.HR_Officer = iStrSessNrp;
                iTbl.VerifikasiHR = "Reject";
                iTbl.Catatan = "Reject";

                iTbl.PersetujuanAtasan = false;

                iTbl.PersetujuanHrga = false;
                iTbl.HRGA_Head = "System";
                iTbl.CatatanHrga = "Rejected By System";

                iTbl.PersetujuanPm = false;
                iTbl.ProjectManager = "System";
                iTbl.TglPersetujuanPM = System.DateTime.Now;
                iTbl.CatatanPM = "Rejected By System";

                dataContext.SubmitChanges();
                dataContext.Dispose();

                return true;
            }
            catch (Exception e)
            {
                e.ToString();
                return false;
            }
        }
    }
}