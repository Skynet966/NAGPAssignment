using NAGP.Services.ServiceAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NAGP.Services.ServiceAPI.Repositories
{
    public class ServiceRepository
    {
        private List<Service> services;

        public ServiceRepository()
        {
            services = new List<Service>
            {
                new Service { Id = 1, Name = "electrician", Description = "Provide all the electrical related services.", Charges="1000" },
                new Service { Id = 2, Name = "yoga trainer", Description = "Provide yoga trainnings", Charges="1500" },
                new Service { Id = 3, Name = "barber", Description = "Provide Hair cutting services.", Charges="600"  },
                new Service { Id = 4, Name = "car washer", Description = "Provide car washing services at your home.", Charges="500"  },
                new Service { Id = 5, Name = "house cleaner", Description = "Clean up your house and make it shine.", Charges="700"  }
            };
        }

        public List<Service> GetServices()
        {
            return services;
        }

        public Service GetServiceById(int id)
        {
            return services.FirstOrDefault(x => x.Id == id);
        }

    }
}
