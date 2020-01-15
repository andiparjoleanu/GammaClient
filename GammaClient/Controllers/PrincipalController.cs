using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GammaClient.Services;
using GammaClient.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GammaClient.Controllers
{
    public class PrincipalController : Controller
    {
        private readonly SchoolClient _schoolClient;

        public PrincipalController(SchoolClient schoolClient)
        {
            _schoolClient = schoolClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SendSearchValue(string value)
        {
            var schools = await _schoolClient.GetAllSchools();
            List<SchoolVM> schoolsbyFilter = new List<SchoolVM>();
            foreach (var school in schools)
            {
                if (school.Name.ToLower().Contains(value.ToLower()))
                {
                    schoolsbyFilter.Add(school);
                }
            }

            return PartialView(schoolsbyFilter);
        }

        [HttpGet]
        public async Task<IActionResult> SchoolDetails(string id)
        {
            var schools = await _schoolClient.GetAllSchools();
            SchoolVM school = schools.SingleOrDefault(s => s.Id == id);
            return PartialView(school);

        }

        [HttpGet]
        public IActionResult AddSchool()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSchool([FromForm] SchoolVM newSchool)
        {
            var result = await _schoolClient.AddSchool(newSchool);
            if (result.Status == Status.Error)
            {
                TempData["addSchoolErrorMessage"] = result.Message;
                return RedirectToAction("AddSchool");
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> ShowTeachers(string schoolid)
        {
            var teachers = await _schoolClient.GetAllTeachers();

            var schoolTeachers = teachers.Where(t => t.SchoolId == schoolid);

            var schools = await _schoolClient.GetAllSchools();
            var school = schools.FirstOrDefault(s => s.Id == schoolid);

            ViewBag.showTeachersSchool = school.Name;
            ViewBag.schoolId = schoolid;
            return View(schoolTeachers);
        }

        public async Task<IActionResult> ShowStudents(string schoolid)
        {
            var students = await _schoolClient.GetAllStudents();

            var schoolStudents = students.Where(s => s.SchoolId == schoolid);

            var schools = await _schoolClient.GetAllSchools();
            var school = schools.FirstOrDefault(s => s.Id == schoolid);

            ViewBag.showStudentsSchool = school.Name;
            ViewBag.schoolId = schoolid;
            return View(schoolStudents);
        }

        [HttpGet]
        public async Task<IActionResult> AddTeachers(string schoolid)
        {
            var teachers = await _schoolClient.GetAllTeachers();

            List<TeacherVM> teachersWithoutSchool = new List<TeacherVM>();
            foreach (var teacher in teachers)
            {
                if (teacher.SchoolId == null)
                {
                    teachersWithoutSchool.Add(new TeacherVM
                    {
                        MemberId = teacher.MemberId,
                        FirstName = teacher.FirstName,
                        LastName = teacher.LastName
                    });
                }
            }

            var schools = await _schoolClient.GetAllSchools();
            var school = schools.FirstOrDefault(s => s.Id == schoolid);

            ViewBag.showTeachersSchool = school.Name;
            ViewBag.schoolId = schoolid;
            return View(teachersWithoutSchool);
        }

        [HttpPost]
        public async Task<IActionResult> AddTeachers(List<TeacherVM> model, string schoolId)
        {
            List<TeacherVM> selectedTeachers = new List<TeacherVM>();

            foreach(var teacher in model)
            {
                if (teacher.IsSelected)
                {
                    teacher.SchoolId = schoolId;
                    selectedTeachers.Add(teacher);
                }
            }

            var result = await _schoolClient.AddTeachers(selectedTeachers);

            if(result.Status == Status.Error)
            {
                TempData["addTeachersErrorMessage"] = result.Message;
                return RedirectToAction("AddTeachers", new { schoolId });
            }

            return RedirectToAction("ShowTeachers", new { schoolId });
        }

        [HttpGet]
        public async Task<IActionResult> AddStudents(string schoolid)
        {
            var students = await _schoolClient.GetAllStudents();

            List<StudentVM> studentsWithoutSchool = new List<StudentVM>();
            foreach (var student in students)
            {
                if (student.SchoolId == null)
                {
                    studentsWithoutSchool.Add(new StudentVM
                    {
                        MemberId = student.MemberId,
                        FirstName = student.FirstName,
                        LastName = student.LastName
                    });
                }
            }

            var schools = await _schoolClient.GetAllSchools();
            var school = schools.FirstOrDefault(s => s.Id == schoolid);

            ViewBag.showStudentsSchool = school.Name;
            ViewBag.schoolId = schoolid;
            return View(studentsWithoutSchool);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudents(List<StudentVM> model, string schoolId)
        {
            List<StudentVM> selectedStudents = new List<StudentVM>();

            foreach (var student in model)
            {
                if (student.IsSelected)
                {
                    student.SchoolId = schoolId;
                    selectedStudents.Add(student);
                }
            }

            var result = await _schoolClient.AddStudents(selectedStudents);

            if (result.Status == Status.Error)
            {
                TempData["addStudentsErrorMessage"] = result.Message;
                return RedirectToAction("AddStudents", new { schoolId });
            }

            return RedirectToAction("ShowStudents", new { schoolId });
        }
    
        [HttpGet]
        public async Task<IActionResult> EditTeacher(string teacherid, string schoolid)
        {
            var teachers = await _schoolClient.GetAllTeachers();
            var selectedTeacher = teachers.FirstOrDefault(t => t.MemberId == teacherid);
        
            if(selectedTeacher != null)
            {
                List<SchoolVM> schools = await _schoolClient.GetAllSchools();
                var school = schools.FirstOrDefault(s => s.Id == schoolid);
                ViewBag.showTeachersSchool = school.Name;
                return View(selectedTeacher);
            }

            return RedirectToAction("ShowTeachers", new { schoolid });
        }

        [HttpPost]
        public async Task<IActionResult> EditTeacher(TeacherVM teacherVM)
        {
            var result = await _schoolClient.UpdateTeacher(teacherVM);

            if(result.Status == Status.Error)
            {
                ViewBag["updateTeacherErrorMessage"] = result.Message;
                return RedirectToAction("EditTeacher", new { teacherid = teacherVM.MemberId, schoolid = teacherVM.SchoolId });
            }

            return RedirectToAction("ShowTeachers", new { schoolid = teacherVM.SchoolId });
        }

        [HttpGet]
        public async Task<IActionResult> RemoveTeacher(string teacherid, string school)
        {
            var result = await _schoolClient.RemoveTeacher(teacherid);

            if (result.Status == Status.Error)
            {
                ViewData["removeTeacherErrorMessage"] = result.Message;
            }
            
            return RedirectToAction("ShowTeachers", new { schoolid = school });
        }

        [HttpGet]
        public async Task<IActionResult> EditStudent(string studentid, string schoolid)
        {
            var students = await _schoolClient.GetAllStudents();
            var selectedStudent = students.FirstOrDefault(t => t.MemberId == studentid);

            if (selectedStudent != null)
            {
                List<SchoolVM> schools = await _schoolClient.GetAllSchools();
                var school = schools.FirstOrDefault(s => s.Id == schoolid);
                ViewBag.showTeachersSchool = school.Name;
                return View(selectedStudent);
            }

            return RedirectToAction("ShowStudents", new { schoolid });
        }

        [HttpPost]
        public async Task<IActionResult> EditStudent(StudentVM studentVM)
        {
            var result = await _schoolClient.UpdateStudent(studentVM);

            if (result.Status == Status.Error)
            {
                ViewBag["updateStudentErrorMessage"] = result.Message;
                return RedirectToAction("EditStudent", new { studentid = studentVM.MemberId, schoolid = studentVM.SchoolId });
            }

            return RedirectToAction("ShowStudents", new { schoolid = studentVM.SchoolId });
        }

        [HttpGet]
        public async Task<IActionResult> RemoveStudent(string studentid, string school)
        {
            var result = await _schoolClient.RemoveStudent(studentid);

            if (result.Status == Status.Error)
            {
                ViewData["removeStudentErrorMessage"] = result.Message;
            }

            return RedirectToAction("ShowStudents", new { schoolid = school });
        }
    }
}