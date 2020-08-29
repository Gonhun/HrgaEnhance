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
    public class MasterKaryawanController : Controller
    {
        bool Status;
        bool StatusValid;
        String Remarks;
        private string iStrSessNRP = string.Empty;
        private string iStrSessDistrik = string.Empty;
        private string iStrSessGPID = string.Empty;

        // GET: MasterKaryawan
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
        public JsonResult jsonGetKaryawan([DataSourceRequest] DataSourceRequest request)
        {
            ClsMasterKaryawan cls = new ClsMasterKaryawan();
            return Json(cls.getKaryawan().ToDataSourceResult(request));
        }

        [HttpPost]
        public JsonResult jsonGetData(string sParameter)
        {
            ClsMasterKaryawan cls = new ClsMasterKaryawan();
            return Json(new { data = cls.getKaryawanEllipse(sParameter)});
        }

        [HttpPost]
        public JsonResult jsonGetDept()
        {
            ClsMasterKaryawan cls = new ClsMasterKaryawan();
            return Json(new { Data = cls.getDept(), Total = cls.getDept().Count() });
        }

        [HttpPost]
        public JsonResult jsonGetPOH()
        {
            ClsMasterKaryawan cls = new ClsMasterKaryawan();
            return Json(new { Data = cls.getPOH(), Total = cls.getPOH().Count() });
        }

        [HttpPost]
        public JsonResult jsonGetMarital()
        {
            ClsMasterKaryawan cls = new ClsMasterKaryawan();
            return Json(new { Data = cls.getMarital(), Total = cls.getMarital().Count() });
        }

        [HttpPost]
        public JsonResult jsonGetBank()
        {
            ClsMasterKaryawan cls = new ClsMasterKaryawan();
            return Json(new { Data = cls.getBank(), Total = cls.getBank().Count() });
        }

        [HttpPost]
        public JsonResult jsonValidKaryawan(ClsParameter.Karyawan sClsKaryawan)
        {
            ClsMasterKaryawan cls = new ClsMasterKaryawan();
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { status = false, remarks = ModelState.Values, JsonRequestBehavior.AllowGet });
                }
                else
                {
                    StatusValid = cls.validKaryawan(sClsKaryawan);
                    if (!StatusValid)
                    {
                        Status = cls.insertKaryawan(sClsKaryawan);
                        if (!Status)
                        {
                            Remarks = "Data Karyawan gagal disimpan";
                        }
                        else
                        {
                            Remarks = "Data Karyawan berhasil disimpan";
                        }
                    }
                    else
                    {
                        Status = cls.updateKaryawan(sClsKaryawan);
                        if (!Status)
                        {
                            Remarks = "Data Karyawan gagal dirubah";
                        }
                        else
                        {
                            Remarks = "Data Karyawan berhasil dirubah";
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Status = false;
                Remarks = e.ToString();
            }
            return Json(new { status = Status, remarks = Remarks, JsonRequestBehavior.AllowGet });
        }
    }
}