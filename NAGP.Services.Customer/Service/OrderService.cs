using Microsoft.Extensions.Configuration;
using NAGP.Services.CustomerAPI.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NAGP.Services.CustomerAPI.Service
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

        public async Task<Order> CreateServiceOrder(CustomerService customerService)
        {
            try
            {
                var result = await httpClient.PostAsJsonAsync<CustomerService>($"{requestURL}/api/order/create", customerService);
                Order order = await result.Content.ReadFromJsonAsync<Order>();
                return order;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Order>> GetCustomerOrders(int customerId)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<List<Order>>($"{requestURL}/api/order/customer/{customerId}");
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
