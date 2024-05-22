using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yazilim_mimari.Data.Models;
using yazilim_mimari.Models.Istek;

namespace yazilim_mimari.Data.Abstract
{
    public interface IRequestService
    {
        public Task<int> IstekOlustur(int IlanId);
    
        public Task<int> IstekOnayla(int IstekId,int IlanId);

        public Task<int> IstekReddet(int IstekId);
        

        public Task<int> IlanBeklemeyeAl(int IlanId);

        Task<int> IstekSil(int IlanId);//ilan silinince çalışır 
        Task<Istek> IlanaGoreIstekBul(int IlanId);
       
        Task<Istek> IstekGetir(int IstekId);

        Task<List<Istek>> IstekleriListele();
    }
}