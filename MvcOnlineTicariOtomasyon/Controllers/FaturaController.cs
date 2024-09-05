using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Migrations;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System.Security.Policy;
using System.Web.UI.WebControls;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var liste = c.Faturalars.ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturalars.Find(id);
            return View("FaturaGetir", fatura);
        }

        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var fatura = c.Faturalars.Find(f.FaturaID);
            fatura.FaturaSeriNo = f.FaturaSeriNo;
            fatura.FaturaSıraNo = f.FaturaSıraNo;
            fatura.FaturaSaat = f.FaturaSaat;
            fatura.FaturaTarih = f.FaturaTarih;
            fatura.TeslimAlan = f.TeslimAlan;
            fatura.TeslimEden = f.TeslimEden;
            fatura.VergiDairesi = f.VergiDairesi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.Faturaid == id).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem p)
        {
            c.FaturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}






//1-Fatura/ index view den faturaDetay controller a FaturaID yi göndedim

//<td><a href="/Fatura/FaturaDetay/@k.FaturaID" class= "btn btn-warning" > Fatura Kalemleri </ a ></ td >

//2 - FaturaDetay Controller ı şu şeklide yazdım

//public ActionResult FaturaDetay(int id)

//{

//    var degerler = c.FaturaKalems.Where(x => x.FaturaID == id).ToList();

//    var fatura = c.Faturalars.Where(x => x.FaturaID == id).Select(y => y.FaturaID).FirstOrDefault();

//    ViewBag.f = fatura;

//    var faturaseri = c.Faturalars.Where(x => x.FaturaID == id).Select(y => y.FaturaSeriNo).FirstOrDefault();

//    ViewBag.fseri = faturaseri;



//    return View(degerler);

//}

//3 - FaturaDetay ın view inden YeniKalem Controller ına faturaID yi taşıdım.

//<a href="/Fatura/YeniKalem/@ViewBag.f" class= "btn btn-default" style = "background-color:darksalmon" > Yeni Kalem Ekle</a>





//4-Yeni kalem ekleme controller ı aşağıdaki gibi yaptım.

//[HttpGet]

//        public ActionResult YeniKalem()

//{

//    return View();



//}

//[HttpPost]

//public ActionResult YeniKalem(FaturaKalem f, int id)

//{

//    var fatura = c.Faturalars.Where(x => x.FaturaID == id).Select(y => y.FaturaID).FirstOrDefault();

//    f.FaturaID = fatura;

//    c.FaturaKalems.Add(f);

//    c.SaveChanges();

//    return RedirectToAction("/FaturaDetay/" + fatura);

//}
