using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using yazilim_mimari.Data.Abstract;
using yazilim_mimari.Data.Context;
using yazilim_mimari.Data.Models;
using yazilim_mimari.Models.Filter;

namespace yazilim_mimari.Data.Concreate
{
    public class EfSearchService : ISearchService
    {
        private AracSatisContext _context;
        public EfSearchService(AracSatisContext context)
        {
            _context = context;
        }
        public async Task<List<Ilan>> Search(FilterViewModel model)
        {
            var query= _context.Ilanlar.Include(u=>u.arac).AsQueryable();

            if(!string.IsNullOrEmpty(model.Tittle))
                query = query.Where(k=>k.Baslik.Contains(model.Tittle)).Include(k=>k.kullanici).Include(k=>k.Yorumlar).ThenInclude(k=>k.kullanici);
            
            if(!string.IsNullOrEmpty(model.Type))
                query = query.Where(k=>k.arac.Tur==model.Type).Include(k=>k.kullanici).Include(k=>k.Yorumlar).ThenInclude(k=>k.kullanici);
            
            if(model.minPrice!=0)
                query = query.Where(k=>k.Fiyat>=model.minPrice).Include(k=>k.kullanici).Include(k=>k.Yorumlar).ThenInclude(k=>k.kullanici);
            
            if(model.maxPrice!=0)
                query = query.Where(k=>k.Fiyat<=model.maxPrice).Include(k=>k.kullanici).Include(k=>k.Yorumlar).ThenInclude(k=>k.kullanici);
            
            if(model.minKm!=0)
                query = query.Where(k=>k.arac.Km>=model.minKm).Include(k=>k.kullanici).Include(k=>k.Yorumlar).ThenInclude(k=>k.kullanici);
            if(model.maxKm!=0)
                query = query.Where(k=>k.arac.Km<=model.maxKm).Include(k=>k.kullanici).Include(k=>k.Yorumlar).ThenInclude(k=>k.kullanici);
            if(model.MakeId != 0)
                query = query.Where(k=>k.arac.MarkaId==model.MakeId).Include(k=>k.kullanici).Include(k=>k.Yorumlar).ThenInclude(k=>k.kullanici);
            if(model.ModelId!=0)
                query = query.Where(k=>k.arac.ModelId==model.ModelId).Include(k=>k.kullanici).Include(k=>k.Yorumlar).ThenInclude(k=>k.kullanici);
            if(model.minYear!=0)
                query = query.Where(k=>k.arac.UretimYili>=model.minYear).Include(k=>k.kullanici).Include(k=>k.Yorumlar).ThenInclude(k=>k.kullanici);
            if(model.maxYear!=0)
                query.Where(k=>k.arac.UretimYili<=model.maxYear).Include(k=>k.kullanici).Include(k=>k.Yorumlar).ThenInclude(k=>k.kullanici);
            if(!string.IsNullOrEmpty(model.Transmission))
                query = query.Where(k=>k.arac.YakitTuru.Contains(model.
                FuelType)).Include(k=>k.kullanici).Include(k=>k.Yorumlar).ThenInclude(k=>k.kullanici);
            if(!string.IsNullOrEmpty(model.FuelType))
                query = query.Where(k=>k.arac.Sanziman.Contains(model.Transmission)).Include(k=>k.kullanici).Include(k=>k.Yorumlar).ThenInclude(k=>k.kullanici);
            
            var FilteredAds = await query.ToListAsync();
            return FilteredAds;
        }

    }
    }
