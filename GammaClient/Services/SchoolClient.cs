using GammaClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GammaClient.Services
{
    public class SchoolClient
    {
        public HttpClient Client { get; set; }

        public SchoolClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44352/api/principal");

            Client = client;
        }

        public async Task<List<SchoolVM>> GetAllSchools()
        {
            return await HttpMethods<List<SchoolVM>>.GetAsync(Client, "/getAllSchools");
        }

        public async Task<ResultVM> AddSchool(SchoolVM newSchool)
        {
            return await HttpMethods<SchoolVM>.PostAsync(Client, newSchool, "/addSchool");
        }

        public async Task<List<TeacherVM>> GetAllTeachers()
        {
            return await HttpMethods<List<TeacherVM>>.GetAsync(Client, "/getAllTeachers");
        }

        public async Task<List<StudentVM>> GetAllStudents()
        {
            return await HttpMethods<List<StudentVM>>.GetAsync(Client, "/getAllStudents");
        }


        public async Task<ResultVM> AddTeachers(List<TeacherVM> selectedTeachers)
        {
            return await HttpMethods<List<TeacherVM>>.PostAsync(Client, selectedTeachers, "/addTeachers");
        }

        public async Task<ResultVM> AddStudents(List<StudentVM> selectedTeachers)
        {
            return await HttpMethods<List<StudentVM>>.PostAsync(Client, selectedTeachers, "/addStudents");
        }

        public async Task<ResultVM> UpdateTeacher(TeacherVM teacherVM)
        {
            return await HttpMethods<TeacherVM>.PutAsync(Client, teacherVM, "/updateTeacher");
        }

        public async Task<ResultVM> UpdateStudent(StudentVM studentVM)
        {
            return await HttpMethods<StudentVM>.PutAsync(Client, studentVM, "/updateStudent");
        }

        public async Task<ResultVM> RemoveTeacher(string teacherid)
        {
            return await HttpMethods<ResultVM>.GetAsync(Client, "/deleteTeacher/" + teacherid);
        }

        public async Task<ResultVM> RemoveStudent(string studentid)
        {
            return await HttpMethods<ResultVM>.GetAsync(Client, "/deleteStudent/" + studentid);
        }
    }
}
