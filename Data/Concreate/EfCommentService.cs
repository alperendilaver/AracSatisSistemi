using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yazilim_mimari.Data.Abstract;
using yazilim_mimari.Data.Context;
using yazilim_mimari.Data.Models;
using yazilim_mimari.Models.Yorum;

namespace yazilim_mimari.Data.Concreate
{
    public class EfCommentService : ICommentService
    {
        private AracSatisContext _context;
        public EfCommentService(AracSatisContext aracSatisContext)
        {
            _context = aracSatisContext;
        }
        public async Task<int> YorumEkle(YorumEkleViewModel yorumEkleViewModel)
        {
            await _context.Yorumlar.AddAsync(new Yorum{
                IlanId=yorumEkleViewModel.IlanId,
                KullaniciId=yorumEkleViewModel.KullaniciId,
                Tarih=yorumEkleViewModel.Tarih,
                YorumIcerik=yorumEkleViewModel.Yorum
            });
            return await _context.SaveChangesAsync();
        }
    }
}