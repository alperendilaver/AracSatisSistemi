using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yazilim_mimari.Data.Models
{
    public class Yorum
    {
        [Key]
        public int YorumId { get; set; }

        public string YorumIcerik { get; set; } =string.Empty;
    
        public DateTime Tarih { get; set; }

        public int KullaniciId { get; set; }
        public Kullanici kullanici { get; set; } = null!;
        public int IlanId { get; set; }
        public Ilan Ilan { get; set; }=null!;
    }
}