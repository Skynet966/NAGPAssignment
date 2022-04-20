using NAGP.Services.CustomerAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NAGP.Services.CustomerAPI.Service
{
    public interface IOrderService
    {
        Task<Order> GetOrderById(int orderId);
        Task<List<Order>> GetCustomerOrders(int customerId);
        Task<Order> CreateServiceOrder(CustomerService customerService);
    }
}
