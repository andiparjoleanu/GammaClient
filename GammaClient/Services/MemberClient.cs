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
            try 
            {
                RoleVM role = await HttpMethods<RoleVM>.GetAsync(Client, "/currentClientInfo");
                return role;
            }
            catch(Exception)
            {
                return new RoleVM { };
            }
        }

        public async Task<ResultVM> Logout()
        {
            try 
            {
                ResultVM result = await HttpMethods<ResultVM>.GetAsync(Client, "/logout");
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

        public async Task<ResultVM> Login(LoginVM loginVM)
        {
            try 
            {
                ResultVM result = await HttpMethods<LoginVM>.PostAsync(Client, loginVM, "/login");
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

        public async Task<ResultVM> Register(RegisterVM registerVM)
        {
            try 
            {
                ResultVM result =  await HttpMethods<RegisterVM>.PostAsync(Client, registerVM, "/register");
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
