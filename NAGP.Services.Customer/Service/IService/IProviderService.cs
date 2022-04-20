using NAGP.Services.CustomerAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NAGP.Services.CustomerAPI.Service
{
    public interface IProviderService
    {
        Task<List<Provider>> GetAvailableProivders(int serviceId);
        Task<Provider> GetProviderById(int providerId);
    }
}
