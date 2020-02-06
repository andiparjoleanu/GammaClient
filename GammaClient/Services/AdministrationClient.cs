using GammaClient.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GammaClient.Services
{
    public class AdministrationClient
    {
        public HttpClient Client { get; set; }

        public AdministrationClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44352/api/administration");

            Client = client;
        }

        public async Task<ResultVM> RemoveRole(string roleid)
        {
            try
            {
                ResultVM result = await HttpMethods<ResultVM>.GetAsync(Client, "/removeRole/" + roleid);
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

        public async Task<ResultVM> CreateRole(RoleVM roleVM)
        {
            try
            {
                ResultVM result = await HttpMethods<RoleVM>.PostAsync(Client, roleVM, "/createRole");
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

        public async Task<List<IdentityRole>> GetRolesList()
        {
            try 
            {
                List<IdentityRole> roles = await HttpMethods<List<IdentityRole>>.GetAsync(Client, "/getRolesList");
                return roles;
            }
            catch (Exception)
            {
                return new List<IdentityRole>();
            }
        }

        public async Task<List<EditRoleVM>> GetAllRoles()
        {
            try
            {
                List<EditRoleVM> roles = await HttpMethods<List<EditRoleVM>>.GetAsync(Client, "/getAllRoles");
                return roles;
            }
            catch (Exception)
            {
                return new List<EditRoleVM>();
            }

        }

        public async Task<List<AddUserRoleVM>> GetUsersWithoutRoles(string roleId)
        {
            try
            {
                List<AddUserRoleVM> model = await HttpMethods<List<AddUserRoleVM>>.GetAsync(Client, "/getUsersWithoutRole/" + roleId);
                return model;
            }
            catch (Exception)
            {
                return new List<AddUserRoleVM>();
            }

        }

        public async Task<ResultVM> SaveUserRoles(UpdateUserRolesVM razorModel)
        {
            try
            {
                ResultVM result = await HttpMethods<UpdateUserRolesVM>.PostAsync(Client, razorModel, "/saveUserRoles");
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
