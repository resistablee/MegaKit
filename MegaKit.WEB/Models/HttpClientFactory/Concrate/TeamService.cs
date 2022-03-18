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
    public class TeamService : BaseService, ITeamService
    {
        protected readonly HttpClient _client;

        public TeamService(HttpClient client) : base(client)
        {
            _client = client;
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<ReturnValue<IList<Team>>> GetTeam()
        {
            HttpResponseMessage response = null;
            ReturnValue<IList<Team>> DataList = null;

            try
            {
                response = await _client.GetAsync("api/Team/List");
            }
            catch (Exception ex)
            {
                var asd = response.Content.ReadAsStringAsync().Result;
            }

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var jsonData = response.Content.ReadAsStringAsync().Result;
                DataList = JsonConvert.DeserializeObject<ReturnValue<IList<Team>>>(jsonData);

                return DataList;
            }

            return DataList;
        }

        public async Task<ReturnValue<IList<Contact>>> GetContact()
        {
            HttpResponseMessage response = null;
            ReturnValue<IList<Contact>> DataList = null;

            try
            {
                response = await _client.GetAsync("api/Team/Contact");
            }
            catch (Exception ex)
            {
                var asd = response.Content.ReadAsStringAsync().Result;
            }

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var jsonData = response.Content.ReadAsStringAsync().Result;
                DataList = JsonConvert.DeserializeObject<ReturnValue<IList<Contact>>>(jsonData);

                return DataList;
            }

            return DataList;
        }
    }
}
