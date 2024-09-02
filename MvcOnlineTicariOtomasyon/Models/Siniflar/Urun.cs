using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar                                 
{
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }

        [Column(TypeName = "VARCHAR")] 
        [StringLength(30)]
        public string UrunAd { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        public string Marka { get; set; }

        public short  Stok { get; set; }
        public decimal AlisFiyati{ get; set; } 
        public decimal SatisFiyati{ get; set; } 
        public bool Durum{ get; set;}    // örn ürün stok sayısı 10'un altına düşerse "STOKLAR TÜKENİYOR.." 

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string UrunGorsel { get; set; }

        // bu şekilde DB' ye atılırsa string değişlenler NVCHAR(MAX) 
        public int Kategoriid { get; set; }
        public virtual Kategori Kategori { get; set; }                  // KATEGORİ SINIFINDAKİ DEĞERLERE ULAŞABİLECEĞİZ

        // Satış ilişkileri : 
        public ICollection<SatisHareket> SatisHarekets { get; set; }

    }
}