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

        public async Task<ResultVM> CreateCourse(CourseVM course)
        {
            return await HttpMethods<CourseVM>.PostAsync(Client, course, "/createCourse");
        }
    }
}
