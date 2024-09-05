using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanelController
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degerler = c.Carilers.FirstOrDefault(x => x.CariMail == mail);
            ViewBag.m = mail;    
            return View(degerler);
        }

        [Authorize]
        public ActionResult CariGuncelleme()
        {            
            return View();
        }

        [Authorize]
        public ActionResult CariGuncelle(Cariler cr)
        {
            var cari = c.Carilers.Find(cr.CariID);
            cari.CariAd =cr.CariAd;
            cari.CariSoyad =cr.CariSoyad;
            cari.CariSehir =cr.CariSehir;
            //cari.CariMail =cr.CariMail;
            cari.CariSifre =cr.CariSifre;
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        [Authorize]
        public ActionResult Siparislerim()
        {   
            // sisteme giriş yapan mail adresi bilgisi
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == mail.ToString())
                .Select(y => y.CariID).FirstOrDefault();
            //^^ sisteme giriş yapan mail adresinin ID 'sini çektik 
            var degerler = c.SatisHarekets.Where(x=>x.Cariid==id).ToList();
            return View(degerler);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();  //istekleri reddet
            return RedirectToAction("Index","Login");
        }

    }
} 