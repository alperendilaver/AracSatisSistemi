using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yazilim_mimari.Models.AracSahip
{
    public class RegisterViewModel
    {
        [Required]
        public string Ad { get; set; } =String.Empty;

        [Required]
        public string Soyad { get; set; } = String.Empty;
    
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Eposta { get; set; } = String.Empty;
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }= String.Empty;

        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = String.Empty;
    }
}