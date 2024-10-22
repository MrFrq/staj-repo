﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System.Web.Security;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Partial11()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial11(Cariler car)
        {
            c.Carilers.Add(car);
            c.SaveChanges();
            return PartialView();
        }

        [HttpGet]
        public ActionResult CariLogin1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariLogin1(Cariler cr)
        {
            var bilgiler = c.Carilers.FirstOrDefault(x => x.CariMail == cr.CariMail
            && x.CariSifre == cr.CariSifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false);
                Session["CariMail"] = bilgiler.CariMail.ToString();
                return RedirectToAction("Index", "CariPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.KullanıcıAd == p.KullanıcıAd
            && x.Sifre == p.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullanıcıAd, false);
                Session["KullanıcıAd"] = bilgiler.KullanıcıAd.ToString();
                return RedirectToAction("Index", "istatistik");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}