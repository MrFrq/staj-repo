using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        public string PersonelAd { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        public string PersonelSoyad { get; set; }

        [Column(TypeName = "VARCHAR")] 
        [StringLength(250)]  // LINK GELECEK
        public string PersonelGorsel { get; set; }

        // Satış ilişkileri : 
        public ICollection<SatisHareket> SatisHarekets { get; set; }

        // Bir personel sadece 1 departmanda bulunabilir 
        public int Departmanid { get; set; }
        public virtual Departman Departman { get; set; }
    }
}