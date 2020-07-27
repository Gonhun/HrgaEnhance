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
        public JsonResult jsonInsertKaryawan(ClsParameter.Karyawan sClsKaryawan)
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
                    //Status = cls.insertKaryawan(sClsKaryawan);
                    if (!Status)
                    {
                        Remarks = "Data Karyawan gagal disimpan";
                    }
                    else
                    {
                        Remarks = "Data Karyawan berhasil disimpan";
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