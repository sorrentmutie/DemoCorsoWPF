using DemoCorso.Models;
using DemoCorso.StartupHelpers;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DemoCorso.Customers;

public class CustomerListViewModel: MyViewModelBase
{
    private ICustomersRepository? repository = null;
        // = new MockCustomersRepository();

    public RelayCommand DeleteCommand { get; set; }
    public RelayCommand AddOrderCommand { get; set; }
    public RelayCommand EditCustomer { get; set; }
    public event Action<Guid> PlaceOrderRequested = delegate { };
    public event Action<Customer> EditCustomerRequested = delegate { };


    public ObservableCollection<Customer> Customers { get; set; } = new();
    private Customer? customer;
    public Customer? SelectedCustomer
    {
        get { return customer; }
        set {
            SetProperty(ref customer, value);
        }
    }
    //public Customer? SelectedCustomer { get; set; }

    public CustomerListViewModel(ICustomersRepository repository)
    {
        //if (DesignerProperties.GetIsInDesignMode(
        //   new System.Windows.DependencyObject())) return;

       // var customers = repository.GetCustomersAsync().Result;
        Customers = new ObservableCollection<Customer>();
        this.repository = repository;

        DeleteCommand = new RelayCommand(OnDelete, CanExecuteDelete);
        AddOrderCommand = new RelayCommand(OnAddOrder);
        EditCustomer = new RelayCommand(OnEditCustomer);



    }

    private void OnEditCustomer()
    {
        EditCustomerRequested(customer!);
    }

    private void OnAddOrder()
    {
        PlaceOrderRequested(customer!.Id);
    }

    public async void LoadCustomers()
    {
        //if (DesignerProperties.GetIsInDesignMode(
        //   new System.Windows.DependencyObject())) return;
        var customers = await repository!.GetCustomersAsync();
        foreach (var customer in customers)
        {
            Customers.Add(customer);
        }
    }


    private bool CanExecuteDelete()
    {
        return SelectedCustomer != null;
    }

    private void OnDelete()
    {
        if(SelectedCustomer!=null)
        {
            Customers.Remove(SelectedCustomer);
        }
    }
}
