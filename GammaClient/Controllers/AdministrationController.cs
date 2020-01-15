using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GammaClient.Services;
using GammaClient.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GammaClient.Controllers
{
    [Route("[controller]")]
    public class AdministrationController : Controller
    {
        private readonly MemberClient _memberClient;
        private readonly AdministrationClient _administrationClient;

        public AdministrationController(MemberClient memberClient, AdministrationClient administrationClient)
        {
            _memberClient = memberClient;
            _administrationClient = administrationClient;
        }

        [HttpGet("createRole")]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost("createRole")]
        public async Task<IActionResult> CreateRole([FromForm] RoleVM roleVM)
        {
            var result = await _administrationClient.CreateRole(roleVM);
            if(result.Status == Status.Error)
            {
                TempData["CreateRoleErrorMessage"] = result.Message;
                return RedirectToAction("createRole", "Administration");
            }

            return RedirectToAction("showAllRoles", "Administration");
        }

        [HttpGet("showAllRoles")]
        public async Task<IActionResult> ShowAllRoles()
        {
            List<EditRoleVM> result = await _administrationClient.GetAllRoles();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string roleid)
        {
            ViewBag.RoleId = roleid;

            var result = await _administrationClient.GetUsersWithoutRoles(roleid);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(List<AddUserRoleVM> model, string roleid)
        {
            var razorModel = new UpdateUserRolesVM
            {
                RoleId = roleid,
                UserRoles = model
            };

            var result = await _administrationClient.SaveUserRoles(razorModel);

            if(result.Status == Status.Error)
            {
                TempData["updateRolesErrorMessage"] = result.Message;
                return RedirectToAction("EditRole", "Administration", new { roleid });
            }

            return RedirectToAction("ShowAllRoles", "Administration");
        }

        [HttpGet("rmvrole/{roleid}")]
        public async Task<IActionResult> RemoveRole(string roleid)
        {
            await _administrationClient.RemoveRole(roleid);

            return RedirectToAction("ShowAllRoles");
        }
    }
}