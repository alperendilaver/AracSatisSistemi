using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using yazilim_mimari.Data.Abstract;
using yazilim_mimari.Data.Context;
using yazilim_mimari.Data.Models;

namespace yazilim_mimari.Data.Concreate
{
    public class EfGetMarkService:IGetMarkServie
    {
        AracSatisContext _context;
        public EfGetMarkService(AracSatisContext context)
        {
            _context = context;
        }

        public async Task<List<AracModel>> ModelleriGetir()
        {
            return await _context.Modeller.ToListAsync();
        }
        public async Task<List<Marka>> MarkalariGetir()
        {
            return await _context.Markalar.ToListAsync();
        }
        
    }
}