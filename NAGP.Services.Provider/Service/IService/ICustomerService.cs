using NAGP.Services.ProviderAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NAGP.Services.ProviderAPI.Service
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerById(int customerId);
    }
}
