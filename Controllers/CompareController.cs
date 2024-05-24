using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using yazilim_mimari.Data.Abstract;

namespace yazilim_mimari.Controllers
{
    public class CompareController : Controller
    {
        private ICompareService _compareService;

        public CompareController(ICompareService compareService)
        {
            _compareService = compareService;
        }

        [HttpPost("Compare")]
        public async Task<IActionResult> Compare([FromBody]string[] Ilanlar)
        {
            List<int> intList= Ilanlar.Select(s=>int.Parse(s)).ToList();
            var ilanlar = await _compareService.Compare(intList);

            return View("_CompareResultPartial",ilanlar);//geri donyste view çalışmıyo ajaxı kontrol et
            
        }

   }
}