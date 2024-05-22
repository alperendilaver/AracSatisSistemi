using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yazilim_mimari.Data.Models;

namespace yazilim_mimari.Models.Istek
{
    public class IstekOlusturViewModel
    {
        public int IlanId { get; set; }

        public IstekDurumu Istek { get; set; } = IstekDurumu.beklemede;
    }
}