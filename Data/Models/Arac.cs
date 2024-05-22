using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace yazilim_mimari.Data.Models
{
    public class Arac
    {
        [Key]
        public int AracId { get; set; }
        public string Tur { get; set; }=string.Empty; 
        public int UretimYili { get; set; }


        public int MarkaId { get; set; }
        public Marka Marka { get; set; } =null!;

        public int ModelId { get; set; }
        public AracModel Model { get; set; } = null!;

        public string YakitTuru { get; set; } = string.Empty;

        public string Sanziman { get; set; } =string.Empty; 

        public int Km { get; set; }
    
        public bool SisFari { get; set; }
    
        public bool KatlanabilirAyna { get; set; }
    
        public bool ParkSensoru { get; set; }
   
        public bool MerkeziKilit { get; set; }
    
        public bool CamTavan { get; set; }
    }
}