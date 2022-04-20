using NAGP.Services.CustomerAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NAGP.Services.CustomerAPI.Service
{
    public interface IServiceService
    {
        Task<List<ServiceEntity>> GetAvailableServices();
        Task<ServiceEntity> GetServiceById(int serviceId);
    }
}
