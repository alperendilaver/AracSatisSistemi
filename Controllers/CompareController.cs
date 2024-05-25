using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using yazilim_mimari.Data.Abstract;
using yazilim_mimari.Models.Ilan;

namespace yazilim_mimari.Controllers
{
    public class CompareController : Controller
    {
        private ICompareService _compareService;

        public CompareController(ICompareService compareService)
        {
            _compareService = compareService;
        }

        [HttpPost]
        public async Task <JsonResult> Compare([FromBody]string[] Ilanlar)
        {   try
    {
        List<int> intList = Ilanlar.Select(s => int.Parse(s)).ToList();
        var ilanlar = await _compareService.Compare(intList);
        var ilanlarDTO =ilanlar.Select(ilan=>new IlanDTO{
            Baslik=ilan.Baslik,
            Fiyat=ilan.Fiyat,
            Km=ilan.arac.Km,
            MakeName=ilan.arac.Marka.MakeName,
            ModelAdi=ilan.arac.Model.ModelAdi,
            YakitTuru=ilan.arac.YakitTuru,
            UretimYili=ilan.arac.UretimYili,
            CamTavan=ilan.arac.CamTavan,  
            KatlanabilirAyna=ilan.arac.KatlanabilirAyna,
            MerkeziKilit=ilan.arac.MerkeziKilit,
            ParkSensoru=ilan.arac.ParkSensoru,
            Sanziman=ilan.arac.Sanziman,
            SisFari=ilan.arac.SisFari,
        }).ToList();
        return Json(ilanlarDTO);
    }
    catch (Exception ex)
    {
        // Hata oluştuğunda loglama veya hata mesajını görüntüleme
        Console.WriteLine("Hata oluştu: " + ex.Message);
        return Json(new { error = ex.Message });
    }
    }

   }
}