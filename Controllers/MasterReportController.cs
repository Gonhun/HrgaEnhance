using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HrgaEnhance.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace HrgaEnhance.Controllers
{
    public class MasterReportController : Controller
    {
        bool Status;
        bool StatusValid;
        String Remarks;
        private string iStrSessNRP = string.Empty;
        private string iStrSessDistrik = string.Empty;
        private string iStrSessGPID = string.Empty;

        // GET: MasterReport
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

        [HttpPost]
        public JsonResult jsonGetReport([DataSourceRequest] DataSourceRequest request)
        {
            ClsMasterReport cls = new ClsMasterReport();
            return Json(cls.getReport().ToDataSourceResult(request));
        }

        public JsonResult jsonGetCategory()
        {
            ClsMasterReport cls = new ClsMasterReport();
            return Json(new { Data = cls.getReportCategory(), Total = cls.getReportCategory().Count() });
        }

        [HttpPost]
        public JsonResult jsonInsertReport(ClsParameter.Report sClsReport)
        {
            ClsMasterReport cls = new ClsMasterReport();
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { status = false, remarks = ModelState.Values, JsonRequestBehavior.AllowGet });
                }
                else
                {
                    Status = cls.insertReport(sClsReport);
                    if (!Status)
                    {
                        Remarks = "Data Report gagal disimpan";
                    }
                    else
                    {
                        Remarks = "Data Report berhasil disimpan";
                    }
                }
            }
            catch (Exception e)
            {
                Status = false;
                Remarks = e.ToString();
            }
            return Json(new { status = Status, remarks = Remarks, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult jsonUpdateReport(ClsParameter.Report sClsReport)
        {
            ClsMasterReport cls = new ClsMasterReport();
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { status = false, remarks = ModelState.Values, JsonRequestBehavior.AllowGet });
                }
                else
                {
                    Status = cls.updateReport(sClsReport);
                    if (!Status)
                    {
                        Remarks = "Data Report gagal dirubah";
                    }
                    else
                    {
                        Remarks = "Data Report berhasil dirubah";
                    }
                }
            }
            catch (Exception e)
            {
                Status = false;
                Remarks = e.ToString();
            }
            return Json(new { status = Status, remarks = Remarks, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult jsonDeleteReport(ClsParameter.Report sClsReport)
        {
            ClsMasterReport cls = new ClsMasterReport();
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { status = false, remarks = ModelState.Values, JsonRequestBehavior.AllowGet });
                }
                else
                {
                    Status = cls.deleteReport(sClsReport);
                    if (!Status)
                    {
                        Remarks = "Data Report gagal dihapus";
                    }
                    else
                    {
                        Remarks = "Data Report berhasil dihapus";
                    }
                }
            }
            catch (Exception e)
            {
                Status = false;
                Remarks = e.ToString();
            }
            return Json(new { status = Status, remarks = Remarks, JsonRequestBehavior.AllowGet });
        }
    }
}