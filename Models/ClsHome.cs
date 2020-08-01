using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrgaEnhance.Models
{
    public class ClsHome
    {
        public IQueryable<cufnGetMenuHrgaResult> GetMenu(string GPID)
        {
            LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
            return dataContext.cufnGetMenuHrga(GPID);
        }
    }
}