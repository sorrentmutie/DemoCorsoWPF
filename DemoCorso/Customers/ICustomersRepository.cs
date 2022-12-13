using DemoCorso.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoCorso.Customers;

public interface ICustomersRepository
{
    Task<List<Customer>> GetCustomersAsync();
    Task<Customer?> GetCustomerByIdAsync(Guid id);
    Task CreateCustomerAsync(Customer customer);
    Task DeleteCustomerAsync(Guid id);
    Task UpdateCustomerAsync(Customer customer);
}
