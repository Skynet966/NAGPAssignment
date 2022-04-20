using System.ComponentModel.DataAnnotations;

namespace NAGP.Services.ProviderAPI.Entities
{
    public class ServiceEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Charges { get; set; }
    }
}
