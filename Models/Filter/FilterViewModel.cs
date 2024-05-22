using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yazilim_mimari.Models.Filter
{
    public class FilterViewModel
    {
        public string Tittle { get; set; } = string.Empty;

        public string Type { get; set; }=string.Empty;

        public int minPrice { get; set; }
    
        public int maxPrice { get; set; }

        public int minKm { get; set; }

        public int maxKm { get; set; }

        public int minYear { get; set; }
        
        public int maxYear { get; set; }
        
        public int MakeId { get; set; } 

        public int ModelId { get; set; }

        public string FuelType { get; set; } = string.Empty;
        public string Transmission { get; set; } = string.Empty;
        
    }

}