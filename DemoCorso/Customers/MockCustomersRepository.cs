using DemoCorso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCorso.Customers
{
    public class MockCustomersRepository : ICustomersRepository
    {
        private static List<DemoCustomer> customers = new List<DemoCustomer>()
        {
            new DemoCustomer { Id = Guid.NewGuid(), Name = "Mario Rossi", PhoneNumber = "1234"},
            new DemoCustomer { Id = Guid.NewGuid(), Name = "Luigi Bianchi", PhoneNumber = "5678"},
            new DemoCustomer { Id = Guid.NewGuid(), Name = "Giuseppe Verdi", PhoneNumber = "90000"}
        };

        public async Task CreateCustomer(DemoCustomer customer)
        {
            await DoSomethingAsync();
            customers.Add(customer);
        }

        public async Task<DemoCustomer?> GetCustomer(Guid id)
        {
            await DoSomethingAsync();
            return customers.Where(x=> x.Id == id).FirstOrDefault();
        }

        public async Task<List<DemoCustomer>> GetCustomers()
        {
            await DoSomethingAsync();
            return customers;
        }

        private Task DoSomethingAsync()
        {
            return Task.CompletedTask;
        }
    }
}
