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
        [StringLength(30,ErrorMessage ="En fazla 30 karakter girebilirsiniz...")]
        [Required(ErrorMessage = "Bu alan boş geçilemez!!")]
        public  string CariAd { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        [Required(ErrorMessage ="Bu alan boş geçilemez!!")]
        public  string CariSoyad { get; set; }

        //public  string CariUnvan MyProperty { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(16, ErrorMessage = "En fazla 30 karakter girebilirsiniz...")]
        [Required(ErrorMessage = "Bu alan boş geçilemez!!")]
        public  string CariSehir { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(40, ErrorMessage = "En fazla 30 karakter girebilirsiniz...")]
        [Required(ErrorMessage = "Bu alan boş geçilemez!!")]        
        public  string CariMail  { get; set; }

        public bool Durum { get; set; }

        // Satış ilişkileri : 
        public ICollection<SatisHareket> SatisHarekets { get; set; }

    }
}