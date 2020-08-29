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
    public class MasterSutuController : Controller
    {
        bool Status;
        bool StatusValid;
        String Remarks;
        private string iStrSessNRP = string.Empty;
        private string iStrSessDistrik = string.Empty;
        private string iStrSessGPID = string.Empty;

        // GET: MasterSutu
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

        public ActionResult Approval()
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
        public JsonResult jsonGetSurat([DataSourceRequest] DataSourceRequest request, string sParameter)
        {
            ClsMasterSutu cls = new ClsMasterSutu();
            return Json(cls.getSutu(sParameter).ToDataSourceResult(request));
        }

        [HttpPost]
        public JsonResult jsonGetData(string sParameter)
        {
            ClsMasterKaryawan cls = new ClsMasterKaryawan();
            return Json(new { data = cls.getKaryawanEllipse(sParameter) });
        }

        [HttpPost]
        public JsonResult jsonGetKetCuti()
        {
            ClsMasterSutu cls = new ClsMasterSutu();
            return Json(new { Data = cls.getKetCuti(), Total = cls.getKetCuti().Count() });
        }

        [HttpPost]
        public JsonResult jsonInsertSurat(ClsParameter.Sutu sClsSutu, ClsParameter.Tiket sClsTiket)
        { 
            try
            {
                this.pv_CustLoadSession();
                ClsMasterSutu cls = new ClsMasterSutu();

                Status = cls.insertSutu(sClsSutu);
                if (!Status)
                {
                    Remarks = "Surat anda gagal disimpan";
                }
                else
                {
                    bool input;
                    if(sClsSutu.Keperluan == "CUTI" || sClsSutu.Keperluan == "TUGAS")
                    {
                        input = cls.insertTiket(sClsTiket, iStrSessNRP);
                        if (!input)
                        {
                            Remarks = "Surat anda gagal diproses";
                        }
                        else
                        {
                            Remarks = "Surat dan tiket sudah tersimpan dan akan diproses oleh tim HC";
                        }
                    }
                    else
                    {
                        Remarks = "Surat tersimpan dan akan diproses oleh tim HC";
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
        public JsonResult jsonApprovalSutu(ClsParameter.Sutu sClsSutu)
        {
            try
            {
                this.pv_CustLoadSession();
                ClsMasterSutu cls = new ClsMasterSutu();

                Status = cls.approvalSutu(sClsSutu, iStrSessNRP);
                if (!Status)
                {
                    Remarks = "Surat " + sClsSutu.NomorST + " gagal di approve";
                }
                else
                {
                    Remarks = "Surat " + sClsSutu.NomorST + " sudah diproses";
                }
            }
            catch(Exception e)
            {
                Status = false;
                Remarks = e.ToString();
            }
            return Json(new { status = Status, remarks = Remarks, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult jsonRejectSutu(ClsParameter.Sutu sClsSutu)
        {
            try
            {
                this.pv_CustLoadSession();
                ClsMasterSutu cls = new ClsMasterSutu();

                Status = cls.rejectSutu(sClsSutu, iStrSessNRP);
                if (!Status)
                {
                    Remarks = "Surat " + sClsSutu.NomorST + " gagal di reject";
                }
                else
                {
                    Remarks = "Surat " + sClsSutu.NomorST + " sudah diproses";
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