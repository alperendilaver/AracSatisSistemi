using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;

namespace yazilim_mimari.Data.Models
{
    public class Ilan
    {
        [Key]
        public int IlanId { get; set; }

        public int Fiyat { get; set; }
        public string Baslik { get; set; } = string.Empty;
        public List<string> Resimler { get; set; } = new List<string>();
        public int AracId { get; set; }
        public Arac arac{ get; set; } = null!;
        public bool AdminOnayladiMi { get; set; } = false;

        public bool YayindaMi {get; set; } = true;
        public int KullaniciId { get; set; }
        public Kullanici kullanici { get; set; } = null!;

        public List<Yorum> Yorumlar { get; set; } = new List<Yorum>();
    }
}