using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HrgaEnhance.Report
{
    public partial class RptBrowser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dtab = new DataTable();
                SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PERSISConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("SELECT NULL REPORT_CATEGORY UNION SELECT DISTINCT REPORT_CATEGORY FROM [VW_M_MAPPING_REPORT] WHERE ID_PROFILE='" + (string)Session["gpId"] + "'", conn);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtab);
                conn.Close();

                ddlKategori.DataSource = dtab;
                ddlKategori.DataTextField = "REPORT_CATEGORY";
                ddlKategori.DataValueField = "REPORT_CATEGORY";
                ddlKategori.DataBind();
            }
        }

        protected void ddlKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlKategori.Text != "")
            {
                DataTable dtab = new DataTable();
                SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PERSISConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("SELECT NULL REPORT_ID, NULL REPORT_NAME UNION SELECT  REPORT_ID, REPORT_NAME FROM [VW_M_MAPPING_REPORT] WHERE ID_PROFILE='" + (string)Session["gpId"] + "' AND REPORT_CATEGORY='" + ddlKategori.Text + "' ORDER BY REPORT_NAME", conn);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtab);
                conn.Close();

                ddlReport.DataSource = dtab;
                ddlReport.DataTextField = "REPORT_NAME";
                ddlReport.DataValueField = "REPORT_ID";
                ddlReport.DataBind();
            }
            rvBrowser.Visible = false;
        }

        protected void ddlReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlReport.SelectedValue != "")
            {
                SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PERSISConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand();

                conn.Open();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT REPORT_SERVER, REPORT_PATH FROM VW_M_MAPPING_REPORT WHERE REPORT_ID='" + ddlReport.SelectedValue + "'";
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    rvBrowser.ProcessingMode = ProcessingMode.Remote;
                    ServerReport serverReport = rvBrowser.ServerReport;
                    serverReport.ReportServerUrl = new Uri(dr.GetString(0));
                    serverReport.ReportPath = dr.GetString(1);
                    //if (dr.GetString(0).Contains("10.157"))
                    //{
                    //    IReportServerCredentials ReportSecur = new CustomReportCredentials(System.Configuration.ConfigurationManager.AppSettings["Userdomain"].ToString(), System.Configuration.ConfigurationManager.AppSettings["Passworddomain"].ToString(), "ADRO");
                    //    serverReport.ReportServerCredentials = ReportSecur;

                    //}
                    serverReport.Refresh();
                    rvBrowser.DataBind();
                    rvBrowser.Visible = true;

                }
                else
                {
                    rvBrowser.Visible = false;
                }
            }
        }
    }
}