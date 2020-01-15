using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GammaClient.Services
{
    public class MarkClient
    {
        public HttpClient Client { get; set; }

        public MarkClient(HttpClient client)
        {
            client.BaseAddress = new Uri("");

            Client = client;
        }
    }
}
