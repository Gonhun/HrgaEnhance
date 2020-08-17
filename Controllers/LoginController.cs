using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FormsAuth;
using HrgaEnhance.Models;
using Newtonsoft.Json;

namespace HrgaEnhance.Controllers
{
    public class LoginController : Controller
    {
        bool Status;
        String Remarks;
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult getUser(ClsLogin clsLogin)
        {
            ClsLogin iCls = new ClsLogin();
            LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();

            try
            {
                var ldap = new LdapAuthentication("LDAP://PAMAPERSADA:389");
                Status = ldap.IsAuthenticated("PAMAPERSADA", clsLogin.userid, clsLogin.password);

                if (Status)
                {
                    String idLogin;
                    idLogin = clsLogin.userid.Length == 0 ? "0" : clsLogin.userid;
                    idLogin = idLogin.Substring(1, idLogin.Length - 1);
                    var list_gpId = dataContext.VW_M_PROFILEs.Where(f => f.USERID == idLogin).ToList();
                    FormsAuthentication.SetAuthCookie(idLogin, true);
                    if (list_gpId.Count > 0)
                    {
                        foreach (var v in list_gpId)
                        {
                            Session["PNRP"] = idLogin;
                            Session["NRP"] = v.USERID;
                            Session["Nama"] = v.Nama;
                            Session["Nama_Nrpp"] = string.Format("{0} - {1}", v.USERID, v.Nama);
                        }

                        return RedirectToAction("Profiles", "Login");
                        // var pID = "p" + pNrp;

                    }
                    else
                    {
                        TempData["notice"] = "User NRP anda tidak di temukan di database, Pastikan anda sudah terdaftar.. !!";
                    }
                }
                else
                {
                    TempData["notice"] = "User NRP anda tidak di temukan di database, Pastikan anda sudah terdaftar.. !!";
                }
            }
            catch (Exception e)
            {
                Remarks = e.ToString();
                Status = false;
                TempData["notice"] = "Jaringan error atau Anda belum memiliki login komputer. Segera info ke tim IT";
            }
            return RedirectToAction("Index", "Login");
        }

        public ActionResult Profiles()
        {
            if (Session["PNRP"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                IEnumerable<SelectListItem> itemsProfile;

                itemsProfile = getProfile().Select(c => new SelectListItem
                {
                    Value = c.value,
                    Text = c.text
                });

                ViewBag.Profile = itemsProfile;
                return View();
            }
        }

        [HttpPost]
        public List<itemSelect> getProfile()
        {
            
            List<itemSelect> ls = new List<itemSelect>();
            LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();
            string i_str_empId = Session["NRP"] == null ? "" : Session["NRP"].ToString();
            var list_viewGp = dataContext.VW_M_PROFILEs
                                        .Where(f => f.USERID == i_str_empId
                                        ).ToList();

            foreach (var v in list_viewGp)
            {
                ls.Add(new itemSelect { text = Convert.ToString(v.PROFILE_NAME), value = Convert.ToString(v.ID_PROFILE) });
            }

            return ls;
        }

        [HttpPost]
        public ActionResult Authenticate(string idProfile)
        {
            Session["gpId"] = idProfile;
            Session["distrik"] = "BRCG"; //HardCode
            string i_str_empId = Convert.ToString(Session["NRP"]);
            LtsHrgaEnhanceDataContext dataContext = new LtsHrgaEnhanceDataContext();

            try
            {
                var list_viewGp = dataContext.VW_M_PROFILEs
                                        .Where(
                                            f => f.USERID == i_str_empId
                                              && f.ID_PROFILE == Convert.ToInt32(idProfile)
                                         ).ToList();

                foreach (var v in list_viewGp)
                {
                    Session["description"] = Convert.ToString(v.PROFILE_NAME);
                }

                if (list_viewGp.Count == 0)
                {
                    TempData["notice"] = "User NRP anda tidak di temukan di database, Pastikan anda sudah terdaftar.. !!";
                    return RedirectToAction("Index", "Login");
                }

                if (idProfile != null || idProfile != "")
                {
                    dataContext.Dispose();
                    //ClsHome iClsHome = new ClsHome();
                    //cufn_getInnerHtmlResult menu = iClsHome.GetMenu(idProfile).FirstOrDefault();
                    //ViewData["myMenu"] = menu.InnerHTML;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            catch(Exception e)
            {
                String Remarks = e.ToString();
                TempData["notice"] = "Akses anda error";
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index", "login");
        }

        public class itemSelect
        {
            public string text { get; set; }
            public string value { get; set; }
        }
    }
}