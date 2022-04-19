using NAGP.Services.OrderAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NAGP.Services.OrderAPI.Repositories
{
    public class OrderRepository
    {
        private List<Order> orders;
        private Random random;

        public OrderRepository()
        {
            orders = new List<Order>
            {
                new Order{Id = 1, CustomerId = 1, ServiceId= 1, ProviderId=1, ConfirmStatus = OrderStatusEnum.Accepted},
                new Order{Id = 2, CustomerId = 2, ServiceId= 2, ProviderId=2, ConfirmStatus = OrderStatusEnum.Denied},
                new Order{Id = 3, CustomerId = 3, ServiceId= 3, ProviderId=3, ConfirmStatus = OrderStatusEnum.Pending},
                new Order{Id = 4, CustomerId = 4, ServiceId= 4, ProviderId=4, ConfirmStatus = OrderStatusEnum.Accepted},
            };
            random = new Random();
        }
        public Order AddOrder(Order order)
        {
            order.Id = random.Next();
            orders.Append<Order>(order);
            return order;
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
