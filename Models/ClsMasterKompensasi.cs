using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrgaEnhance.Models
{
    public class ClsMasterKompensasi
    {
        public IQueryable<VW_M_KOMPENSASI> getKompensasi(String s_Awal, String s_Akhir)
        {
            LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
            if(s_Awal == null || s_Akhir == null)
            {
                return dataContext.VW_M_KOMPENSASIs;
            }
            else
            {
                return dataContext.VW_M_KOMPENSASIs.Where(j => j.tanggal <= Convert.ToDateTime(s_Akhir) && j.tanggal >= Convert.ToDateTime(s_Awal));
            }
        }

        public IQueryable<VW_R_KOMPENSASI> getJnsKompensasi()
        {
            LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
            return dataContext.VW_R_KOMPENSASIs;
        }

        public bool validKompensasi(ClsParameter.Kompensasi sClsKompensasi)
        {
            LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
            TBL_M_KOMPENSASI iTbl = dataContext.TBL_M_KOMPENSASIs.Where(f => f.PID_KOMPENSASI.Equals(sClsKompensasi.PID_KOMPENSASI)).FirstOrDefault();

            if (iTbl != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool insertKompensasi(ClsParameter.Kompensasi sClsKompensasi)
        {
            try
            {
                LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
                TBL_M_KOMPENSASI iTbl = new TBL_M_KOMPENSASI();

                iTbl.PID_KOMPENSASI = System.Guid.NewGuid().ToString();
                iTbl.NRP = sClsKompensasi.nrp;
                iTbl.TANGGAL = sClsKompensasi.tanggal;
                iTbl.SHIFT = sClsKompensasi.shift;
                iTbl.ABSEN_IN = sClsKompensasi.@in;
                iTbl.ABSEN_OUT = sClsKompensasi.@out;
                iTbl.STATUS_KOMP = sClsKompensasi.STATUS_KOMP;

                dataContext.TBL_M_KOMPENSASIs.InsertOnSubmit(iTbl);
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

        public bool updateKompensasi(ClsParameter.Kompensasi sClsKompensasi)
        {
            try
            {
                LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
                TBL_M_KOMPENSASI iTbl = dataContext.TBL_M_KOMPENSASIs.Where(g => g.PID_KOMPENSASI.Equals(sClsKompensasi.PID_KOMPENSASI)).FirstOrDefault();

                iTbl.NRP = sClsKompensasi.nrp;
                iTbl.TANGGAL = sClsKompensasi.tanggal;
                iTbl.SHIFT = sClsKompensasi.shift;
                iTbl.ABSEN_IN = sClsKompensasi.@in;
                iTbl.ABSEN_OUT = sClsKompensasi.@out;
                iTbl.STATUS_KOMP = sClsKompensasi.STATUS_KOMP;

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