using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class FaturaKalem
    {
        [Key]
        public  int FaturaKalemID { get; set; }

        [Column(TypeName = "VARCHAR")] 
        [StringLength(100)]
        public   string Aciklama { get; set; }
        public    int  Miktar { get; set; }
        public    decimal BirimFiyat{ get; set; }
        public    decimal Tutar { get; set; }


        // Bir Fatura kaleminin sadece bir faturası olabilir 
        public  Faturalar  Faturalar { get; set; }

    }
}