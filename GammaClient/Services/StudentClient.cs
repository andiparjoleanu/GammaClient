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
            client.BaseAddress = new Uri("");

            Client = client;
        }
    }
}
