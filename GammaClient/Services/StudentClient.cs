using GammaClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GammaClient.Services
{
    public class StudentClient
    {
        public HttpClient Client { get; set; }

        public StudentClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44352/api/student");

            Client = client;
        }
        
        public async Task<List<CourseVM>> GetCourses(string studentid)
        {
            try
            {
                List<CourseVM> courses = await HttpMethods<List<CourseVM>>.GetAsync(Client, "/getCourses/" + studentid);
                return courses;
            }
            catch (Exception)
            {
                return new List<CourseVM>();
            }
        }

        public async Task<StudentVM> GetStudentInfo(string studentid)
        {
            try
            {
                StudentVM student = await HttpMethods<StudentVM>.GetAsync(Client, "/getStudentInfo/" + studentid);
                return student;
            }
            catch (Exception)
            {
                return new StudentVM();
            }
        }

        public async Task<List<MarkVM>> GetMarks(string studentid, string courseid)
        {
            try
            {
                List<MarkVM> marks = await HttpMethods<List<MarkVM>>.GetAsync(Client, "/getMarks/" + studentid + "/" + courseid);
                return marks;
            }
            catch (Exception)
            {
                return new List<MarkVM>();
            }
        }
    }
}
