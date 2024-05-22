using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yazilim_mimari.Data.Models;

namespace yazilim_mimari.Data.Abstract
{
    public interface IAdminService
    {
        public Task<int> IlanOnayla(int IlanId,int IstekId);
        
        public Task<int> IlanReddet(int IstekId);

        Task<int> MarkaEkle(string MakeName);

        
        Task<int> ModelEkle(int MarkaId,string ModelAdi);
    }
}