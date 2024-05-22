using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yazilim_mimari.Data.Models;
using yazilim_mimari.Models.Ilan;

namespace yazilim_mimari.Data.Abstract
{
    public interface IIlanService
    {
        Task<int> IlanOlustur(IlanOlusturViewModel model);

        Task<int> IlanDuzenle(IlanDuzenleViewModel ilanDuzenleViewModel);

        Task<int> IlanYayinaAl(int IlanId,int IstekId);

        Task<Ilan> IlanGetir(int IlanId);
        Task<List<Ilan>> KullaniciIlaniGetir(int KullaniciId);
        
        Task<int> IlanKaldir(int IlanId);
    
        Task<List<Ilan>> YayindakiIlanlariGetir();
        
        Task<int> KullaniciYayindanIlanKaldir(int IlanId);

        Task<int> KullaniciIlaniYayinaAl(int IlanId);
    }
}