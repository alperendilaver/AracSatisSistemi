using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace yazilim_mimari.Data.Models
{
    public enum IstekDurumu{
        kabul,red,beklemede
    }
    public class Istek
    {
        [Key]
        public int IstekId { get; set; }

        public int IlanId { get; set; }
        public Ilan Ilan { get; set; }=null!;

        public IstekDurumu Durum { get; set; }
    }
}