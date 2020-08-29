using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using System.Globalization;//untuk format tanggal
using System.Threading;//untuk format tanggal
using System.Threading.Tasks;
using System.Data;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Security;
using HrgaEnhance.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Web.ModelBinding;

namespace HrgaEnhance.Controllers
{
    public class MasterMappingReportController : Controller
    {
        bool Status;
        String Remarks;
        private string iStrSessNRP = string.Empty;
        private string iStrSessDistrik = string.Empty;
        private string iStrSessGPID = string.Empty;

        // GET: MasterMappingReport
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
        public JsonResult jsonGetAksesReport([DataSourceRequest] DataSourceRequest request)
        {
            ClsMasterMappingReport cls = new ClsMasterMappingReport();
            return Json(cls.getMappingReport().ToDataSourceResult(request));
        }

        [HttpPost]
        public JsonResult jsonGetProfile()
        {
            ClsMasterMappingAkses cls = new ClsMasterMappingAkses();
            return Json(new { Data = cls.getDataProfile(), Total = cls.getDataProfile().Count() });
        }

        [HttpPost]
        public JsonResult jsonGetReport()
        {
            ClsMasterMappingReport cls = new ClsMasterMappingReport();
            return Json(new { Data = cls.getReport(), Total = cls.getReport().Count() });
        }

        [HttpPost]
        public JsonResult jsonInsertAksesReport(ClsParameter.AksesReport sClsAksesReport)
        {
            ClsMasterMappingReport cls = new ClsMasterMappingReport();
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { status = false, remarks = ModelState.Values, JsonRequestBehavior.AllowGet });
                }
                else
                {
                    Status = cls.insertMappingReport(sClsAksesReport);
                    if (!Status)
                    {
                        Remarks = "Data Akses Report gagal disimpan";
                    }
                    else
                    {
                        Remarks = "Data Akses Report berhasil disimpan";
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
        public JsonResult jsonUpdateAkses(ClsParameter.AksesReport sClsAksesReport)
        {
            ClsMasterMappingReport cls = new ClsMasterMappingReport();
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { status = false, remarks = ModelState.Values, JsonRequestBehavior.AllowGet });
                }
                else
                {
                    Status = cls.updateMappingReport(sClsAksesReport);
                    if (!Status)
                    {
                        Remarks = "Data Akses Report gagal dirubah";
                    }
                    else
                    {
                        Remarks = "Data Akses Report berhasil dirubah";
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
        public JsonResult jsonDeleteAkses(ClsParameter.AksesReport sClsAksesReport)
        {
            ClsMasterMappingReport cls = new ClsMasterMappingReport();
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { status = false, remarks = ModelState.Values, JsonRequestBehavior.AllowGet });
                }
                else
                {
                    Status = cls.deleteMappingReport(sClsAksesReport);
                    if (!Status)
                    {
                        Remarks = "Data Akses Report gagal dihapus";
                    }
                    else
                    {
                        Remarks = "Data Akses Report berhasil dihapus";
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