using Microsoft.Extensions.Configuration;
using NAGP.Services.CustomerAPI.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NAGP.Services.CustomerAPI.Service
{
    public class ProviderService: IProviderService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;
        private readonly string requestURL;
        public ProviderService(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
            this.requestURL = configuration.GetValue<string>("ProviderAPIURL");
        }
        public async Task<List<Provider>> GetAvailableProivders(int serviceId)
        {
            return await httpClient.GetFromJsonAsync<List<Provider>>($"{requestURL}/api/provider/service/{serviceId}");
        }

        public async Task<Provider> GetProviderById(int providerId)
        {
            return await httpClient.GetFromJsonAsync<Provider>($"{requestURL}/api/provider/{providerId}");
        }
    }
}
