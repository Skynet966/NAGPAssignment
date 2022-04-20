using NAGP.Services.ProviderAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NAGP.Services.ProviderAPI.Service
{
    public interface IOrderService
    {
        Task<Order> GetOrderById(int orderId);
        Task<List<Order>> GetNewOrders(int providerId);
        Task<List<Order>> GetAllOrders(int providerId);
    }
}
