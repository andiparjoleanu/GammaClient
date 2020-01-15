using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GammaClient.Models;
using GammaClient.Services;
using Microsoft.AspNetCore.Authorization;
using GammaClient.ViewModels;

namespace GammaClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly MemberClient _memberClient;

        public HomeController(MemberClient memberClient)
        {
            _memberClient = memberClient;
        }

        public async Task<IActionResult> Index()
        {
            var member = await _memberClient.GetCurrentClient();
            if(member != null)
            {
                RoleVM userRole = await _memberClient.GetCurrentClientInfo();
                switch (userRole.RoleName) { 
                    case "Administrator": return RedirectToAction("ShowAllRoles", "Administration");
                    case "Director": return RedirectToAction("Index", "Principal");
                    case "Profesor": return RedirectToAction("Index", "Teacher");
                    default: return View(new IndexVM
                    {
                        Username = member.UserName,
                        Name = member.FirstName + " " + member.LastName,
                        Role = userRole.RoleName
                    });
                }
            }

            return View(new IndexVM
            {
                Role = "guest"
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
