using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace yazilim_mimari.Data.Models
{
    [Index(nameof(MakeName),IsUnique = true)]
    public class Marka
    {
        [Key]
        public int MarkaId { get; set; }

        public string MakeName { get; set; } = string.Empty;
    }
}