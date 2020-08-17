using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrgaEnhance.Models
{
    public class ClsMasterMenu
    {
        public IQueryable<VW_M_MENU> getMenu()
        {
            LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
            return dataContext.VW_M_MENUs;
        }

        public bool insertMenu(ClsParameter.Menu sParameter)
        {
            try
            {
                LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
                TBL_M_MENU iTbl = new TBL_M_MENU();
                iTbl.PID_MENU = System.Guid.NewGuid().ToString();
                iTbl.MENU_DESC = sParameter.MENU_DESC;
                iTbl.MENU_LINK = sParameter.MENU_LINK;
                iTbl.PARENT_PID = sParameter.PARENT_PID;
                iTbl.SORT_ORDER = sParameter.SORT_ORDER;
                iTbl.CLASS = sParameter.CLASS;
                iTbl.ICON = sParameter.ICON;
                iTbl.POSITON_ID = sParameter.POSITON_ID;

                dataContext.TBL_M_MENUs.InsertOnSubmit(iTbl);
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

        public bool updateMenu(ClsParameter.Menu sParameter)
        {
            try
            {
                LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
                TBL_M_MENU iTbl = dataContext.TBL_M_MENUs.Where(i => i.PID_MENU.Equals(sParameter.PID_MENU)).FirstOrDefault();
                iTbl.MENU_DESC = sParameter.MENU_DESC;
                iTbl.MENU_LINK = sParameter.MENU_LINK;
                iTbl.PARENT_PID = sParameter.PARENT_PID;
                iTbl.SORT_ORDER = sParameter.SORT_ORDER;
                iTbl.CLASS = sParameter.CLASS;
                iTbl.ICON = sParameter.ICON;
                iTbl.POSITON_ID = sParameter.POSITON_ID;

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

        public bool deleteMenu(ClsParameter.Menu sParameter)
        {
            try
            {
                LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
                TBL_M_MENU iTbl = dataContext.TBL_M_MENUs.Where(i => i.PID_MENU.Equals(sParameter.PID_MENU)).FirstOrDefault();

                dataContext.TBL_M_MENUs.DeleteOnSubmit(iTbl);
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