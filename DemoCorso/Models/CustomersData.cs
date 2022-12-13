using System.Collections.Generic;
using System.Windows.Documents;

namespace DemoCorso.Models;

public class CustomersData
{
    public List<Customer> Customers { get; private set; }

	public CustomersData()
	{
		Customers = new List<Customer>()
		{
			new Customer() { Name = "Mario", Surname = "Rossi", PhoneNumber = "123"},
            new Customer() { Name = "Luig", Surname = "Bianchi", PhoneNumber = "456"},
            new Customer() { Name = "Giuseppe", Surname = "Verdi", PhoneNumber = "789"}
        };
	}
}
