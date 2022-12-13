using DemoCorso.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoCorso.Customers;

public interface ICustomersRepository
{
    Task<List<DemoCustomer>> GetCustomers();
    Task<DemoCustomer?> GetCustomer(Guid id);
    Task CreateCustomer(DemoCustomer customer); 
}
