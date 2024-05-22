using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace yazilim_mimari.Data.Models
{
    [Index(nameof(ModelAdi),IsUnique = true)]
    public class AracModel
    {  
        
        [Key]
        public int ModelId { get; set; }
        
        public int MarkaId { get; set; }
        public Marka Marka { get; set; } = null!;
        public string ModelAdi { get; set; } = string.Empty;
    }
}