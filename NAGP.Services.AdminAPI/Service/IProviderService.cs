using NAGP.Services.AdminAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NAGP.Services.AdminAPI.Service
{
    public interface IProviderService
    {
        Task<List<Provider>> GetAvailableProivders(int serviceId);
    }
}
