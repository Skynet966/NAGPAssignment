using Microsoft.AspNetCore.Mvc;
using NAGP.Services.ProviderAPI.Entities;
using NAGP.Services.ProviderAPI.Repositories;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NAGP.Services.ProviderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly ProviderRepository providerRepository;
        public ProviderController()
        {
            providerRepository = new ProviderRepository();
        }
        // GET: api/<ProviderController>
        [HttpGet]
        public List<Provider> GetProviders()
        {
            return providerRepository.Providers();
        }
        [HttpGet("Available/{serviceId}")]
        public List<Provider> GetAvailableProviders(int serviceId)
        {
            return providerRepository.AvailableProviders(serviceId);
        }
        // GET api/<ProviderController>/5
        [HttpGet("{id}")]
        public Provider GetProvider(int id)
        {
            return providerRepository.GetProviderById(id);
        }
        // POST api/<ProviderController>
        [HttpPost("Login")]
        public string Login(string username, string password)
        {
            return providerRepository.IsValidProvider(username, password)?"Welcome":"Username or password not correct!!!";
        }
    }
}
