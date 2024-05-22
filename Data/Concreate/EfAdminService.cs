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
    public class EfAdminService : IAdminService
    {
        private AracSatisContext _context;
        private IIlanService _ilanService;
        private IRequestService _requestService;
        public EfAdminService(IRequestService requestService,IIlanService ilanService,AracSatisContext context)
        {
            _ilanService = ilanService;
            _requestService = requestService;
            _context = context;
        }
        public async Task<int> IlanOnayla(int IstekId,int IlanId)
        {
            var result = await _ilanService.IlanYayinaAl(IlanId, IstekId);
            return result;
        }

        public async Task<int> IlanReddet(int IstekId)
        {
            var result = await _requestService.IstekReddet(IstekId);
            return result;
        }

        public async Task<int> MarkaEkle(string MakeName){
            await _context.Markalar.AddAsync(new Marka{
                MakeName=MakeName
            });
            return await _context.SaveChangesAsync();
        }

       

        public async Task<int> ModelEkle(int MarkaId, string ModelAdi)
        {
            await _context.Modeller.AddAsync(new AracModel{
                MarkaId=MarkaId,
                ModelAdi=ModelAdi
            });
            return await _context.SaveChangesAsync();
        }

        
    }
}