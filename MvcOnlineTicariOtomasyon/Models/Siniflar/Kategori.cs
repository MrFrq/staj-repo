using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Kategori
    {

        [Key]
        public int KategoriID { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        public string KategoriAd { get; set; }

        // kategori - ürün ilişkisi   // her bir kategoride birden fazla ürün vardır 

        public ICollection<Urun>  Uruns  { get; set; }  // ICollection inteface'ini kullandık 
        // it means there can be more than one product in each category
        // public  Kategori Kategori { get; set; }  // Urun.cs



    }
}