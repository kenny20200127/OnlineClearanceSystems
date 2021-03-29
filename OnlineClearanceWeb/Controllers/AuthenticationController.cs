using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineClearanceCore.Core.Data;
using OnlineClearanceWeb.IServices;
using OnlineClearanceWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal.UrlActions;
using Microsoft.AspNetCore.Http;

namespace OnlineClearanceWeb.Controllers
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
        public IActionResult StudentLogin()
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
            if (login.type == "Admin")
            {
                return RedirectToAction("Index", "Home");
            }
           // HttpContext.Session.SetString("StudentNumber", login.UserName);
            return RedirectToAction("Index", "Student");


        }

        public async Task<IActionResult> Logout()
        {
            await authenticationService.SignOutUserAsync();
            return RedirectToAction("Login", "Authentication");
        }
    }
}