using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdoTrafficMgtCore.Core.Data;
using EdoTrafficMgtWeb.IServices;
using EdoTrafficMgtWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal.UrlActions;

namespace EdoTrafficMgtWeb.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IUserService userService;

        private readonly IUnitOfWork unitOfWork;
        public AuthenticationController(IAuthenticationService authenticationService, IUserService userService, IUnitOfWork unitOfWork)
        {
            this.authenticationService = authenticationService;
            this.userService = userService;
            this.unitOfWork = unitOfWork;
        }
        public IActionResult  Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            var auth = await authenticationService.SignInUserAsync(login.UserName, login.Password, "false");

            if (!auth.Success)
            {
                TempData["ErrorMessage"] = auth.Message;
                return RedirectToAction("Login", "Authentication");
            }
           
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await authenticationService.SignOutUserAsync();
            return RedirectToAction("Login", "Authentication");
        }
    }
}