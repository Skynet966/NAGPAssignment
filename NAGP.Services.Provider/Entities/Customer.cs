using System.ComponentModel.DataAnnotations;

namespace NAGP.Services.ProviderAPI.Entities
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string ContactNumber { get; set; }

    }
}
