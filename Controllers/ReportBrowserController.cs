using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HrgaEnhance.Models;

namespace HrgaEnhance.Controllers
{
    public class ReportBrowserController : Controller
    {
        bool Status;
        bool StatusValid;
        String Remarks;
        private string iStrSessNRP = string.Empty;
        private string iStrSessDistrik = string.Empty;
        private string iStrSessGPID = string.Empty;

        // GET: ReportBrowser
        public ActionResult Index()
        {
            if (Session["NRP"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                this.pv_CustLoadSession();
                ClsHome clsHome = new ClsHome();
                cufnGetMenuHrgaResult menu = clsHome.GetMenu(iStrSessGPID).FirstOrDefault();
                ViewData["myMenu"] = menu.InnerHTML;

                return View();
            }
        }

        private void pv_CustLoadSession()
        {
            iStrSessNRP = (string)Session["NRP"];
            iStrSessGPID = Convert.ToString(Session["gpId"] == null ? "1000" : Session["gpId"]);
        }
    }
}