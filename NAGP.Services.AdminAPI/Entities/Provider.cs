using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NAGP.Services.AdminAPI.Entities
{
    public class Provider
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ServiceArea { get; set; }
        public int ServiceId { get; set; }
    }
}
