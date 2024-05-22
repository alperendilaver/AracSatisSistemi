using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yazilim_mimari.Models.Ilan
{
    public class IlanDuzenleViewModel
    {
        [Required]
        public int IlanId { get; set; }
        [Required]
        public int Fiyat { get; set; }
        
        [Required]
        public List<string> Resimler { get; set; } = new List<string>();

        [Required]
        public IFormFileCollection Gorseller{ get; set; } = null!;

        [Required]
        public int Km { get; set; }
   
        [Required]
        public int KullaniciId { get; set; }
    }
}