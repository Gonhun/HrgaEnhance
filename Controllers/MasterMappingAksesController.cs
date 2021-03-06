﻿using System;
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
    public class MasterMappingAksesController : Controller
    {
        bool Status;
        String Remarks;
        private string iStrSessNRP = string.Empty;
        private string iStrSessDistrik = string.Empty;
        private string iStrSessGPID = string.Empty;

        // GET: MasterMappingAkses
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
        public JsonResult jsonGetAkses([DataSourceRequest] DataSourceRequest request)
        {
            ClsMasterMappingAkses cls = new ClsMasterMappingAkses();
            return Json(cls.getDataAkses().ToDataSourceResult(request));
        }

        [HttpPost]
        public JsonResult jsonGetProfile()
        {
            ClsMasterMappingAkses cls = new ClsMasterMappingAkses();
            return Json(new { Data = cls.getDataProfile(), Total = cls.getDataProfile().Count() });
        }

        [HttpPost]
        public JsonResult jsonGetMenu()
        {
            ClsMasterMappingAkses cls = new ClsMasterMappingAkses();
            return Json(new { Data = cls.getDataMenu(), Total = cls.getDataMenu().Count() });
        }

        [HttpPost]
        public JsonResult jsonInsertAkses(ClsParameter.Akses sClsAkses)
        {
            ClsMasterMappingAkses cls = new ClsMasterMappingAkses();
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { status = false, remarks = ModelState.Values, JsonRequestBehavior.AllowGet });
                }
                else
                {
                    Status = cls.insertAkses(sClsAkses, iStrSessNRP);
                    if (!Status)
                    {
                        Remarks = "Data Akses gagal disimpan";
                    }
                    else
                    {
                        Remarks = "Data Akses berhasil disimpan";
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
        public JsonResult jsonUpdateAkses(ClsParameter.Akses sClsAkses)
        {
            ClsMasterMappingAkses cls = new ClsMasterMappingAkses();
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { status = false, remarks = ModelState.Values, JsonRequestBehavior.AllowGet });
                }
                else
                {
                    Status = cls.updateAkses(sClsAkses, iStrSessNRP);
                    if (!Status)
                    {
                        Remarks = "Data Akses gagal dirubah";
                    }
                    else
                    {
                        Remarks = "Data Akses berhasil dirubah";
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
        public JsonResult jsonDeleteAkses(ClsParameter.Akses sClsAkses)
        {
            ClsMasterMappingAkses cls = new ClsMasterMappingAkses();
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { status = false, remarks = ModelState.Values, JsonRequestBehavior.AllowGet });
                }
                else
                {
                    Status = cls.deleteAkses(sClsAkses, iStrSessNRP);
                    if (!Status)
                    {
                        Remarks = "Data Akses gagal dihapus";
                    }
                    else
                    {
                        Remarks = "Data Akses berhasil dihapus";
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