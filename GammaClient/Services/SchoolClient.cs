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
            try
            {
                List<SchoolVM> schools = await HttpMethods<List<SchoolVM>>.GetAsync(Client, "/getAllSchools");
                return schools;
            }
            catch(Exception)
            {
                return new List<SchoolVM>();
            }
        }

        public async Task<ResultVM> AddSchool(SchoolVM newSchool)
        {
            try
            {
                ResultVM result = await HttpMethods<SchoolVM>.PostAsync(Client, newSchool, "/addSchool");
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

        public async Task<List<TeacherVM>> GetAllTeachers()
        {
            try
            {
                List<TeacherVM> teachers = await HttpMethods<List<TeacherVM>>.GetAsync(Client, "/getAllTeachers");
                return teachers;
            }
            catch(Exception)
            {
                return new List<TeacherVM>();
            }
        }

        public async Task<List<StudentVM>> GetAllStudents()
        {
            try
            {
                List<StudentVM> students = await HttpMethods<List<StudentVM>>.GetAsync(Client, "/getAllStudents");
                return students;
            }
            catch(Exception)
            {
                return new List<StudentVM>();
            }
        }


        public async Task<ResultVM> AddTeachers(List<TeacherVM> selectedTeachers)
        {
            try
            {
                ResultVM result = await HttpMethods<List<TeacherVM>>.PostAsync(Client, selectedTeachers, "/addTeachers");
                return result;
            }
            catch(Exception e)
            {
                return new ResultVM
                {
                    Message = e.Message,
                    Status = Status.Error
                };
            }
        }

        public async Task<ResultVM> AddStudents(List<StudentVM> selectedTeachers)
        {
            try
            {
                ResultVM result = await HttpMethods<List<StudentVM>>.PostAsync(Client, selectedTeachers, "/addStudents");
                return result;
            }
            catch(Exception e)
            {
                return new ResultVM
                {
                    Message = e.Message,
                    Status = Status.Error
                };
            }
        }

        public async Task<ResultVM> UpdateTeacher(TeacherVM teacherVM)
        {
            try
            {
                ResultVM resultVM = await HttpMethods<TeacherVM>.PutAsync(Client, teacherVM, "/updateTeacher");
                return resultVM;
            }
            catch(Exception e)
            {
                return new ResultVM
                {
                    Message = e.Message,
                    Status = Status.Error
                };
            }

        }

        public async Task<ResultVM> UpdateStudent(StudentVM studentVM)
        {
            try
            {
                ResultVM result = await HttpMethods<StudentVM>.PutAsync(Client, studentVM, "/updateStudent");
                return result;
            }
            catch(Exception e)
            {
                return new ResultVM
                {
                    Message = e.Message,
                    Status = Status.Error
                };
            }

        }

        public async Task<ResultVM> RemoveTeacher(string teacherid)
        {
            try 
            {
                ResultVM result = await HttpMethods<ResultVM>.GetAsync(Client, "/deleteTeacher/" + teacherid);
                return result;
            }
            catch (Exception e)
            {
                return new ResultVM
                {
                    Message = e.Message,
                    Status = Status.Error
                };
            }
        }

        public async Task<ResultVM> RemoveStudent(string studentid)
        {
            try
            {
                ResultVM result = await HttpMethods<ResultVM>.GetAsync(Client, "/deleteStudent/" + studentid);
                return result;
            }
            catch (Exception e)
            {
                return new ResultVM
                {
                    Message = e.Message,
                    Status = Status.Error
                };
            }

        }
    }
}
