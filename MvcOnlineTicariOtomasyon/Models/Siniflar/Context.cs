using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Context: DbContext
    {
    
        public DbSet<Admin>  Admins{ get; set; }  // Tablo bazlı çalışacağız ve bu tablo DB'ye yansıtılacak
        public DbSet<Cariler> Carilers { get; set; } // sınıf isimlerinin tablo isimleri ile karışmaması için s takısı 
        public DbSet<Departman> Departmans { get; set; } 
        public DbSet<FaturaKalem> FaturaKalems { get; set; } 
        public DbSet<Faturalar> Faturalars { get; set; }
        public DbSet<Gider> Giders { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }    //
        public DbSet<Personel> Personels { get; set; } 
        public DbSet<SatisHareket> SatisHarekets { get; set; } 
        public DbSet<Urun> Uruns { get; set; } 
        public DbSet<Detay> Detays { get; set; } 
        //public DbSet<Class1> Class1s { get; set; } 
    }
}