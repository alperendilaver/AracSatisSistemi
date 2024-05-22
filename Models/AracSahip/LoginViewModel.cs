using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yazilim_mimari.Models.AracSahip
{
    public class LoginViewModel
    {

        [Required]
        public string EPosta { get; set; } = String.Empty;
        [Required]
        public string Password { get; set; } = String.Empty;
        public bool RememberMe { get; set; } 
  
    }
}