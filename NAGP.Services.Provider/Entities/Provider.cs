using System;
using System.Collections.Generic;

namespace NAGP.Services.ProviderAPI.Entities
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ServiceArea { get; set; }
        public string ContactNumber { get; set; }
        public int ServiceId { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
