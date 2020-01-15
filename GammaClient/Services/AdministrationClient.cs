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
            return await HttpMethods<ResultVM>.GetAsync(Client, "/removeRole/" + roleid);
        }

        public async Task<ResultVM> CreateRole(RoleVM roleVM)
        {
            return await HttpMethods<RoleVM>.PostAsync(Client, roleVM, "/createRole");
        }

        public async Task<List<IdentityRole>> GetRolesList()
        {
            return await HttpMethods<List<IdentityRole>>.GetAsync(Client, "/getRolesList");
        }

        public async Task<List<EditRoleVM>> GetAllRoles()
        {
            return await HttpMethods<List<EditRoleVM>>.GetAsync(Client, "/getAllRoles");
        }

        public async Task<List<AddUserRoleVM>> GetUsersWithoutRoles(string roleId)
        {
            return await HttpMethods<List<AddUserRoleVM>>.GetAsync(Client, "/getUsersWithoutRole/" + roleId);
        }

        public async Task<ResultVM> SaveUserRoles(UpdateUserRolesVM razorModel)
        {
            return await HttpMethods<UpdateUserRolesVM>.PostAsync(Client, razorModel, "/saveUserRoles");
        }
    }
}
