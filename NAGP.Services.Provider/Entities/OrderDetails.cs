using System.ComponentModel.DataAnnotations;

namespace NAGP.Services.ProviderAPI.Entities
{
    public class OrderDetails
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ServiceName { get; set; }
        [Required]
        public string ServiceDescription { get; set; }
        [Required]
        public string ServiceCharges { get; set; }
        [Required]
        public OrderStatusEnum ConfirmStatus { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerContactNumber { get; set; }
    }
}
