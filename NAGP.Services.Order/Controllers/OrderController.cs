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
        [HttpGet("status/{id}")]
        public OrderStatusEnum GetOrderStatus(int id)
        {
            return orderRepository.OrderById(id).ConfirmStatus;
        }

        // PUT api/<OrderController>/5
        [HttpPut("customer/{id}")]
        public List<Order> GetCustomerOrders(int id)
        {
            return orderRepository.CustomerOrders(id);
        }

        // DELETE api/<OrderController>/5
        [HttpPut("provider/{id}")]
        public List<Order> GetProviderOrders(int id)
        {
            return orderRepository.ProviderOrders(id);
        }
    }
}
