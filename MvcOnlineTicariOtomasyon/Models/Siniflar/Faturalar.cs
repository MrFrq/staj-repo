using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Faturalar
    {
        [Key]
        public int FaturaID { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public char FaturaSeriNo { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(6)]
        public string FaturaSıraNo { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(60)]
        public string VergiDairesi { get; set; }
        
        public DateTime FaturaTarih { get; set; }
        public DateTime FaturaSaat { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        public string TeslimEden {  get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        public string TeslimAlan {  get; set; }


        // Bir Faturanın birden fazla Kalemi olabilir 
        // Fatura Kalemden üretilecek nesne DB'de FaturaKalems olarak geçecek 
        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}