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
using Microsoft.Ajax.Utilities;

namespace HrgaEnhance.Controllers
{
    public class MasterKompensasiController : Controller
    {
        bool Status;
        bool StatusValid;
        String Remarks;
        private string iStrSessNRP = string.Empty;
        private string iStrSessDistrik = string.Empty;
        private string iStrSessGPID = string.Empty;

        // GET: MasterKompensasi
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
        public JsonResult jsonGetKompensasi([DataSourceRequest] DataSourceRequest request, String s_Awal, String s_Akhir)
        {
            ClsMasterKompensasi cls = new ClsMasterKompensasi();
            return Json(cls.getKompensasi(s_Awal, s_Akhir).ToDataSourceResult(request));
        }

        [HttpPost]
        public JsonResult jsonGetJnsKompensasi()
        {
            ClsMasterKompensasi cls = new ClsMasterKompensasi();
            return Json(new { Data = cls.getJnsKompensasi(), Total = cls.getJnsKompensasi() });
        }

        [HttpPost]
        public JsonResult jsonValidKompensasi(ClsParameter.Kompensasi sClsKompensasi)
        {
            ClsMasterKompensasi cls = new ClsMasterKompensasi();
            try
            {
                StatusValid = cls.validKompensasi(sClsKompensasi);
                if (!StatusValid)
                {
                    Status = cls.insertKompensasi(sClsKompensasi);
                    if (!Status)
                    {
                        Remarks = "Data Kompensasi gagal disimpan";
                    }
                    else
                    {
                        Remarks = "Data Kompensasi berhasil disimpan";
                    }
                }
                else
                {
                    Status = cls.updateKompensasi(sClsKompensasi);
                    if (!Status)
                    {
                        Remarks = "Data Kompensasi gagal dirubah";
                    }
                    else
                    {
                        Remarks = "Data Kompensasi berhasil dirubah";
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