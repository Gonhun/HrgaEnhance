using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrgaEnhance.Models
{
    public class ClsMasterMappingAkses
    {
        public IQueryable<VW_R_MAPPING_AKSE> getDataAkses()
        {
            LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
            return dataContext.VW_R_MAPPING_AKSEs;
        }

        public IQueryable<TBL_R_PROFILE> getDataProfile()
        {
            LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
            return dataContext.TBL_R_PROFILEs;
        }

        public IQueryable<TBL_M_MENU> getDataMenu()
        {
            LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
            return dataContext.TBL_M_MENUs;
        }

        public bool insertAkses(ClsParameter.Akses sClsAkses, string iStrSessNrp)
        {
            LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();

            try
            {
                TBL_R_MAPPING_AKSE iTbl = new TBL_R_MAPPING_AKSE();
                iTbl.PID_MAPPING_AKSES = System.Guid.NewGuid().ToString();
                iTbl.ID_PROFILE = sClsAkses.ID_PROFILE;
                iTbl.MENU_PID = sClsAkses.MENU_PID;
                iTbl.C = sClsAkses.C;
                iTbl.R = sClsAkses.R;
                iTbl.U = sClsAkses.U;
                iTbl.D = sClsAkses.D;
                iTbl.CREATED_BY = iStrSessNrp;
                iTbl.CREATE_DATE = System.DateTime.Now;

                dataContext.TBL_R_MAPPING_AKSEs.InsertOnSubmit(iTbl);
                dataContext.SubmitChanges();
                dataContext.Dispose();

                return true;
            }
            catch(Exception e)
            {
                String remarks = e.ToString();
                return false;
            }
        }

        public bool updateAkses(ClsParameter.Akses sClsAkses, string iStrSessNrp)
        {
            LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();

            try
            {
                TBL_R_MAPPING_AKSE iTbl = dataContext.TBL_R_MAPPING_AKSEs.Where(k => k.PID_MAPPING_AKSES.Equals(sClsAkses.PID_MAPPING_AKSES)).FirstOrDefault();
                iTbl.ID_PROFILE = sClsAkses.ID_PROFILE;
                iTbl.MENU_PID = sClsAkses.MENU_PID;
                iTbl.C = sClsAkses.C;
                iTbl.R = sClsAkses.R;
                iTbl.U = sClsAkses.U;
                iTbl.D = sClsAkses.D;
                iTbl.CREATED_BY = iStrSessNrp;
                iTbl.CREATE_DATE = System.DateTime.Now;

                dataContext.TBL_R_MAPPING_AKSEs.InsertOnSubmit(iTbl);
                dataContext.SubmitChanges();
                dataContext.Dispose();

                return true;
            }
            catch (Exception e)
            {
                String remarks = e.ToString();
                return false;
            }
        }

        public bool deleteAkses(ClsParameter.Akses sClsAkses, string iStrSessNrp)
        {
            LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();

            try
            {
                TBL_R_MAPPING_AKSE iTbl = dataContext.TBL_R_MAPPING_AKSEs.Where(k => k.PID_MAPPING_AKSES.Equals(sClsAkses.PID_MAPPING_AKSES)).FirstOrDefault();

                dataContext.TBL_R_MAPPING_AKSEs.DeleteOnSubmit(iTbl);
                dataContext.SubmitChanges();
                dataContext.Dispose();

                return true;
            }
            catch (Exception e)
            {
                String remarks = e.ToString();
                return false;
            }
        }
    }
}