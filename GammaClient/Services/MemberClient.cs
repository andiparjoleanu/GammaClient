using GammaClient.Models;
using GammaClient.ViewModels;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GammaClient.Services
{
    public class MemberClient
    {
        public HttpClient Client { get; set; }

        public MemberClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44352/api/member");

            Client = client;
        }

        public async Task<Member> GetCurrentClient()
        {
            return await HttpMethods<Member>.GetAsync(Client, "/currentClient");
        }

        public async Task<RoleVM> GetCurrentClientInfo()
        {
            return await HttpMethods<RoleVM>.GetAsync(Client, "/currentClientInfo");
        }

        public async Task<ResultVM> Logout()
        {
            return await HttpMethods<ResultVM>.GetAsync(Client, "/logout");
        }

        public async Task<ResultVM> Login(LoginVM loginVM)
        {
            return await HttpMethods<LoginVM>.PostAsync(Client, loginVM, "/login");
        }

        public async Task<ResultVM> Register(RegisterVM registerVM)
        {
            return await HttpMethods<RegisterVM>.PostAsync(Client, registerVM, "/register");
        }
    }
}
