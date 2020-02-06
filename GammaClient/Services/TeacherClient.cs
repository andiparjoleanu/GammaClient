using GammaClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GammaClient.Services
{
    public class TeacherClient
    {
        public HttpClient Client { get; set; }

        public TeacherClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44352/api/teacher");

            Client = client;
        }

        public async Task<List<CourseVM>> GetCourses(string teacherid)
        {
            try 
            {
                List<CourseVM> courses = await HttpMethods<List<CourseVM>>.GetAsync(Client, "/getCourses/" + teacherid);
                return courses;
            }
            catch(Exception)
            {
                return new List<CourseVM>();
            }
        }


        public async Task<CourseVM> GetCourse(string courseid)
        {

            try
            {
                CourseVM course = await HttpMethods<CourseVM>.GetAsync(Client, "/getCourse/" + courseid);
                return course;
            }
            catch(Exception)
            {
                return new CourseVM { };
            }
        }

        public async Task<ResultVM> EditCourse(CourseVM course)
        {
            try
            {
                ResultVM result = await HttpMethods<CourseVM>.PutAsync(Client, course, "/editCourse");
                return result;
            }
            catch(Exception e)
            {
                return new ResultVM
                {
                    Status = Status.Error,
                    Message = e.Message
                };
            }
        }

        public async Task<TeacherVM> GetTeacherInfo(string teacherid)
        {
            try 
            {
                TeacherVM teacher = await HttpMethods<TeacherVM>.GetAsync(Client, "/getTeacherInfo/" + teacherid);
                return teacher;
            }
            catch(Exception)
            {
                return new TeacherVM { };
            }
        }


        public async Task<ResultVM> CreateCourse(CourseVM course)
        {
            try
            {
                ResultVM result = await HttpMethods<CourseVM>.PostAsync(Client, course, "/createCourse");
                return result;
            }
            catch(Exception e)
            {
                return new ResultVM
                {
                    Status = Status.Error,
                    Message = e.Message
                };
            }
        }

        public async Task<List<StudentVM>> GetStudents(string courseid)
        {
            try 
            {
                List<StudentVM> students = await HttpMethods<List<StudentVM>>.GetAsync(Client, "/getStudents/" + courseid);
                return students;
            }
            catch(Exception)
            {
                return new List<StudentVM>();
            }
        }


        public async Task<List<StudentVM>> GetStudentsToJoinIn(string courseid, string schoolid)
        {
            try 
            {
                List<StudentVM> students = await HttpMethods<List<StudentVM>>.GetAsync(Client, "/getStudentsToJoinIn/" + courseid + "/" + schoolid);
                return students;
            }
            catch(Exception)
            {
                return new List<StudentVM>();
            }
        }

        public async Task<ResultVM> SubscribeStudents(SubscribeStudentsVM studentVMs)
        {
            try
            {
                ResultVM model = await HttpMethods<SubscribeStudentsVM>.PostAsync(Client, studentVMs, "/subscribeStudents");
                return model;
            }
            catch(Exception e)
            {
                return new ResultVM
                {
                    Status = Status.Error,
                    Message = e.Message
                };
            }
        }

        public async Task<ResultVM> RemoveCourse(string courseid)
        {
            try
            {
                ResultVM result = await HttpMethods<ResultVM>.GetAsync(Client, "/removeCourse/" + courseid);
                return result;
            }
            catch(Exception e)
            {
                return new ResultVM
                {
                    Status = Status.Error,
                    Message = e.Message
                };
            }
        }

        public async Task<List<MarkVM>> GetMarks(string studentid, string courseid)
        {
            try 
            {
                List<MarkVM> marks = await HttpMethods<List<MarkVM>>.GetAsync(Client, "/getMarks/" + studentid + "/" + courseid);
                return marks;    
            }
            catch(Exception)
            {
                return new List<MarkVM>();
            }
        }

        public async Task<ResultVM> AddMark(MarkVM markVM)
        {
            try
            {
                ResultVM result = await HttpMethods<MarkVM>.PostAsync(Client, markVM, "/addMark");
                return result;
            }
            catch(Exception e)
            {
                return new ResultVM
                {
                    Status = Status.Error,
                    Message = e.Message
                };
            }
        }
    }
}
