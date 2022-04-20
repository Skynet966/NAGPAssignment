using System.ComponentModel.DataAnnotations;

namespace NAGP.Services.OrderAPI.Entities
{
    public class Auth
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
