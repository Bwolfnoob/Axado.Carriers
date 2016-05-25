using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Axado.Carriers.Application.Interfaces;
using Axado.Carriers.Application.ViewModels;
using Microsoft.AspNet.Http;

namespace Axado.Carriers.Presentation.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private IUserAppService userService;

        public LoginController(IUserAppService _userService)
        {
            userService = _userService;
        }

        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View(new LoginViewModel());
        }

        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await HttpContext.Authentication.SignOutAsync("Cookies");
            return RedirectToAction(nameof(LoginController.Login), "Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            try
            {
              var loggedUser =   userService.Login(user);
                await HttpContext.Authentication.SignInAsync("Cookies",
                new ClaimsPrincipal(new ClaimsIdentity(new List<Claim> { new Claim("sub", loggedUser.Name), new Claim("id", loggedUser.Id.ToString())}, "local", "sub", "role")));

                return RedirectToLocal(returnUrl);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }

            return View(user);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
