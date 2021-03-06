﻿using System;
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
        private readonly ITrafficMgtDbContext context;
        private readonly IStudentService studentService;

        private readonly IUnitOfWork unitOfWork;
        public AuthenticationController(IStudentService studentService,ITrafficMgtDbContext context,IAuthenticationService authenticationService, IUserService userService, IUnitOfWork unitOfWork)
        {
            this.authenticationService = authenticationService;
            this.userService = userService;
            this.unitOfWork = unitOfWork;
            this.context = context;
          this.studentService= studentService;
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
            if (login.type == "Admin" && auth.Data.EmailConfirmed == true)
            {
                return RedirectToAction("Index", "Home");
            }
            else if(login.type == "Student" && auth.Data.EmailConfirmed == false)
            {
                var gal = studentService.GetStudentByCode(login.UserName.Trim()).Result;
                var dd = context.Students.Where(s => s.StudentId == login.UserName && s.Status == "Approve").FirstOrDefault();
                if (dd != null)
                {
                    HttpContext.Session.SetString("StudentNumber", login.UserName);
                    return RedirectToAction("StudentsReport", "Student");

                }

                HttpContext.Session.SetString("StudentNumber", login.UserName);
                ViewBag.studentid = login.UserName;
                return RedirectToAction("Index", "Student");
            }
            else
            {
                TempData["ErrorMessage"] = auth.Message;
                ViewBag.message="User Not Found";
                return RedirectToAction("homepage", "Home");
            }

        }

        public async Task<IActionResult> Logout()
        {
            await authenticationService.SignOutUserAsync();
            return RedirectToAction("Login", "Authentication");
        }
    }
}