using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yazilim_mimari.Data.Models;

namespace yazilim_mimari.Data.Abstract
{
    public interface ICompareService
    {
        Task<List<Ilan>> Compare(List<int> ilanlar);
    }
}