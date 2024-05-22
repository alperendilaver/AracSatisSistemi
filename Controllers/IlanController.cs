using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using yazilim_mimari.Data.Abstract;
using yazilim_mimari.Data.Models;

using yazilim_mimari.Models.Ilan;

namespace yazilim_mimari.Controllers
{
    public class IlanController : Controller
    {
        IGetMarkServie _getMarkServie;
        IIlanService _service;
        IAdminService _adminService;
        public IlanController(IIlanService service, IAdminService adminService,IGetMarkServie getMarkServie)
        {
            _getMarkServie=getMarkServie;
            _adminService = adminService;
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var Markalar = await _getMarkServie.MarkalariGetir();
          
            ViewBag.Markalar = new SelectList(Markalar,nameof(Marka.MarkaId),"MakeName");
            var Modeller = await _getMarkServie.ModelleriGetir();
    
            ViewBag.Modeller = new SelectList(Modeller,nameof(AracModel.ModelId),"ModelAdi");
          
            var ilanlar = await _service.YayindakiIlanlariGetir();
            return View(ilanlar);
        }


        [Authorize]
        public async Task <IActionResult> IlanOlustur(){
            var Markalar = await _getMarkServie.MarkalariGetir();
          
            ViewBag.Markalar = new SelectList(Markalar,"MarkaId","MakeName");
            var Modeller = await _getMarkServie.ModelleriGetir();
    
            ViewBag.Modeller = new SelectList(Modeller,"ModelId","ModelAdi");
            return View();
        }
        [Authorize]
        
        [HttpPost]
        public async Task <IActionResult> IlanOlustur(IlanOlusturViewModel ilanOlusturViewModel){
            if(ModelState.IsValid){
                var result = await _service.IlanOlustur(ilanOlusturViewModel);
                if(result>0){
                    return RedirectToAction("Index","Home");
                }
                ModelState.AddModelError("","İlan Oluşturulamadı");
            }
            return View(ilanOlusturViewModel);
        }

        public async Task<IActionResult> IlanDuzenle(int Id){
            var ilan = await _service.IlanGetir(Id);
            if(String.IsNullOrEmpty(ilan.Baslik)){
                return RedirectToAction("Index","Home");
            }
            var ilanModel = new IlanDuzenleViewModel{
                Fiyat=ilan.Fiyat,
                Resimler=ilan.Resimler,
                IlanId=ilan.IlanId,
                Km=ilan.arac.Km,
                KullaniciId=ilan.KullaniciId,
            };
            return View(ilanModel);
        }
        [HttpPost]
        public async Task<IActionResult> IlanDuzenle(IlanDuzenleViewModel ilanDuzenleViewModel){
            if(ModelState.IsValid){
                var result= await _service.IlanDuzenle(ilanDuzenleViewModel);
                if(result>0){

                    return RedirectToAction("Index","Home");
                }
                ModelState.AddModelError("","İlan Düzenlenemedi");
            }
            return View(ilanDuzenleViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> IlanKaldir(int IlanId){
            var result = await _service.IlanKaldir(IlanId);

            if(result>0){
                return RedirectToAction("Index","Home");
            }
            else{
                return NoContent();
            }
        }

        public async Task<IActionResult> Detay(int Id){
            var ilan = await _service.IlanGetir(Id);
            return View(ilan);
        }

          public async Task<IActionResult> IlaniYayindanKaldir(int Id){
            var result = await _service.KullaniciYayindanIlanKaldir(Id);
            if(result>0){return  RedirectToAction("Profil","Kullanici",new{Id=User.FindFirstValue(ClaimTypes.NameIdentifier)});
            }
            else
                return NotFound();
        }
        public async Task<IActionResult> IlaniYayinla(int Id){
            var result = await _service.KullaniciIlaniYayinaAl(Id);
            if (result>0){
                return  RedirectToAction("Profil","Kullanici",new{Id=User.FindFirstValue(ClaimTypes.NameIdentifier)});
            }
            else
                return NotFound();
        }
    }
}