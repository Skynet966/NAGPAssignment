using System.ComponentModel.DataAnnotations;

namespace NAGP.Services.CustomerAPI.Entities
{
    public class Provider
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ContactNumber { get; set; }
    }
}
