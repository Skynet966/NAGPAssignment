using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NAGP.Services.ServiceAPI.Entities
{
    public class Service
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Charges { get; set; }
    }
}
