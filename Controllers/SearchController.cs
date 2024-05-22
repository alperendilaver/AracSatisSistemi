using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using yazilim_mimari.Data.Abstract;
using yazilim_mimari.Models.Filter;

namespace yazilim_mimari.Controllers
{
    public class SearchController : Controller
    {
        private IGetMarkServie _getMarkServie;
        private ISearchService _searchService;
        public SearchController(ISearchService searchService,IGetMarkServie getMarkServie)
        {
            _getMarkServie=getMarkServie;
            _searchService  = searchService;
        }
        [HttpPost]
       public async Task<IActionResult> GetFilteredAd(FilterViewModel filterViewModel){

            var FilteredAds = await _searchService.Search(filterViewModel);
            if(FilteredAds == null)
                ModelState.AddModelError("", "Filtrelemeye Uygun İlan Bulunamadı");
              var Markalar = await _getMarkServie.MarkalariGetir();
          
            ViewBag.Markalar = new SelectList(Markalar,"MarkaId","MakeName");
            var Modeller = await _getMarkServie.ModelleriGetir();
    
            ViewBag.Modeller = new SelectList(Modeller,"ModelId","ModelAdi");
          
            return View("~/Views/Ilan/Index.cshtml",FilteredAds);
       } 
                
    }
}