using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using yazilim_mimari.Data.Abstract;
using yazilim_mimari.Data.Context;
using yazilim_mimari.Data.Models;
using yazilim_mimari.Models.AracSahip;

namespace yazilim_mimari.Data.Concreate
{
    public class EfUserService : IUserService
    {
        private AracSatisContext _context;
        public EfUserService(AracSatisContext context)
        {
            _context = context;
        }

        public async Task<Kullanici> Login(LoginViewModel loginViewModel)
        {
            return await _context.Kullanicilar.Where(u=>u.Eposta==loginViewModel.EPosta && u.Password==loginViewModel.Password).FirstOrDefaultAsync()??new Kullanici();
        }


        public int Register(RegisterViewModel registerViewModel)
        {
            var kullanici = new Kullanici{
                Ad=registerViewModel.Ad,
                Soyad = registerViewModel.Soyad,
                Eposta=registerViewModel.Eposta,
                Password=registerViewModel.Password,  // şifreleme yapılacak
            };
            _context.Kullanicilar.Add(kullanici);
            var result = _context.SaveChanges();
            return result;
        }
    }
}