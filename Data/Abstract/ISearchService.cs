using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yazilim_mimari.Data.Models;
using yazilim_mimari.Models.Filter;

namespace yazilim_mimari.Data.Abstract
{
    public interface ISearchService
    {

       Task<List<Ilan>> Search(FilterViewModel filterViewModel);
    }
}