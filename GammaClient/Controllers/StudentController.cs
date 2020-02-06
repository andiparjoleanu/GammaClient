using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GammaClient.Services;
using GammaClient.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GammaClient.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentClient _studentClient;
        private readonly MemberClient _memberClient;

        public StudentController(StudentClient studentClient, MemberClient memberClient)
        {
            _studentClient = studentClient;
            _memberClient = memberClient;
        }

        public async Task<IActionResult> Index()
        {
            var member = await _memberClient.GetCurrentClient();
            if (member != null)
            {
                var studentInfo = await _studentClient.GetStudentInfo(member.Id);

                ViewBag.schoolid = studentInfo.SchoolId;
                ViewBag.fieldOfStudy = studentInfo.FieldOfStudy;
                ViewBag.grade = studentInfo.Grade;
                var courses = await _studentClient.GetCourses(member.Id);
                return View(courses);
            }

            return RedirectToAction("Login", "Account");
        }

        public async Task<IActionResult> ShowMarks(string studentid, string courseid)
        {
            List<MarkVM> marks = await _studentClient.GetMarks(studentid, courseid);

            var courses = await _studentClient.GetCourses(studentid);
            var course = courses.FirstOrDefault(c => c.CourseId == courseid);

            var student = await _studentClient.GetStudentInfo(studentid);

            ViewBag.courseid = courseid;
            ViewBag.studentid = studentid;
            ViewBag.courseName = course.Name;
            ViewBag.studentName = student.FirstName + " " + student.LastName;

            return View(marks);
        }
    }
}