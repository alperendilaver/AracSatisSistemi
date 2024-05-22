using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yazilim_mimari.Data.Models;
using yazilim_mimari.Models.AracSahip;

namespace yazilim_mimari.Data.Abstract
{
    public interface IUserService
    {
        public int Register(RegisterViewModel registerViewModel);

        Task<Kullanici> Login(LoginViewModel loginViewModel); 

        
    
    }
}