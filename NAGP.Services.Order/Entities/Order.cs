using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NAGP.Services.OrderAPI.Entities
{
    public enum OrderStatusEnum { Accepted, Denied, Pending}
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public int CustomerId  { get; set; }
        public int ProviderId { get; set; }
        public OrderStatusEnum ConfirmStatus { get; set; } = OrderStatusEnum.Pending;
    }
}
