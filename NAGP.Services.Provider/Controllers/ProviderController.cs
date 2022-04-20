using Microsoft.AspNetCore.Mvc;
using NAGP.Services.ProviderAPI.Entities;
using NAGP.Services.ProviderAPI.Repositories;
using NAGP.Services.ProviderAPI.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NAGP.Services.ProviderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IServiceService _serviceService;
        private readonly ICustomerService _customerService;
        private readonly ProviderRepository providerRepository;
        public ProviderController(IOrderService orderService, IServiceService serviceService, ICustomerService customerService)
        {
            _orderService = orderService;
            _serviceService = serviceService;
            _customerService = customerService;
            providerRepository = new ProviderRepository();
        }

        // Get all providers
        [HttpGet]
        public List<Provider> GetProviders()
        {
            return providerRepository.Providers();
        }

        // GET Provider with provider Id
        [HttpGet("{id}")]
        public Provider GetProvider(int id)
        {
            return providerRepository.GetProviderById(id);
        }

        // Get Provider based on services and avaibility
        [HttpGet("Service/{serviceId}")]
        public List<Provider> GetAvailableProviders(int serviceId)
        {
            return providerRepository.AvailableProviders(serviceId);
        }

        // Get all provider's service new orders
        [HttpGet("{providerId}/Orders")]
        public async Task<ActionResult<List<Order>>> GetProviderNewOrders(int providerId)
        {
            return await _orderService.GetNewOrders(providerId);
        }

        // Get provider's service all orders
        [HttpGet("{providerId}/AllOrders")]
        public async Task<ActionResult<List<Order>>> GetProviderAllOrders(int providerId)
        {
            return await _orderService.GetAllOrders(providerId);
        }

        // Reply to the service order request
        [HttpPost("{providerId}/Order/{orderId}/{accepted}")]
        public async Task<ActionResult<OrderDetails>> ProviderServiceOrderReply(int providerId, int orderId, bool accepted)
        {
            Order order = await _orderService.GetOrderById(orderId);
            if (order != null && order.ProviderId == providerId)
            {
                order.ConfirmStatus = accepted ? OrderStatusEnum.Accepted : OrderStatusEnum.Denied;
                OrderDetails orderDetails = new OrderDetails() { Id = order.Id, ConfirmStatus = order.ConfirmStatus };
                Customer customer = await _customerService.GetCustomerById(order.CustomerId);
                ServiceEntity service = await _serviceService.GetServiceById(order.ServiceId);
                if (customer != null && accepted)
                {
                    orderDetails.CustomerName= customer.Name;
                    orderDetails.CustomerAddress = customer.Address;
                    orderDetails.CustomerContactNumber = customer.ContactNumber;
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
                return NotFound("Invalid provider or orderId!!");
            }
        }
    }
}
