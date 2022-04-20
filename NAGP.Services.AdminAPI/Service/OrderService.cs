using Microsoft.Extensions.Configuration;
using NAGP.Services.AdminAPI.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NAGP.Services.AdminAPI.Service
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

        public async Task<Order> AssignProviderOnOrder(Order order)
        {
            var result = await httpClient.PutAsJsonAsync<Order>($"{requestURL}/api/order/assign",order);
            if (result.IsSuccessStatusCode)
            {
                return order;
            }
            else
            {
                return null;
            }
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<Order>($"{requestURL}/api/order/{orderId}");
            }catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Order>> GetPendingOrders()
        {
            return await httpClient.GetFromJsonAsync<List<Order>>($"{requestURL}/api/order/pending");
        }
    }
}
