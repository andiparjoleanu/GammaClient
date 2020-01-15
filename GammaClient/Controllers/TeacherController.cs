using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GammaClient.Services;
using GammaClient.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GammaClient.Controllers
{
    public class TeacherController : Controller
    {
        private readonly MemberClient _memberClient;
        private readonly TeacherClient _teacherClient;

        public TeacherController(MemberClient memberClient, TeacherClient teacherClient)
        {
            _memberClient = memberClient;
            _teacherClient = teacherClient;
        }

        public async Task<IActionResult> Index()
        {
            var member = await _memberClient.GetCurrentClient();
            if (member != null)
            {
                var courses = await _teacherClient.GetCourses(member.Id);
                return View(courses);
            }

            return RedirectToAction("Login", "Account");        
        }

        [HttpGet]
        public async Task<IActionResult> EditCourse(string courseid)
        {
            var course = await _teacherClient.GetCourse(courseid);
            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> EditCourse([FromForm] CourseVM course)
        {
            var result = await _teacherClient.EditCourse(course);
            if(result.Status == Status.Error)
            {
                TempData["updateCourseErrorMessage"] = result.Message;
                return RedirectToAction("EditCourse", new { courseid = course.CourseId });
            }

            return RedirectToAction("Index", "Teacher");
        }

        [HttpGet]
        public async Task<IActionResult> CreateCourse()
        {
            var member = await _memberClient.GetCurrentClient();
            if(member != null)
            {
                ViewBag.teacherId = member.Id;
                return View();
            }

            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromForm] CourseVM course)
        {
            var result = await _teacherClient.CreateCourse(course);

            if(result.Status == Status.Error)
            {
                TempData["createCourseErrorMessage"] = result.Message;
                return RedirectToAction("CreateCourse");
            }

            return RedirectToAction("Index");
        }
    }
}