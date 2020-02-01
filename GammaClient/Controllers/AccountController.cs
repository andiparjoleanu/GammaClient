using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GammaClient.Services;
using GammaClient.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GammaClient.Controllers
{
    public class AccountController : Controller
    {
        private readonly MemberClient _memberClient;

        public AccountController(MemberClient memberClient)
        {
            _memberClient = memberClient;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _memberClient.Logout();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginVM loginVM)
        {
            var result = await _memberClient.Login(loginVM);
            if(result.Status == Status.Error)
            {
                TempData["TrySignInErrorMessage"] = result.Message;
                return RedirectToAction("Login");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterVM registerVM)
        {
            var result = await _memberClient.Register(registerVM);

            if (result.Status == Status.Error)
            {
                TempData["RegisterErrorMessage"] = result.Message;
                return RedirectToAction("Register");
            }

            return RedirectToAction("Index", "Home");
        }

    }
}