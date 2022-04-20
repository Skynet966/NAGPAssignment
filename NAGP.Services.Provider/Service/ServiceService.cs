using Microsoft.Extensions.Configuration;
using NAGP.Services.ProviderAPI.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NAGP.Services.ProviderAPI.Service
{
    public class ServiceService : IServiceService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;
        private readonly string requestURL;
        public ServiceService(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
            requestURL = configuration.GetValue<string>("ServiceAPIURL");
        }

        public async Task<ServiceEntity> GetServiceById(int serviceId)
        {
            return await httpClient.GetFromJsonAsync<ServiceEntity>($"{requestURL}/api/service/{serviceId}");
        }
    }
}
