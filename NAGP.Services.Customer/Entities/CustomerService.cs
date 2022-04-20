using System.ComponentModel.DataAnnotations;

namespace NAGP.Services.CustomerAPI.Entities
{
    public class CustomerService
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int ServiceId { get; set; }
    }
}
