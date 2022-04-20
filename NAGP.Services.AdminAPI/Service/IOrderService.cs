using NAGP.Services.AdminAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NAGP.Services.AdminAPI.Service
{
    public interface IOrderService
    {
        Task<List<Order>> GetPendingOrders();
        Task<Order> AssignProviderOnOrder(Order order);
        Task<Order> GetOrderById(int orderId);
    }
}
