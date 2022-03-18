using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MegaKit.WEB.Models.HttpClientFactory.Concrate
{
    public class BaseService
    {
        private readonly static string apiURL = "https://localhost:44378/";

        protected readonly HttpClient _client;

        public BaseService(HttpClient client)
        {
            _client = client;
        }
    }
}
