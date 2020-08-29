using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrgaEnhance.Models
{
    public class ClsMasterRoster
    {
        public IQueryable<VW_R_ROSTER> getRoster()
        {
            LtsAbsenDataContext dataContext = new LtsAbsenDataContext();
            return dataContext.VW_R_ROSTERs;
        }

        
    }
}