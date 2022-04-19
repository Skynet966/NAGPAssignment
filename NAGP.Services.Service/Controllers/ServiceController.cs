using Microsoft.AspNetCore.Mvc;
using NAGP.Services.ServiceAPI.Entities;
using NAGP.Services.ServiceAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NAGP.Services.ServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly ServiceRepository serviceRepository;
        public ServiceController()
        {
            serviceRepository = new ServiceRepository();
        }

        // GET: api/<ServiceController>
        [HttpGet]
        public List<Service> GetServices()
        {
            var services = serviceRepository.GetServices();
            return services;
        }

        // GET api/<ServiceController>/5
        [HttpGet("{id}")]
        public Service Get(int id)
        {
            return serviceRepository.GetServiceById(id);
        }
    }
}
