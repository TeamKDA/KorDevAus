using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using KorDevAus.Models.Api;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace KorDevAus.Services
{
    public class RsvpService : IRsvpService
    {
        private readonly IConfiguration _config;

        public RsvpService(IConfiguration config)
        {
            _config = config;
        }

        private Uri GetBaseAddress() => new Uri(_config.GetValue<string>("ApiBaseUrl"));
        private AuthenticationHeaderValue GetAuthorization() => new AuthenticationHeaderValue("Basic", _config.GetValue<string>("AuthKey"));

        public async Task<List<Rsvp>> GetRsvpByCampaignId(string campaignId)
        {
            List<Rsvp> rsvps = new List<Rsvp>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = GetBaseAddress();
                client.DefaultRequestHeaders.Authorization = GetAuthorization();
                var response = await client.GetAsync($"api/v1/rsvps/{campaignId}");
                if (response.IsSuccessStatusCode)
                {
                    rsvps = await response.Content.ReadAsAsync<List<Rsvp>>();
                }
                return rsvps;
            }
        }

        public async Task<Rsvp> GetRsvpByEmailId(string campaignId, string emailId)
        {
            List<Rsvp> rsvps = new List<Rsvp>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = GetBaseAddress();
                client.DefaultRequestHeaders.Authorization = GetAuthorization();
                var response = await client.GetAsync($"api/v1/rsvps/{campaignId}/{emailId}");
                if (response.IsSuccessStatusCode)
                {
                    rsvps = await response.Content.ReadAsAsync<List<Rsvp>>();
                }
                return rsvps.FirstOrDefault();
            }
        }

        public async Task<bool> Register(string campaignId, string emailId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = GetBaseAddress();
                client.DefaultRequestHeaders.Authorization = GetAuthorization();
                var content = JsonConvert.SerializeObject(new { rsvpYn = true });
                var request = new StringContent(content, Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"api/v1/rsvps/{campaignId}/{emailId}", request);
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> Cancel(string campaignId, string emailId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = GetBaseAddress();
                client.DefaultRequestHeaders.Authorization = GetAuthorization();
                var content = JsonConvert.SerializeObject(new { rsvpYn = false });
                var request = new StringContent(content, Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"api/v1/rsvps/{campaignId}/{emailId}", request);
                return response.IsSuccessStatusCode;
            }
        }
    }
}
