using Microsoft.AspNetCore.Mvc;
using NAGP.Services.OrderAPI.Entities;
using NAGP.Services.OrderAPI.Repositories;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NAGP.Services.OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public enum OrderDecisionEnum { Denied = -1, Accepted = 2 }
        private readonly OrderRepository orderRepository;
        public OrderController()
        {
            orderRepository = new OrderRepository();
        }
        // GET: api/<OrderController>
        [HttpGet]
        public List<Order> GetOrders()
        {
            return orderRepository.Orders();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public Order GetOrder(int id)
        {
            return orderRepository.OrderById(id);
        }

        // POST api/<OrderController>
        [HttpGet("Status/{id}")]
        public OrderStatusEnum GetOrderStatus(int id)
        {
            return orderRepository.OrderById(id).ConfirmStatus;
        }

        [HttpPost("Create")]
        public Order create([FromBody] Order order)
        {
            return orderRepository.AddOrder(order);
        }

        [HttpGet("Customer/{customerId}")]
        public List<Order> GetCustomerOrders(int customerId)
        {
            return orderRepository.CustomerOrders(customerId);
        }

        [HttpGet("Provider/{providerId}")]
        public List<Order> GetProviderOrders(int providerId)
        {
            return orderRepository.ProviderOrders(providerId);
        }

        [HttpGet("Provider/{providerId}/new")]
        public List<Order> GetProviderNewOrders(int providerId)
        {
            return orderRepository.ProviderNewOrders(providerId);
        }

        [HttpGet("Provider/{id}/{providerId}")]
        public Order GetProviderOrder(int orderId, int providerId)
        {
            // Also need to Provide Customer details 
            return orderRepository.ProviderOrder(orderId, providerId);
        }

        [HttpPost("Provider/{id}")]
        public Order ProviderOrderDecision(int orderId, [FromBody] OrderDecisionEnum decision)
        {
            return orderRepository.OrderProviderDecision(orderId, (OrderStatusEnum)decision);
        }

        [HttpGet("Pending")]
        public List<Order> GetPendingOrders()
        {
            return orderRepository.PendingOrders();
        }

        [HttpPut("Assign")]
        public Order OrdersAssignment([FromBody]Order order)
        {
            return orderRepository.UpdateOrder(order);
        }
    }
}
