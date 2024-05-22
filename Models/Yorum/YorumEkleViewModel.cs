using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using yazilim_mimari.Data.Models;

namespace yazilim_mimari.Models.Yorum
{
    public class YorumEkleViewModel
    {

        public string Yorum {get; set; } =String.Empty;

        public int IlanId { get; set; }

        public int KullaniciId { get; set; }
        public DateTime Tarih { get; set; } = DateTime.Now;
    
    }
}