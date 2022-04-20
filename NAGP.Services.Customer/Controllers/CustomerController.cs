using Microsoft.AspNetCore.Mvc;
using NAGP.Services.CustomerAPI.Entities;
using NAGP.Services.CustomerAPI.Repositories;
using NAGP.Services.CustomerAPI.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NAGP.Services.CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IServiceService _serviceService;
        private readonly IProviderService _providerService;
        private readonly CustomerRepository customerRepository;
        public CustomerController(IOrderService orderService, IProviderService providerService, IServiceService serviceService)
        {
            _orderService = orderService;
            _providerService = providerService;
            _serviceService = serviceService;
            customerRepository = new CustomerRepository();
        }

        // Get all customers
        [HttpGet()]
        public async Task<ActionResult<List<Customer>>> GetCustomers()
        {
            return Ok(await customerRepository.Customers());
        }

        // Get customer with Id
        [HttpGet("{id}")]
        public Customer GetCustomer(int id)
        {
            return customerRepository.GetCustomerById(id);
        }

        // Get all services
        [HttpGet("Services")]
        public async Task<ActionResult<List<ServiceEntity>>> GetServices()
        {
            return await _serviceService.GetAvailableServices();
        }

        // Place an new service order
        [HttpPost("Order")]
        public async Task<ActionResult<Order>> PlaceOrder([FromBody] CustomerService customerService)
        {
            return await _orderService.CreateServiceOrder(customerService);
        }

        // Get customer order services history
        [HttpGet("{customerId}/Orders")]
        public async Task<ActionResult<List<Order>>> GetOrderHistory(int customerId)
        {
            return await _orderService.GetCustomerOrders(customerId);
        }

        // Get customer order services detailed status
        [HttpGet("{customerId}/OrderStatus/{orderId}")]
        public async Task<ActionResult<OrderDetails>> GetCustomerOrderStatus(int customerId, int orderId)
        {
            Order order = await _orderService.GetOrderById(orderId);
            if (order != null && order.CustomerId == customerId)
            {
                OrderDetails orderDetails = new OrderDetails() { Id = order.Id, ConfirmStatus = order.ConfirmStatus };
                Provider provider = await _providerService.GetProviderById(order.ProviderId);
                ServiceEntity service = await _serviceService.GetServiceById(order.ServiceId);
                if (provider != null)
                {
                    orderDetails.ProviderName = provider.Name;
                    orderDetails.ProviderContactNumber = provider.ContactNumber;
                }
                if (service != null)
                {
                    orderDetails.ServiceName = service.Name;
                    orderDetails.ServiceDescription = service.Description;
                    orderDetails.ServiceCharges = service.Charges;
                }
                return orderDetails;
            }
            else
            {
                return NotFound("Invalid customerId or orderId!!");
            }
        }
    }
}
