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
                new Provider{Id = 1, Name ="sumit", Username="sumit@123", Password="sumit@123", ContactNumber="9871778941", ServiceArea="Haryana", ServiceId=1},
                new Provider{Id = 2, Name ="amit", Username="amit@123", Password="amit@123", ContactNumber="9871778931", ServiceArea="Delhi",ServiceId=2},
                new Provider{Id = 3, Name ="ronit", Username="ronit@123", Password="ronit@123", ContactNumber="9871778942", ServiceArea="Haryana",ServiceId=3},
                new Provider{Id = 4, Name ="tina", Username="tina@123", Password="tina@123", ContactNumber="9871778932", ServiceArea="UP",ServiceId=4},
            };
        }

        public List<Provider> Providers()
        {
            return providers;
        }

        public Provider GetProviderById(int id)
        {
            return providers.FirstOrDefault(x=> x.Id == id);   
        }

        public bool IsValidProvider(string username, string password)
        {
            Provider provider = providers.FirstOrDefault(x => x.Username == username && x.Password == password);
            return provider != null;
        }
    }
}
