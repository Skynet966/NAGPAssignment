using Microsoft.Extensions.Configuration;
using NAGP.Services.AdminAPI.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NAGP.Services.AdminAPI.Service
{
    public class ProviderService: IProviderService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;
        public ProviderService(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
        }
        public async Task<List<Provider>> GetAvailableProivders(int serviceId)
        {
            var requestURL = configuration.GetValue<string>("ProviderAPIURL");

            return await httpClient.GetFromJsonAsync<List<Provider>>($"{requestURL}/api/provider/available/{serviceId}");
        }
    }
}
