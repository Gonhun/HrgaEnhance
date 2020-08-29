using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrgaEnhance.Models
{
    public class ClsMasterReport
    {

        public IQueryable<TBL_M_REPORT> getReport()
        {
            LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
            return dataContext.TBL_M_REPORTs;
        }

        public IQueryable<TBL_R_REPORT_CATEGORY> getReportCategory()
        {
            LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
            return dataContext.TBL_R_REPORT_CATEGORies;
        }

        public bool insertReport(ClsParameter.Report sClsReport)
        {
            try
            {
                LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
                TBL_M_REPORT iTbl = new TBL_M_REPORT();

                iTbl.REPORT_ID = System.Guid.NewGuid().ToString();
                iTbl.REPORT_NAME = sClsReport.REPORT_NAME;
                iTbl.REPORT_PATH = sClsReport.REPORT_PATH;
                iTbl.REPORT_SERVER = sClsReport.REPORT_SERVER;
                iTbl.REPORT_CATEGORY = sClsReport.REPORT_CATEGORY;
                iTbl.STATUS = true;

                dataContext.TBL_M_REPORTs.InsertOnSubmit(iTbl);
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

        public bool updateReport(ClsParameter.Report sClsReport)
        {
            try
            {
                LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
                TBL_M_REPORT iTbl = dataContext.TBL_M_REPORTs.Where(s => s.REPORT_ID.Equals(sClsReport.REPORT_ID)).FirstOrDefault();

                iTbl.REPORT_NAME = sClsReport.REPORT_NAME;
                iTbl.REPORT_PATH = sClsReport.REPORT_PATH;
                iTbl.REPORT_SERVER = sClsReport.REPORT_SERVER;
                iTbl.REPORT_CATEGORY = sClsReport.REPORT_CATEGORY;
                iTbl.STATUS = sClsReport.STATUS;

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

        public bool deleteReport(ClsParameter.Report sClsReport)
        {
            try
            {
                LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
                TBL_M_REPORT iTbl = dataContext.TBL_M_REPORTs.Where(s => s.REPORT_ID.Equals(sClsReport.REPORT_ID)).FirstOrDefault();

                dataContext.TBL_M_REPORTs.DeleteOnSubmit(iTbl);
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