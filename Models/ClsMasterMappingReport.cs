using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrgaEnhance.Models
{
    public class ClsMasterMappingReport
    {
        public IQueryable<VW_M_MAPPING_REPORT> getMappingReport()
        {
            LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
            return dataContext.VW_M_MAPPING_REPORTs;
        }

        public IQueryable<TBL_M_REPORT> getReport()
        {
            LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
            return dataContext.TBL_M_REPORTs;
        }

        public bool insertMappingReport(ClsParameter.AksesReport sClsAksesReport)
        {
            try
            {
                LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
                TBL_M_MAPPING_REPORT iTbl = new TBL_M_MAPPING_REPORT();

                iTbl.PID_MAPPING_REPORT = System.Guid.NewGuid().ToString();
                iTbl.REPORT_ID = sClsAksesReport.REPORT_ID;
                iTbl.ID_PROFILE = sClsAksesReport.ID_PROFILE;

                dataContext.TBL_M_MAPPING_REPORTs.InsertOnSubmit(iTbl);
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

        public bool updateMappingReport(ClsParameter.AksesReport sClsAksesReport)
        {
            try
            {
                LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
                TBL_M_MAPPING_REPORT iTbl = dataContext.TBL_M_MAPPING_REPORTs.Where(h => h.PID_MAPPING_REPORT.Equals(sClsAksesReport.PID_MAPPING_REPORT)).FirstOrDefault();

                iTbl.REPORT_ID = sClsAksesReport.REPORT_ID;
                iTbl.ID_PROFILE = sClsAksesReport.ID_PROFILE;

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

        public bool deleteMappingReport(ClsParameter.AksesReport sClsAksesReport)
        {
            try
            {
                LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
                TBL_M_MAPPING_REPORT iTbl = dataContext.TBL_M_MAPPING_REPORTs.Where(h => h.PID_MAPPING_REPORT.Equals(sClsAksesReport.PID_MAPPING_REPORT)).FirstOrDefault();

                dataContext.TBL_M_MAPPING_REPORTs.DeleteOnSubmit(iTbl);
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