using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using yazilim_mimari.Data.Models;

namespace yazilim_mimari.Models.Ilan
{
    public class IlanOlusturViewModel
    {
        [Required]
        public int Fiyat { get; set; }
        public string Baslik { get; set; } =string.Empty;
        [Required]
        public List<string> Resimler { get; set; } = new List<string>();


        [Required]
        public IFormFileCollection Gorseller{ get; set; } = null!;

        [Required]
        public string Tur { get; set; } =string.Empty;
        
        [Required]
        public int UretimYili { get; set; }
        [Required]
        public int MarkaId { get; set; } 

        [Required]
        public int ModelId { get; set; }

        [Required]
        public string Sanziman { get; set; } = string.Empty;
        [Required]
        public int Km { get; set; }
   
        [Required]

        public string  YakitTuru { get; set; } = string.Empty;
      

        [Required]
        public bool SisFari { get; set; }
   
        [Required]
        public bool KatlanabilirAyna { get; set; }

        [Required]
        public bool ParkSensoru { get; set; }
    
        [Required]
        public bool MerkeziKilit { get; set; }
    
        [Required]
        public bool Camtavan { get; set; }

        [Required]
        public int KullaniciId { get; set; }
    }
}