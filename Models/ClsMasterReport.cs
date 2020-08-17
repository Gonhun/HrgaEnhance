using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrgaEnhance.Models
{
    public class ClsMasterReport
    {
        public bool insertReport(ClsParameter.Report sParameter)
        {
            try
            {

                return true;
            }
            catch(Exception e)
            {
                String remarks = e.ToString();
                return false;
            }
        }

        public bool updateReport(ClsParameter.Report sParameter)
        {
            try
            {
                return true;
            }
            catch (Exception e)
            {
                String remarks = e.ToString();
                return false;
            }
        }

        public bool deleteReport(ClsParameter.Report sParameter)
        {
            try
            {
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