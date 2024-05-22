using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using yazilim_mimari.Data.Abstract;
using yazilim_mimari.Models.Yorum;

namespace yazilim_mimari.Controllers
{
    public class YorumController : Controller
    {
        private ICommentService _commentService;
        public YorumController(ICommentService commentService)
        {
            _commentService=commentService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> YorumEkle(int IlanId,string Yorum,int KullaniciId){
            if(ModelState.IsValid){
                var userName = User.FindFirstValue(ClaimTypes.Name);
                var Tarih =DateTime.Now;
                var result = await _commentService.YorumEkle(new YorumEkleViewModel{KullaniciId=KullaniciId, Yorum=Yorum,IlanId=IlanId});
                if(result>0){
                    return Json(new{
                        userName,        
                        Yorum,
                        Tarih
                    });
                }
                else{
                    return Json(new{});
                }
            }
            else return Json(new{});
        }
   }
}