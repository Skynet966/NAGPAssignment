using NAGP.Services.ProviderAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NAGP.Services.ProviderAPI.Repositories
{
    public class ProviderRepository
    {
        private readonly List<Provider> providers;

        public ProviderRepository()
        {
            providers = new List<Provider>
            {
                new Provider{Id = 1, Name ="sumit", ContactNumber="9871778941", ServiceArea="Gurugram", ServiceId=1},
                new Provider{Id = 2, Name ="amit", ContactNumber="9871778931", ServiceArea="Delhi",ServiceId=2},
                new Provider{Id = 3, Name ="ronit", ContactNumber="9871778942", ServiceArea="Noida",ServiceId=3},
                new Provider{Id = 4, Name ="tina", ContactNumber="9871778932", ServiceArea="Rohtak",ServiceId=4},
            };
        }

        public List<Provider> Providers()
        {
            return providers;
        }
        public List<Provider> AvailableProviders(int serviceId)
        {
            return providers.FindAll(x=> x.IsAvailable && x.ServiceId == serviceId);
        }

        public Provider GetProviderById(int id)
        {
            return providers.FirstOrDefault(x=> x.Id == id);   
        }
    }
}
