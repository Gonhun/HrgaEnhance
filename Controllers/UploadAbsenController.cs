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

namespace HrgaEnhance.Controllers
{
    public class UploadAbsenController : Controller
    {
        bool Status;
        String Remarks;
        private string iStrSessNRP = string.Empty;
        private string iStrSessDistrik = string.Empty;
        private string iStrSessGPID = string.Empty;

        // GET: MasterAbsen
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
        public JsonResult jsonGetAbsen([DataSourceRequest] DataSourceRequest request, String s_Nrp, String s_Awal, String s_Akhir)
        {
            ClsUploadAbsen cls = new ClsUploadAbsen();
            return Json(cls.getAbsen(s_Nrp, s_Awal, s_Akhir).ToDataSourceResult(request));
        }

        [HttpPost]
        public JsonResult jsonGetAbsenCode()
        {
            ClsUploadAbsen iCls = new ClsUploadAbsen();
            return Json(new { Data = iCls.getAbsenCode(), Total = iCls.getAbsenCode().Count()});
        }

        [HttpPost]
        public JsonResult jsonUpdateAbsen(ClsParameter.Absen sParameter)
        {
            try
            {
                this.pv_CustLoadSession();
                LtsAbsenDataContext dataContext = new LtsAbsenDataContext();

                if (!ModelState.IsValid)
                {
                    var message = string.Join(" | ", ModelState.Values
                                        .SelectMany(v => v.Errors)
                                        .Select(e => e.ErrorMessage));

                    return Json(new { status = false, remarks = message, JsonRequestBehavior.AllowGet });
                }
                else
                {
                    ClsUploadAbsen iCls = new ClsUploadAbsen();
                    Status = iCls.updateAbsen(sParameter, iStrSessNRP);
                    Remarks = "Absensi sudah di update";
                }
            }
            catch(Exception e)
            {
                Status = false;
                Remarks = e.ToString();
            }
            return Json(new { status = Status, remarks = Remarks, JsonRequestBehavior.AllowGet });
        }

        public JsonResult jsonUploadCSV(string id, int type = 0)
        {
            DataTable dt = new DataTable();
            var iStrRemarks = string.Empty;
            LtsAbsenDataContext context = new LtsAbsenDataContext();
            id = System.Guid.NewGuid().ToString();
            string Name;
            ClsUploadAbsen cls = new ClsUploadAbsen();

            try
            {
                foreach(string file in Request.Files)
                {
                    var fileContent = Request.Files[file];
                    if (fileContent != null && fileContent.ContentLength > 0)
                    {
                        var fileName = fileContent.FileName.Substring(fileContent.FileName.LastIndexOf("\\") + 1);
                        Name = fileContent.FileName;
                        var path = Path.Combine(Server.MapPath("~/Csv/Absen"), fileName);
                        fileContent.SaveAs(path);

                        context.CommandTimeout = 999999999;
                        context.ExecuteCommand("DELETE FROM dbo.lembarkerja_temp_new");
                        dt = cls.ProcessCSV(path, id, "SYSTEM");
                        iStrRemarks = cls.ProcessBulkCopy(dt, "DATA_ABS1ConnectionString", "dbo.lembarkerja_temp_new");
                    }

                    context.cusp_UploadDataAbsenPama(id, "SYSTEM HC");
                    context.SubmitChanges();
                }
                return Json(new { remarks = iStrRemarks, status = true, JsonRequestBehavior.AllowGet });
            }
            catch(Exception e)
            {
                return Json(new { remaks = "Upload failed. error :" + e.ToString(), error = e.ToString(), status = false });
            }
            finally
            {
                context.Dispose();
            }
        }
    }
}