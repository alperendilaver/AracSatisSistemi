using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yazilim_mimari.Data.Models
{
    public class Kullanici
    {
        [Key]
        public int UserId { get; set; }

        public string Ad { get; set; } = string.Empty;

        public string Soyad { get; set; } = string.Empty;

        public string Eposta { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Role {get;set;} ="Uye";

        public List<Ilan> KullaniciIlanlari { get; set; } = new List<Ilan>();
    }
}