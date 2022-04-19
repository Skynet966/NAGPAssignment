using MassTransit;
using Microsoft.AspNetCore.Mvc;
using NAGP.Services.CustomerAPI.Entities;
using NAGP.Services.CustomerAPI.Repositories;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NAGP.Services.CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerRepository customerRepository;
        
        public CustomerController()
        {
            customerRepository = new CustomerRepository();
        }
        // GET: api/<ProviderController>
        [HttpGet]
        public List<Customer> GetCustomers()
        {
            return customerRepository.Customers();
        }

        // GET api/<ProviderController>/5
        [HttpGet("{id}")]
        public Customer GetCustomer(int id)
        {
            return customerRepository.GetCustomerById(id);
        }

        // POST api/<ProviderController>
        [HttpPost("Login")]
        public string Login(string username, string password)
        {
            return customerRepository.IsValidCustomer(username, password) ? "Welcome" : "Username or password not correct!!!";
        }
    }
}
