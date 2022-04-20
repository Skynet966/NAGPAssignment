using NAGP.Services.CustomerAPI.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NAGP.Services.CustomerAPI.Repositories
{
    public class CustomerRepository
    {
        private readonly List<Customer> customers;

        public CustomerRepository()
        {
            customers = new List<Customer>
            {
                new Customer{Id = 1, Name ="sumit", ContactNumber="9871778941", Address="Rohtak, Haryana"},
                new Customer{Id = 2, Name ="amit", ContactNumber="9871778931", Address="Dwarka, Delhi"},
                new Customer{Id = 3, Name ="ronit", ContactNumber="9871778942", Address="Gurugram, Haryana"},
                new Customer{Id = 4, Name ="tina", ContactNumber="9871778932", Address="Noida, UP"},
            };
        }

        public async Task<List<Customer>> Customers()
        {
            return customers;
        }

        public Customer GetCustomerById(int id)
        {
            return customers.FirstOrDefault(x => x.Id == id);
        }
    }
}
