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
    public class MasterUserController : Controller
    {
        bool Status;
        String Remarks;
        private string iStrSessNRP = string.Empty;
        private string iStrSessDistrik = string.Empty;
        private string iStrSessGPID = string.Empty;


        // GET: MasterUser
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
        public JsonResult jsonGetUser([DataSourceRequest] DataSourceRequest request)
        {
            ClsMasterUser cls = new ClsMasterUser();
            return Json(cls.getUser().ToDataSourceResult(request));
        }

        [HttpPost]
        public JsonResult jsonGetNama(string sParameter)
        {
            ClsMasterUser cls = new ClsMasterUser();
            String Nama = cls.getNama(sParameter);
            return Json(new { Data = Nama });
        }

        [HttpPost]
        public JsonResult jsonGetProfile()
        {
            ClsMasterUser cls = new ClsMasterUser();
            return Json(new { Data = cls.getProfile(), Total = cls.getProfile().Count() });
        }

        [HttpPost]
        public JsonResult jsonInsertUser(ClsParameter.User sClsUser)
        {
            ClsMasterUser cls = new ClsMasterUser();
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { status = false, remarks = ModelState.Values, JsonRequestBehavior.AllowGet });
                }
                else
                {
                    Status = cls.insertUser(sClsUser, iStrSessNRP);
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
            catch (Exception e)
            {
                Status = false;
                Remarks = e.ToString();
            }
            return Json(new { status = Status, remarks = Remarks, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult jsonUpdateUser(ClsParameter.User sClsUser)
        {
            ClsMasterUser cls = new ClsMasterUser();
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { status = false, remarks = ModelState.Values, JsonRequestBehavior.AllowGet });
                }
                else
                {
                    Status = cls.updateUser(sClsUser, iStrSessNRP);
                    if (!Status)
                    {
                        Remarks = "Data User gagal dirubah";
                    }
                    else
                    {
                        Remarks = "Data User berhasil dirubah";
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
        public JsonResult jsonDeleteUser(ClsParameter.User sClsUser)
        {
            ClsMasterUser cls = new ClsMasterUser();
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { status = false, remarks = ModelState.Values, JsonRequestBehavior.AllowGet });
                }
                else
                {
                    Status = cls.deleteUser(sClsUser, iStrSessNRP);
                    if (!Status)
                    {
                        Remarks = "Data User gagal dihapus";
                    }
                    else
                    {
                        Remarks = "Data User berhasil dihapus";
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