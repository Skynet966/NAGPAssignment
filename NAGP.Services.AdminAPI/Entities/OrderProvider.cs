using System.ComponentModel.DataAnnotations;

namespace NAGP.Services.AdminAPI.Entities
{
    public class OrderProvider
    {
        [Required]
        public int ProviderId { get; set; }
        [Required]
        public int OrderId { get; set; }
        
    }
}
