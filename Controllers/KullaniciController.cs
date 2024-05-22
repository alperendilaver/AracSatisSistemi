using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using yazilim_mimari.Data.Abstract;
using yazilim_mimari.Models.AracSahip;

namespace yazilim_mimari.Controllers
{
    public class KullaniciController : Controller
    {
        private IIlanService _ilanService;
        private IUserService _userService;
        public KullaniciController(IUserService userService, IIlanService ilanService)
        {
            _ilanService = ilanService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register(){
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel){
            var result = _userService.Register(registerViewModel);
            if(result>0){
                return RedirectToAction("Index","Home");
            }   
            return View(registerViewModel);
        }




        public IActionResult Login(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Login(LoginViewModel loginViewModel){
            var user= await _userService.Login(loginViewModel);
            if(user==null || string.IsNullOrEmpty(user.Ad)){ 
                ModelState.AddModelError("", "Kullanıcı Bulunamadı Tekrar Deneyiniz");
                return View(loginViewModel);
            }
            
            await AddCookie(user.UserId.ToString(),user.Ad,loginViewModel.RememberMe,user.Role,user.Eposta);
            return RedirectToAction("Index","Home");
            
        }

        public async Task<IActionResult> Logout(){
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> Profil(int Id){
            return View(await _ilanService.KullaniciIlaniGetir(Id));
        }
        public async Task AddCookie(string userId,string Ad,bool RememberMe,string Role,string email){
                var userClaims = new List<Claim>();
                userClaims.Add(new Claim(ClaimTypes.NameIdentifier,userId));
                userClaims.Add(new Claim(ClaimTypes.Name,Ad ?? ""));
                userClaims.Add(new Claim(ClaimTypes.Role,Role));
                userClaims.Add(new Claim(ClaimTypes.Email,email));
                var claimsIdentity = new ClaimsIdentity(userClaims,CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties{
                    IsPersistent = RememberMe//kullanıcıyı hatırlama
                };
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity),authProperties);
        }
      

    }
}