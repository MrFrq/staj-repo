using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();   // tablolar context sınıfında tutuluyor

        public ActionResult Index()
        {
            var degerler = c.Kategoris.ToList();
            return View(degerler);
        }

        [HttpGet]                         // View Yüklendiği zaman çalıştır
        public ActionResult KategoriEkle()
        {
            return View();               // boş sayfa gelir
        }

        [HttpPost]                      //butona tıklandığı zaman çalıştır
        public ActionResult KategoriEkle(Kategori k)
        {
            c.Kategoris.Add(k); // Context'te bulunan kategorinin içine k'dan gelen değeri ekle
                                // (View tarafından gelen parametre) = Kategori Adı
            c.SaveChanges();   // context'e  k'dan gelen değerleri ekle DB'ye kaydet (EF yapısı)  //ado nette karşılığı ExeCuteNonQuery 
            return RedirectToAction("Index");  // işlem bittikten sonra index aksiyonuna yönlendir 
        }
        public ActionResult KategoriSil(int id) 
        {
            var ktg = c.Kategoris.Find(id);
            c.Kategoris.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id) 
        {
            var kategori = c.Kategoris.Find(id);
            return View("KategoriGetir",kategori);  
        }

        public ActionResult KategoriGuncelle(Kategori k) 
        {
            var ktgr = c.Kategoris.Find(k.KategoriID); // değişken aracılığı ile sayfadaki ID hafızaya alındı
            ktgr.KategoriAd = k.KategoriAd;  // k = parametre olarak View tarafına gönderilecek değerler
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}