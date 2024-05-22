using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using yazilim_mimari.Data.Abstract;
using yazilim_mimari.Data.Context;
using yazilim_mimari.Data.Models;
using yazilim_mimari.Models.Istek;

namespace yazilim_mimari.Data.Concreate
{
    public class EfRequestService : IRequestService
    {
        private AracSatisContext _context;
        public EfRequestService(AracSatisContext aracSatisContext)
        {
            _context = aracSatisContext;
        }
        public async Task<int> IstekOlustur(int IlanId)
        {
            await _context.Istekler.AddAsync(new Istek{
                IlanId = IlanId,
                Durum=IstekDurumu.beklemede
            });
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<Istek> IstekGetir(int IstekId)
        {
            return await _context.Istekler.Where(i=>i.IstekId==IstekId).FirstOrDefaultAsync() ?? new Istek();    
        }


        public async Task<int> IstekOnayla(int IstekId,int IlanId)
        {
            var istek = await IstekGetir(IstekId);
            istek.Durum = IstekDurumu.kabul;
            _context.Update(istek);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<int> IstekReddet(int IstekId)
        {
            var istek = await IstekGetir(IstekId);
            istek.Durum = IstekDurumu.red;
            var result = await _context.SaveChangesAsync();
            return result;    
        }
     
        public async Task<int> IlanBeklemeyeAl(int IlanId)
        {
            var istek = await IlanaGoreIstekBul(IlanId);
            istek.Durum = IstekDurumu.beklemede;
            _context.Istekler.Update(istek);
            var result = await _context.SaveChangesAsync();
            return result;
        }
        public async Task<List<Istek>> IstekleriListele()
        {
            return await _context.Istekler.Where(i=>i.Durum==IstekDurumu.beklemede).Include(u=>u.Ilan).ThenInclude(u=>u.arac.Marka).Include(u=>u.Ilan).ThenInclude(u=>u.arac.Model).ToListAsync();
        }

        public async Task<Istek> IlanaGoreIstekBul(int IlanId)
        {
            return await _context.Istekler.Where(i=>i.IlanId==IlanId).FirstOrDefaultAsync() ?? new Istek();
        }

        public async Task<int> IstekSil(int IlanId)
        {
            var istek = await IlanaGoreIstekBul(IlanId);
            _context.Istekler.Remove(istek);
            var result= await _context.SaveChangesAsync();
            return result;
        }

   
    }
}