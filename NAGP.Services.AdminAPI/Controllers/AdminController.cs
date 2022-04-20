using Microsoft.AspNetCore.Mvc;
using NAGP.Services.AdminAPI.Entities;
using NAGP.Services.AdminAPI.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NAGP.Services.AdminAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IProviderService _providerService;
        public AdminController(IOrderService orderService, IProviderService providerService)
        {
            _orderService = orderService;
            _providerService = providerService;
        }

        [HttpGet("Orders")]
        public async Task<ActionResult<List<Order>>> GetPendingOrders()
        {
            var orders = await _orderService.GetPendingOrders();
            if (orders.Count > 0)
            {
                return Ok(orders);
            }
            return NotFound("No pending order present yet!");
        }
        [HttpGet("Providers/service/{serviceId}")]
        public async Task<ActionResult<List<Provider>>> GetAvailableServiceProviders(int serviceId)
        {
            var providers = await _providerService.GetAvailableProivders(serviceId);
            if (providers.Count > 0)
            {
                return Ok(providers);
            }
            return NotFound("No service provider available yet!");
        }
        [HttpPost("Provider")]
        public async Task<ActionResult<Order>> AssignServiceProviders([FromBody] OrderProvider orderProvider)
        {
            Order order = await _orderService.GetOrderById(orderProvider.OrderId);
            Provider provider = await _providerService.GetProviderById(orderProvider.ProviderId);
            if (order != null && provider != null && order.ServiceId == provider.ServiceId)
            {
                order.ProviderId = orderProvider.ProviderId;
                order.ConfirmStatus = OrderStatusEnum.Assigned;
                var updatedOrder = await _orderService.AssignProviderOnOrder(order);
                if (updatedOrder != null)
                {
                    return Ok(updatedOrder);
                }
            }
            else
            {
                return NotFound("Invalid Order or Provider Id else Incompatable service provider!!");
            }
            return BadRequest("Service provider not able to assigned!");
        }
    }
}
