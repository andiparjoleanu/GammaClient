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
            return await HttpMethods<List<CourseVM>>.GetAsync(Client, "/getCourses/" + teacherid);
        }


        public async Task<CourseVM> GetCourse(string courseid)
        {
            return await HttpMethods<CourseVM>.GetAsync(Client, "/getCourse/" + courseid);
        }

        public async Task<ResultVM> EditCourse(CourseVM course)
        {
            return await HttpMethods<CourseVM>.PutAsync(Client, course, "/editCourse");
        }

        public async Task<TeacherVM> GetTeacherInfo(string teacherid)
        {
            return await HttpMethods<TeacherVM>.GetAsync(Client, "/getTeacherInfo/" + teacherid);
        }

        public async Task<ResultVM> CreateCourse(CourseVM course)
        {
            return await HttpMethods<CourseVM>.PostAsync(Client, course, "/createCourse");
        }

        public async Task<List<StudentVM>> GetStudents(string courseid)
        {
            return await HttpMethods<List<StudentVM>>.GetAsync(Client, "/getStudents/" + courseid);
        }

        public async Task<List<StudentVM>> GetStudentsToJoinIn(string courseid, string schoolid)
        {
            return await HttpMethods<List<StudentVM>>.GetAsync(Client, "/getStudentsToJoinIn/" + courseid + "/" + schoolid);
        }

        public async Task<ResultVM> SubscribeStudents(SubscribeStudentsVM studentVMs)
        {
            return await HttpMethods<SubscribeStudentsVM>.PostAsync(Client, studentVMs, "/subscribeStudents");
        }

        public async Task<ResultVM> RemoveCourse(string courseid)
        {
            return await HttpMethods<ResultVM>.GetAsync(Client, "/removeCourse/" + courseid);
        }

        public async Task<List<MarkVM>> GetMarks(string studentid, string courseid)
        {
            return await HttpMethods<List<MarkVM>>.GetAsync(Client, "/getMarks/" + studentid + "/" + courseid);
        }

        public async Task<ResultVM> AddMark(MarkVM markVM)
        {
            return await HttpMethods<MarkVM>.PostAsync(Client, markVM, "/addMark");
        }
    }
}
