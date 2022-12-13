using DemoCorso.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DemoCorso.Customers;

public class CustomerListViewModel: ViewModelBase
{
    private ICustomersRepository? repository = null;
        // = new MockCustomersRepository();

    public ObservableCollection<Customer> Customers { get; set; } = new();
    private Customer? customer;
    public Customer? SelectedCustomer
    {
        get { return customer; }
        set { 
            if(customer== value) return;
            customer = value;
            NotifyPropertyChanged();
        }
    }
    //public Customer? SelectedCustomer { get; set; }

    public CustomerListViewModel(ICustomersRepository repository)
    {
        if (DesignerProperties.GetIsInDesignMode(
           new System.Windows.DependencyObject())) return;

        var customers = repository.GetCustomersAsync().Result;
        Customers = new ObservableCollection<Customer>(customers);
        this.repository = repository;
    }

}
