using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using yazilim_mimari.Data.Abstract;
using yazilim_mimari.Data.Context;
using yazilim_mimari.Data.Models;
using yazilim_mimari.Models.Ilan;

namespace yazilim_mimari.Data.Concreate
{
    public class EfIlanService : IIlanService
    {
        IGorselService _gorselService;
        IRequestService _requestService;
        AracSatisContext _context;
        public EfIlanService(AracSatisContext aracSatisContext,IRequestService requestService,IGorselService gorselService)
        {
            _gorselService = gorselService;
            _requestService = requestService;
            _context=aracSatisContext;
        }
        public async Task<int> IlanOlustur(IlanOlusturViewModel model)
        {
          var resimler= await _gorselService.GorselEkle(model.Gorseller);

          var arac= new Arac{
            CamTavan = model.Camtavan,
            KatlanabilirAyna = model.KatlanabilirAyna,
            Km = model.Km,
            MarkaId=model.MarkaId,
            MerkeziKilit=model.MerkeziKilit,
            ParkSensoru=model.ParkSensoru,
            Sanziman=model.Sanziman,
            SisFari=model.SisFari,
            UretimYili=model.UretimYili,
            YakitTuru=model.YakitTuru,
            Tur=model.Tur,
            ModelId=model.ModelId,
          };
          var ilan= new Ilan{
                Fiyat=model.Fiyat,
                Baslik=model.Baslik,
                Resimler = resimler,
                KullaniciId=model.KullaniciId,
                arac = arac
            }; 
            await _context.Ilanlar.AddAsync(ilan);
            var result = await _context.SaveChangesAsync();
            
            await _requestService.IstekOlustur(ilan.IlanId);
            return result;
        }
        public async Task<int> IlanDuzenle(IlanDuzenleViewModel ilanDuzenleViewModel)
        {
            var YeniGorseller= await _gorselService.GorselEkle(ilanDuzenleViewModel.Gorseller);
            var ilan = await IlanGetir(ilanDuzenleViewModel.IlanId);
            _gorselService.EskiGorselleriSil(ilan);
            ilan.Fiyat=ilanDuzenleViewModel.Fiyat;
            ilan.arac.Km=ilanDuzenleViewModel.Km;
            ilan.Resimler = YeniGorseller;
            ilan.AdminOnayladiMi = false;
            _context.Update(ilan);
            var result = await _context.SaveChangesAsync();
            var istekSonuc = await _requestService.IlanBeklemeyeAl(ilanDuzenleViewModel.IlanId);
            return istekSonuc > 0 ? result : 0 ;
        }
        public async Task<Ilan> IlanGetir(int IlanId)
        {
            var ilan = await _context.Ilanlar.Where(x=>x.IlanId==IlanId).Include(y=>y.Yorumlar).ThenInclude(u=>u.kullanici).Include(u=>u.kullanici).Include(u=>u.arac).ThenInclude(u=>u.Marka).Include(u=>u.arac).ThenInclude(u=>u.Model).FirstOrDefaultAsync();
            return ilan??new Ilan();
        }

        public async Task<int> IlanKaldir(int IlanId)
        {
            var ilan = await IlanGetir(IlanId);
            var istekSonuc =  await _requestService.IstekSil(IlanId);
            _context.Ilanlar.Remove(ilan);
            _gorselService.EskiGorselleriSil(ilan);
            var result = await _context.SaveChangesAsync();
            return istekSonuc > 0 ? result:0;
        }

        public async Task<int> IlanYayinaAl(int IlanId,int IstekId)
        {
            var ilan = await IlanGetir(IlanId);
            ilan.AdminOnayladiMi = true;
            _context.Ilanlar.Update(ilan);
            var result=await _context.SaveChangesAsync();
            await _requestService.IstekOnayla(IstekId,IlanId);
            return result;
        }

        public async Task<List<Ilan>> YayindakiIlanlariGetir()
        {
            return await _context.Ilanlar.Where(i=>i.AdminOnayladiMi == true && i.YayindaMi==true).Include(u=>u.kullanici).Include(u=>u.arac).ThenInclude(u=>u.Marka).Include(u=>u.arac).ThenInclude(u=>u.Model).ToListAsync();
        }

        public async Task<List<Ilan>> KullaniciIlaniGetir(int KullaniciId)
        {
            return await _context.Ilanlar.Where(u=>u.KullaniciId == KullaniciId).Include(u=>u.kullanici).Include(u=>u.Yorumlar).ThenInclude(u=>u.kullanici).Include(u=>u.arac).ThenInclude(u=>u.Marka).Include(u=>u.arac).ThenInclude(u=>u.Model).ToListAsync();
        }

        public async Task<int> KullaniciYayindanIlanKaldir(int IlanId)
        {
            var ilan = await IlanGetir(IlanId);
            ilan.YayindaMi =false;
            _context.Ilanlar.Update(ilan);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> KullaniciIlaniYayinaAl(int IlanId)
        {
            var ilan = await IlanGetir(IlanId);
            ilan.YayindaMi =true;
            _context.Ilanlar.Update(ilan);
            return await _context.SaveChangesAsync();
        }
    }
}