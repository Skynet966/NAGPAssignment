using Microsoft.Extensions.Configuration;
using NAGP.Services.ProviderAPI.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NAGP.Services.ProviderAPI.Service
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;
        private readonly string requestURL;
        public OrderService(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
            this.requestURL = configuration.GetValue<string>("OrderAPIURL");
        }

        public async Task<List<Order>> GetAllOrders(int providerId)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<List<Order>>($"{requestURL}/api/order/provider/{providerId}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Order>> GetNewOrders(int providerId)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<List<Order>>($"{requestURL}/api/order/provider/{providerId}/new");
            }
            catch
            {
                return null;
            }
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<Order>($"{requestURL}/api/order/{orderId}");
            }
            catch
            {
                return null;
            }
        }
    }
}
