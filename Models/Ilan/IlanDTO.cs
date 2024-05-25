using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yazilim_mimari.Models.Ilan
{
    public class IlanDTO
    {
        public string Baslik { get; set;} = string.Empty;
        public int Fiyat { get; set; }
        public int UretimYili { get; set; }

         public string YakitTuru { get; set; } = string.Empty;

        public string Sanziman { get; set; } =string.Empty; 

        public int Km { get; set; }
    
        public bool SisFari { get; set; }
    
        public bool KatlanabilirAyna { get; set; }
    
        public bool ParkSensoru { get; set; }
   
        public bool MerkeziKilit { get; set; }
    
        public bool CamTavan { get; set; }

        public string MakeName { get; set; } = string.Empty;
         public string ModelAdi { get; set; } = string.Empty;
    }
}