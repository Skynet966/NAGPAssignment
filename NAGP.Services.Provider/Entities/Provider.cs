using System;
using System.Collections.Generic;

namespace NAGP.Services.ProviderAPI.Entities
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ServiceArea { get; set; }
        public string ContactNumber { get; set; }
        public int ServiceId { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
