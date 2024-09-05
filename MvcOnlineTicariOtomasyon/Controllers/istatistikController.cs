using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Microsoft.Ajax.Utilities;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class istatistikController : Controller
    {
        // GET: istatistik
        Context c = new Context(); 
        public ActionResult Index()
        {
            var deger1 = c.Carilers.Count().ToString();
            ViewBag.d1 = deger1;

            var deger2 = c.Uruns.Count().ToString();
            ViewBag.d2 = deger2;

            var deger3 = c.Personels.Count().ToString();
            ViewBag.d3 = deger3;

            var deger4 = c.Kategoris.Count().ToString();
            ViewBag.d4 = deger4;

            var deger5 = c.Uruns.Sum(x => x.Stok).ToString();
            ViewBag.d5 = deger5;

            //seçilen markayı TEKRARSIZ olarak SAY
            var deger6 = (from x in c.Uruns select x.Marka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;

            var deger7 = c.Uruns.Count(x => x.Stok <= 20).ToString();
            ViewBag.d7 = deger7;

            //max fiyatlı ürünü seç
            var deger8 = (from x in c.Uruns orderby x.SatisFiyati descending select x.UrunAd).FirstOrDefault();
            ViewBag.d8 = deger8;

            var deger9 = (from x in c.Uruns orderby x.SatisFiyati ascending select x.UrunAd).FirstOrDefault();
            ViewBag.d9 = deger9;

            // en çok ürün çeşidi olan marka //tabloyu artan sıralayıp tablodaki en üstteki değeri çekecek 
            var deger10 = c.Uruns.GroupBy(x=>x.Marka).OrderByDescending(y=>y.Count()).Select(z=>z.Key).FirstOrDefault();
            ViewBag.d10 = deger10;

            var deger11 = c.Uruns.Count(x => x.UrunAd == "Buzdolabı").ToString();
            ViewBag.d11 = deger11;

            var deger12 = c.Uruns.Count(x => x.UrunAd == "Laptop").ToString();
            ViewBag.d12 = deger12;

            // SatışHareket tablosunda UrunId'si en çok geçen ürünün Adını çeken Linq Sorgusu
            var deger13 = c.Uruns.Where(u => u.UrunId == (c.SatisHarekets.GroupBy(x => x.Urunid).
            OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.UrunAd).FirstOrDefault();
            ViewBag.d13 = deger13;

            var deger14 = c.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.d14 = deger14;

            var deger15 = c.SatisHarekets.Count(x => x.SatisTarihi == DateTime.Today).ToString();
            ViewBag.d15 = deger15;         

            try
            {
                var deger16 = c.SatisHarekets.Where(x => x.SatisTarihi == DateTime.Today).Sum(y => y.ToplamTutar).ToString();
                ViewBag.d16 = deger16;
            }
            catch (Exception)
            {

                var deger16 =0;
                ViewBag.d16 = deger16;
            }
            return View();


        }

        public  ActionResult BasitTablolar()
        {
            var sorgu = from x in c.Carilers
                        group x by x.CariSehir into g
                        select new SinifGrup
                        {
                            Sehir = g.Key,
                            Sayi= g.Count()
                        };
             return View(sorgu.ToList()); 
        }

        public PartialViewResult Partial1() 
        {
            var sorgu2 = from x in c.Personels
                         group x by x.Departman.DepartmanAd into g
                         select new SinifGrup2
                         {
                             Departman = g.Key,
                             Sayi = g.Count()   
                         };

            return PartialView(sorgu2.ToList());
        }


        public PartialViewResult Partial2()
        {
            var sorgu3 = c.Carilers.ToList();
            return PartialView(sorgu3);
        }
        public PartialViewResult Partial3()
        {
            var sorgu = c.Uruns.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial4()
        {
            var sorgu= from x in c.Uruns
                         group x by x.Marka into g
                         select new SinifGrup3
                         {
                             marka = g.Key,
                             sayi = g.Count()
                         };

            return PartialView(sorgu.ToList());
        }
    }


}