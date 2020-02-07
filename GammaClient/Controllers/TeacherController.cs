using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GammaClient.Services;
using GammaClient.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GammaClient.Controllers
{
    [Route("[controller]")]
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
                ViewBag.teacherSchoolId = member.SchoolId;

                var info = await _teacherClient.GetTeacherInfo(member.Id);
                ViewBag.department = info.Department;

                var courses = await _teacherClient.GetCourses(member.Id);
                return View(courses);
            }

            return RedirectToAction("Login", "Account");        
        }

        [HttpGet("editCourse")]
        public async Task<IActionResult> EditCourse(string courseid)
        {
            var course = await _teacherClient.GetCourse(courseid);
            return View(course);
        }

        [HttpPost("editCourse")]
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

        [HttpGet("createCourse")]
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

        [HttpPost("createCourse")]
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

        [HttpGet("showStudents")]
        public async Task<IActionResult> ShowStudents(string courseid)
        {
            ViewBag.courseId = courseid;

            var course = await _teacherClient.GetCourse(courseid);
            ViewBag.courseName = course.Name;

            var students = await _teacherClient.GetStudents(courseid);
            return View(students);
        }

        [HttpGet("subscribeStudents")]
        public async Task<IActionResult> SubscribeStudents(string courseid)
        {
            var member = await _memberClient.GetCurrentClient();
            if (member != null)
            {
                var students = await _teacherClient.GetStudentsToJoinIn(courseid, member.SchoolId);
                
                ViewBag.courseId = courseid;

                var course = await _teacherClient.GetCourse(courseid);
                ViewBag.courseName = course.Name;

                return View(students);
            }

            return RedirectToAction("Login", "Account");
        }

        [HttpPost("subscribeStudents")]
        public async Task<IActionResult> SubscribeStudents([FromForm] List<StudentVM> studentVMs, string courseid)
        {
            SubscribeStudentsVM subscribeStudentsVM = new SubscribeStudentsVM
            {
                Students = studentVMs,
                CourseId = courseid
            };

            var result = await _teacherClient.SubscribeStudents(subscribeStudentsVM);

            if(result.Status == Status.Error)
            {
                ViewData["subscribeStudentsErrorMessage"] = result.Message;
                return RedirectToAction("SubscribeStudents", new { courseid });
            }

            return RedirectToAction("ShowStudents", new { courseid });
        }

        [HttpGet("rmvcourse/{courseid}")]
        public async Task<IActionResult> RemoveCourse(string courseid)
        {
            await _teacherClient.RemoveCourse(courseid);

            return RedirectToAction("Index");
        }

        [HttpGet("ShowMarks/{studentid}/{courseid}")]
        public async Task<IActionResult> ShowMarks(string studentid, string courseid)
        {
            List<MarkVM> marks = await _teacherClient.GetMarks(studentid, courseid);

            var course = await _teacherClient.GetCourse(courseid);

            var students = await _teacherClient.GetStudents(courseid);
            var student = students.FirstOrDefault(s => s.MemberId == studentid);

            ViewBag.courseid = courseid;
            ViewBag.studentid = studentid;
            ViewBag.courseName = course.Name;
            ViewBag.studentName = student.FirstName + " " + student.LastName;

            return View(marks);
        }

        [HttpGet("addMark")]
        public async Task<IActionResult> AddMark(string courseid, string studentid)
        {
            ViewBag.courseid = courseid;
            ViewBag.studentid = studentid;
            
            CourseVM course = await _teacherClient.GetCourse(courseid);
            List<StudentVM> students = await _teacherClient.GetStudents(courseid);
            StudentVM student = students.FirstOrDefault(st => st.MemberId == studentid);

            ViewBag.coursename = course.Name;
            ViewBag.studentname = student.FirstName + " " + student.LastName;

            return View();
        }

        [HttpPost("addMark")]
        public async Task<IActionResult> AddMark([FromForm] MarkVM markVM)
        {
            var result = await _teacherClient.AddMark(markVM);

            if(result.Status == Status.Error)
            {
                ViewData["errorAddMark"] = result.Message;
                return RedirectToAction("AddMark", new { markVM.CourseId, markVM.StudentId });
            }

            return RedirectToAction("ShowMarks", new { markVM.StudentId, markVM.CourseId });
        }

        [HttpGet("ShowLesson")]
        public async Task<IActionResult> ShowLesson(string courseid)
        {
            var course = await _teacherClient.GetCourse(courseid);
            return View(course);
        }

        [HttpPost("ShowLesson")]
        public async Task<IActionResult> ShowLesson([FromForm] CourseVM course)
        {
            var result = await _teacherClient.EditCourse(course);
            if (result.Status == Status.Error)
            {
                TempData["updateCourseErrorMessage"] = result.Message;
                return RedirectToAction("EditCourse", new { courseid = course.CourseId });
            }

            return RedirectToAction("Index", "Teacher");
        }
    }
}