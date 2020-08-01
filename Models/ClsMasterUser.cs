using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace HrgaEnhance.Models
{
    public class ClsMasterUser
    {
        public IQueryable<TBL_M_PROFILE> getUser()
        {
            LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
            return dataContext.TBL_M_PROFILEs;
        }

        public bool insert(ClsParameter.User parameterUser, string iStrSessNrp)
        {
            LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
            bool Status;

            try
            {
                TBL_M_PROFILE tBL = new TBL_M_PROFILE();

                tBL.PID_MAPPING_PROFILE = System.Guid.NewGuid().ToString();
                tBL.USERID = parameterUser.USERID;
                tBL.ID_PROFILE = parameterUser.ID_PROFILE;
                tBL.LAST_UPDATE_BY = iStrSessNrp;
                tBL.LAST_UPDATE_DATE = System.DateTime.Now;

                dataContext.TBL_M_PROFILEs.InsertOnSubmit(tBL);
                dataContext.SubmitChanges();
                Status = true;
            }
            catch(Exception e)
            {
                Status = false;
            }

            return Status;
        }

        public bool update(ClsParameter.User parameterUser, string iStrSessNrp)
        {
            LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
            bool Status;

            try
            {
                TBL_M_PROFILE tBL = dataContext.TBL_M_PROFILEs.Where(j => j.USERID.Equals(parameterUser.USERID)).FirstOrDefault();

                tBL.ID_PROFILE = parameterUser.ID_PROFILE;
                tBL.LAST_UPDATE_BY = iStrSessNrp;
                tBL.LAST_UPDATE_DATE = System.DateTime.Now;

                dataContext.SubmitChanges();
                Status = true;
            }
            catch (Exception e)
            {
                Status = false;
            }

            return Status;
        }

        public bool delete(ClsParameter.User parameterUser, string iStrSessNrp)
        {
            LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
            bool Status;

            try
            {
                TBL_M_PROFILE tBL = dataContext.TBL_M_PROFILEs.Where(j => j.USERID.Equals(parameterUser.USERID)).FirstOrDefault();

                dataContext.TBL_M_PROFILEs.DeleteOnSubmit(tBL);
                dataContext.SubmitChanges();
                Status = true;
            }
            catch (Exception e)
            {
                Status = false;
            }

            return Status;
        }
    }
}