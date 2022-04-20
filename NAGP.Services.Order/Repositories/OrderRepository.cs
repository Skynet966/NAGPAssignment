using NAGP.Services.OrderAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NAGP.Services.OrderAPI.Repositories
{
    public class OrderRepository
    {
        private Random random;
        private static List<Order> orders = new List<Order>
        {
            new Order{Id = 1, CustomerId = 1, ServiceId= 1, ProviderId=1, ConfirmStatus = OrderStatusEnum.Accepted},
            new Order{Id = 2, CustomerId = 2, ServiceId= 2, ProviderId=2, ConfirmStatus = OrderStatusEnum.Denied},
            new Order{Id = 3, CustomerId = 3, ServiceId= 3, ProviderId=3, ConfirmStatus = OrderStatusEnum.Pending},
            new Order{Id = 4, CustomerId = 4, ServiceId= 4, ProviderId=4, ConfirmStatus = OrderStatusEnum.Accepted},
        };
        public OrderRepository()
        {
            random = new Random();
        }
        public Order AddOrder(Order order)
        {
            order.Id = random.Next();
            orders.Add(order);
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
            return orders.FindAll(x => x.ProviderId == providerId);
        }
        public Order ProviderOrder(int id, int providerId)
        {
            return orders.FirstOrDefault(x => x.ProviderId == providerId && x.Id == id);
        }
        public List<Order> CustomerOrders(int customerId)
        {
            return orders.FindAll(x => x.CustomerId == customerId);
        }
        public Order CustomerOrder(int id, int customerId)
        {
            return orders.FirstOrDefault(x => x.CustomerId == customerId && x.Id == id);
        }
        public List<Order> PendingOrders()
        {
            return orders.FindAll(x => x.ProviderId == 0);
        }
        public Order UpdateOrder(Order newOrder)
        {
            Order order = orders.FirstOrDefault(x => x.Id == newOrder.Id);
            if (order != null) order = newOrder;
            return order;
        }

        public Order OrderProviderDecision(int id, OrderStatusEnum status)
        {
            Order order = orders.FirstOrDefault(x => x.Id == id);
            order.ConfirmStatus = status;
            return order;
        }


    }
}
