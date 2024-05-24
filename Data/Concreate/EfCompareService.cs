using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yazilim_mimari.Data.Abstract;
using yazilim_mimari.Data.Models;

namespace yazilim_mimari.Data.Concreate
{
    public class EfCompareService : ICompareService
    {
        private IIlanService _ilanService;
        
        public EfCompareService(IIlanService ilanService)
        {
            _ilanService= ilanService;
        }
        
        public async Task<List<Ilan>> Compare(List<int> ilanlar)
        {
            var ilans = new List<Ilan>();
            
            foreach (var ilan in ilanlar){
                ilans.Add(await _ilanService.IlanGetir(ilan));
            }

            return ilans;
        }
    }
}
