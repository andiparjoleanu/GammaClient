using GammaClient.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GammaClient
{
    public static class ServicesExtentionMethods
    {
        public static void ConfigureHttpClients(this IServiceCollection services)
        {
            services.AddHttpClient<AdministrationClient>();
            services.AddHttpClient<MemberClient>();
            services.AddHttpClient<SchoolClient>();
            services.AddHttpClient<TeacherClient>();
        }
    }
}
