using MegaKit.EL;
using MegaKit.EL.DBMegaKit.Entites;
using MegaKit.WEB.Models.HttpClientFactory.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MegaKit.WEB.Models.HttpClientFactory.Concrate
{
    public class AboutService : BaseService, IAboutService
    {
        protected readonly HttpClient _client;

        public AboutService(HttpClient client) : base(client)
        {
            _client = client;
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
        }
    }
}
