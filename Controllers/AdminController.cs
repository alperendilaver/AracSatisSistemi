using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using yazilim_mimari.Data.Abstract;
using yazilim_mimari.Data.Context;

namespace yazilim_mimari.Controllers
{
    [Authorize(Policy ="AdminPolicy")]
    public class AdminController : Controller
    {
        private IGetMarkServie _getMarkService;
        private IRequestService _requestService;
        private IAdminService _adminService;
        public AdminController(IAdminService adminService, IRequestService requestService,IGetMarkServie getMark)
        {
            _getMarkService=getMark;
            _requestService = requestService;
            _adminService=adminService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Istekler(){
            
            return View( await _requestService.IstekleriListele());
        }

        [HttpPost]
        public async  Task<IActionResult> IlanOnayla(int IlanId,int IstekId){
            return await _adminService.IlanOnayla(IstekId,IlanId) > 0 ? RedirectToAction("Istekler","Admin"):RedirectToAction("Index","Admin");
        }

        [HttpPost]
        public async Task<IActionResult> IlanReddet(int IstekId){
            return await _adminService.IlanReddet(IstekId) > 0 ? RedirectToAction("Istekler","Admin"):RedirectToAction("Index","Admin");
            
        }

        public IActionResult MarkaEkle(){
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> MarkaEkle(string MakeName)
        {
            if(string.IsNullOrEmpty(MakeName)){
                ModelState.AddModelError("", "Marka Adı Giriniz");
                return View();
            }
            var result = await _adminService.MarkaEkle(MakeName);
            if(result == 0)
                ModelState.AddModelError("","Model Eklenemedi");
            return View();
        }

        public async Task<IActionResult> ModelEkle()
        {
            var Markalar = await _getMarkService.MarkalariGetir();
            ViewBag.Markalar = new SelectList(Markalar,"MarkaId","MakeName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ModelEkle(string ModelAdi,int MarkaId){
            var result = await _adminService.ModelEkle(MarkaId, ModelAdi);
            if(result == 0)
                ModelState.AddModelError("","Model Eklenemedi");
            return RedirectToAction("ModelEkle");
        }
   }
}