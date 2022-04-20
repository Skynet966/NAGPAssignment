using Microsoft.Extensions.Configuration;
using NAGP.Services.ProviderAPI.Entities;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NAGP.Services.ProviderAPI.Service
{
    public class CustomerService: ICustomerService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;
        private readonly string requestURL;
        public CustomerService(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
            this.requestURL = configuration.GetValue<string>("CustomerAPIURL");
        }

        public async Task<Customer> GetCustomerById(int customerId)
        {
            return await httpClient.GetFromJsonAsync<Customer>($"{requestURL}/api/customer/{customerId}");
        }
    }
}
