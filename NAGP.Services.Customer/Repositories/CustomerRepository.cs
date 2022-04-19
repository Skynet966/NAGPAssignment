using NAGP.Services.CustomerAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NAGP.Services.CustomerAPI.Repositories
{
    public class CustomerRepository
    {
        private readonly List<Customer> customers;

        public CustomerRepository()
        {
            customers = new List<Customer>
            {
                new Customer{Id = 1, Name ="sumit", Username="sumit@123", Password="sumit@123", ContactNumber="9871778941", Address="Rohtak, Haryana"},
                new Customer{Id = 2, Name ="amit", Username="amit@123", Password="amit@123", ContactNumber="9871778931", Address="Dwarka, Delhi"},
                new Customer{Id = 3, Name ="ronit", Username="ronit@123", Password="ronit@123", ContactNumber="9871778942", Address="Gurugram, Haryana"},
                new Customer{Id = 4, Name ="tina", Username="tina@123", Password="tina@123", ContactNumber="9871778932", Address="Noida, UP"},
            };
        }

        public List<Customer> Customers()
        {
            return customers;
        }

        public Customer GetCustomerById(int id)
        {
            return customers.FirstOrDefault(x => x.Id == id);
        }

        public bool IsValidCustomer(string username, string password)
        {
            Customer customer= customers.FirstOrDefault(x => x.Username == username && x.Password == password);
            return customer != null;
        }
    }
}
