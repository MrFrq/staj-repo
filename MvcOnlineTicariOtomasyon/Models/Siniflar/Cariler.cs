using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Cariler
    {
        [Key]
        public  int CariID { get; set; }
        
        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        public  string CariAd { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        public  string CariSoyad { get; set; }

        //public  string CariUnvan MyProperty { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(15)]
        public  string CariSehir { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        public  string CariMail  { get; set; }

        // Satış ilişkileri : 
        public ICollection<SatisHareket> SatisHarekets { get; set; }

    }
}