using DemoCorso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCorso.Customers;

public class MockCustomersRepository : ICustomersRepository
{
    private static List<Customer> customers = new List<Customer>()
    {
            new Customer() { Name = "Mario", Surname = "Rossi", PhoneNumber = "123"},
            new Customer() { Name = "Luig", Surname = "Bianchi", PhoneNumber = "456"},
            new Customer() { Name = "Giuseppe", Surname = "Verdi", PhoneNumber = "789"}
    };

    public async Task CreateCustomerAsync(Customer customer)
    {
        await DoSomething();
        customers.Add(customer);
    }

    public async Task DeleteCustomerAsync(Guid id)
    {
        var customer = await GetCustomerByIdAsync(id);
        if(customer != null)
        {
            customers.Remove(customer);
        }
    }

    public async Task<Customer?> GetCustomerByIdAsync(Guid id)
    {
        await DoSomething();
        return customers.FirstOrDefault(x => x.Id == id);
    }

    public async Task<List<Customer>> GetCustomersAsync()
    {
        await DoSomething();
        return customers;
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
        await DeleteCustomerAsync(customer.Id);
        await CreateCustomerAsync(customer);
    }

    private Task DoSomething()
    {
        return Task.CompletedTask;
    }


}
