using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yazilim_mimari.Data.Models;

namespace yazilim_mimari.Data.Abstract
{
    public interface IGorselService
    {
        public Task<List<string>> GorselEkle(IFormFileCollection gorseller);

        public void EskiGorselleriSil(Ilan ilan);
    }
}