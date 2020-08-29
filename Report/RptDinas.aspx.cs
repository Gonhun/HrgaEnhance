using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HrgaEnhance.Report
{
    public partial class RptDinas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pv_cust_generateReport();
        }

        private void pv_cust_generateReport()
        {
            string i_str_reportName = "Form_Dinas_Per_Nomor";
            //ConsolAll.ServerReport.Refresh();
            rvDinas.ProcessingMode = ProcessingMode.Remote;
            string NomorST = Request.QueryString["NomorST"].ToString();

            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("NomorST", NomorST);

            //rvCuti.ServerReport.SetParameters = new ReportParameter("NomorST", NomorST);
            rvDinas.ServerReport.ReportServerUrl = new Uri(System.Configuration.ConfigurationManager.AppSettings["ReportUrl"].ToString());
            rvDinas.ServerReport.ReportPath = System.Configuration.ConfigurationManager.AppSettings["ReportPath"].ToString() + i_str_reportName;
            rvDinas.ServerReport.SetParameters(parameters);
            rvDinas.ServerReport.Refresh();
        }
    }
}