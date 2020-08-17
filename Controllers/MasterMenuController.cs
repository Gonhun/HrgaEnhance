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
    public class MasterMenuController : Controller
    {
        bool Status;
        String Remarks;
        private string iStrSessNRP = string.Empty;
        private string iStrSessDistrik = string.Empty;
        private string iStrSessGPID = string.Empty;

        // GET: MasterMenu
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
        public JsonResult jsonGetMenu([DataSourceRequest] DataSourceRequest request)
        {
            ClsMasterMenu cls = new ClsMasterMenu();
            return Json(cls.getMenu().ToDataSourceResult(request));
        }

        public JsonResult jsonGetParent()
        {
            ClsMasterMenu cls = new ClsMasterMenu();
            return Json (new { Data = cls.getMenu(), Total = cls.getMenu().Count()});
        }

        [HttpPost]
        public JsonResult jsonInsertMenu(ClsParameter.Menu sClsMenu)
        {
            ClsMasterMenu cls = new ClsMasterMenu();
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { status = false, remarks = ModelState.Values, JsonRequestBehavior.AllowGet });
                }
                else
                {
                    Status = cls.insertMenu(sClsMenu);
                    if (!Status)
                    {
                        Remarks = "Data Menu gagal disimpan";
                    }
                    else
                    {
                        Remarks = "Data Menu berhasil disimpan";
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
        public JsonResult jsonUpdateMenu(ClsParameter.Menu sClsMenu)
        {
            ClsMasterMenu cls = new ClsMasterMenu();
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { status = false, remarks = ModelState.Values, JsonRequestBehavior.AllowGet });
                }
                else
                {
                    Status = cls.updateMenu(sClsMenu);
                    if (!Status)
                    {
                        Remarks = "Data Menu gagal dirubah";
                    }
                    else
                    {
                        Remarks = "Data Menu berhasil dirubah";
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
        public JsonResult jsonDeleteMenu(ClsParameter.Menu sClsMenu)
        {
            ClsMasterMenu cls = new ClsMasterMenu();
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { status = false, remarks = ModelState.Values, JsonRequestBehavior.AllowGet });
                }
                else
                {
                    Status = cls.deleteMenu(sClsMenu);
                    if (!Status)
                    {
                        Remarks = "Data Menu gagal dihapus";
                    }
                    else
                    {
                        Remarks = "Data Menu berhasil dihapus";
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