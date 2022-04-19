using NAGP.Services.OrderAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NAGP.Services.OrderAPI.Repositories
{
    public class OrderRepository
    {
        private List<Order> orders;

        public OrderRepository()
        {
            orders = new List<Order>();
        }

        public List<Order> Orders()
        {
            return orders;
        }

        public Order OrderById(int id)
        {
            return orders.FirstOrDefault(x => x.Id == id);
        }

        public List<Order> ProviderOrders(int providerId)
        {
            return orders.FindAll(x=> x.ProviderId == providerId); 
        }
        public List<Order> CustomerOrders(int customerId)
        {
            return orders.FindAll(x => x.CustomerId == customerId);
        }

    }
}
